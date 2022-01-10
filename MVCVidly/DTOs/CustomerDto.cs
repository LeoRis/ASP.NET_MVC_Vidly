using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCVidly.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCVidly.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        //[Required(ErrorMessage = "Please enter customer's name.")] - To override the default validation error message.
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
    }
}