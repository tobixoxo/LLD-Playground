public class VendingMachineContext
{
    public List<Product> Inventory {get; set;}
    public Product? SelectedProduct {get; set;}
    private VendingMachineState _currentState {get; set;}
    public decimal InsertAmount {get; set;}

    public VendingMachineContext(List<Product> inventory)
    {
        Inventory = inventory;
        InsertAmount = 0;
        SelectedProduct = null;

        _currentState = new WaitingForProduct(this);
    }

    public void SelectProduct(int choice)
    {
        _currentState.SelectProduct(choice);
    }
    public void InsertMoney(decimal money)
    {
        _currentState.InsertMoney(money);
    }
    public decimal Purchase()
    {
        return _currentState.Purchase();
    }
    public void Cancel()
    {
        _currentState.Cancel();
    }

    public void ChangeState(VendingMachineState newState)
    {
        _currentState = newState;
    }

}