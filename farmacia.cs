
    using System;
using System.Collections.Generic;

class Farmacia
{
    // Diccionario para el inventario
    static Dictionary<string, (int cantidad, double precio)> inventario =
        new Dictionary<string, (int, double)>();

    static double totalVentas = 0;

    static void Main()
    {
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("=== FARMACIA DE JUAN ===");
            Console.WriteLine("1. Registrar medicamento");
            Console.WriteLine("2. Consultar inventario");
            Console.WriteLine("3. Vender medicamento");
            Console.WriteLine("4. Mostrar total de ventas del día");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RegistrarMedicamento();
                    break;
                case 2:
                    ConsultarInventario();
                    break;
                case 3:
                    VenderMedicamento();
                    break;
                case 4:
                    MostrarTotalVentas();
                    break;
                case 5:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

        } while (opcion != 5);
    }

    // Función para registrar medicamentos
    static void RegistrarMedicamento()
    {
        Console.Write("Nombre del medicamento: ");
        string nombre = Console.ReadLine();

        Console.Write("Cantidad disponible: ");
        int cantidad = int.Parse(Console.ReadLine());

        Console.Write("Precio: ");
        double precio = double.Parse(Console.ReadLine());

        if (inventario.ContainsKey(nombre))
        {
            Console.WriteLine("El medicamento ya existe. Se actualizará la cantidad.");
            inventario[nombre] = (inventario[nombre].cantidad + cantidad, precio);
        }
        else
        {
            inventario.Add(nombre, (cantidad, precio));
            Console.WriteLine("Medicamento registrado correctamente.");
        }
    }

    // Función para consultar inventario
    static void ConsultarInventario()
    {
        Console.WriteLine("\n--- INVENTARIO ACTUAL ---");

        if (inventario.Count == 0)
        {
            Console.WriteLine("No hay medicamentos registrados.");
            return;
        }

        foreach (var item in inventario)
        {
            Console.WriteLine($"Medicamento: {item.Key} | Cantidad: {item.Value.cantidad} | Precio: {item.Value.precio:C}");
        }
    }

    // Función para vender medicamentos
    static void VenderMedicamento()
    {
        Console.Write("Ingrese el nombre del medicamento a vender: ");
        string nombre = Console.ReadLine();

        if (!inventario.ContainsKey(nombre))
        {
            Console.WriteLine("El medicamento no existe.");
            return;
        }

        Console.Write("Cantidad a vender: ");
        int cantidadVenta = int.Parse(Console.ReadLine());

        var medicamento = inventario[nombre];

        if (cantidadVenta > medicamento.cantidad)
        {
            Console.WriteLine("No hay suficiente stock.");
            return;
        }

        medicamento.cantidad -= cantidadVenta;
        inventario[nombre] = medicamento;

        double venta = cantidadVenta * medicamento.precio;
        totalVentas += venta;

        Console.WriteLine($"Venta realizada. Total: {venta:C}");
    }

    // Función para mostrar total de ventas
    static void MostrarTotalVentas()
    {
        Console.WriteLine($"Total de ventas del día: {totalVentas:C}");
    }
}


    