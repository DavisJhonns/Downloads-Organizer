using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadsOrganizer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var view = new MainForm();
            var service = new FileOrganizerService();
            var presenter = new OrganizerPresenter(view, service);
            Application.Run(view);
        }
    }
}
