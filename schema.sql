-- ==========================================================
-- SCRIPT DE CREACIÓN DE BASE DE DATOS PARA MYSQL: regventas
-- ==========================================================

-- CREATE DATABASE IF NOT EXISTS regventas;
-- USE regventas;

-- 1. Tabla: Usuarios
CREATE TABLE IF NOT EXISTS Usuarios (
    ID_Usuario INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL,
    Rol VARCHAR(20) NOT NULL,
    Estado TINYINT(1) NOT NULL DEFAULT 1,
    CONSTRAINT CK_Usuarios_Rol CHECK (Rol IN ('Administrador', 'Cajero'))
);

-- 2. Tabla: Clientes
CREATE TABLE IF NOT EXISTS Clientes (
    ID_Cliente INT AUTO_INCREMENT PRIMARY KEY,
    Cedula VARCHAR(20) NOT NULL UNIQUE,
    Nombre VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) NULL,
    Direccion VARCHAR(250) NULL
);

-- 3. Tabla: Productos
CREATE TABLE IF NOT EXISTS Productos (
    ID_Producto INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL UNIQUE,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    StockMinimo INT NOT NULL,
    CONSTRAINT CK_Productos_Precio CHECK (Precio >= 0),
    CONSTRAINT CK_Productos_Stock CHECK (Stock >= 0),
    CONSTRAINT CK_Productos_StockMinimo CHECK (StockMinimo >= 0)
);

-- 4. Tabla: Ventas
CREATE TABLE IF NOT EXISTS Ventas (
    ID_Venta INT AUTO_INCREMENT PRIMARY KEY,
    NumeroFactura VARCHAR(20) NOT NULL UNIQUE,
    Fecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    ID_Cliente INT NOT NULL,
    ID_Usuario INT NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_Ventas_Clientes FOREIGN KEY (ID_Cliente) REFERENCES Clientes(ID_Cliente),
    CONSTRAINT FK_Ventas_Usuarios FOREIGN KEY (ID_Usuario) REFERENCES Usuarios(ID_Usuario),
    CONSTRAINT CK_Ventas_Total CHECK (Total >= 0)
);

-- 5. Tabla: DetalleVenta (Relación N:M entre Ventas y Productos)
CREATE TABLE IF NOT EXISTS DetalleVenta (
    ID_Detalle INT AUTO_INCREMENT PRIMARY KEY,
    ID_Venta INT NOT NULL,
    ID_Producto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    Subtotal DECIMAL(10,2) GENERATED ALWAYS AS (Cantidad * PrecioUnitario) STORED,
    CONSTRAINT FK_DetalleVenta_Ventas FOREIGN KEY (ID_Venta) REFERENCES Ventas(ID_Venta) ON DELETE CASCADE,
    CONSTRAINT FK_DetalleVenta_Productos FOREIGN KEY (ID_Producto) REFERENCES Productos(ID_Producto),
    CONSTRAINT CK_DetalleVenta_Cantidad CHECK (Cantidad > 0),
    CONSTRAINT CK_DetalleVenta_Precio CHECK (PrecioUnitario >= 0)
);
