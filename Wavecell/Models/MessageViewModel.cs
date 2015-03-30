using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wavecell.Models
{
    public class MessageViewModel
    {
        [Required]
        [StringLength(20)]
        public string Source { get; set; }
        [Required]        
        public string Destination { get; set; }
        [Required]
        [StringLength(500)]
        public string Body { get; set; }        
        public DateTime? Date { get; set; }
        public bool SavedSuccessfully { get; set; }

        public string Status { get; set; }
    }
}