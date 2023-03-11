using System;

namespace libreriaApp.DAL.Core
{
    public abstract class AuditEntity
    {
        public AuditEntity()
        {
            this.CreationDate = DateTime.Now;
            this.Deleted = 1;
        }
        public int? CreationUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? UserMod { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? UserDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? Deleted { get; set; }

        public DateTime StartDate { get; set; }
    }
}
