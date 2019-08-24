using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Yardy.Models
{
    public class YardSale
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Max length: 250 characters")]
        public string Description { get; set; }
        
        [ForeignKey("UserProfile")]
        public int UserID { get; set; }

        [Required]
        public DateTime SaleStart { get; set; }

        [Required]
        public DateTime SaleEnd{ get; set; }

        public DateTime Created { get; set; }

        public bool Active { get; set; }

        //public List<string> Catergories { get; set; }
        //public string ImagesPath { get; set; }
    }
}
