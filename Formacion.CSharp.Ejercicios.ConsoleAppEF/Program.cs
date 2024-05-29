using Formacion.CSharp.Ejercicios.ConsoleAppEF.Models;

namespace Formacion.CSharp.Ejercicios.ConsoleAppEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ejercicio1();
            Ejercicio2();
            Ejercicio3();
            Ejercicio4();
            Ejercicio5();
            Ejercicio6();
            Ejercicio7();
            Ejercicio8();
            Ejercicio9();
            Ejercicio10();
            Ejercicio11();
            Ejercicio12();
            Ejercicio13();
            Ejercicio14();
            Ejercicio15();
            Ejercicio16();
            Ejercicio17();
        }

        static void Ejercicio1()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Clientes que residen en USA
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Customers WHERE Country = 'USA'

            Console.WriteLine("\n-------------------------Ejercicio  1-------------------------");

            var context = new NorthwindContext();

            var clientes = context.Customers
                .Where(x => x.Country == "USA")
                .ToList();

            foreach (var cliente in clientes)
            {
                Console.Write($"{cliente.CustomerID.PadLeft(5, ' ')}# ");
                Console.Write($"{cliente.CompanyName.PadRight(40, ' ')} ");
                Console.WriteLine($"{cliente.Country}");
            }
        }

        static void Ejercicio2()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Proveedores (Suppliers) de Berlin
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Suppliers WHERE City = 'Berlin'

            Console.WriteLine("\n-------------------------Ejercicio  2-------------------------");

            var context = new NorthwindContext();

            var proveedores = context.Suppliers
                .Where(x => x.City == "Berlin")
                .ToList();

            foreach (var proveedor in proveedores)
            {
                Console.Write($"{proveedor.SupplierID.ToString().PadLeft(5, ' ')}# ");
                Console.Write($"{proveedor.CompanyName.PadRight(40, ' ')} ");
                Console.WriteLine($"{proveedor.City}");
            }
        }

        static void Ejercicio3()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Empleados con identificadores 3, 5 y 8
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Employees WHERE EmployeeID IN (3, 5, 8)

            Console.WriteLine("\n-------------------------Ejercicio  3-------------------------");

            var context = new NorthwindContext();

            List<int> IDsEmpleados = new List<int>() { 3, 5, 8 };

            var empleados = context.Employees
                .Where(x => IDsEmpleados.Contains(x.EmployeeID))
                .ToList();

            foreach (var empleado in empleados)
            {
                Console.Write($"{empleado.EmployeeID.ToString().PadLeft(5, ' ')}# ");
                Console.Write($"{empleado.FirstName.PadRight(40, ' ')} \n");
            }
        }

        static void Ejercicio4()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos con stock mayor de cero
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Products WHERE UnitsInStock > 0

            Console.WriteLine("\n-------------------------Ejercicio  4-------------------------");

            var context = new NorthwindContext();

            var productos = context.Products
                .Where(x => x.UnitsInStock > 0)
                .ToList();

            foreach (var producto in productos)
            {
                Console.Write($"{producto.ProductID.ToString().PadLeft(5, ' ')}# ");
                Console.Write($"{producto.ProductName.PadRight(40, ' ')} ");
                Console.WriteLine($"Stock: {producto.UnitsInStock}");
            }
        }

        static void Ejercicio5()
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos con stock mayor de cero de los proveedores con identificadores 1, 3 y 5
            /////////////////////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Products WHERE SupplierID IN (1, 3, 5)

            Console.WriteLine("\n-------------------------Ejercicio  5-------------------------");

            var context = new NorthwindContext();

            var ids = new List<int>() { 1, 3, 5 };
            
            var productos = context.Products
                .Where(x => x.UnitsInStock > 0 && ids.Contains(Convert.ToInt32(x.SupplierID)))
                .ToList();

            foreach (var producto in productos)
            {
                Console.Write($"{producto.ProductID.ToString().PadLeft(5, ' ')}# ");
                Console.Write($"{producto.ProductName.PadRight(40, ' ')} ");
                Console.Write($"Stock: {(producto.UnitsInStock.HasValue ? producto.UnitsInStock.Value : -1).ToString().PadRight(5, ' ')}");
                Console.WriteLine($"Supplier ID: {producto.SupplierID}#");
            }
        }

        static void Ejercicio6()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos con precio mayor de 20 y menor 90
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Products WHERE UnitPrice > 20 AND UnitPrice < 90

            Console.WriteLine("\n-------------------------Ejercicio  6-------------------------");

            var context = new NorthwindContext();

            int minimo = 20;
            int maximo = 90;

            var productos = context.Products
                .Where(x => x.UnitPrice > minimo && x.UnitPrice < maximo)
                .ToList();

            foreach (var producto in productos)
            {
                Console.Write($"{producto.ProductID.ToString().PadLeft(5, ' ')}# ");
                Console.Write($"{producto.ProductName.PadRight(40, ' ')} ");
                Console.WriteLine($"{(producto.UnitPrice.HasValue ? producto.UnitPrice.Value : -1).ToString("N2")}$");                
            }
        }

        static void Ejercicio7()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos entre 01/01/1997 y 15/07/1997
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE OrderDate >= '1997/01/01' AND OrderDate <= '1997/09/15'

            Console.WriteLine("\n-------------------------Ejercicio  7-------------------------");

            var context = new NorthwindContext();

            DateTime fechaInicio = new DateTime(1997, 01, 01);
            DateTime fechaFin = new DateTime(1997, 09, 15);

            var pedidos = context.Orders
                .Where(x => x.OrderDate >= fechaInicio &&  x.OrderDate <= fechaFin)
                .ToList();

            foreach (var pedido in pedidos)
            {
                Console.Write($"{pedido.OrderID.ToString().PadLeft(5, ' ')}# ");
                Console.Write($"{pedido.ShipName!.PadRight(40, ' ')} ");
                Console.WriteLine($"{pedido.OrderDate}");
            }
        }

        static void Ejercicio8()
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos registrados por los empleados con identificador 1, 3, 4 y 8 en 1997
            /////////////////////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE YEAR(OrderDate) = 1997 AND EmployeeID IN (1, 3, 4, 8)

            Console.WriteLine("\n-------------------------Ejercicio  8-------------------------");

            var context = new NorthwindContext();

            int año = 1997;
            var ids = new List<int>() { 1, 3, 4, 8 };

            var pedidos = context.Orders
                .Where(x => ids.Contains(Convert.ToInt32(x.EmployeeID)) && (x.OrderDate.HasValue ? x.OrderDate.Value: DateTime.MinValue).Year == año)
                .ToList();

            foreach (var pedido in pedidos)
            {
                Console.Write($"{pedido.OrderID.ToString().PadLeft(5, ' ')}# ");
                Console.Write($"- ID del empleado: {pedido.EmployeeID}# ");
                Console.WriteLine($"- Año: {Convert.ToDateTime(pedido.OrderDate).Year}");
            }
        }

        static void Ejercicio9()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos de Octubre de 1996
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE YEAR(OrderDate) = 1996 AND MONTH(OrderDate) = 10

            Console.WriteLine("\n-------------------------Ejercicio  9-------------------------");

            var context = new NorthwindContext();

            int año = 1996;
            int mes = 10;

            var pedidos = context.Orders
                .Where(x => (x.OrderDate.HasValue ? x.OrderDate.Value : DateTime.MinValue).Year == año && (x.OrderDate.HasValue ? x.OrderDate.Value : DateTime.MinValue).Month == mes)
                .ToList();

            foreach (var pedido in pedidos)
            {
                Console.Write($"{pedido.OrderID.ToString().PadLeft(5, ' ')}# ");
                Console.Write($"Año: {Convert.ToDateTime(pedido.OrderDate).Year} ");
                Console.WriteLine($"Mes: {Convert.ToDateTime(pedido.OrderDate).Month}");
            }
        }

        static void Ejercicio10()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos del realizado los dia uno de cada mes del año 1998
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE YEAR(OrderDate) = 1998 AND DAY(OrderDate) = 1

            Console.WriteLine("\n-------------------------Ejercicio 10-------------------------");

            var context = new NorthwindContext();

            int año = 1998;
            int dia = 1;

            var pedidos = context.Orders
                .Where(x => (x.OrderDate.HasValue ? x.OrderDate.Value : DateTime.MinValue).Year == año && x.OrderDate!.Value.Day == dia)
                .ToList();

            foreach (var pedido in pedidos)
            {
                Console.Write($"{pedido.OrderID.ToString().PadLeft(5, ' ')}# ");
                Console.Write($"Año: {Convert.ToDateTime(pedido.OrderDate).Year} ");
                Console.Write($"Mes: {Convert.ToDateTime(pedido.OrderDate).Month} ");
                Console.WriteLine($"Día: {Convert.ToDateTime(pedido.OrderDate).Day}");
            }
        }

        static void Ejercicio11()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Clientes que no tiene fax
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Customers WHERE Fax = NULL

            Console.WriteLine("\n-------------------------Ejercicio 11-------------------------");

            var context = new NorthwindContext();

            var clientes = context.Customers
                .Where(x => x.Fax == null)
                .ToList();

            foreach (var cliente in clientes)
            {
                Console.Write($"{cliente.CustomerID.PadLeft(5, ' ')}# ");
                Console.Write($"{cliente.CompanyName.PadRight(40, ' ')} ");
                Console.WriteLine($"Fax: {cliente.Fax}");
            }
        }

        static void Ejercicio12()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de los 10 productos más baratos
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT TOP(10) * FROM dbo.Products ORDER BY UnitPrice

            Console.WriteLine("\n-------------------------Ejercicio 12-------------------------");

            var context = new NorthwindContext();

            var productos = context.Products
                .OrderBy(x => x.UnitPrice)
                .ToList();

            int tamaño = (productos.Count <= 10)? productos.Count : 10;

            for (int i = 0; i < tamaño; i++)
            {
                Console.Write($"{productos[i].ProductID.ToString().PadLeft(5, ' ')}# ");
                Console.WriteLine($"Precio: {productos[i].UnitPrice.Value.ToString("N2")}$");
            }
        }

        static void Ejercicio13()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de los 10 productos más caros con stock
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT TOP(10) * FROM dbo.Products ORDER BY UnitPrice DESC

            Console.WriteLine("\n-------------------------Ejercicio 13-------------------------");

            var context = new NorthwindContext();

            var productos = context.Products
                .Where(x => x.UnitsInStock > 0)
                .OrderByDescending(x => x.UnitPrice)
                .ToList();

            int tamaño = (productos.Count <= 10) ? productos.Count : 10;

            for (int i = 0; i < tamaño; i++)
            {
                Console.Write($"{productos[i].ProductID.ToString().PadLeft(5, ' ')}# ");
                Console.WriteLine($"Precio: {productos[i].UnitPrice.Value.ToString("N2")}$");
            }
        }

        static void Ejercicio14()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Cliente de UK y nombre de empresa que comienza por B
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Customers WHERE CompanyName LIKE 'B%' AND Country = 'Uk'

            Console.WriteLine("\n-------------------------Ejercicio 14-------------------------");

            var context = new NorthwindContext();

            string comienzo = "B";

            var clientes = context.Customers
                .Where(x => x.Country == "UK" && x.CompanyName.StartsWith(comienzo))
                .ToList();

            foreach (var cliente in clientes)
            {
                Console.Write($"{cliente.CustomerID.PadLeft(5, ' ')}# ");
                Console.Write($"{cliente.CompanyName.PadRight(40, ' ')} ");
                Console.WriteLine($"{cliente.Country}");
            }
        }

        static void Ejercicio15()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos de identificador de categoria 3 y 5
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT TOP(10) * FROM dbo.Products WHERE CategoryID IN (3, 5)

            Console.WriteLine("\n-------------------------Ejercicio 15-------------------------");

            var context = new NorthwindContext();

            var ids = new List<int>() { 3, 5 };

            var productos = context.Products
                .Where(x => ids.Contains(Convert.ToInt32(x.CategoryID)))
                .ToList();

            foreach (var producto in productos)
            {
                Console.Write($"{producto.ProductID.ToString().PadLeft(5, ' ')}# ");
                Console.Write($"{producto.ProductName.PadRight(40, ' ')} ");
                Console.WriteLine($"ID de categoría: {producto.CategoryID}#");
            }
        }

        static void Ejercicio16()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Importe total del stock
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT SUM(UnitInStock * UnitPrice) FROM Products

            Console.WriteLine("\n-------------------------Ejercicio 16-------------------------");

            var context = new NorthwindContext();

            var total = context.Products
                .Sum(x => x.UnitsInStock * x.UnitPrice);

            Console.WriteLine($"Importe total del stock: {total.Value.ToString("N2")}$");
        }

        static void Ejercicio17()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos de los clientes de Argentina
            /////////////////////////////////////////////////////////////////////////////////            

            // SELECT CustomerID FROM dbo.Customers WHERE Country = 'Argentina'
            // SELECT * FROM dbo.Orders WHERE CustomerID IN ('CACTU', 'OCEAN', 'RANCH')


            // SELECT * FROM dbo.Orders WHERE CustomerID IN (SELECT CustomerID FROM dbo.Customers WHERE Country = 'Argentina')

            Console.WriteLine("\n-------------------------Ejercicio 17-------------------------");

            var context = new NorthwindContext();

            // Mi método
            var clientes = context.Customers
                .Where(x => x.Country == "Argentina")
                .Select(x => x.CustomerID)
                .ToList();
            
            var pedidos = context.Orders
                .Where(x => clientes.Distinct().Contains(x.CustomerID))
                .OrderBy(x => x.CustomerID)
                .ToList();

            // Método de Borja
            // TO DO

            foreach (var pedido in pedidos)
            {
                Console.Write($"{pedido.OrderID.ToString().PadLeft(5, ' ')}# ");
                Console.Write($"ID Customer: #{pedido.CustomerID.ToString().PadRight(20, ' ')} ");
                Console.WriteLine($"País: {pedido.ShipCountry} ");
            }
        }
    }
}