using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class L_or_R : Form
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

        private void L_or_R_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        public L_or_R()
        {
            // Optimize form initialization to prevent flickering
            this.SuspendLayout();
            
            InitializeComponent();
            
            // Set double buffering and other visual properties
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                         ControlStyles.UserPaint | 
                         ControlStyles.DoubleBuffer | 
                         ControlStyles.ResizeRedraw, true);
            
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

        private void Close_btn_Click(object sender, EventArgs e)
        {
            WControls.exit();
        }

        private void L_or_R_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    Pass_tbx.PasswordChar = '\0';
                }
                else
                {
                    Pass_tbx.PasswordChar = '*';
                }
            }
            catch (Exception ex)
            {
                WControls.ShowToasterMsg("ERROR", "Something Went Wrong", ex.Message);
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            UName_tbx.Text = Pass_tbx.Text = null;
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            string Sql_Query;
            WControls.DBConOpen();
            SqlCommand cmd;
            SqlDataReader dataReader;
            Sql_Query = "Select * from Users where UserName='"+ UName_tbx.Text +"' and Password='"+ Pass_tbx.Text +"'";
            SqlDataAdapter adapter = new SqlDataAdapter(Sql_Query, WControls.connection);
            DataTable table = new DataTable();
            adapter.Fill(table);

            cmd = new SqlCommand(Sql_Query, WControls.connection);
            dataReader = cmd.ExecuteReader();
            bool userFound = false;
            while (dataReader.Read())
            {
                userFound = true;
            }
            if (!userFound)
            {
                WControls.ShowToasterMsg("ACTION NEEDED", "USER NOT FOUND", "Register / ADD New User!");
                WControls.DBConClose();
            }
            else
            {
                string Name, UserType;
                byte [] DP;
                Name = table.Rows[0][0].ToString();
                UserType = table.Rows[0][3].ToString();

                DP = (byte[])table.Rows[0][6];

                // Optimize form transition to prevent flickering
                this.SuspendLayout();
                this.Hide();
                
                Dashboard dashboard = new Dashboard(Name, UserType, DP);
                dashboard.Show();
                
                this.ResumeLayout();
                WControls.ShowToasterMsg("SUCCESS", "Login Successfull", "User Loged in Successfully");
                WControls.DBConClose();
                //this.Close();

            }
        }

        private void RegBtn_lbl_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }
    }
}
