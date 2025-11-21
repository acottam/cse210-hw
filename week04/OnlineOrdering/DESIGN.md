# Online Ordering System - Design Document

## Class Analysis and Responsibilities

### Current Classes (Complete)
The current implementation includes all necessary classes for the requirements:

1. **Product** - Class for all products
2. **Address** - Customer and shipping address management
3. **Customer** - Customer information container
4. **Order** - Order management and cost calculation

### Missing Classes Assessment
**No additional classes are needed** - the current design adequately covers all requirements with proper separation of concerns.

## Class Diagrams

### Product Class
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
│   string                │
└─────────────────────────┘
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
Product
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

## Key Design Principles Applied

1. **Encapsulation**: Private fields with controlled access through methods
2. **Single Responsibility**: Each class has one clear purpose
3. **Composition**: Order contains Customer, Customer contains Address

## Data Flow Summary

```
User Input → Products Created → Added to Order → 
Cost Calculated ← Address Checked ← Customer Retrieved ← 
Labels Generated ← Products Iterated
```

This design provides a clean, maintainable structure that can easily be extended with new product types or additional functionality.
