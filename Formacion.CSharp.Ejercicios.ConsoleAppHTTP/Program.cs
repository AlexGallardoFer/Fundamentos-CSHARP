using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Formacion.CSharp.Ejercicios.ConsoleAppHTTP
{
    internal class Program
    {
        private static HttpClient http;

        static void Main(string[] args)
        {
            http = new HttpClient();

            ConsultarIP();
        }

        // Método GET
        // Url: https://api.zippopotam.us/es/11540
        static void ConsultarCodigoPostal()
        {
            Console.Clear();
            Console.Write("Escribe un código postal: ");
            string code = Console.ReadLine();

            HttpResponseMessage response = http.GetAsync($"https://api.zippopotam.us/es/{code}").Result;

            if (response.IsSuccessStatusCode)
            {
                string responseBodyText = response.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<dynamic>(responseBodyText);

                Console.WriteLine($"Pais: {data["country"]}");
                foreach (var lugar in data["places"])
                    Console.WriteLine($"Lugar: {lugar["place name"]} ({lugar["state"]})");                    
            }
            else Console.WriteLine($"Error: {response.StatusCode}");
        }

        // Método GET
        // Url: https://api.zippopotam.us/es/11540
        static void ConsultarCodigoPostal2()
        {
            Console.Clear();
            Console.Write("Escribe un código postal: ");
            string code = Console.ReadLine();

            HttpResponseMessage response = http.GetAsync($"https://api.zippopotam.us/es/{code}").Result;

            if (response.IsSuccessStatusCode)
            {
                string responseBodyText = response.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<PostalCodeInfo>(responseBodyText);

                Console.WriteLine($"Código postal: {data.PostCode}");
                Console.WriteLine($"Pais: {data.Country}");
                foreach (var lugar in data.Places)
                    Console.WriteLine($"Lugar: {lugar.PlaceName} ({lugar.State}) - {lugar.StateCode}");
            }
            else Console.WriteLine($"Error: {response.StatusCode}");
        }

        // Método GET
        // Url: https://api.zippopotam.us/es/11540
        static void ConsultarCodigoPostal3()
        {
            Console.Clear();
            Console.Write("Escribe un código postal: ");
            string code = Console.ReadLine();

            try
            {
                var data = http.GetFromJsonAsync<PostalCodeInfo>($"https://api.zippopotam.us/es/{code}").Result;

                Console.WriteLine($"Código postal: {data.PostCode}");
                Console.WriteLine($"Pais: {data.Country}");
                foreach (var lugar in data.Places)
                    Console.WriteLine($"Lugar: {lugar.PlaceName} ({lugar.State}) - {lugar.StateCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ConsultarIP()
        {
            Console.Clear();
            Console.Write("Escribe una IP: ");
            string ip = Console.ReadLine();

            // Comprobar que se trata de una dirección IP mediante una expresión regular
            // 0-255.0-255.0-255.0-255
            //---------------------------------//

            var response = http.GetAsync($"http://ip-api.com/json/{ip}").Result;

            if (response.IsSuccessStatusCode)
            {
                string responseBodyText = response.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<IpInfo>(responseBodyText);

                Console.WriteLine($"Pais: {data.Country} - ({data.CountryCode})");
                Console.WriteLine($"Región: {data.RegionName} - ({data.Region})");
                Console.WriteLine($"Ciudad: {data.City}");
            }
            else Console.WriteLine($"Error: {response.StatusCode}");
        }

        static void ConsultarIP2()
        {
            Console.Clear();
            Console.Write("Escribe una IP: ");
            string ip = Console.ReadLine();

            try
            {
                var data = http.GetFromJsonAsync<IpInfo>($"http://ip-api.com/json/{ip}").Result;

                Console.WriteLine($"Pais: {data.Country} - ({data.CountryCode})");
                Console.WriteLine($"Región: {data.RegionName} - ({data.Region})");
                Console.WriteLine($"Ciudad: {data.City}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public class PostalCodeInfo
    {
        [JsonProperty("post code")]
        [JsonPropertyName("post code")]
        public string PostCode { get; set; }
        public string Country { get; set; }
        [JsonProperty("country abbreviation")]
        [JsonPropertyName("country abbreviation")]
        public string CountryAbbreviation { get; set; }
        public List<PostalCodePlace> Places { get; set; }        
    }

    public class PostalCodePlace
    {
        [JsonProperty("place name")]
        [JsonPropertyName("place name")]
        public string PlaceName { get; set; }
        public string Longitude { get; set; }
        public string Lattitude { get; set; }
        public string State { get; set; }
        [JsonProperty("state abbreviation")]
        [JsonPropertyName("state abbreviation")]
        public string StateCode { get; set; }        
    }

    public class IpInfo
    {
        public string Status { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Region { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string TimeZone { get; set; }
        public string Isp { get; set; }
        public string Org { get; set; }
        public string As { get; set; }
        public string Query { get; set; }
    }
}
