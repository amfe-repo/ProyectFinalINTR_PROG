using System;
using comp;
using System.Collections.Generic;
using static System.Console;

namespace ProjectFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Calculate cl = new Calculate(287000, 48, 16.95);

            List<Amortization> amort = cl.createTable();

            foreach (var item in amort)
            {
               WriteLine($"{item.id}: {(int)item.init_fee} -- {(int)item.fee} -- {(int)item.interest} -- {(int)item.stock} -- {(int)item.balance}"); 
            }

            

        }
    }
}
