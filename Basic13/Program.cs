using System;
using System.Collections.Generic;
namespace Basic13
{
    public class Program
    {
        public static void print1To255()
        {
            for (int i = 1; i <= 255; i++)
                Console.WriteLine(i);
        }

        public static void print1To255odd()
        {
            for (int i = 1; i <= 255; i += 2)
                Console.WriteLine(i);
        }


        public static void printSum()
        {
            int sum = new int();
            sum = 0;
            for (int i = 1; i <= 255; i++)
            {
                sum += i;
                Console.WriteLine("New Num: {0} Sum: {1}", i, sum);
            }
        }

        public static void iterArr()
        {
            int[] myArray = { 1, 2, 3, 4, 5 };
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void findMax()
        {
            int[] myArray = { 1, 2, 16, 4, 9 };
            int max = myArray[0];
            for (int i = 1; i < myArray.Length; i++)
            {
                if (myArray[i] > max)
                {
                    max = myArray[i];
                }
            }
            Console.WriteLine("Max is:" + max);
        }



        public static void findAvg()
        {
            int[] myArray = { 1, 2, 3, 4 };
            int sum = 0;
            int average = 0;
            for (int i = 0; i < myArray.Length; i++)
            {

                sum += myArray[i];

            }
            average = sum / myArray.Length;
            Console.WriteLine(average);
        }


        public static void arrOdd()
        {
            List<int> templist = new List<int>();
            for (int i = 0; i <= 255; i++)
            {
                if (i % 2 != 0)
                {
                    templist.Add(i);
                }
            }
            int[] y = templist.ToArray();
            Console.Write("[");
            foreach (var item in templist)
            {
                Console.Write(item.ToString());
                if (item != 255)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]");
            Console.WriteLine();
        }


        public static void greaterThanY(int[] myArray, int y)
        {
            int count = 0;
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] > y)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }


        public static void squareValues()
        {
            int[] myArray = { 1, 2, 3, 4 };
            List<int> templist = new List<int>();
            for (int i = 0; i < myArray.Length; i++)
            {
                int temp = myArray[i] * myArray[i];
                templist.Add(temp);
            }
            int[] x = templist.ToArray();
            foreach (var item in templist)
            {
                Console.WriteLine(item);
            }
        }



        // public static void eliminateNegNums()
        // {
        //     int[] negArray = {1,-2,3,-4};
        //     List<int> templist = new List<int>();
        //     for (int i = 0; i < negArray.Length; i++)
        //     {
        //         if(negArray[i] >= 0) {
        //             templist.Add(negArray[i]);
        //         }     
        //     }
        //     int[] x =templist.ToArray();
        //     foreach(var temp in templist)
        //     {
        //     Console.WriteLine(temp);
        //     }
        // }

        public static void MaxMinAvg()
        {
            int[] myArray = { 1, 2, 3, 4 };
            int min = myArray[0];
            int max = myArray[0];
            int sum = myArray[0];
            int avg = 0;

            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] < min)
                {
                    min = myArray[i];
                }
                if (myArray[i] > max)
                {
                    max = myArray[i];
                }
                sum += myArray[i];
            }
            avg = sum / myArray.Length;
            Console.WriteLine("Min: " + min + ", Max: " + max + ", and Avg: " + avg);

        }


        public static void shiftValues()
        {
            int[] myArray = { 1, 2, 3, 4 };
            List<int> templist = new List<int>();
            for (int i = 0; i < myArray.Length -1; i++)
            {
                templist.Add(myArray[i + 1]);
            }
            templist.Add(0);
            foreach (var item in templist)
            {
                Console.WriteLine(item);
            }
        }


           //     public static void numToString();{
    //     int[] negArray = { 1, -2, 3, -4 };
    //     List<string> templist = new List<string>();
    //     for(int i = 0; i<negArray.Length; i++){
    //         if(negArray[i] < 0){
    //             templist.Add("Dojo");
    //         } 
    //         else {
    //             templist.Add(negArray[i].ToString());
    //         }
    //     }
    //     foreach(var item in templist){
    //         Console.WriteLine(item);
    //     }
    //     return templist;
    // }

        static void Main(string[] args)
        {
            shiftValues();
        }
    }
}
