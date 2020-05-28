using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2HugoApp
{
    public partial class Form1 : Form
    {
        private UserControl current = null;

        public Form1()
        {
            InitializeComponent();
            current = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new CrudAddress();
            current.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(current, 1, 1);
            tableLayoutPanel1.SetColumnSpan(current, 4);
            tableLayoutPanel1.SetRowSpan(current, 3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new CrudUsers();
            current.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(current, 1, 1);
            tableLayoutPanel1.SetColumnSpan(current, 4);
            tableLayoutPanel1.SetRowSpan(current, 3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new CrudBusiness();
            current.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(current, 1, 1);
            tableLayoutPanel1.SetColumnSpan(current, 4);
            tableLayoutPanel1.SetRowSpan(current, 3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new CrudProduct();
            current.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(current, 1, 1);
            tableLayoutPanel1.SetColumnSpan(current, 4);
            tableLayoutPanel1.SetRowSpan(current, 3);
        }

        private void button2_click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new CrudOrders();
            current.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(current, 1, 1);
            tableLayoutPanel1.SetColumnSpan(current, 4);
            tableLayoutPanel1.SetRowSpan(current, 3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Program.activeUser.Type == false) //User normal 
            {
                button4.Visible = false;
                button3.Visible = false;
                button5.Visible = false;
            }
        }
    }
}