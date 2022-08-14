using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookieMonstersAdventureGame
{
    class MainCharacter: Characters
    {

        private string name;
        private string weapon;
        


        public MainCharacter(int health, int attack, int defend, string name, string weapon) : base(health, attack, defend)
        {
            Health = health;
            Attack = attack;
            Defend = defend;
            this.name = name;
            this.weapon = weapon;
            
        }

        public override void Greet()
        {
            base.Greet();
            Console.WriteLine("My name is {0}, and my weapon is a big ol' {1}", name, weapon);
            Console.WriteLine("I am ready to save this land!");
        }

        public override int AttackOpponent(int opponentsDefence, int opponentsHealth)
        {
            Console.WriteLine("You've attacked the enemy.");
            Console.WriteLine("Its critical dude.");
            return (opponentsHealth - (Attack - opponentsDefence));
        }

        public void addDefence(int def)
        {
            Defend += def;
            Console.WriteLine("Your defence ability has grown by {0}!", def);
        }

        public void addAttack(int goodness)
        {
            Attack += goodness;
            Console.WriteLine($"Your attack power has grown! You can now attack {Attack} damage at a time!");
            Console.WriteLine("Something tells me (the omnipresent cookieland god) you're going to need it....");
        }

        public override void Die()
        {
            base.Die();
            Console.WriteLine("Better luck next time.");
            Console.WriteLine("If there is a next time.....");
            Console.WriteLine(@"
              ________    _____      _____  ___________ ____________   _______________________ 
             /  _____/   /  _  \    /     \ \_   _____/ \_____  \   \ /   |_   _____|______   \
            /   \  ___  /  /_\  \  /  \ /  \ |    __)_   /   |   \   Y   / |    __)_ |       _/
            \    \_\  \/    |    \/    Y    \|        \ /    |    \     /  |        \|    |   \
             \______  /\____|__  /\____|__  /_______  / \_______  /\___/  /_______  /|____|_  /
                    \/         \/         \/        \/          \/                \/        \/

            ");
            gameOver = true;
        }
    }
}
