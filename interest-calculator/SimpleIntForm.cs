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
    public partial class SimpleIntForm : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private readonly PrivateFontCollection fonts = new PrivateFontCollection();
        readonly Font font;
        public SimpleIntForm()
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
            timeComboBox.Text = "Years";
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            int p;
            float r, t, s, result;
            panel2.Visible = true;

            p = Convert.ToInt32(principalTextBox.Text);
            r = Convert.ToSingle(rateTextBox.Text) / 100;
            
            if (timeComboBox.Text == "Years")
            {  
                t = Convert.ToSingle(timeTextBox.Text);
                s = Calculate.SimpleInterest(p, r, t);
                result = Calculate.SimpleInterestResult(p, r, t);
                Output(p, r, t, s, result);
            }

            else if (timeComboBox.Text == "Months")
            {
                t = Convert.ToSingle(timeTextBox.Text) / 12;
                s = Calculate.SimpleInterest(p, r, t);
                result = Calculate.SimpleInterestResult(p, r, t);
                Output(p, r, t, s, result);
            }

            else if (timeComboBox.Text == "Days")
            {
                t = Convert.ToSingle(timeTextBox.Text) / 365;
                s = Calculate.SimpleInterest(p, r, t);
                result = Calculate.SimpleInterestResult(p, r, t);
                Output(p, r, t, s, result);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            principalTextBox.ResetText();
            rateTextBox.ResetText();
            timeComboBox.Text = "Years";
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
        private void Output(int p, float r, float t, float s, float result)
        {
            textBox4.AppendText("P = " + Convert.ToString(p));
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText("r = " + Convert.ToString(r));
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText("t = " + Convert.ToString(t));
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText("Simple Interest");
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText("Equation: ");
            textBox4.AppendText("I\x209B" + "= Prt");
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText("Answer: \x20B1" + Convert.ToString(s));
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText("Maturity Value of Simple Interest");
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText("Equation: ");
            textBox4.AppendText("F = P (1 + rt)");
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText("Answer: \x20B1" + Convert.ToString(result));
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
