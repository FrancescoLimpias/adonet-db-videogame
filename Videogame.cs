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
        public long ID { get; }
        public string Name { get; set; }

        //CONSTRUCTOR
        internal Videogame(long id, string name)
        {
            ID = id;

            if (name.Length > 50)
                throw new ArgumentException($"The given name is too long (max: 50) [{name}]");
            Name = name;
        }

        /* ***************
         * VIDEOGAME's METHODS
         */
    }
}
