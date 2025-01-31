using StaticFactoryMethods_2.Entities;

Clothing tshirt = Clothing.CreateClothing("T-Shirt Be Catholic is beauty.", 110);
Electronics cellphone = Electronics.CreateEletronic("Redmi 9", 1200);
Food burguer = Food.CreateFood("Big Mac", 35);

Console.WriteLine(tshirt.GetProduceDetails() + " / " + tshirt.GetPriceWithTax());
Console.WriteLine(cellphone.GetProduceDetails() + " / " + cellphone.GetPriceWithTax());
Console.WriteLine(burguer.GetProduceDetails() + " / " + burguer.GetPriceWithTax());