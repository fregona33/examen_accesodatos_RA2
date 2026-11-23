using PreExamenRA2;

Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== VIVERO LEVANTE · Pre-examen RA2 ===");
    Console.WriteLine("1. Conectar");
    Console.WriteLine("2. Crear estructura");
    Console.WriteLine("3. Cargar datos iniciales");
    Console.WriteLine("4. Modificar datos");
    Console.WriteLine("5. Consultas SQL");
    Console.WriteLine("6. Consultas LINQ");
    Console.WriteLine("0. Salir");
    Console.Write("Opción: ");

    string? opcion = Console.ReadLine();
    if (opcion == "0") break;

    try
    {
        switch (opcion)
        {
            case "1": Examen.Tarea1_Conectar(); break;
            case "2": Examen.Tarea2_CrearEstructura(); break;
            case "3": Examen.Tarea3_CargarDatos(); break;
            case "4":
                Console.Write("Categoría a rebajar: ");
                string catRebaja = Console.ReadLine() ?? "";
                Console.Write("Porcentaje de descuento (entero): ");
                int porcentaje = int.Parse(Console.ReadLine() ?? "0");
                Examen.Tarea4_ModificarDatos(catRebaja, porcentaje);
                break;
            case "5":
                Console.Write("Categoría: ");
                string categoria = Console.ReadLine() ?? "";
                Console.Write("Precio máximo: ");
                decimal precioMax = decimal.Parse(Console.ReadLine() ?? "0",
                                                  System.Globalization.CultureInfo.InvariantCulture);
                Examen.Tarea5_ConsultasSql(categoria, precioMax);
                break;
            case "6": Examen.Tarea6_ConsultasLinq(); break;
            default: Console.WriteLine("Opción no válida."); break;
        }
    }
    catch (NotImplementedException)
    {
        Console.WriteLine("Tarea sin implementar todavía.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"ERROR: {ex.Message}");
    }
}
