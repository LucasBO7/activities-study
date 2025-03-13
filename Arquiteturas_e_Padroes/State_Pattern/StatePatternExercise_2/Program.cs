Order order = new Order();

order.Approve(); // ✅ Pedido aprovado!
order.Ship();    // ✅ Pedido enviado!
order.Deliver(); // ✅ Pedido entregue!
order.Cancel();  // ❌ Não é possível cancelar o pedido neste estado.