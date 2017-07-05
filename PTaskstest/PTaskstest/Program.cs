using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTaskstest {
   class Program {
      static void Main(string[] args) {
         Aquisition aq = new Aquisition();

         // start aquisition 
         aq.StartAquisition();

         Console.WriteLine("Value found in the buffer");
         while (!aq.IsQueFull) {
            aq.getDataAndEmpty();
         }
      }
   }
}
