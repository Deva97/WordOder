using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetlixRecords.Model
{
    public class Series
    {
        [Required]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public DateTime ReleaseDate { get; set; }
        public bool IsSeries { get; set; }
        [StringLength(20, ErrorMessage = "Name should be less than 20 letter long ")]
        public string Name { get; set; }
        public int ScreeningHours { get; set; }
        [Required]
        public int AgeLimit { get; set; }
        public enum Genres
        {
            Action = 1,
            Adventure = 2,
            horror = 3,
            comedy = 4,
            selfhelp = 5,
        }

        public string Country { get; set; }
    }
}

