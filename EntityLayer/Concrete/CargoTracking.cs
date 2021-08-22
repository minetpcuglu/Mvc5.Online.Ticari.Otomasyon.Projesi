﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class CargoTracking
    {
        [Key]
        public int CargoTrackingId { get; set; }

        [Column(TypeName = "Varchar")]
        public string TrackingCode { get; set; }

        [Column(TypeName = "Varchar")]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
