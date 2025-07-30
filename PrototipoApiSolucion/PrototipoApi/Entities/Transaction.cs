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

        /// <summary>
        /// Tipo de transacción.
        /// Valores posibles: "INGRESO", "GASTO".
        /// </summary>
        public string TransactionType { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int AssociatedBudgetId { get; set; }
        public TotalBudget AssociatedBudget { get; set; } = null!;
    }

}
