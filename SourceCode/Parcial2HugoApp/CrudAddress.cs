using System;
using System.Windows.Forms;

namespace Parcial2HugoApp
{
    public partial class CrudAddress : UserControl
    {
        public CrudAddress()
        {
            InitializeComponent();
        }

        string idAddress;

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Equals(""))
            {
                MessageBox.Show("Seleccione una dirección");
            }
            else
            {
                try
                {
                    ConnectionDB.ExecuteNonQuery($"DELETE FROM address WHERE idAddress = {idAddress}");

                    MessageBox.Show("Eliminado exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se ha producido un error");
                }   
            }
        }

        private void CrudAddress_Load(object sender, EventArgs e)
        {
            if (Program.activeUser.Type) //User admin
            {
                tabControl1.TabPages.RemoveByKey("tabPage2");
                button4.Visible = false;
                button1.Visible = false;
                label6.Visible = false;
                textBox8.Visible = false;
                dataGridView1.Visible = false;
            }
             var dt = ConnectionDB.executeQuery($"SELECT * FROM address WHERE idUser " +
                                                $"= {Program.activeUser.Id.ToString()}");
            dataGridView1.DataSource = dt;
            string tipouser;
            if (Program.activeUser.Type)
            {
                tipouser = "Administrador";
            }
            else
            {
                tipouser = "Cliente";
            }
            textBox2.Text = Program.activeUser.Name;
            textBox3.Text = Program.activeUser.Nickname;
            textBox4.Text = Program.activeUser.Password;
            textBox5.Text = tipouser;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0) 
            { 
                idAddress = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Equals(""))
            {
                MessageBox.Show("Debe seleccionar una dirección");
            }
            else
            {
                try
                {
                    ConnectionDB.ExecuteNonQuery($"UPDATE address SET address = '{textBox8.Text}'" +
                                                 $"WHERE idAddress = {idAddress}");

                    MessageBox.Show("Modificado exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se ha producido un error");
                }   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if (textBox6.Text.Equals(""))
           {
            MessageBox.Show("No se pueden dejar campos vacíos");
           }
           else
           {
               try
               {
                   ConnectionDB.ExecuteNonQuery("INSERT INTO address(idUser, address) VALUES( " +
                                                $"'{Program.activeUser.Id.ToString()}'," +
                                                $"'{textBox6.Text}')");
                   MessageBox.Show("Agregado exitosamente");
               }
               catch (Exception ex)
               {
                   MessageBox.Show("Ha ocurrido un error");
               }
           }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionDB.ExecuteNonQuery($"UPDATE appuser SET password = '{textBox7.Text}' " +
                                             $"WHERE idUser = {Program.activeUser.Id.ToString()}");
                MessageBox.Show("Su nueva contraseña se ha guardado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error");
            }
            
        }
    }
}