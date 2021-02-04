﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _413Assignment2.Models
{
    public class MovieResponse
    {
        [Required(ErrorMessage="Category is required")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Director is required")]

        public string Director { get; set; }
        [Required(ErrorMessage = "Rating is required")]

        public string Rating { get; set; }


        public bool? Edited { get; set; }

        public string LentTo { get; set; }
        [StringLength(25, ErrorMessage = "Note must be between 0 and 25 characters")]
        public string Notes { get; set; }

    }
}
