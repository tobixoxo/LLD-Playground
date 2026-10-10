public class TransactionService
{
    public List<Transaction> Transactions {get;} = new();


    public bool isTransactionIdValid(Guid transactionId)
    {
        return Transactions.Exists(t => t.TransactionId == transactionId);
    }
}