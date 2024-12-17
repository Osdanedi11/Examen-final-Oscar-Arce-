Create Database ExamenFinalOscar

CREATE TABLE CategoriaLaboral (
    Categoria VARCHAR(20) PRIMARY KEY,
    Descripcion TEXT NOT NULL
);

CREATE TABLE Empleado (
    Carnet INT PRIMARY KEY,
    NombreCompleto VARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Direccion VARCHAR(255) DEFAULT 'San José',
    Telefono VARCHAR(15) NOT NULL,
    CorreoElectronico VARCHAR(100) NOT NULL UNIQUE,
    Salario DECIMAL(10, 2) DEFAULT 250000 CHECK (Salario <= 500000),
    Categoria VARCHAR(20) NOT NULL,
    FOREIGN KEY (Categoria) REFERENCES CategoriaLaboral(Categoria)
);

CREATE TABLE Proyecto (
    CodigoProyecto INT PRIMARY KEY,
    NombreProyecto VARCHAR(100) NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE
);

CREATE TABLE Asignacion (
    Carnet INT,
    CodigoProyecto INT,
    FechaAsignacion DATE DEFAULT GETDATE(),
    PRIMARY KEY (Carnet, CodigoProyecto),
    FOREIGN KEY (Carnet) REFERENCES Empleado(Carnet),
    FOREIGN KEY (CodigoProyecto) REFERENCES Proyecto(CodigoProyecto)
);

-- Ejemplos
-- Categorías Laborales
INSERT INTO CategoriaLaboral (Categoria, Descripcion) VALUES
('Administrador', 'Responsable de la administración general del proyecto'),
('Operario', 'Encargado de tareas operativas en el proyecto'),
('Peón', 'Asistente general en el área de construcción');

-- Empleados
INSERT INTO Empleado (Carnet, NombreCompleto, FechaNacimiento, Direccion, Telefono, CorreoElectronico, Salario, Categoria) VALUES
(1, 'Juan Pérez', '1990-05-15', 'San José', '8888-5555', 'juan.perez@gmail.com', 300000, 'Administrador'),
(2, 'María López', '1985-09-20', 'Heredia', '8777-4444', 'maria.lopez@gmail.com', 250000, 'Operario'),
(3, 'Carlos Jiménez', '1992-11-10', NULL, '8999-3333', 'carlos.jimenez@gmail.com', 270000, 'Peón');

--  Proyectos
INSERT INTO Proyecto (CodigoProyecto, NombreProyecto, FechaInicio, FechaFin) VALUES
(101, 'Construcción de Vivienda', '2024-01-01', NULL),
(102, 'Ampliación de Oficina', '2024-03-01', '2024-06-01');

--  Asignaciones
INSERT INTO Asignacion (Carnet, CodigoProyecto, FechaAsignacion) VALUES
(1, 101, '2024-01-15'),
(2, 101, '2024-01-20'),
(3, 102, '2024-03-10');