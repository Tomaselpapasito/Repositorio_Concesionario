CREATE DATABASE CONCESIONARIO_DB;
GO

USE CONCESIONARIO_DB;
GO

-- PERSONAS
CREATE TABLE [Personas]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NULL,
    [Cedula] NVARCHAR(50) NULL UNIQUE,
    [Fecha_Nacimiento] SMALLDATETIME NOT NULL,
    [Telefono] NVARCHAR(30) NULL
);

-- USUARIOS
CREATE TABLE [Usuarios]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [NombreUsuario] NVARCHAR(100) NULL,
    [Contraseña] NVARCHAR(250) NULL
);

-- AUDITORIAS
CREATE TABLE [Auditorias]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Descripcion] NVARCHAR(MAX) NULL,
    [Fecha] SMALLDATETIME NOT NULL,
    [Usuario] INT NOT NULL FOREIGN KEY REFERENCES [Usuarios]([ID])
);

-- ROLES
CREATE TABLE [Roles]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NULL,
    [Usuario] INT NOT NULL FOREIGN KEY REFERENCES [Usuarios]([ID])
);

-- PERMISOS
CREATE TABLE [Permisos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Descripcion] NVARCHAR(200) NOT NULL,
    [Rol] INT NOT NULL FOREIGN KEY REFERENCES [Roles]([ID])
);

-- CARGOS
CREATE TABLE [Cargos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NULL,
    [Salario] DECIMAL(18,2) NOT NULL,
    [Activo] BIT NOT NULL
);

-- MODELOS DE MOTOS
CREATE TABLE [ModelosMotos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NULL,
    [Cilindraje] INT NOT NULL,
    [Tipo_motor] NVARCHAR(100) NULL,
    [Transmision] NVARCHAR(100) NULL,
    [Potencia] DECIMAL(18,2) NOT NULL
);

-- PROVEEDORES
CREATE TABLE [Proveedores]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NULL,
    [NIT] NVARCHAR(50) NULL,
    [Telefono] NVARCHAR(30) NULL,
    [Correo] NVARCHAR(150) NULL,
    [Direccion] NVARCHAR(200) NULL
);

-- METODOS DE PAGO
CREATE TABLE [MetodosPagos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NULL,
    [Tipo] NVARCHAR(100) NULL,
    [Descripcion] NVARCHAR(250) NULL,
    [Activo] BIT NOT NULL
);

-- PRODUCTOS
CREATE TABLE [Productos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Codigo] NVARCHAR(50) NULL,
    [Nombre] NVARCHAR(100) NULL,
    [Fecha_Creacion] SMALLDATETIME NOT NULL,
    [Fecha_Modificacion] SMALLDATETIME NOT NULL,
    [Precio] DECIMAL(18,2) NOT NULL,
    [Stock] INT NOT NULL,
    [Activo] BIT NOT NULL
);

-- ACCESORIOS
CREATE TABLE [Accesorios]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NULL,
    [Categoria] NVARCHAR(100) NULL,
    [Marca] NVARCHAR(100) NULL,
    [Producto] INT NOT NULL FOREIGN KEY REFERENCES [Productos]([ID])
);

-- CLIENTES
CREATE TABLE [Clientes]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Correo] NVARCHAR(150) NULL,
    [Numero_Licencia] NVARCHAR(50) NULL UNIQUE,
    [Direccion] NVARCHAR(200) NULL,
    [Activo] BIT NOT NULL,
    [Persona] INT NOT NULL FOREIGN KEY REFERENCES [Personas]([ID])
);

-- MOTOS
CREATE TABLE [Motos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [VIN] NVARCHAR(100) NULL UNIQUE,
    [Numero_Motor] NVARCHAR(100) NULL,
    [Color] NVARCHAR(50) NULL,
    [Anio] INT NOT NULL,
    [Estado] NVARCHAR(50) NOT NULL,
    [Modelo] INT NOT NULL FOREIGN KEY REFERENCES [ModelosMotos]([ID])
);

-- INVENTARIOS
CREATE TABLE [Inventarios]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Fecha_Ingreso] SMALLDATETIME NOT NULL,
    [Ubicacion] NVARCHAR(150) NULL,
    [Moto] INT NOT NULL FOREIGN KEY REFERENCES [Motos]([ID])
);

-- COMPRAS
CREATE TABLE [Compras]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Fecha_Compra] SMALLDATETIME NOT NULL,
    [Impuesto] DECIMAL(18,2) NOT NULL,
    [Numero_Factura] NVARCHAR(100) NULL,
    [Total] DECIMAL(18,2) NOT NULL,
    [Proveedor] INT NOT NULL FOREIGN KEY REFERENCES [Proveedores]([ID])
);

