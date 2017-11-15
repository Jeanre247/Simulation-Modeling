using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console_Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int profit = 8 - 4;
            double avg = 0.0;

            for (int s = 0; s < 1000; s++)
            {
                avg += simulateMonth() * (profit);
            }// end of for

            avg /= 1000;
            Console.WriteLine(avg);
            Console.ReadLine();
        }

        public static int simulateMonth()
        {
            Random random = new Random();
            int lostClients = 0;
            int reorderPoint = 25;
            int orderSize = 35;
            int stock = 0;
            int receiveDay = -1;
            bool activeOrder = false;

            for (int i = 1; i <= 28; i++)
            {

                // subtract sales...
                stock -= getRandomDemand(random);
                //System.out.println(stock);

                // stock received
                if (i == receiveDay)
                {
                    stock += orderSize;
                    activeOrder = false;
                    receiveDay = -1;
                }// end if

                // lost sales or clients
                if (stock <= 0)
                {
                    lostClients += Math.Abs(stock);
                    stock = 0;
                }// end if

                // reorder stock at reorderPoint of 25
                if (stock <= reorderPoint && !activeOrder)
                {
                    receiveDay = getRandomLeadTime(random) + i;
                    activeOrder = true;
                }// end if

            }// end of for

            return lostClients;
        }// end of simulateMonth

        public static int getRandomDemand(Random r)
        {
            double num = r.NextDouble();

            if (num < 0.261306533)
            {
                return 5;
            }
            else if (num < 0.48241206)
            {
                return 6;
            }
            else if (num < 0.804020101)
            {
                return 7;
            }
            else
            {
                return 8;
            }// end if else
        }// end of getRandomDemand

        public static int getRandomLeadTime(Random r)
        {
            double num = r.NextDouble();

            if (num < 0.285714286)
            {
                return 2;
            }
            else if (num < 0.642857143)
            {
                return 3;
            }
            else
            {
                return 4;
            }// end if else
        }// end of getRandomLeadTime
    }// end of class
}// end of simulation.
