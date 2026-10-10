public class ReviewService
{
    public List<Review> Reviews {get; } =  new();

    private readonly TransactionService _transactionService ;
    private readonly UserService _userService;

    public ReviewService(TransactionService transactionService, UserService userService)
    {
        _transactionService = transactionService;
        _userService = userService;
    }

    public bool SubmitReview(Guid transactionId, Guid userId, int rating, string comment)
    {
        if(_transactionService.isTransactionIdValid(transactionId) == false)
        {
            throw new InvalidOperationException("transaction is invalid");
        }
        if(_userService.isUserIdValid(userId) == false)
        {
            throw new InvalidOperationException("User is invalid");
        }

        Guid transactionBuyerId = _transactionService.Transactions
        .First(t => t.TransactionId == transactionId).BuyerId;

        Guid transactionSellerId = _transactionService.Transactions
        .First(t => t.TransactionId == transactionId).SellerId;

        if(userId != transactionBuyerId && userId != transactionSellerId)
        {
            throw new InvalidOperationException("user is not allowed to review for the current transaction");
        }

        bool reviewAlreadyPresent = Reviews
        .Exists(r => r.ReviewerId == userId && r.TransactionId == transactionId);

        if (reviewAlreadyPresent)
        {
            throw new InvalidOperationException("Review is already present by the user for this transaction");
        }

        if(!(rating >= 1 && rating <= 5))
        {
            throw new InvalidOperationException("Rating is Invalid");
        }

        Guid revieweeId = (userId == transactionBuyerId) ? transactionSellerId : transactionBuyerId;
        Review review = new Review(rating, comment, userId, revieweeId, transactionId);
        Reviews
        .Add(review)
        ;
        Review? revieweeReview = Reviews
        .FirstOrDefault(t => t.ReviewerId == revieweeId && t.TransactionId == transactionId);

        if(revieweeReview != null)
        {
            revieweeReview.Status = ReviewStatus.Published;
            review.Status = ReviewStatus.Published;
        }
        return true;
    }

    public List<Review> GetReviews(Guid userId)
    {
        if(_userService.isUserIdValid(userId) == false)
        {
            throw new InvalidOperationException("User is invalid");
        }

        return Reviews.Where(r => r.RevieweeId == userId && r.Status == ReviewStatus.Published).ToList();
    }

    public int GetReviewCountForUser(Guid userId)
    {
        if(_userService.isUserIdValid(userId) == false)
        {
            throw new InvalidOperationException("User is invalid");
        }

        return Reviews.Count(r => r.RevieweeId == userId && r.Status == ReviewStatus.Published);
    }

    public decimal? GetAverageReviewForUser(Guid userId)
    {
        if(_userService.isUserIdValid(userId) == false)
        {
            throw new InvalidOperationException("User is invalid");
        }

        decimal userReviewsRatings = Reviews.Where(r => r.RevieweeId == userId && r.Status == ReviewStatus.Published).Sum(r => r.Rating);

        decimal userReviewCount = Reviews.Count(r => r.RevieweeId == userId && r.Status == ReviewStatus.Published);

        if(userReviewCount == 0)
            return null;
        
        return userReviewsRatings / userReviewCount ;
    }
}