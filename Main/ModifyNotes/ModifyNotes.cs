using System;

namespace ModifyNotes
{
    public class ModifyNotes
    {
        public static bool modifyNote = false;
        public static int ID = 0;

        public static void changeValues(int noteID)
        {
            modifyNote = true;
            ID = noteID;
        }

        public static int needID()
        {
            return ID;
        }
    }
}
