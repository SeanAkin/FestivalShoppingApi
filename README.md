# Festival Shopping API

The **Festival Shopping API** is a backend service designed to facilitate the management of shopping lists for festival attendees. This API enables users to create, update, and manage shopping lists, simplifying the planning and sharing of items for festival preparations.

---

## Features

- **Shopping List Management**: Create, retrieve, update, and delete shopping lists tailored for festival needs.
- **Item Management**: Add, modify, and remove items within each shopping list.
- **GUID-Based Access**: Each shopping list is assigned a unique GUID, allowing for easy sharing and access without requiring user authentication.

---

## Technologies Used

- **ASP.NET Core**: Utilized for building a high-performance, cross-platform web API.
- **Entity Framework Core**: Serves as the Object-Relational Mapper (ORM) to interact with the database in an efficient manner.
- **SQLite**: Chosen as the lightweight, file-based database provider for storing shopping list data.
- **Docker**: For containerizing the application, ensuring consistent environments across different deployment platforms.

---

## Design Patterns and Architecture

- **Results Pattern**: A spin/play on the results pattern for error handling.
- **Dependency Injection**: Leverages ASP.NET Core's built-in dependency injection to manage service lifetimes and dependencies, enhancing modularity and testability.
- **Layered Architecture**: Organizes the solution into distinct projects:
  - `FestivalShoppingApi`: Contains the API controllers and startup configuration.
  - `FestivalShoppingApi.Business`: Encapsulates business logic and service implementations.
  - `FestivalShoppingApi.Common`: Includes shared utilities and constants.
  - `FestivalShoppingApi.Data`: Manages data access, entities, and database context.
  - `FestivalShoppingApi.Test`: Holds unit and integration tests to ensure code reliability.

---

## Future Plans

The following features are planned to enhance the API further:

- **Authentication and Authorization**:
  - Implement user authentication to secure access to shopping lists.
  - Introduce role-based authorization to enable sharing and collaboration on lists with controlled permissions.

- **Real-Time Updates with SignalR**:
  - Use SignalR to provide real-time notifications and updates, such as list modifications or item additions, improving the user experience for collaborative shopping.

- **Automatic Price Detection**:
  - Integrate third-party APIs or services to automatically fetch and display prices for items in the shopping lists.
  - Allow users to compare prices across multiple retailers, adding value and convenience.

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started)
- [FestivalShoppingUI](https://github.com/SeanAkin/FestivalShoppingUi)
