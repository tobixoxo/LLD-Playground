public class WaitingForProduct : VendingMachineState
{
    public WaitingForProduct(VendingMachineContext vendingMachineContext) :  base(vendingMachineContext)
    {
        
    }

    public override void SelectProduct(int choice)
    {
        // select one product
        if (choice < 1 || choice > _context.Inventory.Count)
        {
            Console.WriteLine("Invalid choice. Please select a valid product.");
            return;
        }
        _context.SelectedProduct = _context.Inventory[choice - 1];
        Console.WriteLine($"You have selected {_context.SelectedProduct.Name} for ${_context.SelectedProduct.Price}");
        _context.ChangeState(new WaitingForMoney(_context)); // change state to waiting for money
    }

    public override  void InsertMoney(decimal money)
    {
        throw new InvalidOperationException("Cannot Insert Money before selecting a product.");
    }

    public override decimal Purchase()
    {
        throw new InvalidOperationException("Cannot Purchase Item in Product Selection Mode");
    }

    public override void Cancel()
    {
        // clear the cart
        _context.SelectedProduct = null;
        // keep the same state
    }
}