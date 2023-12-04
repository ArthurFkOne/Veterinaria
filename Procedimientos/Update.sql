create procedure SpEditarRol

@idr int,
@Nombrer nvarchar(50)
as
begin
Update Roles
set
Nombre=@Nombrer
Where PkRoles=@idr
end