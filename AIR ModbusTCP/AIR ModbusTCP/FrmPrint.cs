using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIR_ModbusTCP
{
    public partial class FrmPrint : Form
    {
        public FrmPrint()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Rectangle rectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            graphics.DrawRectangle(new Pen(Color.Gray), rectangle);
        }


        public FrmPrint(List<string> availableFields)
        {
            InitializeComponent();
            this.Load += FrmPrint_Load;
            foreach (string field in availableFields)
                chklst.Items.Add(field, true);
        }

        void FrmPrint_Load(object sender, EventArgs e)
        {
            rdoAllRows.Checked = true;
            chkFitToPageWidth.Checked = true;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public List<string> GetSelectedColumns()
        {
            List<string> lst = new List<string>();
            foreach (object item in chklst.CheckedItems)
                lst.Add(item.ToString());
            return lst;
        }

        public string PrintTitle
        {
            get { return txtTitle.Text; }
        }

        public bool PrintAllRows
        {
            get { return rdoAllRows.Checked; }
        }

        public bool FitToPageWidth
        {
            get { return chkFitToPageWidth.Checked; }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
