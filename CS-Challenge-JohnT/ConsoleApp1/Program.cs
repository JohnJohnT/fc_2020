﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

          int userInput = 0;

              do{
                userInput = DisplayJokeMenu();
                switch(userInput){
                  case 1:
                    GetInstructions();
                    clearApp();
                    break;
                  case 2:
                    GetJokesByCategory();
                    clearApp();
                    break;
                  case 3:
                    GetJokes(null);
                    clearApp();
                    break;
                  case 4:
                    Console.WriteLine("Just Kidding. You actually have to be Chuck Norris to do that");
                    clearApp();
                    break;

                }
              }while(userInput !=5);

        }

        private static void clearApp(){
         Console.WriteLine("Press Any key to continue");
         Console.ReadKey();
         Console.Clear();
       }

       ///<summary>
       /// Create a display menu to allow user to select flow
       ///</summary>
        static public int DisplayJokeMenu()
        {
          Console.WriteLine("Welcome to the Chuck Norris Joke Generator");
          Console.WriteLine("================================================");
          Console.WriteLine("1. Get Instructions");
          Console.WriteLine("2. Get Jokes By Category");
          Console.WriteLine("3. Get some random jokes");
          Console.WriteLine("4. Divide By Zero");
          Console.WriteLine("5. Exit");
          try{
          var result = Console.ReadLine();
          return Convert.ToInt32(result);
          }
          catch (Exception e){
              Console.WriteLine("Invalid Entry. Chuck says read the instructions");
              return 1;
          }

        }


        ///<summary>
        /// Get Jokes Flow
        ///</summary>
        private static void GetJokes(string catName)
        {
          Console.WriteLine("Please enter a name or leave blank to invoke using Chuck Norris\n");
          string name = Console.ReadLine();

          Console.WriteLine("How many jokes do you want? 1-9\n");
          int numOfJokes = 1;
          try{
            numOfJokes = Convert.ToInt32(Console.ReadLine());
            if(numOfJokes > 9){
              numOfJokes = 1;
              throw new Exception();
            }
          }
          catch(Exception e){
            Console.WriteLine("Invalid Entry. Chuck says you get one joke\n");
          }


          try{
            List<String> jokes = JsonFeed.GetRandomJokesByCategory(catName,numOfJokes).Result;
            //Print out list of jokes. If the user provided a substitue name, replace Chuck norris with it 
            foreach(string joke in jokes){
              Console.WriteLine(!string.IsNullOrEmpty(name)?joke.Replace("Chuck Norris", name) : joke);
            }
          }
          catch(Exception e){
            Console.WriteLine("Error retriving jokes. Please try again later or contact Chuck directly.");
          }

        }


        private static void GetInstructions(){
          Console.WriteLine("----Instructions For CN joke generator----\n");
          Console.WriteLine("The Chuck Norris Joke Generator will generate jokes by a category of your choosing, or you can ask for some random jokes.\n You can ask for up to 9 jokes at a time and can swap in" +
          " a different name in place of Chuck Norris - although Chuck will be very unimpressed.");


        }
        ///<summary>
        /// Get Jokes By Category Flow, will call get jokes flow
        ///</summary>
        private static void GetJokesByCategory()
        {
          Dictionary<int, string> categories = new Dictionary<int, string>();
            try{
              categories = JsonFeed.GetCategories().Result;

            }
            catch(Exception e){
              Console.WriteLine("Error retrieving joke categories please try again later");
            }
            //Present user with a menu to allow them to select Joke Category
            Console.WriteLine("Please select a category");
            foreach(KeyValuePair<int, string> cat in categories){
              Console.WriteLine("{0} {1}", cat.Key, cat.Value);
            }

            try{
              var result = Console.ReadLine();
              int catVal = Convert.ToInt32(result);
              //Use the text value of the category name key they provided as required by endpoint
              string catName = categories[catVal];
              GetJokes(catName);
            }
            catch(KeyNotFoundException knfe){
              Console.WriteLine("Invalid category selected.");
            }
            catch (Exception e){
              Console.WriteLine("Error retriving jokes. Please try again later or contact Chuck directly.");
              clearApp();
            }

        }

    }
}
