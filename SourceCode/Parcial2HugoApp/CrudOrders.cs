using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial2HugoApp
{
    public partial class CrudOrders : UserControl
    {
        public CrudOrders()
        {
            InitializeComponent();
        }

        private string idOrder;

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

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
                    string direccion = "SELECT idAddress FROM address " +
                                       $"WHERE address = '{comboBox1.SelectedItem}'";
                    
                    ConnectionDB.ExecuteNonQuery("INSERT INTO apporder(createDate, idProduct, idAddress) " +
                                                 "VALUES( " +
                                                 $"CURRENT_DATE, " +
                                                 $"'{textBox2.Text}'," +
                                                 $"'{direccion}')");
                    MessageBox.Show("Agregado exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idOrder = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void Orders_load(object sender, EventArgs e)
        {
            if (Program.activeUser.Type)
            {
                tabControl1.TabPages.RemoveByKey("tabPage2");
                textBox3.Visible = false;
                button2.Visible = false;
                var dt = ConnectionDB.executeQuery("SELECT * FROM apporder");
                dataGridView1.DataSource = dt;
            }
            else
            {
                var dt = ConnectionDB.executeQuery($"SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address "+
                "FROM apporder ao, address ad, PRODUCT pr, appuser au " +
                "WHERE ao.idProduct = pr.idProduct "+
                "AND ao.idAddress = ad.idAddress "+
                "AND ad.idUser = au.idUser "+
                $"AND au.idUser = {Program.activeUser.Id.ToString()};");
                dataGridView1.DataSource = dt;

                var det = ConnectionDB.executeQuery($"SELECT * FROM product");
                dataGridView2.DataSource = det;

                var address = ConnectionDB.executeQuery("SELECT * FROM address " +
                                                        $"WHERE idUser = {Program.activeUser.Id.ToString()}");
                var addressCombo = new List<string>();

                foreach (DataRow dr in address.Rows)
                {
                    addressCombo.Add(dr[0].ToString());
                }
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }
    }
}