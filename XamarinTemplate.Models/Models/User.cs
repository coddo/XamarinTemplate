using System;
using System.ComponentModel.DataAnnotations;
using XamarinTemplate.Models.Interfaces;

namespace XamarinTemplate.Models.Models
{
    public class User : ISinglePkModel
    {
        public static readonly Guid DefaultGuid = Guid.NewGuid();

        public Guid Id { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string FacebookId { get; set; }
    }
}
