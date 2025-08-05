using HelloWorldAPI.Models.Domain;
using HelloWorldAPI.Models.DTO;
using HelloWorldAPI.Models.DTO.Domain;
using HelloWorldAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MutualFundsController : ControllerBase
        {
            private readonly IMutualFundRepository mutualFundRepository;

            public MutualFundsController(IMutualFundRepository mutualFundRepository)
            {
                this.mutualFundRepository = mutualFundRepository;
            }

            [HttpPost]
            public async Task<IActionResult> CreateMutualFund([FromBody] CreateMutualFundRequestDto request)
            {
                var mutualFund = new MutualFund
                {
                    FundName = request.FundName,
                    FundManager = request.FundManager,
                    Category = request.Category,
                    Description = request.Description,
                    ImageUrl = request.ImageUrl,
                    UrlHandle = request.UrlHandle,
                    LaunchDate = request.LaunchDate,
                    NetAssetValue = request.NetAssetValue,
                    ExpenseRatio = request.ExpenseRatio,
                    IsActive = request.IsActive
                };

                mutualFund = await mutualFundRepository.CreateAsync(mutualFund);

                var response = new MutualFundDto
                {
                    Id = mutualFund.Id,
                    FundName = mutualFund.FundName,
                    FundManager = mutualFund.FundManager,
                    Category = mutualFund.Category,
                    Description = mutualFund.Description,
                    ImageUrl = mutualFund.ImageUrl,
                    UrlHandle = mutualFund.UrlHandle,
                    LaunchDate = mutualFund.LaunchDate,
                    NetAssetValue = mutualFund.NetAssetValue,
                    ExpenseRatio = mutualFund.ExpenseRatio,
                    IsActive = mutualFund.IsActive
                };

                return Ok(response);
            }

            [HttpGet]
            public async Task<IActionResult> GetAllMutualFunds()
            {
                var mutualFunds = await mutualFundRepository.GetAllAsync();

                var response = mutualFunds.Select(fund => new MutualFundDto
                {
                    Id = fund.Id,
                    FundName = fund.FundName,
                    FundManager = fund.FundManager,
                    Category = fund.Category,
                    Description = fund.Description,
                    ImageUrl = fund.ImageUrl,
                    UrlHandle = fund.UrlHandle,
                    LaunchDate = fund.LaunchDate,
                    NetAssetValue = fund.NetAssetValue,
                    ExpenseRatio = fund.ExpenseRatio,
                    IsActive = fund.IsActive
                }).ToList();

                return Ok(response);
            }

            [HttpGet]
            [Route("{id:Guid}")]
            public async Task<IActionResult> GetMutualFundById([FromRoute] Guid id)
            {
                var mutualFund = await mutualFundRepository.GetByIdAsync(id);

                if (mutualFund == null)
                    return NotFound();

                var response = new MutualFundDto
                {
                    Id = mutualFund.Id,
                    FundName = mutualFund.FundName,
                    FundManager = mutualFund.FundManager,
                    Category = mutualFund.Category,
                    Description = mutualFund.Description,
                    ImageUrl = mutualFund.ImageUrl,
                    UrlHandle = mutualFund.UrlHandle,
                    LaunchDate = mutualFund.LaunchDate,
                    NetAssetValue = mutualFund.NetAssetValue,
                    ExpenseRatio = mutualFund.ExpenseRatio,
                    IsActive = mutualFund.IsActive
                };

                return Ok(response);
            }

            [HttpGet]
            [Route("handle/{urlHandle}")]
            public async Task<IActionResult> GetMutualFundByUrlHandle([FromRoute] string urlHandle)
            {
                var mutualFund = await mutualFundRepository.GetByUrlHandleAsync(urlHandle);

                if (mutualFund == null)
                    return NotFound();

                var response = new MutualFundDto
                {
                    Id = mutualFund.Id,
                    FundName = mutualFund.FundName,
                    FundManager = mutualFund.FundManager,
                    Category = mutualFund.Category,
                    Description = mutualFund.Description,
                    ImageUrl = mutualFund.ImageUrl,
                    UrlHandle = mutualFund.UrlHandle,
                    LaunchDate = mutualFund.LaunchDate,
                    NetAssetValue = mutualFund.NetAssetValue,
                    ExpenseRatio = mutualFund.ExpenseRatio,
                    IsActive = mutualFund.IsActive
                };

                return Ok(response);
            }

            [HttpPut]
            [Route("{id:Guid}")]
            public async Task<IActionResult> UpdateMutualFundById([FromRoute] Guid id, [FromBody] UpdateMutualFundRequestDto request)
            {
                var mutualFund = new MutualFund
                {
                    Id = id,
                    FundName = request.FundName,
                    FundManager = request.FundManager,
                    Category = request.Category,
                    Description = request.Description,
                    ImageUrl = request.ImageUrl,
                    UrlHandle = request.UrlHandle,
                    LaunchDate = request.LaunchDate,
                    NetAssetValue = request.NetAssetValue,
                    ExpenseRatio = request.ExpenseRatio,
                    IsActive = request.IsActive
                };

                var updatedFund = await mutualFundRepository.UpdateAsync(mutualFund);

                if (updatedFund == null)
                    return NotFound();

                var response = new MutualFundDto
                {
                    Id = updatedFund.Id,
                    FundName = updatedFund.FundName,
                    FundManager = updatedFund.FundManager,
                    Category = updatedFund.Category,
                    Description = updatedFund.Description,
                    ImageUrl = updatedFund.ImageUrl,
                    UrlHandle = updatedFund.UrlHandle,
                    LaunchDate = updatedFund.LaunchDate,
                    NetAssetValue = updatedFund.NetAssetValue,
                    ExpenseRatio = updatedFund.ExpenseRatio,
                    IsActive = updatedFund.IsActive
                };

                return Ok(response);
            }

            [HttpDelete]
            [Route("{id:Guid}")]
            public async Task<IActionResult> DeleteMutualFund([FromRoute] Guid id)
            {
                var deletedFund = await mutualFundRepository.DeleteAsync(id);

                if (deletedFund == null)
                    return NotFound();

                var response = new MutualFundDto
                {
                    Id = deletedFund.Id,
                    FundName = deletedFund.FundName,
                    FundManager = deletedFund.FundManager,
                    Category = deletedFund.Category,
                    Description = deletedFund.Description,
                    ImageUrl = deletedFund.ImageUrl,
                    UrlHandle = deletedFund.UrlHandle,
                    LaunchDate = deletedFund.LaunchDate,
                    NetAssetValue = deletedFund.NetAssetValue,
                    ExpenseRatio = deletedFund.ExpenseRatio,
                    IsActive = deletedFund.IsActive
                };

                return Ok(response);
            }
        }
    

}
