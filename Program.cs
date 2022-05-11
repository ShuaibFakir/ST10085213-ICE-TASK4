using System;
using System.Collections.Generic;

namespace ST10085213_ICE_Task_4
{
    class Program
    {
        private const int ExitCode = 0;
        private const bool T = true;
        //ICE Task 5 
        static List<Item> Grocery = new List<Item>();
        //ICE Task 5
        static List<Item> BigBox = new List<Item>();
        //ICE Task 5
        static double Total = 0.0;
        //ICE Task 5
        static double totalPriceOfDelivery = 0.0;
        static String Print = "";
        static Metrics metrics = new Metrics();
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 to enter a product or 2 to view metrics ");
            string userOpt = Console.ReadLine();

            if (userOpt.Equals("1"))
            {
                Purchasing();
            }
            else if (userOpt.Equals("2"))
            {
                //Metrics
                metrics.Display();
            }
            else 
            {
                Console.WriteLine("You have entered an invalid option");
            }

            Console.WriteLine("Enter 1 to exit the program"); //Asking user to input number 1 if user wishes to exit program
            int exit = Convert.ToInt32(Console.ReadLine()); //Input will be stored in int variable

            if (exit== 1)  //If exit variable equals 1
            {
                Environment.Exit(ExitCode); //The program would proceed to exit
            } 
            else 
            {
                Total = 0;
                totalPriceOfDelivery = 0;
                Grocery.Clear();
                BigBox.Clear();
            }
            }
        static void GroceryInput()
        {

            Console.WriteLine("Enter the grocery item's"); //Asking user to input names of groceries
            String groceryItem = Console.ReadLine(); //Input stored in string variable
            Console.WriteLine("Enter the price of the grocery items"); //Asking user to input price of each grocery item
            double groceryPrice = Convert.ToDouble(Console.ReadLine()); //Input stored in double variable

            Total += groceryPrice; //Total equals to sum of all 5 prices

            Item gItems = new Item(groceryItem, groceryPrice); //Creation of an instance of Item class
            Grocery.Add(gItems);

            metrics.update("grocery", 1, groceryPrice);
        }
        static void BigBoxInput()
        {

            Console.WriteLine("Enter the big box items"); //Asking user to input names of the big box items
            String bigBoxItem = Console.ReadLine(); //Input stored in string variable
            Console.WriteLine("Enter the price of the big box items"); //Asking user to input price of each big box item
            double bigBoxItemPrice = Convert.ToDouble(Console.ReadLine()); //Input stored in double variable
            Console.WriteLine("Would you like the option of delivery, Please enter Y for Yes or N for No");
            string deliveryOption = Console.ReadLine();

            if (deliveryOption.ToUpper().Equals("Y"))
            {
                Item bbItems = new Item(bigBoxItem, bigBoxItemPrice, Delivery(bigBoxItem, true), WarrantyExpiryDate());
                BigBox.Add(bbItems);
            }
            else
            {
                Item bbItems = new Item(bigBoxItem, bigBoxItemPrice, Delivery(bigBoxItem, false), WarrantyExpiryDate());
                BigBox.Add(bbItems);
            }

            Total += bigBoxItemPrice; //Total equals to sum of all 5 prices

            metrics.update("bigbox", 1, bigBoxItemPrice);

        }
        static string WarrantyExpiryDate()
        {
            int currentYear = System.DateTime.Now.Year;
            int months = System.DateTime.Now.Month;
            int days = System.DateTime.Now.Day;

            currentYear += 1;
            DateTime expiryDate = new DateTime(currentYear, months, days);

            string expiryD = expiryDate.Date.ToString("yyyy-MM-dd");
            return expiryD;
        }
        static double Delivery(string name, bool opt)
        {

            double priceOfDelivery;

            if (opt == true)
            {
                Console.WriteLine("Please enter the price of delivery for " + name);
                priceOfDelivery = Convert.ToDouble(Console.ReadLine());
            }
            else
            {
                priceOfDelivery = 0.0;
            }

            totalPriceOfDelivery += priceOfDelivery;

            return priceOfDelivery;
        }
        static void Purchasing()
        {
            string displaySnip;
            string userOpt;
            bool cont = true;

            try
            {
                while (cont == true)
                {
                    Console.WriteLine("Which of the two categories of products would you like to purchase? Grocery or BigBox, " +
                        "Enter 1 for Grocery or 2 for BigBox");
                    userOpt = Console.ReadLine();

                    if (userOpt.Equals("1"))
                    {
                        GroceryInput();
                    }
                    else if (userOpt.Equals("2"))
                    {
                        BigBoxInput();
                    }
                    else
                    {
                        Console.WriteLine("Category not found");
                    }
                    Console.WriteLine("Would you like to purchase another product? If yes, please enter Y");
                    userOpt = Console.ReadLine();


                    if (!userOpt.ToUpper().Equals("Y"))
                    {
                        cont = false;
                    }

                }
                Cart c = new(Total); //Creation of object of Cart class

                c.Calculations(); //Execution of Calculations method that originates in the Cart class

                for (int i = 0; i < Grocery.Count; i++) //Defining iteration, which permits code to be performed many times,
                                                        //in this case five times
                {
                    Item item = (Item)Grocery[i];
                    Print += item.GetItems() + " R " + item.GetPrice().ToString("F") + "\n";
                }

                for (int i = 0; i < BigBox.Count; i++) //Defining iteration, which permits code to be performed many times,
                                                       //in this case five times
                {
                    Item item = (Item)BigBox[i];
                    Print += item.GetItems() + " R " + item.GetPrice().ToString("F") +
                        "The price of delivery is: " + item.Delivery + " and the date that the warranty expires is: " + item.Date + "\n";
                }

                c.Print(Print); //Execution of Print method which originates in the Cart class
            }
            catch (FormatException)
            {
                Console.WriteLine("You have entered an incorrect format");
            }
        }
    }
}