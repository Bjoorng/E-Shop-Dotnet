namespace E_Store.Domain.Entities.Common;

public class AuditableBaseEntity<TId> : BaseEntity<TId>, IAuditableBaseEntity
{
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedIn { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? ModifiedIn { get; set; }

    protected AuditableBaseEntity() { }

    protected AuditableBaseEntity(TId id) : base(id) { }
}
