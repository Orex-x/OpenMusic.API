namespace OpenMusic.API.Models;

public class MySong
{
    public string Name { get; set; }
    public string Author { get; set; }
    
    public byte[] Data { get; set; }
}