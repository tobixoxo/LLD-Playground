## Vending Machine

Build a vending machine that allows a customer to purchase products.

## Products
- Coke  
- Pepsi
- Water
- Chips
Entities
- Product
    - ProductId
    - Name
    - Price
    - Quantity

Enum
- VendingState
    - WaitingForProduct
    - WaitingForMoney
    - Dispensing

Abstract Class
- VendingMachineState
    - Context
    - SelectProduct()
    - InsertMoney()
    - Purchase()
    - Cancel()

States
- WaitingForProduct
- WaitingForMoney
- Dispensing

Context
- VendingMachineContext
    - Inventory
    - CurrentState
    - SelectedProduct
    - InsertedAmount
