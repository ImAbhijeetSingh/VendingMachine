using System;
using System.Collections.Generic;
using System.Linq;

namespace Vending_Machine
{
    class Program
    {

        static void Main(string[] args)
        {
            var vendingMachine = new Dictionary<int, int>(){
            {20, 5},
            {10, 10},
            {5, 10},
            {2, 10},
            {1, 10}};

            Console.WriteLine("\n\n                        ============================");
            Console.WriteLine("                        || ABHI's Vending Machine ||");
            Console.WriteLine("                        ============================");
            PrintDictionary(vendingMachine);

            Console.WriteLine(BuyNow(vendingMachine, 2, 25));
            //Your change is 23.
            //20$: 1 piece
            //2$: 1 piece
            //1$: 1 piece
            //Thank you for shopping.

            Console.WriteLine(BuyNow(vendingMachine, 2, -25));  // Invalid Insert money.
            Console.WriteLine(BuyNow(vendingMachine, 2, 0));    // Paid money is not enough.
            Console.WriteLine(BuyNow(vendingMachine, -2, 25));  // Invalid item price.
            Console.WriteLine(BuyNow(vendingMachine, 0, 25));   // Invalid item price.

            Console.WriteLine(BuyNow(vendingMachine, 2, 2));
            // Your change is 0.
            //Thank you for shopping.

            Console.WriteLine(BuyNow(vendingMachine, 2, 130));
            //Your change is 128.
            //20$: 4 piece
            //10$: 4 piece
            //5$: 1 piece
            //2$: 1 piece
            //1$: 1 piece
            //Thank you for shopping.

            Console.WriteLine(BuyNow(vendingMachine, 2, 300));
            //Transaction cancel.
            //Sorry, machine is out of money.
            //Please insert lower amount of money.

            Console.WriteLine(BuyNow(vendingMachine, 2, 30));
            //Your change is 28.
            //10$: 2 piece
            //5$: 1 piece
            //2$: 1 piece
            //1$: 1 piece
            //Thank you for shopping.

            PrintDictionary(vendingMachine);

        }

        static void PrintDictionary(Dictionary<int, int> myDict)
        {
            Console.WriteLine("\n========================== Print vendingMachine ===========================");
            foreach(var item in myDict)
            {
                Console.WriteLine($"{item.Key}$: {item.Value} piece");
            }
        }

        static void updateVendingMachine(Dictionary<int, int> tempDictionary, Dictionary<int, int> vendingMachine)
        {
            for (int i = 0; i < tempDictionary.Count; i++)
            {
                vendingMachine[vendingMachine.ElementAt(i).Key] = tempDictionary.ElementAt(i).Value;
            }
        }

        static string BuyNow(Dictionary<int, int> vendingMachine, int itemPrice, int paidMoney)
        {
            Console.WriteLine($"\n======================== BuyNow(vendingMachine, {itemPrice}, {paidMoney}) ====================");
            Dictionary<int, int> tempDictionary = new Dictionary<int, int>(vendingMachine);
            int moneyToReturn;
            int counter = 0;
            int coinValue;
            string result = "";
            if (itemPrice <= 0)
            {
                return "Invalid item price.";
            }

            if (paidMoney < itemPrice)
            {
                if (paidMoney < 0)
                {
                    return "Invalid Insert money.";
                }
                else
                {
                    return "Paid money is not enough.";
                }
            }
            else
            {
                moneyToReturn = paidMoney - itemPrice;
                result += $"Your change is {moneyToReturn}. \n";
            }

            while (moneyToReturn > 0)
            {
                if(counter >= tempDictionary.Count)
                {
                    return "Transaction cancel. \nSorry, machine is out of money. \nPlease insert lower amount of money.";
                }
                coinValue = tempDictionary.ElementAt(counter).Key;
                int numberOfCoins = moneyToReturn / coinValue;
                if (tempDictionary[coinValue] < numberOfCoins)
                {
                    numberOfCoins = tempDictionary[coinValue];
                }
                if (numberOfCoins > 0)
                {
                    result += coinValue + "$: " + numberOfCoins + " piece \n";
                    tempDictionary[coinValue] = tempDictionary[coinValue] - numberOfCoins;
                }
                moneyToReturn = moneyToReturn - (coinValue * numberOfCoins);
                counter++;
            }

            updateVendingMachine(tempDictionary, vendingMachine);
            result += "Thank you for shopping.";
            return result;
        }
        
    }
}
