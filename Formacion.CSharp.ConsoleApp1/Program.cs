using Formacion.CSharp.ConsoleApp1.Models;
using Microsoft.VisualBasic;

namespace Formacion.CSharp.ConsoleApp1;
/// <summary>
/// La clase Program es donde se encuentra el método Main, donde inicia la ejecución del programa
/// </summary>
class Program
{
    /// <summary>
    /// Método Main, inicio del programa
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Console.Clear();
        //DeclaracionVariables();
        ConversionVariables();
    }

    /// <summary>
    /// Declaración de Variables
    /// </summary>
    static void DeclaracionVariables()
    {
        string texto = "Hola Mundo !!!";
        string otroTexto;
        System.String texto2 = "Mi nombre el Alejandro";
        int numero = 10;
        int otroNumero;
        System.Int32 numero2 = 0;

        decimal a, b, c;

        // Instanciamos un objeto Alumno y modificamos sus variables
        Alumno alumno = new Alumno();
        alumno.Nombre = "Alejandro";
        alumno.Apellidos = "Gallardo";
        alumno.Edad = 27;
        
        // Instanciamos un objeto Alumno y asignamos valores a sus variables
        Alumno alumno1 = new Alumno()
        {
            Nombre = "Julian",
            Apellidos = "Sánchez",
            Edad = 25
        };

        // Instanciamos un objeto Alumno usando VAR, OBJECT, DYNAMIC

        // Las variables con un tipo implícito VAR siempre se deben inicializar
        var alumno2 = new Alumno();
        alumno2.Nombre = "María José";

        Console.WriteLine($"Tipo 2: {alumno2.GetType()}");
        Console.WriteLine($"Nombre 2: {alumno2.Nombre}\n");

        // OBJECT tiene la capacidad de contener cualquier tipo de dato, se comprueba en diseño
        // No permite acceder a los miempros del objeto, para acceder tenemos que aplicar la conversión
        Object alumno3 = new Alumno();
        ((Alumno)alumno3).Nombre = "Isabel";
        // alumno3.Nombre = "Isabel"; <- No funciona por ser un Object

        Console.WriteLine($"Tipo 3: {alumno3.GetType()}");
        Console.WriteLine($"Nombre 3: {((Alumno)alumno3).Nombre}\n");
        //Console.WriteLine($"Nombre 3: {alumno3.Nombre}"); <- No funciona por ser un Object 
        
        // DYNAMIC tiene la capacidad de contener cualquier tipo de dato, se comprueba en ejecución
        dynamic alumno4 = new Alumno();
        alumno4.Nombre = "Antonio José";
        alumno4.Edad = 30;

        Console.WriteLine($"Tipo 4: {alumno4.GetType()}");
        Console.WriteLine($"Nombre 4: {alumno4.Nombre}\n");

        // Sintaxis C# de versiones más actuales
        Alumno alumno5 = new();
        alumno5.Nombre = "Paula";

        Console.WriteLine($"Tipo 5: {alumno5.GetType()}");
        Console.WriteLine($"Nombre 5: {alumno5.Nombre}\n");
    }

    /// <summary>
    /// Conversión de variables
    /// </summary>
    static void ConversionVariables()
    {
        byte num1 = 10;         //  8 bits
        int num2 = 32;          // 32 bits
        string num3 = "42";     // bits variables según contenido

        Console.WriteLine($"Num1: {num1} - Num2: {num2} - Num3: {num3}");

        // Conversión Implicita, SI es posible si el receptor es de mayor tamaño en bits
        num2 = num1;

        // Conversión Implicita, NO es posible si el receptro es de menor tamaño en bits
        //num1 = num2;

        // La opción es una conversión Explicita, indicada por el programador
        // Es válida si el valor está comprendido entre los valores de la variable receptora
        num2 = 1532;
        num1 = (byte)num2;

        // Conversión explicita, utilizando los métodos del objeto CONVERT
        // Para valores fuera del rango de la variable receptora genera una excepción
        num2 = 32;
        num1 = Convert.ToByte(num2);
        num1 = Convert.ToByte(num3);

        Console.WriteLine("Después de la conversión");
        Console.WriteLine($"Num1 (byte): {num1} - Num2 (int): {num2} - Num3 (string): {num3}");
    }
}