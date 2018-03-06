using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        public static void RandomArrayFX()
        {
            Random randNum = new Random();
            int[] randomArray = new int[10];
            int sum = randomArray[0];
            for (int i = 0; i < 10; i++)
            {
                randomArray[i] = randNum.Next(5, 26);
                sum += randomArray[i];
            }
            int min = randomArray[0];
            int max = randomArray[0];
            for (int j = 0; j < 10; j++)
            {
                if (randomArray[j] < min)
                {
                    min = randomArray[j];
                }
                if (randomArray[j] > max)
                {
                    max = randomArray[j];
                }
            }
            Console.WriteLine(randomArray);
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(sum);

        }

        public static string CoinFlip()
        {
            Random rand = new Random();
            // System.Console.WriteLine("Tossing a coin!");
            // int[] randomArray = new int[1];
            string postResults = "";
            // for (int val = 0; val < 1; val++)
            int flip = rand.Next(1, 3);
            {
                if (flip == 1)
                {
                    postResults = "heads";
                }
                if (flip == 2)
                {
                    postResults = "tails";
                }
            }
            return postResults;
        }


        public static double TossMultipleCoins(int num)
        {
            string toss;
            int totalH = 0;
            int totalT=0; 
            for (int val = 0; val < num; val++)
            {
             
             toss = CoinFlip();
             System.Console.WriteLine(toss);
             if (toss == "heads")
             {
            totalH ++;
             }
             if (toss == "tails")
             {
             totalT++;
            }
            }
            double result = (double)totalH/(double )totalT;
            System.Console.WriteLine(result);
            return result;
        }

        public static string[] Names()
        {
            string [] nameArray = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random rand = new Random();
            String temp = "";
            for( int i = 0; i < nameArray.Length; i++)
            {

                int index = rand.Next(i, nameArray.Length);
                temp = nameArray[i];
                nameArray [i] = nameArray[index];
                nameArray[index] = temp;
                Console.WriteLine("Index {0} has {1}", i, nameArray[i]);

            }
            List<string> longNamesList = new List<string>();
            for (int i=0; i<nameArray.Length; i++)
            {
                if(nameArray[i].Length > 5){
                    longNamesList.Add(nameArray[i]);
                }
            }
            string[] longNames = longNamesList.ToArray();
            for (int i =0; i < longNames.Length; ++i)
            {
                System.Console.WriteLine(longNames[i]);
            }
            return longNames;
        }

        static void Main(string[] args)
        {
            {

                Names();

                //THIS IS THE RETURN STATEMENT FOR COINFLIP
                //string tossMany;
                //tossMany = TossMultipleCoins();
                //Console.WriteLine(tossMany);
                
                //THIS IS THE RETURN STATEMMENT FOR MULTIPLE COIN TOSS
                // int num_tosses = 20;
                // double ratio = TossMultipleCoins(num_tosses);
                // System.Console.WriteLine("The ratio of Heads to Tails is {0}", ratio.ToString());
            }

        }
    }
}
