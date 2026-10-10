public class Review
{
    public Guid ReviewId {get; set;}
    public int Rating {get; set;}
    public string? Comment {get; set;}
    public Guid ReviewerId {get; set;}
    public Guid RevieweeId {get; set;}
    public Guid TransactionId {get; set;}

    public ReviewStatus Status {get; set;}

    public DateTime CreatedAt {get; set;}

    public Review(int rating, string? comment, Guid reviewerId, Guid revieweeId, Guid transactionId)
    {
        ReviewId = Guid.NewGuid();
        Rating = rating;
        Comment = comment;
        ReviewerId = reviewerId;
        RevieweeId = revieweeId;
        TransactionId = transactionId;
        Status = ReviewStatus.Waiting;
        CreatedAt = DateTime.UtcNow;
    }

}