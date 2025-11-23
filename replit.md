# TechStore - Tienda de Tecnología

## Overview
TechStore is a modern, professional online technology store built with ASP.NET Core 8.0 Blazor Server. It enables users to browse, customize, and purchase tech products, including hardware (laptops, PCs, monitors), software (licenses, office suites), and IT services (technical support, custom development). The project aims to showcase a full-featured e-commerce platform with a focus on interactive product customization and a seamless user experience.

## User Preferences
I prefer iterative development, so please propose changes and improvements in small, manageable steps. Before making any major architectural changes or introducing new libraries, please ask for my approval. I appreciate clear and concise explanations, avoiding overly technical jargon where possible. Ensure all code changes are well-commented and follow C# best practices. Do not make changes to the `wwwroot` folder directly without explicit instruction, as it contains static assets.

## System Architecture

### UI/UX Decisions
The application features a modern and professional design with a dark theme utilizing cyan and black gradients. It employs the Inter font from Google Fonts for a contemporary look. The interface is responsive across devices, incorporating smooth animations, fluid transitions, and interactive hover effects. A dropdown menu provides user-specific options in the header.

### Technical Implementations
- **Framework**: ASP.NET Core 8.0
- **UI**: Blazor Server-Side
- **Database**: SQLite with Entity Framework Core 8.0
- **Language**: C# 12 (.NET 8)

### Feature Specifications
- **Authentication**: Full login/registration system with SHA256 password hashing, email validation, user profiles, secure password change, and persistent user sessions.
- **Product Catalog**: Interactive catalog with category navigation (Hardware, Software, IT Services), product cards with high-quality images, dynamic filters, and detailed product descriptions.
- **Product Customization**: Modal system for personalizing products with additional specifications (e.g., RAM, SSD, extended warranties). Automatic price calculation based on selected specifications with real-time preview.
- **Shopping Cart**: Comprehensive cart management, including quantity modification, item removal, automatic total calculations, and requiring authentication for checkout.
- **Order System**: Checkout form with data validation, customer information capture, user-specific order history, detailed viewing of customized specifications in past orders, and orders linked to user accounts.
- **User Profile**: View and edit personal information (shipping address, phone, membership history) and securely change passwords.

### System Design Choices
- **Project Structure**: Organized into `Components` (UI layout, pages), `Data` (EF Core context, services), `Models` (entity definitions), and `wwwroot` (static assets).
- **Data Models**: `Usuario`, `ProductoTecnologico`, `Especificacion`, `Orden`, `ItemOrden`, `EspecificacionOrden` define the core entities and their relationships.
- **Data Layer**: `TechStoreContext` manages SQLite interaction with EF Core, including seed data for products and specifications. `EstadoPedido` (Singleton) manages the shopping cart state across user sessions. `UsuarioService` (Scoped) handles all user authentication and profile management, including secure password hashing and session management.
- **Data Flow**: Products are added to `EstadoPedido` from the catalog or personalization modals. Checkout clones cart items and persists them to the database. Order history loads detailed orders with all related entities using EF Core's `Include`/`ThenInclude`.
- **Security**: Form validation, SQL injection prevention via Entity Framework, separation of concerns, and protected routes requiring authentication for checkout and order history.

## External Dependencies
- **Database**: SQLite
- **ORM**: Entity Framework Core 8.0
- **Fonts**: Google Fonts (Inter)
- **Image Assets**: Unsplash (for product images)
## Development Notes - Session Nov 23, 2025

### CARRITO COMPLETAMENTE FUNCIONAL ✅

**Final Fix**: Created `CarritoNotificador` (Singleton) service with async thread-safe events
- Index.razor (InteractiveServer) adds items and notifies via `CarritoNotificador.NotificarCambio()`
- MainLayout (SSR) receives notification and updates via `InvokeAsync(() => StateHasChanged())`
- **Result**: Cart updates INSTANTLY in navbar when items are added ✅

**Technical Stack**:
- EstadoPedido: Singleton that holds cart items
- CarritoNotificador: Singleton event bus for component communication  
- MainLayout: Subscribes to cart notifications
- Index.razor: Triggers notifications on add-to-cart actions
