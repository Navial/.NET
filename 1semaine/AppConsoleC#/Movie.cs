using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsoleC_
{
    public class Movie
    {


        private string _title;
        private int _releaseYear;
        private List<Actor> _actors;
        // private Director _director;

        public virtual string Title
        {
            get { return _title; }  
            set { _title = value; }
        }

        public virtual int ReleaseYear
        {
            get { return _releaseYear;}
            set { _releaseYear = value; }
        }

        public Movie(String title, int releaseYear)
        {
            _actors = new List<Actor>();
            this._title = title;
            this._releaseYear = releaseYear;
        }

        // public Director Director 
        // {
        //     get { return _director; } 
        // }

        // public void setDirector(Director director)
        // {
        //     if (director == null)
        //         return;
        //     this.director = director;
        //     director.addMovie(this);
        // }


        public bool AddActor(Actor actor)
        {
            if (_actors.Contains(actor))
                return false;

            _actors.Add(actor);
            if (!actor.ContainsMovie(this))
                actor.AddMovie(this);

            return true;
        }

        public bool ContainsActor(Actor actor)
        {
            return _actors.Contains(actor);
        }

        
        public override String ToString()
        {
            return "Movie [title=" + _title + ", releaseYear=" + _releaseYear + "]";
        }

    }
}
