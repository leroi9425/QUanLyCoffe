using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class FormHoaDon : Form
    {
        public FormHoaDon()
        {
            InitializeComponent();
        }

        //tao thuoc tinh cho form
        public static List<Label> labels = new List<Label>();
        public static List<Label> labelTiens = new List<Label>();
        public static List<TextBox> textBoxes = new List<TextBox>();
        private int tong_tien;
        private string maHoaDon;
        public static int maBan;
        public static string ghiChu;
        public List<Label> getTenMon
        {
            get { return labels; }
            set { labels = value; }
        }
        public List<TextBox> getSoLuong
        {
            get { return textBoxes; }
            set { textBoxes = value; }
        }
        public List<Label> getTien
        {
            get { return labelTiens; }
            set { labelTiens = value; }
        }
        public int tongTien
        {
            get { return tong_tien; }
            set { tong_tien = value; }
        }
        public string idBill
        {
            get { return maHoaDon; }
            set { maHoaDon = value; }
        }
        public int idTable
        {
            get { return maBan; }
            set { maBan= value; }
        }
        public string getGhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            labelTenMon.Hide();
            textSoLuong.Hide();
            labelThanhTien.Hide();
            lbMaDon.Text = maHoaDon;
            drawhoaDon();
            TongTien.Text = xuLiGia(tong_tien);
        }
        private void drawhoaDon()
        {
            for (int i = labels.Count; i > 0; i--)
            {
                try
                {
                    showHoaDon.Controls.Add(labels[i - 1]); // bug in this line
                    showHoaDon.Controls.Add(textBoxes[i - 1]);
                    showHoaDon.Controls.Add(labelTiens[i - 1]);
                }
                catch (Exception)
                {

                }
            }
        }
        private string xuLiGia(int gia)
        {
            return String.Format("{0:#,##0.##}", gia);
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            textKhachDua.Text = string.Empty;
        }

        private void textKhachDua_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int tienkhach = int.Parse(textKhachDua.Text);
                int tong = tienkhach - tong_tien;
                if (tong >= 0)
                {
                    lbTienThua.Text = xuLiGia(tong);
                }
                else
                {
                    lbTienThua.Text = "";
                }
            }
            catch (Exception)
            {

            }
        }

        private void textKhachDua_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void textKhachDua_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void btnDong_MouseClick(object sender, MouseEventArgs e)
        {
            // xác nhận xem hóa đơn đang ở trạng thái nào và sửa ở sql
            if (lbTienThua.Text != "")
            {
                HoaDon.updateStatusHoaDon(maHoaDon, 1);  // != 0 tuc la da thanh toan
            }
            this.Close();
        }
    }
}
