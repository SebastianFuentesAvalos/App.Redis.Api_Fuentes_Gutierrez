# App.Redis.Api_Fuentes_Gutierrez

**Trabajo Académico**

Este proyecto es una API REST desarrollada con **ASP.NET Core** que implementa almacenamiento en caché utilizando **Redis**. Forma parte de un ejercicio académico para aprender sobre contenedores Docker, servicios cacheados y despliegue con Docker Compose.

## 🧠 Tecnologías utilizadas

- **ASP.NET Core 8** (lenguaje: **C#**)
- **Redis**
- **Docker & Docker Compose**
- **Visual Studio Code**
- **Postman o navegador web para pruebas**

## 🚀 ¿Qué hace esta API?

- Devuelve una lista de tareas (`Todos`) desde una fuente simulada.
- Guarda temporalmente esa lista en Redis para mejorar el rendimiento.
- Permite limpiar la caché desde un endpoint.

## 📦 Endpoints principales

- `GET /todos`: Devuelve la lista de tareas. Si hay datos en Redis, los carga desde ahí.
- `GET /todos/clear-cache/_todos`: Elimina la clave `_todos` del caché Redis.

## ⚙️ Cómo ejecutar el proyecto

1. Clonar el repositorio:
   git clone https://github.com/tu-usuario/App.Redis.Api_Fuentes_Gutierrez.git
   cd App.Redis.Api_Fuentes_Gutierrez
2. Construir y levantar los contenedores:
  docker-compose up --build
3. Acceder a la API desde tu navegador o Postman:
  http://localhost:5000/todos
  http://localhost:5000/todos/clear-cache/_todos
