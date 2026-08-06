namespace Application.Commons;

public abstract class PagerViewModel
{
    public int PageNo { get; set; }
    public int PageSize { get; set; }
    public bool Desc { get; set; }  
}
