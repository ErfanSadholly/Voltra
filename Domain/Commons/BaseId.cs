namespace Domain;

public abstract class BaseId<TId> : IBaseId<TId>
    where TId : struct
{
    public TId Id { get; set; }
}