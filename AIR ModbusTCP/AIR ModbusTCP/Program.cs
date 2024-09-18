using AIR_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIR_ModbusTCP
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new SQLiteManage().ConnectPath("Data Source="+Application.StartupPath+"\\DataBase\\KYJTCP;Pooling=true;FailIfMissing=false");
            FrmLogin frmLogin = new FrmLogin();
            if (frmLogin.ShowDialog()==DialogResult.OK)
            {
                Application.Run(new FrmMain());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
