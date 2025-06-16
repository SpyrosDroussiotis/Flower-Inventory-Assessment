# Flower Inventory Assessment Web Application

## Description

This web application allows users to manage an inventory of flower categories and flowers. Users can:
- Create, edit, and delete flower categories.
- Add, update, and remove flowers within each category.
- View detailed category and flower information.
- Search bar and filters for better seatching
  
---

## Implementation
- **Architecture/Structure**  
  A service layer architecture is implemented to separate business logic from the presentation layer for better code reusability and maintainability
  
- **Data Access**  
    All SQL operations are handled using SqlCommand and SqlDataAdapter

- **UI Functionality**  
  Pages have controls like Textbox , Buttons and GridViews to interact with the user. Postbacks are used for processing and refreshing data

- **Data Passing / Navigation**  
  IDs are past between pages from the URLs using query strings

---

## Technologies Used

- **ASP.NET Web Forms**
- **Microsoft SQL Server**
- **ADO.NET**
- **Visual Studio 2022**

---

## Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/SpyrosDroussiotis/Flower-Inventory-Assessment
   cd Flower-Inventory-Assessment

---

## Challenges Faced
1. **Maintining state between postbacks** : CategoryID was manually reload on postback to avoid being lost
2. **Layer Seperation** : Refacotring the code in order to Create FLower,Category and SearchAndSort services

---


## Assumptions Made
1. Each flower belongs to one Category
2. No Sign up page. User credientials for login are given by the supervisor of the user and not just creating an account on his own  
