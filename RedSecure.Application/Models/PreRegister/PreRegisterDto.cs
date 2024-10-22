﻿using RedSecure.Application.Models.Shared;
using RedSecure.Domain.Validations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RedSecure.Application.Models.PreRegister
{
    public class PreRegisterDRequest 
    {
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public required string UserName { get; set; }

        [JustNumbers]
        public required string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

    }
}
