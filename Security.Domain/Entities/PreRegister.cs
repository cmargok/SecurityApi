﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    [Table("PreRegister")]
    public class PreRegister
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(12)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]       
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }
    }
}