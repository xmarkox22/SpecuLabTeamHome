namespace PrototipoApi.Entities
{
    public class TotalBudget
    {
        public int BudgetId { get; set; }
        public int BudgetYear { get; set; }
        public double TotalAmount { get; set; }
        public double CurrentAmount { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        // Relaciones
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }

}
