using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial2HugoApp
{
    public partial class CrudUsers : UserControl
    {
        public CrudUsers()
        {
            InitializeComponent();
        }
        string idUser;

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            { 
                idUser = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox1.SelectedItem= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") ||
                textBox2.Text.Equals("") ||
                textBox3.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacíos");
            }
            else
            {
                try
                {
                    ConnectionDB.ExecuteNonQuery($"DELETE FROM appuser WHERE idUser = {idUser}");

                    MessageBox.Show("Eliminado exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se ha producido un error");
                }   
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Equals("") ||
                textBox4.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacíos");
            }
            else
            {
                try
                {
                    bool tipouser = false;
                    if (comboBox2.SelectedIndex == 0)
                    {
                        tipouser = true;
                    }
                    else
                    {
                        tipouser = false;
                    }

                    ConnectionDB.ExecuteNonQuery($"INSERT INTO appuser(fullname, username, password, userType) " +
                                                 $"VALUES( " +
                                                 $"'{textBox4.Text}'," +
                                                 $"'{textBox5.Text}'," +
                                                 $"'{textBox5.Text}'," +
                                                 $"{tipouser})");
                        
                    
                    MessageBox.Show("Agregado exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }

        private void CrudUsers_Load(object sender, EventArgs e)
        {
             var dt = ConnectionDB.executeQuery("SELECT * FROM appuser");
                        dataGridView1.DataSource = dt;
        }
    }
    
}