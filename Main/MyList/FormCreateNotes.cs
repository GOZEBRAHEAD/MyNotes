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
    public partial class FormCreateNotes : Form
    {
        public FormCreateNotes()
        {
            InitializeComponent();
        }

        private void resetText()
        {
            textboxTITLE.Text = null;
            textboxCATEGORY.Text = null;
            textboxDESCRIPTION.Text = null;

            comboboxIMPORTANCE.SelectedIndex = 0;
        }

        private void FormCreateNotes_Load(object sender, EventArgs e)
        {
            labelID.Visible = false;
            textboxID.Visible = false;
            labelDATE.Visible = false;
            textboxDATE.Visible = false;

            comboboxIMPORTANCE.SelectedIndex = 0;

            // If the user wants to modify a note...
            if (ModifyNotes.modifyNote)
            {
                labelID.Visible = true;
                textboxID.Visible = true;
                labelDATE.Visible = true;
                textboxDATE.Visible = true;

                modifyTheNote();
            }
        }

        private void modifyTheNote()
        {            
            Note note = new Note();
            note = ModifyNotes.getNote();

            textboxID.Text = Convert.ToString(note.Id);
            textboxTITLE.Text = note.Title;
            textboxCATEGORY.Text = note.Category;
            textboxDESCRIPTION.Text = note.Description;
            textboxDATE.Text = Convert.ToString(note.DateCreated);

            switch (note.Importance)
            {
                case "Low":
                    comboboxIMPORTANCE.SelectedIndex = 0;
                    break;

                case "Medium":
                    comboboxIMPORTANCE.SelectedIndex = 1;
                    break;

                default:
                    comboboxIMPORTANCE.SelectedIndex = 2;
                    break;
            }

            if (note.Favorite == 1)
                switchFAVOURITE.Value = true;
            else
                switchFAVOURITE.Value = false;
        }

        private void buttonCANCEL_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Are you sure you want to discard the note?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                resetText();

                ModifyNotes.modifyNote = false;
                ModifyNotes.resetNotes();

                this.Hide();
            }
        }

        private void buttonSAVE_Click(object sender, EventArgs e)
        {
            Note note = new Note();

            note.Title = textboxTITLE.Text;
            note.Category = textboxCATEGORY.Text;
            note.Description = textboxDESCRIPTION.Text;

            switch (comboboxIMPORTANCE.SelectedIndex)
            {
                case 0:
                    note.Importance = "Low";
                    break;

                case 1:
                    note.Importance = "Medium";
                    break;

                default:
                    note.Importance = "High";
                    break;
            }

            if (switchFAVOURITE.Value)
                note.Favorite = 1;
            else
                note.Favorite = 0;

            // If the user is modifying the note...
            if (ModifyNotes.modifyNote)
            {
                note.Id = Convert.ToInt32(textboxID.Text);

                // Sending data to modify the note.
                DB_Data.ModifyNote(note);

                // Send the message to the user.
                MessageBox.Show("Note modified!", "Modify note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Sending data to create the note.
                DB_Data.CreateNote(Properties.Settings.Default.UserID, note);

                // Send the message to the user.
                MessageBox.Show("Note added!", "Create note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Refreshing the datagridview.
            if (Application.OpenForms["FormSeeNotes"] != null)
            {
                (Application.OpenForms["FormSeeNotes"] as FormSeeNotes).updateNotes();
            }

            // Reset every possible thing to avoid bugs.
            resetText();

            ModifyNotes.modifyNote = false;
            ModifyNotes.resetNotes();

            // Hiding the form.
            this.Hide();
        }

        
    }
}
