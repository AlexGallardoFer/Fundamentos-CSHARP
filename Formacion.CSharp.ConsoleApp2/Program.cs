using Formacion.CSharp.ConsoleApp2.Models;

namespace Formacion.CSharp.ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        Alumno alumno = new Alumno();
        alumno.Nombre = "Alejandro";
        alumno.Apellidos = "Gallardo";
        alumno.Edad = 27;
        alumno.CambiaEdad = 3;

        Console.WriteLine($"Nombre: {alumno.Nombre} {alumno.Apellidos}");
        Console.WriteLine($"Edad: {alumno.Edad}");  

        Console.WriteLine($"Nombre Completo: {alumno.NombreCompleto}");  
    }
}
