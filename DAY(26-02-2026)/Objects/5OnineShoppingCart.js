let cart = [
  { product: "Laptop", price: 50000, qty: 1 },
  { product: "Mouse", price: 500, qty: 2 },
  { product: "Keyboard", price: 1500, qty: 1 }
];
let total = cart.map(pro => pro.price);
console.log("Total: ", total);
let proName = cart.map(pro => pro.product);
console.log("Products: ", proName);
let updatedCart = cart.map(pro => {
  return {
    product: pro.product,
    price: pro.price,
    qty: pro.qty,
  };
});
console.log("Updated Cart",updatedCart);