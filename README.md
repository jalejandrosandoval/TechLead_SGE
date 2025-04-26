# TechLead_SGE

## Contexto

Proyecto prueba de desarrollo: Creación de una API de tipo Rest en Net 8 consumida desde un FrontEND en React.

<b> Prueba Desarrollada Por: Jhon Alejandro Sandoval Miranda </b> 

## Estructura Principal de Archivos

```bash
└─ TechLead_SGE
    ├─ TechLead_SGE.Client
    │   ├─ public
    │   │   └─ assets
    │   │      ├─ backgrounds
    │   │      ├─ icons
    │   │      └─ logos
    │   └─ src
    │       ├─ Components
    │       │  ├─ Employees 
    │       │  ├─ Forms 
    │       │  ├─ Home
    │       │  └─ Shared
    │       ├─ Interfaces
    │       ├─ Layouts
    │       ├─ Models
    │       └─ Services
    ├─ TechLead_SGE.Server
    │  ├─ Classes
    │  │  └─ Logic
    │  │      ├─ Common
    │  │      └─ Custom
    │  └─ Controllers
    ├─ TechLead_SGE.Server.BL
    │  ├─ Classes
    │  ├─ Repositories
    │  │  ├─ Implements
    │  │  └─ Interfaces
    │  └─ Services
    │     ├─ Implements
    │     └─ Interfaces
    ├─ TechLead_SGE.Server.Data
    │  ├─ DBContext
    │  └─ Migrations
    ├─ TechLead_SGE.Server.Domain
    ├─ TechLead_SGE.Server.UnitTest
    │  ├─ Contexts
    │  ├─ DTOS
    │  ├─ Interfaces
    │  └─ Models
    └─ TechLead_SGE.Server.Utilities
       ├─ Classes
       └─ Models
```

Cada una de estas carpetas principales corresponde a proyectos separados donde se encuentra segmentado por una modularización. De igual manera, en cada ruta se encuentra una breve explicación.

La distribución se realizó de la siguiente forma:

* FRONT-END: 
    - ./TechLead_SGE.Client
* BACK-END: 
    - ./TechLead_SGE.Server
    - ./TechLead_SGE.Server.BL
    - ./TechLead_SGE.Server.Data
    - ./TechLead_SGE.Server.Domain
    - ./TechLead_SGE.Server.Utilities
* Pruebas Unitarias:
    - ./TechLead_SGE.Server.UnitTest

## Inicialización de los proyectos

Se debe tener en cuenta que para arrancar los proyectos se deben tener previamente instaladas algunas tecnologías como lo son:

- NodeJS V22.15.0.
- NPM V11.3.0.
- React 19.00.
- Net 8.
- EF 9.0.4.
- SQL SERVER - SSMS 18.

## Diseño Proyecto

### FRONT-END
A continuación se presenta el diseño del FrontEnd del Proyecto.

![](./FrontEnd.png)

### BACK-END
A continuación se presenta la imagen dela documentación de la API del BackEnd.

![](./BackEnd.png)

## Pruebas Unitarias

### BACK-END
A continuación se presenta la imagen de las pruebas unitarias realizadas a los endpoints de la API.

![](./UnitTest_BackEnd.png)