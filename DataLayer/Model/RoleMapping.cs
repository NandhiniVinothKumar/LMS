using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Model
{
    public partial class RoleMapping
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Employee User { get; set; }
    }
}
