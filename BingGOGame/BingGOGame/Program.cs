using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingGOGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] bingorow = new int[5]; // Correct me if I'm wrong but I think a 7 number bingo should accept 7 numbers as input
            string[] positions = { "first", "second", "third", "fourth", "fifth", "sixth", "seventh" }; // This is not necessary, but makes the flow slightly clearer.

            Console.WriteLine("#########################");
            Console.WriteLine("Welcome to C Sharp Bingo!");
            Console.WriteLine("#########################");
            Console.WriteLine("Please provide your 7 numbers in the range from 1 to 25.");

            for (int i = 0; i < bingorow.Length; i++)
            {
                try
                {
                    Console.WriteLine("Enter your {0} number:", positions[i]);
                    int bingonr = int.Parse(Console.ReadLine());
                    bingorow[i] = bingonr;
                }

                catch
                {
                    Console.WriteLine("Some error message.");
                    // Some Exception should be thrown here don't just use "continue".
                    continue;
                }
            }         
                Console.WriteLine();           
                Console.Write("\nCheckResult Enter...");
                Console.ReadKey();

            string[,] table = new string[5, 5];
           var tablevalue = FillCard(table);

            DisplayBingoCard(table);
            string CheckbingoResult = Checkbingo(tablevalue,bingorow);

            Console.Write("\nInput =[{0}]", string.Join(",", bingorow));
            Console.Write("\nOutput ={0}", CheckbingoResult);
            Console.Write("\nPress any key to exit...");
            Console.ReadKey();
        }

        private static string Checkbingo(int[,] tablevalue, int[] bingorow)
        {
            bool isEqual =false;
            int[] thisrow = new int[5];
            //row check
            for (int row = 0; row < 5; row++)
            {
              
                for (int i = 0; i < bingorow.Length; i++)
                {
                    int bingonr = tablevalue[row,i];
                    thisrow[i] = bingonr;
                }

                 isEqual = Enumerable.SequenceEqual(thisrow, bingorow);

               
            }
            //col check
            for (int row = 0; row < 5; row++)
            {
               
                for (int i = 0; i < bingorow.Length; i++)
                {
                    int bingonr = tablevalue[i, row];
                    thisrow[i] = bingonr;
                }

                isEqual = Enumerable.SequenceEqual(thisrow, bingorow);
            }

            //special check
            for (int row = 0; row < 5; row++)
            {
              
                int bingonr = tablevalue[row, row];
                thisrow[row] = bingonr;
            }
            isEqual = Enumerable.SequenceEqual(thisrow, bingorow);
            for (int row = 5; row < 0; row--)
            {
                int bingonr = tablevalue[row, row];
                thisrow[row] = bingonr;
            }
            isEqual = Enumerable.SequenceEqual(thisrow, bingorow);



            if (isEqual)
            {
                return "Bing Go";
            }
            else
            {
                return "Not Bing Go";
            }
            return "Not Bing Go";
        }
     
        private static readonly Random Rnd = new Random();
        static int[,] FillCard(string[,] table)
        {
            var BValues = Enumerable.Range(1, 25).ToList();
            int[,] revalue = new int[5,5];
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    switch (col)
                    {
                        case 0: // B
                            table[row, col] = GetRandomItemAndRemoveIt(BValues);
                            revalue[row, col] =int.Parse(table[row, col]);
                            break;
                        case 1: // I
                            table[row, col] = GetRandomItemAndRemoveIt(BValues);
                            revalue[row, col] = int.Parse(table[row, col]);
                            break;
                        case 2: // N
                            table[row, col] = GetRandomItemAndRemoveIt(BValues);
                            revalue[row, col] = int.Parse(table[row, col]);
                            break;
                        case 3: // G
                            table[row, col] = GetRandomItemAndRemoveIt(BValues);
                            revalue[row, col] = int.Parse(table[row, col]);
                            break;
                        case 4: // O
                            table[row, col] = GetRandomItemAndRemoveIt(BValues);
                            revalue[row, col] = int.Parse(table[row, col]);
                            break;
                    }
                }
            }
            return revalue;

        }



        private static string GetRandomItemAndRemoveIt(IList<int> items)
        {
            if (items == null || items.Count == 0) return string.Empty;

            var randomItem = items[Rnd.Next(items.Count)];
            items.Remove(randomItem);

            // The PadRight method will ensure each string is at least two characters wide
            return randomItem.ToString().PadRight(2, ' ');
        }
        public static void DisplayBingoCard(string[,] values)
        {
            Console.WriteLine();
            Console.WriteLine("╔════╦════╦════╦════╦════╗");
         
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Console.Write("║ " + values[row, col] + " ");
                }

                Console.WriteLine("║");

                if (row < 4)
                {
                    Console.WriteLine("╠════╬════╬════╬════╬════╣");
                }
                else
                {
                    Console.WriteLine("╚════╩════╩════╩════╩════╝");
                }
            }
        }
      
    }
}
