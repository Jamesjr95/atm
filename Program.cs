using System;
using System.Collections.Generic;
using System.Linq;
public class cardHolder 
{
// declaring a variable without assigning the value, so we can assign a value later
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

// constructor method, this dictates what our cardHolder object will be instantiated with
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {

        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
        {
            return cardNum;
        }
    
    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFistName(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(String newLastName)
    {
        firstName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

// main is the function that gets run when the code executes
// void means that the function returns nothing
    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit + currentUser.getBalance());
            Console.WriteLine("Thank you for your $$. your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw? ");
            double withdrawal = Double.Parse(Console.ReadLine());
            // checking if the user has enough money
            if(currentUser.getBalance() > withdrawal)
            {
                Console.WriteLine("Insufficient balance :<");
            }
            else
            {
            currentUser.setBalance(currentUser.getBalance() - withdrawal);
            Console.WriteLine("You're withdrawal was succesfful! Thank you :)");
            }

        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4929061547213340", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new cardHolder("4929337367944739", 4321, "Ashley", "Jones", 321.13));
        cardHolders.Add(new cardHolder("4916603356388500", 9999, "Frida", "Dickerson", 105.59));
        cardHolders.Add(new cardHolder("4539298605348442", 2468, "Manuel", "Harding", 700.65));
        cardHolders.Add(new cardHolder("4539213885570995", 4826, "Jane", "Smith", 50.20));

        // prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // check against db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) {break;}
                else {Console.WriteLine("Card not recognized. Please try again");}
            }
            catch {Console.WriteLine("Card not recognized. Please try again");}
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while(true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // check against db
                if(currentUser.getPin() == userPin) {break;}
                else {Console.WriteLine("Incorrect pin. Please try again");}
            }
            catch {Console.WriteLine("Incorrect pin. Please try again");}
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + "!");
        int option = 0;
        //  do is similiar to a while loop, in that it executes the code block while a boolean is true
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch {}
            if(option == 1) {deposit(currentUser);}
            else if(option == 2) {withdraw(currentUser);}
            else if(option == 3) {balance(currentUser);}
            else if(option == 4) {break;}
            else {option = 0;}


        }   
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day.");
    }

}
