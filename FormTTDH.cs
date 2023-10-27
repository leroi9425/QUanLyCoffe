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
    public partial class FormTTDH : Form
    {
        public FormTTDH()
        {
            InitializeComponent();
        }

        private void FormTTDH_Load(object sender, EventArgs e)
        {
            firstLabel.Hide();
            HoaDon.loadDataHoaDon();
            HoaDon.loadListHD();
            HoaDon.loadListCTHD();
            for(int i=0; i<HoaDon.listHoaDon.Count; i++)
            {
                Label label = new Label()
                {
                    AutoSize = false,
                    Font = firstLabel.Font,
                    BackColor = firstLabel.BackColor,
                    Width = firstLabel.Width,
                    Height = firstLabel.Height

                };
                label.Text = String.Concat(new object[]
                {
                    "MÃ ĐƠN :",
                    HoaDon.listHoaDon[i].id,
                    "\nbàn :",
                    HoaDon.listHoaDon[i].idban,
                    "\nTổng :",
                    xuLiGia(HoaDon.listHoaDon[i].tongtien),
                    "       ",
                    HoaDon.listHoaDon[i].status
                });
                label.Click += Label_Click;
                //  label.Text = "MÃ ĐƠN :" + HoaDon.listHoaDon[0].id + "\nbàn :" + HoaDon.listHoaDon[0].idban + "\n" + HoaDon.listHoaDon[0].tongtien;
                dsHoaDon.Controls.Add(label);
            }
        }
        private string xuLiGia(int gia)
        {
            return String.Format("{0:#,##0.##}", gia);
        }
        private void Label_Click(object sender, EventArgs e)
        {
            // yêu cầu: chuyển thông tin chi tiết xuống dưới
            Label label = sender as Label;
            // yêu cầu:
            // ý tưởng: hai vòng for lồng nhau để lấy số lượng, vừa lấy vừa cộng
            // lấy mã hóa đơn nx


            // xử lí để lấy mã:
            string b1 = label.Text.Replace("MÃ ĐƠN :", "");
            string[] b2 = b1.Split('b');     // b trong bàn
            string infomation = string.Empty;
            //      HoaDon.loadList1HoaDon(b2[0]);
            MaHoaDon = b2[0];
            HoaDon.loadList1hoaDon(MaHoaDon);
            for (int i = 0; i < HoaDon.list1HoaDon.Count; i++)
            {
                int dem = 0;
                for (int j=0; j< HoaDon.list1HoaDon.Count; j++)
                {
                    dem += HoaDon.list1HoaDon[i].tongtien;  // ghi la tong tien thuc ra la so luong
                }
                infomation = infomation + dem+ "-" + getNameFood(HoaDon.list1HoaDon[i].idfood);
            }
            lbMaHoaDon.Text = "MÃ ĐƠN :" + MaHoaDon;
            lbInfo.Text = lbInfo.Text + infomation;
        }
        public static string getNameFood(int id)
        {
            for(int i=0; i<CMenu.menus.Count; i++)
            {
                if (CMenu.menus[i].id == id)
                {
                    return CMenu.menus[i].tenMon;
                }
            }
            return String.Empty;
        }
        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            firstLabel.Text = "MÃ ĐƠN :" + "\nbàn " + "\nThời gian123";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            HoaDon.updateStatusHoaDon(MaHoaDon, 1);

            dsHoaDon.Controls.Clear();
            for (int i = 0; i < HoaDon.listHoaDon.Count; i++)
            {
                Label label = new Label()
                {
                    AutoSize = false,
                    Font = firstLabel.Font,
                    BackColor = firstLabel.BackColor,
                    Width = firstLabel.Width,
                    Height = firstLabel.Height

                };
                label.Text = String.Concat(new object[]
                {
                    "MÃ ĐƠN :",
                    HoaDon.listHoaDon[i].id,
                    "\nbàn :",
                    HoaDon.listHoaDon[i].idban,
                    "\nTổng :",
                    xuLiGia(HoaDon.listHoaDon[i].tongtien),
                    "       ",
                    HoaDon.listHoaDon[i].status
                });
                label.Click += Label_Click;
                dsHoaDon.Controls.Add(label);

            }
        }
        public static string MaHoaDon;
    }
}
