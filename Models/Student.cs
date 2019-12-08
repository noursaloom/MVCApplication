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
        [Required(ErrorMessage = "A phone number is required.")]
        //[DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Plz enter number in this format(##########)")]
        public string MobileNumber { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Please enter a valid email address")]
        public string StudentEmail { get; set; }
    }
    

}