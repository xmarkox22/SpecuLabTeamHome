namespace PrototipoApi.Entities
{
    public class TransactionType
    {
        public int TransactionTypeId { get; set; }

        // Relaciones
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; } = null!;

        public DateTime LogDate { get; set; }
        public string TransactionName { get; set; } = string.Empty;
    }

}
