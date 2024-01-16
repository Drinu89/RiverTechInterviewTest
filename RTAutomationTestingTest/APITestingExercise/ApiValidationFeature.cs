using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.NUnit3;

[assembly: LightBddScope]

namespace RTAutomationTestingTest.APITestingExercise;

[FeatureDescription(
    @"In order to receive a valid API call
    As a user
    I want to send a valid GET request")]
public partial class ApiValidationFeature
{
    [Scenario]
    public void ValidationOfTheApiResponse()
    {
        Runner.RunScenario(
            _ => Given_the_user_sets_a_get_request("https://jsonplaceholder.typicode.com/users/1"),
            _ => When_the_user_sends_the_http_request(),
            _ => Then_the_response_returned_is_valid(200));
    }
    
    [Scenario]
    public void ValidateFieldsAndValues()
    {
        Runner.RunScenario(_ => Given_the_user_sets_a_get_request("https://jsonplaceholder.typicode.com/users/1"),
            _ => When_the_user_sends_the_http_request(),
            _ => Then_the_api_response_return_the_fields_and_values("{\n    \"id\": 1,\n    \"name\": \"Leanne Graham\",\n    \"username\": \"Bret\",\n    \"email\": \"Sincere@april.biz\",\n    \"address\": {\n        \"street\": \"Kulas Light\",\n        \"suite\": \"Apt. 556\",\n        \"city\": \"Gwenborough\",\n        \"zipcode\": \"92998-3874\",\n        \"geo\": {\n            \"lat\": \"-37.3159\",\n            \"lng\": \"81.1496\"\n        }\n    },\n    \"phone\": \"1-770-736-8031 x56442\",\n    \"website\": \"hildegard.org\",\n    \"company\": {\n        \"name\": \"Romaguera-Crona\",\n        \"catchPhrase\": \"Multi-layered client-server neural-net\",\n        \"bs\": \"harness real-time e-markets\"\n    }\n}"));
    }
}