-- REPUESTOS
CREATE TABLE [Repuestos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Numero_Parte] NVARCHAR(100) NULL,
    [Descripcion] NVARCHAR(250) NULL,
    [Fecha_Modificacion] SMALLDATETIME NOT NULL,
    [Producto] INT NOT NULL FOREIGN KEY REFERENCES [Productos]([ID])
);

-- EMPLEADOS
CREATE TABLE [Empleados]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Carnet] NVARCHAR(50) NULL,
    [Fecha_Contratacion] SMALLDATETIME NOT NULL,
    [Persona] INT NOT NULL FOREIGN KEY REFERENCES [Personas]([ID]),
    [Cargo] INT NOT NULL FOREIGN KEY REFERENCES [Cargos]([ID])
);

-- VENTAS
CREATE TABLE [Ventas]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Fecha_Venta] SMALLDATETIME NOT NULL,
    [Impuestos] DECIMAL(18,2) NOT NULL,
    [Total] DECIMAL(18,2) NOT NULL,
    [Cliente] INT NOT NULL FOREIGN KEY REFERENCES [Clientes]([ID]),
    [Empleado] INT NOT NULL FOREIGN KEY REFERENCES [Empleados]([ID])
);

-- PAGOS
CREATE TABLE [Pagos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Fecha_Pago] SMALLDATETIME NOT NULL,
    [Monto] DECIMAL(18,2) NOT NULL,
    [Metodo] INT NOT NULL FOREIGN KEY REFERENCES [MetodosPagos]([ID]),
    [Venta] INT NOT NULL FOREIGN KEY REFERENCES [Ventas]([ID])
);

-- DETALLES DE VENTAS DE MOTOS
CREATE TABLE [DetallesVentasMotos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Precio_Unitario] DECIMAL(18,2) NOT NULL,
    [Descuento] DECIMAL(18,2) NOT NULL,
    [Subtotal] DECIMAL(18,2) NOT NULL,
    [Moto] INT NOT NULL FOREIGN KEY REFERENCES [Motos]([ID]),
    [Venta] INT NOT NULL FOREIGN KEY REFERENCES [Ventas]([ID])
);

-- DETALLES DE VENTAS DE PRODUCTOS
CREATE TABLE [DetallesVentasProductos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Precio_Unitario] DECIMAL(18,2) NOT NULL,
    [Descuento] DECIMAL(18,2) NOT NULL,
    [Subtotal] DECIMAL(18,2) NOT NULL,
    [Cantidad] INT NOT NULL,
    [Producto] INT NOT NULL FOREIGN KEY REFERENCES [Productos]([ID]),
    [Venta] INT NOT NULL FOREIGN KEY REFERENCES [Ventas]([ID])
);

-- FINANCIAMIENTOS
CREATE TABLE [Financiamientos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Monto] DECIMAL(18,2) NOT NULL,
    [Numero_Cuotas] INT NOT NULL,
    [Tasa_Interes] DECIMAL(18,2) NOT NULL,
    [Fecha_Inicio] SMALLDATETIME NOT NULL,
    [Fecha_Fin] SMALLDATETIME NOT NULL,
    [Estado] NVARCHAR(50) NOT NULL,
    [Venta] INT NOT NULL FOREIGN KEY REFERENCES [Ventas]([ID])
);

-- CUOTAS
CREATE TABLE [Cuotas]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Numero_cuota] INT NOT NULL,
    [Monto] DECIMAL(18,2) NOT NULL,
    [Fecha_vencimiento] SMALLDATETIME NOT NULL,
    [Fecha_pago] SMALLDATETIME NULL,
    [Financiamiento] INT NOT NULL FOREIGN KEY REFERENCES [Financiamientos]([ID])
);

-- DETALLES DE COMPRAS
CREATE TABLE [DetallesCompras]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Cantidad] INT NOT NULL,
    [Precio_Unitario] DECIMAL(18,2) NOT NULL,
    [Descuento] DECIMAL(18,2) NOT NULL,
    [Subtotal] DECIMAL(18,2) NOT NULL,
    [Compra] INT NOT NULL FOREIGN KEY REFERENCES [Compras]([ID]),
    [Producto] INT NOT NULL FOREIGN KEY REFERENCES [Productos]([ID])
);


-- ===================================================================================
-- TABLAS DE AUDITORIA DEL CONCESIONARIO
-- =============================================

