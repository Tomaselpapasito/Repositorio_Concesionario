/*CREATE DATABASE CONCESIONARIO_DB;
GO
USE CONCESIONARIO_DB;
GO

CREATE TABLE [Personas]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NULL,
    [Cedula] NVARCHAR(50) NULL UNIQUE,
    [Fecha_Nacimiento] SMALLDATETIME NOT NULL,
    [Telefono] NVARCHAR(30) NULL
);

CREATE TABLE [Cargos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NULL,
    [Salario] DECIMAL(18,2) NOT NULL,
    [Activo] BIT NOT NULL
);

CREATE TABLE [ModelosMotos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NULL,
    [Cilindraje] INT NOT NULL,
    [Tipo_motor] NVARCHAR(100) NULL,
    [Transmision] NVARCHAR(100) NULL,
    [Potencia] DECIMAL(18,2) NOT NULL
);

CREATE TABLE [Proveedores]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NULL,
    [NIT] NVARCHAR(50) NULL,
    [Telefono] NVARCHAR(30) NULL,
    [Correo] NVARCHAR(150) NULL,
    [Direccion] NVARCHAR(200) NULL
);

CREATE TABLE [MetodosPagos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NULL,
    [Tipo] NVARCHAR(100) NULL,
    [Descripcion] NVARCHAR(250) NULL,
    [Activo] BIT NOT NULL
);

CREATE TABLE Servicios
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NULL,
    [Precio] DECIMAL(18,2) NOT NULL,
    [Duracion] INT NOT NULL,
    [Tipo_Servicio] NVARCHAR(100) NULL
);

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

CREATE TABLE [Clientes]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Correo] NVARCHAR(150) NULL,
    [Numero_Licencia] NVARCHAR(50) NULL UNIQUE,
    [Direccion] NVARCHAR(200) NULL,
    [Activo] BIT NOT NULL,
    [Persona] INT NOT NULL FOREIGN KEY REFERENCES [Personas]([ID])
);

CREATE TABLE [Motos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [VIN] NVARCHAR(100) NULL UNIQUE,
    [Numero_Motor] NVARCHAR(100) NULL,
    [Color] NVARCHAR(50) NULL,
    [Anio] INT NOT NULL,
    [Estado] NVARCHAR(50)NOT NULL,
    [Modelo] INT NOT NULL FOREIGN KEY REFERENCES [ModelosMotos]([ID])
);

CREATE TABLE [Inventarios]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Fecha_Ingreso] SMALLDATETIME NOT NULL,
    [Ubicacion] NVARCHAR(150) NULL,
    [Moto] INT NOT NULL FOREIGN KEY REFERENCES [Motos]([ID])
);

CREATE TABLE [Compras]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Fecha_Compra] SMALLDATETIME NOT NULL,
    [Impuesto] DECIMAL(18,2) NOT NULL,
    [Numero_Factura] NVARCHAR(100) NULL,
    [Total] DECIMAL(18,2) NOT NULL,
    [Proveedor] INT NOT NULL FOREIGN KEY REFERENCES [Proveedores]([ID])
);

CREATE TABLE [Repuestos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Numero_Parte] NVARCHAR(100) NULL,
    [Descripcion] NVARCHAR(250) NULL,
    [Fecha_Modificacion] SMALLDATETIME NOT NULL,
    [Producto] INT NOT NULL FOREIGN KEY REFERENCES [Productos]([ID])
);

CREATE TABLE [Accesorios]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NULL,
    [Categoria] NVARCHAR(100) NULL,
    [Marca] NVARCHAR(100) NULL,
    [Producto] INT NOT NULL FOREIGN KEY REFERENCES [Productos]([ID])
);

CREATE TABLE [Empleados]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Carnet] NVARCHAR(50) NULL,
    [Fecha_Contratacion] SMALLDATETIME NOT NULL,
    [Persona] INT NOT NULL FOREIGN KEY REFERENCES [Personas]([ID]),
    [Cargo] INT NOT NULL FOREIGN KEY REFERENCES [Cargos]([ID])
);

CREATE TABLE [Ventas]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Fecha_Venta] SMALLDATETIME NOT NULL,
    [Impuestos] DECIMAL(18,2) NOT NULL,
    [Total] DECIMAL(18,2) NOT NULL,
    [Cliente] INT NOT NULL FOREIGN KEY REFERENCES [Clientes]([ID]),
    [Empleado] INT NOT NULL FOREIGN KEY REFERENCES [Empleados]([ID])
);

CREATE TABLE [Pagos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Fecha_Pago] SMALLDATETIME NOT NULL,
    [Monto] DECIMAL(18,2) NOT NULL,
    [Metodo] INT NOT NULL FOREIGN KEY REFERENCES [MetodosPagos]([ID]),
    [Venta] INT NOT NULL FOREIGN KEY REFERENCES [Ventas]([ID])
);

CREATE TABLE [DetallesVentasMotos]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Precio_Unitario] DECIMAL(18,2) NOT NULL,
    [Descuento] DECIMAL(18,2) NOT NULL,
    [Subtotal] DECIMAL(18,2) NOT NULL,
    [Moto] INT NOT NULL FOREIGN KEY REFERENCES [Motos]([ID]),
    [Venta] INT NOT NULL FOREIGN KEY REFERENCES [Ventas]([ID])
);

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

CREATE TABLE [Cuotas]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Numero_cuota] INT NOT NULL,
    [Monto] DECIMAL(18,2) NOT NULL,
    [Fecha_vencimiento] SMALLDATETIME NOT NULL,
    [Fecha_pago] SMALLDATETIME NULL,
    [Financiamiento] INT NOT NULL FOREIGN KEY REFERENCES [Financiamientos]([ID])
);

CREATE TABLE [OrdenesServicios]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Fecha_Ingreso] SMALLDATETIME NOT NULL,
    [Fecha_Salida] SMALLDATETIME NOT NULL,
    [Descripcion] NVARCHAR(500) NULL,
    [Costo_Total] DECIMAL(18,2) NOT NULL,
    [Cliente] INT NOT NULL FOREIGN KEY REFERENCES [Clientes]([ID]),
    [Empleado] INT NOT NULL FOREIGN KEY REFERENCES [Empleados]([ID]),
    [Moto] INT NOT NULL FOREIGN KEY REFERENCES [Motos]([ID])
);

CREATE TABLE [DetallesServicios]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Cantidad] INT NOT NULL,
    [Precio] DECIMAL(18,2) NOT NULL,
    [Descuento] DECIMAL(18,2) NOT NULL,
    [Subtotal] DECIMAL(18,2) NOT NULL,
    [Orden] INT NOT NULL FOREIGN KEY REFERENCES [OrdenesServicios]([ID]),
    [Servicio] INT NOT NULL FOREIGN KEY REFERENCES [Servicios]([ID])
);

CREATE TABLE [DetallesCompras]
(
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Cantidad] INT NOT NULL,
    [Precio_Unitario] DECIMAL(18,2) NOT NULL,
    [Descuento] DECIMAL(18,2) NOT NULL,
    [Subtotal] DECIMAL(18,2) NOT NULL,
    [Compra] INT NOT NULL FOREIGN KEY REFERENCES [Compras]([ID]),
    [Producto] INT NOT NULL FOREIGN KEY REFERENCES [Productos]([ID])


    INSERT INTO [Personas] ([Nombre], [Cedula], [Fecha_Nacimiento], [Telefono])
            VALUES ('Arnold Gomez', '123456789', '1990-01-01', '3001234567');

    INSERT INTO [Cargos] ([Nombre], [Salario], [Activo])
            VALUES ('Asesor Comercial', 2500000.00, 1);

    INSERT INTO [ModelosMotos] ([Nombre], [Cilindraje], [Tipo_motor], [Transmision], [Potencia])
            VALUES ('Yamaha MT-03', 321, 'Bicilindrico', '6 velocidades', 42.00);

    INSERT INTO [Proveedores] ([Nombre], [NIT], [Telefono], [Correo], [Direccion])
            VALUES  ('MotoPartes Colombia SAS', '900123456-7', '6015551234', 'ventas@motopartes.com', 'Carrera 50 # 10-25');

    INSERT INTO [MetodosPagos] ([Nombre], [Tipo], [Descripcion], [Activo])
            VALUES ('Tarjeta de Credito', 'Electronico', 'Pago realizado mediante tarjeta de credito', 1);

    INSERT INTO [Servicios] ([Nombre], [Precio], [Duracion], [Tipo_Servicio])
        VALUES ('Cambio de aceite', 80000.00, 60, 'Mantenimiento');

    INSERT INTO [Productos] ([Codigo], [Nombre], [Fecha_Creacion], [Fecha_Modificacion], [Precio], [Stock], [Activo])
        VALUES ('ACE-001', 'Aceite Motul 5100 4T', '2026-01-10', '2026-01-10', 65000.00, 50, 1);

    INSERT INTO [Clientes] (Correo, Numero_Licencia, Direccion, Activo, Persona)
        VALUES ('arnold.gomez@email.com', 'LIC-123456', 'Calle 20 # 15-30', 1, 1);


);*/ 