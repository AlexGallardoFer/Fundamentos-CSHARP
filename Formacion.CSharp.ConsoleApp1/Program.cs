using Formacion.CSharp.ConsoleApp1.Models;

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
        //ConversionVariables();
        //SentenciasControl();
        //SentenciasRepeticion();
        ControlExcepciones();
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
        Console.WriteLine($"Num1 (byte): {num1} - Num2 (int): {num2} - Num3 (string): {num3}\n");

        ///////////////////////////////////////////////////////////////////
        // Transformaciones de STRING a cualquier tipo de dato numérico  //
        ///////////////////////////////////////////////////////////////////

        // Utilizando los métodos del objeto CONVERT
        num1 = Convert.ToByte(num3);
        num2 = Convert.ToInt32(num3);

        // Conversión explícita, utilizando el método Parse
        num1 = byte.Parse(num3);

        // Conversión explícita, utilizando el método TryParse
        byte.TryParse(num3, out num1);


        // El método .TryParse() retorna TRUE/FALSE dependiendo de si la trasnformación es posible
        // El resultado de la transformación se almacena en num4, siendo 0 si la transformación no es posible
        num3 = "102";
        int num4;
        bool result = int.TryParse(num3, out num4);
        Console.WriteLine($"Resultado: {result} - Valor num4: {num4}\n");


        // En este ejemplo solo comprobamos si la transformación es posible
        // Mediante [out _] indicamos que no queremos el resultado de la transformación
        bool num5 = int.TryParse(num3, out _);
        Console.WriteLine($"Resultado: {result} - Valor num5: {num5}\n");
    }

    /// <summary>
    /// 
    /// </summary>
    static void SentenciasControl()
    {
        // Uso de IF/ELSE
        Reserva reserva = new Reserva();

        Console.Write("ID de la reserva: ");
        reserva.id = Console.ReadLine();

        Console.Write("Nombre del cliente: ");
        reserva.cliente = Console.ReadLine();

        Console.Write("Tipo de reserva: (100, 200, 300, 400) ");
        // Opcion A
        string respuesta = Console.ReadLine();
        int.TryParse(respuesta, out reserva.tipo);

        // Opcion B
        //int.TryParse(Console.ReadLine(), out reserva.tipo);

        Console.Write("Es fumador? (Sí o No) ");
        string fumador = Console.ReadLine();

        // Opción 1, utilizando IF/ELSE
        if (fumador.ToLower().Trim() == "si" || fumador.ToLower().Trim() == "sí")
            reserva.fumador = true;
        else
            reserva.fumador = false;

        // Opción 2, utilizando IF/ELSE-IF
        if (fumador.ToLower().Trim() == "si" || fumador.ToLower().Trim() == "sí")
            reserva.fumador = true;
        else if (fumador.ToLower().Trim() == "no")
            reserva.fumador = false;
        else
        {
            reserva.fumador = false;
            Console.WriteLine($"El valor {fumador} no es válido pero se asigna habitación de no fumador");
        }
        // Opción 3, asignación condicional con ? :
        reserva.fumador = (fumador.ToLower().Trim() == "si" || fumador.ToLower().Trim() == "sí") ? true : false;

        // Opción 4, utilizando SWITCH
        switch(fumador.ToLower().Trim())
        {
            case "si":
                reserva.fumador = true;
                break;
            case "sí":
                reserva.fumador = true;
                break;
            case "no":
                reserva.fumador = false;
                break;
            default:
                reserva.fumador = false;                
                Console.WriteLine($"El valor {fumador} no es válido pero se asigna habitación de no fumador");
                break;
        }
        Console.Clear();
        Console.Write($"ID de la reserva: ".PadLeft(15, ' '));
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(reserva.id);
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write($"Cliente: ".PadLeft(15, ' '));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(reserva.cliente);
        Console.ForegroundColor = ConsoleColor.White;

        // Pintar el tipo de habitación
        // 100 -> Habitación individual
        // 200 -> Habitación doble
        // 300 -> Habitación Junior Suite
        // 400 -> Habitación Suite (cyan)
        // xxx -> tipo de habitación desconocido (rojo)

        Console.Write("IF -> Tipo: ".PadLeft(15, ' '));
        // IF/ELSE/IF
        if (respuesta == "100")
            Console.WriteLine("Habitación Individual.");
        else if (respuesta == "200")
            Console.WriteLine("Habitación Doble.");
        else if (respuesta == "300")
            Console.WriteLine("Habitación Junior SUITE.");
        else if (respuesta == "400")
        {
            Console.ForegroundColor = ConsoleColor.Cyan;              
            Console.WriteLine("Habitación SUITE.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;  
            Console.WriteLine($"Tipo de habitación <{respuesta}> desconocido.");
        }
        Console.ForegroundColor = ConsoleColor.White;

        // SWITCH
        Console.Write("SWITCH -> Tipo: ".PadLeft(15, ' '));
        switch(respuesta)
        {
            case "100":
                Console.WriteLine("Habitación Individual.");
                break;
            case "200":
                Console.WriteLine("Habitación Doble.");
                break;
            case "300":
                Console.WriteLine("Habitación Junior SUITE.");
                break;
            case "400":
                Console.ForegroundColor = ConsoleColor.Cyan;              
                Console.WriteLine("Habitación SUITE.");
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;  
                Console.WriteLine($"Tipo de habitación <{respuesta}> desconocido.");
                break;
        }
        Console.ForegroundColor = ConsoleColor.White;

        // Pintar si es fumador
        // true -> si
        // false -> no

        // Asignador condicional (condicion) ? "Sí" : "No"
        Console.Write("Es fumador? ");
        Console.ForegroundColor = reserva.fumador ? ConsoleColor.Red : ConsoleColor.Green;
        Console.WriteLine(reserva.fumador ? "Sí" : "No");
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void SentenciasRepeticion()
    {
        string[] frutas = {"naranja", "limón", "pomelo", "lima"};
        object[] objetos = {"naranja", 10, new Alumno(), new Reserva()};

        // Recorremos una colección con un contador FOR
        // Mostramos el contenido de Array utilizando la posición de los elementos
        // Python: for i in range(0, i < len(frutas), i += 1)
        
        // Opción 1a
        for(int i = 0; i < frutas.Length; i++)
        {
            Console.WriteLine($"Posición {i} -> {frutas[i]}");
        }
        Console.WriteLine("");

        // Opción 1b
        for(int i = 0; i < frutas.Length; i++)
            Console.WriteLine($"Posición {i} -> {frutas[i]}");
        Console.WriteLine("");

        // Recorremos una colección con un contador FOREACH
        // Mostramos el contenido de Array utilizando los valores de los elementos
        // Python: for fruta in frutas
        
        // Opción 1a
        foreach(string fruta in frutas)
        {
            Console.WriteLine($"-> {fruta}");
        }
        Console.WriteLine("");

        // Recorremos una colección con un contador WHILE
        // Opción 1
        int contador = 0;
        while (contador < frutas.Length)
        {
            Console.WriteLine($"Posición {contador} -> {frutas[contador]}");
            contador++;
        }
        Console.WriteLine("");

        // Opción2
        contador = 0;
        while (true)
        {
            Console.WriteLine($"Posición {contador} -> {frutas[contador]}");
            contador++;
            if(contador >= frutas.Length) break;
        }
        Console.WriteLine("");


        // Recorremos una colección con un contador DO/WHILE
        contador = 0;
        do
        {
            Console.WriteLine($"Posición {contador} -> {frutas[contador]}");
            contador++;
        }while(contador < frutas.Length);

        Console.WriteLine("");

        //////////////////////////////////////////////////////////
        
        decimal[] numeros = {10, 5, 345, 52, 13, 1000, 83};

        decimal suma = 0;
        decimal max = 0;
        decimal min = numeros[0];


        // FOR
        for(int i = 0; i < numeros.Length; i++)
        {
            suma += numeros[i];
            if(numeros[i] > max) max = numeros[i];
            if(numeros[i] < min) min = numeros[i];
        }        

        // Mostramos la suma y la media, el número mayor y el menor
        Console.WriteLine($"FOR: Suma total: {suma}");
        Console.WriteLine($"FOR: Media: {(suma/numeros.Length).ToString("N2")}");
        Console.WriteLine($"FOR: Número mayor: {max}");
        Console.WriteLine($"FOR: Número menor: {min}\n");

        // FOREACH
        suma = 0;
        max = 0;
        min = numeros[0];
        foreach(decimal numero in numeros)
        {
            suma += numero;
            if(numero > max) max = numero;
            if(numero < min) min = numero;
        }
        Console.WriteLine($"FOREACH: Suma total: {suma}");
        Console.WriteLine($"FOREACH: Media: {(suma/numeros.Length).ToString("N2")}");
        Console.WriteLine($"FOREACH: Número mayor: {max}");
        Console.WriteLine($"FOREACH: Número menor: {min}\n");


        // WHILE
        suma = 0;
        max = 0;
        min = numeros[0];
        contador = 0;
        while(contador < numeros.Length)
        {
            suma += numeros[contador];
            if(numeros[contador] > max) max = numeros[contador];
            if(numeros[contador] < min) min = numeros[contador];
            contador++;
        }
        Console.WriteLine($"WHILE: Suma total: {suma}");
        Console.WriteLine($"WHILE: Media: {(suma/numeros.Length).ToString("N2")}");
        Console.WriteLine($"WHILE: Número mayor: {max}");
        Console.WriteLine($"WHILE: Número menor: {min}\n");

        // Ejemplo de obtener información con métodos de LINQ
        Console.WriteLine($"LINQ: Suma total: {numeros.Sum()}");
        Console.WriteLine($"LINQ: Media: {numeros.Average().ToString("N2")}");
        Console.WriteLine($"LINQ: Número mayor: {numeros.Max()}");
        Console.WriteLine($"LINQ: Número menor: {numeros.Min()}\n");
    }

    /// <summary>
    /// 
    /// </summary>
    static void ControlExcepciones()
    {
        // EJEMPLO EN PYTHON
        // numero1 = 5
        // numero2 = 100

        // try:    
        //     numero3 = numero2 / numero1
        //     print(f"Valor de número 3: {numero3}")

        //     f = open("miFichero.txt")
        // except ZeroDivisionError as err:
        //     print(f"-> {err}")
        //     print(f"-> {type(err)}")
        // except FileNotFoundError as err:
        //     print(f"-> {err}")
        //     print(f"-> {type(err)}")
        // except Exception as err:
        //     print(f"{err}")
        //     print(f"{type(err)}")
        // finally:
        //     print(f"F I N")


        int numero1 = 5;
        int numero2 = 100;

        try
        {
            int numero3 = numero2 / numero1;
            Console.WriteLine($"El valor de número 3 es {numero3}");
        }
        catch (DivideByZeroException err)
        {
            Console.WriteLine("Excepción específica");
            Console.WriteLine($"Mensaje: {err.Message}");
            Console.WriteLine($"Tipo: {err.GetType()}");
        }
        catch (FileNotFoundException err)
        {
            Console.WriteLine("Excepción específica");
            Console.WriteLine($"Mensaje: {err.Message}");
            Console.WriteLine($"Tipo: {err.GetType()}");
        }
        catch (Exception err)
        {   
            Console.WriteLine("Excepción genérica");
            Console.WriteLine($"Mensaje: {err.Message}");
            Console.WriteLine($"Tipo: {err.GetType()}");
            //throw;
        }
        finally
        {
            Console.WriteLine("FIN");
        }
    }
}