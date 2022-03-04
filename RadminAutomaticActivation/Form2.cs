using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadminAutomaticActivation
{
    public partial class Form2 : Form
    {
        private string pass;
        public Form2() {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            try {
                if ((e.KeyChar == ((char)Keys.Back)) && (pass != "") && (pass != null)) {
                    pass = pass.Remove(pass.Length - 1);
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length);
                    textBox1.SelectionStart = textBox1.Text.Length;
                    return;
                }
            } catch {
                return;
            }
            if ((e.KeyChar == ((char)Keys.Enter)) || (e.KeyChar == ((char)Keys.Escape))) {
                button1.PerformClick();
            } else
            if (e.KeyChar != ((char)Keys.Back)) {
                pass += e.KeyChar;
                e.KeyChar = '*';
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            if (pass == "Eghfdktybt!") {
                CallBackMy.callbackEventHandler(true);
            }
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e) {
            pass = null;
        }
    }
}
