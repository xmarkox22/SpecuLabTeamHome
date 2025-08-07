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
        public int TransactionTypeId { get; set; }
        public TransactionType TransactionsType { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        //public int ManagementBudgetId { get; set; }
        //public ManagementBudget ManagementBudget { get; set; } = null!;
    }

}
