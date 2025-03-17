namespace FrontEnd.Repository.Interface
{
    public interface IApiRepository<T>
    {
        Task<T?> CallApi(string resourceUrl, HttpMethod method, object? payloadBody = null, string bodycontentType = "application/json", SortedDictionary<string, string>? parameter = null, string? filePath = null);
    }
}
