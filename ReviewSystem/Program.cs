using System;
using System.Linq;

// 1. Create users
var userService = new UserService();

var buyer = new User("Alice");
var seller = new User("Bob");
var anotherBuyer = new User("Charlie");

userService.Users.Add(buyer);
userService.Users.Add(seller);
userService.Users.Add(anotherBuyer);

// 2. Create transactions
var transactionService = new TransactionService();

var transaction1 = new Transaction(buyer.UserId, seller.UserId)
{
    IsCompleted = true,
    CompletedAt = DateTime.UtcNow.AddDays(-2)
};

var transaction2 = new Transaction(anotherBuyer.UserId, seller.UserId)
{
    IsCompleted = true,
    CompletedAt = DateTime.UtcNow.AddDays(-15)
};

transactionService.Transactions.Add(transaction1);
transactionService.Transactions.Add(transaction2);

// 3. Initialize services
var reviewService = new ReviewService(transactionService, userService);
var reviewWorker = new ReviewWorker(reviewService, transactionService);

Console.WriteLine("=== Review System Demo ===");

// 4. Buyer submits a review for transaction 1
reviewService.SubmitReview(
    transaction1.TransactionId,
    buyer.UserId,
    5,
    "Great seller!");

Console.WriteLine("\nAfter buyer submits:");
PrintUserReviews(reviewService, seller.UserId, "Bob");

// 5. Seller submits a review for transaction 1
reviewService.SubmitReview(
    transaction1.TransactionId,
    seller.UserId,
    4,
    "Smooth transaction.");

Console.WriteLine("\nAfter seller submits:");
PrintUserReviews(reviewService, buyer.UserId, "Alice");
PrintUserReviews(reviewService, seller.UserId, "Bob");

// Both reviews for transaction 1 should now be published.

// 6. Charlie submits a review for transaction 2.
// The transaction completed 15 days ago, but the seller hasn't reviewed Charlie.
reviewService.SubmitReview(
    transaction2.TransactionId,
    anotherBuyer.UserId,
    3,
    "Item was as described.");

// This review should initially be waiting.
Console.WriteLine("\nBefore worker runs:");
PrintUserReviews(reviewService, seller.UserId, "Bob");

// 7. Run the worker to publish expired reviews
reviewWorker.UpdateStaleReviews();

Console.WriteLine("\nAfter worker runs:");
PrintUserReviews(reviewService, seller.UserId, "Bob");

Console.WriteLine("\n=== Demo Complete ===");

static void PrintUserReviews(
    ReviewService service,
    Guid userId,
    string userName)
{
    var reviews = service.GetReviews(userId);

    Console.WriteLine($"\nReviews received by {userName}:");

    foreach (var review in reviews)
    {
        Console.WriteLine(
            $"- Rating: {review.Rating}/5 | " +
            $"Comment: {review.Comment} | " +
            $"Status: {review.Status}");
    }

    Console.WriteLine($"Total published reviews: " +
        $"{service.GetReviewCountForUser(userId)}");

    Console.WriteLine($"Average rating: " +
        $"{service.GetAverageReviewForUser(userId):F2}");
}