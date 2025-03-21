using System.Text.Json;

namespace DotNET_Console_Application;
class Program
{
    static readonly HttpClient client = new HttpClient();

    static int GetValidInt(string prompt)
    {
        int result = 0;
        bool valid = false;
        while (!valid)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out result))
            {
                valid = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
        return result;
    }
    static async Task<Person> GetPersonFromAPI()
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync("https://randomuser.me/api/");
            response.EnsureSuccessStatusCode();
            string responseStr = await response.Content.ReadAsStringAsync();
            JsonDocument responseData = JsonDocument.Parse(responseStr);
            JsonElement results = responseData.RootElement.GetProperty("results")[0];
            return new Person(results.GetProperty("name").GetProperty("first").GetString(), results.GetProperty("name").GetProperty("last").GetString(), results.GetProperty("location").GetProperty("street").GetProperty("number").GetInt32() + " " + results.GetProperty("location").GetProperty("street").GetProperty("name").GetString() + " " + results.GetProperty("location").GetProperty("city").GetString() + " " + results.GetProperty("location").GetProperty("state").GetString() + " " + results.GetProperty("location").GetProperty("country").GetString(), results.GetProperty("email").GetString());
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            return null;
        }

    }
    static async Task Main(string[] args)
    {
        string selection;
        List<Person> people = new List<Person>([
            await GetPersonFromAPI(),
            await GetPersonFromAPI(),
            await GetPersonFromAPI(),
            await GetPersonFromAPI(),
            await GetPersonFromAPI()
        ]);
        do
        {
            Console.Write("--People--\n1. Create\n2. Read\n3. Update\n4. Delete\n5. Exit\n\tChoose: ");
            selection = Console.ReadLine().Trim();
            if (selection == "1")
            {
                people.Add(await GetPersonFromAPI());
            }
            else if (selection == "2")
            {
                for (int i = 0; i < people.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {people[i].FirstName} {people[i].LastName}");
                }
                Console.Write("Select a Person: ");
                Console.WriteLine(people[int.Parse(Console.ReadLine()) - 1]);
            }
            else if (selection == "3")
            {
                for (int i = 0; i < people.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {people[i].FirstName} {people[i].LastName}");
                }
                Console.Write("Select a Person: ");
                int selectedPerson = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Enter new first name: ");
                people[selectedPerson].FirstName = Console.ReadLine().Trim();
            }
            else if (selection == "4")
            {
                for (int i = 0; i < people.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {people[i].FirstName} {people[i].LastName}");
                }
                Console.Write("Select a Person: ");
                people.RemoveAt(int.Parse(Console.ReadLine()) - 1);
            }
            else
            {
                Console.WriteLine("Invalid selection, please try again...");
            }
        } while (selection != "5");
        Console.WriteLine("Cya!");
    }
}
