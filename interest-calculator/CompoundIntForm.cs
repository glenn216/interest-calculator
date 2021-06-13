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
    public partial class CompoundIntForm : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private readonly PrivateFontCollection fonts = new PrivateFontCollection();
        readonly Font font;
        public CompoundIntForm()
        {
            InitializeComponent();

            byte[] fontData = Properties.Resources.NotoSans_Regular;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.NotoSans_Regular.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.NotoSans_Regular.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            font = new Font(fonts.Families[0], 12.0F);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            label1.Font = font;
            label3.Font = font;
            textBox4.Font = font;
            cpComboBox.Text = "Annually";
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            int p, n;
            float r, t, result;
            panel2.Visible = true;

            p = Convert.ToInt32(principalTextBox.Text);
            t = Convert.ToSingle(timeTextBox.Text);
            r = (float)Convert.ToSingle(rateTextBox.Text) / 100;

            if (cpComboBox.Text == "Annually")
            {
                n = 1;
                result = Calculate.CompoundInterest(p, n, r, t);
                Output(p, n, r, t, result);
            }
            else if (cpComboBox.Text == "Semi-Annually")
            {
                n = 2;
                result = Calculate.CompoundInterest(p, n, r, t);
                Output(p, n, r, t, result);
            }
            else if (cpComboBox.Text == "Quarterly")
            {
                n = 4;
                result = Calculate.CompoundInterest(p, n, r, t);
                Output(p, n, r, t, result);
            }
            else if (cpComboBox.Text == "Every 2 months")
            {
                n = 6;
                result = Calculate.CompoundInterest(p, n, r, t);
                Output(p, n, r, t, result);
            }
            else if (cpComboBox.Text == "Every Month")
            {
                n = 12;
                result = Calculate.CompoundInterest(p, n, r, t);
                Output(p, n, r, t, result);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            principalTextBox.ResetText();
            rateTextBox.ResetText();
            cpComboBox.Text = "Annually";
            timeTextBox.ResetText();
            textBox4.ResetText();
            panel2.Visible = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Output(int p, int n, float r, float t, float result)
        {
            textBox4.AppendText("P = " + Convert.ToString(p));
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText("r = " + Convert.ToString(r));
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText("n = " + Convert.ToString(n));
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText("t = " + Convert.ToString(t));
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText("Future Value of Compound Interest");
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText("Equation: ");
            textBox4.AppendText("F = P(1 + r/n)" + "\u207F" + "\u1D57");
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText("Answer: \x20B1" + Convert.ToString(result));
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
