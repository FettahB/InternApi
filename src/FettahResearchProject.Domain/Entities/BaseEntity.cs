using FettahResearchProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FettahResearchProject.Models.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public Status Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;}

        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set;}
        protected BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
            Status = Status.Created;
        }
    }

}
