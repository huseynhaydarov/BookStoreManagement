namespace Contracts.Pagination;

public class PagingConstants
{
    private int _page;
    private int _pageSize;
    
    public bool OrderByDescending { get; set; }

    public int Page
    {
        get => _page;
        set => _page = Math.Clamp(value, 1, int.MaxValue);
    }

    public int PageSize
    {
        get => _pageSize == 0 ? PagingConstants
    }
}