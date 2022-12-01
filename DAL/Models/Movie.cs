using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [MaxLength(10)]
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
    }
}
