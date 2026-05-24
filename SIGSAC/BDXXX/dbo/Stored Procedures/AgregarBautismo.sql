CREATE OR REPLACE FUNCTION agregar_bautismo(
    p_bautizando_id INT,
    p_padre_id INT,
    p_madre_id INT,
    p_tipo_union_padres VARCHAR(50),
    p_fecha_matrimonio_padres DATE,
    p_abuelo_paterno_id INT,
    p_abuela_paterna_id INT,
    p_abuelo_materno_id INT,
    p_abuela_materna_id INT,
    p_padrino_id INT,
    p_madrina_id INT,
    p_declarante_id INT
)
RETURNS INT
LANGUAGE plpgsql
AS
$$
DECLARE
    nuevo_id INT;
BEGIN

    INSERT INTO bautismo
    (
        sacramento,
        bautizando_id,
        padre_id,
        madre_id,
        tipo_union_padres,
        fecha_matrimonio_padres,
        abuelo_materno_id,
        abuela_materna_id,
        abuelo_paterno_id,
        abuela_paterna_id,
        padrino_id,
        madrina_id,
        declarante_id
    )
    VALUES
    (
        1,
        p_bautizando_id,
        p_padre_id,
        p_madre_id,
        p_tipo_union_padres,
        p_fecha_matrimonio_padres,
        p_abuelo_materno_id,
        p_abuela_materna_id,
        p_abuelo_paterno_id,
        p_abuela_paterna_id,
        p_padrino_id,
        p_madrina_id,
        p_declarante_id
    )
    RETURNING id
    INTO nuevo_id;

    RETURN nuevo_id;

END;
$$;