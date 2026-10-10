 Level 1: Core Review System
 Goal: Implement the foundational features of the review system for buyers and sellers.

Functional Requirements:
Allow both buyer and seller to leave a review after an order is completed.
A review includes:
rating (1 to 5)
comment (optional)
reviewer_id and reviewee_id
transaction_id (to bind it to the order)
Reviews are published only after both parties submit their reviews, or automatically after 14 days if one party fails to respond.
Provide APIs to:
Submit a review 
Fetch published reviews for a user
Show for each user:
Total review count
Average rating
Constraints:
Assume each transaction results in only one review per user.
No requirement for replies, compliments, or real-time aggregation at this level.

# Entities
- Review
  - ReviewId : Guid
  - Rating : Integer 
  - Comment : Text
  - ReviewerId : Guid
  - RevieweeId : Guid
  - TransactionId : Guid
  - Status : Enum
  - CreatedAt : DateTime

- Transaction
  - TransactionId : Guid
  - Buyer : User
  - Seller : User
  - CreatedAt : DateTime
  - CompletedAt : DateTime

- User
  - UserId : Guid
  - Name : String

## Enums
- Status
  - Waiting
  - Published

## Services
- ReviewService
  - List<Review> Reviews
  - SubmitReview(Guid transactionId, Guid userId, rating, comment) : Void
    - Validation on the identifiers
    - validater userId is authorized to review the tranasation
    - Validated that no review for the same exists for the same transaction
    - pull tyransaction/ user fields that are required
    - create review Object
    - return success
  
  - GetReviewsForUser(Guid userId) : List<Review>
    - validate identifier for user id
    - return reviews where user id is a reviewer 
  
  - GetReviewCount(Guid userId) : Integer
    - validate the userid identifier
    - return the count
  - GetAverageRating(Guid userId) : Integer
    - validate the identifier 
    - return the average rating

- UserService
  - List<User> users
  - isUserIdValid(id) : bool

- TransactionService
  - List<Transaction> transactions
  - isTransactionIdValid(id) : bool

## Worker
- ReviewWorker
  - Run at a set Frequency 
  - Iterate through all the reviews
  - get a list of all the reviews that has 
  - expired (14 days past)
  - make of all of them published