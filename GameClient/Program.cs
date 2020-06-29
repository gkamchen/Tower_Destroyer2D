using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    static class Program
    {
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Main main = new Main();

			main.Width = Screen.PrimaryScreen.WorkingArea.Width;
			main.Height = Screen.PrimaryScreen.WorkingArea.Height;

			//main.WindowState = FormWindowState.Maximized;
			main.IsMdiContainer = true;

			Application.Run(main);
		}
    }
}
