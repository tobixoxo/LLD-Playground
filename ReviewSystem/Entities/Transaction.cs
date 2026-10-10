public class Transaction
{
    public Guid TransactionId {get; set;}
    public Guid BuyerId {get; set;}
    public Guid SellerId {get; set;}
    public DateTime CreatedAt {get; set;}

    public bool IsCompleted {get; set;}
    public DateTime CompletedAt {get; set;}

    public Transaction(Guid buyerId, Guid sellerId)
    {
        TransactionId = Guid.NewGuid();
        BuyerId = buyerId;
        SellerId = sellerId;
        CreatedAt = DateTime.UtcNow;
    }
}