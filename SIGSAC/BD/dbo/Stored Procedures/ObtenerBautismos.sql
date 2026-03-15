CREATE PROCEDURE ObtenerBautismos
AS
BEGIN
SET NOCOUNT ON;

SELECT
id,
sacramento,
bautizando_id AS BautizandoId,
padre_id AS PadreId,
madre_id AS MadreId,
tipo_union_padres AS TipoUnionPadres,
fecha_matrimonio_padres AS FechaMatrimonioPadres,
abuelo_materno_id AS AbueloMaternoId,
abuela_materna_id AS AbuelaMaternaId,
abuelo_paterno_id AS AbueloPaternoId,
abuela_paterna_id AS AbuelaPaternaId,
padrino_id AS PadrinoId,
madrina_id AS MadrinaId,
declarante_id AS DeclaranteId
FROM bautismo

END
