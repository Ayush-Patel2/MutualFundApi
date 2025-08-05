namespace HelloWorldAPI.Models.DTO.Domain
{


    public class MutualFund
    {
        public Guid Id { get; set; }
        public string FundName { get; set; }
        public string FundManager { get; set; }
        public string Category { get; set; } // e.g., Equity, Debt, Hybrid
        public string Description { get; set; }
        public string ImageUrl { get; set; } // Optional: logo or branding
        public string UrlHandle { get; set; } // SEO-friendly identifier
        public DateTime LaunchDate { get; set; }
        public decimal NetAssetValue { get; set; } // Current NAV
        public double ExpenseRatio { get; set; } // Annual cost percentage
        public bool IsActive { get; set; } // Whether fund is open for investment
    }

}
