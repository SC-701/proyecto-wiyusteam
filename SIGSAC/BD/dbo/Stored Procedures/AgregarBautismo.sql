CREATE PROCEDURE AgregarBautismo

@BautizandoId INT,
@PadreId INT,
@MadreId INT,
@TipoUnionPadres VARCHAR(50),
@FechaMatrimonioPadres DATE,
@AbueloPaternoId INT,
@AbuelaPaternaId INT,
@AbueloMaternoId INT,
@AbuelaMaternaId INT,
@PadrinoId INT,
@MadrinaId INT,
@DeclaranteId INT

AS
BEGIN

SET NOCOUNT ON;

BEGIN TRANSACTION

INSERT INTO Bautismo
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
@BautizandoId,
@PadreId,
@MadreId,
@TipoUnionPadres,
@FechaMatrimonioPadres,
@AbueloMaternoId,
@AbuelaMaternaId,
@AbueloPaternoId,
@AbuelaPaternaId,
@PadrinoId,
@MadrinaId,
@DeclaranteId
)

SELECT SCOPE_IDENTITY()

COMMIT TRANSACTION

END