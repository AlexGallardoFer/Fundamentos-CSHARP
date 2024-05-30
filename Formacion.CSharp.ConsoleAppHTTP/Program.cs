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
        }

        static void Get()
        {
            // La Uri sería: https://postman-echo.com/get
            HttpResponseMessage response = http.GetAsync("get").Result;
        }
    }
}
