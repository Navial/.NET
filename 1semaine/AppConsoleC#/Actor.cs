
using System.Globalization;
using System.Linq;
using System;
using System.Collections;

namespace AppConsoleC_ {

    [Serializable]
    public class Actor : Person
    {

        private static readonly long _serialVersionUID = 1L;
        private readonly int _sizeInCentimeter;
        public List<Movie> _movies;

        public int SizeInCentimeter
        {
            get { return _sizeInCentimeter; }
        }
        
        public override string Name
        {
            get { return base.Name.ToUpper(); }
        }

        public IEnumerator<Movie> Movies
        {
            get { return _movies.GetEnumerator(); }
        }

        public Actor(String name, String firstname, DateTime birthDate, int sizeInCentimeter) : base(name, firstname, birthDate)
        { 
            this._sizeInCentimeter = sizeInCentimeter;
            _movies = new List<Movie>();
        }
        
        public override String ToString()
        {
            return "Actor [name = " + Name + " firstname = " + base.Firstname+ " sizeInCentimeter = " + _sizeInCentimeter + " birthdate = " + base.BirthDate + "]";
        }


        /**
         * add movie to the list of movies in which the actor has played
         * @param movie
         * @return false if the movie is null or already present
         */
         public bool AddMovie(Movie movie)
         {
             if ((movie == null) || _movies.Contains(movie))
                 return false;
         
             // if (!movie.containsActor(this))
             //     movie.addActor(this);
             _movies.Add(movie);
             return true;
         }
         
         public bool ContainsMovie(Movie movie)
         {
             return _movies.Contains(movie);
         }

    }

}