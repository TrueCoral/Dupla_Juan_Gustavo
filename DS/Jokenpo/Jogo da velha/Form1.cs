using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_velha
{
    public partial class Form1 : Form
    {
        int pontosVoce = 0;
        int pontosBob = 0;

        Random aleatorio = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            string jogador = cmbJogada.Text;

            if (jogador == "")
            {
                MessageBox.Show("Escolha Pedra, Papel ou Tesoura");
                return;
            }

            int numero = aleatorio.Next(1, 4);

            string Bob = "";

            if (numero == 1)
            {
                Bob = "Pedra";
            }
            else if (numero == 2)
            {
                Bob = "Papel";
            }
            else
            {
                Bob = "Tesoura";
            }

            lblVoce.Text = "Você: " + jogador;
            lblBob.Text = "Bob: " + Bob;

            if (jogador == Bob)
            {
                lblResultado.Text = "EMPATE!";
            }
            else if (jogador == "Pedra" && Bob == "Tesoura")
            {
                lblResultado.Text = "VOCÊ GANHOU!";
                pontosVoce++;
            }
            else if (jogador == "Papel" && Bob == "Pedra")
            {
                lblResultado.Text = "VOCÊ GANHOU!";
                pontosVoce++;
            }
            else if (jogador == "Tesoura" && Bob == "Papel")
            {
                lblResultado.Text = "VOCÊ GANHOU!";
                pontosVoce++;
            }
            else
            {
                lblResultado.Text = "VOCÊ PERDEU!";
                pontosBob++;
            }

            lblPlacar.Text = "Você: " + pontosVoce + " | Bob: " + pontosBob;

            string resultado = lblResultado.Text;

            Historico.Items.Add(
                "Você: " + jogador +
                " | Bob: " + Bob +
                " | " + resultado
            );
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
          Historico.Items.Clear();
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            pontosVoce = 0;
            pontosBob = 0;

            lblVoce.Text = "Você:";
            lblBob.Text = "Bob:";
            lblResultado.Text = "Resultado";
            lblPlacar.Text = "Você: 0 | Bob: 0";

            cmbJogada.SelectedIndex = -1;

            Historico.Items.Clear();
        }
    }
}
