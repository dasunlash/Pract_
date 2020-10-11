using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataObjects.Models
{
   public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        [Column(TypeName ="varchar(200)")]
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public int AppointedUserId { get; set; }
        [ForeignKey("AppointedUserId")]
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string _date
        {
            get
            {
                return string.Format("{0:yyyy-MM-dd}", Date);
            }
        }
    }
}
