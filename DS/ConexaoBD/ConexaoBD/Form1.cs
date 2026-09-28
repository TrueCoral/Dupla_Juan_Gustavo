using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ConexaoBD
{
    public partial class Form1 : Form
    {
        SQLconnection conecta = new SQLconnection();
            (@"Data Source=LAPTOP-V9M1ME3V;Initial Catalog=BD_Funcionarios_CS;Integrated Security=True");
        SqlCommand comando = new SqlCommand();
        SqlDataReader dr;
        DataTable ds = new DataTable("TB_funcionarios");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conecta.Open();
            cmd.Connection = conecta;

            try
            {
                MessageBox.Show("A conexão foi obtida com sucesso.");
            }
            catch
            {
                MessageBox.Show("Não foi possível obter a conexão. Veja o log de erros.");
            }
            cmd.CommandType = CommandType.Text;
            carrega_dados();

            if (ds.Rows.Count <= 0)
            {
                MessageBox.Show("Tabela sem registros, cadastre um ", "Tabela Vazia");
            }
            else
            {
                navega();
                labelFinal.Text = Convert.ToString(ds.Rows.Count);

            }
           
    }
        private void navega()
        {
            lblID.Text = Convert.ToString(ds.Rows[pos]["id_funcionario"]);
            lblNome.Text = Convert.ToString(ds.Rows[pos]["nome"]);
            lblFone.Text = Convert.ToString(ds.Rows[pos]["fone"]);
            lblUF.Text = Convert.ToString(ds.Rows[pos]["uf"]);
        }
        private void carrega_dados()
        {
            cmd.CommandText = "select * from Funcionario";
            dr = cmd.ExecuteReader();
            ds.Clear();
            ds.Load(dr);
            pos = 0;
            label4.Text = Convert.ToString(ds.Rows.Count);
            dataGridView1.DataSource = ds;
        }

        private void botoes(Boolean ativar)
        {
            button1.Enabled = ativar;
            button2.Enabled = ativar;
            button3.Enabled = ativar;
            button4.Enabled = ativar;
            button5.Enabled = ativar;
            button6.Enabled = !ativar;
            button7.Enabled = ativar;
            button8.Enabled = ativar;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ds.Rows.Count <= 0)
            {
                lblID.Text = Convert.ToString("1");
            }
            else
            {
                codigo = Convert.ToInt32(ds.Rows[ds.Rows.Count - 1]["id_funcionario"]);
                lblNome.Clear();
                lblFone.Clear();
                lblUF.Clear();
                lblID.Focus();
            }
            botoes(false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conecta;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into TB_Funcionario (id_funcionario,nome,fone,uf) " +
                "Values (@id_funcionario,@nome,@fone,@uf)";

            cmd.Parameters.Add(new SqlParameter("@id_funcionario", this.lblID.Text));
            cmd.Parameters.Add(new SqlParameter("@nome", this.lblNome.Text));
            cmd.Parameters.Add(new SqlParameter("@fone", this.lblFone.Text));
            cmd.Parameters.Add(new SqlParameter("@uf", this.lblUF.Text));

            cmd.ExecuteNonQuery();
            MessageBox.Show("Dados cadastrados com sucesso", "Inclusão");
            carrega_dados();
            navega();
            botoes(true);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            botoes(true);
            // SqlConnection conecta = Conexao.obterConexao();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conecta;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "update Funcionario set nome=@nome,fone=@fone,uf=@uf where id_funcionario=@id_funcionario";

            cmd.Parameters.AddWithValue("@id_funcionario", lblID.Text);
            cmd.Parameters.AddWithValue("@nome", lblNome.Text);
            cmd.Parameters.AddWithValue("@fone", lblFone.Text);
            cmd.Parameters.AddWithValue("@uf", lblUF.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Dados atualizados com sucesso", "Atualização");
            carrega_dados();
            navega();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conecta;
            cmd.CommandType = CommandType.Text;

            if (MessageBox.Show("Tem certeza que deseja excluir este registro?", "Exclusão",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cmd.CommandText = ("delete from TB_Funcionario where id_funcionario = @id_funcionario");
                cmd.Parameters.Add(new SqlParameter("@id_funcionario", this.lblID.Text));
                cmd.ExecuteNonQuery();
                carrega_dados();
                navega();
                botoes(true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pos = 0;
            navega();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pos > 0)
            {
                pos -= 1;
            }
            else
            {
                MessageBox.Show("Primeiro registro", "Mensagem");
                pos = 0;
            }
            navega();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pos < ds.Rows.Count - 1)
            {
                pos += 1;
            }
            else
            {
                MessageBox.Show("Não há mais registros", "Mensagem");
                pos = ds.Rows.Count - 1;
            }
            navega();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pos = ds.Rows.Count - 1;
            navega();
        }
    }
