using System;
using System.Windows.Forms;

namespace Parcial2HugoApp
{
    public partial class CrudBusiness : UserControl
    {
        public CrudBusiness()
        {
            InitializeComponent();
        }

        string idNegocio;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") ||
                textBox2.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacíos");
            }
            else
            {
                try
                {
                    ConnectionDB.ExecuteNonQuery($"DELETE FROM business WHERE idBusiness = {idNegocio}");

                    MessageBox.Show("Eliminado exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se ha producido un error");
                }   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals("") ||
                textBox4.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacíos");
            }
            else
            {
                try
                {
                    ConnectionDB.ExecuteNonQuery("INSERT INTO business(name, description) VALUES( " +
                                                 $"'{textBox3.Text}'," +
                                                 $"'{textBox4.Text}')");
                    MessageBox.Show("Agregado exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }

        private void CrudBusiness_Load(object sender, EventArgs e)
        {
            var dt = ConnectionDB.executeQuery("SELECT * FROM business");
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            { 
                idNegocio = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }
    }
}