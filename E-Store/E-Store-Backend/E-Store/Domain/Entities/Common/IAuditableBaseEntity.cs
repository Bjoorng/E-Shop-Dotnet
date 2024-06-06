namespace E_Store.Domain.Entities.Common;

public interface IAuditableBaseEntity
{
    string CreatedBy { get; set; }
    DateTimeOffset CreatedIn { get; set; }
    string? ModifiedBy { get; set; }
    DateTimeOffset? ModifiedIn { get; set; }
}
