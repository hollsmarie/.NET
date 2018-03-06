using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Seymore = new Human ("Seymore");
            Human Larry = new Human ("Larry");
            Seymore.attack(Larry);
        }
    }
}
