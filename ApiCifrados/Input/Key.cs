using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ApiCifrados.Input
{
    public class Key 
    {
       // public T key { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public string Word { get; set; }
        public int Level { get; set; }
    }
}
