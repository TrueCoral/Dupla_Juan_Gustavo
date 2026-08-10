using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace palindromo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btnTamanho_Click(object sender, EventArgs e)
        {
            lblTotalCaracteres.Text = txtFrase.Text.Length.ToString();
        }

        private void btnInverter_Click(object sender, EventArgs e)
        {
            string frase = txtFrase.Text;
            string invertida = "";

            for (int i = frase.Length - 1; i >= 0; i--)
            {
                invertida += frase[i];
            }

            lblInvertida.Text = invertida;
        }

        private void btnRetirarEspacos_Click(object sender, EventArgs e)
        {
            lblSemEspacos.Text = txtFrase.Text.Replace(" ", "");
        }

        private void btnVogais_Click(object sender, EventArgs e)
        {
            string frase = txtFrase.Text.ToLower();
            int a = 0, e2 = 0, i2 = 0, o = 0, u = 0;

            foreach (char c in frase)
            {
                if (c == 'a') a++;
                else if (c == 'e') e2++;
                else if (c == 'i') i2++;
                else if (c == 'o') o++;
                else if (c == 'u') u++;
            }

            lblA.Text = a.ToString();
            lblE.Text = e2.ToString();
            lblI.Text = i2.ToString();
            lblO.Text = o.ToString();
            label15.Text = u.ToString();
        }

        private void btnQuebrarLetra_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (char c in txtFrase.Text)
            {
                listBox1.Items.Add(c.ToString());
            }
        }

        private void btnQuebrarPalavra_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            string[] palavras = txtFrase.Text.Split(' ');

            foreach (string p in palavras)
            {
                listBox2.Items.Add(p);
            }
        }

        private void btnPalindromo_Click(object sender, EventArgs e)
        {
            string original = txtFrase.Text.ToLower().Replace(" ", "");
            string invertida = "";

            for (int i = original.Length - 1; i >= 0; i--)
            {
                invertida += original[i];
            }

            if (original == invertida)
                MessageBox.Show("A frase é um palíndromo!");
            else
                MessageBox.Show("A frase não é um palíndromo.");
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            txtFrase.Text = "";
            lblTotalCaracteres.Text = "";
            lblInvertida.Text = "";
            lblSemEspacos.Text = "";
            lblA.Text = "";
            lblE.Text = "";
            lblI.Text = "";
            lblO.Text = "";
            label15.Text = "";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }
    }
}
