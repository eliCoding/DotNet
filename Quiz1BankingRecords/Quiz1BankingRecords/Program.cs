using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1BankingRecords
{
    public class AccountTransaction
    {
        public readonly DateTime Date;
        public readonly string Description;
        public readonly decimal Deposit;
        public readonly decimal Withdrawal;
        public AccountTransaction(string description)
        {
            
                //this.Description = description;
           
           
        }
    }
    class Program
    {
        static List<AccountTransaction> transactionList = new List<AccountTransaction>();

        public bool IsDesciptionInvalid(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                if (text != null &&  text.Length >2)
                {
                    return true;
                }
            }
            return false;
        }
        public static void LoadDataFromFile()
        {
            try
            {
                string[] lineArray = System.IO.File.ReadAllLines(@"..\..\operations.txt");
                foreach (string line in lineArray)
                {
                   

                    string[] a = line.Split(';');
                    DateTime date;
                    
                    try
                    {
                        date = DateTime.Parse(a[0]);
                        String.Format("{0:d/MM/yyyy}", date); 
                        
                    }
                    catch(FormatException f) {
                        Console.WriteLine("" + f.StackTrace);

                    }
                    string description = a[1];
                  //  IsDesciptionInvalid();
                  
                    decimal deposit = decimal.Parse( a[2]);
                    decimal withdwal = decimal.Parse(a[3]);

                    if (deposit <= 0 || withdwal <0)
                    {
                        Console.WriteLine("deposit and withdrawl cant be negetive ");
                        continue;
                    }

                 /*  foreach (string transaction in transactionList)
                    {

                        transactionList.Add();
                    }*/
                 
                    Console.WriteLine(date +";"+ description + ";" + deposit + ";" + withdwal);             
                    
                }

                Console.ReadKey();
            }
            catch (IOException ex)
            {
                Console.WriteLine("There is a problem to open the file." + ex);
            }

        }

      

        static void AddTransaction()
        {
            while (true)
            {
              
                Console.Write("please add  Date: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("please add Student Description: ");
                string description = Console.ReadLine();


                try
                {
                    decimal deposit = decimal.Parse(Console.ReadLine());
                    decimal Withdrawal = decimal.Parse(Console.ReadLine());
                    AccountTransaction a = new AccountTransaction(description);
                    transactionList.Add(a);

                    break;

                }
                catch (FormatException e)
                {
                    Console.WriteLine("FATAL ERROR: " + e.StackTrace);
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                LoadDataFromFile();
            }
            catch (FileFormatException f)
            {
                Console.WriteLine(" ", f.StackTrace);

            }
            AddTransaction();
            /*find the final balance of the account and display it (sum of all deposits minus sum of all withdrawals)*/
            double sum = 0;
            double deposit =0;
            double withdrawl = 0;
            foreach (AccountTransaction a in transactionList)
            {
                sum = deposit - withdrawl; 
            }
           
            Console.WriteLine("Final balance is " + sum);

        }
    }
}
