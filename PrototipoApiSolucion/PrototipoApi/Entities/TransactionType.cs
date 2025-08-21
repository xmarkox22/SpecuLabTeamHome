namespace PrototipoApi.Entities
{
    public class TransactionType
    {
        public int TransactionTypeId { get; set; }
        public string TransactionName { get; set; } = string.Empty;

        // lista de transacciones asociadas a este tipo
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }

}
