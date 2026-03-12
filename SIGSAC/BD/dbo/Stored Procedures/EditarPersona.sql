

CREATE PROCEDURE EditarPersona

@Id INT,
@Nombre VARCHAR(100),
@PrimerApellido VARCHAR(100),
@SegundoApellido VARCHAR(100),
@Cedula VARCHAR(20),
@Pasaporte VARCHAR(20),
@Sexo VARCHAR(10),
@FechaNacimiento DATE,
@HoraNacimiento VARCHAR(10),
@LugarNacimiento VARCHAR(150),
@Nacionalidad VARCHAR(100),
@EstadoCivil VARCHAR(50),
@Profesion VARCHAR(100),
@Religion VARCHAR(100),
@Direccion VARCHAR(200)

AS
BEGIN

SET NOCOUNT ON;

BEGIN TRANSACTION

UPDATE Persona
SET
nombre=@Nombre,
primer_apellido=@PrimerApellido,
segundo_apellido=@SegundoApellido,
cedula=@Cedula,
pasaporte=@Pasaporte,
sexo=@Sexo,
fecha_nacimiento=@FechaNacimiento,
hora_nacimiento=@HoraNacimiento,
lugar_nacimiento=@LugarNacimiento,
nacionalidad=@Nacionalidad,
estado_civil=@EstadoCivil,
profesion=@Profesion,
religion=@Religion,
direccion=@Direccion

WHERE id=@Id

SELECT @Id

COMMIT TRANSACTION

END