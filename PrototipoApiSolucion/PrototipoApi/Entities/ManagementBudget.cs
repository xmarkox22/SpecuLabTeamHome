namespace PrototipoApi.Entities
{
    public class ManagementBudget
    {
        public int ManagementBudgetId { get; set; }
        public double InitialAmount { get; set; }
        public double CurrentAmount { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        // Relaciones
        //public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
