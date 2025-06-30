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


string rutaCsv = Path.Combine(pathIndicado, "reporte_archivos.csv");

FileStream filestream = new FileStream(rutaCsv, FileMode.Create, FileAccess.Write);
StreamWriter escritorcsv = new StreamWriter(filestream);

escritorcsv.WriteLine("Archivo, Tamaño, Fecha de Modificacion");

string[] filesPathIndicado = Directory.GetFiles(pathIndicado);



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
        escritorcsv.WriteLine($"{Path.GetFileName(archivo)},{aux.Length / 1000}KB,{aux.LastWriteTime.ToString("yyyy-MM-dd")}");
    }
}

directorios = Directory.GetDirectories(pathIndicado);

Console.WriteLine("\nCarpetas en el Path Indicado:");

foreach (var carpetas in directorios)
{
    archivos = Directory.GetFiles(carpetas);
    string[] carpeta = carpetas.Split("\\");

    //     C:\\Usuarios\\Escritorio\\CarpetaTDL
    //     carpeta[0]=C:
    //     carpeta[1]=Usuarios
    //     ...
    //     carpeta[length-1] = nombre de la carpeta
    //     C:\\Usuarios\\Escritorio\\CarpetaTDL\\ 
    //     C:\\Usuarios\\Escritorio\\CarpetaTDL\\EJ2

    Console.WriteLine($"\n-------Archivos de la Carpeta: {carpeta[carpeta.Length - 1]}-------");
    foreach (var archivo in archivos)
    {
        var aux = new FileInfo(archivo);
        Console.WriteLine($"Archivo: {Path.GetFileName(archivo)} - Peso: {aux.Length / 1000}KB");

        escritorcsv.WriteLine($"{Path.GetFileName(archivo)},{aux.Length / 1000}KB,{aux.LastWriteTime.ToString("yyyy-MM-dd")}");
    }

}

escritorcsv.Close();


Console.WriteLine("CSV GENERADO\n");
