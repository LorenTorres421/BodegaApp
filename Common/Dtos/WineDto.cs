using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class WineDto
    {
        public string Name { get; set; }
        public string Variety { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public object Id { get; set; }
    }

}
