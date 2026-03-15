CREATE PROCEDURE ObtenerBautismo
@Id INT
AS
BEGIN
SET NOCOUNT ON;

SELECT
b.id,
b.sacramento,

b.bautizando_id AS BautizandoId,
pb.nombre + ' ' + pb.primer_apellido + ' ' + pb.segundo_apellido AS BautizandoNombre,

b.padre_id AS PadreId,
pp.nombre + ' ' + pp.primer_apellido + ' ' + pp.segundo_apellido AS PadreNombre,

b.madre_id AS MadreId,
pm.nombre + ' ' + pm.primer_apellido + ' ' + pm.segundo_apellido AS MadreNombre,

b.tipo_union_padres AS TipoUnionPadres,
b.fecha_matrimonio_padres AS FechaMatrimonioPadres,

b.abuelo_paterno_id AS AbueloPaternoId,
pap.nombre + ' ' + pap.primer_apellido + ' ' + pap.segundo_apellido AS AbueloPaternoNombre,

b.abuela_paterna_id AS AbuelaPaternaId,
pap2.nombre + ' ' + pap2.primer_apellido + ' ' + pap2.segundo_apellido AS AbuelaPaternaNombre,

b.abuelo_materno_id AS AbueloMaternoId,
pam.nombre + ' ' + pam.primer_apellido + ' ' + pam.segundo_apellido AS AbueloMaternoNombre,

b.abuela_materna_id AS AbuelaMaternaId,
pam2.nombre + ' ' + pam2.primer_apellido + ' ' + pam2.segundo_apellido AS AbuelaMaternaNombre,


b.padrino_id AS PadrinoId,
ppad.nombre + ' ' + ppad.primer_apellido + ' ' + ppad.segundo_apellido AS PadrinoNombre,

b.madrina_id AS MadrinaId,
pmad.nombre + ' ' + pmad.primer_apellido + ' ' + pmad.segundo_apellido AS MadrinaNombre,

b.declarante_id AS DeclaranteId,
pdec.nombre + ' ' + pdec.primer_apellido + ' ' + pdec.segundo_apellido AS DeclaranteNombre

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

WHERE b.id = @Id

END