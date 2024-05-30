﻿using Azure.Core;
using Formacion.CSharp.ConsoleAppEF.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace Formacion.CSharp.ConsoleAppEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ConsultaConADONET();
            //ConsultaConEF();
            //InsertarDatos();
            //ActualizarDatos();
            //EliminarDatos();
            SentenciasAvanzadas();
        }

        /// <summary>
        /// Ejecutamos una consulta de datos utilizando ADO.NET
        /// </summary>
        static void ConsultaConADONET()
        {
            // (A)-Access (D)-Data (O)-Object

            // Select * FROM dbo.Customers

            // Creamos un objeto para crear la cadena de conexión
            var csb = new SqlConnectionStringBuilder()
            {
                DataSource = "hostdb-eoi.database.windows.net",
                InitialCatalog = "Northwind",
                UserID = "Administrador",
                Password = "azurePa$$w0rd",
                IntegratedSecurity = false,
                ConnectTimeout = 60
            };

            // Mostrar la cadena de conexión resultante con los datos introducidos
            Console.WriteLine($"Cadena de conexión: {csb.ToString()}");

            // Creamos el objeto que representa la conexión con la base de datos
            SqlConnection connection = new SqlConnection()
            {
                ConnectionString = csb.ToString()
            };

            Console.WriteLine($"Estado de la conexión: {connection.State}");

            // Abrimos la conexión con la base de datos
            connection.Open();
            Console.WriteLine($"Estado de la conexión: {connection.State}");

            // Creamos un objeto que representa el comando que ejecutaremos en la base de datos
            SqlCommand command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT * FROM dbo.Customers"
            };

            SqlCommand command2 = new SqlCommand("SELECT * FROM dbo.Customers", connection);

            // Ejecución del comando

            // Si el comando retorna datos tenemos que crear un cursor que nos permita recorrer los datos recuperados
            SqlDataReader cursor = command.ExecuteReader();

            // Recorremos los datos del cursor
            if (!cursor.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                while (cursor.Read())
                {
                    Console.Write($"{cursor["CustomerID"].ToString().PadLeft(5, ' ')}#");
                    Console.Write($"{cursor.GetValue(1).ToString().PadRight(20, ' ')}");
                    Console.WriteLine($"{cursor["Country"]}");
                }
            }

            // Si el comando NO retorna datos recogemos en una variable INT el número de registros
            // afectados por el comando. (Comandos INSERT, UPDATE y DELETE)

            // int rows = command.ExecuteNonQuery();
            //

            // Cerramos conexiones
            cursor.Close();
            command.Dispose();
            connection.Close();
            connection.Dispose();
        }

        /// <summary>
        /// Ejecutamos consultas de datos utilizando Entity Framework Core
        /// </summary>
        static void ConsultaConEF()
        {
            // SELECT * FROM dbo.Customers

            var context = new NorthwindContext();

            var clientes = context.Customers
                .ToList();

            var clientes2 = from x in context.Customers
                            select x;

            foreach (var cliente in clientes)
            {
                Console.Write($"{cliente.CustomerID.PadLeft(5, ' ')}# ");
                Console.Write($"{cliente.CompanyName.PadRight(40, ' ')} ");
                Console.WriteLine($"{cliente.Country}");
            }
        }

        static void InsertarDatos()
        {
            var context = new NorthwindContext();

            var cliente = new Customer()
            {
                CustomerID = "AGF01",
                CompanyName = "Empresa Alex. G",
                ContactName = "Alejandro Gallardo",
                ContactTitle = "CEO",
                Address = "Calle Desengaño, 21",
                Region = "Granada",
                City = "Granada",
                Country = "España",
                Phone = "900 900 901",
                Fax = "900 900 911"
            };

            // Método 1
            //context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            // Método 2
            context.Customers.Add( cliente );
            context.SaveChanges();

            Console.WriteLine("Registro insertado correctamente.");
        }

        static void ActualizarDatos()
        {
            var context = new NorthwindContext();

            // Opción A
            // Recuperamos el cliente de la base de datos, modificamos valores de las propiedades y grabamos cambios.

            var cliente = context.Customers
                .Where(x => x.CustomerID == "AGF01")
                .FirstOrDefault();

            if (cliente == null) Console.WriteLine("NO existe el cliente.");
            else
            {
                cliente.ContactName = "Alex. G";
                cliente.PostalCode = "28115";
                context.SaveChanges();

                Console.WriteLine("Actualizado correctamente");
            }
            // Opción B
            // Instanciamos un objeto que representa un registro que existe en la base de datos
            // pero con valores diferentes y lo utilizamos para actualizar

            var context2 = new NorthwindContext();

            var cliente2 = new Customer()
            {
                CustomerID = "AGF01",
                CompanyName = "Empresa Alex. G",
                ContactName = "Alex. G",
                ContactTitle = "CEO",
                Address = "Calle Desengaño, 21",
                Region = "Granada",
                City = "Granada",
                PostalCode = "28115",
                Country = "España",
                Phone = "900 900 901",
                Fax = "900 900 911"
            };

            // Método 1
            //context2.Entry(cliente2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //context2.SaveChanges();

            // Método 2
            context2.Customers.Update( cliente2 );
            context2.SaveChanges();
        }

        static void EliminarDatos()
        {
            var context = new NorthwindContext();

            // Opción A
            var cliente = context.Customers
                .Where(x => x.CustomerID == "AGF01")
                .FirstOrDefault();

            if (cliente == null) Console.WriteLine("No existe el cliente.");
            else
            {
                context.Customers.Remove(cliente);
                context.SaveChanges();

                Console.WriteLine("Registro eliminado correctamente.");
            }

            // Opción B
            var cliente2 = new Customer() { CustomerID = "AGF01" };           
            context.Entry(cliente2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
        }

        static void SentenciasAvanzadas()
        {
            var context = new NorthwindContext();

            // INCLUDE

            // Listado de Empleados(nombre y apellidos) y listado de pedidos gestionados

            // Opción A
            var empleados = context.Employees
                .Select(x => new { x.EmployeeID, x.FirstName, x.LastName });

            foreach (var empleado in empleados)
            {
                var pedidos = context.Orders
                    .Where(x => x.EmployeeID == empleado.EmployeeID);
            }

            // Opción B
            var empleados2 = context.Employees
                .Select(x => new
                {
                    x.EmployeeID,
                    x.FirstName,
                    x.LastName,
                    Pedidos = context.Orders.Where(s => s.EmployeeID == x.EmployeeID)
                });

            // Opción C con INCLUDE
            var empleados3 = context.Employees
                .Include(x => x.Orders)
                .Select(x => x);

            // Opción D, nuevas versiones (dentro del select al pedirlo te lo da también)
            var empleados4 = context.Employees
                .Select(x => new
                {
                    x.EmployeeID,
                    x.FirstName,
                    x.LastName,
                    x.Orders
                });

            foreach (var empleado in empleados4)
                Console.WriteLine($"{empleado.FirstName} {empleado.LastName} - {empleado.Orders.Count} pedidos");
        }
    }
}
