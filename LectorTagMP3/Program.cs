// See https://aka.ms/new-console-template for more information

Console.WriteLine("Ingrese la ruta del archivo MP3 a analizar:");
string path = Console.ReadLine();


Id3v1Tag tag = Id3v1Tag.LeerDesdeArchivo(path);

Console.WriteLine("\nInformación del archivo:");
Console.WriteLine($"Título : {tag.Titulo}");
Console.WriteLine($"Artista: {tag.Artista}");
Console.WriteLine($"Álbum  : {tag.Album}");
Console.WriteLine($"Año    : {tag.Anio}");


