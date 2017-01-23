USE [DB_A14EBC_reserva]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ----------------------------
-- AGREGAR COMIDA
-- ----------------------------
CREATE PROCEDURE [dbo].[M06_AgregarComida]
  @com_nombre AS varchar (100),
  @com_tipo AS varchar (100),
  @com_estatus AS int,
  @com_descripcion AS varchar (100)
AS
BEGIN
	insert into Comida (com_nombre, com_tipo, com_estatus, com_referencia)
	values (@com_nombre, @com_tipo, 1, @com_descripcion);
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- AGREGAR COMIDA A VUELO
-- ----------------------------
CREATE PROCEDURE [dbo].[M06_AgregarComidaVuelo]
  @com_vue_id AS int,
  @com_vue_fk_comida AS int,
  @com_vue_cantidad AS int
AS
BEGIN
	insert into Comida_Vuelo values (@com_vue_id, @com_vue_fk_comida , @com_vue_cantidad);
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- CONSULTAR COMIDAS
-- ----------------------------
CREATE PROCEDURE [dbo].[M06_ConsultarComidas]

AS
BEGIN
	select com_id, com_nombre, com_tipo, com_estatus, com_referencia from Comida;
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- CONSULTAR COMIDAS EN VUELOS
-- ----------------------------
CREATE PROCEDURE [dbo].[M06_ConsultarComidasVuelos]

AS
BEGIN
	SELECT com_vue_id, com_nombre, vue_codigo, com_vue_cantidad FROM Comida_Vuelo, Comida, Vuelo WHERE com_id = com_vue_fk_comida AND vue_id = com_vue_fk_vuelo
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- CAMBIAR ESTATUS COMIDA
-- ----------------------------

CREATE PROCEDURE [dbo].[M06_CambiarEstatusComida]
	@com_id AS int,
	@com_estatus AS int
 AS
BEGIN
SET NOCOUNT ON 
	update Comida set com_estatus = @com_estatus where com_id = @com_id; 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- CONSULTAR DATOS COMIDA
-- ----------------------------
CREATE PROCEDURE [dbo].[M06_ConsultarDatosComida]
	@com_id AS int
AS
BEGIN
	select com_nombre, com_tipo, com_estatus, com_referencia from Comida where com_id = @com_id;
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- EDITAR COMIDA
-- ----------------------------

CREATE PROCEDURE [dbo].[M06_EditarComida]
	@com_id AS int,
	@com_nombre AS varchar (100),
	@com_tipo AS varchar (100),
	@com_estatus AS int,
	@com_descripcion AS varchar (100)
 AS
BEGIN
SET NOCOUNT ON 
	update Comida set com_nombre = @com_nombre, com_tipo = @com_tipo, com_estatus = @com_estatus, com_referencia = @com_descripcion where com_id = @com_id; 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
DROP PROCEDURE dbo.M06_ConsultarComidas;
GO
*/

