using ExempleSQLApp2;
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

namespace WinFormsApp2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.passField.Size = new Size(this.passField.Size.Width, 61);        }

        private void button1_Click(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.FromArgb(189, 30,136);
        }

        private void closeButton_Click(object sender, EventArgs e)//закрытие окна
        {
            this.Close();         }

        private void closeButton_MouseLeave(object sender, EventArgs e)//меняет цвет при наведении на крестик
        {
            closeButton.ForeColor = Color.White;
        }

        Point lastPoint;
        private void LoginForm_MouseMove(object sender, MouseEventArgs e)//перетаскивание окна
        {
            if(e.Button == MouseButtons.Left)//если нажата левая клавиша мыши
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)//при нажатии мыши(запоминаются текущие ккоординаты)
        {
            lastPoint = new Point(e.X, e.Y);//устанавливаем координаты
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //получили данные от пользователя
            String loginUser = loginField.Text;
            String passUser = passField.Text;

            DB db = new DB();

            DataTable table = new DataTable();//объект что-то вроде массива или таблицы для работы с данными

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP",db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Yes");
            }
            else
            {
                MessageBox.Show("No");
            }

        }
    }
}
