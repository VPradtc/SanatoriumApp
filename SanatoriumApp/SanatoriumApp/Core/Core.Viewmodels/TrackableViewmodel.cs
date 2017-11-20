using System;

namespace Core.Viewmodels
{
    public class TrackableViewmodel : BaseViewmodel
    {
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
