using StaticFactoryMethods_2.Entities;

Product tshirt = Product.CreateClothing("T-Shirt Be Catholic is beauty.", 110);
Product cellphone = Product.CreateEletronics("Redmi 9", 1200);
Product burguer = Product.CreateFood("Big Mac", 35);

Console.WriteLine(tshirt.GetProduceDetails() + " / " + tshirt.GetPriceWithTax());
Console.WriteLine(cellphone.GetProduceDetails() + " / " + cellphone.GetPriceWithTax());
Console.WriteLine(burguer.GetProduceDetails() + " / " + burguer.GetPriceWithTax());