using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMVCApplication.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Student Name cannot be less than 5")]
        public string StudentName { get; set; }
        [Required]
        [Range(5, 50, ErrorMessage = "Student Age must be between 5 and 50")]
        public int Age { get; set; }
        [Phone]
        public int PhoneNumber { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
    

}