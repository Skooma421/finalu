using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalu
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //studentebi
            StudentManager manager = new StudentManager();
            int menu;
            do
            {
                Console.WriteLine("1.Add a new student");
                Console.WriteLine("2.View all students");
                Console.WriteLine("3.Search by roll number");
                Console.WriteLine("4.Update student's grade");
                Console.WriteLine("5.Exit");
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Enter student's name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter student's roll number:");
                        int rollNum = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter student's grade:");
                        char grade = char.Parse(Console.ReadLine());
                        manager.AddStudent(name, rollNum, grade);
                        Console.WriteLine("Student added");
                        break;
                    case 2:
                        manager.viewAllStud();
                        break;
                    case 3:
                        Console.WriteLine("Enter roll number:");
                        int searchRollNum = int.Parse(Console.ReadLine());
                        manager.SearchRoll(searchRollNum);
                        break;
                    case 4:
                        Console.WriteLine("Enter students roll number:");
                        int updateRollNum = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new grade");
                        char newGrade = char.Parse(Console.ReadLine());
                        manager.UpdateGrade(updateRollNum, newGrade);
                        break;
                    case 5:
                        Console.WriteLine("Exitinig program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            } while (menu != 5);
            

            /*
            bookManager manager = new bookManager();
            manager.AddBook("Catcher in the Rye", "J.D. Salinger", "July 16, 1951");
            manager.ShowBooks();
            string searchTitle = "Catcher in the Rye";
            Book foundBook = manager.SearchByBook(searchTitle);
            if (foundBook != null)
            {
                Console.WriteLine($"Book found: {foundBook}");//wignis povnis shemtxveva
            }
            else
            {
                Console.WriteLine($"Book with title '{searchTitle}' not found.");//wignis ver povnis shemtxveva
            }
            */
            /*
            //martivi kalkulatori switchit
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
                    if (num2 != 0)
                    {
                        Console.WriteLine(num / num2);
                    }
                    else
                    {
                        Console.WriteLine("Can not divide by zero");
                    }
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
            }*/
            
            //hangman
            string[] words = { "hello", "goodbye", "horse", "car", "pillow" };
            Random random1 = new Random();
            string wordToGuess = words[random1.Next(words.Length)];
            char[] hiddenWord = new char[wordToGuess.Length];
            int attempts1 = 5;

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                hiddenWord[i] = '_';//vshifravt sityvis sigrdzis mixedvit
            }
            Console.WriteLine("Hangman game");
            Console.WriteLine("Guess the word:");

            while (attempts1 > 0 && new string(hiddenWord) != wordToGuess)
            {
                Console.WriteLine("Word: " + string.Join(" ", hiddenWord));//vbechdavt damalul sityvas
                Console.WriteLine("Attempts left: " + attempts1);
                Console.Write("Enter a letter: ");
                char letter = char.Parse(Console.ReadLine());

                bool letterFound = false;
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == letter)
                    {
                        hiddenWord[i] = letter;
                        letterFound = true;
                    }
                }

                if (!letterFound)
                {
                    attempts1--;
                    Console.WriteLine("Incorrect guess!");
                }
                else
                {
                    Console.WriteLine("Correct guess!");
                }
            }

            if (new string(hiddenWord) == wordToGuess)
            {
                Console.WriteLine("You guessed the word: " + wordToGuess);
            }
            else
            {
                Console.WriteLine("You ran out of attempts. The word was: " + wordToGuess);
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
            //vqmni direqtorias rom shevinaxo aqauntebis filebi desktopze
            String directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ATM";
            Directory.CreateDirectory(directoryPath);

            AddAccount("123456", "Nino", 522, directoryPath);//xelit vamatebt aqaunts

            Console.Write("Enter your account number: ");
            String accountNum = Console.ReadLine();
            //es aris path account failis
            string accountFile = Path.Combine(directoryPath, $"{accountNum}.txt");
            //vamowmebt arsebobs tu ara aqauntis faili
            if (!File.Exists(accountFile))
            {
                Console.WriteLine("Account not found.");
                return;
            }
            Console.WriteLine("1.Check balance");//aq vwert operaciebs useristvis
            Console.WriteLine("2.Deposit");
            Console.WriteLine("3.Withdraw");
            Console.WriteLine("4.Exit");
            Console.WriteLine("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)//switchi momxmareblis archevanze 
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
                case "4":
                    Console.WriteLine("Exiting program.");
                    break;
                default: Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        //metodebi
        //aqauntis damatebis metodi
        static void AddAccount(string accountNumber, string accountName, decimal balance, string directoryPath)
        {
            //path aqauntis failis
            string accountFile = Path.Combine(directoryPath, $"{accountNumber}.txt");
            //aq vinaxavt usertis informacias failshi
            using (StreamWriter writer = new StreamWriter(accountFile))
            {
                writer.WriteLine(accountNumber);
                writer.WriteLine(balance);
            }
        }
        //balansis naxvis metodi
        static void CheckBalance (string accountFile)
        {
            string balance = File.ReadAllText(accountFile);//vkitxulobt balanss
            Console.WriteLine($"Your current balance: {balance}");            
        }
        //depozitis metodi
        static void Deposit (string accountFile) 
        {
            Console.Write("Enter Deposit amount: ");
            string depositAmount = Console.ReadLine();
            //amjamindeli balansis wakitxva
            decimal currentBal= decimal.Parse(File.ReadAllText(accountFile));
            decimal newBal = currentBal + decimal.Parse(depositAmount);//aq vumatebs arsebul tanxas axal depozits
            //vwert axal balanss
            File.WriteAllText(accountFile,newBal.ToString());
            Console.WriteLine("Deposit finished.");
        }
        //fulis gamotanis metodi
        static void Withdraw(string accountFile)
        {
            Console.WriteLine("Enter widhtrawl amount: ");
            string withAmount = Console.ReadLine(); 
            //vnaxulobt amjamindel tanxas
            decimal currentBal = decimal.Parse(File.ReadAllText(accountFile));
            //useris mier sheyvanili tanxis parse xdeba aq
            decimal withdrawl = decimal.Parse(withAmount);
            //vamowmebt tu aris sakmarisi tanxa aqauntze
            if(withdrawl > currentBal)
            {
                Console.WriteLine("Not enought balance to withdraw");
                return;
            }
            decimal newBal = currentBal - withdrawl;//gamotvla

            File.WriteAllText (accountFile,newBal.ToString());
            Console.WriteLine("Withdrawl finished."); 
        }
        

    }
}
