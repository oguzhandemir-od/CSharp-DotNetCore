import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<Customer> customers=new ArrayList<Customer>();

        customers.add(new Customer(1,"Oğuzhan","Demir"));
        customers.add(new Customer(2,"Baturhan","Demir"));
        customers.add(new Customer(3,"Berk","Güney"));

        for(Customer customer:customers)
        {
            System.out.println(customer.firstName);
        }
    }
}