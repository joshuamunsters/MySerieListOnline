﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Episode
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Serie Serie { get; set; }
    }
}
