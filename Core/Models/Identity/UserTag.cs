using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.Identity
{
    public class UserTag
    {
        public int Id { get; set; }
        public bool CanCheckErrors { get; set; } = false;

        [Required]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}