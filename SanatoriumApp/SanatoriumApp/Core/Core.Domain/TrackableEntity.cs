using System;

namespace Core.Domain
{
    public class TrackableEntity : BaseEntity
    {
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
