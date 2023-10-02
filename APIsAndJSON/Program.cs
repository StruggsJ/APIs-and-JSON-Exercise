using Newtonsoft.Json.Linq;

namespace APIsAndJSON

{
    public class Program
    {
        static void Main(string[] args)
        {

            string removeWord = "quote";

            int counterRon = 0;
            int counterKanye = 0;

            int totalRon = 0;
            int totalKanye = 0;
            int totalQuotes = 0;

            var client = new HttpClient();
            
            var ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var kanyeUrl = "https://api.kanye.rest";

            

            string[] ronQuotes = new string[5];
            string[] kayneQuotes = new string[5];

            foreach (var quote in ronQuotes)
            {

                var ronResponse = client.GetStringAsync(ronUrl).Result;
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();

                ronQuotes[counterRon] = ronQuote;
                counterRon++;
            }

            foreach (var quote in kayneQuotes)
            {
                var kanyeResponse = client.GetStringAsync(kanyeUrl).Result;
                var kayneQuote = JObject.Parse(kanyeResponse).ToString().Replace('{', ' ').Replace('}', ' ').Replace('"', ' ').Replace(removeWord, " ").Replace(':', ' ').Trim();

                kayneQuotes[counterKanye] = kayneQuote;
                counterKanye++;
            }

            totalRon = ronQuotes.Length;
            totalKanye = kayneQuotes.Length;
            totalQuotes = totalRon + totalKanye;

            for (int i = 0; i < 5; i++) 
            {
                Console.WriteLine($"\"{ronQuotes[i]}\", said Ron.");
                Console.WriteLine();
                Console.WriteLine($"\"{kayneQuotes[i]}\", said Kanye.");
                Console.WriteLine();

            }
          
        }
    }
}
