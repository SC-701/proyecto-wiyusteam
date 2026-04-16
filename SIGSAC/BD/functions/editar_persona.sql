CREATE OR REPLACE FUNCTION editar_persona(
    p_id INT,
    p_nombre VARCHAR(100),
    p_primer_apellido VARCHAR(100),
    p_segundo_apellido VARCHAR(100),
    p_cedula VARCHAR(20),
    p_pasaporte VARCHAR(20),
    p_sexo VARCHAR(10),
    p_fecha_nacimiento TIMESTAMP,
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
BEGIN

    UPDATE persona
    SET
        nombre = p_nombre,
        primer_apellido = p_primer_apellido,
        segundo_apellido = p_segundo_apellido,
        cedula = p_cedula,
        pasaporte = p_pasaporte,
        sexo = p_sexo,
        fecha_nacimiento = p_fecha_nacimiento,
        hora_nacimiento = p_hora_nacimiento,
        lugar_nacimiento = p_lugar_nacimiento,
        nacionalidad = p_nacionalidad,
        estado_civil = p_estado_civil,
        profesion = p_profesion,
        religion = p_religion,
        direccion = p_direccion,
        fecha_actualizacion = NOW()
    WHERE id = p_id;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'No se encontró la persona con id %', p_id;
    END IF;

    RETURN p_id;

END;
$$;