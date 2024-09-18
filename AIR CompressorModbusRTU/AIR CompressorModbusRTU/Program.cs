using kYJBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIR_CompressorModbusRTU
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
            //连接数据库
            new SQLLiteManage().ConnStr("Data Source="+Application.StartupPath+"\\DataBase\\KYJScada;Pooling=true;FailIfMissing=false");
            FrmLogIn frmLogIn = new FrmLogIn();
            if (frmLogIn.ShowDialog()==DialogResult.OK)
            {
                Application.Run(new FraMain());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
