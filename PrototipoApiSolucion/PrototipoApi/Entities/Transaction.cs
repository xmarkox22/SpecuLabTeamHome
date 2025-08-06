namespace PrototipoApi.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        // Relaciones
        public int RequestId { get; set; }
        public Request Request { get; set; } = null!;
        public DateTime TransactionDate { get; set; }
        public double Amount { get; set; }

        // Tipo de transacción.
        // Valores posibles: "INGRESO", "GASTO".
        public string TransactionTypeId { get; set; } = string.Empty;
        public TransactionsType TransactionType { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public int AssociatedBudgetId { get; set; }
        public ManagementBudget AssociatedBudget { get; set; } = null!;
    }

}
