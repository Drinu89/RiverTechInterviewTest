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
            _ => Then_the_api_response_return_the_fields_and_values(1 , "Leanne Graham", "Bret", "Sincere@april.biz",
                "Kulas Light", "Apt. 556", "Gwenborough", "92998-3874", "-37.3159", "81.1496" ,
                "1-770-736-8031 x56442", "hildegard.org", "Romaguera-Crona", "Multi-layered client-server neural-net", "harness real-time e-markets"));
    }
}