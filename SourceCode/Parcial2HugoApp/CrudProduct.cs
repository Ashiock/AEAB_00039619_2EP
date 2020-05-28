using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial2HugoApp
{
    public partial class CrudProduct : UserControl
    {
        public CrudProduct()
        {
            InitializeComponent();
        }

        string idProduct;

        private void CrudProduct_Load(object sender, EventArgs e)
        {
            var dt = ConnectionDB.executeQuery("SELECT * FROM product");
            dataGridView1.DataSource = dt;
            
            var business = ConnectionDB.executeQuery("SELECT name FROM business");
            var businessCombo = new List<string>();

            foreach (DataRow dr in business.Rows)
            {
                businessCombo.Add(dr[0].ToString());
            }
            comboBox2.DataSource = businessCombo;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            { 
                idProduct = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacíos");
            }
            else
            {
                try
                {
                    ConnectionDB.ExecuteNonQuery($"DELETE FROM product WHERE idProduct = {idProduct}");

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
            var query = ConnectionDB.executeQuery($"SELECT idBusiness FROM business WHERE name = '{comboBox2.SelectedItem}'");
            var dr = query.Rows[0][0];

                
             if (textBox2.Text.Equals(""))
             {
                 MessageBox.Show("No se pueden dejar campos vacíos");
             }
             else
             {
                 try
                 {
                     
                     ConnectionDB.ExecuteNonQuery("INSERT INTO product(idBusiness, name)" +
                                                  "VALUES(" +
                                                  $"{dr}," +
                                                  $"'{textBox2.Text}')");
                     
                     MessageBox.Show("Agregado exitosamente");
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Ha ocurrido un error");
                 }
             }
        }
    }
}