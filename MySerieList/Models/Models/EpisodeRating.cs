﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class EpisodeRating
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public int Episodeid { get; set; }

        public int Userid { get; set; }

    }
}