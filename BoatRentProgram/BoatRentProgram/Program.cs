using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string val;
            Console.Write("Enter integer: ");
            val = Console.ReadLine();
            string result = AmountOfBoatToRent(val);
            Console.WriteLine(result);
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
        static string AmountOfBoatToRent(string inpuvalue)
        {           
            int seat = Convert.ToInt32(inpuvalue);
            int Tiny = 0;
            int Medium = 0;
            int Large = 0;
            int Cost = 0;
            string rrturnval = "";
            while (seat>0)
            {
                if (seat < 5)
                {
                    Tiny = Tiny + 1;
                    Cost = Cost + 5;
                    seat = 0;
                }
                else if (seat == 5)
                {
                    Tiny = Tiny + 1;
                    Cost = Cost + 5;
                    seat = 0;
                }
                else if (seat >= 10 && seat < 10)
                {
                    Medium = Medium + 1;
                    Cost = Cost + 10;
                    seat = seat - 10;
                }
                else if (seat >= 15)
                {                  
                    Large = Large + 1;
                    Cost = Cost + 15;
                    seat = seat - 15;
                }

            }

            if (Large!=0)
            {
                rrturnval = rrturnval + "Large=" + Large;
            }
            if (Medium != 0)
            {
                rrturnval = rrturnval + "Medium=" + Medium;
            }
            if (Tiny != 0)
            {
                rrturnval = rrturnval + "Tiny=" + Tiny;
            }
            return rrturnval + ",Cost=" + Cost+"$";
        }
       
    }
}
