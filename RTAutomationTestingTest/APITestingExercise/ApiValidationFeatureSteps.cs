using LightBDD.NUnit3;
using Newtonsoft.Json;
using static RTAutomationTestingTest.APITestingExercise.ApiService;

namespace RTAutomationTestingTest.APITestingExercise;

public partial class ApiValidationFeature : FeatureFixture
{
    private ApiBuilder _apiBuilder = null!;
    private IApiService _iApiService = new ApiService();
    private int _apiResponseCode = default;
    private string _apiBody = null!;
    private ApiResponse _apiResponse = null!;
    
    private void Given_the_user_sets_a_get_request(string apiUrl)
    {
        _apiBuilder = new ApiBuilder()
        {
            ApiUrl = apiUrl
        };
    }

    private void When_the_user_sends_the_http_request()
    {
        HttpResponseMessage response = _iApiService.SendAGetHTTPRequest(_apiBuilder.ApiUrl);
        _apiResponseCode = (int)response.StatusCode;
        _apiBody = response.Content.ReadAsStringAsync().Result;
    }

    private void Then_the_response_returned_is_valid(int expectedResponseCode)
    {
        Assert.That(expectedResponseCode, Is.EqualTo(_apiResponseCode));
    }
    
    private void Then_the_api_response_return_the_fields_and_values(string expectedJson)
    {

        _apiResponse = JsonConvert.DeserializeObject<ApiResponse>(_apiBody);
        Assert.AreEqual(1, _apiResponse.id);
        Assert.AreEqual("Leanne Graham", _apiResponse.name);
        Assert.AreEqual("Bret", _apiResponse.username);
        Assert.AreEqual("Sincere@april.biz", _apiResponse.email);
        
        Assert.AreEqual("Kulas Light", _apiResponse.address.street);
        Assert.AreEqual("Apt. 556", _apiResponse.address.suite);
        Assert.AreEqual("Gwenborough", _apiResponse.address.city);
        Assert.AreEqual("92998-3874", _apiResponse.address.zipcode);
        
        Assert.AreEqual("-37.3159", _apiResponse.address.geo.lat);
        Assert.AreEqual("81.1496", _apiResponse.address.geo.lng);
        
        Assert.AreEqual("1-770-736-8031 x56442", _apiResponse.phone);
        Assert.AreEqual("hildegard.org", _apiResponse.website);
        
        Assert.AreEqual("Romaguera-Crona", _apiResponse.company.name);
        Assert.AreEqual("Multi-layered client-server neural-net", _apiResponse.company.catchPhrase);
        Assert.AreEqual("harness real-time e-markets", _apiResponse.company.bs);

    }
}