CREATE TABLE AuditoriasUsuarios (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasRoles (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasPermisos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasPersonas (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasCargos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasModelosMotos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasProveedores (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasMetodosPagos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasProductos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasAccesorios (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasClientes (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasMotos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasInventarios (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasCompras (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasRepuestos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasEmpleados (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasVentas (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasPagos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasDetallesVentasMotos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasDetallesVentasProductos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasFinanciamientos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasCuotas (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE AuditoriasDetallesCompras (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Objeto INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Accion NVARCHAR(50),
    Detalles NVARCHAR(MAX),
    Usuario INT NOT NULL,
    FOREIGN KEY (Usuario) REFERENCES Usuarios(ID)
);
GO


-- PERSONAS
INSERT INTO [Personas] ([Nombre], [Cedula], [Fecha_Nacimiento], [Telefono])
VALUES ('Arnold Gomez', '123456789', '1990-01-01', '3001234567');
GO

INSERT INTO [Personas] ([Nombre], [Cedula], [Fecha_Nacimiento], [Telefono])
VALUES ('Pablo Gomez', '123453535359', '1990-02-02', '300122323237');
GO


-- CARGOS
INSERT INTO [Cargos] ([Nombre], [Salario], [Activo])
VALUES ('Asesor Comercial', 2500000.00, 1);
GO


-- MODELOS DE MOTOS
INSERT INTO [ModelosMotos] ([Nombre], [Cilindraje], [Tipo_motor], [Transmision], [Potencia])
VALUES ('Yamaha MT-03', 321, 'Bicilindrico', '6 velocidades', 42.00);
GO


-- PROVEEDORES
INSERT INTO [Proveedores] ([Nombre], [NIT], [Telefono], [Correo], [Direccion])
VALUES ('MotoPartes Colombia SAS', '900123456-7', '6015551234', 'ventas@motopartes.com', 'Carrera 50 # 10-25');
GO


-- METODOS DE PAGO
INSERT INTO [MetodosPagos] ([Nombre], [Tipo], [Descripcion], [Activo])
VALUES ('Tarjeta de Credito', 'Electronico', 'Pago realizado mediante tarjeta de credito', 1);
GO


-- PRODUCTOS
INSERT INTO [Productos] ([Codigo], [Nombre], [Fecha_Creacion], [Fecha_Modificacion], [Precio], [Stock], [Activo])
VALUES ('ACE-001', 'Aceite Motul 5100 4T', '2026-01-10', '2026-01-10', 65000.00, 50, 1);
GO

INSERT INTO [Productos] ([Codigo], [Nombre], [Fecha_Creacion], [Fecha_Modificacion], [Precio], [Stock], [Activo])
VALUES ('ACE-002', 'Pegatina', '2026-01-11', '2026-01-11', 75000.00, 60, 1);
GO


-- ACCESORIOS
INSERT INTO [Accesorios] ([Nombre], [Categoria], [Marca], [Producto])
VALUES ('Pegatina', 'Decoracion', 'Generica', 2);
GO


-- CLIENTES
INSERT INTO [Clientes] ([Correo], [Numero_Licencia], [Direccion], [Activo], [Persona])
VALUES ('arnold.gomez@email.com', 'LIC-123456', 'Calle 20 # 15-30', 1, 1);
GO


-- MOTOS
INSERT INTO [Motos] ([VIN], [Numero_Motor], [Color], [Anio], [Estado], [Modelo])
VALUES ('9C6RG1234MA000001', 'MOT123456', 'Negro', 2026, 'Disponible', 1);
GO

INSERT INTO [Motos] ([VIN], [Numero_Motor], [Color], [Anio], [Estado], [Modelo])
VALUES ('9C6RG122323200001', 'MOT126656', 'Blanco', 2025, 'Disponible', 1);
GO


-- INVENTARIOS
INSERT INTO [Inventarios] ([Fecha_Ingreso], [Ubicacion], [Moto])
VALUES ('2026-10-01', 'Zona de exhibicion', 1);
GO


-- COMPRAS
INSERT INTO [Compras] ([Fecha_Compra], [Impuesto], [Numero_Factura], [Total], [Proveedor])
VALUES ('2026-10-01', 247000.00, 'FAC-001', 1547000.00, 1);
GO


-- REPUESTOS
INSERT INTO [Repuestos] ([Numero_Parte], [Descripcion], [Fecha_Modificacion], [Producto])
VALUES ('REP-001', 'Filtro de aceite para motocicleta', '2026-10-01', 1);
GO


-- EMPLEADOS
INSERT INTO [Empleados] ([Carnet], [Fecha_Contratacion], [Persona], [Cargo])
VALUES ('EMP001', '2026-01-15', 2, 1);
GO


-- VENTAS
INSERT INTO [Ventas] ([Fecha_Venta], [Impuestos], [Total], [Cliente], [Empleado])
VALUES ('2026-10-01', 1819250.00, 11394250.00, 1, 1);
GO


-- PAGOS
-- El cliente paga inicialmente $6.394.250
INSERT INTO [Pagos] ([Fecha_Pago], [Monto], [Metodo], [Venta])
VALUES ('2026-10-01', 6394250.00, 1, 1);
GO


-- DETALLES DE VENTAS DE MOTOS
INSERT INTO [DetallesVentasMotos] ([Precio_Unitario], [Descuento], [Subtotal], [Moto], [Venta])
VALUES (10000000.00, 500000.00, 9500000.00, 2, 1);
GO


-- DETALLES DE VENTAS DE PRODUCTOS
INSERT INTO [DetallesVentasProductos] ([Precio_Unitario], [Descuento], [Subtotal], [Cantidad], [Producto], [Venta])
VALUES (75000.00, 0.00, 75000.00, 1, 2, 1);
GO


-- FINANCIAMIENTOS
INSERT INTO [Financiamientos] ([Monto], [Numero_Cuotas], [Tasa_Interes], [Fecha_Inicio], [Fecha_Fin], [Estado], [Venta])
VALUES (5000000.00, 12, 1.50, '2026-10-01', '2027-10-01', 'Activo', 1);
GO


-- CUOTAS
INSERT INTO [Cuotas] ([Numero_cuota], [Monto], [Fecha_vencimiento], [Fecha_pago], [Financiamiento])
VALUES (1, 458333.33, '2026-11-01', NULL, 1);
GO


-- DETALLES DE COMPRAS
INSERT INTO [DetallesCompras] ([Cantidad], [Precio_Unitario], [Descuento], [Subtotal], [Compra], [Producto])
VALUES (20, 65000.00, 0.00, 1300000.00, 1, 1);
GO
INSERT INTO Usuarios (NombreUsuario, Contraseña)
VALUES ('admin', '123456');
GO

BEGIN TRANSACTION;

DECLARE @UsuarioID INT;
DECLARE @RolID INT;


SET @UsuarioID = SCOPE_IDENTITY();


-- 2. Crear rol Administrador
INSERT INTO Roles (Nombre, Usuario)
VALUES ('Administrador', @UsuarioID);

SET @RolID = SCOPE_IDENTITY();


-- 3. Asignar permisos de visualización
INSERT INTO Permisos (Rol, Descripcion)
VALUES
    (@RolID, 'Accesorios'),
    (@RolID, 'Cargos'),
    (@RolID, 'Clientes'),
    (@RolID, 'Empleados'),
    (@RolID, 'Inventarios'),
    (@RolID, 'ModelosMotos'),
    (@RolID, 'Motos'),
    (@RolID, 'Personas'),
    (@RolID, 'Productos'),
    (@RolID, 'Proveedores'),
    (@RolID, 'Repuestos'),
    (@RolID, 'Usuarios'),
    (@RolID, 'Roles'),
    (@RolID, 'Compras'),
    (@RolID, 'DetallesCompras'),
    (@RolID, 'Ventas'),
    (@RolID, 'DetallesVentasMotos'),
    (@RolID, 'DetallesVentasProductos'),
    (@RolID, 'Financiamientos'),
    (@RolID, 'Cuotas'),
    (@RolID, 'Pagos'),
    (@RolID, 'MetodosPagos');

COMMIT TRANSACTION;
GO

BEGIN TRANSACTION;

DECLARE @UsuarioID INT;
DECLARE @RolID INT;

-- 1. Crear usuario
INSERT INTO Usuarios (NombreUsuario, Contraseña)
VALUES ('vendedor', 'Vendedor123');

SET @UsuarioID = SCOPE_IDENTITY();

-- 2. Crear rol
INSERT INTO Roles (Nombre, Usuario)
VALUES ('Vendedor', @UsuarioID);

SET @RolID = SCOPE_IDENTITY();

-- 3. Asignar permisos de visualización
INSERT INTO Permisos (Rol, Descripcion)
VALUES
    (@RolID, 'Clientes'),
    (@RolID, 'Productos'),
    (@RolID, 'Motos'),
    (@RolID, 'Ventas');

COMMIT TRANSACTION;

-- 4. Verificar usuario, rol y permisos
SELECT
    U.ID,
    U.NombreUsuario,
    R.Nombre AS Rol,
    P.Descripcion AS Permiso
FROM Usuarios U
INNER JOIN Roles R ON R.Usuario = U.ID
INNER JOIN Permisos P ON P.Rol = R.ID
WHERE U.NombreUsuario = 'vendedor';