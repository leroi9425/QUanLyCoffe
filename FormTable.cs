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
    public partial class FormTable : Form
    {
        public FormTable()
        {
            InitializeComponent();
        }
        private void FormTable_Load(object sender, EventArgs e)
        {
            firstLabel.Hide();
            firstTextSl.Hide();
            lbGiaBan.Hide();
            titleTable.Text = "KC TABLE  " + cofferManager.idTable;
            labels.Clear();
            labelTiens.Clear();
            textBoxes.Clear();
            labelNV.Text = InfoFormTable.infoForm;


            if(CMenu.menus.Count == 0)
            {
                CMenu.addMenu();
            }

            //   add thong tin vao sql HOADON
            // lấy mã hóa đơn
            ma_hoa_don = getMaHoaDon();
            int sloveid = int.Parse(cofferManager.idTable.Replace("0", ""));
            HoaDon.addHoaDon(ma_hoa_don, sloveid, tongTien, 0,"");
        }
        private string getMaHoaDon()
        {
            // ý tưởng: lấy buổi +  giờ + bàn = mã hóa đơn
            // -10/22/2023 6:27:36 PM- 1 vi du ve date time
            DateTime time = DateTime.Now;
            string[] s = time.ToString().Split(' ');   // 0 la nay, 1 la gio, 2 la PM hoac AM
            string[] hms = s[1].Split(':');     // hour minute sencond
            return s[2] + hms[0] + hms[1] + hms[2] + cofferManager.idTable;
        }
        private void drawButton()
        {
            for (int i = 0; i < 3; i++)
            {
                Button btn = new Button()
                {
                    Text = "cofe",
                    Height = 52,
                    Width = 148,
                    Image = Image.FromFile("C:\\Users\\Admin\\Pictures\\du_an_app_coffe\\nut_type2.png"),
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.Black
                };
                showButton.Controls.Add(btn);
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void clear()
        {
           labelMon.Controls.Clear();
        }
        private void drawmon()
        {
            for (int i = 0; i < CMenu.menus.Count; i++)
            {
                //MessageBox.Show("for "+btnCoffe.Text);
                if (CMenu.menus[i].type == publicType)
                {
                    //MessageBox.Show(btnCoffe.Text);
                    if (textTimKiem.Text != "") { }
                    Button btn = new Button()
                    {
                        Text = CMenu.menus[i].tenMon,
                        Font = button1.Font,
                        Height = 33,
                        Width = 101,
                        FlatStyle = FlatStyle.Popup,
                        AutoSize = true
                    };
                    btn.Click += btn_Click;
                    labelMon.Controls.Add(btn);
                }
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
         //   MessageBox.Show(btn.Text + HoaDon.getIdFood(btn.Text).ToString());
            // tạo nhãn ghi tên món
            Label label = new Label()
            {
                AutoSize = false,
                Text = btn.Text,
                Image = firstLabel.Image,
                Height = firstLabel.Height,
                Width = firstLabel.Width,
                Font = firstLabel.Font
            }; 
            // tạo nhãn ghi tổng số tiền
            Label labelTien = new Label()
            {
                AutoSize = false,
                Text = "0",
                Image = firstLabel.Image,
                Height = firstLabel.Height,
                Width = firstLabel.Width,
                Font = firstLabel.Font
            };
            // tạo text nhập số lượng
            TextBox textBox = new TextBox()
            {
                Multiline = true,
                Height = firstTextSl.Height,
                Width = firstTextSl.Width,
                Font = firstTextSl.Font
            };
            textBox.TextChanged += textBox_TextChanged;
            textBox.Leave += texBox_Leave;
            // thay đổi thuộc tính của text bõ bên dưới:
            if(textBoxes.Count >= 1)
            {
                if(textBoxes[textBoxes.Count - 1].Text == "")
                {
                    MessageBox.Show("vui lòng nhập số lượng");
                    return;
                }
                else
                {
                    textBoxes[textBoxes.Count - 1].ReadOnly = true;
                }
            }
            // add vao sql CHITIETHOADON
            idFood = HoaDon.getIdFood(btn.Text);
            if(idFood >= 0)
            {
                HoaDon.addChiTietHD(ma_hoa_don, idFood);
            }
            
            labels.Add(label);
            labelTiens.Add(labelTien);
            textBoxes.Add(textBox);
            showTenMon.Controls.Clear();
            showInfo(showTenMon,showTien);
            int id = HoaDon.getIdFood(oldTenMon);
            HoaDon.updateChiTietHD(ma_hoa_don, id, oldSoLuong);
        }
        public static void updateChiTietHD(string mahoadon, int soluong)
        {

        }
        public static void showInfo(FlowLayoutPanel showTenMon, FlowLayoutPanel showTien)
        {
            for (int i = labels.Count; i > 0; i--)
            {
                showTenMon.Controls.Add(labels[i - 1]); // bug in this line
                showTenMon.Controls.Add(textBoxes[i - 1]);
                showTien.Controls.Add(labelTiens[i - 1]);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            clear();
            publicType = btnCoffe.Text;
            drawmon();
        }
        private string xuLiGia(int gia)
        {
            return String.Format("{0:#,##0.##}", gia);
        }
        private void thanhTien() // ham nay ko dung j ca
        {
            int tong = 0;
            for(int i=0; i< labelTiens.Count; i++)
            {
                tong += int.Parse(labelTiens[i].Text);
            }
            labelThanhTien.Text = xuLiGia(tong);
        }
        private void texBox_Leave(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            string gia = String.Empty;
            TextBox textBoxes = sender as TextBox;
            if(textBoxes.Text == "")
            {
                return;
            }
            for(int i=0; i<CMenu.menus.Count; i++)
            {
                 //kiểm tra phần tử cuối cùng
                if (CMenu.menus[i].tenMon == labels[labels.Count - 1].Text)
                {
                    gia = CMenu.menus[i].gia;
                }
            }
            // xu li gia tien:
            int gia2 = 0;
            if(textBoxes.Text != "")
            {
                try
                {
                    gia2 = int.Parse(gia) * int.Parse(textBoxes.Text);
                }
                catch (Exception) { }
            }
            tongTien = tongTien + gia2;
            labelTiens[labelTiens.Count-1].Text = xuLiGia(gia2);
            labelThanhTien.Text = xuLiGia(tongTien);
            try
            {
                oldSoLuong = int.Parse(textBoxes.Text);
            }
            catch (Exception) { }
            oldTenMon = labels[labels.Count - 1].Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            publicType = button1.Text;
            drawmon();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
            publicType = button3.Text;
            drawmon();
        }

        private void FormTable_FormClosed(object sender, FormClosedEventArgs e)
        {
            InfoFormTable.aTable = false; // không còn bàn nào đang mở nữa
        }

        private void textTimKiem_TextChanged(object sender, EventArgs e)
        {
            labelMon.Controls.Clear();
            for(int i = 0; i < CMenu.menus.Count; i++)
            {
                if (CMenu.menus[i].type == publicType && CMenu.menus[i].tenMon.Contains(textTimKiem.Text))
                {
                    Button btn = new Button()
                    {
                        Text = CMenu.menus[i].tenMon,
                        Font = button1.Font,
                        Height = 33,
                        Width = 101,
                        FlatStyle = FlatStyle.Popup
                    };
                    btn.Click += btn_Click;
                    labelMon.Controls.Add(btn);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int index = HoaDon.listHoaDon.Count -1 ;
            string cid = textBoxes[textBoxes.Count - 1].Text;
            HoaDon.updateTongTienHD(ma_hoa_don, tongTien);
            HoaDon.updateGhiChuHD(ma_hoa_don, textGhiChu.Text);
            textBoxes[textBoxes.Count - 1].ReadOnly = true;  // chuyển hóa nút cuối ko cho sửa
            HoaDon.updateChiTietHD(ma_hoa_don, idFood, int.Parse(cid));
            FormHoaDon formHoaDon = new FormHoaDon();
            formHoaDon.getTenMon = labels;
            formHoaDon.getSoLuong = textBoxes;
            formHoaDon.getTien = labelTiens;
            formHoaDon.tongTien = tongTien;
            formHoaDon.idBill = ma_hoa_don;
            formHoaDon.idTable = int.Parse(cofferManager.idTable.Replace("0", ""));
            this.Hide();
            formHoaDon.ShowDialog();
            this.Close();
            showInfo(showTenMon, showTien);
            tongTien = 0;
        }

        private static int idFood;
        private static int oldSoLuong;
        private static string oldTenMon;
        public static List<Label> labels = new List<Label>();
        public static List<Label> labelTiens = new List<Label>();
        public static List<TextBox> textBoxes = new List<TextBox>();
        public static int tongTien = 0;
        public static string publicType;
        private static string ma_hoa_don; // luu ma hoa don cua don hang dang thuc thi

        private void textGhiChu_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("leaver");
        }
    }
}
