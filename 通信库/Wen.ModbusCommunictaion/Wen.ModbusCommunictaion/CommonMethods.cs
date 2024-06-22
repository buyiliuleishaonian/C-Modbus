using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wen.ModbusCommunictaion
{
    public  class CommonMethods
    {
        /// <summary>
        /// ͨ��д����־�ķ���
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="index"></param>
        /// <param name="log"></param>
        public static void AddLog(ListView listView, int index, string log)
        {
            if (listView.InvokeRequired)
            {
                listView.Invoke(new Action<ListView, int, string>(AddLog), listView, index, log);
            }
            else
            {
                ListViewItem listViewItem = new ListViewItem("  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), index);
                listViewItem.SubItems.Add(log);
                //��֤���µ���־��������
                listView.Items.Add(listViewItem);
                listView.Items[listView.Items.Count - 1].EnsureVisible();
            }          
        }
    }
}
