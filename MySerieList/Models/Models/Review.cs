﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Reviewtext { get; set; }

        public int Serieid { get; set; }


        public DateTime Date { get; set; }

        public User User { get; set; }

    }
}
