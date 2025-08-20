namespace PrototipoApi.Entities
{
    public class ManagementBudget
    {
        public int ManagementBudgetId { get; set; } //poner valor fijo cuando sepamos la cantidad de presupuestos que vamos a tener
        public double InitialAmount { get; set; }
        public double CurrentAmount { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Transaction Transaction { get; set; } = null!;
        public int TransactionId { get; set; }


    }
}
