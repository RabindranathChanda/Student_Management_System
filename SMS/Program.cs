using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Optimize startup to reduce flickering
            try
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
            }
            catch
            {
                // Ignore if HighDpiMode is not available in older .NET versions
            }
            
            // Create and configure the main form with optimized initialization
            L_or_R mainForm = new L_or_R();
            
            // Show the main form
            mainForm.Show();
            
            Application.Run(mainForm);
        }
    }
}
