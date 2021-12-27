using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StraxTemplate.Models
{
    public class DesingType
    {

        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Img { get; set; }
        public List<Service> Services { get; set; }
    }
}
