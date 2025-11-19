# Online Ordering System - Design Document

## Class Analysis and Responsibilities

### Current Classes (Complete)
The current implementation includes all necessary classes for the requirements:

1. **Product** - Base class for all products
2. **OutdoorProduct** - Specialized product with safety warnings
3. **SwimmingProduct** - Specialized product with safety instructions
4. **Address** - Customer and shipping address management
5. **Customer** - Customer information container
6. **Order** - Order management and cost calculation

### Missing Classes Assessment
**No additional classes are needed** - the current design adequately covers all requirements with proper separation of concerns.

## Class Diagrams

### Product Class Hierarchy
```
┌─────────────────────────┐
│       Product           │
├─────────────────────────┤
│ - _name: string         │
│ - _price: double        │
│ - _productId: int       │
├─────────────────────────┤
│ + Product(name, price,  │
│   productId)            │
│ + GetPrice(): double    │
│ + GetPackingLabel():    │
│   string (virtual)      │
└─────────────────────────┘
           ▲
           │
    ┌──────┴──────┐
    │             │
┌───▼────────┐ ┌──▼─────────────┐
│OutdoorProd │ │ SwimmingProduct│
├────────────┤ ├────────────────┤
│(inherits   │ │ (inherits all  │
│all from    │ │ from Product)  │
│Product)    │ ├────────────────┤
├────────────┤ │+ SwimmingProd  │
│+ OutdoorPr │ │  (name, price, │
│  (name,    │ │  productId)    │
│  price,    │ │+ GetPackingLab │
│  productId)│ │  el(): string  │
│+ GetPacking│ │  (override)    │
│  Label():  │ └────────────────┘
│  string    │
│  (override)│
└────────────┘
```

### Address Class
```
┌─────────────────────────┐
│       Address           │
├─────────────────────────┤
│ - _street: string       │
│ - _city: string         │
│ - _state: string        │
│ - _country: string      │
├─────────────────────────┤
│ + Address(street, city, │
│   state, country)       │
│ + IsInUSA(): bool       │
│ + GetDisplayText():     │
│   string                │
└─────────────────────────┘
```

### Customer Class
```
┌─────────────────────────┐
│       Customer          │
├─────────────────────────┤
│ - _name: string         │
│ - _address: Address     │
├─────────────────────────┤
│ + Customer(name,        │
│   address)              │
│ + GetName(): string     │
│ + GetAddress(): Address │
└─────────────────────────┘
```

### Order Class
```
┌─────────────────────────┐
│        Order            │
├─────────────────────────┤
│ - _products: List<Prod> │
│ - _customer: Customer   │
├─────────────────────────┤
│ + Order(customer)       │
│ + AddProduct(product)   │
│ + CalculateTotalCost(): │
│   double                │
│ + GetPackingLabel():    │
│   string                │
│ + GetShippingLabel():   │
│   string                │
└─────────────────────────┘
```

## Class Relationships
```
Order ──────► Customer ──────► Address
  │
  │ (contains list)
  ▼
Product ◄──── OutdoorProduct
        ◄──── SwimmingProduct
```

## Program Flow Chart

```
START
  │
  ▼
Create Addresses
  │
  ▼
Create Customers (with addresses)
  │
  ▼
Create Products (various types)
  │
  ▼
Create Orders (with customers)
  │
  ▼
Add Products to Orders
  │
  ▼
For Each Order:
  ├─ Generate Packing Label
  │  └─ Call GetPackingLabel() on each product
  │     └─ Use polymorphism for special labels
  │
  ├─ Generate Shipping Label
  │  └─ Get customer name and address
  │
  └─ Calculate Total Cost
     ├─ Sum all product prices
     └─ Add shipping cost based on address
  │
  ▼
Display Results
  │
  ▼
END
```

## Method Interaction Flow

### Order Processing Sequence:
1. **Order Creation**: `new Order(customer)`
2. **Product Addition**: `order.AddProduct(product)` (multiple calls)
3. **Label Generation**: 
   - `order.GetPackingLabel()` → calls `product.GetPackingLabel()` for each product
   - `order.GetShippingLabel()` → calls `customer.GetName()` and `customer.GetAddress().GetDisplayText()`
4. **Cost Calculation**: 
   - `order.CalculateTotalCost()` → calls `product.GetPrice()` for each product
   - Uses `customer.GetAddress().IsInUSA()` for shipping cost

### Polymorphism in Action:
```
Product.GetPackingLabel() (base)
    ↓
OutdoorProduct.GetPackingLabel() (override) → adds waiver warning
SwimmingProduct.GetPackingLabel() (override) → adds safety instructions
```

## Key Design Principles Applied

1. **Inheritance**: Product hierarchy with specialized behavior
2. **Polymorphism**: Virtual method overriding for different product labels
3. **Encapsulation**: Private fields with controlled access through methods
4. **Single Responsibility**: Each class has one clear purpose
5. **Composition**: Order contains Customer, Customer contains Address

## Data Flow Summary

```
User Input → Products Created → Added to Order → 
Cost Calculated ← Address Checked ← Customer Retrieved ← 
Labels Generated ← Polymorphic Methods Called ← Products Iterated
```

This design provides a clean, maintainable structure that can easily be extended with new product types or additional functionality.
