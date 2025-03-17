using FrontEnd.Repository.Interface;
using FrontEnd.Define;
using System.Text;
using System.Text.Json;
using System.Web;

namespace FrontEnd.Repository
{
    public class ApiRepository<T> : IApiRepository<T> where T : class
    {
        private readonly HttpClient _httpClient;

        public ApiRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<T?> CallApi(string resourceUrl, HttpMethod method, object? payloadBody = null, string bodycontentType = "application/json", SortedDictionary<string, string>? parameter = null, string? filePath = null)
        {
            StringContent? stringContent = null;
            using var formData = new MultipartFormDataContent();

            if (payloadBody != null)
            {
                stringContent = new StringContent(JsonSerializer.Serialize(payloadBody), Encoding.UTF8, bodycontentType);
                formData.Add(stringContent, "json");
            }

            if (filePath != null)
            {
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var fileName = Path.GetFileName(filePath);
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                formData.Add(fileContent, "file", fileName);
            }

            var uriBuilder = new UriBuilder($"{EndPointUrl.BaseUrl}{resourceUrl}");
            if (parameter != null)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);

                foreach (var item in parameter)
                    query[item.Key] = item.Value;

                uriBuilder.Query = query.ToString();
            }

            var requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(uriBuilder.ToString()),
                Method = method,
                Content = filePath != null ? formData : stringContent
            };

            var response = await _httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) throw new Exception($"เกิดข้อผิดผลาดกรุณาลองใหม่อีกครั้ง({System.Net.HttpStatusCode.NotFound})");
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new Exception($"เกิดข้อผิดผลาดกรุณาลองใหม่อีกครั้ง({System.Net.HttpStatusCode.Unauthorized})");
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) throw new Exception($"เกิดข้อผิดผลาดกรุณาลองใหม่อีกครั้ง({System.Net.HttpStatusCode.Forbidden})");
            if (response.StatusCode == System.Net.HttpStatusCode.BadGateway) throw new Exception($"เกิดข้อผิดผลาดกรุณาลองใหม่อีกครั้ง({System.Net.HttpStatusCode.BadGateway})");
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception($"เกิดข้อผิดผลาดกรุณาลองใหม่อีกครั้ง({System.Net.HttpStatusCode.BadRequest})");
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError) throw new Exception($"เกิดข้อผิดผลาดกรุณาลองใหม่อีกครั้ง({System.Net.HttpStatusCode.InternalServerError})");
            if (response.StatusCode == System.Net.HttpStatusCode.UnsupportedMediaType) throw new Exception($"เกิดข้อผิดผลาดกรุณาลองใหม่อีกครั้ง({System.Net.HttpStatusCode.UnsupportedMediaType})");
            if (response.Content == null) throw new Exception("เกิดข้อผิดผลาดกรุณาลองใหม่อีกครั้ง(NULL_CONTENT)");

            var result = JsonSerializer.Deserialize<T>(responseContent);
            return result;
        }
    }
}
