using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommApp
{
    public partial class ServerForm : Form
    {
        // Свойства

        // Название сервера
        public string NameServer { get { return tbName.Text; } set { tbName.Text = value; } }

        // IP Адрес
        public string AdressIP { get { return tbAdress.Text; } set { tbAdress.Text = value; } }

        // База Данных
        public string DB_Name { get { return tbDB.Text; } set { tbDB.Text = value; } }

        // Порт
        public string Port { get { return tbPort.Text; } set { tbPort.Text = value; } }

        // Пользователь
        public string User { get { return tbUser.Text; } set { tbUser.Text = value; } }

        // Пароль
        public string Pass { get { return tbPassword.Text; } set { tbPassword.Text = value; } }

        //Показать пароль
        private bool ViewPass { get { return cbViewPass.Checked; } set { cbViewPass.Checked = value; } }

        // Таймаут
        public string Timeout { get { return tbTimeout.Text; } set { tbTimeout.Text = value; } }


        public ServerForm()
        {
            InitializeComponent();
        }

        private void cbViewPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbViewPass.Checked)
            {
                tbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {

        }

        private void ActivateBattonOk()
        {
            if (string.IsNullOrEmpty(tbName.Text)
                || string.IsNullOrEmpty(tbAdress.Text)
                || string.IsNullOrEmpty(tbPort.Text)
                || string.IsNullOrEmpty(tbDB.Text)
                || string.IsNullOrEmpty(tbUser.Text)
                || string.IsNullOrEmpty(tbPassword.Text)
                || string.IsNullOrEmpty(tbTimeout .Text)
                )
            {
                btOk.Enabled = false;
            }
            else
            {
                btOk.Enabled = true;
            }
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            ActivateBattonOk();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            ActivateBattonOk();
        }

        private void tbAdress_TextChanged(object sender, EventArgs e)
        {
            ActivateBattonOk();
        }

        private void tbPort_TextChanged(object sender, EventArgs e)
        {
            ActivateBattonOk();
        }

        private void tbDB_TextChanged(object sender, EventArgs e)
        {
            ActivateBattonOk();
        }

        private void tbUser_TextChanged(object sender, EventArgs e)
        {
            ActivateBattonOk();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            ActivateBattonOk();
        }

        private void tbTimeout_TextChanged(object sender, EventArgs e)
        {
            ActivateBattonOk();
        }
    }
}
