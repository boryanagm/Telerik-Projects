<img src="https://i.imgur.com/yqIN5FX.png" width="300px" />

# Cosmetics shop - workshop (OOP - Principles exercise)

### 1. Description
You're provided with a skeleton of the Cosmetics shop. It already has a working Engine. You do not have to touch anything in it. Just use it. There should be two types of products for now, Shampoos and Toothpastes. Your **task** is to **design an object-oriented class hierarchy** (only two fo now) to model the cosmetics shop, **using the best practices for object-oriented design** (OOD) and **object-oriented programming** (OOP). Encapsulate correctly all fields and use validation whenever needed. Unit tests are present to help you along the way - don't forget to use them! At the end of this document we've provided you with an example of an input and output. Also, all needed interfaces are present. **You must use them all** in order to achieve the best OOP design. 

Some general notes and constraints:
- You don't need to take care of the Engine class and the Main method but of course you could try to understand how they work.
- To simplify your work you are given an already built execution engine that executes a sequence of commands read from the console using the classes and interfaces in your project (see the Cosmetics-Skeleton folder)

### 2. Project information

- Framework: **.NET Core 3.1**
- Language and version: **C# 8.0**

### 3. Shampoo class
#### Description
Below you'll find a list of tasks and constraints you need to follow in order to implement the Shampoo product correctly:
- Implements IShampoo
- It has **name, brand, price, gender, milliliters, usage**
- Minimum shampoo name’s length is 3 symbols and maximum is 10 symbols.
- Minimum shampoo brand name’s length is 2 symbols and maximum is 10 symbols.
- Price cannot be negative.
- Gender type can be **"Men"**, **"Women"** or **"Unisex"**.
- Milliliters are not negative number
- Usage type can be **"EveryDay"** or **"Medical"**
- If a null value is passed to some mandatory property, your program should throw a proper exception.
> Note - All number type fields should be printed “as is”, without any formatting or rounding.

> **Hint**: Use the Unit tests whenever you finish a task.


### 4. Toothpaste class
#### Description
Below you'll find a list of tasks and constraints you need to follow in order to implement the Toothpaste product correctly:
- Implements IToothpaste
- It has **name, brand, price, gender, ingredients**
- Minimum toothpaste name’s length is 3 symbols and maximum is 10 symbols.
- Minimum toothpaste brand name’s length is 2 symbols and maximum is 10 symbols.
- Price cannot be negative.
- Gender type can be **"Men"**, **"Women"** or **"Unisex"**.
- Ingredients are comma separated values
- If a null value is passed to some mandatory property, your program should throw a proper exception.
> Note - All number type fields should be printed “as is”, without any formatting or rounding.

> **Hint**: Use the Unit tests whenever you finish a task.


### 5. CosmeticsFactory class
#### Description
CosmeticsFactory class should be responsible for creating all the products(ex. `CreateShampoo`, `CreateToothpaste`) as well as the ShoppingCart and The Category(`CreateCategory` and `CreateShoppingCart`). The signature of the required methods is already provided, you just need to implement them.

> **Constraint 1** - All properties in the above interfaces are mandatory (cannot be null or empty).

> **Constraint 2** - You are **only allowed** to create classes. You are **not allowed** to **modify the existing interfaces and classes** except the **CosmeticsFactory** class and **ICosmeticsFactory** interface.


### Input example

```
CreateShampoo MyMan Nivea 10.99 Men 1000 EveryDay
CreateToothpaste White Colgate 10.99 Men calcium,fluorid
CreateCategory Shampoos
CreateCategory Toothpastes
AddToCategory Shampoos MyMan
AddToCategory Toothpastes White
AddToShoppingCart MyMan
AddToShoppingCart White
ShowCategory Shampoos
ShowCategory Toothpastes
TotalPrice
RemoveFromCategory Shampoos MyMan
ShowCategory Shampoos
RemoveFromShoppingCart MyMan
TotalPrice
```

### Output Example

```
Shampoo with name MyMan was created!
Toothpaste with name White was created!
Category with name Shampoos was created!
Category with name Toothpastes was created!
Product MyMan added to category Shampoos!
Product White added to category Toothpastes!
Product MyMan was added to the shopping cart!
Product White was added to the shopping cart!
#Category: Shampoos
#MyMan Nivea
 #Price: $10.99
 #Gender: Men
 #Milliliters: 1000
 #Usage: EveryDay
 ===
#Category: Toothpastes
#White Colgate
 #Price: $10.99
 #Gender: Men
 #Ingredients: calcium, fluorid
 ===
$21.98 total price currently in the shopping cart!
Product MyMan removed from category Shampoos!
#Category: Shampoos
 #No product in this category
Product MyMan was removed from the shopping cart!
$10.99 total price currently in the shopping cart!
```
> **Note** - Don't worry if your program prints with a ','(comma) as a decimal separator instead a '.'(dot). That's a Windows setting and not an issue with your implementation.

### 6. OPTIONAL ADVANCED TASK - Cream class
#### Description
- Implement new product and its creation in the engine class. 
- Cream (name, brand, price, gender, scent)
    - name minimum 3 symbols and maximum 15
    - brand minimum 3 symbols and maximum 15
    - price greater than zero
    - gender (men, women, unisex)
    - scent (lavender, vanilla, rose)
- Implement product creation in the Factory and the Engine
    - Just look at the other products
- Test it if it works correctly

