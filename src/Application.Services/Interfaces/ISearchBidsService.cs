namespace Application.Services.Interfaces;

using Application.DTO;
using System.Collections.Generic;

public interface ISearchBidsService
{
    Task<List<Bid>> SearchAsync(SearchContext searchContextDto);
}