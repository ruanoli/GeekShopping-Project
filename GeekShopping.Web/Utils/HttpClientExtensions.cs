using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.Web.Utils
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");

        //Permite ler e desserializar facilmente o conteúdo
        //de uma resposta HTTP para um objeto do tipo T,
        //desde que a resposta tenha um status de sucesso.
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Alguma coisa de errado aconteceu ao chamar a API: {response.ReasonPhrase}");
            
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Com o conteúdo ja serealizado em JSON, esse método envia a solicitação HTTP POST
        // e retorna uma tarefa que representa a operação assíncrona de envio da solicitação
        public static Task<HttpResponseMessage> PostAsJson<T>(
            this HttpClient httpClient, 
            string url,
            T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;

            return httpClient.PostAsync(url, content);
        }

        // Com o conteúdo ja serealizado em JSON, esse método envia a solicitação HTTP PUT
        // e retorna uma tarefa que representa a operação assíncrona de envio da solicitação
        public static Task<HttpResponseMessage> PutAsJson<T>(
            this HttpClient httpClient,
            string url,
            T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;

            return httpClient.PutAsync(url, content);
        }
    }
}
