using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your number:");
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

            Random random = new Random();
            int Gnum = random.Next(1, 11);
            int guess;
            int attempts = 0;
            Console.WriteLine("Number Guessing Game!");
            do
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
        }
    }
}
