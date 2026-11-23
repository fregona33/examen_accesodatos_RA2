using System.Text.Json;
using MySqlConnector;
namespace PreExamenRA2;

/// <summary>
/// Aquí va tu código. Puedes crear más clases y ficheros si lo necesitas.
/// No cambies las firmas de estos métodos: el menú de Program.cs los llama.
/// </summary>
public static class Examen
{
    static string CadenaConexion()
    {
        string ruta = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

        if (!File.Exists(ruta))
        {
            throw new FileNotFoundException("Archivo no encontrado");
        }

        ConfigBD config = ConfigBD.Cargar();
        var cadena = new MySqlConnectionStringBuilder
        {
            Server = config.Servidor,
            Port = (uint)config.Puerto,
            Database = config.Nombre,
            UserID = config.Usuario,
            Password = config.Password
        };
        return cadena.ConnectionString;
    }

    public static void Tarea1_Conectar()
    {
        using var conexion = new MySqlConnection(CadenaConexion());
        conexion.Open();
        
        Console.WriteLine($"Conexión correcta. Versión {conexion.ServerVersion}");
    }

    public static void Tarea2_CrearEstructura()
    {
        using var conexion = new MySqlConnection(CadenaConexion());
        conexion.Open();

        using var comando = conexion.CreateCommand();

        comando.CommandText = "DROP TABLE IF EXISTS Planta";
        comando.ExecuteNonQuery();

        comando.CommandText = "DROP TABLE IF EXISTS Categoria";
        comando.ExecuteNonQuery();

        comando.CommandText = """
                              CREATE TABLE Categoria (
                                  Id INT AUTO_INCREMENT PRIMARY KEY,
                                  Nombre VARCHAR(40) NOT NULL UNIQUE
                                                     ) ENGINE=InnoDB
                              """;
        comando.ExecuteNonQuery();

        comando.CommandText = """
                              CREATE TABLE Planta (
                                  Id INT AUTO_INCREMENT PRIMARY KEY,
                                  Nombre VARCHAR(60) NOT NULL,
                                  CategoriaId INT NOT NULL,
                                  Precio DECIMAL(10, 2) NOT NULL CHECK (Precio > 0),
                                  Stock INT NOT NULL DEFAULT 0 CHECK (Stock >= 0),
                                  FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id)
                              ) ENGINE=InnoDB
                              """;
        comando.ExecuteNonQuery();
        
        Console.WriteLine("Tablas Categoría y Planta creadas correctamente. ");
    }

    public static void Tarea3_CargarDatos()
    {
        using var conexion = new MySqlConnection(CadenaConexion());
        conexion.Open();
        
        var ids = new Dictionary<string, int>();

        using (var cmdCat = new MySqlCommand("INSERT INTO Categoria (Nombre) VALUES (@nombre)", conexion))
        {
            MySqlParameter pNombre = cmdCat.Parameters.Add("@nombre", MySqlDbType.VarChar);
            foreach (string cat in SeedData.Categorias)
            {
                pNombre.Value = cat;
                cmdCat.ExecuteNonQuery();
                ids[cat] = (int)cmdCat.LastInsertedId;
            }
        }

        int insertadas = 0;
        using (var cmdPl = new MySqlCommand(
                   "INSERT INTO Planta (Nombre, CategoriaId, Precio, Stock) VALUES (@nombre, @cat, @precio, @stock"))
        {
            cmdPl.Parameters.Add("@nombre", MySqlDbType.VarChar);
            cmdPl.Parameters.Add("@cat", MySqlDbType.Int32);
            cmdPl.Parameters.Add("@precio", MySqlDbType.Decimal);
            cmdPl.Parameters.Add("@stock", MySqlDbType.Int32);

            foreach (var p in SeedData.Plantas)
            {
                cmdPl.Parameters["@nombre"].Value = p.Nombre;
                cmdPl.Parameters["@cat"].Value = ids[p.Categoria];
                cmdPl.Parameters["@precio"].Value = p.Precio;
                cmdPl.Parameters["@stock"].Value = p.Stock;
                insertadas += cmdPl.ExecuteNonQuery();
            }
        }
        Console.WriteLine($"Categorias insertadas: {ids.Count}. Plantas insertadas: {insertadas}");
    }

    public static void Tarea4_ModificarDatos(string categoria, int porcentaje)
    {
        throw new NotImplementedException();
    }

    public static void Tarea5_ConsultasSql(string categoria, decimal precioMax)
    {
        throw new NotImplementedException();
    }

    public static void Tarea6_ConsultasLinq()
    {
        throw new NotImplementedException();
    }
}
