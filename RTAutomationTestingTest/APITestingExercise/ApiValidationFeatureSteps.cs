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
    
    private void Then_the_api_response_return_the_fields_and_values(int expectedId, string expectedName, string expectedUsername, string expectedEmail, string expectedStreet, string expectedSuite,
        string expectedCity, string expectedZipCode, string expectedGeoLat, string expectedGeoLng, string expectedPhone, string expectedWebsite, string expectedCompanyName, string expectedCompanyCachePhrase, string expectedCompanyBs)
    {

        _apiResponse = JsonConvert.DeserializeObject<ApiResponse>(_apiBody);
        
        //Here I am asserting that the fields are not null or empty. This will assert that the fields are available.
        Assert.That(_apiResponse.name, Is.Not.Null.Or.Empty);
        Assert.That(_apiResponse.username, Is.Not.Null.Or.Empty);
        Assert.That(_apiResponse.email, Is.Not.Null.Or.Empty);

        Assert.That(_apiResponse.address, Is.Not.Null);
        Assert.That(_apiResponse.address.street, Is.Not.Null.Or.Empty);
        Assert.That(_apiResponse.address.suite, Is.Not.Null.Or.Empty);
        Assert.That(_apiResponse.address.city, Is.Not.Null.Or.Empty);
        Assert.That(_apiResponse.address.zipcode, Is.Not.Null.Or.Empty);

        Assert.That(_apiResponse.address.geo, Is.Not.Null);
        Assert.That(_apiResponse.address.geo.lat, Is.Not.Null.Or.Empty);
        Assert.That(_apiResponse.address.geo.lng, Is.Not.Null.Or.Empty);

        Assert.That(_apiResponse.phone, Is.Not.Null.Or.Empty);
        Assert.That(_apiResponse.website, Is.Not.Null.Or.Empty);

        Assert.That(_apiResponse.company, Is.Not.Null);
        Assert.That(_apiResponse.company.name, Is.Not.Null.Or.Empty);
        Assert.That(_apiResponse.company.catchPhrase, Is.Not.Null.Or.Empty);
        Assert.That(_apiResponse.company.bs, Is.Not.Null.Or.Empty);
        
        //Here I am asserting the values inside the fields.
        Assert.AreEqual(expectedId, _apiResponse.id);
        Assert.AreEqual(expectedName, _apiResponse.name);
        Assert.AreEqual(expectedUsername, _apiResponse.username);
        Assert.AreEqual(expectedEmail, _apiResponse.email);
        
        Assert.AreEqual(expectedStreet, _apiResponse.address.street);
        Assert.AreEqual(expectedSuite, _apiResponse.address.suite);
        Assert.AreEqual(expectedCity, _apiResponse.address.city);
        Assert.AreEqual(expectedZipCode, _apiResponse.address.zipcode);
        
        Assert.AreEqual(expectedGeoLat, _apiResponse.address.geo.lat);
        Assert.AreEqual(expectedGeoLng, _apiResponse.address.geo.lng);
        
        Assert.AreEqual(expectedPhone, _apiResponse.phone);
        Assert.AreEqual(expectedWebsite, _apiResponse.website);
        
        Assert.AreEqual(expectedCompanyName, _apiResponse.company.name);
        Assert.AreEqual(expectedCompanyCachePhrase, _apiResponse.company.catchPhrase);
        Assert.AreEqual(expectedCompanyBs, _apiResponse.company.bs);

    }
}