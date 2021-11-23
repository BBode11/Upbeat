using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upbeat.Models
{
    public class Songs
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Artist { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        //[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        //[RegularExpression(@"^[0 - 9]\d{0, 9}(\.\d{1,3})?%?$", ErrorMessage = "Only numbers and decimals are allowed.")]
        public double DurationTime { get; set; }

    }
}
