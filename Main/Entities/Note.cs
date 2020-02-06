using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Note
    {
        private int id;
        private string title;
        private string category;
        private string description;
        private string importance;
        private DateTime dateCreated;
        private int favorite;
        private int active;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Importance
        {
            get { return importance; }
            set { importance = value; }
        }

        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        public int Favorite
        {
            get { return favorite; }
            set { favorite = value; }
        }

        public int Active
        {
            get { return active; }
            set { active = value; }
        }

        public Note()
        {
        }

        public Note(int id, string title, string category, string description, 
            string importance, DateTime dateCreated, int favorite, int active)
        {
            this.id = id;
            this.title = title;
            this.category = category;
            this.description = description;
            this.importance = importance;
            this.dateCreated = dateCreated;
            this.favorite = favorite;
            this.active = active;
        }

    }
}
