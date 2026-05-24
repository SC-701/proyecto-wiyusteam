CREATE OR REPLACE FUNCTION eliminar_bautismo(
    p_id INT
)
RETURNS INT
LANGUAGE plpgsql
AS
$$
BEGIN

    DELETE
    FROM bautismo
    WHERE id = p_id;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'No se encontró el bautismo con id %', p_id;
    END IF;

    RETURN p_id;

END;
$$;