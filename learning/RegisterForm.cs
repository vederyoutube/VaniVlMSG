using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace learning
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            this.label2.Text = "QQ!";
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            this.label2.Text = "X";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        Point lastPoint;
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (this.NameBox.Text == "" || this.MailBox.Text == "" || this.PassBox.Text == "")
            {
                MessageBox.Show("Wrong values");
                return;
            }
            if (checkLogin())
                return;
            DataBase db = new DataBase();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `mail`) VALUE (@login, @pass, @mail)", db.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = this.NameBox.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = this.PassBox.Text;
            command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = this.MailBox.Text;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Secsesfull regristrated!");
                this.Hide();
                Program.LW.Show();
            }
            else MessageBox.Show("something went wrong!");
            db.closeConnection();
        }

        public Boolean checkLogin()
        {
            DataBase db = new DataBase();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @lU", db.getConnection());
            command.Parameters.Add("@lU", MySqlDbType.VarChar).Value = NameBox.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("login claimed");
                return true;
            }
            else
                return false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.LW.Show();
        }
    }
}
