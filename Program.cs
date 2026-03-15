public class NumbersFact
{
    public static async Task Main()
    {
        Console.WriteLine("This application gives you a random fact about a date.");
        Console.Write("Enter a month: ");
        int month = int.Parse(Console.ReadLine());
        Console.Write("Enter a day: ");
        int day = int.Parse(Console.ReadLine());
        
        string url = $"http://numbersapi.com/{month}/{day}/date";

        try
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Fact: " + message);
            } else
            {
                Console.WriteLine("The request was not succesful. Status code: " + response.StatusCode);
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        
    }
}