using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] myArray = new int[10] {0,1,2,3,4,5,6,7,8,9};
            // foreach (int array in myArray)
            // {
            //     Console.WriteLine(array);
            // }
            string[] myNames = new string[4] {"Tim", "Martin", "Nikki", "Sara"};
            foreach (string name in myNames)
            {
                Console.WriteLine(name);
            }

            // int[] myArray = new int[10] {0,1,2,3,4,5,6,7,8,9};
            // for (int idx = 0; idx <myArray.Length; idx++)
            // {
            //     if (idx % 2 == 0)
            //     {
            //         Console.WriteLine("True");
            //     }
            //     else if (idx %2 != 0)
            //     {
            //         Console.WriteLine("False");
            //     }
            // }
            // int[,] multiTable = new int[10,10];
            // {
            //     for (int i = 0; i < 10; i++)
            //     {
            //         for (int j = 0; j < 10; j++)
            //         {
            //             multiTable[i,j] = (i + 1) * (j + 1);
            //             Console.Write(multiTable[i,j] + "\t");
            //         }
            //         Console.WriteLine();
            //     }
            
            // List<string> iceCreams = new List<string>();
            // iceCreams.Add("Chocolate");
            // iceCreams.Add("Vanilla");
            // iceCreams.Add("Strawberry");
            // iceCreams.Add("Pistachio");
            // iceCreams.Add("Mint");
            // foreach (string flavor in iceCreams)
            // {
            // Console.WriteLine(flavor);
            // }

            List<string> iceCreams = new List<string>();
            iceCreams.Add("Chocolate");
            iceCreams.Add("Vanilla");
            iceCreams.Add("Strawberry");
            iceCreams.Add("Pistachio");
            iceCreams.Add("Mint");
            Console.WriteLine(iceCreams.Count);

            // List<string> iceCreams = new List<string>();
            // iceCreams.Add("Chocolate");
            // iceCreams.Add("Vanilla");
            // iceCreams.Add("Strawberry");
            // iceCreams.Add("Pistachio");
            // iceCreams.Add("Mint");
            // Console.WriteLine(iceCreams[3]);
            // iceCreams.RemoveAt(3);
            // foreach (string flavor in iceCreams)
            // {
            // Console.WriteLine("-" + flavor);
            // Console.WriteLine(iceCreams.Count);
            // }

            // Dictionary<string,string> profile = new Dictionary<string,string>();
            // profile.Add("Name", "Holly");
            // Console.WriteLine("Name - " + profile["Name"]);

            // Dictionary<string,string> profile = new Dictionary<string,string>();
            // profile.Add("Tim", "null");
            // profile.Add("Martin", "null");
            // profile.Add("Nikki", "null");
            // profile.Add("Sara", "null");
            // foreach (var entry in profile)
            // {
            //     Console.WriteLine(entry.Key + " - " + entry.Value);
            // }

            Dictionary<string,string> profile = new Dictionary<string,string>();
            foreach (string name in myNames) {
                profile.Add(name, null);
            }
            Random rand = new Random();
            List<string> keys = new List<string>(profile.Keys);
            for(int i =0; i<keys.Count; i++){
                profile[keys[i]] = iceCreams[rand.Next(0,4)];
            }
            foreach (var entry in profile)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}



///Create an array to hold integer values 0 through 9
///Create an array of the names "Tim", "Martin", "Nikki", "Sara"
///Create an array of length 10 that alternates between true and false values, starting with true
// With the values 1-10, use code to generate a multiplication table like the one below.
// Create a list of Ice Cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
// Output the length of this list after building it
// Output the third flavor in the list, then remove this value.
// Output the new length of the list (Note it should just be one less~)
// Create a Dictionary that will store both string keys as well as string values
// For each name in the array of names you made previously, add it as a new key in this dictionary with value null
// For each name key, select a random flavor from the flavor list above and store it as the value
// Loop through the Dictionary and print out each user's name and their associated ice cream flavor