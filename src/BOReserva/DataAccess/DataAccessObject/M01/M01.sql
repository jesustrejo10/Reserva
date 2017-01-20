USE [DB_A14EBC_reserva]
GO
/****** Object:  StoredProcedure [dbo].[M01_ConsultarUsuario] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ----------------------------
-- AGREGAR COMIDA
-- ----------------------------
CREATE PROCEDURE [dbo].[M01_ConsultarUsuario]
@correo 	VARCHAR(255)
AS
BEGIN
  SELECT  
	U.USU_CORREO correo,		
	U.USU_NOMBRE nombre,
    U.USU_APELLIDO apellido,
    U.USU_CONTRASEÑA contrasena,
    U.USU_ACTIVO activo,
    U.USU_ID usuID,
    R.rol_nombre rol,
	U.USU_FK_ROL rolID,
    U.USU_FECHACREACION fecha
  FROM [dbo].Usuario as U, 
	[dbo].ROL R
  WHERE U.usu_correo  LIKE @correo
	AND U.usu_fk_rol IS NOT NULL
END
GO
CREATE PROCEDURE [dbo].[M01_ActivarUsuario]
@id int
AS
BEGIN
	UPDATE [dbo].[Usuario]
		SET
			[usu_activo] = 'Activo'
		WHERE
			[usu_id] = @id
END
GO
CREATE PROCEDURE [dbo].[M01_DesactivarUsuario]
@id int
AS
BEGIN
	UPDATE [dbo].[Usuario]
		SET
			[usu_activo] = 'Inactivo'
		WHERE
			[usu_id] = @id
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO