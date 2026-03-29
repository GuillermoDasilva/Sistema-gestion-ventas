##  Tecnologías utilizadas
- C# .NET
- SQL Server
- ASP.NET WebForms
- Arquitectura en capas (Presentación, Lógica, Persistencia, Entidades)

##  Funcionalidades principales
- Gestión de clientes (alta, baja, modificación, consulta)
- Gestión de artículos y categorías
- Registro de ventas
- Seguimiento del estado de ventas:
  - Armado
  - Enviado
  - Entregado
  - Devuelto
- Consultas por cliente, artículo y categoría
- Validaciones de negocio mediante stored procedures

##  Características técnicas
- Uso de **stored procedures** para lógica de base de datos
- Implementación de **transacciones** para asegurar integridad
- Base de datos relacional con claves foráneas
- Validaciones en backend (C# y SQL)

##  Base de datos
El proyecto incluye script SQL para:
- Creación de base de datos
- Tablas
- Datos de prueba
- Stored procedures

Archivo: `BaseDatosPF.sql`

##  Cómo ejecutar el proyecto
1. Ejecutar el script `BaseDatosPF.sql` en SQL Server
2. Abrir la solución en Visual Studio
3. Configurar la cadena de conexión
4. Ejecutar el proyecto

##  Autor
Guillermo Da Silva
