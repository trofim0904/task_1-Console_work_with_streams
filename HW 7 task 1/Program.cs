using System;
using System.Threading;

namespace HW_7_task_1
{
    class Paydesk
    {
        public bool is_working = true;
        public int orders = 0;
        public void End_work_or_not()
        {
            Random random = new Random();
            
            
                if (random.Next(0, 101) <= 30 )
                {
                    is_working = false;
                    Console.WriteLine("End");
                }
            
        }
        public void Order(string name)
        {
               if (is_working)
                {
                    Thread.Sleep(3000);
                    orders++;
                    Console.WriteLine("Accept order from " + name + "; Orders: " + orders);
                    End_work_or_not();
                }
            
        }
    }
    class Customer
    {
        public string name;
        public int orders = 0;
        public Paydesk paydesk;
        public Customer(string name,Paydesk paydesk)
        {
            this.name = name;
            this.paydesk = paydesk;
            new Thread(Method).Start();
        }
        public void Method()
        {
           
            while (paydesk.is_working)
            {
                lock (paydesk)
                {
                    paydesk.Order(name);
                    
                }
            }
          
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Paydesk paydesk = new Paydesk();

            new Customer("A", paydesk);
            new Customer("B", paydesk);
            new Customer("C", paydesk);
            new Customer("D", paydesk);
            new Customer("E", paydesk);

            Console.ReadKey();
        }
    }
}
