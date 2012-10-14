﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.MemberShip
{
    public class OtherInformation
    {
        public int ID { get; set; }
        
        public string QQ { get; set; }

        public SexCatalog Sex { get; set; }

        public string Mobile { get; set; }

        public Guid ApplicationId { get; set; }

        public Guid UserId { get; set; }
    }

    public enum SexCatalog
    {
        Male = 0,
        Fmale = 1
    }
}
