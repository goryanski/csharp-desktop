using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Practice.Models.Database.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
