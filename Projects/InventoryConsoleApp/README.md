# 🧭 Inventory Management System

A clean and modular **C# console application** for managing inventory items.  
This project demonstrates object‑oriented programming principles such as **abstraction**, **interfaces**, **inheritance**, and **JSON‑based data persistence**.

---

## 📌 Features

### ✔ Inventory Operations
- Add new items  
- Edit existing items  
- Archive items  
- Delete items  
- View all items  

### ✔ Sorting
- Sort by date added  
- Sort by category  

### ✔ JSON Persistence
- Saves all items to `inventory.json`  
- Loads items automatically at startup  
- Uses `System.Text.Json` for serialization  

---

## 🧱 Architecture
---

## 🧩 Object‑Oriented Design

### **Abstract Class**
`AbstractItem` defines shared fields and behavior for all inventory items.

### **Inheritance**
`InventoryItem` extends `AbstractItem` and adds quantity.

### **Interface**
`IStorable` enforces Save/Load functionality.

### **Manager Class**
`InventoryManager` handles all operations and implements JSON persistence.

---

## ▶ Running the Application

1. Clone the repository  
2. Open the project in Visual Studio or VS Code  
3. Run the program  
4. Use the menu to manage your inventory  

---

## 💾 JSON Data Storage

Items are saved in `inventory.json` in the project root.

### Example JSON:

```json
[
  {
    "Id": 1,
    "Name": "Laptop",
    "Quantity": 5,
    "Category": "Electronics",
    "AddedDate": "2024-01-10T14:22:00",
    "IsArchived": false
  }
]


