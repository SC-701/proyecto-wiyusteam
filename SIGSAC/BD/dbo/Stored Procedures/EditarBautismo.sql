CREATE PROCEDURE EditarBautismo

@Id INT,
@BautizandoId INT,
@PadreId INT,
@MadreId INT,
@TipoUnionPadres VARCHAR(50),
@FechaMatrimonioPadres DATE,
@AbueloMaternoId INT,
@AbuelaMaternaId INT,
@AbueloPaternoId INT,
@AbuelaPaternaId INT,
@PadrinoId INT,
@MadrinaId INT,
@DeclaranteId INT

AS
BEGIN

SET NOCOUNT ON;

BEGIN TRANSACTION

UPDATE Bautismo
SET
bautizando_id = @BautizandoId,
padre_id = @PadreId,
madre_id = @MadreId,
tipo_union_padres = @TipoUnionPadres,
fecha_matrimonio_padres = @FechaMatrimonioPadres,
abuelo_materno_id = @AbueloMaternoId,
abuela_materna_id = @AbuelaMaternaId,
abuelo_paterno_id = @AbueloPaternoId,
abuela_paterna_id = @AbuelaPaternaId,
padrino_id = @PadrinoId,
madrina_id = @MadrinaId,
declarante_id = @DeclaranteId

WHERE id = @Id

SELECT @Id

COMMIT TRANSACTION

END