
using System;
using System.Collections.Generic;
namespace WizardNinjaSamurai
{
    public class Ninja : Human
    {

        public Ninja(string name) : base(name)
        {
            dexterity = 175;
        }

        public void Steal(Human human)
        {
            this.health += 10;
            System.Console.WriteLine($"{human.name} now has a health of {human.health}");
        }

         public void getAway()
        {
            this.health -= 15;
            System.Console.WriteLine($"{this.name} now has a health of {this.health}");
        }


    }

}