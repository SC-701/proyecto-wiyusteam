CREATE OR REPLACE FUNCTION eliminar_persona(
    p_id INT
)
RETURNS INT
LANGUAGE plpgsql
AS
$$
BEGIN

    DELETE
    FROM persona
    WHERE id = p_id;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'No se encontró la persona con id %', p_id;
    END IF;

    RETURN p_id;

END;
$$;