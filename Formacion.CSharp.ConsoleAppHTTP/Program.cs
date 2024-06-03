using Newtonsoft.Json;
using System.Dynamic;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Formacion.CSharp.ConsoleAppHTTP
{
    internal class Program
    {
        private static HttpClient http = new HttpClient();
        static void Main(string[] args)
        {
            // Opcionalmente especificamos la dirección base para las URLs de consulta

            http.BaseAddress = new Uri("https://postman-echo.com/");

            // Headers opcionales del objeto HttpClient
            // Se envian con todas las peticiones lanzadas con este objeto
            // Son útiles para especificar token o claves (APIKey) de acceso

            http.DefaultRequestHeaders.Clear();
            http.DefaultRequestHeaders.Add("User-Agent", "HttpCliente .Net Core Demo");
            http.DefaultRequestHeaders.Add("X-Data-1", "Demo");
            http.DefaultRequestHeaders.Add("X-Data-2", "1234567890");

            // Llamada a GET
            Get3();
        }

        static void Get()
        {
            // La Uri sería: https://postman-echo.com/get
            HttpResponseMessage response = http.GetAsync("get?param1=hola").Result;

            // Opción 1, preguntamos por un código de estado concreto
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Lectura del cuerpo del mensaje como STRING
                // El texto obtenido normalmente estará en JSON
                string responseBodyText = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Body: ");
                Console.WriteLine("=================================================================");
                Console.WriteLine($"{responseBodyText}\n");

                // Convertir el JSON en Objeto, indicando el tipo
                // Utilizamos DYNAMIC cuando no tenemos una clase que represente el objeto retornado
                var obj = JsonConvert.DeserializeObject<dynamic>(responseBodyText);

                Console.WriteLine("Datos del Body: ");
                Console.WriteLine("=================================================================");
                Console.WriteLine($"URL: {obj["url"]}");
                Console.WriteLine($"Param1: {obj["args"]["param1"]}");
                Console.WriteLine($"Data 1: {obj["headers"]["x-data-1"]}\n");



                // También tenemos acceso a las cabeceras del mensaje de respuesta
                Console.WriteLine("Headers: ");
                Console.WriteLine("=================================================================");
                foreach (var header in response.Headers)
                {
                    Console.WriteLine($"{header.Key}: {header.Value.FirstOrDefault()}");
                }

                Console.WriteLine($"Date: {response.Headers.GetValues("Date").FirstOrDefault()}");

                IEnumerable<string> valor;
                response.Headers.TryGetValues("Content-Type", out valor);
                Console.WriteLine($"Content-Type: {(valor == null ? "" : valor.FirstOrDefault())}");
            }
            else Console.WriteLine($"Error: {response.StatusCode}");

            // Opción 2, preguntamos si finaliza con cualquier código 2XX
            if (response.IsSuccessStatusCode)
            {
                // El mismo código que en la opción 1
            }
            else Console.WriteLine($"Error: {response.StatusCode}");
        }

        static void Get2()
        {
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "get");
            
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri("https://postman-echo.com/get?param1=hola");

            // Opcionalmente definimos las cabeceras del mensaje
            // Las cabeceras se anexan a las cabeceras por defecto del objeto HttpClient
            request.Headers.Add("X-Data-3", "ABCD");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Opcionalmente definimos el cuerpo del mensaje
            var obj = new { Nombre = "Alejandro", Apellido1 = "Gallardo", Apellido2 = "Fernández" };

            string objJSON = JsonConvert.SerializeObject(obj);
            StringContent contenido = new StringContent(objJSON, Encoding.UTF8, "application/json");
            request.Content = contenido;
            
            // Enviamos la petición y obtenemos la respuesta
            HttpResponseMessage response = http.SendAsync(request).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Lectura del cuerpo del mensaje de respuesta como STRING
                // El texto obtenido normalmente estara en JSON

                string responseBodyText = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine("Body:");
                Console.WriteLine("=============================================");
                Console.WriteLine($"{responseBodyText}");


                // Convertir el JSON en Objeto, indicado el tipo
                // Utilizamos DYNAMIC cuando no tenemos una clase que represente el objeto retornado

                var obj2 = JsonConvert.DeserializeObject<dynamic>(responseBodyText);

                Console.WriteLine("");
                Console.WriteLine("Datos del Body:");
                Console.WriteLine("=============================================");
                Console.WriteLine($"URL: {obj2["url"]}");
                Console.WriteLine($"Param 1: {obj2["args"]["param1"]}");
                Console.WriteLine($"Data 1: {obj2["headers"]["x-data-1"]}");

                Console.WriteLine($"URL: {obj2.url}");
                Console.WriteLine($"Param 1: {obj2.args.param1}");

                Console.WriteLine("");
                Console.WriteLine("Headers:");
                Console.WriteLine("=============================================");
                // También tenemos acceso a las cabeceras del mensaje de respuesta
                foreach (var header in response.Headers)
                {
                    Console.WriteLine($"{header.Key}: {header.Value.FirstOrDefault()}");
                }

                Console.WriteLine($"Date: {response.Headers.GetValues("Date").FirstOrDefault()}");

                IEnumerable<string> valor;
                response.Headers.TryGetValues("Content-Type", out valor);

                Console.WriteLine($"Content-Type: {(valor == null ? "" : valor.FirstOrDefault())}");

            }
            else Console.WriteLine($"Error: {response.StatusCode}");

        }

        static void Get3()
        {
            try
            {
                var obj3 = http.GetFromJsonAsync<ExpandoObject>("get?param1=hola").Result;

                if (obj3 != null)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Datos del Body:");
                    Console.WriteLine("=============================================");
                    Console.WriteLine($"URL: {obj3["url"]}");
                    Console.WriteLine($"Param 1: {obj3["args"]["param1"]}");
                    Console.WriteLine($"Data 1: {obj3["headers"]["x-data-1"]}");

                    Console.WriteLine($"URL: {obj3.url}");
                    Console.WriteLine($"Param 1: {obj3.args.param1}");
                }
                else
                    Console.WriteLine("No se puede acceder a la información");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
