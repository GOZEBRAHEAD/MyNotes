using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyList
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Making the app full screen.
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void OpenForm<MyForm>() where MyForm : Form, new()
        {
            Form form;
            form = panelCENTER_GENERAL.Controls.OfType<MyForm>().FirstOrDefault();

            if (form != null)
            {
                form.Close();
            }

            form = new MyForm();
            form.TopLevel = false;

            panelCENTER_GENERAL.Controls.Add(form);
            panelCENTER_GENERAL.Tag = form;

            form.Dock = DockStyle.Fill;

            form.BringToFront();
            form.Show();
        }

        private void buttonMINIMIZE_Click(object sender, EventArgs e)
        {
            // Minimize the window app.
            WindowState = FormWindowState.Minimized;
        }

        private void buttonCLOSE_Click(object sender, EventArgs e)
        {
            // In case that the user just miss-click the button.
            if (MessageBox.Show("¿Do you really want to exit?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonNOTES_DASHBOARD_Click(object sender, EventArgs e)
        {
            OpenForm<FormDashboard>();
        }

        private void buttonNOTES_CREATE_Click(object sender, EventArgs e)
        {
            OpenForm<FormCreateNotes>();
        }

        private void buttonNOTES_SEE_Click(object sender, EventArgs e)
        {
            OpenForm<FormSeeNotes>();
        }

        private void buttonNOTES_DELETED_Click(object sender, EventArgs e)
        {
            OpenForm<FormSeeDeletedNotes>();
        }

        private void buttonNOTES_FAVOURITE_Click(object sender, EventArgs e)
        {
            OpenForm<FormSeeFavoriteNotes>();
        }

        private void buttonNOTES_LOGOUT_Click(object sender, EventArgs e)
        {
            FormLoginRegister form = new FormLoginRegister();
            form.Show();
            this.Hide();
        }
    }
}
