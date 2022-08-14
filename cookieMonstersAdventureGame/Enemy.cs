using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookieMonstersAdventureGame
{
    class Enemy : Characters
    {
        public string cookieName;
        private string gift;


        public Enemy(int health, int attack, int defend, string name, string present): base(health, attack, defend)
        {
            Health = health;
            Attack = attack;
            Defend = defend;
            cookieName = name;
            gift = present;
            Console.WriteLine("An enemy has spawned! Uh oh. Its health is {0}, Attack Power is {1}, Defence is {2}\n", Health, Attack, Defend);
        }

        public override void Greet()
        {
            base.Greet();
            Console.WriteLine("And my name is {0}", cookieName);
            Console.WriteLine("I hope you are ready to fight!\n");
        }

        public override void Die()
        {
            Console.WriteLine("You killed me.");
            Console.WriteLine("Please eat me with milk, so I am not wasted.");
            Console.WriteLine("I will give you a gift, {0}\n\n", gift);
        }


    }
}
