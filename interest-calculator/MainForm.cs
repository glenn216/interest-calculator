using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interest_calculator
{
    public partial class MainForm : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private readonly PrivateFontCollection fonts = new PrivateFontCollection();
        readonly Font font;
        public MainForm()
        {
            InitializeComponent();

            byte[] fontData = Properties.Resources.NotoSans_Regular;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.NotoSans_Regular.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.NotoSans_Regular.Length, IntPtr.Zero, ref dummy); ;
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            font = new Font(fonts.Families[0], 12.0F, FontStyle.Bold);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            label1.Font = font;
            containerPanel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            containerPanel.Controls.Clear();
            containerPanel.Visible = true;
            SimpleIntForm simpleIntForm = new SimpleIntForm
            {
                TopLevel = false,
                AutoScroll = true
            };
            containerPanel.Controls.Add(simpleIntForm);
            simpleIntForm.FormBorderStyle = FormBorderStyle.None;
            simpleIntForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            containerPanel.Controls.Clear();
            containerPanel.Visible = true;
            CompoundIntForm compoundIntForm = new CompoundIntForm
            {
                TopLevel = false,
                AutoScroll = true
            };
            containerPanel.Controls.Add(compoundIntForm);
            compoundIntForm.FormBorderStyle = FormBorderStyle.None;
            compoundIntForm.Show();
        }
    }
}
