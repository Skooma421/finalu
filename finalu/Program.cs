using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalu
{
    internal class Program
    {
        static void Main(string[] args)
        {   //martivi kalkulatori switchit
            Console.WriteLine("Enter your number:");//users sheyavs monacemebi
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your second number");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the operator");
            string calc = Console.ReadLine();
            switch (calc)
            {
                case "+":
                    Console.WriteLine(num+num2); 
                    break;
                case "-": 
                    Console.WriteLine(num-num2);
                    break;
                case "/":
                    Console.WriteLine(num / num2);
                    break;
                case "*":
                    Console.WriteLine(num * num2);
                    break;
                case "%":
                    Console.WriteLine(num % num2);
                    break;
                default:
                    Console.WriteLine("Invalid operator");
                    break;
            }
            //ricxvis gamosacnobi tamashi
            Random random = new Random();//viyenebt rands rom davagenerirot ertidan atis chatvlit ricxvebi
            int Gnum = random.Next(1, 11);
            int guess;
            int attempts = 0;
            Console.WriteLine("Number Guessing Game!");
            do//loopi
            {
                Console.WriteLine("Enter a number from one to ten");
                guess = int.Parse(Console.ReadLine());
                attempts++;

                if (guess < Gnum)
                    Console.WriteLine("Number too low, try again!");
                else if (guess > Gnum)
                    Console.WriteLine("Number too High, try again!");
            }
            while (guess!= Gnum);
            Console.WriteLine($"You guessed the number {Gnum} correctly");

            //ATM aplikacia
            String directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ATM";
            Directory.CreateDirectory(directoryPath);

            AddAccount("123456", "Nino", 522, directoryPath);

            Console.Write("Enter your account number: ");
            String accountNum = Console.ReadLine();

            string accountFile = Path.Combine(directoryPath, $"{accountNum}.txt");
            if (!File.Exists(accountFile))
            {
                Console.WriteLine("Account not found.");
                return;
            }
            Console.WriteLine("1.Check balance");
            Console.WriteLine("2.Deposit");
            Console.WriteLine("3.Withdraw");
            Console.WriteLine("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CheckBalance(accountFile); 
                    break;
                case "2":       
                    Deposit(accountFile); 
                    break;
                case "3":
                    Withdraw(accountFile); 
                    break;
                    default: Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        static void AddAccount(string accountNumber, string accountName, decimal balance, string directoryPath)
        {
            string accountFile = Path.Combine(directoryPath, $"{accountNumber}.txt");

            using (StreamWriter writer = new StreamWriter(accountFile))
            {
                writer.WriteLine(accountNumber);
                writer.WriteLine(balance);
            }
        }
        static void CheckBalance (string accountFile)
        {
            string balance = File.ReadAllText(accountFile);
            Console.WriteLine($"Your current balance: {balance}");            
        }
        static void Deposit (string accountFile) 
        {
            Console.Write("Enter Deposit amount: ");
            string depositAmount = Console.ReadLine();

            decimal currentBal= decimal.Parse(File.ReadAllText(accountFile));
            decimal newBal = currentBal + decimal.Parse(depositAmount);//aq vumatebs arsebul tanxas axal depozits
            
            File.WriteAllText(accountFile,newBal.ToString());
            Console.WriteLine("Deposit finished.");
        }
        static void Withdraw(string accountFile)
        {
            Console.WriteLine("Enter widhtrawl amount: ");
            string withAmount = Console.ReadLine(); 

            decimal currentBal = decimal.Parse(File.ReadAllText(accountFile));

            decimal withdrawl = decimal.Parse(withAmount);
            if(withdrawl > currentBal)
            {
                Console.WriteLine("Not enought balance to withdraw");
                return;
            }
            decimal newBal = currentBal - withdrawl;

            File.WriteAllText (accountFile,newBal.ToString());
            Console.WriteLine("Withdrawl finished."); 
        }
    }
}
