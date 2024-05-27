using System.ComponentModel;

namespace Formacion.CSharp.ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ConsultasBasicas();
            Ejercicio1();
            Ejercicio2();
            Ejercicio3();
            Ejercicio3B();
            Ejercicio4();
            Ejercicio5();
            Ejercicio6();
            Ejercicio7();
        }

        /// <summary>
        /// Consultas básicas de LINQ con DataLists
        /// </summary>
        static void ConsultasBasicas()
        {
            // Transat-SQL -> SELECT * FROM ListaProductos
            // Listado de productos completo

            // Métodos de LINQ
            var productos = DataLists.ListaProductos
                .ToList();

            // Expresiones de LINQ
            var productos2 = from x in DataLists.ListaProductos
                             select x;

            foreach (var producto in productos)
                Console.WriteLine($"{producto.Descripcion} - Precio: {producto.Precio.ToString("N2")}");
            Console.WriteLine("");


            // Transat-SQL -> SELECT * FROM ListaProductos WHERE Precio > 2
            // Listado de productos con precio mayor de 2

            // Métodos de LINQ
            var productos2a = DataLists.ListaProductos
                .Where(x => x.Precio > 2)
                .ToList();

            // Expresiones de LINQ
            var productos2b = from x in DataLists.ListaProductos
                              where x.Precio > 2
                              select x;

            foreach (var producto in productos2a)
                Console.WriteLine($"{producto.Descripcion} - Precio: {producto.Precio.ToString("N2")}");
            Console.WriteLine("");


            // Transat-SQL -> SELECT * FROM ListaProductos WHERE Precio > 2 ORDER BY Descripcion DESC
            // Listado de productos con precio mayor de 2 ordenados por descripción descendente

            // Métodos de LINQ
            var productos3a = DataLists.ListaProductos
                .Where(x => x.Precio > 2)
                .OrderByDescending(x => x.Descripcion)
                .ToList();

            // Expresiones de LINQ
            var productos3b = from x in DataLists.ListaProductos
                              where x.Precio > 2
                              orderby x.Descripcion descending
                              select x;

            foreach (var producto in productos3a)
                Console.WriteLine($"{producto.Descripcion} - Precio: {producto.Precio.ToString("N2")}");
            Console.WriteLine("");


            // Transat-SQL -> SELECT Descripcion, Precio FROM ListaProductos WHERE Precio > 2.5 ORDER BY Precio ASC
            // Listado de descripción y precio para productos con precio mayor de 2.5 ordenados por precio ascendente

            // Métodos de LINQ
            var productos4a = DataLists.ListaProductos
                .Where(x => x.Precio > 2.5)
                .OrderBy(x => x.Precio)
                .Select(x => new { x.Descripcion, x.Precio })
                .ToList();

            // Expresiones de LINQ
            var productos4b = from x in DataLists.ListaProductos
                              where x.Precio > 2.5
                              orderby x.Precio
                              select new { x.Descripcion, x.Precio };

            foreach (var producto in productos4a)
                Console.WriteLine($"{producto.Descripcion} - Precio: {producto.Precio.ToString("N2")}");
            Console.WriteLine("");


            // Transat-SQL -> SELECT id AS Code, descripcion FROM ListaProductos
            // Listado de Id y Descripción de Productos

            // Métodos de LINQ
            var productos5a = DataLists.ListaProductos
                .Select(x => new { Code = x.Id, x.Descripcion })
                .ToList();

            // Expresiones de LINQ
            var productos5b = from r in DataLists.ListaProductos
                              select new { Code = r.Id, r.Descripcion };

            foreach (var producto in productos5a)
                Console.WriteLine($"{producto.Descripcion} - Código: {producto.Code}");
            Console.WriteLine("");

            /////////////////////////////////////////////////////////////////////

            // Ordena en la base de datos
            var orders1a = DataLists.ListaProductos
                .Where(x => x.Precio > 0.90 && x.Precio < 2)
                .OrderBy(x => x.Descripcion)
                .Select(x => x.Descripcion);

            // Ordena en la base de datos
            var orders1b = from x in DataLists.ListaProductos
                          where x.Precio > 0.90 && x.Precio < 2
                          orderby x.Descripcion
                          select x.Descripcion;


            // Ordena en el pc/servidor, puede ofrecer menos rendimiento
            var orders2a = DataLists.ListaProductos
                .Where(x => x.Precio > 0.90 && x.Precio < 2)
                .Select(x => x.Descripcion)
                .OrderBy(x => x);

            // Ordena en el pc/servidor, puede ofrecer menos rendimiento
            var orders2b = (from x in DataLists.ListaProductos
                          where x.Precio > 0.90 && x.Precio < 2
                          select x.Descripcion).ToList().OrderBy(x => x);

            foreach (var order in orders1a)
                Console.WriteLine(order);
            Console.WriteLine("");

            /////////////////////////////////////////////////////////////////////

            // Contains -> Contiene
            // Transat-SQL -> SELECT * FROM ListaProductos WHERE descripcion LIKE '%es%'
            var w1a = DataLists.ListaProductos
                .Where(x => x.Descripcion.Contains("es"))
                .Select(x => x)
                .ToList();

            var w1b = from x in DataLists.ListaProductos
                              where x.Descripcion.Contains("es")
                              select x;

            //  StartsWith -> Comienza con
            // Transat-SQL -> SELECT * FROM ListaProductos WHERE descripcion LIKE 'es%'
            var w2a = DataLists.ListaProductos
                .Where(x => x.Descripcion.StartsWith("es"))
                .Select(x => x)
                .ToList();

            var w2b = from x in DataLists.ListaProductos
                      where x.Descripcion.StartsWith("es")
                      select x;

            // EndsWith->Finaliza con
            // Transat-SQL -> SELECT * FROM ListaProductos WHERE descripcion LIKE '%es'
            var w3a = DataLists.ListaProductos
                .Where(x => x.Descripcion.EndsWith("es"))
                .Select(x => x)
                .ToList();

            var w3b = from x in DataLists.ListaProductos
                      where x.Descripcion.EndsWith("es")
                      select x;


            foreach (var producto in w1a)
                Console.WriteLine($"{producto.Descripcion} - Precio: {producto.Precio.ToString("N2")}");
            Console.WriteLine("");
        }

        /// <summary>
        /// Clientes Mayores de 40 años
        /// </summary>
        static void Ejercicio1()
        {
            Console.WriteLine("EJERCICIO 1");
            Console.WriteLine("Clientes Mayores de 40 años");
            DateTime fecha = DateTime.Now;
            var clientes = from x in DataLists.ListaClientes
                            where (DateTime.Now.Year - x.FechaNac.Year) > 40
                            select x;

            foreach (var cliente in clientes)
                Console.WriteLine($"Nombre: {cliente.Nombre} - Edad: {fecha.Year - cliente.FechaNac.Year}\n");
        }
        /// <summary>
        /// Productos que comiencen por 'C' ordenados por precio
        /// </summary>
        static void Ejercicio2()
        {
            Console.WriteLine("EJERCICIO 2");
            Console.WriteLine("Productos que comiencen por 'C' ordenados por precio");

            var productos = from x in DataLists.ListaProductos
                            where x.Descripcion.StartsWith("C")
                            orderby x.Precio
                            select x;

            foreach (var producto in productos)
                Console.WriteLine($"{producto.Descripcion} - Precio: {producto.Precio}\n");
        }
        /// <summary>
        /// Listar un detalle de todos los pedidos
        /// </summary>
        static void Ejercicio3()
        {
            Console.WriteLine("EJERCICIO 3");
            Console.WriteLine("Listar un detalle de todos los pedidos");

            var pedidos = from x in DataLists.ListaPedidos
                             select x;

            foreach (var pedido in pedidos)
            {
                Console.WriteLine($"Pedido número: {pedido.Id}");

                var lineas = from x in DataLists.ListaLineasPedido
                             where x.IdPedido == pedido.Id
                             select x;

                foreach (var linea in lineas)
                {
                    var producto = DataLists.ListaProductos
                        .Where(x => x.Id == linea.IdProducto)
                        .FirstOrDefault();

                    Console.WriteLine($"-> Id del producto: {producto.Id} - {producto.Descripcion} - Cantidad: {linea.Cantidad} - Precio: {producto.Precio}");
                }
            }
        }

        static void Ejercicio3B()
        {
            // Subconsultas o SubSelects
            Console.Clear();
            Console.Write("Número de Pedido: ");
            int numPedido = Convert.ToInt32(Console.ReadLine());

            var lineas = DataLists.ListaLineasPedido
                .Where(r => r.IdPedido == numPedido)
                .Select(r => new {
                    r.IdProducto,
                    Descripcion = DataLists.ListaProductos
                        .Where(s => s.Id == r.IdProducto)
                        .Select(r => r.Descripcion)
                        .FirstOrDefault(),
                    Precio = DataLists.ListaProductos
                        .Where(s => s.Id == r.IdProducto)
                        .Select(r => r.Precio)
                        .FirstOrDefault(),
                    r.Cantidad
                })
                .ToList();

            foreach (var linea in lineas)
                Console.WriteLine($"{linea.IdProducto} - {linea.Descripcion} -  Cant. {linea.Cantidad} - Precio {linea.Precio.ToString("N2")}");
        }

        /// <summary>
        /// Mostrar el importe total de un pedido
        /// </summary>
        static void Ejercicio4()
        {
            Console.WriteLine("EJERCICIO 4");
            Console.WriteLine("Mostrar el importe total de un pedido\n");

            Console.Write("Introduzca el ID del pedido (1-12): ");
            int numPedido = Convert.ToInt32(Console.ReadLine());
            float importeTotal = 0;

            var lineasPedido = from x in DataLists.ListaLineasPedido
                          where x.IdPedido == numPedido
                          select x; 

            foreach (var lineaPedido in lineasPedido)
            {
                var productos = from x in DataLists.ListaProductos
                              where x.Id == lineaPedido.IdProducto
                              select x;

                foreach (var producto in productos)
                {
                    importeTotal += (producto.Precio * lineaPedido.Cantidad);
                }                
            }
            Console.WriteLine($"Importe total del pedido {pedido}: {importeTotal.ToString("N2")}\n");
        }
        /// <summary>
        /// Mostrar los pedidos con lapiceros
        /// </summary>
        static void Ejercicio5()
        {
            Console.WriteLine("EJERCICIO 5");
            Console.WriteLine("Mostrar los pedidos con lapiceros");

            var lineasPedido = from x in DataLists.ListaLineasPedido
                          where x.IdProducto == 11
                          select x;

            foreach (var lineaPedido in lineasPedido)
                Console.WriteLine($"ID Pedido: {lineaPedido.IdPedido}\n");
        }
        /// <summary>
        /// Número de pedidos con cuaderno grande
        /// </summary>
        static void Ejercicio6()
        {
            Console.WriteLine("EJERCICIO 6");
            Console.WriteLine("Número de pedidos con cuaderno grande");

            int totalPedidos = 0;
            var lineasPedido = from x in DataLists.ListaLineasPedido
                               where x.IdProducto == 2
                               select x;

            foreach (var lineaPedido in lineasPedido)
                totalPedidos++;
            
            Console.WriteLine($"Número de pedidos: {totalPedidos}\n");
        }
        /// <summary>
        /// Unidades vendidas de cuaderno pequeño
        /// </summary>
        static void Ejercicio7()
        {
            Console.WriteLine("EJERCICIO 7");
            Console.WriteLine("Unidades vendidas de cuaderno pequeño");

            int unidadesVendidas = 0;
            var lineasPedido = from x in DataLists.ListaLineasPedido
                               where x.IdProducto == 3
                               select x;

            foreach (var lineaPedido in lineasPedido)
                unidadesVendidas += lineaPedido.Cantidad;

            Console.WriteLine($"Unidades vendidas: {unidadesVendidas} \n");
        }
    }   
}
