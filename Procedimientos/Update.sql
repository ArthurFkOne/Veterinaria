CREATE PROCEDURE SpEditarRol

@idr INT,
@Nombrer NVARCHAR(50)
AS
BEGIN
UPDATE Roles
SET
Nombre=@Nombrer
WHERE PkRoles=@idr
END;