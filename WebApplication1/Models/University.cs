using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class University
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public List<College> Colleges{ get; set; }

    } 
}
