using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    static class JsonFeed
    {
        static readonly HttpClient httpClient = new HttpClient();

        static JsonFeed(){
          httpClient.BaseAddress = new Uri("https://api.chucknorris.io/jokes/");
        }


        ///<summary>
        /// Get Jokes By Categroy Call
        /// <parameter> categoryName </parameter> if a category name is provided append paramater to URL
        /// <parameter> numberOfJokes </parameter> denotes how many jokes the user requested
        ///</summary>
    public static async Task<List<String>> GetRandomJokesByCategory(string categoryName,int numberOfJokes){

      StringBuilder sb = new StringBuilder();
      sb.Append("random");
      if(!String.IsNullOrEmpty(categoryName)){
        sb.Append("?category=" + categoryName);
      }

      List<string> jokes = new List<string>();
      int i = 0;
      while(i < numberOfJokes){
        var randomJoke = JsonConvert.DeserializeObject<dynamic>(httpClient.GetStringAsync(sb.ToString()).Result);
        String joke = randomJoke.value;
        jokes.Add(joke);
        i++;
      }

      return jokes;

    }
    ///<summary>
    /// Get Category Listing
    /// Returns a dictionary of generated int keys and string values of the categaory names
    ///</summary>
		public static async Task<Dictionary<int, string>> GetCategories()
		{
      var categories = JsonConvert.DeserializeObject<List<string>>(httpClient.GetStringAsync("categories").Result);
      Dictionary<int, string> dict = new Dictionary<int, string>();
      int i = 1;
      Console.WriteLine("----JOKE CATEGORIES ----\n");
      foreach(string s in categories){
        dict.Add(i, s);
        i++;

      }
      return dict;


		}
    }

}
