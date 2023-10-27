using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyQuanCafe
{
    public struct cHoaDon
    {
        public string id;
        public int idban;
        public int tongtien;
        public string status;
        public string ghichu;
    }
    public struct chiTietHoaDon
    {
        public string idbill;
        public int idfood;
        public int tongtien;
    }
    public class HoaDon
    {
        public static int getIdFood(string food)
        {
            for(int i=0; i<CMenu.menus.Count; i++)
            {
                if (CMenu.menus[i].tenMon == food)
                {
                    return CMenu.menus[i].id;
                }
            }
            return -1;
        }
        public static void loadDataChiTietHoaDon()   // LOAD TU SQL
        {
            string connectionSTR = "Data Source=ADMIN;Initial Catalog=QLQCF;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionSTR);

            string query = "SELECT * FROM CHITIETHOADON";                                      // ở đây viết câu lệnh truy vấn sql
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection); // ct sẽ truy cập vào connectin và thực hiện câu truy vấn
                                                                    //        DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataChiTietHD);
            connection.Close();
        }
        public static void loadListCTHD()   // sd khi mo form tthd len
        {
            if (dataChiTietHD != null)
            {
                dataChiTietHD.Clear();
            }
            if(listChiTietHoaDon.Count >=1)
            {
                listChiTietHoaDon.Clear();
            }
            loadDataChiTietHoaDon();
            foreach (DataRow row in dataChiTietHD.Rows)
            {
                chiTietHoaDon cthd = new chiTietHoaDon();
                cthd.idbill = row["idbill"].ToString();
                cthd.idfood = (int)row["idfood"];
                cthd.tongtien =  (int)row["tongtien"];
                listChiTietHoaDon.Add(cthd);
            }
        }
        public static void addChiTietHD(string idbill, int idfood)
        {
            string query = "INSERT INTO CHITIETHOADON\r\nVALUES\t('"+idbill+"',"+idfood+",1)";
            try
            {
                int data;
                string connectionSTR = "Data Source=ADMIN;Initial Catalog=QLQCF;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionSTR);

                //    string query = "INSERT INTO HOADON\r\nVALUES\t('ban04',11,100000,'12:15:12','12:20:1')";                                      // ở đây viết câu lệnh truy vấn sql
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection); // ct sẽ truy cập vào connectin và thực hiện câu truy vấn

                data = command.ExecuteNonQuery(); // phai co cau nay ms chay dc
                connection.Close();
             //   MessageBox.Show("addmenu");
            }
            catch (Exception) { }
        }
        public static string getStatus(sbyte status)
        {
            string cstatus = string.Empty;
            switch (status)
            {
                case 0:
                    cstatus = "CHƯA THANH TOÁN";
                    break;
                case 1:
                    cstatus = "đã thanh toán";
                    break;
            }
            return cstatus;
        }
        public static void addHoaDon(string id, int idban, int tongtien, sbyte status, string ghichu)  // chen du lieu vao table HoaDon
        {
            string cstatus = getStatus(status);
            MessageBox.Show("add hoa don " + ghichu);
            string query = "INSERT INTO HOADON\r\nVALUES\t('"+id+"',"+idban+","+tongtien+",null,null,N'"+cstatus+"',N'"+ghichu+"')";
            try
            {
                int data;
                string connectionSTR = "Data Source=ADMIN;Initial Catalog=QLQCF;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionSTR);

            //    string query = "INSERT INTO HOADON\r\nVALUES\t('ban04',11,100000,'12:15:12','12:20:1')";                                      // ở đây viết câu lệnh truy vấn sql
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection); // ct sẽ truy cập vào connectin và thực hiện câu truy vấn

                data = command.ExecuteNonQuery(); // phai co cau nay ms chay dc
                connection.Close();
             //   MessageBox.Show("addmenu");
            }
            catch (Exception) { }
        }
        public static void loadDataHoaDon()   // LOAD TU SQL
        {
            string connectionSTR = "Data Source=ADMIN;Initial Catalog=QLQCF;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionSTR);

            string query = "SELECT * FROM HOADON";                                      // ở đây viết câu lệnh truy vấn sql
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection); // ct sẽ truy cập vào connectin và thực hiện câu truy vấn
                                                                    //        DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataHoaDon);
            connection.Close();
        }
        public static void loadListHD()   // sd khi mo form tthd len
        {
            if (dataHoaDon != null)
            {
                dataHoaDon.Clear();
            }
            loadDataHoaDon();
            listHoaDon.Clear();
            foreach( DataRow row in dataHoaDon.Rows)
            {
                cHoaDon hoaDon = new cHoaDon();
                hoaDon.id = row["id"].ToString();
                hoaDon.idban = (int)row["idban"];
                hoaDon.tongtien = (int)row["tongtiem"];
                hoaDon.status = row["status"].ToString();
                hoaDon.ghichu = row["ghichu"].ToString();
                listHoaDon.Add(hoaDon);
            }
        }
        private static void resetHOADON()
        {
            // xoa du lieu cu
            dataHoaDon.Clear();
            listHoaDon.Clear();

            // lay lai du lieu cho list
            loadDataHoaDon();
            loadListHD();
        }
        public static void updateGhiChuHD(string id, string ghichu)
        {
            // ý tưởng: update xong lấy lại dữ liệu
            MessageBox.Show("update ghi chu " + ghichu);
            string query = "UPDATE HOADON SET ghichu = N'" + ghichu + "' WHERE id = '" + id + "'";
            try
            {
                int data;
                string connectionSTR = "Data Source=ADMIN;Initial Catalog=QLQCF;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionSTR);

                //    string query = "INSERT INTO HOADON\r\nVALUES\t('ban04',11,100000,'12:15:12','12:20:1')";                                      // ở đây viết câu lệnh truy vấn sql
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection); // ct sẽ truy cập vào connectin và thực hiện câu truy vấn

                data = command.ExecuteNonQuery(); // phai co cau nay ms chay dc
                connection.Close();
            }
            catch (Exception) { }

            resetHOADON();
        }
        public static void updateTongTienHD(string id, int tongtien)
        {
            // ý tưởng: update xong lấy lại dữ liệu
            string query = "UPDATE HOADON SET tongtiem = '" + tongtien + "' WHERE id = '" + id + "'";
            try
            {
                int data;
                string connectionSTR = "Data Source=ADMIN;Initial Catalog=QLQCF;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionSTR);

                //    string query = "INSERT INTO HOADON\r\nVALUES\t('ban04',11,100000,'12:15:12','12:20:1')";                                      // ở đây viết câu lệnh truy vấn sql
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection); // ct sẽ truy cập vào connectin và thực hiện câu truy vấn

                data = command.ExecuteNonQuery(); // phai co cau nay ms chay dc
                connection.Close();
            }
            catch (Exception) { }

            resetHOADON();
        }
        public static void updateStatusHoaDon(string id, sbyte status)
        {
            // ý tưởng: update xong lấy lại dữ liệu
            string cstatus = getStatus(status);
            string query = "UPDATE HOADON SET status = N'" + cstatus + "' WHERE id = '" + id + "'";
            try
            {
                int data;
                string connectionSTR = "Data Source=ADMIN;Initial Catalog=QLQCF;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionSTR);

                //    string query = "INSERT INTO HOADON\r\nVALUES\t('ban04',11,100000,'12:15:12','12:20:1')";                                      // ở đây viết câu lệnh truy vấn sql
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection); // ct sẽ truy cập vào connectin và thực hiện câu truy vấn

                data = command.ExecuteNonQuery(); // phai co cau nay ms chay dc
                connection.Close();

            }
            catch (Exception) { }

            resetHOADON();

        }
        public static void loadList1HoaDon(string cidbill)
        {
            int dem = 0;
            for (int i=0; i<listChiTietHoaDon.Count; i++)
            {
                chiTietHoaDon cthd = new chiTietHoaDon();
                if (listChiTietHoaDon[i].idbill == cidbill)
                {
                    cthd.idbill = listChiTietHoaDon[i].idbill;
                    cthd.idfood = listChiTietHoaDon[i].idfood;
                    cthd.tongtien = listChiTietHoaDon[i].tongtien;
                    list1HoaDon.Add(cthd);
                }
            }
        }
        public static void load1hoaDon(string idbill)
        {
            string connectionSTR = "Data Source=ADMIN;Initial Catalog=QLQCF;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionSTR);

            string query = "SELECT * FROM CHITIETHOADON WHERE idbill = '"+idbill+"'";                                      // ở đây viết câu lệnh truy vấn sql
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection); // ct sẽ truy cập vào connectin và thực hiện câu truy vấn
                                                                    //        DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data1HoaDon);
            if(data1HoaDon != null)
            connection.Close();
        }
        public static void loadList1hoaDon(string idbill)
        {
            if (data1HoaDon != null)
            {
                   data1HoaDon.Clear();
            }
            load1hoaDon(idbill);
            list1HoaDon.Clear();
            File.WriteAllText("idbill.txt",idbill);
            foreach (DataRow row in data1HoaDon.Rows)
            {
                MessageBox.Show("123");
                chiTietHoaDon hoaDon = new chiTietHoaDon();
                hoaDon.idbill = row["idbill"].ToString();
                hoaDon.idfood = (int)row["idfood"];
                hoaDon.tongtien = (int)row["tongtien"];
                list1HoaDon.Add(hoaDon);
            }
        }
        public static void updateChiTietHD(string idbill, int idfood, int sl)
        {
            string query = "UPDATE CHITIETHOADON SET tongtien = "+sl+" WHERE idbill = '"+idbill+"' and idfood = '"+idfood+"'";
            try
            {
                int data;
                string connectionSTR = "Data Source=ADMIN;Initial Catalog=QLQCF;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionSTR);

                //    string query = "INSERT INTO HOADON\r\nVALUES\t('ban04',11,100000,'12:15:12','12:20:1')";                                      // ở đây viết câu lệnh truy vấn sql
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection); // ct sẽ truy cập vào connectin và thực hiện câu truy vấn

                data = command.ExecuteNonQuery(); // phai co cau nay ms chay dc
                connection.Close();
            }
            catch (Exception) { }
            resetChiTietHD();
        }
        private static void resetChiTietHD()
        {
            loadListCTHD();
        }

        public static DataTable dataHoaDon = new DataTable();
        public static DataTable dataChiTietHD = new DataTable();
        public static DataTable data1HoaDon = new DataTable();
        public static List<cHoaDon> listHoaDon = new List<cHoaDon>();
        public static List<chiTietHoaDon> listChiTietHoaDon = new List<chiTietHoaDon>();
        public static List<chiTietHoaDon> list1HoaDon = new List<chiTietHoaDon>();
    }
}
