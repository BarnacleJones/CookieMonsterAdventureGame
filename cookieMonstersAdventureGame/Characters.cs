using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookieMonstersAdventureGame
{
    class Characters
    {

        public int Health { get; set; }
        protected int Attack { get; set; }
        public int Defend { get; set; }

        //gameover bool
        public static bool gameOver = false;

        public Characters(int health, int attack, int defend)
        {
            Health = health;
            Attack = attack;
            Defend = defend;            
        }

        public virtual void Greet()
        {
            Console.WriteLine("I am created - I am alive!\n");
        }

        //attack is called and returns an int value for updating the health of the opponent
        public virtual int AttackOpponent(int opponentsDefence, int opponentsHealth)
        {
            Console.WriteLine("Its critical!\n");
            return (opponentsHealth - (Attack - opponentsDefence));
        }

        //defend int is returned 
        public virtual int DefendOpponent()
        {
            return Defend;
        }


        public virtual void Die()
        {
            Console.WriteLine("Wow. I am dead.\n");            
        }

    }
}
