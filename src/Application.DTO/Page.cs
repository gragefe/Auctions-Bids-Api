namespace Application.DTO;

using System.Collections.Generic;
using System.Linq;

public class Page<T> where T : class
{
    public int CurrentPage { get; set; }

    public int TotalPages { get; set; }

    public int TotalItems { get; set; }

    public IEnumerable<T> Results { get; set; }

    public Page(int pageNumber = 1, int totalPages = 1, int totalItems = 0, IEnumerable<T> results = null)
    {
        this.CurrentPage = pageNumber;
        this.TotalPages = totalPages;
        this.TotalItems = totalItems;
        this.Results = results ?? Enumerable.Empty<T>();
    }
}