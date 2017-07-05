using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PTaskstest {
   class Aquisition {
      public Queue<int> data = null;
      public int _queueSize = 1000;
      public bool IsQueFull { get; set; }
      private int maxIteration;
      private object myLock = new object();
      // 


      public Aquisition() {
         data = new Queue<int>(_queueSize);
         IsQueFull = false;
         maxIteration = 50;
      }


      public void StartAquisition() {
         Task t = new Task(() => {
            int num = 0;
            while (maxIteration-- > 0) {
               lock (myLock) {
                  data.Enqueue(num++);
               }
               Thread.Sleep(300);
            }
            IsQueFull = true;
         });
         // start task;
         t.Start();
      }

      public void getDataAndEmpty() {
         // 
         lock (myLock) {

            var arr = this.data.ToArray();
            foreach (var i in arr) {
               Console.Write("{0}, ", i);
            }
            // empty buffer
            data.Clear();
         }
         Console.WriteLine();
         Thread.Sleep(2000);
      }
   }
}
