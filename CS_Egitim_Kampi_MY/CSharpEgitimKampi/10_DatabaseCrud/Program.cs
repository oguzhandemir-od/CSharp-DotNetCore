using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_DatabaseCrud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Menü Sipariş İşlem Paneli *****");
            Console.WriteLine();

            Console.WriteLine("--------------------------------------");
            #region Adding Category
            //Console.Write("Eklemek istediğiniz kategori adı: ");
            //string categoryName = Console.ReadLine();

            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CR14I0T;Initial Catalog=EgitimKampiDb;" +
            //    "Integrated Security=true");
            //connection.Open();
            //SqlCommand command = new SqlCommand("Insert Into TblCategory (CategoryName) values (@p1)", connection);
            //command.Parameters.AddWithValue("@p1", categoryName);
            //command.ExecuteNonQuery();
            //connection.Close();

            //Console.Write("Kategori başarıyla eklendi!");
            #endregion

            #region Adding Product

            //string productName;
            //decimal productPrice;
            // bool productStatus;

            //Console.Write("Ürün adı: ");
            //productName= Console.ReadLine();
            //Console.Write("Ürün fiyatı: ");
            //productPrice=decimal.Parse(Console.ReadLine());

            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CR14I0T;Initial Catalog=EgitimKampiDb;" +
            //    "Integrated Security=true");
            //connection.Open();
            //SqlCommand command = new SqlCommand("Insert Into TblProduct (ProductName, ProductPrice, ProductStatus)" +
            //    "values (@productName,@productPrice,@productStatus)", connection);
            //command.Parameters.AddWithValue("@productName", productName);
            //command.Parameters.AddWithValue("@productPrice", productPrice);
            //command.Parameters.AddWithValue("@productStatus", true);
            //command.ExecuteNonQuery();
            //connection.Close();

            //Console.WriteLine("Ürün eklemesi başarılı!");

            #endregion

            #region Listing Products

            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CR14I0T;Initial Catalog=EgitimKampiDb;" +
            //    "Integrated Security=true");
            //connection.Open();
            //SqlCommand command = new SqlCommand("Select * From TblProduct", connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //DataTable dataTable = new DataTable();
            //adapter.Fill(dataTable);

            //foreach (DataRow row in dataTable.Rows)
            //{
            //    foreach (var item in row.ItemArray)
            //    {
            //        Console.Write(item.ToString() + " ");
            //    }
            //    Console.WriteLine();
            //}
            //connection.Close();

            #endregion

            #region Deleting Products

            //Console.Write("Silinecek ürün ID: ");
            //int productId=int.Parse(Console.ReadLine());

            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CR14I0T;Initial Catalog=EgitimKampiDb;" +
            //    "Integrated Security=true");
            //connection.Open();

            //SqlCommand command = new SqlCommand("Delete From TblProduct Where ProductId=@productId",connection);
            //command.Parameters.AddWithValue("@productId", productId);
            //command.ExecuteNonQuery();

            //connection.Close();

            //Console.WriteLine("Silme işlemi başarılı!");

            #endregion

            #region Updating Products

            Console.Write("Güncellenecek ürün ID: ");
            int productId=int.Parse(Console.ReadLine());
            Console.Write("Güncellenecek ürün adı: ");
            string productName=Console.ReadLine();
            Console.Write("Güncellenecek ürün fiyatı: ");
            decimal productPrice=decimal.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CR14I0T;Initial Catalog=EgitimKampiDb;" +
                "Integrated Security=true");
            connection.Open();

            SqlCommand command = new SqlCommand("Update TblProduct Set ProductName=@productName, ProductPrice=@productPrice Where ProductId=@productId", connection);
            command.Parameters.AddWithValue("@productName", productName);
            command.Parameters.AddWithValue("@productPrice", productPrice);
            command.Parameters.AddWithValue("@productId", productId);
            command.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine("Güncelleme Başarılı!");

            #endregion

            Console.ReadKey();
        }

    }
}
