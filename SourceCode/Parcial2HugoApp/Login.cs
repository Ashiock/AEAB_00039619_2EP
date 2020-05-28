using System;
using System.Windows.Forms;

namespace Parcial2HugoApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = $"SELECT EXISTS (SELECT * FROM appuser WHERE username = '{textBox1.Text}' " +
                               $"AND password = '{textBox2.Text}')";
                var dt = ConnectionDB.executeQuery(query);
                var dr = dt.Rows[0][0];
                if ((bool) dr)
                {
                    string quer = $"SELECT * FROM appuser WHERE username = '{textBox1.Text}' " +
                                  $"AND password = '{textBox2.Text}'";
                    
                    var dte = ConnectionDB.executeQuery(quer);

                    Program.activeUser.Id = Convert.ToInt32(dte.Rows[0][0]);
                    Program.activeUser.Name = Convert.ToString(dte.Rows[0][1]);
                    Program.activeUser.Nickname = Convert.ToString(dte.Rows[0][2]);
                    Program.activeUser.Password = Convert.ToString(dte.Rows[0][3]);
                    Program.activeUser.Type =  Convert.ToBoolean(dte.Rows[0][4]);
                    
                    this.Hide();
                    new Form1().Show();
                }
                else
                {
                    MessageBox.Show("La combinación de usuario y contraseña no existe");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ha ocurrido un Error");
            }
        }
    }
}