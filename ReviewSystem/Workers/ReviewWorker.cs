// worker class that will run at a set frequency
public class ReviewWorker
{
    private readonly ReviewService _reviewService;
    private readonly TransactionService _transactionService;

    public ReviewWorker(ReviewService reviewService, TransactionService transactionService)
    {
        _reviewService = reviewService;
        _transactionService = transactionService;
    }

    public void UpdateStaleReviews()
    {
        List<Guid> eligibleTransactionIds = _transactionService.Transactions
        .Where(t => t.CompletedAt.AddDays(14) <= DateTime.UtcNow && 
            t.IsCompleted)
        .Select(t => t.TransactionId)
        .ToList();

        List<Review> reviews = _reviewService.Reviews
        .Where(r => eligibleTransactionIds.Contains(r.TransactionId))
        .ToList();

        foreach(Review review in reviews)
        {
            review.Status = ReviewStatus.Published;
        }
    }
}