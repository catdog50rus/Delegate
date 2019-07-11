using System;

delegate void AccountStateHandlerMes(string message);
delegate void AccountStateHandler(object sender, AccountEventArgs e);

class MainClass 
{
    public static void Main (string[] args) 
    {
        Account acc = new Account(100);
        acc.Added += Display;
        acc.Withdrawn += Display;
        //acc.Withdrawn += ColorDisplay;
        //acc.RegistredHandler(Display);
        acc.RegistredHandler(ColorDisplay);
        acc.Put(100);
        acc.Withdraw(150);
        //acc.Withdrawn -= ColorDisplay;
        //acc.UnregistredHandler(ColorDisplay);
        acc.Withdraw(100);
    }

    
    static void ColorDisplay(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine (message);
        Console.ResetColor();
    }
    
  
    static void Display(object sender, AccountEventArgs e)
    {
        Console.WriteLine($"Сумма транзакции: {e.Sum}");
        Console.WriteLine(e.Message);
    }
}