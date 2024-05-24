using System.Diagnostics;

namespace Formacion.CSharp.ConsoleApp2.Models;

public class Alumno{
    // Miembro: Variables (suelen ser privadas siempre)
    private string nombre;
    private int edad;

    // Miembro: Propiedades (suelen ser y deberían de ser públicas)
    public string Nombre{
        get{ 
            return nombre.Trim().ToLower();
        }
        set{
            if(value.Length < 2) nombre = "";
            else nombre = value;
        }
    }

    public int Edad{
        get { return edad; }
        set { 
            if(value < 1 || value > 120) edad = 0;
            else edad = value;
        }
    }

    // Miembro: Propiedades que se comporta como una variable pública
    public string Apellidos { get; set; }

    public Dias DiaTutoria { get; set; }

    public Estados Estado { get; set; }

    // Miembro: Propiedad de solo lectura, no asociada a una variable
    public string NombreCompleto{
        get{ return $"{nombre} {Apellidos}";}
    }

    // Miembro: Propiedad de solo escritura, no asociada a una variable
    public int CambiaEdad{
        set{
            if(value < 1 || value > 120) edad = 0;
            else edad = value;
        }
    }

    // Miembro: Método Constructor, se ejecuta cuando se instancia el objeto
    // Es public, no tiene tipo (no retorna nada) y se llama igual que la clase
    public Alumno(){}

    // Sobrecarga del constructor
    public Alumno(string nombre, string apellidos){
        this.nombre = nombre;
        this.Apellidos = apellidos;
    }

    // Sobrecarga del constructor
    public Alumno(string nombre, int edad){
        this.nombre = nombre;
        this.edad = edad;
    }

    // Miembro: Destructor
    // No se le puede llamar, se ejecuta automáticamente
    // No tiene parámetros, no tiene tipo y se llama igual que la clase
    // Comienza por ~ (Alt+0126 o AltGr+4)
    ~Alumno()
    {
        Debug.WriteLine("Se ejecutó el destructor de Alumno");
        this.nombre = null;
        this.Apellidos = null;
        this.edad=0;
    }

    // Miembro: Métodos con tipo VOID, no retorna nada
    public void MetodoUno(){

    }

    // Miembro: Métodos con un tipo de datos (Ejemplo un bool), que siempre retorna ese tipo de dato
    public bool MetodoDos(){
        return true;
    }

    public bool MetodoTres(int param1, string param2, float param3 = 0, string param4 = "valor por defecto"){
        return true;
    }
}