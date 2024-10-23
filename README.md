# Vinoteca API

## Descripción

**Vinoteca API** es un sistema de gestión de inventario para bodegas de vinos. Permite la administración de vinos,
consulta de stock por variedad, y registro de catas. Este proyecto está desarrollado con **ASP.NET Core Web API** y
utiliza una base de datos SQLite para almacenar la información.

El sistema incluye autenticación JWT para proteger rutas sensibles y sigue el patrón de diseño de repositorios, facilitando el mantenimiento y la escalabilidad del código.

## Funcionalidades

- **Gestión de Vinos**: Crear, consultar, actualizar y eliminar vinos.
- **Gestión de Stock**: Consultar y actualizar el stock de vinos por variedad.
- **Gestión de Catas**: Registrar y consultar catas de vinos.
- **Autenticación JWT**: Sistema de autenticación basado en tokens para asegurar las rutas.
- **Base de Datos SQLite**: Base de datos local para almacenar la información de los vinos y catas.

## Requisitos Previos

Antes de comenzar, asegúrate de tener instalado:

- [.NET SDK 6.0]
- [SQLite
- [Postman]


Endpoints
Autenticación
POST /api/auth/login: Iniciar sesión y obtener un token JWT.
Cuerpo: { "username": "admin", "password": "1234" }
Vinos
GET /api/wines: Obtener la lista de todos los vinos.
GET /api/wines/{id}: Obtener un vino por ID.
POST /api/wines: Crear un nuevo vino.
Cuerpo:
json
Copiar código
{
  "nombre": "Cabernet Sauvignon",
  "variedad": "Cabernet",
  "año": 2019,
  "precio": 1200
}
PUT /api/wines/{id}: Actualizar un vino.
Cuerpo:
json
Copiar código
{
  "nombre": "Merlot",
  "variedad": "Merlot",
  "año": 2020,
  "precio": 1300
}
DELETE /api/wines/{id}: Eliminar un vino por ID.
Stock
GET /api/wines/stock?variety={variedad}: Consultar el stock de vinos por variedad.
PUT /api/wines/{id}/stock: Actualizar el stock de un vino por ID.
Cuerpo:
json
Copiar código
{
  "stock": 50
}
Catas
POST /api/catas: Registrar una nueva cata de vino.
Cuerpo:
json
Copiar código
{
  "nombre": "Cata Primavera",
  "fecha": "2024-10-01",
  "vinos": [
    { "wineId": 1, "puntuacion": 90 },
    { "wineId": 2, "puntuacion": 88 }
  ]
}
GET /api/catas: Obtener todas las catas registradas.
Ejemplos de Uso
Crear un nuevo vino
bash
Copiar código
curl -X POST https://localhost:5001/api/wines \
  -H "Authorization: Bearer {your_token}" \
  -H "Content-Type: application/json" \
  -d '{
        "nombre": "Syrah",
        "variedad": "Syrah",
        "año": 2018,
        "precio": 1700
      }'
Consultar el stock por variedad
bash
Copiar código
curl -X GET https://localhost:5001/api/wines/stock?variety=Malbec \
  -H "Authorization: Bearer {your_token}"
Registrar una cata
bash
Copiar código
curl -X POST https://localhost:5001/api/catas \
  -H "Authorization: Bearer {your_token}" \
  -H "Content-Type: application/json" \
  -d '{
        "nombre": "Cata de Verano",
        "fecha": "2024-12-20",
        "vinos": [
          { "wineId": 1, "puntuacion": 95 },
          { "wineId": 2, "puntuacion": 88 }
        ]
      }'
Arquitectura del Proyecto
El proyecto sigue el patrón Modelo-Vista-Controlador (MVC), con capas separadas para la lógica de negocio, 
acceso a datos y presentación. También utiliza el patrón Repository para abstraer el acceso a la base de datos, 
facilitando el cambio de proveedor de base de datos si es necesario.

Controllers: Gestionan las solicitudes HTTP y devuelven respuestas adecuadas.
Services: Contienen la lógica de negocio.
Repositories: Manejan las operaciones CRUD con la base de datos.
DTOs (Data Transfer Objects): Estructuras de datos utilizadas para transferir información entre las capas de la aplicación.
Contribuciones
Si deseas contribuir a este proyecto, sigue los siguientes pasos:


### ¿Qué incluye este README?
- **Descripción** clara de qué hace el proyecto.
- **Instrucciones de instalación** con pasos detallados.
- **Listado de endpoints** con ejemplos de cada funcionalidad.
- **Explicación de la arquitectura del proyecto**,