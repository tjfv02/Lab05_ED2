using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ApiCifrados.Input
{
    public class CifradoInput <T>
    {
        public IFormFile File { get; set; }
        public T Key { get; set; }
    }

    public class RutaKey
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
    }

    public class CesarCifradoImput : CifradoInput<string> { }
    public class ZigZagCifradoImput : CifradoInput<int> { }
    public class RutaCifradoImput : CifradoInput<RutaKey> { }



}
