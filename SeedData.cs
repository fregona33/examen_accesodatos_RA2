namespace PreExamenRA2;

/// <summary>Datos iniciales del vivero. Ya vienen dados: no hay que escribirlos.</summary>
public static class SeedData
{
    public static readonly string[] Categorias = { "Interior", "Exterior", "Aromatica", "Suculenta" };

    public static readonly (string Nombre, string Categoria, decimal Precio, int Stock)[] Plantas =
    {
        ("Monstera",        "Interior",  18.50m, 12),
        ("Ficus Benjamina", "Interior",  24.90m,  8),
        ("Sansevieria",     "Interior",  12.30m,  0),
        ("Pothos",          "Interior",   9.50m, 22),
        ("Hibisco",         "Exterior",  15.75m,  6),
        ("Jazmín",          "Exterior",  14.20m, 10),
        ("Olivo",           "Exterior",  39.90m,  3),
        ("Geranio",         "Exterior",   6.80m,  0),
        ("Albahaca",        "Aromatica",  2.90m, 30),
        ("Romero",          "Aromatica",  4.50m,  4),
        ("Menta",           "Aromatica",  3.20m,  2),
        ("Tomillo",         "Aromatica",  3.80m, 15),
    };
}
