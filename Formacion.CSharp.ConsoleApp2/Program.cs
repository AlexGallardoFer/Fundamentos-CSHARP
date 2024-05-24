using Formacion.CSharp.ConsoleApp2.Models;

namespace Formacion.CSharp.ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        // Class, de tipo referencia
        Alumno first = new Alumno() { Nombre = "Alejandro", Edad = 27};
        Alumno second = first;

        Console.WriteLine($"Nombre: {first.Nombre} - Edad: {first.Edad}");
        second.Edad = 40;
        Console.WriteLine($"Nombre: {first.Nombre} - Edad: {first.Edad}");


        Alumno alumno = new Alumno() { Nombre = "Alejandro", Edad = 27 };
        alumno.DiaTutoria = Dias.Miercoles;
        alumno.Estado = Estados.Operativo;

        int num = 3;
        Console.WriteLine($"Demo: {(Dias)num}");

        Console.WriteLine($"Nombre: {alumno.Nombre} - Edad: {alumno.Edad}");
        Console.WriteLine($"Tutoría los {alumno.DiaTutoria}");
        Console.WriteLine($"Estado: {alumno.Estado}");

        // Struct, de tipo Valor
        Alumno2 first2 = new Alumno2() { Nombre = "Alejandro", Edad = 27 };
        Alumno2 second2 = first2;

        Console.WriteLine($"Nombre: {first2.Nombre} - Edad: {first2.Edad}");
        second2.Edad = 40;
        Console.WriteLine($"Nombre: {first2.Nombre} - Edad: {first2.Edad}");


        Alumno2 alumno2 = new Alumno2() { Nombre= "Alejandro", Edad= 27 };

        Console.WriteLine($"Nombre: {alumno2.Nombre} - Edad: {alumno2.Edad}");
        Transformar2(ref alumno2);
        Console.WriteLine($"Nombre: {alumno2.Nombre} - Edad: {alumno2.Edad}");

        int numero = 10;
        Transformar(ref numero);
        Console.WriteLine($"Número: {numero}");

        string num2 = "10";
        int num3 = 0;
        string texto = "";
        bool resultado = TryParseToInt(num2, out num3, out texto);

        Console.WriteLine($"Resultado: {resultado}");
        Console.WriteLine($"Resultado: {texto}");
        Console.WriteLine($"Valor: {num2}");

    }

    static public bool TryParseToInt(string num, out int result, out string demo)
    {
        try
        {
            result = Convert.ToInt32(num);
            demo = "OK";
            return true;
        }
        catch (Exception)
        {
            result = 0;
            demo = "NOK";
            return false;
        }
    }

    static public void Transformar(ref int n)
    {
        n = 100;
        Console.WriteLine($"Número: {n}");
    }

    static void Transformar(Alumno alumno)
    {
        alumno.Edad = 40;
        Console.WriteLine($"Ahora la edad es: {alumno.Edad}");
    }

    static void Transformar2(ref Alumno2 alumno)
    {
        alumno.Edad = 40;
        Console.WriteLine($"Ahora la edad es: {alumno.Edad}");
    }
}
