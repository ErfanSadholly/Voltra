namespace Domain.Commons;

public class GetIdTitle<TKey> : BaseId<TKey>
    where TKey : struct
{
    public TKey Id { get; set; }
    public string Title { get; set; } = string.Empty;
}
