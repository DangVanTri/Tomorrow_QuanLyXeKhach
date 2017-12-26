﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class TramXe
    {
        [Key]
        public int MaTramXe { get; set; }

        [StringLength(50)]
        public string TenTramXe { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        public virtual ICollection<HanhTrinh> HanhTrinhs { get; set; }

    }
}
