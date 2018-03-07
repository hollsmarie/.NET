
using System;
using System.Collections.Generic;
namespace WizardNinjaSamurai
{
    public class Wizard : Human
    {

        public Wizard(string name) : base(name)
        {
            health = 50;
            intelligence = 25;
        
        }
        public void Heal(){
            health += 10 * intelligence;
        }
        public void fireball(Human human)
        {
            Random rand = new Random();
            int damage = rand.Next(20,50);
            human.health -= damage;
            System.Console.WriteLine($"{human.name} now has a health of {human.health}");
        }
    }
}