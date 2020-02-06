using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BaseDeDatos;
using Entities;

namespace Database
{
    public class DB_Data
    {
        public static DataSet GetAllNotes(int UserID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@UserID", SqlDbType.Int, 0, UserID)
            };

            // This will return all the notes (with all data they have).
            return FDBHelper.ExecuteDataSet("usp_Data_GetAllNotes", dbParams);
        }

        public static DataSet GetAllFavoriteNotes(int UserID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@UserID", SqlDbType.Int, 0, UserID)
            };

            // This will return all the notes (with all data they have).
            return FDBHelper.ExecuteDataSet("usp_Data_GetAllFavoriteNotes", dbParams);
        }

        public static DataSet GetAllDeletedNotes(int UserID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@UserID", SqlDbType.Int, 0, UserID)
            };

            // This will return the deleted notes (with all data they have).
            return FDBHelper.ExecuteDataSet("usp_Data_GetAllDeletedNotes", dbParams);
        }

        public static int GetTotalNotes(int UserID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@UserID", SqlDbType.Int, 0, UserID)
            };

            // This will return the amount of notes we have in the Database.
            object aux = FDBHelper.ExecuteScalar("usp_Data_GetTotalNotes", dbParams);

            if (aux == DBNull.Value)
                return 0;
            else
                return Convert.ToInt32(aux);
        }

        public static int GetTotalFavoriteNotes(int UserID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@UserID", SqlDbType.Int, 0, UserID)
            };

            // This will return the amount of notes we have in the Database.
            object aux = FDBHelper.ExecuteScalar("usp_Data_GetTotalFavoriteNotes", dbParams);

            if (aux == DBNull.Value)
                return 0;
            else
                return Convert.ToInt32(aux);
        }

        public static int GetTotalDeletedNotes(int UserID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@UserID", SqlDbType.Int, 0, UserID)
            };

            // This will return the amount of notes we have in the Database.
            object aux = FDBHelper.ExecuteScalar("usp_Data_GetTotalDeletedNotes", dbParams);

            if (aux == DBNull.Value)
                return 0;
            else
                return Convert.ToInt32(aux);
        }

        public static DataSet LoadNotesByPage(int UserID, int pageNumber)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@UserID", SqlDbType.Int, 0, UserID),
                FDBHelper.MakeParam("@ActualPage", SqlDbType.Int, 0, pageNumber)
            };

            return FDBHelper.ExecuteDataSet("usp_Data_LoadNotesByPage", dbParams);
        }

        public static DataSet LoadFavoriteNotesByPage(int UserID, int pageNumber)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@UserID", SqlDbType.Int, 0, UserID),
                FDBHelper.MakeParam("@ActualPage", SqlDbType.Int, 0, pageNumber)
            };

            return FDBHelper.ExecuteDataSet("usp_Data_LoadFavoriteNotesByPage", dbParams);
        }

        public static DataSet LoadDeletedNotesByPage(int UserID, int pageNumber)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@UserID", SqlDbType.Int, 0, UserID),
                FDBHelper.MakeParam("@ActualPage", SqlDbType.Int, 0, pageNumber)
            };

            return FDBHelper.ExecuteDataSet("usp_Data_LoadDeletedNotesByPage", dbParams);
        }

        public static int CreateNote(int UserID, Note note)
        {
            DateTime actualDate = DateTime.Now;

            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@UserID", SqlDbType.Int, 0, UserID),
                FDBHelper.MakeParam("@Title", SqlDbType.VarChar, 0, note.Title),
                FDBHelper.MakeParam("@Category", SqlDbType.VarChar, 0, note.Category),
                FDBHelper.MakeParam("@NoteDescription", SqlDbType.VarChar, 0, note.Description),
                FDBHelper.MakeParam("@Importance", SqlDbType.VarChar, 0, note.Importance),
                FDBHelper.MakeParam("@ActualDate", SqlDbType.DateTime, 0, actualDate),
                FDBHelper.MakeParam("@Favorite", SqlDbType.Int, 0, note.Favorite)
            };

            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_CreateNote", dbParams));
        }

        public static int ModifyNote(Note note)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@ID", SqlDbType.Int, 0, note.Id),
                FDBHelper.MakeParam("@Title", SqlDbType.VarChar, 0, note.Title),
                FDBHelper.MakeParam("@Category", SqlDbType.VarChar, 0, note.Category),
                FDBHelper.MakeParam("@NoteDescription", SqlDbType.VarChar, 0, note.Description),
                FDBHelper.MakeParam("@Importance", SqlDbType.VarChar, 0, note.Importance),
                FDBHelper.MakeParam("@Favorite", SqlDbType.Int, 0, note.Favorite)
            };

            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_ModifyNote", dbParams));
        }

        public static int DeleteNote(int noteID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@NoteID", SqlDbType.Int, 0, noteID)
            };

            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_DeleteNote", dbParams));
        }

        public static int RestoreNote(int noteID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@NoteID", SqlDbType.Int, 0, noteID)
            };

            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_RestoreNote", dbParams));
        }

        public static bool IsFavorite(int NoteID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@NoteID", SqlDbType.Int, 0, NoteID)
            };

            object aux = FDBHelper.ExecuteScalar("usp_Data_IsFavorite", dbParams);

            if (aux == null)
                return false;
            else
                return true;
        }

        public static int NotFavoriteAnymore(int noteID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@NoteID", SqlDbType.Int, 0, noteID)
            };

            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_NotFavoriteAnymore", dbParams));
        }

        public static bool UserExists(string user)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@Username", SqlDbType.VarChar, 0, user)
            };

            object aux = FDBHelper.ExecuteScalar("usp_Data_UserExists", dbParams);

            if (aux == null)
                return false;
            else
                return true;
        }

        public static bool VerifyLogin(string user, string pass)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@Username",SqlDbType.VarChar,0,user),
                FDBHelper.MakeParam("@Password",SqlDbType.VarChar,0,pass)
            };

            object aux = FDBHelper.ExecuteScalar("usp_Data_VerifyLogin", dbParams);

            if (aux == null)
                return false;
            else
                return true;
        }

        public static int CreateUser(string user, string password)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@Username", SqlDbType.VarChar, 0, user),
                FDBHelper.MakeParam("@Password", SqlDbType.VarChar, 0, password)
            };

            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_CreateUser", dbParams));
        }

        public static int BringUserID(string user)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                FDBHelper.MakeParam("@Username", SqlDbType.VarChar, 0, user)
            };

            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_BringUserID", dbParams));
        }

        public static int GetTotalUsersCreated()
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
            };

            // This will return the amount of notes we have in the Database.
            object aux = FDBHelper.ExecuteScalar("usp_Data_GetTotalUsersCreated", dbParams);

            if (aux == DBNull.Value)
                return 0;
            else
                return Convert.ToInt32(aux);
        }
    }
}
