USE [DB_A14EBC_reserva]
GO
/****** Object:  StoredProcedure [dbo].[M10_ActualizarReservaAutomovil]    Script Date: 15/01/2017 6:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[M19_ActualizarReservaAutomovil]
	-- Add the parameters for the stored procedure here
	  @raut_id AS int,
	  @raut_hora_fin AS varchar (255)  

AS
BEGIN
SET NOCOUNT ON 
	-- SET NOCOUNT ON added to prevent extra result sets from
	update Reserva_Automovil 
	set raut_hora_fin = @raut_hora_fin
	where raut_id = @raut_id; 
END

GO
/****** Object:  StoredProcedure [dbo].[M19_AgregarReservaAutomovil]    Script Date: 15/01/2017 6:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- Procedure structure for M19_AgregarReservaAutomovil
-- ----------------------------
CREATE PROCEDURE [dbo].[M19_AgregarReservaAutomovil]
  @raut_fecha_ini AS varchar (100),
  @raut_fecha_fin AS varchar (100),
  @raut_hora_ini AS varchar (100),
  @raut_hora_fin AS varchar (100),
  @raut_fk_usuario AS int ,
  @raut_fk_automovil AS varchar (100),
  @raut_fk_ciudad_devolucion AS int,
  @raut_fk_ciudad_entrega AS int,
  @raut_estatus AS int 
AS
BEGIN
	insert into Reserva_Automovil (raut_fecha_ini, raut_fecha_fin, raut_hora_ini, raut_hora_fin, raut_fk_usuario,raut_fk_automovil, raut_fk_ciudad_devolucion, raut_fk_ciudad_entrega,raut_estatus)
	values (@raut_fecha_ini, @raut_fecha_fin, @raut_hora_ini, @raut_hora_fin, @raut_fk_usuario, @raut_fk_automovil,@raut_fk_ciudad_devolucion,@raut_fk_ciudad_entrega,@raut_estatus);
END

GO
/****** Object:  StoredProcedure [dbo].[M19_Consultar_Lugar]    Script Date: 15/01/2017 6:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[M19_Consultar_Lugar]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT c.lug_id,c.lug_nombre, p.lug_nombre from lugar p, lugar c
	where c.lug_tipo_lugar = 'Ciudad' and c.lug_FK_lugar_id = p.lug_id
END


GO
/****** Object:  StoredProcedure [dbo].[M19_ConsultarReservaAutomovil]    Script Date: 15/01/2017 6:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- ============================================= consulta reserva de autos por usuario
CREATE PROCEDURE  [dbo].[M19_ConsultarReservaAutomovil]

@raut_fk_usuario AS int -- Atributo de entrada, si tuviera despues del int output es de salida. 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
  	SELECT raut_id, aut_fabricante, aut_modelo, raut_fecha_ini, raut_fecha_fin, lugarEntrega.lug_nombre AS origen, lugarDevolucion.lug_nombre AS destino, raut_estatus, raut_hora_ini, raut_hora_fin, raut_fk_usuario, raut_fk_automovil
  	FROM Automovil, Reserva_Automovil, Usuario, Lugar lugarEntrega, Lugar lugarDevolucion 
  	WHERE usu_id = @raut_fk_usuario
    AND raut_fk_usuario=usu_id 
  	AND raut_fk_automovil=aut_matricula 
  	AND raut_fk_ciudad_entrega=lugarEntrega.lug_id 
  	AND raut_fk_ciudad_devolucion=lugarDevolucion.lug_id;

	END


GO
/****** Object:  StoredProcedure [dbo].[M19_ConsultarReservaAutomovilId]    Script Date: 15/01/2017 6:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[M19_ConsultarReservaAutomovilId]
	-- Add the parameters for the stored procedure here
	 @raut_id AS int -- Atributo de entrada, si tuviera despues del int output es de salida
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select *from Reserva_Automovil where raut_id = @raut_id;
END

GO
/****** Object:  StoredProcedure [dbo].[M19_EliminarReservaAutomovil]    Script Date: 15/01/2017 6:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[M19_EliminarReservaAutomovil]
	-- Add the parameters for the stored procedure here
 @raut_id AS int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Reserva_Automovil 
	SET raut_estatus = 0
	WHERE raut_id = @raut_id; 
END


GO
/****** Object:  StoredProcedure [dbo].[M19_ConsultarReservaAutomovil]    Script Date: 15/01/2017 6:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- ============================================= consulta reserva de autos por ciudad
CREATE PROCEDURE  [dbo].[M19_ConsultarReservaAutomovilPorCiudad]
@raut_fk_ciudad_entrega AS int -- Atributo de entrada, si tuviera despues del int output es de salida. Ciudad donde se entregó el vehículo
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT aut_matricula, aut_modelo, aut_fabricante, aut_tipovehiculo, aut_color, aut_transmision, aut_fk_ciudad, aut_preciocompra, aut_anio, aut_cantpasajeros, aut_disponibilidad FROM Automovil, Reserva_Automovil WHERE aut_disponibilidad=1 and aut_fk_ciudad= @raut_fk_ciudad_entrega 
	EXCEPT SELECT DISTINCT aut_matricula, aut_modelo, aut_fabricante, aut_tipovehiculo, aut_color, aut_transmision, aut_fk_ciudad, aut_preciocompra, aut_anio, aut_cantpasajeros, aut_disponibilidad FROM Automovil, Reserva_Automovil WHERE aut_matricula=raut_fk_automovil and raut_estatus=1 and aut_fk_ciudad= @raut_fk_ciudad_entrega
	END


GO
/****** Object:  StoredProcedure [dbo].[M19_ConsultarReservaAutomovil]    Script Date: 15/01/2017 6:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- ============================================= consulta reserva de autos por ciudad
CREATE PROCEDURE  [dbo].[M19_ConsultarReservaAPorCiudad]
@raut_fk_ciudad_entrega AS int -- Atributo de entrada, si tuviera despues del int output es de salida. Ciudad donde se entregó el vehículo
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT aut_matricula, aut_modelo, aut_fabricante, aut_tipovehiculo, aut_color, aut_transmision, aut_fk_ciudad, aut_precioalquiler, aut_anio, aut_cantpasajeros, aut_disponibilidad FROM Automovil, Reserva_Automovil WHERE aut_disponibilidad=1 and aut_fk_ciudad= @raut_fk_ciudad_entrega 
	EXCEPT SELECT DISTINCT aut_matricula, aut_modelo, aut_fabricante, aut_tipovehiculo, aut_color, aut_transmision, aut_fk_ciudad, aut_precioalquiler, aut_anio, aut_cantpasajeros, aut_disponibilidad FROM Automovil, Reserva_Automovil WHERE aut_matricula=raut_fk_automovil and raut_estatus=1 and aut_fk_ciudad= @raut_fk_ciudad_entrega
	END

