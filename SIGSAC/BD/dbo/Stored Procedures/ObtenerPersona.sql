
CREATE PROCEDURE ObtenerPersona
@Id INT
AS
BEGIN
SET NOCOUNT ON;

SELECT
id,
nombre,
primer_apellido AS PrimerApellido,
segundo_apellido AS SegundoApellido,
cedula,
pasaporte,
sexo,
fecha_nacimiento AS FechaNacimiento,
hora_nacimiento AS HoraNacimiento,
lugar_nacimiento AS LugarNacimiento,
nacionalidad,
estado_civil AS EstadoCivil,
profesion,
religion,
direccion
FROM persona
WHERE id = @Id

END