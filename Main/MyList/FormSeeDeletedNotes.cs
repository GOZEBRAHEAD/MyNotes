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
using Entities;

namespace MyList
{
    public partial class FormSeeDeletedNotes : Form
    {
        // My page method need those variables, so we would create them here.
        private int totalNotes = 0, notesPerPage = 0, actualPage = 0, maxPages = 0;

        // This is the DataTable we use for the datagridview.
        private static DataTable dt = new DataTable();
        private static DataTable dt_aux = new DataTable();

        public FormSeeDeletedNotes()
        {
            InitializeComponent();
        }

        public void updateNotes()
        {
            totalNotes = DB_Data.GetTotalDeletedNotes(Properties.Settings.Default.UserID);
            notesPerPage = 100; // This is because we will show only 100 notes for page.
            actualPage = 1;

            // If we get less notes than the max notes.
            if (totalNotes < notesPerPage)
            {
                // Max pages set to 1.
                maxPages = 1;

                // Blocking those buttons so the user cannot go forward/back.
                buttonPAGE_BACK.Enabled = false;
                buttonPAGE_NEXT.Enabled = false;
            }
            else
            {
                // Max pages set to the value + 1, just to avoid problems with the data showed.
                maxPages = (totalNotes / notesPerPage) + 1;
            }

            // Showing the notes.
            showDeletedNotesByPage(1);
        }

        public void showDeletedNotesByPage(int pageNumber)
        {
            // Obtain data + show it in the datagridview.
            DataSet ds = DB_Data.LoadDeletedNotesByPage(Properties.Settings.Default.UserID, pageNumber);
            dt = ds.Tables[0];
            datagridview_NOTES.DataSource = dt;

            // If the page we sent is 1, set everything to 1, to avoid bugs.
            if (pageNumber == 1)
            {
                actualPage = 1;
                textboxACTUAL_PAGE.Text = "1";
                textoPAGINA_TOTALES.Text = "/ " + maxPages;
            }
        }

        public void udpateSecondaryDataGridView()
        {
            DataSet ds_aux = DB_Data.GetAllDeletedNotes(Properties.Settings.Default.UserID);
            dt_aux = ds_aux.Tables[0];
            datagridviewNOTES_SECONDARY.DataSource = dt_aux;
        }

        private void FormSeeDeletedNotes_Load(object sender, EventArgs e)
        {
            try
            {
                updateNotes();

                // With this we can "escape" from the arrow that let you order (DESC/ASC) all the columns, just to avoid bugs.
                foreach (DataGridViewColumn columna in datagridview_NOTES.Columns)
                {
                    columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                udpateSecondaryDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void datagridview_NOTES_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // We identify what column he clicked to know if he just check some boxes on the datagridview.
            if (e.ColumnIndex == datagridview_NOTES.Columns["Select"].Index && e.RowIndex != -1)
            {
                DataGridViewCheckBoxCell Select = (DataGridViewCheckBoxCell)datagridview_NOTES.Rows[e.RowIndex].Cells["Select"];
                Select.Value = !(Convert.ToBoolean(Select.Value));
            }
        }

        private void buttonPAGE_NEXT_Click(object sender, EventArgs e)
        {
            // If the user isn't on the first page.
            if (actualPage != maxPages)
            {
                actualPage++;

                int value = actualPage;

                textboxACTUAL_PAGE.Text = Convert.ToString(value);

                showDeletedNotesByPage(value);

                // Lets enable the button to go back.
                if (!buttonPAGE_BACK.Enabled)
                    buttonPAGE_BACK.Enabled = true;
            }
            else // The user is in the first page.
            {
                if (buttonPAGE_NEXT.Enabled)
                    buttonPAGE_NEXT.Enabled = false;
            }
        }

        private void buttonPAGE_BACK_Click(object sender, EventArgs e)
        {
            // If the user isn't on the first page.
            if (actualPage != 1)
            {
                actualPage--;

                int value = actualPage;

                textboxACTUAL_PAGE.Text = Convert.ToString(value);

                showDeletedNotesByPage(value);

                // Lets enable the button to go forward.
                if (!buttonPAGE_NEXT.Enabled)
                    buttonPAGE_NEXT.Enabled = true;
            }
            else // The user is in the first page.
            {
                if (buttonPAGE_BACK.Enabled)
                    buttonPAGE_BACK.Enabled = false;
            }
        }

        private void buttonNOTES_SEARCH_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dv_aux = new DataView(dt_aux.Copy());
                dv_aux.RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%'",
                    comboboxNOTES_CATEGORIES.Text.Trim(), textboxNOTES_SEARCH.Text.Trim());

                datagridview_NOTES.DataSource = dv_aux;

                actualPage = 1;
                textboxACTUAL_PAGE.Text = "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void buttonNOTES_CANCEL_Click(object sender, EventArgs e)
        {
            updateNotes();
            textboxNOTES_SEARCH.Text = "";
        }

        private void textboxACTUAL_PAGE_TextChanged(object sender, EventArgs e)
        {
            // If the user write something.
            if (textboxACTUAL_PAGE.Text != "")
            {
                // Save the value of the page writed.
                int pageWrited = Convert.ToInt32(textboxACTUAL_PAGE.Text);

                // If the page writed is more than the max pages or if the page writed is (less or equal) to zero.
                if (pageWrited > maxPages || pageWrited <= 0)
                {
                    // Reset the actualPage.
                    actualPage = 1;
                    textboxACTUAL_PAGE.Text = "1";
                    showDeletedNotesByPage(actualPage);
                }
                else // If pageWrited it's between 1 and max pages.
                {
                    // If pageWrited is not the actual page...
                    if (pageWrited != actualPage)
                    {
                        actualPage = pageWrited;
                        showDeletedNotesByPage(actualPage);

                        // Enable the buttons (forward and back) so the user can click them.
                        if (actualPage > 1 && actualPage < maxPages)
                        {
                            buttonPAGE_BACK.Enabled = true;
                            buttonPAGE_NEXT.Enabled = true;
                        }
                        else
                        {
                            if (actualPage == 1)
                            {
                                buttonPAGE_BACK.Enabled = false;
                                buttonPAGE_NEXT.Enabled = true;
                            }
                            else if (actualPage == maxPages)
                            {
                                buttonPAGE_BACK.Enabled = false;
                                buttonPAGE_NEXT.Enabled = true;
                            }
                        }
                    }
                }
            }
        }

        private void textboxACTUAL_PAGE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void buttonCLOSE_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonRESTORE_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Do you want to restore those notes?", "Restoring notes",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in datagridview_NOTES.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Select"].Value))
                        {
                            int noteID = Convert.ToInt32(row.Cells["ID"].Value);

                            if (DB_Data.RestoreNote(noteID) != 1)
                            {
                                MessageBox.Show("This note cannot be restored.", "Notes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    updateNotes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
