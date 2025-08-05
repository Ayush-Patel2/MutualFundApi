using HelloWorldAPI.Data;
using HelloWorldAPI.Models.DTO.Domain;
using HelloWorldAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldAPI.Repositories.Implementation
{
        public class MutualFundRepository : IMutualFundRepository
        {
            private readonly ApplicationDbContext dbContext;

            public MutualFundRepository(ApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<MutualFund> CreateAsync(MutualFund mutualFund)
            {
                await dbContext.MutualFunds.AddAsync(mutualFund);
                await dbContext.SaveChangesAsync();
                return mutualFund;
            }

            public async Task<MutualFund?> DeleteAsync(Guid id)
            {
                var existingMutualFund = await dbContext.MutualFunds.FirstOrDefaultAsync(x => x.Id == id);

                if (existingMutualFund != null)
                {
                    dbContext.MutualFunds.Remove(existingMutualFund);
                    await dbContext.SaveChangesAsync();
                    return existingMutualFund;
                }

                return null;
            }

            public async Task<IEnumerable<MutualFund>> GetAllAsync()
            {
                return await dbContext.MutualFunds.ToListAsync();
            }

            public async Task<MutualFund?> GetByIdAsync(Guid id)
            {
                return await dbContext.MutualFunds.FirstOrDefaultAsync(x => x.Id == id);
            }

            public async Task<MutualFund?> GetByUrlHandleAsync(string urlHandle)
            {
                return await dbContext.MutualFunds.FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
            }

            public async Task<MutualFund?> UpdateAsync(MutualFund mutualFund)
            {
                var existingMutualFund = await dbContext.MutualFunds
                    .FirstOrDefaultAsync(x => x.Id == mutualFund.Id);

                if (existingMutualFund == null)
                {
                    return null;
                }

                dbContext.Entry(existingMutualFund).CurrentValues.SetValues(mutualFund);
                await dbContext.SaveChangesAsync();

                return mutualFund;
            }
        }
    

}