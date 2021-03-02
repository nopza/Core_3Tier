using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        //LONG
        public Int64 Id { get; set; }
        [Required]
        public String Username { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
        //FOREIGN KEY
        [Required]
        public Int32 AuthLevelRefId { get; set; }
    }
}
