using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AbouID { get; set; }

        [StringLength(500)]
        public string AboutDetails1 { get; set; }

        [StringLength(500)]
        public string AboutDetails2 { get; set; }

        [StringLength(100)]
        public string AboutImega1 { get; set; }

        [StringLength(100)]
        public string AboutImega2{ get; set; }

    }
}
