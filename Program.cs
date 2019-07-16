using System;
using System.Collections.Generic;
using System.Linq;

namespace millionairesClub
{
    class Program
    {
        static void Main(string[] args)
        {
        // Build a collection of customers who are millionaires
            
            
                    List<Customer> customers = new List<Customer>() {
                        new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                        new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                        new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                        new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                        new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                        new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                        new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                        new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                        new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                        new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
                };
                    IEnumerable<Customer> MillionairesClub = customers.Where(customer => customer.Balance >= 1000000);
                    Console.WriteLine("Millionaire's Club");
                        foreach (Customer c in MillionairesClub){
                        Console.WriteLine($"{c.Name} has a balance of {c.Balance}");
                  }
                /*
                Given the same customer set, display how many millionaires per bank.
                Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

                Example Output:
                WF 2
                BOA 1
                FTB 1
                CITI 1
            */

                // IEnumerable<IGrouping<String,Customer>> MillionairesPerBank = MillionairesClub.GroupBy(customer => customer.Bank);

                IEnumerable<IGrouping<String,Customer>> MillionairesPerBank = from millionaire in MillionairesClub
                group millionaire by millionaire.Bank into bankGroup
                select bankGroup;

                foreach (IGrouping<String, Customer> m in MillionairesPerBank){
                    Console.WriteLine($"{m.Key} {m.Count()}");
                }

             // Create some banks and store in a List
        List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };

        
        

        /*
            You will need to use the `Where()`
            and `Select()` methods to generate
            instances of the following class.

            
        */
        List<ReportItem> millionaireReport = (from customer in customers
            join bank in banks on customer.Bank equals bank.Symbol
            where customer.Balance >= 1000000
            orderby customer.Name.Split()[1]
            select new ReportItem {
                CustomerName = customer.Name,
                BankName = bank.Name}).ToList();

        Console.WriteLine("MILLIONAIRE REPORT:");

        foreach (var item in millionaireReport)
        {
            Console.WriteLine($"{item.CustomerName} at {item.BankName}");
        }
        }
    }
}
