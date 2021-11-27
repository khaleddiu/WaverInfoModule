using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Waver_InfoApp.Entities
{
    public partial class SmisWaiverInfo
    {
        public string StudentId { get; set; }
        public double WaiverPercent { get; set; }
        public string Yn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }

        public virtual SmisStudent Student { get; set; }
    }
}
