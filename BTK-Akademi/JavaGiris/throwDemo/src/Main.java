public class Main {
    public static void main(String[] args) {
        AccountManager manager=new AccountManager();
        System.out.println("Hesap Bakiyesi: "+manager.getBalance());
        manager.Deposit(100);
        System.out.println("Hesap Bakiyesi: "+manager.getBalance());
        try
        {
            manager.Withdraw(90);
        }
        catch (BalanceInsufficientException e)
        {
            System.out.println(e.getMessage());
        }
        System.out.println("Hesap Bakiyesi: "+manager.getBalance());
        try
        {
            manager.Withdraw(20);
        }
        catch(BalanceInsufficientException e)
        {
            System.out.println(e.getMessage());
        }
        System.out.println("Hesap Bakiyesi: "+manager.getBalance());

    }
}