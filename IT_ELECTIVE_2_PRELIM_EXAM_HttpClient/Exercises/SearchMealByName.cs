namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 2: GET Search by Name
// TheMealDB API: https://themealdb.com/api/json/v1/1/search.php?s={name}
//
// Your task:
// 1. Use the HttpClient to search for meals with name "Arrabiata"
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the "meals" array has at least 1 result
//
// Hint: Use System.Text.Json.JsonDocument.Parse() to parse JSON
// Hint: The response format is { "meals": [...] } — meals can be null if no results

public static class SearchMealByName
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Send GET request to https://themealdb.com/api/json/v1/1/search.php?s=Arrabiata
        var response = await client.GetAsync("https://themealdb.com/api/json/v1/1/search.php?s=Arrabiata");

        // TODO: Assert status code is 200 OK
        if (!response.IsSuccessStatusCode)
            throw new Exception("Status code is not 200 OK");

        // TODO: Parse the response JSON
        var body = await response.Content.ReadAsStringAsync();
        using var doc = System.Text.Json.JsonDocument.Parse(body);

        // TODO: Assert that the "meals" array is not null and has at least 1 item
        var meals = doc.RootElement.GetProperty("meals");
        if (meals.ValueKind == System.Text.Json.JsonValueKind.Null || meals.GetArrayLength() < 1)
        {
            throw new Exception("Meals array is null or empty");
        }
    }
}