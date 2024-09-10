
# ApiHexagonalNet

Este proyecto es una API RESTful construida con .NET Core utilizando una arquitectura hexagonal. La API permite manejar entidades de flores y pedidos para una floristería.

## Requisitos Previos

- .NET SDK 6.0 o superior
- MongoDB (puedes utilizar MongoDB Atlas para una base de datos en la nube)

## Instalación

1. Clona el repositorio:

   ```bash
   git clone https://github.com/tu-usuario/ApiHexagonalNet.git
   cd ApiHexagonalNet
   ```

2. Restaura las dependencias:

   ```bash
   dotnet restore
   ```

3. Configura la conexión a MongoDB:

   Modifica el archivo `appsettings.json` con tu cadena de conexión de MongoDB:

   ```json
   {
     "MongoDBSettings": {
       "ConnectionString": "mongodb://localhost:27017",
       "DatabaseName": "FloristaDb"
     }
   }
   ```

4. Compila el proyecto:

   ```bash
   dotnet build
   ```

5. Ejecuta el proyecto:

   ```bash
   dotnet run
   ```

## Endpoints de la API

### Flores

- **GET** Obtener todas las flores:
  ```
  GET http://localhost:5020/api/flower
  ```

- **GET** Obtener una flor por ID:
  ```
  GET http://localhost:5020/api/flower/{id}
  ```

- **POST** Crear una nueva flor:
  ```
  POST http://localhost:5020/api/flower
  ```

  **Body:**
  ```json
  {
    "name": "Rose",
    "description": "A beautiful red rose.",
    "price": 5.99,
    "quantityInStock": 100,
    "imageUrl": "http://example.com/rose.jpg"
  }
  ```

- **PUT** Actualizar una flor existente:
  ```
  PUT http://localhost:5020/api/flower/{id}
  ```

  **Body:**
  ```json
  {
    "id": "66dbf736877a46984b6ed6c0",
    "name": "Rose",
    "description": "A beautiful red rose.",
    "price": 5.99,
    "quantityInStock": 50,
    "imageUrl": "http://example.com/rose.jpg"
  }
  ```

- **DELETE** Eliminar una flor:
  ```
  DELETE http://localhost:5020/api/flower/{id}
  ```

### Pedidos

- **GET** Obtener todos los pedidos:
  ```
  GET http://localhost:5020/api/order
  ```

- **GET** Obtener un pedido por ID:
  ```
  GET http://localhost:5020/api/order/{id}
  ```

- **POST** Crear un nuevo pedido:
  ```
  POST http://localhost:5020/api/order
  ```

  **Body:**
  ```json
  {
    "customerName": "John Doe",
    "customerEmail": "john.doe@example.com",
    "items": [
      {
        "flowerId": "66dbf736877a46984b6ed6c0",
        "quantity": 2
      }
    ],
    "totalAmount": 49.99,
    "orderDate": "2024-09-10T14:30:00Z"
  }
  ```

- **PUT** Actualizar un pedido existente:
  ```
  PUT http://localhost:5020/api/order/{id}
  ```

  **Body:**
  ```json
  {
    "id": "66dbf736877a46984b6ed6c0",
    "customerName": "John Doe",
    "customerEmail": "john.doe@example.com",
    "items": [
      {
        "flowerId": "66dbf736877a46984b6ed6c0",
        "quantity": 2
      }
    ],
    "totalAmount": 49.99,
    "orderDate": "2024-09-10T14:30:00Z"
  }
  ```

- **DELETE** Eliminar un pedido:
  ```
  DELETE http://localhost:5020/api/order/{id}
  ```

## Pruebas con Postman

1. Importa el archivo `ApiHexagonalNet.postman_collection.json` en Postman.
2. Ejecuta las solicitudes configuradas para probar cada uno de los endpoints.

## Contribuir

Para contribuir al proyecto, realiza un fork del repositorio, crea una nueva rama y realiza un pull request con tus cambios.

## Licencia

Este proyecto está bajo la licencia MIT.
