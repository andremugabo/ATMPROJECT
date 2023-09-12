using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleATM
{
    public class CardHolder
    {
        private String cardNumber;
        private int pin;
        private String fullNames;
        private double balance;
        private String currency;

        public CardHolder(String cardNo, int pin, String fullNames, double balance, String currency)
        {
            this.cardNumber = cardNo;
            this.pin = pin;
            this.fullNames = fullNames;
            this.balance = balance;
            this.currency = currency;
        }

        // Getters
        public String getCardNumber() { return cardNumber; }
        public int getPin() { return pin; }
        public String getFullNames() { return fullNames; }
        public double getBalance() { return balance; }
        public String getCurrency() { return currency; }

        //Setters
        public void setCardNumber(String newCardNo) { cardNumber = newCardNo; }
        public void setPin(int newPin) { pin = newPin; }
        public void setFirstName(String newFullNames) { fullNames = newFullNames; }
        public void setBalance(double newBal) { balance = newBal; }
        public void setCurrency(String newCurrency) { currency = newCurrency; }
        // Caller function: It is used to call other functions
        static void Main(string[] args)
        {
            List<CardHolder> listOfClients = new List<CardHolder>();
            listOfClients.Add(new CardHolder("4008010", 1234, "Sonia Gasaro", 150000, "Rwf"));
            listOfClients.Add(new CardHolder("4008011", 4321, "Erick Gwiza", 150000, "Rwf"));
            listOfClients.Add(new CardHolder("4008012", 1243, "Beshaho", 500000, "USD"));
            listOfClients.Add(new CardHolder("4008013", 1432, "Munezero Ange", 40000, "Rwf"));
            listOfClients.Add(new CardHolder("4008014", 1423, "Thierry Mugisha", 5000000, "Rwf"));

            // Prompt the user to execute the system
            Console.WriteLine("Welcome to Tuesday Class ATM");
            Console.WriteLine("Please enter the digits on your card");
            String enteredCardNo = "";
            int enteredPin = 0;
            CardHolder currentCustomer;

            //Check against the given cardNumber
            while (true)
            {
                try
                {
                    enteredCardNo = Console.ReadLine();
                    //Check if the entered card number is in our list
                    currentCustomer = listOfClients.FirstOrDefault(client => client.cardNumber == enteredCardNo);
                    if (currentCustomer != null)
                    {
                        break;
                    }
                    else { Console.WriteLine("Card not found!!!"); }

                }
                catch { Console.WriteLine("Card not found!!!"); }
            }

            // Check against the given card PIN
            Console.WriteLine("Please enter your PIN");
            while (true)
            {
                try
                {
                    enteredPin = int.Parse(Console.ReadLine());
                    if (enteredPin == currentCustomer.getPin())
                    {
                        break;
                    }
                    else { Console.WriteLine("Pin not Correct!!!"); }

                }
                catch { Console.WriteLine("PIN not correct!!!"); }
            }

            Console.WriteLine("Welcome Dear " + currentCustomer.getFullNames());
            int option = 0;
            do
            {
                printOptions();
                option = int.Parse(Console.ReadLine());
                if (option == 1) { deposit(currentCustomer); }
                else if (option == 2) { withdraw(currentCustomer); }
                else if (option == 3) { checkBalance(currentCustomer); }
                else if (option == 4) { Console.WriteLine("Your current currency is "+checkCurrency(currentCustomer)); }
                else if (option == 5)
                {
                    Console.WriteLine("Thanks for using our service, Say Hi to Ur Sister");
                    Console.WriteLine("Press any key if U will say Hi to Her");
                    Console.ReadKey();
                    break;
                }
                else { option = 0; }

            } while (option != 5);

        }

        static void printOptions()
        {
            Console.WriteLine("Please choose from the options below:");
            Console.WriteLine("1. To deposit");
            Console.WriteLine("2. To withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Check the currency");
            Console.WriteLine("5. Exit");
        }
        static void deposit(CardHolder cardHolder)
        {
            Console.WriteLine("Specify you Currency");
            String specifiedCurr = Console.ReadLine();
            if (specifiedCurr.Equals(cardHolder.getCurrency()))
            {
                Console.WriteLine("How much do you want to deposit");
                double depositAm = Double.Parse(Console.ReadLine());
                cardHolder.setBalance(depositAm + cardHolder.getBalance());
                Console.WriteLine(depositAm +
                    " Deposited with success, Your new Balance is: "
                    + cardHolder.getBalance());
            }
            else
            {
                Console.WriteLine("Your specified currency is different from the currency in the system, Please try again later");
            }

        }
        static void withdraw(CardHolder cardHolder)
        {
            Console.WriteLine("How much do you want to withdraw");
            double withdrawAm = Double.Parse(Console.ReadLine());
            if (withdrawAm > cardHolder.getBalance())
            {
                Console.WriteLine("Insufficient Amount, Try again!!");
            }
            else
            {
                cardHolder.setBalance(cardHolder.getBalance() - withdrawAm);
                Console.WriteLine(withdrawAm +
                    " withdrawn with success, Your new Balance is: "
                    + cardHolder.getBalance());
            }
        }
        static void checkBalance(CardHolder cardHolder)
        {
            Console.WriteLine("Your balance is: " + cardHolder.getBalance());
        }

        static String checkCurrency(CardHolder cardHolder)
        {
            string currentyCurency = cardHolder.getCurrency();
            return currentyCurency;
        }


    }

}