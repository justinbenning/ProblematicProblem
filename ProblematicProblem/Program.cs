using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Problematic
    {
        Random rng;
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Random rng = new Random();
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            bool cont = false;
            string userInput;
            do
            {
                userInput = Console.ReadLine().ToLower();
            
                if(userInput == "yes")
            {
                cont = true;
            }
            else if(userInput == "no")
            {
                    Console.WriteLine("Please come again");
                    Environment.Exit(0);                  
            }
            else
            {
                Console.WriteLine("Please try again.");
            }
            } while(userInput != "yes" && userInput != "no");
            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge;
            bool userAgeInput;
            do
            {
                userAgeInput = int.TryParse(Console.ReadLine(), out userAge);
                if (userAgeInput == false)
                {
                    Console.WriteLine("That is not a numeric value, please try again.");
                }
            } while (userAgeInput == false);
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            bool seeList = false;
            do
            {
                userInput = Console.ReadLine().ToLower();
                if (userInput == "sure")
                {
                    seeList = true;
                }
                else if (userInput == "no thanks")
                {
                    seeList = false;
                }
                else
                {
                    Console.WriteLine("Invalid response, please try again.");
                }
            } while (userInput != "sure" && userInput != "no thanks");
            
            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                userInput = Console.ReadLine().ToLower();
                bool addToList = false;
                if (userInput == "yes")
                {
                    addToList = true;
                }
                else if (userInput == "no")
                {
                    addToList = false;
                }
                else
                {
                    Console.WriteLine("Invalid response, moving on.");
                }
                Console.WriteLine();
                while (addToList == true)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(50);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    userAddition = Console.ReadLine().ToLower();
                    addToList = false;
                    if (userAddition == "yes")
                    {
                        addToList = true;
                    }
                    else if (userAddition == "no")
                    {
                        addToList = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid response, moving on.");
                         addToList = false;
                    }

                }
            }

            while (cont)
            {
                bool terminate = false;
                do
                {
                    
                    string randomActivity;
                    
                        Console.Write("Connecting to the database");
                        for (int i = 0; i < 10; i++)
                        {
                            Console.Write(". ");
                            Thread.Sleep(50);
                        }
                        Console.WriteLine();
                        Console.Write("Choosing your random activity");
                        for (int i = 0; i < 9; i++)
                        {
                            Console.Write(". ");
                            Thread.Sleep(50);
                        }
                        Console.WriteLine();
                        int randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                    //randomActivity = "Wine Tasting";

                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Picking something else!");
                    }
                    do
                    {   activities.Remove(randomActivity);
                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];

                    } while (randomActivity == "Wine Tasting");

                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    
                    do
                    {
                        userInput = Console.ReadLine().ToLower();
                        if (userInput == "keep")
                        {
                            terminate = true;
                        }
                        else if (userInput == "redo")
                        {
                            terminate = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again.");
                        }
                    } while (userInput != "keep" && userInput != "redo");
                } while (terminate = false);
            }
        }
    }
}
