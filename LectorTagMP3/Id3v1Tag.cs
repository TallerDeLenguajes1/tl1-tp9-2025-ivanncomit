using System.Text;

public class Id3v1Tag
{
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public string Album { get; set; }
    public string Anio { get; set; }

    public static Id3v1Tag LeerDesdeArchivo(string path)
    {
        const int tamañoTag = 128;

        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        {
            fs.Seek(-tamañoTag, SeekOrigin.End);
        }

        byte[] buffer = new byte[tamañoTag];
        fs.Read(buffer, 0, tamañoTag); // Leer los 128 bytes

        var latin1 = Encoding.GetEncoding("latin1");

        return new Id3v1Tag
        {
            Titulo = latin1.GetString(buffer, 3, 30),
            Artista = latin1.GetString(buffer, 33, 30),
            Album = latin1.GetString(buffer, 63, 30),
            Anio = latin1.GetString(buffer, 93, 4)
        };
    }
}
    

