using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookieMonstersAdventureGame
{
    class Location
    {
        public string name { get; set; }
        private string choice1;
        private string choice2;


        public Location(string locationName, string choiceNum1, string choiceNum2)
        {
            name = locationName;
            choice1 = choiceNum1;
            choice2 = choiceNum2;
        }

        public string giveOptions()
        {
            Console.WriteLine("You have two options of where to go.\n");
            Console.Write($"Would you like to go to {choice1} (1) or {choice2} (2)?: ");

            string choice = Console.ReadLine();
            if (int.TryParse(choice, out int value) && (value == 1))
            {
                return choice1;
            }
            else if (int.TryParse(choice, out int value2) && (value2 == 2))
            {
                return choice2;
            }
            else{
                Console.WriteLine("\n\nYou didn't enter a valid number ya flamin' drongo");
                Console.WriteLine("Computer says you're taking option 1 because this is obviously too hard");
                return choice1;
            }



        }
    }
}
