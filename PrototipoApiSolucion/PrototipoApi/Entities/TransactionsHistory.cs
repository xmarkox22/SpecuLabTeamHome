namespace PrototipoApi.Entities
{
    public class TransactionsHistory
    {
        public int TransactionHistoryId { get; set; }

        // Relaciones
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; } = null!;

        public DateTime LogDate { get; set; }

        /// <summary>
        /// Acción registrada sobre la transacción (por ejemplo: "CREATED", "UPDATED", "DELETED").
        /// </summary>
        public string ActionType { get; set; } = string.Empty;
    }

}
