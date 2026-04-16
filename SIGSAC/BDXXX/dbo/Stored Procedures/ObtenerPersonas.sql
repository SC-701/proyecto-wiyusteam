CREATE OR REPLACE FUNCTION obtener_personas()
RETURNS TABLE
(
    id INT,
    nombre VARCHAR(100),
    "PrimerApellido" VARCHAR(100),
    "SegundoApellido" VARCHAR(100),
    cedula VARCHAR(20),
    pasaporte VARCHAR(20),
    sexo VARCHAR(10),
    "FechaNacimiento" DATE,
    "HoraNacimiento" VARCHAR(10),
    "LugarNacimiento" VARCHAR(150),
    nacionalidad VARCHAR(100),
    "EstadoCivil" VARCHAR(50),
    profesion VARCHAR(100),
    religion VARCHAR(100),
    direccion VARCHAR(200)
)
LANGUAGE plpgsql
AS
$$
BEGIN

    RETURN QUERY

    SELECT
        p.id,
        p.nombre,
        p.primer_apellido,
        p.segundo_apellido,
        p.cedula,
        p.pasaporte,
        p.sexo,
        p.fecha_nacimiento,
        p.hora_nacimiento,
        p.lugar_nacimiento,
        p.nacionalidad,
        p.estado_civil,
        p.profesion,
        p.religion,
        p.direccion
    FROM persona p;

END;
$$;