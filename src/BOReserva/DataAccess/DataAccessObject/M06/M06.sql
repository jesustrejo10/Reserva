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