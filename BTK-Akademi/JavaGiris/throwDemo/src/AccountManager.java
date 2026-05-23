public class AccountManager {
    private double balance;

    public void Deposit(double amount)
    {
        balance = getBalance() + amount;
    }

    public void Withdraw(double amount) throws BalanceInsufficientException {
        if(balance>=amount)
            balance = getBalance() - amount;
        else
            throw new BalanceInsufficientException("Bakiye yetersiz.");
    }

    public double getBalance() {
        return balance;
    }
}
