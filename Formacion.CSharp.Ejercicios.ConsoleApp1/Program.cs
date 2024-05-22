namespace Formacion.CSharp.Ejercicios.ConsoleApp1;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Ejercicio1();
        Ejercicio2();
        Ejercicio3();
        Ejercicio4();
    }

    // Pedir un número por consola y analizarlo para retornar uno de los dos mensajes:
    // -> El número introducido es [valor]
    // -> No se ha introducido un número o no se puede convertir
    static void Ejercicio1()
    {
        Console.Write("Introduzca un número: ");
        string respuesta = Console.ReadLine();
        int valor;
        Console.WriteLine(int.TryParse(respuesta, out valor) ? $"[{valor}]" : "No se ha introducido un número o no se puede convertir");
    }

    // Pedir un número con parte decimal por consola y convertirlo a float con .Parse
    // Controlar las excepciones FormatExcepcion y OverflowException
    // Mostras las mensajes en caso de error, de mal formato o número demasiado grande
    static void Ejercicio2()
    {

    }

    // Preguntar por consola una fecha
    // Convertir a DateTime utilizando TryParse
    // Si se puede conventir muestra la fecha que retorna la ejecución del método .ToLongDateString()
    static void Ejercicio3()
    {
        Console.Write("Introduzca una fecha: ");
        string respuesta = Console.ReadLine();
        DateTime fecha;
        Console.WriteLine(DateTime.TryParse(respuesta, out fecha) ? fecha.ToLongDateString() : "No se ha introducido una fecha válida o no se puede convertir");
    }

    // Repite el ejercicio anterior utilizando Convert
    static void Ejercicio4()
    {

    }
}
