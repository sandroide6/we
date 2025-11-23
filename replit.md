# Mi Portafolio - Professional Portfolio Website

## Overview
A professional portfolio website built with ASP.NET Core 8.0 Blazor Server. Showcases projects, skills, and professional experience with a modern, clean design featuring a cyan and dark blue gradient color scheme. The application provides an elegant way to display full-stack development work and contact information.

## User Preferences
- Iterative development with small, manageable changes
- Clear, concise explanations without overly technical jargon
- Well-commented C# code following best practices
- Professional, modern design with smooth animations
- Do not modify `wwwroot` folder directly without explicit instruction

## System Architecture

### UI/UX Design
- Modern professional design with dark theme
- Cyan and dark blue gradient color scheme
- Responsive layout across all devices
- Smooth animations and transitions
- Inter font from Google Fonts for contemporary look

### Technical Stack
- **Framework**: ASP.NET Core 8.0
- **UI**: Blazor Server-Side (InteractiveServer rendermode)
- **Database**: SQLite with Entity Framework Core 8.0
- **Language**: C# 12 (.NET 8)

### Project Structure
```
/Models          - Entity definitions (Proyecto.cs)
/Data            - EF Core context (PortfolioContext.cs)
/Components      - Blazor pages and layout
  /Pages         - Page components (Index.razor)
  /App.razor     - App root component
  /Routes.razor  - Route definitions
/wwwroot         - Static assets (CSS, images, favicon)
  /css           - Stylesheets (app.css)
```

### Data Model
**Proyecto Entity**:
- `Id` - Project identifier
- `Titulo` - Project title
- `Descripcion` - Project description
- `ImagenUrl` - Project image URL
- `UrlProyecto` - GitHub/project link
- `Tecnologias` - Comma-separated technology list
- `FechaCreacion` - Project creation date

### Features
1. **Hero Section**: Eye-catching header with call-to-action button
2. **Projects Gallery**: Responsive grid displaying portfolio projects with:
   - Project images with hover zoom effect
   - Project descriptions
   - Technology tags
   - Links to live projects/repositories
3. **Contact Section**: Call-to-action for professional inquiries with:
   - Email contact button
   - GitHub profile link
   - LinkedIn profile link

### Development Notes

**Session Nov 23, 2025 - Complete Redesign**

Changed from problematic e-commerce TechStore to clean Professional Portfolio:

**Why the change?**
- ❌ Shopping cart had unsurmountable Blazor rendermode conflicts (SSR vs InteractiveServer)
- ❌ Authentication system had compounding issues
- ❌ Complex entity relationships caused JSON serialization failures
- ✅ Portfolio is simpler, more professional, and implements cleanly

**New Architecture Benefits**:
- Single database entity (Proyecto) - no complex relationships
- No authentication required
- No cart/order complexity
- Pure InteractiveServer rendermode throughout
- Seed data loaded directly into database
- Easy to maintain and extend

**Files Structure**:
- Models: Single Proyecto.cs entity
- Data: PortfolioContext with seed data for 3 sample projects
- Components: Single Index.razor page with full portfolio functionality
- Styles: Modern CSS with gradients, animations, responsive design

## External Dependencies
- **Database**: SQLite (local file: portfolio.db)
- **ORM**: Entity Framework Core 8.0
- **Fonts**: Google Fonts (Inter family)
- **Image Assets**: Unsplash (free stock photos for sample projects)
