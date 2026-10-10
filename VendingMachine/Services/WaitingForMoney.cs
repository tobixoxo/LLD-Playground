using System.ComponentModel.DataAnnotations;

public class WaitingForMoney : VendingMachineState
{
    public WaitingForMoney(VendingMachineContext vendingMachineContext) :  base(vendingMachineContext)
    {
        
    }

    public override void SelectProduct(int choice)
    {
        throw new InvalidOperationException("Product is already selected.");
    }

    public override void InsertMoney(decimal amount)
    {
        // render the amounts allowed - {10, 20, 50, 100} and let the user select one
        // The customer can insert multiple notes.
        if (amount != 10 && amount != 20 && amount != 50 && amount != 100)
        {
            Console.WriteLine("Invalid denomination. Please insert a valid amount.");
            return;
        }
        _context.InsertAmount += amount;
    }

    public override decimal Purchase()
    {
        if (_context.InsertAmount < _context.SelectedProduct.Price)
        {
            throw new InvalidOperationException(
                $"Inserted amount: {_context.InsertAmount}. " +
                $"Please insert more money to purchase " +
                $"{_context.SelectedProduct.Name} for ${_context.SelectedProduct.Price}");
        }

        Console.WriteLine("Money received. Dispensing product.");

        decimal change = _context.InsertAmount - _context.SelectedProduct.Price;

        _context.SelectedProduct.Quantity--;

        if (_context.SelectedProduct.Quantity == 0)
        {
            _context.Inventory.Remove(_context.SelectedProduct);
        }

        // Reset transaction
        _context.InsertAmount = 0;
        _context.SelectedProduct = null;

        _context.ChangeState(new WaitingForProduct(_context));

        return change;
    }

    public override void Cancel()
    {
        // remove selected product
        _context.SelectedProduct = null;
        _context.ChangeState(new WaitingForProduct(_context));
        // move the state to first state
    }
}