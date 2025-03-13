using OrderProcessing.Entities;

OrderProcessor processor = new();
decimal totalPrice = 200;
decimal finalPrice = 0;

finalPrice = processor.CalculateTotal(totalPrice);
Console.WriteLine("Com taxa de entrega: " + finalPrice);

processor.ChangePriceCalculationTo(new DeliveryFeeProcessor());
finalPrice = processor.CalculateTotal(totalPrice);
Console.WriteLine("Com taxa de entrega: " + finalPrice);

processor.ChangePriceCalculationTo(new DiscountProcessor());
finalPrice = processor.CalculateTotal(totalPrice);
Console.WriteLine("Com desconto: " + finalPrice);

processor.ChangePriceCalculationTo(new PersonalizedPriceProcessor());
finalPrice = processor.CalculateTotal(totalPrice);
Console.WriteLine("Com taxa personalizada: " + finalPrice);