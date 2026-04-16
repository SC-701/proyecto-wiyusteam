CREATE TABLE persona (
    id SERIAL PRIMARY KEY,

    nombre VARCHAR(100) NOT NULL,
    primer_apellido VARCHAR(100) NOT NULL,
    segundo_apellido VARCHAR(100),

    cedula VARCHAR(20) UNIQUE,
    pasaporte VARCHAR(20) UNIQUE,

    sexo VARCHAR(10) NOT NULL,

    fecha_nacimiento DATE,
    hora_nacimiento VARCHAR(10),

    lugar_nacimiento VARCHAR(150),
    nacionalidad VARCHAR(100),

    estado_civil VARCHAR(50),
    profesion VARCHAR(100),
    religion VARCHAR(100),

    direccion VARCHAR(200),

    fecha_creacion TIMESTAMP DEFAULT NOW(),
    fecha_actualizacion TIMESTAMP,

    activo BOOLEAN DEFAULT TRUE
);