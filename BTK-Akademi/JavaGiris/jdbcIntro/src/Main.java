import java.sql.*;
import java.util.ArrayList;

public class Main {


    public static void main(String[] args) throws SQLException {
        Connection connection = null;
        DbHelper helper = new DbHelper();
        PreparedStatement statement = null;
        ResultSet resultSet;
        try {
            connection = helper.getConnection();
            String sql="delete from city where id=?";
            statement=connection.prepareStatement(sql);
            statement.setInt(1,4080);
            statement.executeUpdate();
            System.out.println("Kayıt silindi.");
        } catch (SQLException exception) {
            helper.ShowErrorMessage(exception);
        } finally {
            statement.close();
            connection.close();
        }
    }

    public static void SelectData() throws SQLException {
        Connection connection = null;
        DbHelper helper = new DbHelper();
        Statement statement = null;
        ResultSet resultSet;
        try {

            connection = helper.getConnection();
            statement=connection.createStatement();
            resultSet=statement.executeQuery("select Code,Name,Continent,Region from country");
            ArrayList<Country> countries=new ArrayList<Country>();
            while(resultSet.next())
            {
                countries.add(new Country(
                        resultSet.getString("Code"),
                        resultSet.getString("Name"),
                        resultSet.getString("Continent"),
                        resultSet.getString("Region")));
            }

            System.out.println(countries.size());
        } catch (SQLException exception) {
            helper.ShowErrorMessage(exception);
        } finally {
            connection.close();
        }
    }

    public static void InsertData() throws SQLException {
        Connection connection = null;
        DbHelper helper = new DbHelper();
        PreparedStatement statement = null;
        ResultSet resultSet;
        try {
            connection = helper.getConnection();
            String sql="insert into city (Name,CountryCode,District,Population) values(?,?,?,?)";
            statement=connection.prepareStatement(sql);
            statement.setString(1,"Düzce");
            statement.setString(2,"TUR");
            statement.setString(3,"Düzce");
            statement.setInt(4,60000);
            statement.executeUpdate();
            System.out.println("Kayıt eklendi.");
        } catch (SQLException exception) {
            helper.ShowErrorMessage(exception);
        } finally {
            statement.close();
            connection.close();
        }
    }

    public static void UpdateData() throws SQLException {
        Connection connection = null;
        DbHelper helper = new DbHelper();
        PreparedStatement statement = null;
        ResultSet resultSet;
        try {
            connection = helper.getConnection();
            String sql="update city set population=90000 where id=?";
            statement=connection.prepareStatement(sql);
            statement.setInt(1,4080);
            statement.executeUpdate();
            System.out.println("Kayıt güncellendi.");
        } catch (SQLException exception) {
            helper.ShowErrorMessage(exception);
        } finally {
            statement.close();
            connection.close();
        }
    }
}