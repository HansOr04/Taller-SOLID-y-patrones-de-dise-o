# Best Practices Workshop - Refactorización con Patrones de Diseño

**Autor:** Hans Ortiz  
**Fecha:** Diciembre 2024  
**Universidad:** UDLA

---

## Descripción

Este proyecto implementa una refactorización completa del sistema de gestión de vehículos, aplicando patrones de diseño y principios SOLID para mejorar la mantenibilidad, escalabilidad y testabilidad del código.

## Patrones de Diseño Implementados

### 1. Dependency Injection
- Desacoplamiento entre capas de la aplicación
- Facilita pruebas unitarias mediante mocks
- Permite intercambio de implementaciones sin modificar código cliente

### 2. Factory Pattern
- Creación dinámica de diferentes modelos de vehículos
- Facilita agregar nuevos modelos sin modificar código existente
- Cumple con el principio Open/Closed

### 3. Fluent Builder Pattern
- Construcción flexible de objetos complejos
- API legible y expresiva
- Preparado para agregar múltiples propiedades

### 4. Repository Pattern
- Abstracción de la capa de persistencia
- Implementación in-memory temporal
- Preparado para migración a base de datos

## Principios SOLID Aplicados

- **Single Responsibility Principle**: Cada clase tiene una única responsabilidad
- **Open/Closed Principle**: Abierto para extensión, cerrado para modificación
- **Liskov Substitution Principle**: Las subclases pueden sustituir a sus clases base
- **Interface Segregation Principle**: Interfaces específicas y cohesivas
- **Dependency Inversion Principle**: Dependencia de abstracciones, no de concreciones

## Estructura del Proyecto

```
BestPractices/
├── Controllers/
│   └── HomeController.cs
├── Infraestructure/
│   ├── DependencyInjection/
│   │   └── ServicesConfiguration.cs
│   └── Factories/
│       ├── IVehicleFactory.cs
│       ├── FordMustangFactory.cs
│       ├── FordExplorerFactory.cs
│       └── FordEscapeFactory.cs
├── ModelBuilders/
│   └── VehicleBuilder.cs
├── Models/
│   ├── Vehicle.cs
│   ├── Car.cs
│   ├── Motorcycle.cs
│   └── IVehicle.cs
├── Repositories/
│   ├── IVehicleRepository.cs
│   └── InMemoryVehicleRepository.cs
└── Views/
    └── Home/
        └── Index.cshtml
```

## Cambios Realizados

### Archivos Nuevos
- `IVehicleFactory.cs`: Interfaz para factories
- `FordEscapeFactory.cs`: Factory para modelo Escape
- `InMemoryVehicleRepository.cs`: Repositorio sin Singleton

### Archivos Modificados
- `HomeController.cs`: Implementación de DI y método unificado
- `ServicesConfiguration.cs`: Configuración de servicios con DI
- `VehicleBuilder.cs`: Patrón Builder completo
- `Vehicle.cs`, `Car.cs`, `Motorcycle.cs`: Constructores actualizados
- Factories: Implementación de interfaz común
- `Index.cshtml`: Vista mejorada con nuevas funcionalidades

### Archivos Eliminados
- `Creator.cs`: Reemplazado por IVehicleFactory
- `MyVehiclesRepository.cs`: Reemplazado por InMemoryVehicleRepository
- `VehicleCollection.cs`: Singleton eliminado

## Funcionalidades

- Agregar vehículos: Ford Mustang, Ford Explorer, Ford Escape
- Iniciar y detener motor de vehículos
- Agregar combustible
- Visualización de propiedades: Año, potencia, transmisión
- Gestión de estado del motor

## Requisitos

- .NET Core 3.1
- ASP.NET Core MVC
- Bootstrap 4.x

## Instalación

1. Clonar el repositorio
```bash
git clone [URL_DEL_REPOSITORIO]
```

2. Restaurar paquetes NuGet
```bash
dotnet restore
```

3. Compilar el proyecto
```bash
dotnet build
```

4. Ejecutar la aplicación
```bash
dotnet run
```

5. Abrir navegador en `https://localhost:5001`

## Uso

1. Seleccionar el tipo de vehículo a agregar (Mustang, Explorer o Escape)
2. El vehículo aparecerá en la tabla con sus propiedades
3. Usar los botones de acción para:
   - Iniciar motor (requiere combustible)
   - Detener motor
   - Agregar combustible

## Ventajas de la Refactorización

### Escalabilidad
- Agregar nuevos modelos solo requiere crear una nueva factory
- Agregar propiedades es sencillo mediante el Builder
- Preparado para base de datos real

### Mantenibilidad
- Código desacoplado con responsabilidades claras
- Logging integrado para debugging
- Estructura clara y organizada

### Testabilidad
- Todas las dependencias son interfaces inyectadas
- Fácil creación de mocks para pruebas unitarias
- Lógica de negocio aislada de infraestructura


## Notas Técnicas

- El repositorio actual usa almacenamiento en memoria (in-memory)
- El Singleton fue eliminado para evitar problemas de concurrencia
- Todos los vehículos incluyen año actual por defecto
- El sistema está preparado para agregar 20+ propiedades adicionales

## Contribuciones

Este proyecto fue desarrollado como parte del Workshop de Best Practices en UDLA.

## Licencia

Proyecto académico - UDLA 2025

## Contacto

**Hans Ortiz**  
Universidad de Las Américas (UDLA)

---

Última actualización: Diciembre 2024
