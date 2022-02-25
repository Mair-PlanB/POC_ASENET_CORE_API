using System.Net;

namespace Shared
{
    public class HttpHelper
    {
        public enum HttpType
        {
            DELETE,
            GET
        }

        public static string HttpGetRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static async Task<string> HttpRequest(HttpType type, string url, string id)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "/" + id);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = type.ToString();

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return await streamReader.ReadToEndAsync();
            }
        }

        public static async Task<string> HttpPostRequest(string url, string serializedData)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "/");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(serializedData);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return await streamReader.ReadToEndAsync();
            }
        }

        public static async Task<string> HttpPostTextRequest(string url, string text)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "/");
            httpWebRequest.ContentType = "application/text";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(text);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return await streamReader.ReadToEndAsync();
            }
        }

        public static async Task<string> HttpPutRequest(string url, string id, string serializedData)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "/" + id);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(serializedData);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return await streamReader.ReadToEndAsync();
            }
        }
    }
}