using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ModifyNotes
    {
        public static bool modifyNote = false;

        public static Note note = new Note();

        public static void resetNotes()
        {
            note.Id = 0;
            note.Title = null;
            note.Category = null;
            note.Description = null;
            note.Importance = null;
            note.Favorite = 0;
        }

        public static void setNote(Note selectedNote)
        {
            resetNotes();

            modifyNote = true;

            note = selectedNote;
        }

        public static Note getNote()
        {
            return note;
        }
    }
}
