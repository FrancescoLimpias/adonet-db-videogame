using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    internal class Videogame
    {
        /* ***************
         * VIDEOGAME's PROPERTIES
         */
        public int ID { get; }
        public string Name { get; set; }

        //CONSTRUCTOR
        internal Videogame(int id, string name)
        {
            ID = id;
            Name = name;
        }

        /* ***************
         * VIDEOGAME's METHODS
         */
    }
}
