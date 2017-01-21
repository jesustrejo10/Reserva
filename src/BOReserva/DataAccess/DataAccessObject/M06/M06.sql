USE [DB_A14EBC_reserva]
GO
/****** Object:  StoredProcedure [dbo].[M10_ActualizarRestaurante]    Script Date: 15/01/2017 6:45:36 PM ******/
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
-- CONSULTAR COMIDAS
-- ----------------------------
CREATE PROCEDURE [dbo].[M06_ConsultarComidas]

AS
BEGIN
	select @com_nombre, @com_tipo, @com_estatus, @com_referencia from Comida;
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


/*
DROP PROCEDURE dbo.M06_ConsultarComidas;
GO
*/