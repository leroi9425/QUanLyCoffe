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
    public partial class FormCustomer : Form
    {
        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;
        public FormCustomer()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            labelNV.Text = InfoFormTable.infoForm;
            drawTable();
        }
        void btn_Click(object sender, EventArgs e)
        {
            if (InfoFormTable.aTable)  // nếu có bàn đang thao tác
            {
                return;
            }
            Button btn = sender as Button;
            FormTable formTable = new FormTable();
            cofferManager.idTable = btn.Text;
            formTable.Show();
            formTable.Text = String.Empty;
            InfoFormTable.aTable = true;
        }
        private void drawTable()
        {
            int dem = 1;
            int y = 23;
            for (int i=0; i<4; i++)
            {
                for(int j=0; j<4; j++)
                {
                    int x = 0;
                    Button btn = new Button();
                    btn.Width = first_table.Width;
                    btn.Height = first_table.Height;
                    btn.Image = first_table.Image;
                    btn.Font = first_table.Font;
                    btn.ForeColor = first_table.ForeColor;
                    btn.FlatStyle = first_table.FlatStyle;
                    btn.FlatAppearance.BorderColor = first_table.FlatAppearance.BorderColor;
                    btn.Click += btn_Click;
                    btn.Text = dem < 10 ? ("0" + dem) : dem.ToString();
                    btn.Name = dem.ToString();
                    switch (j)
                    {
                        case 0:
                            x = 3;
                            break;
                        case 1:
                            x = 177;
                            break;
                        case 2:
                            x = 352;
                            break;
                        case 3:
                            x = 533;
                            break;
                    }
                    switch (i)
                    {
                        case 0:
                            y = 34;
                            break;
                        case 1:
                            y = 122;
                            break;
                        case 2:
                            y = 225;
                            break;
                        case 3:
                            y = 326;
                            break;
                    }
                    if (!(i == 0 && j==0) && !(i==0 && j==2))
                    {
                        btn.Location = new Point(x, y);
                        panel1.Controls.Add(btn);
                    }

                    dem++;
                }
            }
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            FormTTDH formTTDH = new FormTTDH();
            this.Hide();
            formTTDH.ShowDialog();
            this.Show();
        }
    }
}
