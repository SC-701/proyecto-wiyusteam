CREATE OR REPLACE FUNCTION obtener_bautismo(
    p_id INT
)
RETURNS TABLE
(
    id INT,
    sacramento INT,

    "BautizandoId" INT,
    "BautizandoNombre" TEXT,

    "PadreId" INT,
    "PadreNombre" TEXT,

    "MadreId" INT,
    "MadreNombre" TEXT,

    "TipoUnionPadres" VARCHAR(50),
    "FechaMatrimonioPadres" DATE,

    "AbueloPaternoId" INT,
    "AbueloPaternoNombre" TEXT,

    "AbuelaPaternaId" INT,
    "AbuelaPaternaNombre" TEXT,

    "AbueloMaternoId" INT,
    "AbueloMaternoNombre" TEXT,

    "AbuelaMaternaId" INT,
    "AbuelaMaternaNombre" TEXT,

    "PadrinoId" INT,
    "PadrinoNombre" TEXT,

    "MadrinaId" INT,
    "MadrinaNombre" TEXT,

    "DeclaranteId" INT,
    "DeclaranteNombre" TEXT
)
LANGUAGE plpgsql
AS
$$
BEGIN

    RETURN QUERY

    SELECT
        b.id,
        b.sacramento,

        b.bautizando_id,
        CONCAT(pb.nombre, ' ', pb.primer_apellido, ' ', pb.segundo_apellido),

        b.padre_id,
        CONCAT(pp.nombre, ' ', pp.primer_apellido, ' ', pp.segundo_apellido),

        b.madre_id,
        CONCAT(pm.nombre, ' ', pm.primer_apellido, ' ', pm.segundo_apellido),

        b.tipo_union_padres,
        b.fecha_matrimonio_padres,

        b.abuelo_paterno_id,
        CONCAT(pap.nombre, ' ', pap.primer_apellido, ' ', pap.segundo_apellido),

        b.abuela_paterna_id,
        CONCAT(pap2.nombre, ' ', pap2.primer_apellido, ' ', pap2.segundo_apellido),

        b.abuelo_materno_id,
        CONCAT(pam.nombre, ' ', pam.primer_apellido, ' ', pam.segundo_apellido),

        b.abuela_materna_id,
        CONCAT(pam2.nombre, ' ', pam2.primer_apellido, ' ', pam2.segundo_apellido),

        b.padrino_id,
        CONCAT(ppad.nombre, ' ', ppad.primer_apellido, ' ', ppad.segundo_apellido),

        b.madrina_id,
        CONCAT(pmad.nombre, ' ', pmad.primer_apellido, ' ', pmad.segundo_apellido),

        b.declarante_id,
        CONCAT(pdec.nombre, ' ', pdec.primer_apellido, ' ', pdec.segundo_apellido)

    FROM bautismo b

    LEFT JOIN persona pb ON pb.id = b.bautizando_id
    LEFT JOIN persona pp ON pp.id = b.padre_id
    LEFT JOIN persona pm ON pm.id = b.madre_id

    LEFT JOIN persona pam ON pam.id = b.abuelo_materno_id
    LEFT JOIN persona pam2 ON pam2.id = b.abuela_materna_id

    LEFT JOIN persona pap ON pap.id = b.abuelo_paterno_id
    LEFT JOIN persona pap2 ON pap2.id = b.abuela_paterna_id

    LEFT JOIN persona ppad ON ppad.id = b.padrino_id
    LEFT JOIN persona pmad ON pmad.id = b.madrina_id

    LEFT JOIN persona pdec ON pdec.id = b.declarante_id

    WHERE b.id = p_id;

END;
$$;