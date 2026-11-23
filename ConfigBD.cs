using System.Text.Json;

namespace PreExamenRA2;

/// <summary>Datos de conexión leídos de appsettings.json (sección "BaseDatos").</summary>
public class ConfigBD
{
    public string Servidor { get; set; } = "";
    public int Puerto { get; set; } = 3306;
    public string Usuario { get; set; } = "";
    public string Password { get; set; } = "";
    public string Nombre { get; set; } = "";

    private class Raiz
    {
        public ConfigBD BaseDatos { get; set; } = new();
    }

    public static ConfigBD Cargar()
    {
        string ruta = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        string json = File.ReadAllText(ruta);
        var raiz = JsonSerializer.Deserialize<Raiz>(json)
                   ?? throw new InvalidOperationException("appsettings.json vacío o no válido");
        return raiz.BaseDatos;
    }
}
