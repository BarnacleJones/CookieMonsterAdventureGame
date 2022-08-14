using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookieMonstersAdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------------------------------------------------------------------------------------------
            //Ben Jones
            //30056470
            //Homework assignment - class practice
            //--------------------------------------------------------------------------------------------

            #region Intro screen
            //--------------------------------------------------------------------------------------------
            //https://stackoverflow.com/questions/3436132/producing-ascii-art-via-c-sharp
            //To get ASCII art
            //https://patorjk.com/software/taag/

            string text = @"

            _________                __   .__            _____                         __                       
            \_   ___ \  ____   ____ |  | _|__| ____     /     \   ____   ____   ______/  |_  ___________  ______
            /    \  \/ /  _ \ /  _ \|  |/ /  |/ __ \   /  \ /  \ /  _ \ /    \ /  ___|   __\/ __ \_  __ \/  ___/
            \     \___(  <_> |  <_> )    <|  \  ___/  /    Y    (  <_> )   |  \\___ \ |  | \  ___/|  | \/\___ \ 
             \______  /\____/ \____/|__|_ \__|\___  > \____|__  /\____/|___|  /____  >|__|  \___  >__|  /____  >
                    \/                   \/       \/          \/            \/     \/           \/           \/ 

";
            Console.WriteLine(text);
            Console.WriteLine("Welcome - to COOKIE MONSTERS.");
            Console.WriteLine("A text based adventure game.\nBased in the realm of the killer cookies.\n\n\n");
            Console.WriteLine("You will be given options in this game.");
            Console.WriteLine("Press 1 or 2, followed by the ENTER key to make your choices....\n");
            Console.WriteLine("Press any key to begin!");
            Console.ReadKey();
            Console.Clear();
            #endregion
            //--------------------------------------------------------------------------------------------

            #region Backstory
            //--------------------------------------------------------------------------------------------

            Console.WriteLine("Long backstory about why you're here...\n");
            Console.WriteLine("Blah blah story about saving the terrorised people from friendly cookies turned evil\nThey need someone to restore the peace.\n");
            Console.WriteLine("Premonition about milk being a great weapon....where can I get milk???\n");
            Console.WriteLine("Thanks for being here - you must save this cookie kingdom!\nGo\nForth!\n");
            #endregion
            //--------------------------------------------------------------------------------------------

            #region Get details + spawn character
            //--------------------------------------------------------------------------------------------

            Console.Write("First, let us get your name: ");
            string charName = Console.ReadLine();
            Console.WriteLine("Great, thanks {0}!", charName);
            Console.Write("Now, what is your chosen weapon?: ");
            string charWeapon = Console.ReadLine();

            MainCharacter mainChar = new MainCharacter(100, 30, 20, charName, charWeapon);
            mainChar.Greet();
            Console.WriteLine("\n\n\n");
            #endregion
            //--------------------------------------------------------------------------------------------

            # region Location generation
            //--------------------------------------------------------------------------------------------
            Location start = new Location("the starting line", "Kitchen", "Bedroom");
            Location kitchen = new Location("the kitchen", "Front yard", "Back yard");
            Location bedroom = new Location("the bedroom", "Sleep", "Get Dressed");
            Location sleep = new Location("the sleeping quarters", "Get Dressed", "Kitchen");
            Location dressed = new Location("the dressing room", "Dairy", "Sleep");
            Location front = new Location("the front yard", "Back yard", "Dairy");
            Location back = new Location("the back yard", "Front yard", "Dairy");
            Location dairy = new Location("the local dairy", "a", "b");
            #endregion
            //--------------------------------------------------------------------------------------------

            #region Method for changing locations (this is where monsters are created too)
            //returns a string of new location 
            //--------------------------------------------------------------------------------------------
            string changeLocation(string locale)
            {
                switch (locale)
                {
                    case "kitchen":
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        Console.WriteLine("\nYou arrive at the kitchen");
                        Enemy firstCookie = new Enemy(50, 30, 10, "Oaty Killa", "30 health!");
                        firstCookie.Greet();
                        fightSequence(firstCookie);
                        if (Characters.gameOver)
                        {
                            break;
                        }
                        else
                        {
                            mainChar.Health += 30;
                            locale = kitchen.giveOptions().ToLower();
                            break;
                        }
                    case "bedroom":
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        Console.WriteLine("You arrive in the bedroom\n");                        
                        Console.WriteLine("You think to yourself, I'm not going to save the kingdom in here....\n\n");
                        locale = bedroom.giveOptions().ToLower();
                        break;
                    case "get dressed":
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        Console.WriteLine("Some nice clothes should help me save the kingdom.\n");
                        Console.WriteLine("Oh look at that! There is armour in my closet!\n");
                        mainChar.addDefence(20);
                        locale = dressed.giveOptions().ToLower();
                        break;
                    case "front yard":
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        Console.WriteLine("Oh what a sunny day!");
                        Console.WriteLine("Wait - the sun is dissapearing!\n");
                        Enemy giantCookie = new Enemy(60, 30, 20, "Triple Choco CHONK", "50 health!");
                        giantCookie.Greet();
                        fightSequence(giantCookie);
                        if (Characters.gameOver)
                        {
                            break;
                        }
                        else
                        {
                            mainChar.Health += 50;
                            Console.WriteLine("My health is now {0}", mainChar.Health);
                            locale = front.giveOptions().ToLower();
                            break;
                        }
                    case "back yard":
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        Console.WriteLine("Wow, this is a huge back yard!");
                        Console.WriteLine("I must be loaded.\n");
                        Console.WriteLine("What is that running in the distance?\n");
                        Enemy mediumCookie = new Enemy(30, 20, 20, "Bite size chocochip cookie ninja", "40 health!");
                        mediumCookie.Greet();
                        fightSequence(mediumCookie);
                        if (Characters.gameOver)
                        {
                            break;
                        }
                        else
                        {
                            mainChar.Health += 40;
                            Console.WriteLine("My health is now {0}", mainChar.Health);
                            locale = back.giveOptions().ToLower();
                            break;
                        }
                    case "sleep":
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        Console.WriteLine("Mmm, a sleep really doesn't seem like what I should be doing now...\n");
                        Console.WriteLine("Though...I am sleepy\n");
                        Console.WriteLine("OK OK enough of that. Wait - I've gained 40 health!\n");
                        mainChar.Health = +40;
                        Console.WriteLine("My health is now {0}", mainChar.Health);
                        Console.WriteLine("Booya\nOn my way!");
                        locale = sleep.giveOptions().ToLower();
                        break;
                    case "dairy":
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        Console.WriteLine("I've made it to the Dairy!\n");
                        Console.WriteLine("Wonder if I can find milk here, wasn't that supposed to be a good weapon?\n");
                        Console.WriteLine("OH YEA, found some milk!\n");
                        mainChar.addAttack(30);
                        Enemy bossCookie = new Enemy(400, 30, 20, "Big boss macadamia NUTTER", "Peace in the entire cookie kingdom");
                        bossCookie.Greet();
                        fightSequence(bossCookie);
                        if (!Characters.gameOver)
                        {
                            Console.WriteLine("You win!");
                            Console.WriteLine("NO LONGER ARE THE COOKIES EVIL\n");
                            Console.WriteLine("Peace is restored!\n");
                            Console.WriteLine("COOKIE PARTY - GAME OVER");
                            Console.WriteLine(@"
                                _____.___.________   ____ ___   __      __.___ _______   
                                \__  |   |\_____  \ |    |   \ /  \    /  \   |\      \  
                                 /   |   | /   |   \|    |   / \   \/\/   /   |/   |   \ 
                                 \____   |/    |    \    |  /   \        /|   /    |    \
                                 / ______|\_______  /______/     \__/\  / |___\____|__  /
                                 \/               \/                  \/              \/

                                ");
                        }
                        Characters.gameOver = true;                        
                        break;
                    default:
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        locale = "test";
                        Console.WriteLine("Ended up in wrong place. game over");
                        break;
                }
                return locale;
            }
            #endregion
            //--------------------------------------------------------------------------------------------

            #region Method for battle sequence
            //
            //--------------------------------------------------------------------------------------------
            void fightSequence(Enemy nameofChar)
            {
                bool fight = true;
                while (fight)
                {
                    Console.WriteLine("Press any key to attack the {0}\n", nameofChar.cookieName);
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                    Console.ReadKey();
                    Console.WriteLine("You attack first\n");
                    nameofChar.Health = mainChar.AttackOpponent(nameofChar.Defend, nameofChar.Health);
                    Console.WriteLine("Now the {0} attacks\n", nameofChar.cookieName);
                    mainChar.Health = nameofChar.AttackOpponent(mainChar.Defend, mainChar.Health);

                    if (nameofChar.Health <= 0)
                    {
                        nameofChar.Die();
                        fight = false;
                    }
                    else if (mainChar.Health <= 0)
                    {
                        mainChar.Die();
                        fight = false;
                    }
                    else
                    {
                        Console.WriteLine("Nobody dead yet.");
                        Console.WriteLine("Cookie health is {0}", nameofChar.Health);
                        Console.WriteLine("Your health is {0}\n\n", mainChar.Health);
                    }
                }
            }
            #endregion
            //--------------------------------------------------------------------------------------------

            #region Game loop
            //--------------------------------------------------------------------------------------------
            //start at start
            string nextLocation = start.giveOptions().ToLower();

                while (!Characters.gameOver)
                {
                    nextLocation = changeLocation(nextLocation);
                    if (nextLocation == "test")
                    {
                        Console.WriteLine("Game is broken.");
                        Characters.gameOver = true;
                    }
                }
            #endregion
            //--------------------------------------------------------------------------------------------

            Console.ReadKey();


            }
        }
    }

