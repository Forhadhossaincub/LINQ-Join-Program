using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Join_Program
{
    class Program
    {
        class Item{
            public string Name { get; set; }
            public int ItemNumber { get; set; }
            
            public Item(string n, int inum){
                Name = n;
                ItemNumber = inum;
            }
        }

        class InStockStatus {
            public int ItemNumber { get; set; }
            public bool InStock { get; set; }
            public InStockStatus(int n, bool iS){
                ItemNumber = n;
                InStock = iS;
            }
        }

        class Temp
        {
            public string Name { get; set; }
            public bool InStock { get; set; }
            public Temp(string n, bool IS){
                Name= n;
                InStock= IS; 
            }
        }

        static void Main(string[] args)
        {
            Item[] items= {     
                new Item("Pliers", 1424),
                new Item("Hammer", 7892),
                new Item("Wrench", 8534),
                new Item("Saw", 6411)
            };

            InStockStatus[] statusList = {
                new InStockStatus(1424, true),
                new InStockStatus(7892, false),
                new InStockStatus(8534, true),
                new InStockStatus(6411, true),           
            };

            // Create a query that joins Item with InStocksStatus to 
            // produce a list of item names and availability. Noteice
            // that a sequence of Temp object is produced.

            var inStockList = from item in items
                              join sL in statusList
                              on   item.ItemNumber equals sL.ItemNumber
                              select new Temp(item.Name, sL.InStock);

            Console.WriteLine("Item \tAvalable\n ");

            // Display result 

            foreach(Temp t in inStockList)
            {
                Console.WriteLine($"{t.Name},{t.InStock}");
            }

            Console.ReadKey();
    
        }
    }
}
