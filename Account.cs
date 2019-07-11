using System;

class Account
{
    int Sum {get; set;}
    AccountStateHandlerMes Del;
    
    public event AccountStateHandler Added;
    public event AccountStateHandler Adding;
    public event AccountStateHandler Withdrawn;

    
    public void RegistredHandler(AccountStateHandlerMes del)
    {
        Del = del;
    }
/*
    public void UnregistredHandler(AccountStateHandler del)
    {
        Del -= del;
    }
    */


    public Account(int sum)
    {
        Sum = sum;
    }
    public void Put(int sum)
    {
        
        if(Adding != null)
        {
            Adding(this, new AccountEventArgs($"На счет поступает {sum} рублей. ", sum));
        }
        Sum += sum;
        if(Added != null)
        {
            Added(this, new AccountEventArgs($"На счет поступило {sum} рублей. ", sum));
        }
        //Console.WriteLine($"На счет поступило {sum} рублей");
        Acc();
    }

    public void Withdraw(int sum)
    {
        
        if(Sum >= sum)
        {
            Sum -= sum;
            if(Withdrawn != null)
            {
                Withdrawn(this, new AccountEventArgs($"Со счета снято {sum} рублей.", sum));
            }
            //Console.WriteLine($"Со счета снято {sum} рублей");
        }
        else
        {
            if(Withdrawn != null)
            {
                Withdrawn(this, new AccountEventArgs($"На счете недостаточно средств для проведения операции.", sum));
            }
            //Console.WriteLine($"На счете недостаточно средств для проведения операции");
        }
        Acc();
    }

    
    void Acc()
    {
        if(Del != null)
        {
            Del($"Остаток на счете {Sum} рублей");
        }
       // Console.WriteLine($"Остаток на счете {Sum} рублей");
    }
    

}