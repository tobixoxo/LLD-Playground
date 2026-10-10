using System.Net.Http.Headers;

Product coke = new Product ("Coke", 20, 4);
Product pepsi = new Product ("Pepsi", 20, 4);
Product sprite = new Product ("Sprite", 20, 4);
Product fanta = new Product ("Fanta", 20, 4);

List<Product> inventory = new List<Product> {coke, pepsi, sprite, fanta};

VendingMachineContext vmc = new VendingMachineContext(inventory);

Console.WriteLine("Please select a product from the following list:");
for (int i = 0; i < vmc.Inventory.Count; i++)
{
    Console.WriteLine($"{i + 1}. {vmc.Inventory[i].Name} - ${vmc.Inventory[i].Price}");
}

vmc.SelectProduct(1);


vmc.InsertMoney(100);

decimal receievedChange = vmc.Purchase();

Console.WriteLine(receievedChange);

