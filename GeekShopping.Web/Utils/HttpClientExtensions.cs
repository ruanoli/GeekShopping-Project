using System.Text.Json;

namespace GeekShopping.Web.Utils
{
    public static class HttpClientExtensions
    {
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
    }
}
