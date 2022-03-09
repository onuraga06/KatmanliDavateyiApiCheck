using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavetiyeEntities
{
  public  class Davetiye
    {
        public int id { get; set; }
        [Required]
        public string isim { get; set; }
        public string email { get; set; }
        [Required]
        public bool gelmeDurumu { get; set; }
    }
}
