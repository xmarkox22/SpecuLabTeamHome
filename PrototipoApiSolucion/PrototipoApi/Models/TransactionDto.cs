namespace PrototipoApi.Models
{
    public class TransactionDto
    {
        public int TransactionId { get; set; } 
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        // Relaciones
        public int RequestId { get; set; } // Relación con Request
        public string AssociatedBudgetId { get; set; } = string.Empty;
    }
}
