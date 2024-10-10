# API de Gestión Hotelera

Este proyecto es una API construida con *ASP.NET Core, utilizando una arquitectura basada en **repositorios* y *servicios* para manejar la lógica de negocio. El proyecto incluye la gestión de *employee, **huéspedes, **reservas, **habitaciones, **tipos de habitación. La API permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) y maneja conexiones con una base de datos utilizando **Entity Framework Core*.

## Requisitos

- [.NET 6.0 SDK o superior](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MySQL](https://www.mysql.com/downloads/)
- [Visual Studio 2022 o Visual Studio Code](https://visualstudio.microsoft.com/)
- [Postman (para probar la API)](https://www.postman.com/)

## Instalación

### 1. Clona el repositorio

bash
git clone https://github.com/BrayanLanda/HotelApi
cd HotelApi 


### 2. Instalar paquetes NuGet
Ejecuta el siguiente comando para instalar las dependencias necesarias si aún no las tienes instaladas:

bash
dotnet restore


- DotNetEnv
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.IdentityModel.Tokens
- System.IdentityModel.Tokens.Jwt
- System.Security.Cryptography.Algorithms
- Pomelo.EntityFrameworkCore.MySql
- Microsoft.EntityFrameworkCore.Tools
- Swashbuckle.AspNetCore.Annotations
- Swashbuckle.AspNetCore
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- AutoMapper

### 3. Configurar la Base de Datos
Este proyecto utiliza Entity Framework Core para la interacción con la base de datos. Ejecuta las migraciones para configurar la base de datos:

bash
dotnet ef migrations add InitialCreate
dotnet ef database update


### 4. Ejecutar la API
Puedes ejecutar la API utilizando el siguiente comando:

bash
dotnet run 
dotbet watch run


La API estará disponible en https://localhost:5001 (o el puerto que esté configurado).

### 5. Probar la API
Puedes probar la API utilizando herramientas como Postman o directamente desde Swagger. Swagger estará disponible en la siguiente URL una vez que inicies el proyecto:

https://localhost:5001/swagger (o el puerto que esté configurado)

## Funcionalidades principales

### Employee (Employee)
- Register Employee
- Login Employee
- Autenticación con JWT

### Huéspedes (Guests)
- Obtener todos los huéspedes
- Obtener huésped por id y palabra 
- Crear, actualizar y eliminar huéspedes

### Reservas (Bookings)
- Obtener todas las reservas
- Obtener reservas por estado o por huésped
- Crear, actualizar y eliminar reservas
- Buscar reservas (SearchBookings)
- Obtener reserva por ID (GetBookingById)

### Habitaciones (Rooms)
- Obtener todas las habitaciones
- Obtener habitaciones por tipo o estado
- Crear, actualizar y eliminar habitaciones

### Tipos de Habitación (Room Types)
- Obtener todos los tipos de habitación
- Crear, actualizar y eliminar tipos de habitación

## Notas adicionales
- Todas las rutas de la API comienzan con api/v1/
- Se utiliza Swagger/OpenAPI 3.0 para la documentación de la API
- Se implementa manejo de excepciones a través de ExceptionMiddleware
