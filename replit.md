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
- **Cart System**: SessionStorage (browser-based, persistent during user session)

### Feature Specifications
- **Authentication**: Full login/registration system with SHA256 password hashing, email validation, user profiles, secure password change, and persistent user sessions.
- **Product Catalog**: Interactive catalog with category navigation (Hardware, Software, IT Services), product cards with high-quality images, dynamic filters, and detailed product descriptions.
- **Product Customization**: Modal system for personalizing products with additional specifications (e.g., RAM, SSD, extended warranties). Automatic price calculation based on selected specifications with real-time preview.
- **Shopping Cart**: Comprehensive cart management using SessionStorage for reliability, including quantity modification, item removal, automatic total calculations, and requiring authentication for checkout.
- **Order System**: Checkout form with data validation, customer information capture, user-specific order history, detailed viewing of customized specifications in past orders, and orders linked to user accounts.
- **User Profile**: View and edit personal information (shipping address, phone, membership history) and securely change passwords.

### System Design Choices
- **Project Structure**: Organized into `Components` (UI layout, pages), `Data` (EF Core context, services), `Models` (entity definitions), and `wwwroot` (static assets).
- **Data Models**: `Usuario`, `ProductoTecnologico`, `Especificacion`, `Orden`, `ItemOrden`, `EspecificacionOrden` define the core entities and their relationships.
- **Data Layer**: `TechStoreContext` manages SQLite interaction with EF Core, including seed data for products and specifications. `CarritoService` (Scoped) manages shopping cart state using SessionStorage. `UsuarioService` (Scoped) handles all user authentication and profile management, including secure password hashing and session management.
- **Data Flow**: Products are added to SessionStorage via `CarritoService` from the catalog or personalization modals. Checkout loads cart items from SessionStorage, reloads product details from DB, and persists orders. Order history loads detailed orders with all related entities using EF Core's `Include`/`ThenInclude`.
- **Security**: Form validation, SQL injection prevention via Entity Framework, separation of concerns, and protected routes requiring authentication for checkout and order history.

## External Dependencies
- **Database**: SQLite
- **ORM**: Entity Framework Core 8.0
- **Fonts**: Google Fonts (Inter)
- **Image Assets**: Unsplash (for product images)

## Development Notes - Session Nov 23, 2025

### ✅ CARRITO COMPLETAMENTE RECONSTRUIDO - NUEVA ARQUITECTURA

**Major Change**: Replaced unstable Singleton-based EstadoPedido system with SessionStorage-based CarritoService

**Problems with old system**:
- EstadoPedido (Singleton) in memory was not thread-safe
- MainLayout (SSR) couldn't reliably communicate with Index (InteractiveServer)
- CarritoNotificador event system was flaky and only worked once
- Product references were being lost when EntityFramework disconnected items

**New Solution: SessionStorage Architecture** ✅
- **CarritoService**: Scoped service that persists cart items to browser SessionStorage
- Items are serialized as JSON and stored client-side
- SessionStorage persists during the user's session
- MainLayout reads from SessionStorage on navigation
- No cross-component communication needed
- No threading issues
- No EntityFramework reference problems

**How it works**:
1. Index.razor (InteractiveServer) uses CarritoService to add items
2. CarritoService serializes items and saves to SessionStorage via JS interop
3. User navigates (LocationChanged event triggers)
4. MainLayout calls ActualizarCarrito() which reads sessionStorage
5. MainLayout updates cart counter and total
6. Checkout.razor loads items from sessionStorage and reloads product details from DB

**Files Changed**:
- Created: `Data/CarritoService.cs` - SessionStorage-based cart management
- Removed: `Data/EstadoPedido.cs` - Old singleton (no longer needed)
- Removed: `Data/CarritoNotificador.cs` - Old event system (no longer needed)
- Updated: `Program.cs` - Register CarritoService instead of EstadoPedido
- Updated: `Components/Pages/Index.razor` - Use CarritoService
- Updated: `Components/Pages/Checkout.razor` - Read from CarritoService
- Updated: `Components/Layout/MainLayout.razor` - Read from SessionStorage on navigation

**Benefits**:
- ✅ Extremely reliable - uses browser's SessionStorage
- ✅ Simple to understand and maintain
- ✅ No threading issues
- ✅ Works multiple times without degradation
- ✅ Cart data persists across page refreshes during session
- ✅ Cart updates on navigation

