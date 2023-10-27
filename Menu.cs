using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public struct MyMenu
    {
        public int id;
        public string tenMon;
        public string type;
        public string gia;
    }
    public class CMenu
    {
        public static void loadMenuList()   // LOAD TU SQL
        {
            string connectionSTR = "Data Source=ADMIN;Initial Catalog=QLQCF;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionSTR);

            string query = "SELECT * FROM FOOD";                                      // ở đây viết câu lệnh truy vấn sql
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection); // ct sẽ truy cập vào connectin và thực hiện câu truy vấn
                                                                    //        DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataMenu);
            connection.Close();
        }
        public static void addMenu()
        {
           if(dataMenu != null)
           {
                dataMenu.Clear();
           }
            CMenu.loadMenuList();
            foreach (DataRow row in dataMenu.Rows)
            {
                MyMenu myMenu = new MyMenu();
                string type = string.Empty;
                switch (int.Parse(row["categoty"].ToString()))
                {
                    case 0: 
                        type = "COFFE";
                        break;
                    case 1:
                        type = "TRÁI CÂY";
                        break;
                    case 2:
                        type = "TOPPING";
                        break;
                }
                myMenu.id = (int)row["id"];
                myMenu.type = type;
                myMenu.tenMon = row["ten"].ToString();
                myMenu.gia = row["gia"].ToString();
                menus.Add(myMenu);
            }
        }

        public static DataTable dataMenu = new DataTable();
        public static List<MyMenu> menus = new List<MyMenu>();
    }
}
