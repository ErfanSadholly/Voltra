namespace Domain;

public interface IBaseId<TId> 
    where TId : struct
{
    public TId Id { get; set; }
}