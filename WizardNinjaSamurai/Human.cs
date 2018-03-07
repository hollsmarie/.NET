
using System;
using System.Collections.Generic;
namespace WizardNinjaSamurai
{
    public class Human
    {
        public string name;
        public int strength {get;set;}

        public int intelligence {get;set;}

        public int dexterity {get;set;}
        
        public int health {get;set;}

        public Human (string n)
        {
            name = n;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }

        public Human (string n, int s, int i, int d, int h)
        {
            name = n;
            strength = s;
            intelligence = i;
            dexterity = d;
            health = h;
        }

        public void attack(object obj)
        {
            Human alien = obj as Human;
            if(alien == null)
            {
                System.Console.WriteLine("Failed Attack");
            }
            else
            {
                alien.health -= strength * 5;
            }
        }
    }
}