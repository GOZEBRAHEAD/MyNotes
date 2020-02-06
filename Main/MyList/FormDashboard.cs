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
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            updateData();
        }

        public void updateData()
        {
            int id = Properties.Settings.Default.UserID;

            labelNOTES_TOTALCREATED.Text = Convert.ToString(DB_Data.GetTotalNotes(id));
            labelNOTES_FAVORITES.Text = Convert.ToString(DB_Data.GetTotalFavoriteNotes(id));
            labelNOTES_DELETED.Text = Convert.ToString(DB_Data.GetTotalDeletedNotes(id));
            labelNOTES_USERSCREATED.Text = Convert.ToString(DB_Data.GetTotalUsersCreated());
        }
    }
}
