using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DavetiyeApiUi.Models
{
    public class Davetiye
    {
        public int id { get; set; }
       
        public string isim { get; set; }
        public string email { get; set; }
        
        public bool gelmeDurumu { get; set; }
    }
}
