// See https://aka.ms/new-console-template for more information
using System.Reflection.PortableExecutable;

Console.WriteLine("Ingrese un directorio para analizar: ");

string pathIndicado;
string[] directorios, archivos;

do
{
    pathIndicado = Console.ReadLine();

    if (!Directory.Exists(pathIndicado))
    {
        Console.WriteLine("Ingrese un PATH valido: ");
    }

} while (!Directory.Exists(pathIndicado));

var filesPathIndicado = Directory.GetFiles(pathIndicado);
if (filesPathIndicado == null)
{
    System.Console.WriteLine("\nEl Directorio no tiene archivos\n");
}
else
{
    System.Console.WriteLine("\nEl Directorio tiene los archivos:\n");
    foreach (var archivo in filesPathIndicado)
    {
        var aux = new FileInfo(archivo);
        Console.WriteLine($"Archivo: {Path.GetFileName(archivo)} - Peso: {aux.Length / 1024}KB");
    }
}

directorios = Directory.GetDirectories(pathIndicado);

Console.WriteLine("\nCarpetas en el Path Indicado:");

foreach (var carpetas in directorios)
{
    archivos = Directory.GetFiles(carpetas);
    var carpeta = carpetas.Split("\\");
    Console.WriteLine($"\n-------Archivos de la Carpeta: {carpeta[carpeta.Length - 1]}-------");
    foreach (var archivo in archivos)
    {
        var aux = new FileInfo(archivo);
        Console.WriteLine($"Archivo: {Path.GetFileName(archivo)} - Peso: {aux.Length / 1000}KB");
    }

}
Console.WriteLine("\n");
