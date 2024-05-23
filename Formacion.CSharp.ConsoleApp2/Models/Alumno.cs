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
    public string Apellidos{get; set;}

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
}