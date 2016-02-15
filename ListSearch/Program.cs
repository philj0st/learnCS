using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customerList = new List<Customer>();

            Customer cst1 = new Customer();
            cst1.ID = 2;
            cst1.Name = "First Customer";

            Customer cst2 = new Customer();
            cst2.ID = 4;
            cst2.Name = "Second Customer";

            //syntactic sugar? :D
            Customer cst3 = new Customer { ID = 12, Name = "Third Customer" };

            customerList.Add(cst1);
            customerList.Add(cst2);
            customerList.Add(cst3);

            //Customer result = cstLst.Find(x => x.ID == 4);
            int[] idList = new int[5] { 1, 2, 3, 4, 5 };

            //using a named function to see whether a customer matches a self described pattern
            //List<Customer> results = customerList.FindAll(c => customerInList(c, idList));

            //using lambda function to achieve the same as commented out above
            List<Customer> results = customerList.FindAll(c => idList.Contains(c.ID));

            //print all names of the customers whose id was in idList
            foreach (Customer c in results)
            {
                Console.WriteLine(c.Name);
            }

            //achieving something like SELECT * FROM Message WHERE CustomerID = x AND SupplierID = y
            //but searching with an object reference
            Supplier sup1 = new Supplier { ID = 1, Name = "First Supplier" };
            Supplier sup2 = new Supplier { ID = 2, Name = "Second Supplier" };

            List<Message> messages = new List<Message>();
            messages.Add(new Message { ID = 1, Customer = cst1, Supplier = sup1, Text = "Hello First Supplier, this is First Customer" });
            messages.Add(new Message { ID = 2, Customer = cst1, Supplier = sup2, Text = "Hello Second Supplier, this is First Customer" });
            messages.Add(new Message { ID = 3, Customer = cst3, Supplier = sup2, Text = "Hello Second Supplier, this is Third Customer" });

            //get all messages to display to the Second Supplier
            List<Message> msgsForSup2 = messages.FindAll(m => m.Supplier == sup2);
            foreach (Message msg in msgsForSup2)
            {
                Console.WriteLine(msg.Customer.Name + " writes to " + msg.Supplier.Name + ": " + msg.Text);
            }

            //a more specific search
            Message specificMsg = messages.Find(m => m.Customer == cst1 && m.Supplier == sup2);
            Console.WriteLine("specific message: " + specificMsg.Text);

            Console.ReadKey();
        }

        //named search function no longer needed. got replaced with lambda func
        //private static bool customerInList(Customer cst, int[] idList) {
        //    if (idList.Contains(cst.ID))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }

    class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    class Message
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }
        public Supplier Supplier { get; set; }
        public string Text { get; set; }
    }
}