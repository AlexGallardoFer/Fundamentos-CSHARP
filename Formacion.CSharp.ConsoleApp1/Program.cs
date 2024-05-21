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
        DeclaracionVariables();
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
}