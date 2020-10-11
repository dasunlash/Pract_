﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataObjects.Models
{
   public class Role
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]

        public string Name { get; set; }
        public int IsActive { get; set; }
    }
}