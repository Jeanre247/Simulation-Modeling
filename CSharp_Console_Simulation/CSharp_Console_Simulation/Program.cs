using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console_Simulation
{
    class Program
    {
        private int reorderPoint = 25;
        private int orderSize = 35;
        public Random random;


        public Program(Random random)
        {
            this.random = random;
        }// end of constructer

        static void Main(string[] args)
        {
            Random random = new Random();
            Program main = new Program(random);
            int profit = 8 - 4;
            double avg = 0.0;

            for (int s = 0; s < 1000; s++)
            {
                avg += main.simulateMonth() * (profit);
            }// end of for

            avg /= 1000;
            Console.WriteLine(avg);
            Console.ReadLine();
        }

        public int simulateMonth()
        {
            int receiveDay = -1;
            int stock = 0;
            int lostClients = 0;
            bool activeOrder = false;

            for (int i = 1; i <= 28; i++)
            {

                // subtract sales...
                int demand = this.getRandomDemand();
                stock -= demand;

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
                    receiveDay = getRandomLeadTime() + i;
                    activeOrder = true;
                }// end if

            }// end of for

            return lostClients;
        }// end of simulateMonth

        public int getRandomDemand()
        {
            double r = random.NextDouble();

            if (r < 0.261306533)
            {
                return 5;
            }
            else if (r < 0.48241206)
            {
                return 6;
            }
            else if (r < 0.804020101)
            {
                return 7;
            }
            else
            {
                return 8;
            }// end if else
        }// end of getRandomDemand

        public int getRandomLeadTime()
        {
            double r = random.NextDouble();

            if (r < 0.285714286)
            {
                return 2;
            }
            else if (r < 0.642857143)
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
