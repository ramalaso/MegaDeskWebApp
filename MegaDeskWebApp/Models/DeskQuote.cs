using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDeskWebApp.Models
{
    public class DeskQuote
    {
        public int ID { get; set; }

        [Display(Name = "Customer Name")]
        [StringLength(60, MinimumLength =5)]
        [Required]
        public string CustomerName { get; set; }

        [Display(Name = "Quote Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime QuoteDate { get; set; }

        [Range(24, 96)]
        [Required]
        public int Width { get; set; }

        [Range(12, 48)]
        [Required]
        public int Depth { get; set; }

        [Display(Name = "N. of Drawers")]
        [Range(0, 7)]
        [Required]
        public int Drawers { get; set; }

        [StringLength(60, MinimumLength = 5)]
        [Required]
        public string Material { get; set; }

        [Display(Name = "Rush Days")]
        [Range(0, 7)]
        [Required]
        public int rushDays { get; set; }

        [Display(Name = "Total Quote")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal TotalQuote { get; set; }
    }
}
