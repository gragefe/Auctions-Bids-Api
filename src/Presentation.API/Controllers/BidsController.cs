namespace Bids.API.Controllers;

using Application.DTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("[controller]")]
public class BidsController : Controller
{
    private readonly ICreateBidsService _createBidsService;
    private readonly ISearchBidsService _searchBidsService;
    private readonly IGetByIdBidsService _getByIdBidsService;

    public BidsController(
        ICreateBidsService createBidsService,
        ISearchBidsService searchBidsService,
        IGetByIdBidsService getByIdBidsService)
    {
        _createBidsService = createBidsService;
        _searchBidsService = searchBidsService;
        _getByIdBidsService = getByIdBidsService;
    }

    [HttpPost(Name = "Create")]
    public async Task<ActionResult> CreateBidsAsync([FromBody] Bid Auction)
    {
        await _createBidsService.CreateAsync(Auction);
        var AuctionId = Guid.NewGuid();
        var resourceLocationUri = this.Request?.GetDisplayUrl() + $"/{AuctionId}";
        return this.Created(resourceLocationUri, null);
    }

    [HttpGet, Route("GetById")]
    public async Task<ActionResult> GetBidsByIdAsync([Required, FromQuery] Guid id)
    {
        var Auction = await _getByIdBidsService.GetByIdAsync(id);
        return this.Ok( Auction);
    }

    [HttpPost, Route("Search")]
    public async Task<ActionResult<Page<Bid>>> SearechBidsAsync(
        [FromBody] SearchContext searchContext,
        [FromQuery] int? page = null,
        [FromQuery] int? pageSize = null
        )
    {
        await _searchBidsService.SearchAsync(searchContext);
        var resourceLocationUri = this.Request?.GetDisplayUrl() + $"/{123}";
        return this.Created(resourceLocationUri, null);
    }
}