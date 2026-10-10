public abstract class VendingMachineState
{
    public VendingMachineContext _context;

    public VendingMachineState(VendingMachineContext context)
    {
        _context = context;
    }

    public abstract void SelectProduct(int choice);
    public abstract void InsertMoney(decimal money);
    public abstract decimal Purchase();
    public abstract void Cancel();
}