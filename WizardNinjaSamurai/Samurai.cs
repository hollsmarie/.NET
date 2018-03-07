
using System;
using System.Collections.Generic;
namespace WizardNinjaSamurai
{
    public class Samurai : Human
    { 
        public Samurai(string name) : base(name)
        {
            health = 200;
        }

        public void deathBlow(Human human)
        {
            if (human.health < 50)
            {
                human.health = 0;
            }
        System.Console.WriteLine($"{human.name} now has a health of {human.health}");
        }

      public void meditate()
        {
            if (this.health < 200)
            {
            this.health = 200;
            }
            System.Console.WriteLine($"{this.name} now has a health of {this.health}");
        }

    }
}