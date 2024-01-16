namespace RTAutomationTestingTest.APITestingExercise;

public interface IApiService
{
    HttpResponseMessage SendAGetHTTPRequest(string baseUrl);
    List<string> GetFields();
}

public class ApiService : IApiService
{
    public class ApiBuilder()
    {
        public string ApiUrl { get; init; }
    }

    public HttpResponseMessage SendAGetHTTPRequest(string baseUrl)
    {
        HttpClient client = new HttpClient();

        HttpResponseMessage response =  client.GetAsync(baseUrl).Result;

        return response;

    }

    public List<string> GetFields()
    {
        List<string> fieldList = new List<string> { "id", "name", "username" };

        return fieldList;
    }
}