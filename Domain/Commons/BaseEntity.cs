using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public abstract class BaseEntity<TId> : BaseId<TId> 
    where TId : struct
{
    public bool IsDeleted { get; set; }
    [ForeignKey(nameof(CreatedByUser))]
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    [ForeignKey(nameof(ModifiedByUser))]
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }

    public virtual User? CreatedByUser { get; set; }
    public virtual User? ModifiedByUser { get; set; }
}
