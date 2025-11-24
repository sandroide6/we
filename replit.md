# TechStore - Tienda de Tecnología

## Overview
TechStore is a modern, professional online technology store built with ASP.NET Core 8.0 Blazor Server. It enables users to browse, customize, and purchase tech products, including hardware, software, and IT services. The project aims to demonstrate a fully functional e-commerce platform with robust authentication, an interactive product catalog, product customization, a shopping cart, and an order management system, all within a modern UI/UX design.

## User Preferences
I prefer detailed explanations.
Do not make changes to the folder `Z`.
Do not make changes to the file `Y`.

## System Architecture

### UI/UX Decisions
The application features a modern, professional dark theme with cyan and black gradients, utilizing the Inter typeface, smooth animations, and fluid transitions. The interface is responsive, optimized for various devices, and includes interactive elements like hover effects, a professionally styled navbar, a shopping cart with visual feedback, and an animated user menu dropdown.

### Technical Implementations
- **Authentication System**: Full login and registration with BCrypt password hashing (workFactor: 12), email/password validation, user profiles with avatar support, secure password change, and persistent sessions. Requires authentication for checkout and order history. Uses ASP.NET Core Cookie Authentication with persistent HTTP-only cookies (30 days duration), API endpoints for auth, custom `TechStoreAuthenticationStateProvider`, and `UsuarioService`. Incorporates CSRF protection with antiforgery tokens.
- **Interactive Catalog**: Product display with high-quality images, dynamic filters, real-time search, wishlist/favorites integration, and detailed descriptions.
- **Product Customization**: A modal system for customizing products (e.g., RAM, SSD upgrades) with real-time price calculation.
- **Shopping Cart**: Enhanced `CarritoService` for managing quantities, item removal, automatic total calculation, and a floating cart widget. The cart functions without login; checkout requires authentication.
- **Wishlist/Favorites**: Users can save favorite products to their account with database persistence, accessible via the user menu.
- **Order System**: Checkout form with data validation, customer information capture, and a complete order history per user, including customized specifications and status tracking (Pendiente, EnProceso, Enviado, Entregado, Cancelado).
- **WhatsApp Integration**: After successful checkout, the system automatically redirects to WhatsApp (number: 3003895839) with a pre-formatted message containing complete order details (customer info, products, specifications, quantities, totals).
- **User Profile**: Enhanced profile page with avatar support, user statistics (total orders, completed orders, favorite products count), view and edit personal information (city, country, contact number), saved shipping address, and secure password changes. Displays complete order history.

### Feature Specifications
- **Data Models**: `Usuario` (with AvatarUrl, Ciudad, Pais, ProductosFavoritos), `ProductoFavorito`, `ProductoTecnologico`, `Especificacion`, `Orden` (with Estado enum), `ItemOrden`, and `EspecificacionOrden`.
- **Data Layer**: `TechStoreContext` (Entity Framework Core with SQLite) for persistent data storage and seed data. `CarritoService` manages shopping cart state. `UsuarioService` handles authentication, profile updates, and wishlist management.
- **Security**: BCrypt password hashing (workFactor 12), form validation, and SQL injection prevention via Entity Framework.

### System Design Choices
The application is built using ASP.NET Core 8.0 with Blazor Server-Side for the UI. SQLite serves as the database with Entity Framework Core 8.0. C# 12 is the primary programming language. The project structure organizes components, data services, models, and static assets. Data flow involves service-based state management and Entity Framework's `Include`/`ThenInclude` for loading related entities.

## External Dependencies
- **Framework**: ASP.NET Core 8.0
- **UI Framework**: Blazor Server-Side
- **Database**: SQLite (via Entity Framework Core 8.0) with persistent data storage
- **Programming Language**: C# 12 (.NET 8)
- **Security**: BCrypt.Net-Next 4.0.3 for password hashing
- **Images**: Unsplash
- **Fonts**: Google Fonts (Inter)