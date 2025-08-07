namespace PrototipoApi.Entities
{
    public class TransactionType
    {
        public int TransactionTypeId { get; set; }


        public DateTime LogDate { get; set; }
        public string TransactionName { get; set; } = string.Empty;
    }

}
