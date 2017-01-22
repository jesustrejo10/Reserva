USE [DB_A14EBC_reserva]
GO
/****** Object:  StoredProcedure [dbo].[M01_ConsultarUsuario] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ----------------------------
-- CONSULTAR USUARIO
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
		U.USU_FK_ROL rolID,
    U.USU_FECHACREACION fecha
	FROM [dbo].Usuario as U
	WHERE U.usu_correo  LIKE @correo
END
GO
-- ----------------------------
-- ACTIVAR USUARIO
-- ----------------------------
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
-- ----------------------------
-- DESACTIVAR USUARIO
-- ----------------------------
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
-- ----------------------------
-- INCREMENTAR INTENTOS
-- ----------------------------
CREATE PROCEDURE [dbo].[M01_IncrementarIntentos]
@correo VARCHAR(255)
AS
BEGIN
Update Login
	set log_intentos=log_intentos+1 
	where log_idusuario=(Select usu_id from Usuario where usu_correo like @correo)
END
GO
-- ----------------------------
-- RESETEAR INTENTOS
-- ----------------------------
ALTER PROCEDURE [dbo].[M01_ResetearIntentos]
@correo VARCHAR(255)
AS
BEGIN
Update Login 
	set log_intentos=0 
	where log_idusuario=(Select usu_id from Usuario where usu_correo like @correo)
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO