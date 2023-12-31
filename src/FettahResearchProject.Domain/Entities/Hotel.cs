﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FettahResearchProject.Models.Entities
{
    public class Hotel : BaseEntity
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }

        public string? BrandName { get; set; }

        public int? RoomCount { get; set; }
    }
}
