using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database;

namespace MyList
{
    public partial class FormLoginRegister : Form
    {
        public FormLoginRegister()
        {
            InitializeComponent();

            // We are going to show the login form, so the user cannot click on the button...
            resetThings(true);
        }

        // This function helps to reset textboxs/labels/buttons.
        private void resetThings(bool changeButtons)
        {
            if (changeButtons)
            {
                labelLOGINREGISTER.Text = "Login";
                buttonLOGINREGISTER.Text = "Login";

                buttonLOGIN.Enabled = false;
                buttonREGISTER.Enabled = true;
            }
            else
            {
                labelLOGINREGISTER.Text = "Register";
                buttonLOGINREGISTER.Text = "Register";

                buttonLOGIN.Enabled = true;
                buttonREGISTER.Enabled = false;
            }

            textboxUSER.Text = "";
            textboxPASS.Text = "";
        }

        private void buttonLOGINREGISTER_Click(object sender, EventArgs e)
        {
            string user = textboxUSER.Text.Trim();
            string password = textboxPASS.Text.Trim();

            if (user != "" && password != "")
            {
                if (buttonLOGINREGISTER.Text == "Register") // Register
                {
                    // If the user exists.
                    if (DB_Data.UserExists(user))
                    {
                        MessageBox.Show("The user is already taken.", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (password.Length < 3) // If the password have less than 3 characters.
                    {
                        MessageBox.Show("The password is too weak.", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else // Everything is OK.
                    {
                        // Register the user in the database.
                        DB_Data.CreateUser(user, password);

                        resetThings(true);

                        MessageBox.Show("User registered!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else // Login
                {
                    // If the user exists.
                    if (DB_Data.UserExists(user))
                    {
                        // If the user and password match.
                        if (DB_Data.VerifyLogin(user, password))
                        {
                            // With this we save the UserID because we need to have easy access to that ID (creation of notes or
                            // another things).
                            Properties.Settings.Default.UserID = DB_Data.BringUserID(user);
                            Properties.Settings.Default.Save();

                            // Show the main form.
                            FormMain form = new FormMain();
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("User/Password invalid.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The user doesn't exists.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("User or Password empty.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLOGIN_Click(object sender, EventArgs e)
        {
            resetThings(true);
        }

        private void buttonREGISTER_Click(object sender, EventArgs e)
        {
            resetThings(false);
        }

        private void menuLOGIN_MINIMIZAR_Click(object sender, EventArgs e)
        {
            // Minimize the window app.
            WindowState = FormWindowState.Minimized;
        }

        private void menuLOGIN_SALIR_Click(object sender, EventArgs e)
        {
            // In case that the user just miss-click the button.
            if (MessageBox.Show("¿Do you really want to exit?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
