CREATE OR REPLACE FUNCTION agregar_persona(
    p_nombre VARCHAR(100),
    p_primer_apellido VARCHAR(100),
    p_segundo_apellido VARCHAR(100),
    p_cedula VARCHAR(20),
    p_pasaporte VARCHAR(20),
    p_sexo VARCHAR(10),
    p_fecha_nacimiento DATE,
    p_hora_nacimiento VARCHAR(10),
    p_lugar_nacimiento VARCHAR(150),
    p_nacionalidad VARCHAR(100),
    p_estado_civil VARCHAR(50),
    p_profesion VARCHAR(100),
    p_religion VARCHAR(100),
    p_direccion VARCHAR(200)
)
RETURNS INT
LANGUAGE plpgsql
AS
$$
DECLARE
    nuevo_id INT;
BEGIN

    INSERT INTO persona
    (
        nombre,
        primer_apellido,
        segundo_apellido,
        cedula,
        pasaporte,
        sexo,
        fecha_nacimiento,
        hora_nacimiento,
        lugar_nacimiento,
        nacionalidad,
        estado_civil,
        profesion,
        religion,
        direccion
    )
    VALUES
    (
        p_nombre,
        p_primer_apellido,
        p_segundo_apellido,
        p_cedula,
        p_pasaporte,
        p_sexo,
        p_fecha_nacimiento,
        p_hora_nacimiento,
        p_lugar_nacimiento,
        p_nacionalidad,
        p_estado_civil,
        p_profesion,
        p_religion,
        p_direccion
    )
    RETURNING id
    INTO nuevo_id;

    RETURN nuevo_id;

END;
$$;