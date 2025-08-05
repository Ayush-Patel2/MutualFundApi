using HelloWorldAPI.Models.DTO.Domain;

namespace HelloWorldAPI.Repositories.Interface
{
    public interface IMutualFundRepository
    {
        Task<MutualFund> CreateAsync(MutualFund mutualFund);

        Task<IEnumerable<MutualFund>> GetAllAsync();

        Task<MutualFund?> GetByIdAsync(Guid id);

        Task<MutualFund?> GetByUrlHandleAsync(string urlHandle);

        Task<MutualFund?> UpdateAsync(MutualFund mutualFund);

        Task<MutualFund?> DeleteAsync(Guid id);
    }

}
