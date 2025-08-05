namespace HelloWorldAPI.Models.DTO
{


    public class MutualFundDto
    {
        public Guid Id { get; set; }
        public string FundName { get; set; }
        public string FundManager { get; set; }
        public string Category { get; set; } // e.g., Equity, Debt, Hybrid
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime LaunchDate { get; set; }
        public decimal NetAssetValue { get; set; }
        public double ExpenseRatio { get; set; }
        public bool IsActive { get; set; }
    }

}
