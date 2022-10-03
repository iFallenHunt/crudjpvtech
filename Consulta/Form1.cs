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

namespace Consulta
{
    public partial class Form1 : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;

        string strSQL;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {

            try
            {
                conexao = new SqlConnection(@"Server=LUCAS\DBCRUD ;Database=crudjpvtech2 ;User Id=sa ;Password = 1234; ");

                strSQL = "INSERT INTO CAD_CLIENTE (NOME, NASCIMENTO, CPF) VALUES (@NOME, @NASCIMENTO, @CPF)";
                 //instanciando o comando que foi passado para o banco
                comando = new SqlCommand(strSQL, conexao);
                //passando os paramentros
                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@NASCIMENTO", txtNascimento.Text);
                comando.Parameters.AddWithValue("@CPF", txtCpf.Text);
                //abertura da conexão
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }


            

        }

        private void BtnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server=LUCAS\DBCRUD ;Database=crudjpvtech2 ;User Id=sa ;Password = 1234; ");

                strSQL = "SELECT * FROM CAD_CLIENTE";

                DataSet ds = new DataSet();

                da = new SqlDataAdapter(strSQL, conexao);
               
                conexao.Open();

                da.Fill(ds);

                dgvDados.DataSource = ds.Tables[0];
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server=LUCAS\DBCRUD ;Database=crudjpvtech2 ;User Id=sa ;Password = 1234; ");

                strSQL = "SELECT * FROM CAD_CLIENTE WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);
                                
                conexao.Open();
                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    txtNome.Text = (string)dr["nome"];
                    txtNascimento.Text = Convert.ToString(dr["nascimento"]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void BtEditar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server=LUCAS\DBCRUD ;Database=crudjpvtech2 ;User Id=sa ;Password = 1234; ");

                strSQL = "UPDATE CAD_CLIENTE SET NOME = @NOME, NASCIMENTO = @NASCIMENTO WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);
                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@NASCIMENTO", txtNascimento.Text);

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server=LUCAS\DBCRUD ;Database=crudjpvtech2 ;User Id=sa ;Password = 1234; ");

                strSQL = "DELETE CAD_CLIENTE WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);
                

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }
    }
}
