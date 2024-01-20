using System;

namespace FT.Travelako.Common.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; } = new Guid();
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
