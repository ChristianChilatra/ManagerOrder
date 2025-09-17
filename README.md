# 📦 ManagerOrder

El proyecto se estructura desde su configuración inicial utilizando **métodos de extensión**, lo que aporta mayor **claridad y orden** en el código.  
Se implementa una arquitectura **Vertical Slice**, donde los recursos se organizan y se centralizan por **características**. En este caso, el slice principal es **`Orders`**.

📖 (Scalar (OpenAPI) - http://[::]/scalar/v1)

---

## 🔹 Features

1. **Clase "request"**  
   Parametros requeridos.

1. **Endpoint**  
   El MapGetOrder expone un endpoint configurado con Minimal API.  

2. **Clase estática `Handle`**  
   Centraliza la lógica y proporciona la **inyección de dependencias**.  

3. **Servicio principal `AcmeService`**  
   - Gestiona la comunicación **JSON ⇆ XML**.  
   - Se encarga de consultar el estado de las ordenes.  

4. **DTOs**  
   - Transportan y exponen la información del servicio.  

---

## 🎯 Objetivo

El objetivo principal de **ManagerOrder** es permitir la consulta del **estado de los pedidos**, transformando y exponiendo la información en el formato requerido (**JSON o XML**) de manera eficiente y mantenible.

---

## 💻 Tecnologías

- .NET 9 Minimal API
- Arquitectura Vertical Slice
- Inyección de dependencias
- DTOs
- Metodo de Extensión
- FluentValidation
