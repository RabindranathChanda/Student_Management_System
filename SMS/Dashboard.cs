using Custom_Picture_Box;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class Dashboard : Form
    {
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }
        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3
        }
        // Import dwmapi.dll and define DwmSetWindowAttribute in C# corresponding to the native function.
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd,
                                                         DWMWINDOWATTRIBUTE attribute,
                                                         ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                         uint cbAttribute);
        // ----------------------------------------------------------

        // Minimize or Maximize from Taskbar Icon -----------------------//
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;
                var cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                return cp;
            }

        }
        // --------------------------------------------------------

        // Making the Form Movable -----------------------------//
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void TitleBar_pnl_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void STitleBar_pnl_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        public Dashboard(string Name, string UserType, byte[] DP)
        //public Dashboard()
        {
            // Optimize form initialization to prevent flickering
            this.SuspendLayout();
            
            InitializeComponent();
            
            // Set advanced double buffering and visual properties
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                         ControlStyles.UserPaint | 
                         ControlStyles.DoubleBuffer | 
                         ControlStyles.ResizeRedraw, true);
            
            // Set user information
            label13.Text = Name.ToString();
            label14.Text = UserType.ToString();
            
            // Optimize image loading to prevent flickering
            if (DP != null && DP.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(DP))
                    {
                        DP_cpb.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    // Handle image loading errors gracefully
                    DP_cpb.Image = null;
                }
            }
            
            this.ResumeLayout(false);
            this.PerformLayout();
            
            // Apply DWM settings after form is fully loaded
            this.Load += (sender, e) => {
                try
                {
                    var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
                    var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
                    DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));
                }
                catch
                {
                    // Ignore DWM errors on older systems
                }
            };
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            WControls.exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WControls.DoMax(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WControls.Minimize(this);
        }

        private void Close_btn_MouseEnter(object sender, EventArgs e)
        {
            Close_btn.ForeColor = Color.White;
        }

        private void Close_btn_MouseLeave(object sender, EventArgs e)
        {
            Close_btn.ForeColor = Color.Black;
        }
        bool Std_Expanded, Lib_Expended, Trans_Expended;
        private void Students_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Std_Expanded == false)
                {
                    StudentMenu_pnl.Height = StudentMenu_pnl.Height + 10;
                    if (StudentMenu_pnl.Size == StudentMenu_pnl.MaximumSize)
                    {
                        Students_timer.Stop();
                        Std_Expanded = true;
                    }
                }
                else
                {
                    StudentMenu_pnl.Height = StudentMenu_pnl.Height - 10;
                    if (StudentMenu_pnl.Size == StudentMenu_pnl.MinimumSize)
                    {
                        Students_timer.Stop();
                        Std_Expanded = false;
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }
        private void Library_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Lib_Expended == false)
                {
                    LibraryMenu_pnl.Height = LibraryMenu_pnl.Height + 10;
                    if (LibraryMenu_pnl.Size == LibraryMenu_pnl.MaximumSize)
                    {
                        Library_timer.Stop();
                        Lib_Expended = true;
                    }
                }
                else
                {
                    LibraryMenu_pnl.Height = LibraryMenu_pnl.Height - 10;
                    if (LibraryMenu_pnl.Size == LibraryMenu_pnl.MinimumSize)
                    {
                        Library_timer.Stop();
                        Lib_Expended = false;
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void Transport_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Trans_Expended == false)
                {
                    TransMenu_pnl.Height = TransMenu_pnl.Height + 10;
                    if (TransMenu_pnl.Size == TransMenu_pnl.MaximumSize)
                    {
                        Transport_timer.Stop();
                        Trans_Expended = true;
                    }
                }
                else
                {
                    TransMenu_pnl.Height = TransMenu_pnl.Height - 10;
                    if (TransMenu_pnl.Size == TransMenu_pnl.MinimumSize)
                    {
                        Transport_timer.Stop();
                        Trans_Expended = false;
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }
        private void StudentMenu_pnl_Click(object sender, EventArgs e)
        {
            Students_timer.Start();
        }

        private void LibraryMenu_pnl_Click(object sender, EventArgs e)
        {
            Library_timer.Start();
        }

        private void TransMenu_pnl_Click(object sender, EventArgs e)
        {
            Transport_timer.Start();
        }

        private void trans_lbl_Click(object sender, EventArgs e)
        {
            Transport_timer.Start();
        }

        private void lib_lbl_Click(object sender, EventArgs e)
        {
            Library_timer.Start();
        }

        private void stud_lbl_Click(object sender, EventArgs e)
        {
            Students_timer.Start();
        }

        private void Trans_pb_Click(object sender, EventArgs e)
        {
            Transport_timer.Start();
        }

        private void Lib_pb_Click(object sender, EventArgs e)
        {
            Library_timer.Start();
        }

        private void Stud_pb_Click(object sender, EventArgs e)
        {
            Students_timer.Start();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            Admissonbtn_pnl.BackColor = Color.FromArgb(65, 204, 212, 230);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            Admissonbtn_pnl.BackColor = Color.Transparent;

        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            Rectifybtn_pnl.BackColor = Color.FromArgb(65, 204, 212, 230);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            Rectifybtn_pnl.BackColor = Color.Transparent;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            Terminatbtn_pnl.BackColor = Color.FromArgb(65, 204, 212, 230);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            Terminatbtn_pnl.BackColor = Color.Transparent;
        }
        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            BKReturnbtn_pnl.BackColor = Color.FromArgb(65, 204, 212, 230);
        }
        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            BKReturnbtn_pnl.BackColor = Color.Transparent;
        }
        

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            BKIssuebtn_pnl.BackColor = Color.FromArgb(65, 204, 212, 230);
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            BKIssuebtn_pnl.BackColor = Color.Transparent;
        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            AddPassenbtn_pnl.BackColor = Color.FromArgb(65, 204, 212, 230);
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            AddPassenbtn_pnl.BackColor = Color.Transparent;
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            PayFeesbtn_pnl.BackColor = Color.FromArgb(65, 204, 212, 230);
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            PayFeesbtn_pnl.BackColor = Color.Transparent;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            PrintReceiptbtn_pnl.BackColor = Color.FromArgb(65, 204, 212, 230);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            PrintReceiptbtn_pnl.BackColor = Color.Transparent;
        }

        private void pictureBox12_MouseEnter(object sender, EventArgs e)
        {
            ListPassenbtn_pnl.BackColor = Color.FromArgb(65, 204, 212, 230);
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            ListPassenbtn_pnl.BackColor = Color.Transparent;
        }

        UserControl Old_UserControl = new UserControl();        
        private void Terminationbtn_pnl_Click(object sender, EventArgs e)
        {
            try
            {
                Old_UserControl.Dispose();
                WorkingPanel.Controls.Clear();
                StudentTerminate studentTerminate = new StudentTerminate();
                studentTerminate.Dock = DockStyle.Fill;
                Old_UserControl= studentTerminate;
                WorkingPanel.Controls.Add(studentTerminate);

                Terminationbtn_pnl.ForeColor = Color.FromArgb(253, 197, 0);
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label9.ForeColor = Color.White;
                label10.ForeColor = Color.White;
                label12.ForeColor = Color.White;
            }
            catch(Exception ex)
            {
                WControls.ShowToasterMsg("ERROR","Error on Loading",ex.Message.ToString());
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            try
            {
                Old_UserControl.Dispose();
                WorkingPanel.Controls.Clear();
                BkIssue BookIssue =  new BkIssue();
                BookIssue.Dock = DockStyle.Fill;
                Old_UserControl = BookIssue;
                WorkingPanel.Controls.Add(BookIssue);


                //

                label7.ForeColor= Color.FromArgb(253, 197, 0);
                Terminationbtn_pnl.ForeColor = Color.White;
                label2.ForeColor= Color.White;
                label3.ForeColor= Color.White;
                label5.ForeColor= Color.White;
                label6.ForeColor= Color.White;
                label9.ForeColor= Color.White;
                label10.ForeColor= Color.White;
                label12.ForeColor= Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            try
            {
                Old_UserControl.Dispose();
                WorkingPanel.Controls.Clear();
                BkReturn BookReturn = new BkReturn();
                BookReturn.Dock = DockStyle.Fill;
                Old_UserControl = BookReturn;
                WorkingPanel.Controls.Add(BookReturn);

                label6.ForeColor = Color.FromArgb(253, 197, 0);
                Terminationbtn_pnl.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label9.ForeColor = Color.White;
                label10.ForeColor = Color.White;
                label12.ForeColor = Color.White;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            try
            {
                Old_UserControl.Dispose();
                WorkingPanel.Controls.Clear();

                //

                label10.ForeColor = Color.FromArgb(253, 197, 0);
                Terminationbtn_pnl.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label9.ForeColor = Color.White;
                label12.ForeColor = Color.White;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            try
            {
                Old_UserControl.Dispose();
                WorkingPanel.Controls.Clear();

                //

                label9.ForeColor = Color.FromArgb(253, 197, 0);
                Terminationbtn_pnl.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label10.ForeColor = Color.White;
                label12.ForeColor = Color.White;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            try
            {
                Old_UserControl.Dispose();
                WorkingPanel.Controls.Clear();

                //

                label5.ForeColor = Color.FromArgb(253, 197, 0);
                Terminationbtn_pnl.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label9.ForeColor = Color.White;
                label10.ForeColor = Color.White;
                label12.ForeColor = Color.White;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            try
            {
                Old_UserControl.Dispose();
                WorkingPanel.Controls.Clear();

                //

                label12.ForeColor = Color.FromArgb(253, 197, 0);
                Terminationbtn_pnl.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label9.ForeColor = Color.White;
                label10.ForeColor = Color.White;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void pictureBox13_Click(object sender, EventArgs e)
        {
            WControls.ShowToasterMsg("SUCCESS","Logout Successfull","User Loged out Successfully");
            L_or_R lr = new L_or_R();
            lr.Show();
            this.Close();
        }

        private void pictureBox13_MouseEnter(object sender, EventArgs e)
        {
            pictureBox13.BackColor = Color.FromArgb(65, 204, 212, 230);
        }

        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
            pictureBox13.BackColor = Color.Transparent;
        }
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                Old_UserControl.Dispose();
                WorkingPanel.Controls.Clear();
                AdmissionUC admissionUC = new AdmissionUC();
                admissionUC.Dock = DockStyle.Fill;
                Old_UserControl=admissionUC;
                WorkingPanel.Controls.Add(admissionUC);


                label2.ForeColor = Color.FromArgb(253, 197, 0);
                label3.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label9.ForeColor = Color.White;
                label10.ForeColor = Color.White;
                label12.ForeColor = Color.White;
                Terminationbtn_pnl.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Old_UserControl.Dispose();
            WorkingPanel.Controls.Clear();
            StudentRectify studentRectify = new StudentRectify();
            studentRectify.Dock = DockStyle.Fill;
            Old_UserControl= studentRectify;
            WorkingPanel.Controls.Add(studentRectify);
            

            label2.ForeColor = Color.White;
            label3.ForeColor = Color.FromArgb(253, 197, 0);
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label9.ForeColor = Color.White;
            label10.ForeColor = Color.White;
            label12.ForeColor = Color.White;
            Terminationbtn_pnl.ForeColor = Color.White;

        }


    }
}
