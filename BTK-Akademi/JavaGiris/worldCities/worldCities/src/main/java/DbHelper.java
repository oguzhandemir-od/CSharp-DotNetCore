
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

/**
 *
 * @author oğuzhan
 */
public class DbHelper {
    private String userName="root";
    private String password="root";
    private String dbUrl="jdbc:mysql://localhost:3306/world";
    
    public Connection getConnection() throws SQLException
    {
        return DriverManager.getConnection(dbUrl,userName,password);
    }
    
    public void ShowErrorMessage(SQLException exception)
    {
        System.out.println("Error: "+exception.getMessage());
        System.out.println("Error code: "+exception.getErrorCode());
    }
}
