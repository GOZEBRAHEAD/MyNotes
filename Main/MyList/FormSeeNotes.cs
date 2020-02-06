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
    public partial class FormSeeNotes : Form
    {
        // My page method need those variables, so we would create them here.
        private int totalNotes = 0, notesPerPage = 0, actualPage = 0, maxPages = 0;

        // This is the DataTable we use for the datagridview.
        private static DataTable dt = new DataTable();
        private static DataTable dt_aux = new DataTable();

        public FormSeeNotes()
        {
            InitializeComponent();
        }

        public void updateNotes()
        {
            totalNotes = DB_Data.GetTotalNotes(Properties.Settings.Default.UserID);
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
            showNotesByPage(1);
        }

        public void showNotesByPage(int pageNumber)
        {
            // Obtain data + show it in the datagridview.
            DataSet ds = DB_Data.LoadNotesByPage(Properties.Settings.Default.UserID, pageNumber);
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
            DataSet ds_aux = DB_Data.GetAllNotes(Properties.Settings.Default.UserID);
            dt_aux = ds_aux.Tables[0];
            datagridviewNOTES_SECONDARY.DataSource = dt_aux;
        }

        private void OpenForm<MyForm>() where MyForm : Form, new()
        {
            Form form;
            form = panelALLMYNOTES.Controls.OfType<MyForm>().FirstOrDefault();

            if (form != null)
            {
                form.Close();
            }

            form = new MyForm();
            form.TopLevel = false;

            panelALLMYNOTES.Controls.Add(form);
            panelALLMYNOTES.Tag = form;

            form.Dock = DockStyle.Fill;

            form.BringToFront();
            form.Show();
        }

        private void FormSeeNotes_Load(object sender, EventArgs e)
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

                showNotesByPage(value);

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

                showNotesByPage(value);

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
                    showNotesByPage(actualPage);
                }
                else // If pageWrited it's between 1 and max pages.
                {
                    // If pageWrited is not the actual page...
                    if (pageWrited != actualPage)
                    {
                        actualPage = pageWrited;
                        showNotesByPage(actualPage);

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

        private void buttonDELETE_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to delete those notes?", "Deleting notes",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in datagridview_NOTES.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Select"].Value))
                        {
                            int noteID = Convert.ToInt32(row.Cells["ID"].Value);

                            if (DB_Data.DeleteNote(noteID) != 1)
                            {
                                MessageBox.Show("This note cannot be deleted.", "Notes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    // Refresh the datagridview if the form is open.
                    if (Application.OpenForms["FormSeeDeletedNotes"] != null)
                    {
                        (Application.OpenForms["FormSeeDeletedNotes"] as FormSeeDeletedNotes).updateNotes();
                    }

                    // Refresh the datagridview if the form is open.
                    if (Application.OpenForms["FormSeeFavoriteNotes"] != null)
                    {
                        (Application.OpenForms["FormSeeFavoriteNotes"] as FormSeeFavoriteNotes).showFavoriteNotesByPage(1);
                    }

                    showNotesByPage(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void buttonMODIFY_Click(object sender, EventArgs e)
        {
            // If we have more than 0 rows in the datagridview
            if (datagridview_NOTES.Rows.Count > 0)
            {
                int checkboxClicked = 0;

                Note selectedNote = new Note();

                // Looping the datagridview.
                foreach (DataGridViewRow row in datagridview_NOTES.Rows)
                {
                    // If there's a checkbox selected from the column "Select"
                    if (Convert.ToBoolean(row.Cells["Select"].Value))
                    {
                        checkboxClicked++;

                        // If there's more than one checkbox clicked, we end the task.
                        if (checkboxClicked > 1)
                        {
                            MessageBox.Show("You cannot choose more than one note to modify", 
                                "Notes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }

                        // Pick every object data from the datagridview.
                        selectedNote.Id = Convert.ToInt32(row.Cells["ID"].Value);
                        selectedNote.Title = Convert.ToString(row.Cells["Title"].Value);
                        selectedNote.Category = Convert.ToString(row.Cells["Category"].Value);
                        selectedNote.Description = Convert.ToString(row.Cells["NoteDescription"].Value);
                        selectedNote.Importance = Convert.ToString(row.Cells["Importance"].Value);
                        selectedNote.DateCreated = Convert.ToDateTime(row.Cells["DateCreated"].Value);
                    }
                }

                // If there's just one checkbox clicked, we proceed.
                if (checkboxClicked == 1)
                {
                    // See if the note selected is favourite or not.
                    if (DB_Data.IsFavorite(selectedNote.Id))
                        selectedNote.Favorite = 1;
                    else
                        selectedNote.Favorite = 0;

                    // This will help me to know when the user wants to modify a note.
                    ModifyNotes.setNote(selectedNote);

                    // We open the form to modify the note.
                    OpenForm<FormCreateNotes>();
                }
            }
        }
    }
}
