using System;
using comp;
using System.Collections.Generic;
using static System.Console;

namespace ProjectFinal
{
    class Program
    {
        static ProjectStructure obj = new ProjectStructure();
        
        static void Main(string[] args)
        {
            obj.init();
            /*Calculate cl = new Calculate(287000, 48, 16.95);

            List<Amortization> amort = cl.createTable();

            foreach (var item in amort)
            {
               WriteLine($"{item.id}: {(int)item.init_fee} -- {(int)item.fee} -- {(int)item.interest} -- {(int)item.stock} -- {(int)item.balance}"); 
            }
            */

            
            //XmlConection xl = new XmlConection();

            //xl.readInfo("1","id", "name");

            //xl.updateInfo("1", "1", "Alfarero", "12345" , "10000", "1");

            //xl.readInfo("1", "name", "money");
            //xl.createInfo("2", "Pepito", "7000", "1");

            //xl.readInfo("", "name", "pass");
            
            
    
        }
    }
}
