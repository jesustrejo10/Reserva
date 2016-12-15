/*
Navicat SQL Server Data Transfer

Source Server         : BD Reserva
Source Server Version : 120000
Source Host           : sql5032.smarterasp.net:1433
Source Database       : DB_A1380A_reserva
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 110000
File Encoding         : 65001

Date: 2016-12-15 11:01:15
*/


-- ----------------------------
-- Table structure for Automovil
-- ----------------------------
DROP TABLE [Automovil]
GO
CREATE TABLE [Automovil] (
[aut_matricula] varchar(50) NOT NULL ,
[aut_modelo] varchar(50) NOT NULL ,
[aut_fabricante] varchar(50) NOT NULL ,
[aut_anio] int NOT NULL ,
[aut_kilometraje] numeric(20,2) NULL ,
[aut_cantpasajeros] int NOT NULL ,
[aut_tipovehiculo] varchar(50) NOT NULL ,
[aut_preciocompra] numeric(20,2) NOT NULL ,
[aut_precioalquiler] numeric(20,2) NOT NULL ,
[aut_penalidaddiaria] numeric(20,2) NOT NULL ,
[aut_fecharegistro] date NOT NULL ,
[aut_color] varchar(20) NOT NULL ,
[aut_disponibilidad] int NOT NULL ,
[aut_transmision] varchar(20) NOT NULL ,
[aut_fk_ciudad] int NOT NULL 
)


GO

-- ----------------------------
-- Records of Automovil
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [Automovil] ([aut_matricula], [aut_modelo], [aut_fabricante], [aut_anio], [aut_kilometraje], [aut_cantpasajeros], [aut_tipovehiculo], [aut_preciocompra], [aut_precioalquiler], [aut_penalidaddiaria], [aut_fecharegistro], [aut_color], [aut_disponibilidad], [aut_transmision], [aut_fk_ciudad]) VALUES (N'08B1AOE', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'10I9P53', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'1167Y03', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'14DNKVO', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'9999.00', N'2016-11-12', N'Verde', N'1', N'Automatica', N'12'), (N'1CP6FIS', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'213SDFSD', N'Mazda3', N'Mazda', N'2013', N'4600.00', N'4', N'Deportivo', N'12500.00', N'.00', N'1.00', N'2016-12-14', N'Blanco', N'1', N'Automatica', N'74'), (N'2390VNFS', N'move', N'Ford', N'2011', N'99000.00', N'4', N'Minivan', N'9000.00', N'.00', N'.00', N'2016-12-14', N'Verde', N'1', N'Sincronica', N'73'), (N'28ZH5GP', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-11', N'Azul', N'1', N'Automatica', N'12'), (N'2Q16K33', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'345FGDFG', N'flex', N'Jeep', N'2016', N'.00', N'7', N'Camioneta', N'.00', N'250.00', N'200.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'47'), (N'3I3N6DQ', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'3QNVOU5', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-11-12', N'Azul', N'1', N'Automatica', N'12'), (N'45645FFG', N'move', N'Ford', N'2015', N'55000.00', N'4', N'Deportivo', N'15000.00', N'200.00', N'10.00', N'2016-12-14', N'Blanco', N'1', N'Automatica', N'24'), (N'456GFHFH', N'expedition', N'Jeep', N'2016', N'.00', N'6', N'Camioneta', N'60000.00', N'100.00', N'200.00', N'2016-12-14', N'Rojo', N'1', N'Automatica', N'45'), (N'4PDWF7Z', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-12', N'Azul', N'1', N'Automatica', N'12'), (N'4TZDB8S', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'4XMNLC3', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'54YXGH5', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'5KMPQG0', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-11-12', N'Azul', N'1', N'Automatica', N'12'), (N'5PR8V7C', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'5SXKRA8', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-11', N'Azul', N'1', N'Automatica', N'12'), (N'60SDTSC', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-11', N'Azul', N'1', N'Automatica', N'13'), (N'6J95JHE', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-11', N'Azul', N'1', N'Automatica', N'12'), (N'857HT90H', N'Fiesta', N'Ford', N'2012', N'2000.00', N'4', N'Deportivo', N'25000.00', N'10.00', N'10.00', N'2016-12-14', N'Rojo', N'1', N'Sincronica', N'31'), (N'89HKJH87', N'escape', N'Jeep', N'2016', N'.00', N'6', N'Camioneta', N'55000.00', N'200.00', N'100.00', N'2016-12-14', N'Gris', N'1', N'Automatica', N'29'), (N'89YRDV0', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-11', N'Azul', N'0', N'Automatica', N'12'), (N'8FDGJKDF', N'fusion', N'Ford', N'2016', N'.00', N'4', N'Deportivo', N'38450.00', N'.00', N'.00', N'2016-12-14', N'Rojo', N'1', N'Sincronica', N'107'), (N'8TCNEQL', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-11-12', N'Azul', N'1', N'Automatica', N'12'), (N'9AZG5DK', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-11-12', N'Azul', N'1', N'Automatica', N'12'), (N'9JLKFGHF', N'fordGT', N'Ford', N'2015', N'.00', N'2', N'Deportivo', N'100000.00', N'500.00', N'250.00', N'2016-12-14', N'Verde', N'1', N'Sincronica', N'49'), (N'9WKT8C6', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'A46TFCK', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'A57SFUE', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'AEYCX04', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'AGASDGHF', N'Mazda6', N'Mazda', N'2013', N'3500.00', N'4', N'Sedan', N'18000.00', N'.00', N'.00', N'2016-12-14', N'Verde', N'1', N'Sincronica', N'12'), (N'AUT223', N'GrandWagoneer', N'Jeep', N'1999', N'.00', N'10', N'Camioneta', N'.00', N'.00', N'.00', N'2016-05-12', N'Azul', N'1', N'Automatica', N'12'), (N'AUT522', N'Wagoneer', N'Jeep', N'2000', N'.00', N'10', N'Camioneta', N'.00', N'.00', N'.00', N'2016-09-12', N'Azul', N'1', N'Automatica', N'12'), (N'B2CI8ZD', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-11', N'Azul', N'1', N'Automatica', N'12'), (N'BLMOBI1', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-11', N'Azul', N'1', N'Automatica', N'12'), (N'BTOGPMZ', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-11', N'Azul', N'1', N'Automatica', N'12'), (N'BXXBN5K', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-11', N'Azul', N'1', N'Automatica', N'12'), (N'C00NQ4X', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'D6ONBLM', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'DWML5LB', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'F78SDFSD', N'meteor', N'Ford', N'2016', N'6000.00', N'4', N'Sedan', N'.00', N'.00', N'36.00', N'2016-12-14', N'Blanco', N'1', N'Automatica', N'87'), (N'FATTTT', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'12'), (N'FAW3AWG', N'Move', N'Ford', N'2015', N'2000.00', N'4', N'Deportivo', N'16000.00', N'.00', N'10.00', N'2016-12-14', N'Gris', N'1', N'Automatica', N'24'), (N'FGDFGN9D', N'Mazda2', N'Mazda', N'2016', N'.00', N'4', N'Deportivo', N'25000.00', N'.00', N'.00', N'2016-12-14', N'Rojo', N'1', N'Sincronica', N'98'), (N'GDFH34V', N'wrangler', N'Jeep', N'2016', N'1000.00', N'6', N'Todoterreno', N'75650.00', N'.00', N'300.00', N'2016-12-14', N'Rojo', N'1', N'Sincronica', N'16'), (N'GER64444', N'grantCheroke', N'Jeep', N'2011', N'100000.00', N'6', N'Camioneta', N'38952.00', N'.00', N'.00', N'2016-12-14', N'Negro', N'1', N'Automatica', N'81'), (N'GFH8FGH', N'Mazda2', N'Mazda', N'2014', N'200.00', N'4', N'Camioneta', N'8542.00', N'.00', N'20.00', N'2016-12-14', N'Blanco', N'1', N'Sincronica', N'44'), (N'HX92HDI', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'IR5M3G9', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'IZBT0JZ', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'J2WJCG8', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'JDF7DFG', N'fusionHYBRID', N'Ford', N'2013', N'1300.00', N'4', N'Deportivo', N'110000.00', N'.00', N'300.00', N'2016-12-14', N'Azul', N'1', N'Sincronica', N'66'), (N'JH7SG9HS', N'Figo', N'Ford', N'2013', N'909.00', N'4', N'Sedan', N'25000.00', N'.00', N'10.00', N'2016-12-14', N'Negro', N'1', N'Sincronica', N'104'), (N'JU631MR', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'JW9JWE3', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'K15CDR7', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'KJBDFG7D', N'MX5', N'Mazda', N'2016', N'4500.00', N'4', N'Sedan', N'19600.00', N'.00', N'.00', N'2016-12-14', N'Gris', N'1', N'Sincronica', N'39'), (N'KLJH8789', N'cherokee', N'Jeep', N'2016', N'.00', N'8', N'Camioneta', N'90000.00', N'.00', N'.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'67'), (N'KRCTTSL', N'4', N'Jeep', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'12'), (N'KRP7JSJ', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'L4HG0BT', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'L66STEJ', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'LW4UNIW', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'LXOQ74W', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'MKPDF90', N'Cx3', N'Mazda', N'2016', N'1250.00', N'4', N'Camioneta', N'450000.00', N'.00', N'.00', N'2016-12-14', N'Gris', N'1', N'Secuencial', N'55'), (N'MQTTBR4', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'NX2E1Y1', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'O8R23F6', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'OC61SDF', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'P80OCIH', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'PLACA24', N'Wranger', N'Jeep', N'1946', N'100000.00', N'8', N'Minivan', N'100.00', N'10.00', N'5.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'100'), (N'PMSOTCN', N'4', N'Jeep', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'PMX4PUS', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'PRUEBACON', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'12'), (N'Q6XJ7AO', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'Q9GD3D9', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'QWHFR4H', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'RTBRTBRB', N'Mazda3', N'Mazda', N'2010', N'14598.00', N'4', N'Deportivo', N'10.00', N'.00', N'10.00', N'2016-12-14', N'Gris', N'1', N'Sincronica', N'92'), (N'SA9PFDU', N'4', N'Jeep', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'SDFKH6SD', N'renegade', N'Ford', N'2010', N'3556.00', N'4', N'Camioneta', N'11250.00', N'.00', N'1.00', N'2016-12-14', N'Negro', N'1', N'Sincronica', N'35'), (N'SDVSDFSD', N'grantCheroke', N'Jeep', N'2016', N'200.00', N'4', N'Todoterreno', N'46000.00', N'.00', N'40.00', N'2016-12-14', N'Negro', N'1', N'Automatica', N'79'), (N'T0SV8U1', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'TBJQPCE', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'TY9D9JO', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'TZQ8BNX', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'UG60O0X', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'UXN13PD', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'WD30U1W', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'WGM96FV', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'WWECCWEV', N'renegade', N'Jeep', N'2015', N'10000.00', N'4', N'Todoterreno', N'83679.00', N'.00', N'.00', N'2016-12-14', N'Verde', N'1', N'Sincronica', N'21'), (N'X0WFQCK', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'XPWELE3', N'4', N'Jeep', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'YCZ6PRA', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'YDI4DBC', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'YGZQN74', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'YKK8ZQJ', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13')
GO
GO
INSERT INTO [Automovil] ([aut_matricula], [aut_modelo], [aut_fabricante], [aut_anio], [aut_kilometraje], [aut_cantpasajeros], [aut_tipovehiculo], [aut_preciocompra], [aut_precioalquiler], [aut_penalidaddiaria], [aut_fecharegistro], [aut_color], [aut_disponibilidad], [aut_transmision], [aut_fk_ciudad]) VALUES (N'Z9N6K4D', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13'), (N'ZJFP1FC', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-14', N'Azul', N'1', N'Automatica', N'13'), (N'ZK7M5A8', N'3', N'Mazda', N'1936', N'5.00', N'5', N'Sedan', N'1.00', N'1.00', N'1.00', N'2016-12-13', N'Azul', N'1', N'Automatica', N'13')
GO
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Avion
-- ----------------------------
DROP TABLE [Avion]
GO
CREATE TABLE [Avion] (
[avi_id] int NOT NULL IDENTITY(1,1) ,
[avi_matricula] varchar(50) NOT NULL ,
[avi_modelo] varchar(255) NOT NULL ,
[avi_pasajeros_turista] int NULL ,
[avi_pasajeros_ejecutiva] int NULL ,
[avi_pasajeros_vip] int NULL ,
[avi_cap_equipaje] real NOT NULL ,
[avi_max_dist] real NOT NULL ,
[avi_max_vel] real NULL ,
[avi_max_comb] real NOT NULL ,
[avi_disponibilidad] int NULL 
)


GO
DBCC CHECKIDENT(N'[Avion]', RESEED, 157)
GO

-- ----------------------------
-- Records of Avion
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Avion] ON
GO
INSERT INTO [Avion] ([avi_id], [avi_matricula], [avi_modelo], [avi_pasajeros_turista], [avi_pasajeros_ejecutiva], [avi_pasajeros_vip], [avi_cap_equipaje], [avi_max_dist], [avi_max_vel], [avi_max_comb], [avi_disponibilidad]) VALUES (N'1', N'HK-45', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'2', N'HK', N'PRUEBA', N'101', N'101', N'101', N'101', N'201', N'541', N'1002', N'0'), (N'3', N'MD-5763', N'747', N'50', N'4', N'3', N'6', N'7', N'3', N'6', N'1'), (N'4', N'IAM-123', N'Boeing 777', N'20', N'10', N'10', N'3000', N'1900', N'700', N'100000', N'0'), (N'5', N'KM-236', N'Boeing 747', N'30', N'40', N'30', N'50', N'295', N'300', N'100', N'1'), (N'12', N'PruebaMat', N'Boeing', N'100', N'100', N'20', N'1000', N'1400', N'790', N'140000', N'1'), (N'13', N'1234', N'123213', N'1231', N'123213', N'13123', N'123123', N'1212', N'12312', N'123213', N'1'), (N'17', N'hk400', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'36', N'PEIAMRD', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'38', N'LH5VCI7', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'40', N'Hk900', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'41', N'K9TZV3N', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'44', N'G9SKIJD', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'45', N'1XJ4WPV', N'Boeing701', N'101', N'101', N'101', N'101', N'201', N'1001', N'101', N'1'), (N'50', N'5KB3QXA', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'54', N'EFJS6IQ', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'58', N'Z94QKAL', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'62', N'BC9ENAV', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'64', N'99GZ89F', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'66', N'8RWZ4N2', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'0'), (N'69', N'5JRYDBH', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'71', N'LIWBDJY', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'73', N'C6KUHPE', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'75', N'asda', N'zxcc', N'12', N'32', N'32', N'23', N'1000', N'400', N'200', N'1'), (N'77', N'XYDB0H5', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'79', N'FX510QO', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'81', N'55YN99V', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'83', N'7UYBXVU', N'Boeing700', N'101', N'100', N'100', N'100', N'200', N'1000', N'100', N'0'), (N'87', N'W1VQ499', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'88', N'8TC9NNK', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'0'), (N'90', N'RZIDARP', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'92', N'01TP0Y1', N'Boeing701', N'101', N'101', N'101', N'101', N'201', N'1001', N'101', N'0'), (N'93', N'Q8ENZIB', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'97', N'QGHMRV1', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'99', N'NMFCWXT', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'101', N'KA5QWV2', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'103', N'JT7XAJ6', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'105', N'DPLUW7D', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'107', N'CJKGWF9', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'109', N'YOXA27I', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'110', N'A3M5V5F', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'112', N'4KXQ4OQ', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'113', N'1DIKFCR', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'115', N'7J6QKFA', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'116', N'HM6NM3M', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'118', N'2200FVS', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'119', N'1752106', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'121', N'BP6Z8UC', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'122', N'PruebaFinal', N'Boeing-800', N'140', N'50', N'100', N'1400', N'2300', N'900', N'100000', N'1'), (N'123', N'KAUGQVC', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'125', N'Z75KERN', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'126', N'3R75B93', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'128', N'081ITUI', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'130', N'7YKV8I4', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'132', N'NPYSOGQ', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'133', N'UFWJQAE', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'135', N'1KZSWTH', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'137', N'743MIVI', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'139', N'5S6UYE7', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'141', N'6RIH6C7', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'142', N'7UXVMEX', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'143', N'QT5KZ9D', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'145', N'VIRW68F', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'146', N'QP5AJDO', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'148', N'N65RULP', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'149', N'XMWDWBI', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'151', N'331AZZI', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'152', N'8JKVBEW', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'154', N'HP4D3N6', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'155', N'7L6RC3B', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1'), (N'157', N'33X97F6', N'Boeing700', N'100', N'100', N'100', N'100', N'200', N'1000', N'100', N'1')
GO
GO
SET IDENTITY_INSERT [Avion] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Boleto
-- ----------------------------
DROP TABLE [Boleto]
GO
CREATE TABLE [Boleto] (
[bol_id] int NOT NULL IDENTITY(1,1) ,
[bol_escala] int NOT NULL ,
[bol_ida_vuelta] int NOT NULL ,
[bol_costo] int NOT NULL ,
[bol_fk_lugar_origen] int NOT NULL ,
[bol_fk_lugar_destino] int NOT NULL ,
[bol_fk_pasajero] int NOT NULL ,
[bol_fecha] date NOT NULL ,
[bol_tipo_boleto] varchar(50) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Boleto]', RESEED, 68)
GO

-- ----------------------------
-- Records of Boleto
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Boleto] ON
GO
INSERT INTO [Boleto] ([bol_id], [bol_escala], [bol_ida_vuelta], [bol_costo], [bol_fk_lugar_origen], [bol_fk_lugar_destino], [bol_fk_pasajero], [bol_fecha], [bol_tipo_boleto]) VALUES (N'4', N'0', N'1', N'500', N'12', N'16', N'19720982', N'2017-06-18', N'Turista'), (N'7', N'0', N'1', N'650', N'16', N'20', N'19720982', N'2016-10-18', N'Turista'), (N'8', N'0', N'1', N'700', N'11', N'34', N'19720982', N'2016-09-18', N'Ejecutivo'), (N'9', N'0', N'1', N'500', N'12', N'16', N'24221075', N'2016-12-01', N'Turista'), (N'10', N'0', N'0', N'600', N'12', N'16', N'24221075', N'2016-10-18', N'Ejecutivo'), (N'62', N'0', N'1', N'616', N'12', N'16', N'31233', N'2016-12-14', N'Turista'), (N'63', N'0', N'1', N'616', N'12', N'16', N'31233', N'2016-12-14', N'Turista'), (N'64', N'0', N'1', N'961', N'16', N'12', N'11111111', N'2016-12-14', N'Vip'), (N'65', N'0', N'1', N'200', N'12', N'16', N'4455743', N'2016-12-14', N'Ejecutivo'), (N'66', N'0', N'1', N'788', N'12', N'16', N'4444444', N'2016-12-14', N'Ejecutivo'), (N'67', N'0', N'1', N'200', N'12', N'16', N'4455743', N'2016-12-14', N'Ejecutivo'), (N'68', N'0', N'1', N'492', N'12', N'16', N'12211212', N'2016-12-14', N'Turista')
GO
GO
SET IDENTITY_INSERT [Boleto] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Boleto_Vuelo
-- ----------------------------
DROP TABLE [Boleto_Vuelo]
GO
CREATE TABLE [Boleto_Vuelo] (
[bol_vue_id] int NOT NULL IDENTITY(1,1) ,
[bol_fk_boleto] int NOT NULL ,
[bol_fk_vuelo] int NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Boleto_Vuelo]', RESEED, 30)
GO

-- ----------------------------
-- Records of Boleto_Vuelo
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Boleto_Vuelo] ON
GO
INSERT INTO [Boleto_Vuelo] ([bol_vue_id], [bol_fk_boleto], [bol_fk_vuelo]) VALUES (N'1', N'4', N'6'), (N'3', N'7', N'8'), (N'5', N'8', N'6'), (N'7', N'9', N'6'), (N'8', N'10', N'6'), (N'9', N'10', N'7'), (N'24', N'62', N'6'), (N'25', N'63', N'6'), (N'26', N'64', N'7'), (N'27', N'65', N'6'), (N'28', N'66', N'6'), (N'29', N'67', N'6'), (N'30', N'68', N'6')
GO
GO
SET IDENTITY_INSERT [Boleto_Vuelo] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Cabina
-- ----------------------------
DROP TABLE [Cabina]
GO
CREATE TABLE [Cabina] (
[cab_id] int NOT NULL IDENTITY(1,1) ,
[cab_nombre] varchar(20) NULL ,
[cab_precio] float(53) NOT NULL ,
[cab_estatus] varchar(10) NULL ,
[cab_fk_crucero] int NULL 
)


GO
DBCC CHECKIDENT(N'[Cabina]', RESEED, 109)
GO

-- ----------------------------
-- Records of Cabina
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Cabina] ON
GO
INSERT INTO [Cabina] ([cab_id], [cab_nombre], [cab_precio], [cab_estatus], [cab_fk_crucero]) VALUES (N'1', N'Interior', N'90', N'activo', N'1'), (N'2', N'Oceanview', N'80', N'activo', N'1'), (N'3', N'Suites', N'90', N'activo', N'1'), (N'4', N'Suites Lujo', N'80', N'activo', N'1'), (N'5', N'Interior', N'80', N'inactivo', N'2'), (N'6', N'Oceanview', N'100', N'inactivo', N'2'), (N'7', N'Suites', N'90', N'inactivo', N'2'), (N'8', N'Suites Lujo', N'60', N'inactivo', N'2'), (N'9', N'Interior', N'60', N'activo', N'3'), (N'10', N'Oceanview', N'50', N'activo', N'3'), (N'11', N'Suites', N'80', N'activo', N'3'), (N'12', N'Suites Lujo', N'80', N'inactivo', N'3'), (N'13', N'Interior', N'90', N'inactivo', N'4'), (N'14', N'Oceanview', N'80', N'inactivo', N'4'), (N'15', N'Suites', N'50', N'activo', N'4'), (N'16', N'Suites Lujo', N'60', N'activo', N'4'), (N'17', N'Oceanview', N'100', N'inactivo', N'5'), (N'18', N'Suites', N'90', N'inactivo', N'5'), (N'19', N'Suites Lujo', N'60', N'activo', N'5'), (N'20', N'Interior', N'50', N'activo', N'6'), (N'21', N'Oceanview', N'80', N'activo', N'6'), (N'22', N'Suites', N'100', N'activo', N'6'), (N'23', N'Suites Lujo', N'80', N'activo', N'6'), (N'24', N'Interior', N'50', N'inactivo', N'7'), (N'25', N'Oceanview', N'50', N'activo', N'7'), (N'26', N'Suites', N'70', N'activo', N'7'), (N'27', N'Suites Lujo', N'90', N'activo', N'7'), (N'28', N'Interior', N'60', N'activo', N'8'), (N'29', N'Oceanview', N'70', N'activo', N'8'), (N'30', N'Suites', N'90', N'activo', N'8'), (N'31', N'Suites Lujo', N'70', N'activo', N'8'), (N'32', N'Interior', N'60', N'inactivo', N'9'), (N'33', N'Oceanview', N'70', N'inactivo', N'9'), (N'34', N'Suites', N'70', N'inactivo', N'9'), (N'35', N'Suites Lujo', N'80', N'inactivo', N'9'), (N'36', N'Interior', N'90', N'activo', N'10'), (N'37', N'Oceanview', N'100', N'activo', N'10'), (N'38', N'Suites', N'90', N'activo', N'10'), (N'39', N'Suites Lujo', N'80', N'activo', N'10'), (N'40', N'Interior', N'60', N'inactivo', N'11'), (N'41', N'Oceanview', N'60', N'inactivo', N'11'), (N'42', N'Suites', N'60', N'inactivo', N'11'), (N'43', N'Suites Lujo', N'100', N'inactivo', N'11'), (N'44', N'Interior', N'50', N'inactivo', N'12'), (N'45', N'Oceanview', N'80', N'inactivo', N'12'), (N'46', N'Suites', N'70', N'inactivo', N'12'), (N'47', N'Suites Lujo', N'60', N'inactivo', N'12'), (N'48', N'Interior', N'50', N'activo', N'13'), (N'49', N'Oceanview', N'70', N'activo', N'13'), (N'50', N'Suites', N'50', N'activo', N'13'), (N'51', N'Suites Lujo', N'70', N'activo', N'13'), (N'52', N'Interior', N'60', N'activo', N'16'), (N'53', N'Oceanview', N'50', N'activo', N'16'), (N'54', N'Suites', N'50', N'activo', N'16'), (N'55', N'Suites Lujo', N'50', N'activo', N'16'), (N'102', N'Cabina 1', N'100', N'inactivo', N'2'), (N'103', N'cabina explorer', N'100', N'activo', N'3'), (N'104', N'Noruega con vista al', N'120', N'activo', N'16'), (N'105', N'Familiar', N'100', N'activo', N'3'), (N'106', N'Cabina 12', N'120', N'inactivo', N'38'), (N'107', N'Cabina 13', N'120', N'activo', N'38'), (N'108', N'Cabina 14', N'120', N'activo', N'38'), (N'109', N'Exploradora', N'100', N'activo', N'3')
GO
GO
SET IDENTITY_INSERT [Cabina] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Camarote
-- ----------------------------
DROP TABLE [Camarote]
GO
CREATE TABLE [Camarote] (
[cam_id] int NOT NULL IDENTITY(1,1) ,
[cam_cantidad_cama] int NOT NULL ,
[cam_tipo_cama] varchar(20) NOT NULL ,
[cam_estatus] varchar(10) NULL ,
[cam_fk_cabina] int NOT NULL ,
[cam_image] varchar(200) NULL 
)


GO
DBCC CHECKIDENT(N'[Camarote]', RESEED, 153)
GO

-- ----------------------------
-- Records of Camarote
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Camarote] ON
GO
INSERT INTO [Camarote] ([cam_id], [cam_cantidad_cama], [cam_tipo_cama], [cam_estatus], [cam_fk_cabina], [cam_image]) VALUES (N'1', N'1', N'Individual', N'activo', N'1', null), (N'3', N'1', N'Individual', N'activo', N'2', null), (N'4', N'1', N'Doble', N'activo', N'2', null), (N'5', N'1', N'Individual', N'activo', N'3', null), (N'6', N'2', N'Doble', N'activo', N'3', null), (N'7', N'2', N'Individual', N'activo', N'4', null), (N'8', N'1', N'Doble', N'activo', N'4', null), (N'9', N'1', N'Individual', N'inactivo', N'5', null), (N'10', N'1', N'Doble', N'inactivo', N'5', null), (N'11', N'2', N'Individual', N'inactivo', N'6', null), (N'12', N'1', N'Doble', N'inactivo', N'6', null), (N'13', N'2', N'Individual', N'inactivo', N'7', null), (N'14', N'2', N'Doble', N'inactivo', N'7', null), (N'15', N'1', N'Individual', N'inactivo', N'8', null), (N'16', N'1', N'Doble', N'inactivo', N'8', null), (N'17', N'1', N'Individual', N'activo', N'9', null), (N'18', N'2', N'Doble', N'activo', N'9', null), (N'19', N'2', N'Individual', N'activo', N'10', null), (N'20', N'1', N'Doble', N'activo', N'10', null), (N'21', N'1', N'Individual', N'inactivo', N'11', null), (N'22', N'1', N'Doble', N'activo', N'11', null), (N'23', N'2', N'Individual', N'inactivo', N'12', null), (N'24', N'2', N'Doble', N'inactivo', N'12', null), (N'25', N'1', N'Individual', N'inactivo', N'13', null), (N'26', N'2', N'Doble', N'inactivo', N'13', null), (N'27', N'2', N'Individual', N'inactivo', N'14', null), (N'28', N'1', N'Doble', N'inactivo', N'14', null), (N'29', N'1', N'Individual', N'activo', N'15', null), (N'30', N'1', N'Doble', N'inactivo', N'15', null), (N'31', N'2', N'Individual', N'activo', N'16', null), (N'32', N'2', N'Doble', N'activo', N'16', null), (N'33', N'1', N'Individual', N'inactivo', N'17', null), (N'34', N'2', N'Doble', N'inactivo', N'17', null), (N'35', N'2', N'Individual', N'inactivo', N'18', null), (N'36', N'2', N'Doble', N'inactivo', N'18', null), (N'37', N'1', N'Individual', N'inactivo', N'19', null), (N'38', N'2', N'Doble', N'activo', N'19', null), (N'39', N'1', N'Individual', N'activo', N'20', null), (N'40', N'2', N'Doble', N'inactivo', N'20', null), (N'41', N'1', N'Individual', N'activo', N'21', null), (N'42', N'2', N'Doble', N'activo', N'21', null), (N'43', N'2', N'Individual', N'activo', N'22', null), (N'44', N'1', N'Doble', N'inactivo', N'22', null), (N'45', N'1', N'Individual', N'inactivo', N'23', null), (N'46', N'2', N'Doble', N'inactivo', N'23', null), (N'47', N'2', N'Individual', N'inactivo', N'24', null), (N'48', N'1', N'Doble', N'inactivo', N'24', null), (N'49', N'1', N'Individual', N'activo', N'25', null), (N'50', N'1', N'Doble', N'activo', N'25', null), (N'51', N'1', N'Individual', N'inactivo', N'26', null), (N'52', N'2', N'Doble', N'activo', N'26', null), (N'53', N'2', N'Individual', N'activo', N'27', null), (N'54', N'2', N'Doble', N'activo', N'27', null), (N'55', N'2', N'Individual', N'activo', N'28', null), (N'56', N'1', N'Doble', N'activo', N'28', null), (N'57', N'2', N'Individual', N'activo', N'29', null), (N'58', N'1', N'Doble', N'activo', N'29', null), (N'59', N'2', N'Individual', N'inactivo', N'30', null), (N'60', N'2', N'Doble', N'inactivo', N'30', null), (N'61', N'2', N'Individual', N'activo', N'31', null), (N'62', N'1', N'Doble', N'activo', N'31', null), (N'63', N'1', N'Individual', N'activo', N'32', null), (N'64', N'2', N'Doble', N'activo', N'32', null), (N'65', N'2', N'Individual', N'activo', N'33', null), (N'66', N'1', N'Doble', N'activo', N'33', null), (N'67', N'2', N'Individual', N'activo', N'34', null), (N'68', N'1', N'Doble', N'activo', N'34', null), (N'69', N'1', N'Individual', N'activo', N'35', null), (N'70', N'2', N'Doble', N'inactivo', N'35', null), (N'71', N'2', N'Individual', N'activo', N'36', null), (N'72', N'2', N'Doble', N'activo', N'36', null), (N'73', N'1', N'Individual', N'activo', N'37', null), (N'74', N'1', N'Doble', N'activo', N'37', null), (N'75', N'2', N'Individual', N'activo', N'38', null), (N'76', N'1', N'Doble', N'activo', N'38', null), (N'77', N'2', N'Individual', N'activo', N'39', null), (N'78', N'2', N'Doble', N'activo', N'39', null), (N'79', N'1', N'Individual', N'inactivo', N'40', null), (N'80', N'2', N'Doble', N'activo', N'40', null), (N'81', N'2', N'Individual', N'activo', N'41', null), (N'82', N'2', N'Doble', N'activo', N'41', null), (N'83', N'2', N'Individual', N'inactivo', N'42', null), (N'84', N'1', N'Doble', N'activo', N'42', null), (N'85', N'2', N'Individual', N'activo', N'43', null), (N'86', N'2', N'Doble', N'inactivo', N'43', null), (N'87', N'1', N'Individual', N'activo', N'44', null), (N'88', N'1', N'Doble', N'activo', N'44', null), (N'89', N'2', N'Individual', N'activo', N'45', null), (N'90', N'1', N'Doble', N'inactivo', N'45', null), (N'91', N'2', N'Individual', N'activo', N'46', null), (N'92', N'1', N'Doble', N'activo', N'46', null), (N'93', N'1', N'Individual', N'activo', N'47', null), (N'94', N'2', N'Doble', N'inactivo', N'47', null), (N'95', N'2', N'Individual', N'activo', N'48', null), (N'96', N'2', N'Doble', N'activo', N'48', null), (N'97', N'2', N'Individual', N'activo', N'49', null), (N'98', N'2', N'Doble', N'activo', N'49', null), (N'99', N'1', N'Individual', N'activo', N'50', null), (N'100', N'1', N'Doble', N'inactivo', N'50', null), (N'101', N'2', N'Individual', N'activo', N'51', null)
GO
GO
INSERT INTO [Camarote] ([cam_id], [cam_cantidad_cama], [cam_tipo_cama], [cam_estatus], [cam_fk_cabina], [cam_image]) VALUES (N'102', N'1', N'Doble', N'activo', N'51', null), (N'103', N'1', N'Individual', N'activo', N'52', null), (N'104', N'1', N'Doble', N'inactivo', N'52', null), (N'105', N'2', N'Individual', N'inactivo', N'53', null), (N'106', N'1', N'Doble', N'inactivo', N'53', null), (N'107', N'1', N'Individual', N'activo', N'54', null), (N'108', N'1', N'Doble', N'activo', N'54', null), (N'109', N'1', N'Individual', N'activo', N'55', null), (N'110', N'1', N'Doble', N'activo', N'55', null), (N'150', N'2', N'Individual', N'activo', N'103', null), (N'151', N'1', N'Matrimonial', N'activo', N'103', null), (N'152', N'2', N'Individual', N'activo', N'11', null), (N'153', N'2', N'Matrimonial', N'activo', N'22', null)
GO
GO
SET IDENTITY_INSERT [Camarote] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Comida
-- ----------------------------
DROP TABLE [Comida]
GO
CREATE TABLE [Comida] (
[com_id] int NOT NULL IDENTITY(1,1) ,
[com_nombre] varchar(100) NULL ,
[com_tipo] varchar(100) NULL ,
[com_estatus] int NULL ,
[com_referencia] varchar(100) NULL 
)


GO
DBCC CHECKIDENT(N'[Comida]', RESEED, 18)
GO

-- ----------------------------
-- Records of Comida
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Comida] ON
GO
INSERT INTO [Comida] ([com_id], [com_nombre], [com_tipo], [com_estatus], [com_referencia]) VALUES (N'1', N'Pasta con albondigas', N'Comida', N'1', N' Pasta con 2 bolas de carne'), (N'2', N'Pasta carbonara', N'Comida', N'0', N' Pasta con salsa blanca y tocineta'), (N'3', N'Arroz con pollo', N'Comida', N'1', N' Arroz con trozos de pollo'), (N'4', N'Agua Mineral', N'Bebida', N'1', N' Botella de agua mineral'), (N'5', N'Pasticho', N'Comida', N'0', N' Pasticho de carne'), (N'6', N'Batido de Fresa', N'Bebida', N'1', N' Jugo de fresa natural'), (N'7', N'Club House', N'Comida', N'1', N' Sandwich de pollo con papas fritas'), (N'8', N'Pasta Marinera', N'Comida', N'1', N' Pasta con salsa de maricos'), (N'9', N'Batido de lechosa', N'Bebida', N'1', N' Jugo de lechosa natural'), (N'10', N'Carne con Papas', N'Comida', N'1', N' Carnes con papas')
GO
GO
SET IDENTITY_INSERT [Comida] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Comida_Vuelo
-- ----------------------------
DROP TABLE [Comida_Vuelo]
GO
CREATE TABLE [Comida_Vuelo] (
[com_vue_id] int NOT NULL IDENTITY(1,1) ,
[com_vue_fk_vuelo] int NULL ,
[com_vue_fk_comida] int NULL ,
[com_vue_cantidad] int NULL 
)


GO
DBCC CHECKIDENT(N'[Comida_Vuelo]', RESEED, 3)
GO

-- ----------------------------
-- Records of Comida_Vuelo
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Comida_Vuelo] ON
GO
INSERT INTO [Comida_Vuelo] ([com_vue_id], [com_vue_fk_vuelo], [com_vue_fk_comida], [com_vue_cantidad]) VALUES (N'3', N'6', N'1', N'100')
GO
GO
SET IDENTITY_INSERT [Comida_Vuelo] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Crucero
-- ----------------------------
DROP TABLE [Crucero]
GO
CREATE TABLE [Crucero] (
[cru_id] int NOT NULL IDENTITY(1,1) ,
[cru_nombre] varchar(20) NOT NULL ,
[cru_compania] varchar(20) NULL ,
[cru_capacidad] int NOT NULL ,
[cru_estatus] varchar(10) NULL ,
[cru_image] varchar(200) NULL 
)


GO
DBCC CHECKIDENT(N'[Crucero]', RESEED, 38)
GO

-- ----------------------------
-- Records of Crucero
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Crucero] ON
GO
INSERT INTO [Crucero] ([cru_id], [cru_nombre], [cru_compania], [cru_capacidad], [cru_estatus], [cru_image]) VALUES (N'1', N'MSC Preziosa', N'MSC Cruceros', N'1000', N'activo', null), (N'2', N'Soveregn', N'Pullmantur', N'2200', N'inactivo', null), (N'3', N'Explorer Of The Seas', N'Royal Caribbean', N'2700', N'activo', null), (N'4', N'Celebrity Reflection', N'Celebrity Cruises', N'900', N'activo', null), (N'5', N'Norwegian Sun', N'NCL', N'900', N'activo', null), (N'6', N'MSC Divina', N'MSC Cruceros', N'1100', N'activo', null), (N'7', N'Zenith', N'Pullmantur', N'1100', N'activo', null), (N'8', N'Oasis Of The Seas', N'Royal Caribbean', N'2700', N'activo', null), (N'9', N'Celebrity Solstice', N'Celebrity Cruises', N'1000', N'inactivo', null), (N'10', N'Norwegian Getaway', N'NCL', N'1000', N'activo', null), (N'11', N'MSC Fantasía', N'MSC Cruceros', N'1637', N'inactivo', null), (N'12', N'Monarch', N'Pullmantur', N'1200', N'inactivo', null), (N'13', N'Allure of the Seas', N'Royal Caribbean', N'2460', N'activo', null), (N'16', N'Norwegian Epic', N'NCL', N'900', N'activo', null), (N'33', N'crucero 1', N'compania 1', N'777', N'inactivo', N'url'), (N'34', N'ddd', N'dddd', N'3333', N'activo', N'url'), (N'35', N'crucero modificado', N'modificada', N'10', N'activo', N''), (N'36', N'bestti22', N'royas22', N'3200', N'inactivo', N'url'), (N'37', N'hola11', N'11', N'1111', N'activo', N''), (N'38', N'Crucero 12', N'Crucero 12', N'1222', N'activo', N'')
GO
GO
SET IDENTITY_INSERT [Crucero] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Diario_Puntuacion
-- ----------------------------
DROP TABLE [Diario_Puntuacion]
GO
CREATE TABLE [Diario_Puntuacion] (
[id_diar_punt] int NOT NULL IDENTITY(1,1) ,
[fk_pun_id] int NOT NULL ,
[fk_usu_id] int NOT NULL ,
[fk_dia_id] int NOT NULL 
)


GO

-- ----------------------------
-- Records of Diario_Puntuacion
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Diario_Puntuacion] ON
GO
SET IDENTITY_INSERT [Diario_Puntuacion] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Diario_Viaje
-- ----------------------------
DROP TABLE [Diario_Viaje]
GO
CREATE TABLE [Diario_Viaje] (
[id_diar] int NOT NULL IDENTITY(1,1) ,
[nombre_diario] varchar(100) NULL ,
[fecha_ini_diar] date NOT NULL ,
[descripcion_diar] varchar(4000) NOT NULL ,
[fecha_carga_diar] date NOT NULL ,
[calif_creador] int NOT NULL ,
[rating] int NOT NULL ,
[num_visita] int NOT NULL ,
[fk_usuario_id] int NOT NULL ,
[fecha_fin_diar] date NOT NULL ,
[fk_destino] int NULL 
)


GO
DBCC CHECKIDENT(N'[Diario_Viaje]', RESEED, 184)
GO

-- ----------------------------
-- Records of Diario_Viaje
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Diario_Viaje] ON
GO
INSERT INTO [Diario_Viaje] ([id_diar], [nombre_diario], [fecha_ini_diar], [descripcion_diar], [fecha_carga_diar], [calif_creador], [rating], [num_visita], [fk_usuario_id], [fecha_fin_diar], [fk_destino]) VALUES (N'9', N'Viajando por Los Roques', N'2015-05-12', N'Algo', N'2015-06-02', N'4', N'35', N'356', N'10', N'2015-05-30', N'11'), (N'10', N'Adoro la paella', N'2016-02-13', N'Paella Valenciana', N'2016-02-28', N'5', N'45', N'584', N'11', N'2016-02-27', N'29'), (N'11', N'Konichiwa', N'2016-07-09', N'Japón y esas cosas... Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...Japón y esas cosas...', N'2016-08-10', N'4', N'47', N'314', N'12', N'2016-08-10', N'106'), (N'14', N'La Santa Sede', N'2016-11-01', N'Coliseo, bla bla bla, Torre de Pisa, bla bla bla, Venecia, bla bla bla, El Vaticano, bla bla bla, Francisco, bla bla bla, Pasta, bla bla bla', N'2016-11-20', N'3', N'24', N'123', N'10', N'2016-11-18', N'43'), (N'124', N'Ole Ole Ole...', N'2013-01-29', N'In sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.

Suspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.

Maecenas ut massa quis augue luctus tincidunt. Nulla mollis molestie lorem. Quisque ut erat.', N'2013-03-09', N'1', N'4992', N'824', N'10', N'2013-02-19', N'55'), (N'125', N'Monumentos GENIALES!', N'2006-11-18', N'Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui.', N'2007-02-06', N'3', N'4911', N'404', N'10', N'2006-12-29', N'32'), (N'126', N'Cuando se va el sol empieza la Fiesta!', N'2011-07-05', N'Morbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis.', N'2011-09-05', N'3', N'3546', N'106', N'10', N'2011-07-30', N'48'), (N'127', N'Ole Ole Ole...', N'2010-11-26', N'Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.

Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros.', N'2011-01-11', N'3', N'3538', N'177', N'11', N'2011-01-09', N'34'), (N'128', N'Monumentos GENIALES!', N'2013-02-17', N'Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.

Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros.

Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.', N'2013-04-19', N'4', N'3267', N'338', N'10', N'2013-04-18', N'57'), (N'129', N'Monumentos GENIALES!', N'2014-09-08', N'Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.

Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.', N'2014-11-10', N'2', N'3872', N'59', N'11', N'2014-11-02', N'59'), (N'130', N'Ole Ole Ole...', N'2016-02-12', N'Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum.

Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.

Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.', N'2016-04-20', N'2', N'4353', N'777', N'10', N'2016-03-26', N'31'), (N'131', N'La mejor experiencia para la familia', N'2013-06-22', N'Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis. Ut at dolor quis odio consequat varius.

Integer ac leo. Pellentesque ultrices mattis odio. Donec vitae nisi.

Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.', N'2013-08-16', N'2', N'2427', N'151', N'12', N'2013-08-01', N'27'), (N'132', N'Carnavales Impresionantes', N'2011-07-29', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus.

Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.

Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus.', N'2011-08-13', N'1', N'1436', N'865', N'10', N'2011-08-05', N'12'), (N'133', N'Monumentos GENIALES!', N'2009-07-11', N'Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.

Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus.

Phasellus in felis. Donec semper sapien a libero. Nam dui.', N'2009-08-19', N'0', N'3715', N'189', N'11', N'2009-08-05', N'40'), (N'134', N'Un hermoso paraiso', N'2012-08-05', N'Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.', N'2012-11-04', N'0', N'2688', N'141', N'12', N'2012-10-02', N'52'), (N'135', N'La mejor experiencia para la familia', N'2011-11-16', N'Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.', N'2011-12-16', N'2', N'3939', N'260', N'10', N'2011-12-07', N'25'), (N'136', N'La mejor experiencia para la familia', N'2012-05-26', N'In hac habitasse platea dictumst. Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante. Nulla justo.

Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros. Suspendisse accumsan tortor quis turpis.

Sed ante. Vivamus tortor. Duis mattis egestas metus.', N'2012-07-26', N'0', N'2678', N'727', N'12', N'2012-07-12', N'56'), (N'137', N'La mejor experiencia para la familia', N'2013-01-21', N'Morbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem.', N'2013-03-02', N'5', N'2952', N'777', N'11', N'2013-02-09', N'17'), (N'138', N'Ole Ole Ole...', N'2008-12-13', N'In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.', N'2009-01-22', N'0', N'4434', N'785', N'10', N'2008-12-30', N'26'), (N'139', N'Un gran viaje de Compras', N'2012-03-23', N'Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.', N'2012-04-27', N'5', N'1878', N'765', N'11', N'2012-04-20', N'22'), (N'140', N'Monumentos GENIALES!', N'2011-10-22', N'Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.

Curabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.

Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum.', N'2011-11-03', N'0', N'1384', N'440', N'12', N'2011-11-01', N'44'), (N'141', N'La mejor experiencia para la familia', N'2009-02-28', N'In sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.', N'2009-04-28', N'4', N'4648', N'91', N'10', N'2009-03-24', N'41'), (N'142', N'Bailar Bailar y Bailar', N'2014-05-30', N'Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.

Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus.', N'2014-07-10', N'4', N'3697', N'202', N'11', N'2014-06-15', N'38'), (N'143', N'Un gran viaje de Compras', N'2010-01-17', N'Curabitur at ipsum ac tellus semper interdum. Mauris ullamcorper purus sit amet nulla. Quisque arcu libero, rutrum ac, lobortis vel, dapibus at, diam.', N'2010-03-22', N'5', N'2094', N'587', N'12', N'2010-03-07', N'57'), (N'144', N'Un gran viaje de Compras', N'2009-06-28', N'Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.', N'2009-07-11', N'2', N'4773', N'855', N'10', N'2009-07-07', N'13'), (N'145', N'Un gran viaje de Compras', N'2013-08-10', N'Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum.

In hac habitasse platea dictumst. Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante. Nulla justo.', N'2013-10-25', N'3', N'2368', N'849', N'12', N'2013-10-07', N'46'), (N'146', N'Monumentos GENIALES!', N'2014-12-10', N'Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.

Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.', N'2015-01-07', N'3', N'2151', N'302', N'11', N'2014-12-24', N'46'), (N'147', N'Monumentos GENIALES!', N'2007-05-18', N'Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.', N'2007-07-04', N'2', N'3893', N'649', N'10', N'2007-06-23', N'25'), (N'148', N'Cuando se va el sol empieza la Fiesta!', N'2012-03-03', N'Fusce consequat. Nulla nisl. Nunc nisl.

Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum.

In hac habitasse platea dictumst. Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante. Nulla justo.', N'2012-04-03', N'2', N'1195', N'673', N'11', N'2012-03-24', N'13'), (N'149', N'Un hermoso paraiso', N'2015-12-06', N'Fusce consequat. Nulla nisl. Nunc nisl.', N'2016-01-28', N'0', N'642', N'969', N'12', N'2016-01-18', N'41'), (N'150', N'La mejor experiencia para la familia', N'2009-01-21', N'Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.

Proin interdum mauris non ligula pellentesque ultrices. Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl.', N'2009-02-19', N'4', N'3429', N'21', N'10', N'2009-02-10', N'16'), (N'151', N'Un gran viaje de Compras', N'2011-09-24', N'Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus.

Phasellus in felis. Donec semper sapien a libero. Nam dui.

Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis. Ut at dolor quis odio consequat varius.', N'2011-11-18', N'4', N'1606', N'337', N'11', N'2011-10-13', N'40'), (N'152', N'Carnavales Impresionantes', N'2015-02-23', N'Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.', N'2015-04-06', N'5', N'3237', N'510', N'12', N'2015-03-29', N'46'), (N'153', N'Cuando se va el sol empieza la Fiesta!', N'2008-05-15', N'Maecenas ut massa quis augue luctus tincidunt. Nulla mollis molestie lorem. Quisque ut erat.

Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.', N'2008-08-10', N'3', N'1891', N'971', N'19', N'2008-07-09', N'32'), (N'154', N'Ole Ole Ole...', N'2013-02-10', N'In hac habitasse platea dictumst. Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante. Nulla justo.

Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros. Suspendisse accumsan tortor quis turpis.', N'2013-04-06', N'3', N'580', N'586', N'21', N'2013-04-03', N'28'), (N'155', N'Ole Ole Ole...', N'2014-12-29', N'In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet.

Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui.

Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam. Suspendisse potenti.', N'2015-02-21', N'4', N'1533', N'168', N'19', N'2015-01-16', N'40'), (N'156', N'Carnavales Impresionantes', N'2011-06-11', N'Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.', N'2011-08-27', N'4', N'53', N'910', N'10', N'2011-08-10', N'41'), (N'157', N'Monumentos GENIALES!', N'2009-12-30', N'Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.

Proin interdum mauris non ligula pellentesque ultrices. Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl.

Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.', N'2010-02-21', N'3', N'2348', N'326', N'11', N'2010-01-23', N'15'), (N'158', N'Bailar Bailar y Bailar', N'2007-05-20', N'Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.', N'2007-07-22', N'1', N'4713', N'413', N'12', N'2007-07-05', N'25'), (N'159', N'Un hermoso paraiso', N'2013-11-07', N'Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam. Suspendisse potenti.

Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.

Morbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis.', N'2014-01-17', N'1', N'2381', N'243', N'12', N'2013-12-19', N'41'), (N'160', N'Monumentos GENIALES!', N'2010-04-12', N'Integer ac leo. Pellentesque ultrices mattis odio. Donec vitae nisi.

Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.', N'2010-05-04', N'1', N'1252', N'628', N'11', N'2010-05-02', N'33'), (N'161', N'Monumentos GENIALES!', N'2014-05-27', N'Sed ante. Vivamus tortor. Duis mattis egestas metus.', N'2014-08-11', N'4', N'-60', N'605', N'10', N'2014-07-10', N'17'), (N'162', N'Monumentos GENIALES!', N'2007-11-03', N'Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.

Morbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis.', N'2008-01-10', N'3', N'950', N'681', N'11', N'2008-01-02', N'32'), (N'163', N'Un hermoso paraiso', N'2012-10-29', N'Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.

Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.', N'2012-12-13', N'0', N'2618', N'74', N'19', N'2012-12-03', N'54'), (N'164', N'Un gran viaje de Compras', N'2008-02-08', N'Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus.

Phasellus in felis. Donec semper sapien a libero. Nam dui.

Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis. Ut at dolor quis odio consequat varius.', N'2008-03-12', N'3', N'253', N'553', N'20', N'2008-02-29', N'15'), (N'165', N'Un hermoso paraiso', N'2015-09-20', N'Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.', N'2015-11-11', N'3', N'2089', N'639', N'19', N'2015-10-11', N'39'), (N'166', N'Un gran viaje de Compras', N'2015-05-25', N'In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.

Nulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi.

Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.', N'2015-08-20', N'5', N'504', N'88', N'20', N'2015-07-14', N'35'), (N'167', N'Ole Ole Ole...', N'2008-03-12', N'Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.

Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.

Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.', N'2008-04-17', N'0', N'4429', N'894', N'19', N'2008-04-10', N'37'), (N'168', N'Monumentos GENIALES!', N'2009-12-10', N'Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum.

Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.

Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.', N'2010-01-26', N'1', N'1394', N'860', N'20', N'2009-12-20', N'12'), (N'169', N'Bailar Bailar y Bailar', N'2007-02-19', N'Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.

Etiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.', N'2007-05-19', N'3', N'784', N'661', N'19', N'2007-04-15', N'29'), (N'170', N'Bailar Bailar y Bailar', N'2013-05-18', N'Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.', N'2013-07-17', N'5', N'3663', N'469', N'20', N'2013-06-12', N'21'), (N'171', N'Un hermoso paraiso', N'2015-12-05', N'Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.', N'2016-03-02', N'0', N'1253', N'8', N'19', N'2016-01-26', N'29'), (N'172', N'Monumentos GENIALES!', N'2010-04-15', N'In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet.

Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui.', N'2010-06-19', N'0', N'3145', N'480', N'20', N'2010-05-26', N'46'), (N'173', N'Bailar Bailar y Bailar', N'2006-07-15', N'Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.

Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.

Duis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus.', N'2006-09-05', N'4', N'2513', N'89', N'19', N'2006-08-13', N'14'), (N'178', N'Maravillosa Isla', N'2016-11-25', N'Margarita es excelente!
Margarita es excelente!
Margarita es excelente!
Margarita es excelente!
Margarita es excelente!
Margarita es excelente!
Margarita es excelente!', N'2016-12-14', N'4', N'1', N'1', N'11', N'2016-12-14', N'11'), (N'179', N'NUEVOS DESTINOS', N'2016-11-20', N'Mi viaje fue magnífico!', N'2016-12-14', N'5', N'0', N'0', N'11', N'2016-12-05', N'24'), (N'180', N'Vista del Empire State', N'2016-10-05', N'Manhattan es muy movida!', N'2016-12-14', N'2', N'0', N'0', N'11', N'2016-11-10', N'22'), (N'181', N'Titulo del Diario de Prueba 1', N'2016-10-12', N'Descripcion de la prueba 1', N'2016-12-15', N'4', N'0', N'0', N'11', N'2016-10-19', N'24'), (N'182', N'Titulo del Diario de Prueba 1', N'2016-10-12', N'Descripcion de la prueba 1', N'2016-12-14', N'4', N'0', N'0', N'11', N'2016-10-19', N'24'), (N'183', N'Titulo del Diario de Prueba 1', N'2016-10-12', N'Descripcion de la prueba 1', N'2016-12-14', N'4', N'0', N'0', N'11', N'2016-10-19', N'24'), (N'184', N'Titulo del Diario de Prueba 1', N'2016-10-12', N'Descripcion de la prueba 1', N'2016-12-14', N'4', N'0', N'0', N'11', N'2016-10-19', N'24')
GO
GO
SET IDENTITY_INSERT [Diario_Viaje] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Equipaje
-- ----------------------------
DROP TABLE [Equipaje]
GO
CREATE TABLE [Equipaje] (
[equ_id] int NOT NULL IDENTITY(1,1) ,
[equ_peso] int NULL ,
[equ_fk_pase_abordaje] int NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Equipaje]', RESEED, 14)
GO

-- ----------------------------
-- Records of Equipaje
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Equipaje] ON
GO
INSERT INTO [Equipaje] ([equ_id], [equ_peso], [equ_fk_pase_abordaje]) VALUES (N'1', N'25', N'4'), (N'2', N'12', N'4'), (N'4', N'1', N'5'), (N'5', N'2', N'5'), (N'7', N'25', N'6'), (N'8', N'43', N'6'), (N'11', N'12', N'22'), (N'12', N'14', N'22'), (N'13', N'15', N'23'), (N'14', N'15', N'23')
GO
GO
SET IDENTITY_INSERT [Equipaje] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Foto
-- ----------------------------
DROP TABLE [Foto]
GO
CREATE TABLE [Foto] (
[id_foto] int NOT NULL IDENTITY(1,1) ,
[nombre_foto] varchar(1) NOT NULL ,
[dato] image NOT NULL ,
[fk_usuario] int NOT NULL ,
[fk_diario] int NULL 
)


GO

-- ----------------------------
-- Records of Foto
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Foto] ON
GO
SET IDENTITY_INSERT [Foto] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Hotel
-- ----------------------------
DROP TABLE [Hotel]
GO
CREATE TABLE [Hotel] (
[hot_id] int NOT NULL ,
[hot_nombre] varchar(60) NOT NULL ,
[hot_url_pagina] varchar(150) NULL ,
[hot_email] varchar(100) NULL ,
[hot_cantidad_habitaciones] int NULL ,
[hot_fk_ciudad] int NULL ,
[hot_direccion] varchar(250) NULL ,
[hot_estrellas] int NULL ,
[hot_puntuacion] real NULL ,
[hot_disponibilidad] int NULL 
)


GO

-- ----------------------------
-- Records of Hotel
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [Hotel] ([hot_id], [hot_nombre], [hot_url_pagina], [hot_email], [hot_cantidad_habitaciones], [hot_fk_ciudad], [hot_direccion], [hot_estrellas], [hot_puntuacion], [hot_disponibilidad]) VALUES (N'1', N'hotel prueba', N'www.google.com.ve', N'www.testhotel.com', N'10', N'12', N'Calle A', N'5', N'0', N'1'), (N'2', N'hotel prueba2', N'www.gmail.com', N'www.testhotel2.com', N'10', N'12', N'Calle B', N'4', N'0', N'0'), (N'3', N'NombrePrueba', N'www.prueba.com', N'prueba@email.com', N'65', N'15', N'Calle Prueba', N'3', N'0', N'0'), (N'4', N'Sheraton Macuto Resort', N'No Aplica', N'sheraton@gmail.com', N'100', N'20', N'Los Cocos ', N'1', N'0', N'1'), (N'5', N'Gran Melia Caracas', N'https://www.melia.com/es/hoteles/venezuela', N'Gran.Melia.Caracas.Reservaciones@melia.com', N'430', N'12', N'Av. Casanova, esq calle El Recreo', N'5', N'0', N'1'), (N'6', N'Eurobuilding Caracas', N'https://www.hoteleuro.com', N'reservas@hoteleuro.com', N'619', N'12', N'Final Calle La Guairita', N'5', N'0', N'1'), (N'7', N'Grand Hotel Centra', N'http://www.grandhotelcentral.com', N'info@grandhotelcentral.com ', N'147', N'26', N'Via Laietana 30, 08003', N'5', N'0', N'1'), (N'8', N'Hilton Bogotá', N'http://www3.hilton.com/en/hotels/colombia/hilton-bogota-BOGBCHH/index.html', N'bogota.reservations@hilton.com', N'245', N'100', N'Carrera 7, 72-41 11001000', N'5', N'0', N'1'), (N'9', N'Mayoral', N'www.hotelmayoral.com', N'hotel@mayoral.com', N'60', N'15', N'Calle C', N'4', N'0', N'1')
GO
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Itinerario_Crucero
-- ----------------------------
DROP TABLE [Itinerario_Crucero]
GO
CREATE TABLE [Itinerario_Crucero] (
[icru_fecha_inicio] date NOT NULL ,
[icru_fecha_fin] date NOT NULL ,
[icru_estatus] varchar(10) NULL ,
[icru_fk_crucero] int NOT NULL ,
[icru_fk_ruta] int NOT NULL 
)


GO

-- ----------------------------
-- Records of Itinerario_Crucero
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [Itinerario_Crucero] ([icru_fecha_inicio], [icru_fecha_fin], [icru_estatus], [icru_fk_crucero], [icru_fk_ruta]) VALUES (N'2016-12-03', N'2016-12-10', N'activo', N'1', N'28'), (N'2016-12-04', N'2016-12-17', N'activo', N'3', N'30'), (N'2016-12-09', N'2016-12-25', N'activo', N'4', N'30'), (N'2016-12-10', N'2016-12-31', N'activo', N'1', N'30'), (N'2016-12-10', N'2016-12-18', N'activo', N'2', N'29'), (N'2016-12-10', N'2017-01-07', N'activo', N'5', N'30'), (N'2016-12-10', N'2016-12-17', N'activo', N'38', N'29'), (N'2016-12-11', N'2016-12-17', N'activo', N'2', N'31'), (N'2016-12-11', N'2016-12-11', N'activo', N'4', N'30'), (N'2016-12-11', N'2016-12-25', N'activo', N'5', N'30'), (N'2016-12-18', N'2016-12-11', N'activo', N'3', N'30'), (N'2016-12-18', N'2016-12-29', N'activo', N'5', N'30'), (N'2016-12-23', N'2016-12-17', N'activo', N'7', N'31'), (N'2016-12-24', N'2017-01-14', N'activo', N'3', N'31'), (N'2016-12-24', N'2017-02-10', N'activo', N'6', N'31'), (N'2016-12-25', N'2017-02-12', N'activo', N'2', N'30'), (N'2016-12-25', N'2016-12-29', N'activo', N'4', N'29'), (N'2017-01-02', N'2017-01-12', N'inactivo', N'12', N'31'), (N'2017-01-12', N'2017-01-22', N'activo', N'13', N'30'), (N'2017-01-28', N'2017-02-07', N'activo', N'4', N'30'), (N'2017-01-30', N'2017-02-09', N'activo', N'5', N'28'), (N'2017-02-01', N'2017-12-01', N'activo', N'12', N'31'), (N'2017-02-05', N'2017-02-15', N'inactivo', N'2', N'29'), (N'2017-02-05', N'2017-04-15', N'activo', N'16', N'29'), (N'2017-02-15', N'2017-02-25', N'activo', N'12', N'31'), (N'2017-02-17', N'2016-12-23', N'activo', N'5', N'30'), (N'2017-03-03', N'2017-03-13', N'activo', N'5', N'29'), (N'2017-03-03', N'2017-03-13', N'activo', N'6', N'30'), (N'2017-03-06', N'2017-03-16', N'activo', N'3', N'30'), (N'2017-03-13', N'2017-03-23', N'inactivo', N'3', N'28'), (N'2017-03-18', N'2017-03-28', N'inactivo', N'2', N'31'), (N'2017-03-25', N'2017-04-04', N'activo', N'1', N'31'), (N'2017-03-26', N'2017-04-05', N'inactivo', N'1', N'29'), (N'2017-04-06', N'2017-04-16', N'activo', N'12', N'28'), (N'2017-04-14', N'2017-11-11', N'activo', N'5', N'31'), (N'2017-04-18', N'2017-04-28', N'activo', N'12', N'29'), (N'2017-04-24', N'2017-05-04', N'activo', N'11', N'30'), (N'2017-04-28', N'2017-05-08', N'activo', N'12', N'29'), (N'2017-05-21', N'2017-05-31', N'inactivo', N'9', N'29'), (N'2017-05-28', N'2017-06-07', N'inactivo', N'2', N'31'), (N'2017-06-16', N'2017-06-26', N'activo', N'3', N'30'), (N'2017-07-05', N'2017-07-15', N'activo', N'5', N'29'), (N'2017-07-08', N'2017-07-18', N'activo', N'1', N'28'), (N'2017-07-08', N'2017-07-18', N'inactivo', N'13', N'31'), (N'2017-07-09', N'2017-07-19', N'activo', N'8', N'30'), (N'2017-07-21', N'2017-07-31', N'activo', N'16', N'28'), (N'2017-07-22', N'2017-08-01', N'inactivo', N'5', N'31'), (N'2017-08-05', N'2017-08-15', N'activo', N'11', N'31'), (N'2017-08-12', N'2017-08-22', N'activo', N'7', N'28'), (N'2017-08-12', N'2017-08-22', N'activo', N'10', N'30'), (N'2017-08-16', N'2017-08-26', N'inactivo', N'13', N'28'), (N'2017-08-28', N'2017-09-15', N'activo', N'34', N'178')
GO
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Itinerario_Vac
-- ----------------------------
DROP TABLE [Itinerario_Vac]
GO
CREATE TABLE [Itinerario_Vac] (
[itiv_id] int NOT NULL IDENTITY(1,1) ,
[itiv_dia] varchar(255) NULL ,
[itiv_actividad] varchar(255) NULL ,
[itiv_fk_boleto] int NULL ,
[itiv_fk_crucero] int NULL 
)


GO
DBCC CHECKIDENT(N'[Itinerario_Vac]', RESEED, 78)
GO

-- ----------------------------
-- Records of Itinerario_Vac
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Itinerario_Vac] ON
GO
SET IDENTITY_INSERT [Itinerario_Vac] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Login
-- ----------------------------
DROP TABLE [Login]
GO
CREATE TABLE [Login] (
[log_id] int NOT NULL IDENTITY(1,1) ,
[log_idusuario] int NULL ,
[log_sesion] bit NULL ,
[log_intentos] int NULL 
)


GO
DBCC CHECKIDENT(N'[Login]', RESEED, 186)
GO

-- ----------------------------
-- Records of Login
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Login] ON
GO
INSERT INTO [Login] ([log_id], [log_idusuario], [log_sesion], [log_intentos]) VALUES (N'170', N'34', N'0', N'0'), (N'171', N'2', N'0', N'0'), (N'172', N'4', N'0', N'0'), (N'174', null, N'0', N'0'), (N'175', N'33', N'0', N'0'), (N'177', N'73', N'0', N'0'), (N'178', N'75', N'0', N'0')
GO
GO
SET IDENTITY_INSERT [Login] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Lugar
-- ----------------------------
DROP TABLE [Lugar]
GO
CREATE TABLE [Lugar] (
[lug_id] int NOT NULL IDENTITY(1,1) ,
[lug_nombre] varchar(50) NOT NULL ,
[lug_tipo_lugar] varchar(50) NOT NULL ,
[lug_zona_horaria] int NULL ,
[lug_FK_lugar_id] int NULL ,
[lug_abreviatura_lugar] varchar(10) NULL 
)


GO
DBCC CHECKIDENT(N'[Lugar]', RESEED, 107)
GO

-- ----------------------------
-- Records of Lugar
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Lugar] ON
GO
INSERT INTO [Lugar] ([lug_id], [lug_nombre], [lug_tipo_lugar], [lug_zona_horaria], [lug_FK_lugar_id], [lug_abreviatura_lugar]) VALUES (N'11', N'Venezuela', N'pais', N'-4', null, N'Vnzla'), (N'12', N'Caracas', N'ciudad', N'-4', N'11', N'ccs'), (N'13', N'Maracaibo', N'ciudad', N'-4', N'11', N'mcbo'), (N'14', N'Barquisimeto', N'ciudad', N'-4', N'11', N'bqto'), (N'15', N'Porlamar', N'ciudad', N'-4', N'11', N'nesp'), (N'16', N'Valencia', N'ciudad', N'-4', N'11', N'val'), (N'17', N'Estados Unidos', N'pais', N'-5', null, N'usa'), (N'18', N'Miami', N'ciudad', N'-5', N'17', N'mia'), (N'19', N'Los Angeles', N'ciudad', N'-8', N'17', N'LA'), (N'20', N'Honolulu', N'ciudad', N'-10', N'17', N'hlu'), (N'21', N'Boston', N'ciudad', N'-10', N'17', N'bos'), (N'22', N'New York', N'ciudad', N'-10', N'17', N'NY'), (N'23', N'España', N'pais', N'1', null, N'Esp'), (N'24', N'Madrid', N'ciudad', N'1', N'23', N'mad'), (N'25', N'Malaga', N'ciudad', N'1', N'23', N'mal'), (N'26', N'Barcelona', N'ciudad', N'1', N'23', N'bar'), (N'27', N'Sevilla', N'ciudad', N'1', N'23', N'sev'), (N'28', N'Pamplona', N'ciudad', N'1', N'23', N'pam'), (N'29', N'Valencia', N'ciudad', N'1', N'23', N'val'), (N'30', N'Bahamas', N'pais', N'-5', null, N'Bah'), (N'31', N'New Providence', N'ciudad', N'-5', N'30', N'npro'), (N'32', N'Freeport', N'ciudad', N'-5', N'30', N'fpor'), (N'33', N'West Grand Bahama', N'ciudad', N'-5', N'30', N'WGB'), (N'34', N'San Salvador', N'ciudad', N'-5', N'30', N'ssal'), (N'35', N'Cat Island', N'ciudad', N'-5', N'30', N'cisl'), (N'36', N'Trinidad y Tobago', N'pais', N'-4', null, N'tto'), (N'37', N'Puerto España', N'ciudad', N'-4', N'36', N'pto esp'), (N'38', N'Chaguaramas', N'ciudad', N'-4', N'36', N'chag'), (N'39', N'Point Fortin', N'ciudad', N'-4', N'36', N'pfor'), (N'40', N'San Fernando', N'ciudad', N'-4', N'36', N'fndo'), (N'41', N'Scaborough', N'ciudad', N'-4', N'36', N'scab'), (N'42', N'Italia', N'pais', N'1', null, N'ita'), (N'43', N'Roma', N'ciudad', N'1', N'42', N'Rom'), (N'44', N'Milan', N'ciudad', N'1', N'42', N'mil'), (N'45', N'Napoles', N'ciudad', N'1', N'42', N'nap'), (N'46', N'Venecia', N'ciudad', N'1', N'42', N'vene'), (N'47', N'Florencia', N'ciudad', N'1', N'42', N'flo'), (N'48', N'Francia', N'pais', N'1', null, N'Fra'), (N'49', N'Paris', N'ciudad', N'1', N'48', N'Par'), (N'50', N'Niza', N'ciudad', N'1', N'48', N'Niz'), (N'51', N'Tours', N'ciudad', N'1', N'48', N'Trs'), (N'52', N'Lyon', N'ciudad', N'1', N'48', N'Lyo'), (N'53', N'Burdeos', N'ciudad', N'1', N'48', N'Burd'), (N'54', N'Portugal', N'pais', N'0', null, N'Port'), (N'55', N'Lisboa', N'ciudad', N'0', N'54', N'Lis'), (N'56', N'Madeira', N'ciudad', N'0', N'54', N'Made'), (N'57', N'Sintra', N'ciudad', N'0', N'54', N'Sin'), (N'58', N'Algarve', N'ciudad', N'0', N'54', N'Alg'), (N'59', N'Oporto', N'ciudad', N'0', N'54', N'Opor'), (N'65', N'Alemania', N'pais', N'1', null, N'Ale'), (N'66', N'Berlin', N'ciudad', N'1', N'65', N'Ber'), (N'67', N'Munich', N'ciudad', N'1', N'65', N'Mun'), (N'68', N'Francfort', N'ciudad', N'1', N'65', N'Frac'), (N'69', N'Hamburgo', N'ciudad', N'1', N'65', N'Ham'), (N'70', N'Dusseldorf', N'ciudad', N'1', N'65', N'Duss'), (N'71', N'Australia', N'pais', N'11', null, N'Aus'), (N'72', N'Sidney', N'ciudad', N'11', N'71', N'Sid'), (N'73', N'Melbourne', N'ciudad', N'11', N'71', N'Mel'), (N'74', N'Caims', N'ciudad', N'11', N'71', N'Cai'), (N'75', N'Perth', N'ciudad', N'11', N'71', N'Per'), (N'76', N'Brisbane', N'ciudad', N'11', N'71', N'Bris'), (N'77', N'Tailandia', N'pais', N'7', null, N'Tai'), (N'79', N'Bangkok', N'ciudad', N'7', N'77', N'Bang'), (N'80', N'Ko Samul', N'ciudad', N'7', N'77', N'Sam'), (N'81', N'Pattaya', N'ciudad', N'7', N'77', N'Patt'), (N'82', N'Chiang Mai', N'ciudad', N'7', N'77', N'Mai'), (N'83', N'Krabi', N'ciudad', N'7', N'77', N'Kra'), (N'84', N'Polinesia Francesa', N'pais', N'1', null, N'Poli'), (N'85', N'Tahiti', N'ciudad', N'1', N'84', N'Tah'), (N'86', N'Bora Bora', N'ciudad', N'1', N'84', N'brb'), (N'87', N'Moorea', N'ciudad', N'1', N'84', N'Moo'), (N'88', N'Papeete', N'ciudad', N'1', N'84', N'Pap'), (N'89', N'Huahine', N'ciudad', N'1', N'84', N'Hua'), (N'90', N'Panama', N'pais', N'-5', null, N'Pnm'), (N'91', N'Ciudad de Panama', N'ciudad', N'-5', N'90', N'Pnm city'), (N'92', N'Puerto Escondido', N'ciudad', N'-5', N'90', N'pto esc'), (N'93', N'Santiago', N'ciudad', N'-5', N'90', N'sant'), (N'94', N'Vista Alegre', N'ciudad', N'-5', N'90', N'vis'), (N'95', N'Colon', N'ciudad', N'-5', N'90', N'colo'), (N'96', N'Curacao', N'pais', N'-4', null, N'cur'), (N'97', N'Willemstad', N'ciudad', N'-4', N'96', N'will'), (N'98', N'Sint Michiel Liber', N'ciudad', N'-4', N'96', N'SML'), (N'99', N'Colombia', N'pais', N'-5', null, N'Col'), (N'100', N'Bogota', N'ciudad', N'-5', N'99', N'Bgt'), (N'101', N'Barranquilla', N'ciudad', N'-5', N'99', N'Bqa'), (N'102', N'Medallin', N'ciudad', N'-5', N'99', N'Mdn'), (N'103', N'Cartegena', N'ciudad', N'-5', N'99', N'Ctga'), (N'104', N'Santa Marta', N'ciudad', N'-5', N'99', N'St Mar'), (N'105', N'Japon', N'pais', N'9', null, N'Jap'), (N'106', N'Tokyo', N'ciudad', N'9', N'105', N'tkyo'), (N'107', N'Kyoto', N'ciudad', N'9', N'105', N'kyo')
GO
GO
SET IDENTITY_INSERT [Lugar] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Modulo_Detallado
-- ----------------------------
DROP TABLE [Modulo_Detallado]
GO
CREATE TABLE [Modulo_Detallado] (
[mod_det_id] int NOT NULL IDENTITY(1,1) ,
[mod_det_nombre] varchar(100) NOT NULL ,
[mod_det_url] varchar(500) NOT NULL ,
[fk_mod_gen_id] int NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Modulo_Detallado]', RESEED, 41)
GO

-- ----------------------------
-- Records of Modulo_Detallado
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Modulo_Detallado] ON
GO
INSERT INTO [Modulo_Detallado] ([mod_det_id], [mod_det_nombre], [mod_det_url], [fk_mod_gen_id]) VALUES (N'6', N'Gestion de aviones', N'/gestion_aviones/M02_GestionAviones', N'2'), (N'7', N'Agregar aviones', N'/gestion_aviones/M02_AgregarAvion', N'2'), (N'8', N'Visualizar aviones', N'/gestion_aviones/M02_VisualizarAviones', N'2'), (N'9', N'Agregar rutas', N'/gestion_ruta_comercial/AgregarRutasComerciales', N'5'), (N'10', N'Visualizar rutas', N'/gestion_ruta_comercial/VisualizarRutasComerciales', N'5'), (N'11', N'Agregar automovil', N'/gestion_automoviles/M08_AgregarAutomovil', N'12'), (N'12', N'Visualizar automovil', N'/gestion_automoviles/M08_VisualizarAutomoviles', N'12'), (N'13', N'Gestion comida', N'/gestion_comida_vuelo/M06_AgregarComida', N'9'), (N'14', N'Editar comida', N'/gestion_comida_vuelo/M06_EditarComida', N'9'), (N'15', N'Gestion comida de vuelo', N'/gestion_comida_vuelo/M06_EditarComida', N'9'), (N'16', N'Crear Hoteles', N'/gestion_hoteles/M09_GestionHoteles_Crear', N'15'), (N'17', N'Ver reserva', N'/gestion_boletos/M05_VerReserva', N'16'), (N'18', N'Agregar ofertas', N'/gestion_ofertas/M11_AgregarOferta', N'13'), (N'19', N'Consultar ofertas', N'/gestion_ofertas/M11_ConsultarOferta', N'13'), (N'20', N'Modificar ofertas', N'/gestion_ofertas/M11_ModificarOferta', N'13'), (N'21', N'Agregar paquete', N'/gestion_ofertas/M11_AgregarPaquete', N'13'), (N'22', N'Modificar paquete', N'/gestion_ofertas/M11_ModificarPaquete', N'13'), (N'23', N'Consultar paquete', N'/gestion_ofertas/M11_ConsultarPaquete', N'13'), (N'24', N'Ver restaurantes', N'/gestion_ofertas/M11_ConsultarPaquete', N'10'), (N'25', N'Gestion restaurantes', N'/gestion_restaurantes/M10_GestionRestaurantes_Agregar', N'10'), (N'26', N'Visualizar boletos', N'/gestion_boletos/M05_VisualizarBoletos', N'7'), (N'27', N'Check in', N'/gestion_check_in/M05_CheckIn', N'7'), (N'29', N'Agregar Rol', N'/gestion_roles/M13_AgregarRol', N'1'), (N'30', N'Visualizar Rol', N'/gestion_roles/M13_VisualizarRol', N'1'), (N'31', N'Crear vuelo', N'/gestion_vuelo/M04_GestionVuelo_Crear', N'6'), (N'32', N'Visualizar Vuelo', N'/gestion_vuelo/M04_GestionVuelo_Visualizar', N'6'), (N'33', N'Crear Boleto', N'/gestion_boletos/M05_VerReserva', N'7'), (N'34', N'Registro equipaje', N'/gestion_check_in/M05_RegistroEquipaje', N'7'), (N'35', N'Gestion equipaje', N'no asignado', N'11'), (N'36', N'Agregar usuario', N'/gestion_usuarios/M12_AgregarUsuario', N'17'), (N'37', N'Visualizar usuario', N'/gestion_usuarios/M12_Index', N'17'), (N'38', N'Visualiza crucero', N'/gestion_cruceros/M24_GestionCruceros', N'14'), (N'39', N'Agregar crucero', N'/gestion_cruceros/M24_GestionCruceros', N'14'), (N'40', N'Agregar cabina', N'/gestion_cruceros/M24_AgregarCabinas', N'14'), (N'41', N'Consultar Hotel', N'/gestion_hoteles/M09_GestionHoteles_Visualizar', N'15')
GO
GO
SET IDENTITY_INSERT [Modulo_Detallado] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Modulo_General
-- ----------------------------
DROP TABLE [Modulo_General]
GO
CREATE TABLE [Modulo_General] (
[mod_gen_id] int NOT NULL IDENTITY(1,1) ,
[mod_gen_nombre] varchar(100) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Modulo_General]', RESEED, 17)
GO

-- ----------------------------
-- Records of Modulo_General
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Modulo_General] ON
GO
INSERT INTO [Modulo_General] ([mod_gen_id], [mod_gen_nombre]) VALUES (N'1', N'Modulo de roles'), (N'2', N'Modulo de aviones'), (N'5', N'Modulo de rutas'), (N'6', N'Modulo de vuelos'), (N'7', N'Modulo de boletos y check-in'), (N'9', N'Modulo de comida'), (N'10', N'Modulo de restaurantes'), (N'11', N'Modulo de equipaje'), (N'12', N'Modulo de automoviles'), (N'13', N'Modulo de ofertas y paquetes'), (N'14', N'Modulo de cruceros'), (N'15', N'Modulo de hoteles'), (N'16', N'Modulo reservas'), (N'17', N'Modulo Usuarios')
GO
GO
SET IDENTITY_INSERT [Modulo_General] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Oferta
-- ----------------------------
DROP TABLE [Oferta]
GO
CREATE TABLE [Oferta] (
[ofe_id] int NOT NULL IDENTITY(1,1) ,
[ofe_nombre] varchar(255) NOT NULL ,
[ofe_fechaInicio] date NOT NULL ,
[ofe_fechaFin] date NOT NULL ,
[ofe_porcentaje] float(53) NOT NULL ,
[ofe_estado] bit NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Oferta]', RESEED, 23)
GO

-- ----------------------------
-- Records of Oferta
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Oferta] ON
GO
INSERT INTO [Oferta] ([ofe_id], [ofe_nombre], [ofe_fechaInicio], [ofe_fechaFin], [ofe_porcentaje], [ofe_estado]) VALUES (N'16', N'Prueba', N'2016-12-09', N'2016-12-10', N'34', N'1'), (N'17', N'Oferta Nueva', N'2016-12-08', N'2016-12-16', N'23', N'1'), (N'18', N'Oferta prueba numero 1', N'2016-12-02', N'2016-12-08', N'23', N'1'), (N'19', N'oferta de prueba numero 2', N'2016-12-01', N'2016-12-02', N'23', N'1'), (N'20', N'oferta especial', N'2016-11-17', N'2016-12-22', N'23', N'1'), (N'21', N'Oferta cambiada', N'1-01-01', N'1-01-01', N'23', N'0'), (N'22', N'er', N'2016-12-07', N'2016-12-08', N'23', N'1'), (N'23', N'Regulo Perez abstengase a la narrativa', N'2016-12-02', N'2016-12-23', N'4', N'0')
GO
GO
SET IDENTITY_INSERT [Oferta] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Paquete
-- ----------------------------
DROP TABLE [Paquete]
GO
CREATE TABLE [Paquete] (
[paq_id] int NOT NULL IDENTITY(1,1) ,
[paq_nombre] varchar(255) NOT NULL ,
[paq_precio] float(53) NOT NULL ,
[paq_fk_oferta] int NULL ,
[paq_fk_automovil] varchar(50) NULL ,
[paq_fk_restaurante] int NULL ,
[paq_fk_hotel] int NULL ,
[paq_fk_crucero] int NULL ,
[paq_fk_vuelo] int NULL ,
[paq_fechaInicio_automovil] date NULL ,
[paq_fechaFin_automovil] date NULL ,
[paq_fechaInicio_restaurante] date NULL ,
[paq_fechaFin_restaurante] date NULL ,
[paq_fechaInicio_hotel] date NULL ,
[paq_fechaFin_hotel] date NULL ,
[paq_fechaInicio_crucero] date NULL ,
[paq_fechaFin_crucero] date NULL ,
[paq_fechaInicio_boleto] date NULL ,
[paq_fechaFin_boleto] date NULL ,
[paq_estado] bit NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Paquete]', RESEED, 22)
GO

-- ----------------------------
-- Records of Paquete
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Paquete] ON
GO
INSERT INTO [Paquete] ([paq_id], [paq_nombre], [paq_precio], [paq_fk_oferta], [paq_fk_automovil], [paq_fk_restaurante], [paq_fk_hotel], [paq_fk_crucero], [paq_fk_vuelo], [paq_fechaInicio_automovil], [paq_fechaFin_automovil], [paq_fechaInicio_restaurante], [paq_fechaFin_restaurante], [paq_fechaInicio_hotel], [paq_fechaFin_hotel], [paq_fechaInicio_crucero], [paq_fechaFin_crucero], [paq_fechaInicio_boleto], [paq_fechaFin_boleto], [paq_estado]) VALUES (N'19', N'Paquete de Navidad', N'23', N'20', N'08B1AOE', null, null, null, null, N'2012-01-02', N'2012-01-03', null, null, null, null, null, null, null, null, N'1'), (N'20', N'Paquete Carro', N'234', N'22', null, null, null, null, N'6', null, null, null, null, null, null, null, null, N'2016-12-07', N'2016-12-16', N'1'), (N'22', N'Hola', N'50', N'23', null, N'3', null, null, null, N'2016-12-02', N'2016-12-22', N'2016-12-03', N'2016-12-21', null, null, null, null, null, null, N'0')
GO
GO
SET IDENTITY_INSERT [Paquete] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Pasajero
-- ----------------------------
DROP TABLE [Pasajero]
GO
CREATE TABLE [Pasajero] (
[pas_id] int NOT NULL ,
[pas_primer_nombre] varchar(50) NOT NULL ,
[pas_segundo_nombre] varchar(50) NULL ,
[pas_primer_apellido] varchar(50) NOT NULL ,
[pas_segundo_apellido] varchar(50) NULL ,
[pas_fecha_nacimiento] date NOT NULL ,
[pas_sexo] varchar(50) NOT NULL ,
[pas_correo] varchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Records of Pasajero
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [Pasajero] ([pas_id], [pas_primer_nombre], [pas_segundo_nombre], [pas_primer_apellido], [pas_segundo_apellido], [pas_fecha_nacimiento], [pas_sexo], [pas_correo]) VALUES (N'312', N'dasdas', N'dasd', N'das', N'dasd', N'1997-01-01', N'Masculino', N'dasasd'), (N'2132', N'eqw', N'eqw', N'eqwe', N'qweeqw', N'1999-01-01', N'Femenino', N'21321@'), (N'12345', N'Lewis', N'Michael', N'Garcia', N'Ronaldo', N'1995-01-01', N'Masculino', N'lewis@hotmail.com'), (N'31233', N'final1', N'final2', N'final3', N'final4', N'1996-12-12', N'Femenino', N'uhu@gmail'), (N'123124', N'prueba1', N'prueba2', N'prueba3', N'prueba4', N'2012-01-01', N'Masculino', N'2131212@'), (N'4444444', N'312213', N'31232', N'312312', N'312', N'1998-02-02', N'Femenino', N'4444@'), (N'4455743', N'Luis', N'Garcia', N'Garcia', N'Luis', N'1956-07-19', N'Masculino', N'hrendon@gmail.com'), (N'11111111', N'juan', N'lionmel', N'jimenez', N'arango', N'1991-01-01', N'Masculino', N'lionel@gmail'), (N'12211212', N'12', N'2112', N'1221', N'12', N'1998-12-12', N'Masculino', N'211221@hotmail.com'), (N'19720982', N'Venecia', N'Nazareth', N'Castillo', N'Zapata', N'1991-11-04', N'Femenino', N'venecia@gmail.com'), (N'22222222', N'Don', N'Andres', N'Iniesta', N'Mascherano', N'1987-02-12', N'Masculino', N'iniesta@hotmail.com'), (N'23642303', N'Jorge', N'daniel', N'socas', N'bischoff', N'1991-12-20', N'Masculino', N'bisch@gmail.com'), (N'24221075', N'Daniel', N'Daniel', N'Rendon', N'Saaaaaaa', N'2012-06-18', N'Masculino', N'danielrendon93@gmail.com'), (N'33333333', N'luis', N'miguel', N'garcia', N'veneri', N'1995-01-01', N'Masculino', N'luis@gmail.com')
GO
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Pase_Abordaje
-- ----------------------------
DROP TABLE [Pase_Abordaje]
GO
CREATE TABLE [Pase_Abordaje] (
[pas_id] int NOT NULL IDENTITY(1,1) ,
[pas_fk_boleto] int NOT NULL ,
[pas_fk_asiento] varchar(20) NULL ,
[pas_fk_lugar_origen] int NOT NULL ,
[pas_fk_lugar_destino] int NOT NULL ,
[pas_fk_vuelo] int NULL 
)


GO
DBCC CHECKIDENT(N'[Pase_Abordaje]', RESEED, 23)
GO

-- ----------------------------
-- Records of Pase_Abordaje
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Pase_Abordaje] ON
GO
INSERT INTO [Pase_Abordaje] ([pas_id], [pas_fk_boleto], [pas_fk_asiento], [pas_fk_lugar_origen], [pas_fk_lugar_destino], [pas_fk_vuelo]) VALUES (N'4', N'9', N'A12', N'12', N'16', N'6'), (N'5', N'10', N'A12', N'16', N'12', N'7'), (N'6', N'10', N'A12', N'12', N'16', N'6'), (N'22', N'64', N'A12', N'16', N'12', N'7'), (N'23', N'66', N'A12', N'12', N'16', N'6')
GO
GO
SET IDENTITY_INSERT [Pase_Abordaje] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Perfil
-- ----------------------------
DROP TABLE [Perfil]
GO
CREATE TABLE [Perfil] (
[per_id] int NOT NULL IDENTITY(1,1) ,
[per_fk_usuario] int NOT NULL ,
[per_genero] varchar(50) NOT NULL ,
[per_fecha_nacimiento] date NOT NULL ,
[per_fk_telefono] int NOT NULL ,
[per_fk_lugar] int NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Perfil]', RESEED, 9)
GO

-- ----------------------------
-- Records of Perfil
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Perfil] ON
GO
INSERT INTO [Perfil] ([per_id], [per_fk_usuario], [per_genero], [per_fecha_nacimiento], [per_fk_telefono], [per_fk_lugar]) VALUES (N'4', N'50', N'Hombre', N'2016-12-14', N'4', N'12'), (N'5', N'51', N'Hombre', N'2016-12-14', N'5', N'12'), (N'6', N'52', N'Hombre', N'2016-12-14', N'6', N'12'), (N'7', N'53', N'Hombre', N'2016-12-14', N'7', N'12'), (N'8', N'54', N'Hombre', N'2016-12-14', N'8', N'12'), (N'9', N'56', N'Hombre', N'2016-12-14', N'9', N'12')
GO
GO
SET IDENTITY_INSERT [Perfil] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Pregunta_Respuesta
-- ----------------------------
DROP TABLE [Pregunta_Respuesta]
GO
CREATE TABLE [Pregunta_Respuesta] (
[pr_id] int NOT NULL IDENTITY(1,1) ,
[pr_value] int NOT NULL ,
[pr_respuesta] varchar(50) NOT NULL ,
[fk_perfil] int NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Pregunta_Respuesta]', RESEED, 15)
GO

-- ----------------------------
-- Records of Pregunta_Respuesta
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Pregunta_Respuesta] ON
GO
INSERT INTO [Pregunta_Respuesta] ([pr_id], [pr_value], [pr_respuesta], [fk_perfil]) VALUES (N'1', N'1', N'pregunta0', N'5'), (N'2', N'4', N'pregunta1', N'5'), (N'3', N'7', N'pregunta2', N'5'), (N'4', N'1', N'pregunta0', N'6'), (N'5', N'4', N'pregunta1', N'6'), (N'6', N'7', N'pregunta2', N'6'), (N'7', N'1', N'madre', N'7'), (N'8', N'4', N'favorita', N'7'), (N'9', N'7', N'madre', N'7'), (N'10', N'1', N'madre', N'8'), (N'11', N'4', N'favorita', N'8'), (N'12', N'7', N'madrea', N'8'), (N'13', N'1', N'madre', N'9'), (N'14', N'4', N'favorita', N'9'), (N'15', N'7', N'madrea', N'9')
GO
GO
SET IDENTITY_INSERT [Pregunta_Respuesta] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Prueba
-- ----------------------------
DROP TABLE [Prueba]
GO
CREATE TABLE [Prueba] (
[ID] int NOT NULL IDENTITY(1,1) ,
[LastName] varchar(255) NOT NULL ,
[FirstName] varchar(255) NULL ,
[Address] varchar(255) NULL ,
[City] varchar(255) NULL 
)


GO

-- ----------------------------
-- Records of Prueba
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Prueba] ON
GO
SET IDENTITY_INSERT [Prueba] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Puntuacion
-- ----------------------------
DROP TABLE [Puntuacion]
GO
CREATE TABLE [Puntuacion] (
[id_punt] int NOT NULL IDENTITY(1,1) ,
[tipo_punt] varchar(1) NOT NULL 
)


GO

-- ----------------------------
-- Records of Puntuacion
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Puntuacion] ON
GO
SET IDENTITY_INSERT [Puntuacion] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Reclamo_Equipaje
-- ----------------------------
DROP TABLE [Reclamo_Equipaje]
GO
CREATE TABLE [Reclamo_Equipaje] (
[rec_id] int NOT NULL ,
[rec_descripcion] varchar(100) NOT NULL ,
[rec_status] varchar(25) NOT NULL ,
[rec_fecha] date NOT NULL ,
[rec_fk_equipaje] int NULL ,
[rec_fk_pasajero] int NULL 
)


GO

-- ----------------------------
-- Records of Reclamo_Equipaje
-- ----------------------------
BEGIN TRANSACTION
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Reserva_Automovil
-- ----------------------------
DROP TABLE [Reserva_Automovil]
GO
CREATE TABLE [Reserva_Automovil] (
[raut_id] int NOT NULL ,
[raut_fecha_ini] varchar(255) NULL ,
[raut_fecha_fin] varchar(255) NULL ,
[raut_hora_ini] varchar(255) NULL ,
[raut_hora_fin] varchar(255) NULL ,
[raut_fk_usuario] int NOT NULL ,
[raut_fk_automovil] varchar(50) NOT NULL ,
[raut_fk_ciudad_devolucion] int NOT NULL ,
[raut_fk_ciudad_entrega] int NOT NULL ,
[raut_estatus] int NOT NULL 
)


GO

-- ----------------------------
-- Records of Reserva_Automovil
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [Reserva_Automovil] ([raut_id], [raut_fecha_ini], [raut_fecha_fin], [raut_hora_ini], [raut_hora_fin], [raut_fk_usuario], [raut_fk_automovil], [raut_fk_ciudad_devolucion], [raut_fk_ciudad_entrega], [raut_estatus]) VALUES (N'1', N'2016-12-11', N'2016-12-12', N'17:00', N'18:00', N'1', N'14DNKVO', N'13', N'13', N'1'), (N'5', N'2016-12-14', N'2016-12-16', N'15:00', N'17:00', N'1', N'6J95JHE', N'12', N'12', N'1'), (N'76', N'2016-12-14', N'2016-12-16', N'15:00', N'17:00', N'1', N'28ZH5GP', N'12', N'12', N'1')
GO
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Reserva_Boleto
-- ----------------------------
DROP TABLE [Reserva_Boleto]
GO
CREATE TABLE [Reserva_Boleto] (
[reb_id] int NOT NULL ,
[reb_fecha_reservado] date NULL ,
[reb_escala] int NULL ,
[reb_ida_vuelta] int NOT NULL ,
[reb_costo] int NOT NULL ,
[reb_codigo] varchar(9) NULL ,
[reb_tipo] varchar(50) NULL ,
[fk_origen] int NULL ,
[fk_destino] int NULL ,
[fk_pas_id] int NULL 
)


GO

-- ----------------------------
-- Records of Reserva_Boleto
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [Reserva_Boleto] ([reb_id], [reb_fecha_reservado], [reb_escala], [reb_ida_vuelta], [reb_costo], [reb_codigo], [reb_tipo], [fk_origen], [fk_destino], [fk_pas_id]) VALUES (N'1', N'2013-08-30', N'1', N'1', N'200', N'111', N'Ejecutivo', N'12', N'16', N'4455743')
GO
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Reserva_Crucero
-- ----------------------------
DROP TABLE [Reserva_Crucero]
GO
CREATE TABLE [Reserva_Crucero] (
[RC_Id] int NOT NULL IDENTITY(1,1) ,
[RC_Fecha] date NULL ,
[RC_Cantidad_Pasajeros] int NULL ,
[FK_Usuario] int NULL ,
[FK_Crucero] int NULL ,
[FK_Ruta] int NULL ,
[FK_Fecha] date NULL ,
[RC_Status] varchar(20) NULL 
)


GO
DBCC CHECKIDENT(N'[Reserva_Crucero]', RESEED, 11)
GO

-- ----------------------------
-- Records of Reserva_Crucero
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Reserva_Crucero] ON
GO
INSERT INTO [Reserva_Crucero] ([RC_Id], [RC_Fecha], [RC_Cantidad_Pasajeros], [FK_Usuario], [FK_Crucero], [FK_Ruta], [FK_Fecha], [RC_Status]) VALUES (N'11', N'2016-12-14', N'22', N'1', N'1', N'31', N'2017-03-25', N'activo')
GO
GO
SET IDENTITY_INSERT [Reserva_Crucero] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Reserva_Habitacion
-- ----------------------------
DROP TABLE [Reserva_Habitacion]
GO
CREATE TABLE [Reserva_Habitacion] (
[rha_fk_hot_id] int NOT NULL ,
[rha_fk_usu_id] int NOT NULL ,
[rha_fecha_llegada] datetime NOT NULL ,
[rha_estado] int NOT NULL ,
[rha_fecha_reservacion] datetime NOT NULL ,
[rha_cantidad_dias] int NOT NULL ,
[rha_habitacion] int NOT NULL ,
[rha_id] int NOT NULL 
)


GO

-- ----------------------------
-- Records of Reserva_Habitacion
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [Reserva_Habitacion] ([rha_fk_hot_id], [rha_fk_usu_id], [rha_fecha_llegada], [rha_estado], [rha_fecha_reservacion], [rha_cantidad_dias], [rha_habitacion], [rha_id]) VALUES (N'1', N'1', N'2016-12-12 00:00:00.000', N'2', N'2016-12-11 09:12:28.967', N'1', N'1', N'37'), (N'1', N'1', N'2016-12-12 00:00:00.000', N'2', N'2016-12-11 09:12:31.490', N'1', N'2', N'38'), (N'1', N'1', N'2016-12-12 00:00:00.000', N'2', N'2016-12-11 09:12:33.257', N'1', N'3', N'39'), (N'1', N'1', N'2016-12-12 00:00:00.000', N'2', N'2016-12-11 09:12:34.960', N'1', N'4', N'40'), (N'1', N'1', N'2016-12-12 00:00:00.000', N'2', N'2016-12-11 09:12:37.170', N'1', N'5', N'41'), (N'1', N'2', N'2016-10-10 00:00:00.000', N'1', N'2016-10-09 08:12:37.530', N'1', N'1', N'42'), (N'2', N'1', N'2016-12-22 00:00:00.000', N'3', N'2016-12-11 11:33:26.230', N'1', N'1', N'43'), (N'1', N'1', N'2016-12-12 00:00:00.000', N'2', N'2016-12-11 16:53:57.377', N'1', N'6', N'44'), (N'2', N'2', N'2016-10-12 00:00:00.000', N'1', N'2016-12-11 14:10:12.987', N'1', N'2', N'45'), (N'1', N'1', N'2016-12-12 00:00:00.000', N'2', N'2016-12-11 19:49:46.523', N'1', N'7', N'46'), (N'1', N'1', N'2016-12-12 00:00:00.000', N'2', N'2016-12-11 19:53:02.750', N'1', N'8', N'47'), (N'1', N'1', N'2016-12-18 00:00:00.000', N'3', N'2016-12-11 19:53:29.177', N'1', N'1', N'48'), (N'1', N'1', N'2016-12-19 00:00:00.000', N'3', N'2016-12-11 20:16:24.883', N'1', N'2', N'49'), (N'6', N'1', N'2016-12-13 00:00:00.000', N'2', N'2016-12-11 22:08:58.897', N'1', N'1', N'50'), (N'6', N'1', N'2016-12-12 00:00:00.000', N'2', N'2016-12-11 22:55:30.720', N'1', N'2', N'51'), (N'1', N'1', N'2016-12-14 00:00:00.000', N'3', N'2016-12-12 23:00:41.463', N'1', N'1', N'52'), (N'5', N'1', N'2016-12-14 00:00:00.000', N'2', N'2016-12-13 02:35:44.197', N'1', N'1', N'53'), (N'5', N'1', N'2016-12-14 00:00:00.000', N'3', N'2016-12-13 02:36:26.833', N'1', N'2', N'54'), (N'5', N'1', N'2016-12-14 00:00:00.000', N'2', N'2016-12-13 02:37:35.510', N'1', N'2', N'55'), (N'6', N'1', N'2016-12-15 00:00:00.000', N'3', N'2016-12-14 14:39:13.460', N'1', N'1', N'56'), (N'6', N'1', N'2016-12-15 00:00:00.000', N'1', N'2016-12-14 14:43:18.913', N'1', N'1', N'57'), (N'6', N'1', N'2016-12-15 00:00:00.000', N'1', N'2016-12-14 14:46:18.410', N'1', N'2', N'58'), (N'6', N'1', N'2016-12-15 00:00:00.000', N'1', N'2016-12-14 14:59:43.460', N'1', N'3', N'59'), (N'7', N'1', N'2016-12-15 00:00:00.000', N'1', N'2016-12-14 16:08:54.260', N'2', N'1', N'60'), (N'7', N'1', N'2016-12-15 00:00:00.000', N'1', N'2016-12-14 16:09:14.413', N'2', N'2', N'61'), (N'6', N'1', N'2016-12-16 00:00:00.000', N'1', N'2016-12-14 17:24:29.670', N'1', N'4', N'62'), (N'8', N'1', N'2016-12-17 00:00:00.000', N'1', N'2016-12-14 20:21:17.157', N'2', N'1', N'63')
GO
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Reserva_Restaurante
-- ----------------------------
DROP TABLE [Reserva_Restaurante]
GO
CREATE TABLE [Reserva_Restaurante] (
[ID] int NOT NULL IDENTITY(1,1) ,
[Reserva_Nombre] varchar(255) NULL ,
[Fecha] date NULL ,
[Hora] varchar(8) NULL ,
[Cantidad_Personas] int NULL ,
[FK_RESTAURANTE] int NULL ,
[FK_USUARIO] int NULL 
)


GO
DBCC CHECKIDENT(N'[Reserva_Restaurante]', RESEED, 100)
GO

-- ----------------------------
-- Records of Reserva_Restaurante
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Reserva_Restaurante] ON
GO
INSERT INTO [Reserva_Restaurante] ([ID], [Reserva_Nombre], [Fecha], [Hora], [Cantidad_Personas], [FK_RESTAURANTE], [FK_USUARIO]) VALUES (N'43', N'ANDREA', N'2016-12-17', N'19:00', N'3', N'3', N'10'), (N'44', N'alexander', N'2016-12-23', N'18:00', N'2', N'1', N'10'), (N'45', N'carlos', N'2016-12-23', N'21:00', N'4', N'3', N'10'), (N'46', N'barbara', N'2016-12-21', N'19:00', N'4', N'3', N'73'), (N'47', N'daniel goncalves', N'2016-12-21', N'21:00', N'2', N'3', N'10'), (N'51', N'dumar figueroa', N'2016-12-15', N'12:00', N'2', N'2', N'10'), (N'53', N'andrea camacho', N'2016-12-31', N'21:00', N'7', N'4', N'10'), (N'54', N'andrea camacho', N'2016-12-31', N'21:00', N'7', N'4', N'73'), (N'62', N'carlos herrera', N'2016-12-29', N'16:00', N'3', N'36', N'10'), (N'64', N'jennifer socorro', N'2016-12-18', N'20:00', N'10', N'36', N'10'), (N'83', N'carlos herrera', N'2016-12-14', N'14:00', N'4', N'1', N'1'), (N'85', N'rodrigo arellano', N'2017-01-19', N'20:00', N'3', null, N'1'), (N'87', N'alexander perez', N'2016-01-01', N'12:00', N'10', N'1', N'1'), (N'88', N'alexander perez', N'2016-01-01', N'12:00', N'10', N'1', N'1'), (N'89', N'carlos herrera', N'2016-12-22', N'16:00', N'6', N'5', N'1'), (N'92', N'Barbara', N'2016-10-12', N'21:00', N'2', N'1', N'73'), (N'93', N'Juan', N'2016-10-12', N'21:00', N'2', N'2', N'73'), (N'94', N'Barb', N'2016-10-10', N'18:00', N'1', N'4', N'73'), (N'95', N'Rodriguez', N'2016-10-10', N'17:00', N'5', N'5', N'73'), (N'96', N'Pereira', N'2016-10-10', N'14:00', N'2', N'36', N'73'), (N'97', N'alexander perez', N'2016-01-01', N'12:00', N'10', N'1', N'1'), (N'100', N'alexander perez', N'2016-01-01', N'12:00', N'10', N'1', N'1')
GO
GO
SET IDENTITY_INSERT [Reserva_Restaurante] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Reserva_Vuelo
-- ----------------------------
DROP TABLE [Reserva_Vuelo]
GO
CREATE TABLE [Reserva_Vuelo] (
[rev_id] int NOT NULL ,
[fk_reb_id] int NULL ,
[fk_vue_id] int NULL 
)


GO

-- ----------------------------
-- Records of Reserva_Vuelo
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [Reserva_Vuelo] ([rev_id], [fk_reb_id], [fk_vue_id]) VALUES (N'1', N'1', N'6')
GO
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Restaurante
-- ----------------------------
DROP TABLE [Restaurante]
GO
CREATE TABLE [Restaurante] (
[rst_id] int NOT NULL IDENTITY(1,1) ,
[rst_nombre] varchar(50) NULL ,
[rst_direccion] varchar(250) NULL ,
[rst_descripcion] varchar(250) NULL ,
[rst_hora_apertura] varchar(15) NULL ,
[rst_hora_cierre] varchar(15) NULL ,
[fk_lugar] int NULL 
)


GO
DBCC CHECKIDENT(N'[Restaurante]', RESEED, 83)
GO

-- ----------------------------
-- Records of Restaurante
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Restaurante] ON
GO
INSERT INTO [Restaurante] ([rst_id], [rst_nombre], [rst_direccion], [rst_descripcion], [rst_hora_apertura], [rst_hora_cierre], [fk_lugar]) VALUES (N'1', N'Taxco', N'hamburgueseria', N'la paz', N'09:00', N'21:00', N'12'), (N'2', N'taxidon', N'calle 32', N'algo', N'08:00', N'20:00', N'13'), (N'3', N'La Toscana', N'La mejor comida', N'El Paraiso', N'09:00', N'22:00', N'12'), (N'4', N'Maracana', N'restaurante', N'Av. Jose Antonio Paez', N'08:00', N'22:00', N'14'), (N'5', N'DOC', N'Los palos grandes', N'cocina creativa', N'10:00', N'23:00', N'12'), (N'36', N'La Tasca De Don Diego', N'Comida Tradicional', N'Caricuao', N'10:00', N'17:00', N'12'), (N'77', N'Restaurante de prueba', N'Descripcion de prueba', N'X', N'07:00', N'19:00', N'12'), (N'78', N'Restaurante de prueba', N'Direccion de prueba', N'Descripcion de prueba', N'07:00', N'19:00', N'12'), (N'79', N'Restaurante de prueba', N'Direccion de prueba', N'Descripcion de prueba', N'07:00', N'19:00', N'12'), (N'80', N'Restaurante de prueba', N'Direccion de prueba', N'Descripcion de prueba', N'07:00', N'19:00', N'12'), (N'81', N'Restaurante de prueba', N'Direccion de prueba', N'Descripcion de prueba', N'07:00', N'19:00', N'12'), (N'82', N'Restaurante de prueba', N'Direccion de prueba', N'Descripcion de prueba', N'07:00', N'19:00', N'12'), (N'83', N'Restaurante de prueba', N'Direccion de prueba', N'Descripcion de prueba', N'07:00', N'19:00', N'12')
GO
GO
SET IDENTITY_INSERT [Restaurante] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Revision
-- ----------------------------
DROP TABLE [Revision]
GO
CREATE TABLE [Revision] (
[rev_id] int NOT NULL IDENTITY(1,1) ,
[rev_fecha] date NOT NULL ,
[rev_mensaje] varchar(8000) NOT NULL ,
[rev_tipo] int NOT NULL ,
[rev_puntuacion] int NOT NULL ,
[rev_FK_usu_id] int NULL ,
[rev_FK_res_hot_id] int NULL ,
[rev_FK_res_res_id] int NULL 
)


GO
DBCC CHECKIDENT(N'[Revision]', RESEED, 70)
GO

-- ----------------------------
-- Records of Revision
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Revision] ON
GO
INSERT INTO [Revision] ([rev_id], [rev_fecha], [rev_mensaje], [rev_tipo], [rev_puntuacion], [rev_FK_usu_id], [rev_FK_res_hot_id], [rev_FK_res_res_id]) VALUES (N'7', N'2016-12-10', N'Acogedor', N'2', N'10', N'1', N'42', null), (N'12', N'2016-10-10', N'malo', N'2', N'1', N'1', N'42', null), (N'13', N'2015-10-12', N'Excelente', N'2', N'10', N'1', N'45', null), (N'18', N'2000-10-10', N'PRUEBA', N'1', N'2', N'1', null, N'46'), (N'20', N'2016-12-10', N'Comida exquisita', N'1', N'10', N'1', null, N'46'), (N'57', N'2016-12-10', N'mira', N'1', N'5', N'1', null, N'46'), (N'65', N'2016-10-10', N'Excelente', N'1', N'2', N'73', null, N'92'), (N'66', N'2016-11-11', N'Mala atencion', N'1', N'1', N'73', null, N'93'), (N'67', N'2016-10-11', N'Buen ambiente', N'1', N'5', N'73', null, N'94'), (N'68', N'2015-10-11', N'Excelente Comida', N'1', N'5', N'73', null, N'95'), (N'69', N'2016-08-23', N'Agradable', N'1', N'3', N'73', null, N'96'), (N'70', N'2016-12-10', N'Me encanto', N'1', N'4', N'1', null, N'46')
GO
GO
SET IDENTITY_INSERT [Revision] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Revision_Valoracion
-- ----------------------------
DROP TABLE [Revision_Valoracion]
GO
CREATE TABLE [Revision_Valoracion] (
[rv_id] int NOT NULL IDENTITY(1,1) ,
[rv_fecha] date NOT NULL ,
[rv_val_pos] int NULL ,
[rv_val_neg] int NULL ,
[rv_FK_rev] int NULL 
)


GO
DBCC CHECKIDENT(N'[Revision_Valoracion]', RESEED, 9)
GO

-- ----------------------------
-- Records of Revision_Valoracion
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Revision_Valoracion] ON
GO
INSERT INTO [Revision_Valoracion] ([rv_id], [rv_fecha], [rv_val_pos], [rv_val_neg], [rv_FK_rev]) VALUES (N'3', N'2016-10-10', N'2', N'0', N'7'), (N'7', N'2016-11-12', N'2', N'-1', N'12'), (N'9', N'2016-12-11', N'5', N'0', N'13')
GO
GO
SET IDENTITY_INSERT [Revision_Valoracion] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Rol
-- ----------------------------
DROP TABLE [Rol]
GO
CREATE TABLE [Rol] (
[rol_id] int NOT NULL IDENTITY(1,1) ,
[rol_nombre] varchar(20) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Rol]', RESEED, 154)
GO

-- ----------------------------
-- Records of Rol
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Rol] ON
GO
INSERT INTO [Rol] ([rol_id], [rol_nombre]) VALUES (N'1', N'Administrador'), (N'2', N'Cliente'), (N'3', N'Anonimo'), (N'4', N'Cargador'), (N'5', N'Operador Aviones'), (N'145', N'Operador Automoviles'), (N'146', N'Operador'), (N'147', N'prueba2'), (N'148', N'Operador de Ruta'), (N'149', N'Operador de Vuelos'), (N'151', N'Operador de comida'), (N'153', N'Operador de equipaje')
GO
GO
SET IDENTITY_INSERT [Rol] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Rol_Modulo_Detallado
-- ----------------------------
DROP TABLE [Rol_Modulo_Detallado]
GO
CREATE TABLE [Rol_Modulo_Detallado] (
[fk_rol_id] int NOT NULL ,
[fk_mod_det_id] int NOT NULL 
)


GO

-- ----------------------------
-- Records of Rol_Modulo_Detallado
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [Rol_Modulo_Detallado] ([fk_rol_id], [fk_mod_det_id]) VALUES (N'1', N'6'), (N'1', N'7'), (N'1', N'8'), (N'1', N'9'), (N'1', N'10'), (N'1', N'11'), (N'1', N'12'), (N'1', N'13'), (N'1', N'14'), (N'1', N'15'), (N'1', N'16'), (N'1', N'17'), (N'1', N'18'), (N'1', N'19'), (N'1', N'20'), (N'1', N'21'), (N'1', N'22'), (N'1', N'23'), (N'1', N'24'), (N'1', N'25'), (N'1', N'26'), (N'1', N'27'), (N'1', N'29'), (N'1', N'30'), (N'1', N'31'), (N'1', N'32'), (N'1', N'33'), (N'1', N'34'), (N'1', N'35'), (N'1', N'36'), (N'1', N'37'), (N'1', N'38'), (N'1', N'39'), (N'1', N'40'), (N'1', N'41'), (N'2', N'8'), (N'2', N'10'), (N'2', N'12'), (N'2', N'17'), (N'2', N'19'), (N'2', N'23'), (N'2', N'24'), (N'2', N'26'), (N'2', N'32'), (N'4', N'7'), (N'4', N'9'), (N'4', N'11'), (N'4', N'13'), (N'4', N'15'), (N'4', N'16'), (N'4', N'18'), (N'4', N'21'), (N'4', N'25'), (N'4', N'29'), (N'4', N'31'), (N'4', N'33'), (N'4', N'35'), (N'4', N'36'), (N'4', N'39'), (N'4', N'40'), (N'5', N'6'), (N'145', N'11'), (N'145', N'12'), (N'146', N'24'), (N'146', N'25'), (N'147', N'26'), (N'148', N'10'), (N'149', N'32'), (N'153', N'35')
GO
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Ruta
-- ----------------------------
DROP TABLE [Ruta]
GO
CREATE TABLE [Ruta] (
[rut_id] int NOT NULL IDENTITY(1,1) ,
[rut_distancia] int NOT NULL ,
[rut_status_ruta] varchar(50) NOT NULL ,
[rut_tipo_ruta] varchar(50) NOT NULL ,
[rut_FK_lugar_origen] int NOT NULL ,
[rut_FK_lugar_destino] int NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Ruta]', RESEED, 232)
GO

-- ----------------------------
-- Records of Ruta
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Ruta] ON
GO
INSERT INTO [Ruta] ([rut_id], [rut_distancia], [rut_status_ruta], [rut_tipo_ruta], [rut_FK_lugar_origen], [rut_FK_lugar_destino]) VALUES (N'5', N'765', N'Activa', N'Aerea', N'16', N'29'), (N'16', N'225', N'Inactiva', N'Aerea', N'12', N'16'), (N'28', N'168', N'Activa', N'Maritima', N'12', N'37'), (N'29', N'168', N'Activa', N'Maritima', N'12', N'96'), (N'30', N'432', N'activa', N'Maritima', N'12', N'103'), (N'31', N'168', N'Activa', N'Maritima', N'12', N'91'), (N'41', N'707', N'Inactiva', N'Aerea', N'12', N'13'), (N'42', N'368', N'Activa', N'Aerea', N'12', N'14'), (N'43', N'55555', N'Activa', N'Aerea', N'12', N'15'), (N'44', N'707', N'Inactiva', N'Aerea', N'13', N'12'), (N'45', N'1142', N'Activa', N'Aerea', N'13', N'15'), (N'46', N'168', N'Activa', N'Aerea', N'16', N'12'), (N'47', N'602', N'Activa', N'Aerea', N'16', N'15'), (N'48', N'475', N'Activa', N'Aerea', N'15', N'12'), (N'49', N'1142', N'Activa', N'Aerea', N'15', N'16'), (N'54', N'5821', N'Activa', N'Aerea', N'12', N'19'), (N'55', N'3568', N'Activa', N'Aerea', N'12', N'21'), (N'56', N'3432', N'Activa', N'Aerea', N'12', N'22'), (N'57', N'215', N'Activa', N'Aerea', N'22', N'21'), (N'58', N'7982', N'Activa', N'Aerea', N'22', N'20'), (N'59', N'2790', N'Activa', N'Aerea', N'22', N'19'), (N'60', N'1285', N'Activa', N'Aerea', N'22', N'18'), (N'61', N'215', N'Activa', N'Aerea', N'21', N'22'), (N'62', N'8105', N'Activa', N'Aerea', N'21', N'20'), (N'63', N'2983', N'Activa', N'Aerea', N'21', N'19'), (N'64', N'1498', N'Activa', N'Aerea', N'21', N'18'), (N'65', N'7982', N'Activa', N'Aerea', N'20', N'22'), (N'66', N'8105', N'Activa', N'Aerea', N'20', N'21'), (N'67', N'4120', N'Activa', N'Aerea', N'20', N'19'), (N'68', N'7815', N'Activa', N'Aerea', N'20', N'18'), (N'69', N'2790', N'Activa', N'Aerea', N'19', N'22'), (N'70', N'2983', N'Activa', N'Aerea', N'19', N'21'), (N'71', N'4120', N'Activa', N'Aerea', N'19', N'20'), (N'72', N'2733', N'Activa', N'Aerea', N'19', N'18'), (N'73', N'1285', N'Activa', N'Aerea', N'18', N'22'), (N'74', N'1498', N'Activa', N'Aerea', N'18', N'21'), (N'75', N'7815', N'Activa', N'Aerea', N'18', N'20'), (N'76', N'2733', N'Activa', N'Aerea', N'18', N'19'), (N'77', N'6993', N'Activa', N'Aerea', N'12', N'24'), (N'78', N'528', N'Activa', N'Aerea', N'24', N'25'), (N'79', N'622', N'Activa', N'Aerea', N'24', N'26'), (N'80', N'534', N'Activa', N'Aerea', N'24', N'27'), (N'81', N'390', N'Activa', N'Aerea', N'24', N'28'), (N'82', N'303', N'Activa', N'Aerea', N'24', N'29'), (N'83', N'622', N'Activa', N'Aerea', N'26', N'24'), (N'84', N'351', N'Activa', N'Aerea', N'26', N'29'), (N'85', N'996', N'Activa', N'Aerea', N'26', N'27'), (N'86', N'528', N'Activa', N'Aerea', N'25', N'24'), (N'87', N'206', N'Activa', N'Aerea', N'25', N'27'), (N'88', N'534', N'Activa', N'Aerea', N'27', N'24'), (N'89', N'996', N'Activa', N'Aerea', N'27', N'26'), (N'90', N'206', N'Activa', N'Aerea', N'27', N'25'), (N'91', N'303', N'Activa', N'Aerea', N'29', N'24'), (N'93', N'2203', N'Activa', N'Aerea', N'18', N'12'), (N'94', N'5821', N'Activa', N'Aerea', N'19', N'12'), (N'95', N'3568', N'Activa', N'Aerea', N'21', N'12'), (N'96', N'3432', N'Activa', N'Aerea', N'22', N'12'), (N'97', N'1328', N'Activa', N'aerea', N'21', N'33'), (N'100', N'928', N'activa', N'aerea', N'14', N'34'), (N'102', N'3212', N'activa', N'aerea', N'16', N'27'), (N'104', N'3241', N'activa', N'aerea', N'18', N'26'), (N'106', N'5456', N'activa', N'aerea', N'18', N'13'), (N'109', N'2131', N'activa', N'aerea', N'16', N'28'), (N'111', N'0', N'activa', N'aerea', N'27', N'15'), (N'114', N'3123', N'activa', N'aerea', N'12', N'18'), (N'115', N'4500', N'activa', N'aerea', N'18', N'86'), (N'120', N'1231', N'activa', N'aerea', N'16', N'14'), (N'122', N'312', N'activa', N'aerea', N'28', N'31'), (N'152', N'46789', N'inactiva', N'maritima', N'32', N'20'), (N'176', N'763', N'activa', N'aerea', N'32', N'29'), (N'178', N'3219', N'Activa', N'maritima', N'19', N'31'), (N'180', N'632', N'activa', N'aerea', N'25', N'34'), (N'206', N'312', N'activa', N'maritima', N'15', N'32'), (N'208', N'2331', N'Activa', N'maritima', N'24', N'104'), (N'211', N'432', N'activa', N'aerea', N'32', N'16'), (N'212', N'432', N'activa', N'aerea', N'32', N'16'), (N'213', N'3213', N'activa', N'aerea', N'33', N'27'), (N'214', N'3213', N'activa', N'aerea', N'33', N'27'), (N'215', N'432', N'activa', N'aerea', N'32', N'31'), (N'216', N'432', N'activa', N'aerea', N'32', N'31'), (N'217', N'1000', N'Inactiva', N'aerea', N'12', N'94'), (N'219', N'155', N'Activa', N'Aerea', N'12', N'18'), (N'220', N'155', N'Activa', N'Aerea', N'12', N'18'), (N'221', N'155', N'Activa', N'Aerea', N'12', N'18'), (N'222', N'155', N'Activa', N'Aerea', N'12', N'18'), (N'223', N'155', N'Activa', N'Aerea', N'12', N'18'), (N'224', N'155', N'Activa', N'Aerea', N'12', N'18'), (N'225', N'55555555', N'Activa', N'Aerea', N'12', N'18'), (N'226', N'55555555', N'Activa', N'Aerea', N'12', N'18'), (N'227', N'55555555', N'Activa', N'Aerea', N'12', N'18'), (N'228', N'55555555', N'Activa', N'Aerea', N'12', N'18'), (N'229', N'55555555', N'Activa', N'Aerea', N'12', N'18'), (N'230', N'55555555', N'Activa', N'Aerea', N'12', N'18'), (N'231', N'55555555', N'Activa', N'Aerea', N'12', N'18'), (N'232', N'55555555', N'Activa', N'Aerea', N'12', N'18')
GO
GO
SET IDENTITY_INSERT [Ruta] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for TA
-- ----------------------------
DROP TABLE [TA]
GO
CREATE TABLE [TA] (
[Uno] int NOT NULL ,
[Dos] int NOT NULL ,
[Tres] int NOT NULL ,
[Frase] varchar(255) NOT NULL 
)


GO

-- ----------------------------
-- Records of TA
-- ----------------------------
BEGIN TRANSACTION
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for TA_copy
-- ----------------------------
DROP TABLE [TA_copy]
GO
CREATE TABLE [TA_copy] (
[Uno] int NOT NULL ,
[Dos] int NOT NULL ,
[Tres] int NOT NULL 
)


GO

-- ----------------------------
-- Records of TA_copy
-- ----------------------------
BEGIN TRANSACTION
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Telefono
-- ----------------------------
DROP TABLE [Telefono]
GO
CREATE TABLE [Telefono] (
[tel_id] int NOT NULL IDENTITY(1,1) ,
[tel_cod_pais] int NOT NULL ,
[tel_cod_area] int NOT NULL ,
[tel_num_telefonico] int NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Telefono]', RESEED, 9)
GO

-- ----------------------------
-- Records of Telefono
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Telefono] ON
GO
INSERT INTO [Telefono] ([tel_id], [tel_cod_pais], [tel_cod_area], [tel_num_telefonico]) VALUES (N'1', N'0', N'0', N'0'), (N'2', N'0', N'0', N'0'), (N'3', N'0', N'0', N'0'), (N'4', N'0', N'0', N'0'), (N'5', N'0', N'0', N'0'), (N'6', N'0', N'0', N'0'), (N'7', N'4564', N'4564', N'4564564'), (N'8', N'0', N'4444', N'5555555'), (N'9', N'0', N'0', N'0')
GO
GO
SET IDENTITY_INSERT [Telefono] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Usuario
-- ----------------------------
DROP TABLE [Usuario]
GO
CREATE TABLE [Usuario] (
[usu_nombre] varchar(50) NOT NULL ,
[usu_apellido] varchar(50) NOT NULL ,
[usu_correo] varchar(255) NOT NULL ,
[usu_contraseña] varchar(255) NOT NULL ,
[usu_fk_rol] int NOT NULL ,
[usu_fechaCreacion] date NOT NULL ,
[usu_activo] varchar(20) NOT NULL ,
[usu_id] int NOT NULL IDENTITY(1,1) 
)


GO
DBCC CHECKIDENT(N'[Usuario]', RESEED, 92)
GO

-- ----------------------------
-- Records of Usuario
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Usuario] ON
GO
INSERT INTO [Usuario] ([usu_nombre], [usu_apellido], [usu_correo], [usu_contraseña], [usu_fk_rol], [usu_fechaCreacion], [usu_activo], [usu_id]) VALUES (N'Manuel', N'Irazabal', N'a@a.com', N'af8f9dffa5d420fbc249141645b962ee', N'1', N'2016-12-13', N'Activo', N'1'), (N'William', N'Angulo', N'a@reserva.com', N'7bc287c7fe4a949e5e72b4727c404a57', N'1', N'2016-12-13', N'Activo', N'2'), (N'Alfred', N'DEFA', N'alfreasd@er.com', N'a261108357a8dbcb6a891b1efd40a794', N'5', N'2016-12-08', N'Inactivo', N'3'), (N'Andrea', N'Soto', N'avsotoa@reserva.com', N'54910c5c09962d6d268b1f3231fded77', N'1', N'2016-12-13', N'Activo', N'4'), (N'Unai', N'Lecue', N'b@a.com', N'af8f9dffa5d420fbc249141645b962ee', N'4', N'2016-12-13', N'Inactivo', N'5'), (N'Regulo', N'Perez', N'chivo@gmail.com', N'1234', N'1', N'2016-12-06', N'Activo', N'10'), (N'Carlos', N'Velasco', N'cv@gmail.com', N'1234', N'2', N'2016-12-01', N'Activo', N'11'), (N'david', N'garcia', N'dg@gmail.com', N'123456', N'2', N'2016-12-12', N'Activo', N'12'), (N'gabriela', N'gonzalez', N'gabrielagonzalez@gmail.com', N'MQAyADMANAA1ADYANwA=', N'2', N'2016-12-12', N'Activo', N'19'), (N'angela', N'gigglioli', N'gigglioli@gmail.com', N'YQB1AHIAbwByAGEAXwAwADkAMQA=', N'2', N'2016-12-13', N'Activo', N'20'), (N'Gustavo', N'Lara', N'gl@gmail.com', N'1234', N'2', N'2016-12-09', N'Activo', N'21'), (N'ejemplo', N'para', N'gmail@gmail.com', N'1234', N'2', N'2016-12-15', N'Activo ', N'22'), (N' Prueba', N'Prueba', N'prueba@reserva.com', N'12345', N'1', N'2016-11-28', N'Activo', N'33'), (N'Reserva', N'Admin', N'reserva@reserva.com', N'7bc287c7fe4a949e5e72b4727c404a57', N'1', N'2016-12-13', N'Activo', N'34'), (N'vanesa', N'gonzales', N'sssdsdsdsasfs@gmail', N'MQAyADMANAA1ADYANwA=', N'2', N'2016-12-14', N'Activo', N'41'), (N'mario', N'luque', N'luquem@gmail.com', N'MQAyADMANAA1ADYANwA=', N'2', N'2016-12-14', N'Activo', N'42'), (N'carlos', N'herrera', N'carlos@gmail.com', N'12345678', N'2', N'2016-12-15', N'Activo', N'44'), (N'kaori', N'madotsuki', N'ositobenja@ositobenja.com', N'MQAyADMANAA1ADYANwA=', N'2', N'2016-12-14', N'Activo', N'45'), (N'Mario', N'Luque', N'marioluquem@hotmail.com', N'bQBhAHIAaQBvADEAOQA5ADEA', N'2', N'2016-12-14', N'Activo', N'46'), (N'osito', N'gominola', N'gominola@peluchito.com', N'MQAyADMANAA1ADYANwA4ADkA', N'2', N'2016-12-14', N'Activo', N'48'), (N'osito', N'peluchito', N'ositopeluchito@gominola.com', N'MQAyADMANAA1ADYANwA=', N'2', N'2016-12-14', N'Activo', N'49'), (N'osito', N'pegajosito', N'pegajosito1@gmail.com', N'MQAyADMANAA1ADYANwA=', N'2', N'2016-12-14', N'Activo', N'50'), (N'osito', N'pegajosito', N'pegajosito_1@gmail.com', N'MQAyADMANAA1ADYANwA=', N'2', N'2016-12-14', N'Activo', N'51'), (N'lorena', N'uzcategui', N'loreu@outlook.com', N'MQAyADMANAA1ADYANwA=', N'2', N'2016-12-14', N'Activo', N'52'), (N'Marioogfsdf', N'Luquesfggsdf', N'pruebaMario@hotmail.com', N'MQAyADMANAA1ADYANwA=', N'2', N'2016-12-14', N'Activo', N'53'), (N'pruebaMario', N'pruebaMario', N'pruebaMarioFinal@hotmail.com', N'MQAyADMANAA1ADYANwA=', N'2', N'2016-12-14', N'Activo', N'54'), (N'Franklin', N'Morales', N'franklin@gmail.com', N'MQAyADMANAA1ADYANwA4AA==', N'2', N'2016-12-14', N'Activo', N'56'), (N'Jose', N'Cabeza', N'jd.cabeza@gmail.com', N'7bc287c7fe4a949e5e72b4727c404a57', N'1', N'2016-12-14', N'Activo', N'73'), (N'David', N'Botello', N'drbr@reserva.com', N'df6396ca24725abcce7a4ebedd6aa965', N'1', N'2016-12-14', N'Inactivo', N'75')
GO
GO
SET IDENTITY_INSERT [Usuario] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Vuelo
-- ----------------------------
DROP TABLE [Vuelo]
GO
CREATE TABLE [Vuelo] (
[vue_id] int NOT NULL IDENTITY(1,1) ,
[vue_codigo] varchar(50) NOT NULL ,
[vue_fk_ruta] int NOT NULL ,
[vue_fecha_despegue] datetime NOT NULL ,
[vue_status] varchar(50) NOT NULL ,
[vue_fecha_aterrizaje] datetime NOT NULL ,
[vue_fk_avion] int NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Vuelo]', RESEED, 249)
GO

-- ----------------------------
-- Records of Vuelo
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Vuelo] ON
GO
INSERT INTO [Vuelo] ([vue_id], [vue_codigo], [vue_fk_ruta], [vue_fecha_despegue], [vue_status], [vue_fecha_aterrizaje], [vue_fk_avion]) VALUES (N'6', N'V508', N'16', N'2016-12-18 19:05:00.000', N'activo', N'2016-12-18 20:05:00.000', N'1'), (N'7', N'V510', N'46', N'2016-12-23 16:05:00.000', N'inactivo', N'2016-12-23 17:05:00.000', N'2'), (N'8', N'V512', N'16', N'2013-08-30 22:05:00.000', N'inactivo', N'2013-09-02 22:05:00.000', N'3'), (N'9', N'V529', N'59', N'2013-09-30 19:05:00.000', N'inactivo', N'2013-10-03 19:05:00.000', N'1'), (N'10', N'V533', N'46', N'2013-09-30 20:05:00.000', N'inactivo', N'2013-10-03 20:05:00.000', N'2'), (N'11', N'V536', N'46', N'2013-09-30 22:05:00.000', N'inactivo', N'2013-10-03 22:05:00.000', N'3'), (N'12', N'AA555', N'16', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-11 09:45:00.000', N'17'), (N'13', N'AA556', N'41', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-11 10:00:00.000', N'13'), (N'15', N'AA558', N'16', N'2016-12-10 09:00:00.000', N'activo', N'2016-12-10 09:45:00.000', N'17'), (N'16', N'AA559', N'41', N'2016-12-10 09:00:00.000', N'activo', N'2016-12-10 10:00:00.000', N'13'), (N'18', N'AA561', N'16', N'2016-12-09 09:00:00.000', N'activo', N'2016-12-09 09:45:00.000', N'17'), (N'19', N'AA562', N'41', N'2016-12-09 09:00:00.000', N'activo', N'2016-12-09 10:00:00.000', N'13'), (N'20', N'AA563', N'45', N'2016-12-09 09:00:00.000', N'activo', N'2016-12-09 10:20:00.000', N'12'), (N'102', N'AA777', N'42', N'2016-12-07 00:00:00.000', N'activo', N'2016-12-07 00:46:00.000', N'12'), (N'103', N'ZZPrueba', N'42', N'2016-12-03 00:00:00.000', N'activo', N'2016-12-03 00:46:00.000', N'12'), (N'104', N'Modifico', N'42', N'2000-01-01 09:00:00.000', N'activo', N'2000-01-01 09:46:00.000', N'1'), (N'105', N'VVPrueba', N'41', N'2016-12-17 14:02:00.000', N'inactivo', N'2016-12-17 15:31:00.000', N'12'), (N'175', N'hiu', N'42', N'2016-12-13 09:59:00.000', N'inactivo', N'2016-12-13 10:45:00.000', N'12'), (N'177', N'PruebaMerge', N'42', N'2016-12-15 00:00:00.000', N'activo', N'2016-12-15 00:40:00.000', N'122'), (N'178', N'AA557', N'45', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-11 10:20:00.000', N'12'), (N'179', N'AA560', N'45', N'2016-12-10 09:00:00.000', N'activo', N'2016-12-10 10:20:00.000', N'12'), (N'180', N'BE237', N'16', N'2016-12-08 09:00:00.000', N'activo', N'2016-12-08 09:45:00.000', N'17'), (N'181', N'BE238', N'41', N'2016-12-08 09:00:00.000', N'activo', N'2016-12-08 10:00:00.000', N'13'), (N'182', N'BE239', N'45', N'2016-12-08 09:00:00.000', N'activo', N'2016-12-08 10:20:00.000', N'12'), (N'183', N'BE240', N'16', N'2016-12-07 09:00:00.000', N'activo', N'2016-12-07 09:45:00.000', N'17'), (N'184', N'BE241', N'41', N'2016-12-07 09:00:00.000', N'activo', N'2016-12-07 10:00:00.000', N'13'), (N'185', N'BE242', N'45', N'2016-12-07 09:00:00.000', N'activo', N'2016-12-07 10:20:00.000', N'12'), (N'186', N'BE243', N'16', N'2016-12-06 09:00:00.000', N'activo', N'2016-12-06 09:45:00.000', N'17'), (N'187', N'CD776', N'41', N'2016-12-06 09:00:00.000', N'activo', N'2016-12-06 10:00:00.000', N'13'), (N'188', N'CD777', N'45', N'2016-12-06 09:00:00.000', N'activo', N'2016-12-06 10:20:00.000', N'12'), (N'189', N'CD778', N'16', N'2016-12-05 09:00:00.000', N'activo', N'2016-12-05 09:45:00.000', N'17'), (N'190', N'CD779', N'41', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-05 10:00:00.000', N'13'), (N'191', N'CD780', N'45', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-05 10:20:00.000', N'12'), (N'192', N'CD781', N'16', N'2016-12-04 09:00:00.000', N'activo', N'2016-12-04 09:45:00.000', N'17'), (N'193', N'CD782', N'41', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-04 10:00:00.000', N'13'), (N'194', N'CD783', N'45', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-04 10:20:00.000', N'12'), (N'195', N'CD784', N'16', N'2016-12-03 09:00:00.000', N'activo', N'2016-12-03 09:45:00.000', N'17'), (N'196', N'BT900', N'41', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-03 10:00:00.000', N'13'), (N'197', N'BT901', N'45', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-03 10:20:00.000', N'12'), (N'198', N'BT902', N'16', N'2016-12-02 09:00:00.000', N'activo', N'2016-12-02 09:45:00.000', N'17'), (N'199', N'BT903', N'41', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-02 10:00:00.000', N'13'), (N'200', N'BT904', N'45', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-02 10:20:00.000', N'12'), (N'201', N'BT905', N'16', N'2016-12-01 09:00:00.000', N'activo', N'2016-12-01 09:45:00.000', N'17'), (N'202', N'BT906', N'41', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-01 10:00:00.000', N'13'), (N'203', N'BT907', N'45', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-01 10:20:00.000', N'12'), (N'204', N'JS343', N'16', N'2016-12-13 09:00:00.000', N'activo', N'2016-12-13 09:45:00.000', N'17'), (N'205', N'JS344', N'41', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-13 10:00:00.000', N'13'), (N'206', N'JS345', N'45', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-13 10:20:00.000', N'12'), (N'207', N'JS346', N'16', N'2016-12-14 09:00:00.000', N'activo', N'2016-12-14 09:45:00.000', N'17'), (N'208', N'JS347', N'41', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-14 10:00:00.000', N'13'), (N'209', N'JS348', N'45', N'2016-12-11 09:00:00.000', N'activo', N'2016-12-14 10:20:00.000', N'12'), (N'210', N'VZ236', N'67', N'2016-12-12 09:00:00.000', N'activo', N'2016-12-12 14:30:00.000', N'1'), (N'211', N'VZ237', N'74', N'2016-12-12 09:00:00.000', N'activo', N'2016-12-12 12:10:00.000', N'4'), (N'212', N'VZ238', N'57', N'2016-12-12 09:00:00.000', N'activo', N'2016-12-12 10:00:00.000', N'5'), (N'213', N'VZ239', N'67', N'2016-12-15 09:00:00.000', N'activo', N'2016-12-15 14:30:00.000', N'1'), (N'214', N'VZ240', N'74', N'2016-12-15 09:00:00.000', N'activo', N'2016-12-15 12:10:00.000', N'4'), (N'215', N'VZ241', N'57', N'2016-12-15 09:00:00.000', N'activo', N'2016-12-15 10:00:00.000', N'5'), (N'216', N'VZ242', N'67', N'2016-12-16 09:00:00.000', N'activo', N'2016-12-16 14:30:00.000', N'1'), (N'217', N'VZ243', N'74', N'2016-12-16 09:00:00.000', N'activo', N'2016-12-16 12:10:00.000', N'4'), (N'218', N'LM289', N'57', N'2016-12-16 09:00:00.000', N'activo', N'2016-12-16 10:00:00.000', N'5'), (N'219', N'LM290', N'67', N'2016-12-17 09:00:00.000', N'activo', N'2016-12-17 14:30:00.000', N'1'), (N'220', N'LM291', N'74', N'2016-12-17 09:00:00.000', N'activo', N'2016-12-17 12:10:00.000', N'4'), (N'221', N'LM292', N'57', N'2016-12-17 09:00:00.000', N'activo', N'2016-12-17 10:00:00.000', N'5'), (N'222', N'LM293', N'67', N'2016-12-18 09:00:00.000', N'activo', N'2016-12-18 14:30:00.000', N'1'), (N'223', N'LM294', N'74', N'2016-12-18 09:00:00.000', N'activo', N'2016-12-18 12:10:00.000', N'4'), (N'224', N'LM295', N'57', N'2016-12-18 09:00:00.000', N'activo', N'2016-12-18 10:00:00.000', N'5'), (N'225', N'LM296', N'67', N'2016-12-19 09:00:00.000', N'activo', N'2016-12-19 14:30:00.000', N'1'), (N'226', N'LM297', N'74', N'2016-12-19 09:00:00.000', N'activo', N'2016-12-19 12:10:00.000', N'4'), (N'227', N'JL061', N'57', N'2016-12-19 09:00:00.000', N'activo', N'2016-12-19 10:00:00.000', N'5'), (N'228', N'JL062', N'67', N'2016-12-20 09:00:00.000', N'activo', N'2016-12-20 14:30:00.000', N'1'), (N'229', N'JL063', N'74', N'2016-12-20 09:00:00.000', N'activo', N'2016-12-20 12:10:00.000', N'4'), (N'230', N'JL064', N'57', N'2016-12-20 09:00:00.000', N'activo', N'2016-12-20 10:00:00.000', N'5'), (N'231', N'JL065', N'67', N'2016-12-21 09:00:00.000', N'activo', N'2016-12-21 14:30:00.000', N'1'), (N'232', N'JL066', N'74', N'2016-12-21 09:00:00.000', N'activo', N'2016-12-21 12:10:00.000', N'4'), (N'233', N'JL067', N'57', N'2016-12-21 09:00:00.000', N'activo', N'2016-12-21 10:00:00.000', N'5'), (N'234', N'JL068', N'67', N'2016-12-22 09:00:00.000', N'activo', N'2016-12-22 14:30:00.000', N'1'), (N'235', N'JL069', N'74', N'2016-12-22 09:00:00.000', N'activo', N'2016-12-22 12:10:00.000', N'4'), (N'236', N'JL070', N'57', N'2016-12-22 09:00:00.000', N'activo', N'2016-12-22 10:00:00.000', N'5'), (N'237', N'JL071', N'67', N'2016-12-23 09:00:00.000', N'activo', N'2016-12-23 14:30:00.000', N'1'), (N'238', N'NR239', N'74', N'2016-12-23 09:00:00.000', N'activo', N'2016-12-23 12:10:00.000', N'4'), (N'239', N'NR240', N'57', N'2016-12-23 09:00:00.000', N'activo', N'2016-12-23 10:00:00.000', N'5'), (N'240', N'NR241', N'67', N'2016-12-24 09:00:00.000', N'activo', N'2016-12-24 14:30:00.000', N'1'), (N'241', N'NR242', N'74', N'2016-12-24 09:00:00.000', N'activo', N'2016-12-24 12:10:00.000', N'4'), (N'242', N'NR243', N'57', N'2016-12-24 09:00:00.000', N'activo', N'2016-12-24 10:00:00.000', N'5'), (N'243', N'NR244', N'67', N'2016-12-25 09:00:00.000', N'activo', N'2016-12-25 14:30:00.000', N'1'), (N'244', N'NR245', N'74', N'2016-12-25 09:00:00.000', N'activo', N'2016-12-25 12:10:00.000', N'4'), (N'245', N'NR246', N'57', N'2016-12-25 09:00:00.000', N'activo', N'2016-12-25 10:00:00.000', N'5'), (N'246', N'NR247', N'67', N'2016-12-26 09:00:00.000', N'activo', N'2016-12-26 14:30:00.000', N'1'), (N'247', N'NR248', N'74', N'2016-12-26 09:00:00.000', N'activo', N'2016-12-26 12:10:00.000', N'4'), (N'248', N'NR249', N'57', N'2016-12-26 09:00:00.000', N'activo', N'2016-12-26 10:00:00.000', N'5'), (N'249', N'AAprueba', N'42', N'2016-12-15 12:00:00.000', N'inactivo', N'2016-12-15 12:46:00.000', N'12')
GO
GO
SET IDENTITY_INSERT [Vuelo] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Procedure structure for Admin_DesbloquearReserva
-- ----------------------------
DROP PROCEDURE [Admin_DesbloquearReserva]
GO
CREATE procedure [Admin_DesbloquearReserva] 
AS
BEGIN

	DECLARE @id int
		SELECT @id = U.USU_ID 
		FROM USUARIO U
		WHERE U.usu_correo like 'reserva@reserva.com'
		UPDATE [dbo].[Usuario]
		SET
				[usu_activo] = 'Activo'
			WHERE
				[usu_id] = @id
		UPDATE [dbo].[Usuario]
		SET
				[usu_contraseña] = '7bc287c7fe4a949e5e72b4727c404a57'
			WHERE
				[usu_id] = @id
		UPDATE [dbo].[Login]
		SET
				[log_intentos] = 0
			WHERE
				[log_idusuario] = @id


	END

GO

-- ----------------------------
-- Procedure structure for M02_ObtenerModulosDetallados
-- ----------------------------
DROP PROCEDURE [M02_ObtenerModulosDetallados]
GO
CREATE PROCEDURE [M02_ObtenerModulosDetallados]
@modulo_general_nom [varchar](200),
@codigo_rol int

AS
BEGIN
SELECT md.mod_det_nombre as opc_nombre, md.mod_det_url as opc_url
    FROM modulo_general m, modulo_detallado md, rol_modulo_detallado ro
    WHERE m.mod_gen_nombre =@modulo_general_nom and ro.fk_rol_id = @codigo_rol  and m.mod_gen_id = md.fk_mod_gen_id and md.mod_det_id = ro.fk_mod_det_id;
END;

GO

-- ----------------------------
-- Procedure structure for M02_ObtenerModulosGenerales
-- ----------------------------
DROP PROCEDURE [M02_ObtenerModulosGenerales]
GO

CREATE PROCEDURE [M02_ObtenerModulosGenerales]

AS
BEGIN
SELECT m.mod_gen_nombre as Modulo_Detallado
    FROM modulo_general m;
END;

GO

-- ----------------------------
-- Procedure structure for M03_AgregarRuta
-- ----------------------------
DROP PROCEDURE [M03_AgregarRuta]
GO
CREATE PROCEDURE [M03_AgregarRuta]
(
@ciudadOrigenRuta VARCHAR(100),
@paisOrigenRuta VARCHAR(100),
@ciudadDestinoRuta VARCHAR(100),
@paisDestinoRuta VARCHAR(100),
@tipoRuta VARCHAR(10),
@estadoRuta VARCHAR(10),
@distanciaRuta int
)
AS
BEGIN
DECLARE @id1 int;
DECLARE @id2 int;

	(Select @id1 = lug_id
							FROM Lugar 
						  where lug_nombre = @ciudadOrigenRuta
							and lug_FK_lugar_id = (Select lug_id 
																		 FROM Lugar
																		 where lug_nombre = @paisOrigenRuta))
	
	(select @id2 = lug_id
							FROM Lugar 
							where lug_nombre = @ciudadDestinoRuta
							and lug_FK_lugar_id = (Select lug_id 
																		 FROM Lugar
																		 where lug_nombre = @paisDestinoRuta))


	insert into Ruta (rut_distancia, rut_status_ruta, rut_tipo_ruta, rut_FK_lugar_origen, rut_FK_lugar_destino)
	VALUES (@distanciaRuta,@estadoRuta,@tipoRuta,@id1,@id2);
END

GO

-- ----------------------------
-- Procedure structure for M03_InsertarSiNoExiste
-- ----------------------------
DROP PROCEDURE [M03_InsertarSiNoExiste]
GO
CREATE PROCEDURE [M03_InsertarSiNoExiste]

@ciudadOrigenRuta VARCHAR(100),
@paisOrigenRuta VARCHAR(100),
@ciudadDestinoRuta VARCHAR(100),
@paisDestinoRuta VARCHAR(100),
@_distancia INT,
@_Status VARCHAR(15),
@_tipo VARCHAR(15)

AS
BEGIN
DECLARE @_Origen int;
DECLARE @_Destino int;

	(Select @_Origen = lug_id
							FROM Lugar 
						  where lug_nombre = @ciudadOrigenRuta
							and lug_FK_lugar_id = (Select lug_id 
																		 FROM Lugar
																		 where lug_nombre = @paisOrigenRuta))
	
	(select @_Destino = lug_id
							FROM Lugar 
							where lug_nombre = @ciudadDestinoRuta
							and lug_FK_lugar_id = (Select lug_id 
																		 FROM Lugar
																		 where lug_nombre = @paisDestinoRuta))


	if NOT EXISTS(SELECT *
								FROM Ruta a
								where A.rut_tipo_ruta	= @_tipo
								AND A.rut_FK_lugar_origen = @_origen
								AND A.RUT_FK_LUGAR_DESTINO = @_Destino)
	BEGIN
		INSERT INTO Ruta (rut_distancia,rut_status_ruta,rut_tipo_ruta,rut_FK_lugar_origen,rut_FK_lugar_destino)
		VALUES (@_distancia,@_Status,@_tipo,@_Origen,@_Destino)
  END-- routine body goes here, e.g.
  -- SELECT 'Navicat for SQL Server'
END
GO

-- ----------------------------
-- Procedure structure for M03_ValidarRuta
-- ----------------------------
DROP PROCEDURE [M03_ValidarRuta]
GO
CREATE PROCEDURE [M03_ValidarRuta]
(
@ciudadOrigenRuta VARCHAR(100),
@paisOrigenRuta VARCHAR(100),
@ciudadDestinoRuta VARCHAR(100),
@paisDestinoRuta VARCHAR(100),
@tipoRuta VARCHAR(100)
)
AS
BEGIN
DECLARE @idOri int;
DECLARE @idDes int;
DECLARE @cant int;

	(Select @idOri= lug_id
							FROM Lugar 
						  where lug_nombre = @ciudadOrigenRuta
							and lug_FK_lugar_id = (Select lug_id 
																		 FROM Lugar
																		 where lug_nombre = @paisOrigenRuta))
	
	(select @idDes = lug_id
							FROM Lugar 
							where lug_nombre = @ciudadDestinoRuta
							and lug_FK_lugar_id = (Select lug_id 
																		 FROM Lugar
																		 where lug_nombre = @paisDestinoRuta))

	(SELECT (rut_id)
					FROM Ruta
					where rut_FK_lugar_origen = @idOri
					and rut_FK_lugar_destino = @idDes
					and rut_tipo_ruta = @tipoRuta)	
  
END

GO

-- ----------------------------
-- Procedure structure for M04_ActivarVuelo
-- ----------------------------
DROP PROCEDURE [M04_ActivarVuelo]
GO
CREATE PROCEDURE [M04_ActivarVuelo](
@id int)
AS
BEGIN
  UPDATE Vuelo
  SET vue_status = 'activo'
  WHERE vue_id = @id
END
GO

-- ----------------------------
-- Procedure structure for M04_BuscaIdRuta
-- ----------------------------
DROP PROCEDURE [M04_BuscaIdRuta]
GO
CREATE PROCEDURE [M04_BuscaIdRuta]
(
@CiudadOrigen varchar(100) ,
@CiudadDestino varchar(100) 
)
AS
BEGIN
DECLARE @idruta int;
DECLARE @idru int;

SELECT r.rut_id 
FROM Ruta r
WHERE r.rut_FK_lugar_origen = (SELECT ll.lug_id
													FROM Lugar ll
													WHERE ll.lug_nombre = @CiudadOrigen)
AND r.rut_FK_lugar_destino = (SELECT ll.lug_id
													FROM Lugar ll
													WHERE ll.lug_nombre = @CiudadDestino)



END
GO

-- ----------------------------
-- Procedure structure for M04_BuscaKmPorRuta
-- ----------------------------
DROP PROCEDURE [M04_BuscaKmPorRuta]
GO
CREATE PROCEDURE [M04_BuscaKmPorRuta]
( 
@idruta int
)
AS
BEGIN

SELECT r.rut_distancia
FROM Ruta r
WHERE r.rut_id = @idruta

END
GO

-- ----------------------------
-- Procedure structure for M04_BuscaModificar
-- ----------------------------
DROP PROCEDURE [M04_BuscaModificar]
GO
CREATE PROCEDURE [M04_BuscaModificar]
  @id int 
AS
BEGIN

SELECT v.vue_id,v.vue_codigo,v.vue_fecha_aterrizaje,v.vue_fecha_despegue, a.avi_matricula, v.vue_status, v.vue_fk_ruta
FROM Vuelo v, Avion a
WHERE v.vue_id = @id
AND v.vue_fk_avion = a.avi_id

END
GO

-- ----------------------------
-- Procedure structure for M04_BuscarDestinos
-- ----------------------------
DROP PROCEDURE [M04_BuscarDestinos]
GO
CREATE PROCEDURE [M04_BuscarDestinos]
(
@CiudadOrigen AS VARCHAR(100)
)
AS
BEGIN

SELECT l.lug_nombre
FROM Ruta r, Lugar l
WHERE r.rut_FK_lugar_origen = (Select ll.lug_id 
																From Lugar ll
																Where ll.lug_nombre = @CiudadOrigen) 
AND r.rut_FK_lugar_destino = l.lug_id
AND r.rut_tipo_ruta = 'Aerea'

END
GO

-- ----------------------------
-- Procedure structure for M04_BuscaVueloPorId
-- ----------------------------
DROP PROCEDURE [M04_BuscaVueloPorId]
GO
CREATE PROCEDURE [M04_BuscaVueloPorId]
(
@idvuelo int
)
AS
BEGIN
DECLARE @VueloRuta INT;
DECLARE @VueloFechaDespegue DATETIME;
DECLARE @VueloFechaAterrizaje DATETIME;
DECLARE @VueloStatus VARCHAR;
DECLARE @VueloAvion INT;


SET @VueloAvion = (SELECT v.vue_fk_avion
										FROM Vuelo v
										WHERE v.vue_id = @idvuelo)

SET @VueloFechaDespegue = (SELECT v.vue_fecha_despegue
														FROM Vuelo v
														WHERE v.vue_id = @idvuelo)

SET @VueloFechaAterrizaje = (SELECT v.vue_fecha_aterrizaje
															FROM Vuelo v
															WHERE v.vue_id = @idvuelo) 

SET @VueloRuta = (SELECT v.vue_fk_ruta
										FROM Vuelo v
										WHERE v.vue_id = @idvuelo) 

SET @VueloStatus = (SELECT v.vue_status
											FROM Vuelo v
											WHERE v.vue_id = @idvuelo) 
END
GO

-- ----------------------------
-- Procedure structure for M04_CalcularFechaAterrizaje
-- ----------------------------
DROP PROCEDURE [M04_CalcularFechaAterrizaje]
GO
CREATE PROCEDURE [M04_CalcularFechaAterrizaje]
  @fechaDespegue datetime,
	@CiudadOrigen varchar(100),
	@CiudadDestino varchar(100),
	@matriculaAvion varchar(100),
	@idRuta int
AS
BEGIN

 
DECLARE @usoOrigen int;
DECLARE @usoDestino int;
DECLARE @diferencia int;
DECLARE @fechita datetime;
DECLARE @horasVuelo int;
DECLARE @MaxVel FLOAT;
DECLARE @VelocidadPromedio FLOAT;
DECLARE @DistRuta FLOAT;
DECLARE @MinutosVuelo INT;


SET @MaxVel = (SELECT a.avi_max_vel
							 FROM Avion a
							 WHERE a.avi_matricula = @MatriculaAvion)

SET @VelocidadPromedio = (@MaxVel * 0.6);

SET @DistRuta = (SELECT r.rut_distancia
								 FROM Ruta r
								 WHERE r.rut_id = @idRuta)

SET @MinutosVuelo = ((@DistRuta/@VelocidadPromedio)*60)
SET @fechita = DATEADD(MINUTE,@MinutosVuelo,@fechaDespegue) 

SELECT @fechita


SET @usoOrigen = (SELECT l.lug_zona_horaria
									FROM Lugar l
									WHERE l.lug_nombre = @CiudadOrigen)

SET @usoDestino = (SELECT l.lug_zona_horaria
									FROM Lugar l
									WHERE l.lug_nombre = @CiudadDestino)

IF (@usoOrigen > @usoDestino)
BEGIN 
SET @diferencia = ABS(@usoOrigen - @usoDestino)
SET @fechita = DATEADD(HOUR,(@diferencia*-1),@fechita)
END;

IF (@usoOrigen < @usoDestino)
BEGIN 
SET @diferencia = ABS(@usoOrigen - @usoDestino)
SET @fechita = DATEADD(HOUR,@diferencia,@fechita)
END;

SELECT @fechita

END








GO

-- ----------------------------
-- Procedure structure for M04_CalcularMinutosVuelo
-- ----------------------------
DROP PROCEDURE [M04_CalcularMinutosVuelo]
GO
CREATE PROCEDURE [M04_CalcularMinutosVuelo]
  @MatriculaAvion varchar(100) ,
  @idRuta int 
AS
BEGIN

DECLARE @MaxVel FLOAT;
DECLARE @VelocidadPromedio FLOAT;
DECLARE @DistRuta FLOAT;
DECLARE @MinutosVuelo INT;

SET @MaxVel = (SELECT a.avi_max_vel
							 FROM Avion a
							 WHERE a.avi_matricula = @MatriculaAvion)

SET @VelocidadPromedio = (@MaxVel * 0.6);

SET @DistRuta = (SELECT r.rut_distancia
								 FROM Ruta r
								 WHERE r.rut_id = @idRuta)

SET @MinutosVuelo = ((@DistRuta/@VelocidadPromedio)*60)

SELECT @MinutosVuelo

END
GO

-- ----------------------------
-- Procedure structure for M04_CrearVuelo
-- ----------------------------
DROP PROCEDURE [M04_CrearVuelo]
GO
CREATE PROCEDURE [M04_CrearVuelo]
(
@CodVuelo VARCHAR(100) ,
@CiudadOrigen VARCHAR(100),
@CiudadDestino VARCHAR(100),
@FechaDespegue datetime ,
@Status VARCHAR(100) ,
@FechaAterrizaje datetime ,
@MatriculaAvion VARCHAR(100)
)
AS
BEGIN
DECLARE @idRuta int
DECLARE @idvuelo int
DECLARE @idavion int

SET @idvuelo = (SELECT MAX(v.vue_id)+1
								FROM Vuelo v)


SET @idavion = (SELECT a.avi_id
								FROM Avion a
								WHERE a.avi_matricula = @MatriculaAvion)


SET @idRuta = (SELECT r.rut_id 
							 FROM Ruta r
							 WHERE r.rut_FK_lugar_origen = (SELECT ll.lug_id
																							FROM Lugar ll
																							WHERE ll.lug_nombre = @CiudadOrigen)
							 AND r.rut_FK_lugar_destino = (SELECT ll.lug_id
																						 FROM Lugar ll
																						 WHERE ll.lug_nombre = @CiudadDestino))



INSERT INTO Vuelo (vue_codigo,vue_fk_ruta,vue_fecha_despegue,vue_status,vue_fecha_aterrizaje,vue_fk_avion)
VALUES (@CodVuelo,@idRuta,@FechaDespegue,@Status,@FechaAterrizaje,@idavion);


END
GO

-- ----------------------------
-- Procedure structure for M04_DesactivarVuelo
-- ----------------------------
DROP PROCEDURE [M04_DesactivarVuelo]
GO
CREATE PROCEDURE [M04_DesactivarVuelo](
@id int)
AS
BEGIN
  UPDATE Vuelo
  SET vue_status = 'inactivo'
  WHERE vue_id = @id
END
GO

-- ----------------------------
-- Procedure structure for M04_DetalleAvion
-- ----------------------------
DROP PROCEDURE [M04_DetalleAvion]
GO
CREATE PROCEDURE [M04_DetalleAvion]
( 
@MatriculaAvion INT
)
AS
BEGIN
DECLARE @ModeloAvion VARCHAR;
DECLARE @CapacidadPasajeros INT;
DECLARE @DistanciaMaxima INT;
DECLARE @VelocidadMaxima INT;

SET @ModeloAvion = (SELECT a.avi_modelo
										FROM Avion a
										WHERE a.avi_matricula = @MatriculaAvion)

SET @CapacidadPasajeros = (SELECT a.avi_pasajeros_turista + a.avi_pasajeros_ejecutiva + a.avi_pasajeros_vip
										      FROM Avion a 
													WHERE a.avi_matricula = @MatriculaAvion)

SET @DistanciaMaxima = (SELECT a.avi_max_dist
												FROM Avion a
												WHERE a.avi_matricula = @MatriculaAvion) 

SET @VelocidadMaxima = (SELECT a.avi_max_vel
												FROM Avion a
												WHERE a.avi_matricula = @MatriculaAvion) 

END
GO

-- ----------------------------
-- Procedure structure for M04_DetalleAvion_Distancia
-- ----------------------------
DROP PROCEDURE [M04_DetalleAvion_Distancia]
GO
CREATE PROCEDURE [M04_DetalleAvion_Distancia]
( 
@MatriculaAvion VARCHAR(100)
)
AS
BEGIN

DECLARE @distancia  varchar(100);

SET @distancia = (SELECT a.avi_max_dist 
							FROM Avion a
							WHERE a.avi_matricula = @MatriculaAvion)

SELECT @distancia

END
GO

-- ----------------------------
-- Procedure structure for M04_DetalleAvion_Modelo
-- ----------------------------
DROP PROCEDURE [M04_DetalleAvion_Modelo]
GO
CREATE PROCEDURE [M04_DetalleAvion_Modelo]
( 
@MatriculaAvion VARCHAR(100)
)
AS
BEGIN

SELECT a.avi_modelo
FROM Avion a
WHERE a.avi_matricula = @MatriculaAvion

END
GO

-- ----------------------------
-- Procedure structure for M04_DetalleAvion_Pasajeros
-- ----------------------------
DROP PROCEDURE [M04_DetalleAvion_Pasajeros]
GO
CREATE PROCEDURE [M04_DetalleAvion_Pasajeros]
( 
@MatriculaAvion VARCHAR(100)
)
AS
BEGIN

DECLARE @cantidad  varchar(100);

SET @cantidad = (SELECT a.avi_pasajeros_turista + a.avi_pasajeros_ejecutiva + a.avi_pasajeros_vip 
							FROM Avion a
							WHERE a.avi_matricula = @MatriculaAvion)

SELECT @cantidad

END
GO

-- ----------------------------
-- Procedure structure for M04_DetalleAvion_Velocidad
-- ----------------------------
DROP PROCEDURE [M04_DetalleAvion_Velocidad]
GO
CREATE PROCEDURE [M04_DetalleAvion_Velocidad]
( 
@MatriculaAvion VARCHAR(100)
)
AS
BEGIN

DECLARE @velocidad  varchar(100);

SET @velocidad = (SELECT a.avi_max_vel 
							FROM Avion a
							WHERE a.avi_matricula = @MatriculaAvion)

SELECT @velocidad

END
GO

-- ----------------------------
-- Procedure structure for M04_ModificarVuelo
-- ----------------------------
DROP PROCEDURE [M04_ModificarVuelo]
GO
CREATE PROCEDURE [M04_ModificarVuelo]
(
@CodVuelo VARCHAR(100) ,
@CiudadOrigen VARCHAR(100),
@CiudadDestino VARCHAR(100),
@FechaDespegue datetime ,
@Status VARCHAR(100) ,
@FechaAterrizaje datetime ,
@MatriculaAvion VARCHAR(100),
@idVuelo int
)
AS
BEGIN
DECLARE @idRuta int
DECLARE @idavion int



SET @idavion = (SELECT a.avi_id
								FROM Avion a
								WHERE a.avi_matricula = @MatriculaAvion)


SET @idRuta = (SELECT r.rut_id 
							 FROM Ruta r
							 WHERE r.rut_FK_lugar_origen = (SELECT ll.lug_id
																							FROM Lugar ll
																							WHERE ll.lug_nombre = @CiudadOrigen)
							 AND r.rut_FK_lugar_destino = (SELECT ll.lug_id
																						 FROM Lugar ll
																						 WHERE ll.lug_nombre = @CiudadDestino))




UPDATE Vuelo
SET vue_codigo = @CodVuelo, vue_fk_ruta = @idRuta, vue_fecha_despegue = @FechaDespegue, 
		vue_status = @Status ,vue_fecha_aterrizaje = @FechaAterrizaje, vue_fk_avion = @idavion
WHERE vue_id = @idVuelo
END
GO

-- ----------------------------
-- Procedure structure for M04_ValidarAvionParaRuta
-- ----------------------------
DROP PROCEDURE [M04_ValidarAvionParaRuta]
GO
CREATE PROCEDURE [M04_ValidarAvionParaRuta]
(
@CiudadOrigen VARCHAR(100),
@CiudadDestino VARCHAR(100)
)
AS
BEGIN


SELECT a.avi_matricula
FROM Avion a
WHERE a.avi_max_dist >= (SELECT r.rut_distancia
												 FROM Ruta r
												 WHERE r.rut_id = (SELECT r.rut_id 
																					FROM Ruta r
																					WHERE r.rut_FK_lugar_origen = (SELECT ll.lug_id
																					FROM Lugar ll
																					WHERE ll.lug_nombre = @CiudadOrigen)
																					AND r.rut_FK_lugar_destino = (SELECT ll.lug_id
																					FROM Lugar ll
																					WHERE ll.lug_nombre = @CiudadDestino))
AND a.avi_disponibilidad = 1)

END
GO

-- ----------------------------
-- Procedure structure for M06_Pasajero_XClase
-- ----------------------------
DROP PROCEDURE [M06_Pasajero_XClase]
GO
CREATE PROCEDURE [M06_Pasajero_XClase]
( 
@MatriculaAvion VARCHAR(100)
)
AS
BEGIN
DECLARE @PasajerosTurista INT;
DECLARE @PasajerosEjecutiva INT;
DECLARE @PasajerosVip INT;


SET @PasajerosTurista = (SELECT a.avi_pasajeros_turista
										      FROM Avion a 
													WHERE a.avi_matricula = @MatriculaAvion)

SET @PasajerosEjecutiva = (SELECT a.avi_pasajeros_ejecutiva 
										      FROM Avion a 
													WHERE a.avi_matricula = @MatriculaAvion) 

SET @PasajerosVip  = (SELECT a.avi_pasajeros_vip
										      FROM Avion a 
													WHERE a.avi_matricula = @MatriculaAvion)

SELECT @PasajerosEjecutiva,@PasajerosTurista,@PasajerosVip 

END
GO

-- ----------------------------
-- Procedure structure for M12_CambiarStatus
-- ----------------------------
DROP PROCEDURE [M12_CambiarStatus]
GO
CREATE procedure [M12_CambiarStatus] (
	@activo varchar(20),
	@id int
)
AS
BEGIN

	DECLARE @temp int
		SELECT @temp = COUNT(U.USU_ID) 
		FROM USUARIO U, ROL R
		WHERE R.ROL_ID = U.USU_FK_ROL AND R.ROL_ID = 1
			AND u.usu_activo LIKE 'Activo'

	if (@activo = 'Activo')
	BEGIN
		IF @temp = 1
			THROW 55567, 'Debe existir al menos un Usuario Administrador Activo', 1
		UPDATE [dbo].[Usuario]
			SET
				[usu_activo] = 'Inactivo'
			WHERE
				[usu_id] = @id
		END
	ELSE BEGIN
		UPDATE [dbo].[Usuario]
		SET
				[usu_activo] = 'Activo'
			WHERE
				[usu_id] = @id
	END

END

GO

-- ----------------------------
-- Procedure structure for M12_ConsultarUltimoUsuarioID
-- ----------------------------
DROP PROCEDURE [M12_ConsultarUltimoUsuarioID]
GO
CREATE PROCEDURE [M12_ConsultarUltimoUsuarioID]
AS
BEGIN
  SELECT MAX(U.usu_id) as usuID
	FROM [dbo].Usuario as U
END
GO

-- ----------------------------
-- Procedure structure for M12_ConsultarUsuario
-- ----------------------------
DROP PROCEDURE [M12_ConsultarUsuario]
GO
CREATE PROCEDURE [M12_ConsultarUsuario]
@correo 	VARCHAR(255)

AS
BEGIN
  SELECT  
		U.USU_NOMBRE nombre,
    U.USU_APELLIDO apellido,
    U.USU_CORREO correo,
    U.USU_FECHACREACION fecha,
    U.USU_ACTIVO activo,
    R.rol_nombre rol,
		U.USU_FK_ROL rolID,
		U.USU_ID usuID
	FROM [dbo].Usuario as U,
		[dbo].ROL R
	WHERE U.usu_correo  LIKE @correo
	AND U.usu_fk_rol IS NOT NULL
END
GO

-- ----------------------------
-- Procedure structure for M12_ConsultarUsuarioID
-- ----------------------------
DROP PROCEDURE [M12_ConsultarUsuarioID]
GO


CREATE PROCEDURE [M12_ConsultarUsuarioID]
@id	int
AS
BEGIN
  SELECT 
		U.USU_NOMBRE nombre,
    U.USU_APELLIDO apellido,
    U.USU_CORREO correo,
    U.USU_FECHACREACION fecha,
    U.USU_ACTIVO activo,
    R.rol_nombre rol,
		U.USU_FK_ROL rolID,
		U.USU_ID usuID
	FROM [dbo].Usuario as U,
			 [dbo].ROL R
	WHERE 
		@id = U.usu_id
		AND R.ROL_ID = U.USU_FK_ROL 
END

GO

-- ----------------------------
-- Procedure structure for M12_ContarUsuario
-- ----------------------------
DROP PROCEDURE [M12_ContarUsuario]
GO
CREATE PROCEDURE [M12_ContarUsuario]
AS
BEGIN
  SELECT COUNT(U.usu_id) as usunum
	FROM [dbo].Usuario as U
END
GO

-- ----------------------------
-- Procedure structure for M12_CrearUsuario
-- ----------------------------
DROP PROCEDURE [M12_CrearUsuario]
GO
CREATE procedure [M12_CrearUsuario] (
  @nombre varchar(50),
  @apellido varchar(50),
  @correo varchar(255),
  @contraseña varchar(32),
  @rol int,
	@fecha date,
	@activo varchar(20)
)
AS
BEGIN
  INSERT INTO dbo.Usuario
  (
    usu_nombre,
    usu_apellido,
    usu_correo,
    usu_contraseña,
    usu_fk_rol,
		usu_fechaCreacion,
		usu_activo
	)
  VALUES
  (
    @nombre,
    @apellido,
    @correo,
    @contraseña,
    @rol,
		@fecha,
		@activo
  )
END

GO

-- ----------------------------
-- Procedure structure for M12_EliminarUsuario
-- ----------------------------
DROP PROCEDURE [M12_EliminarUsuario]
GO
CREATE PROCEDURE [M12_EliminarUsuario]
@id int
AS

BEGIN
	DECLARE @temp int, @idUsuario int
		SELECT @temp = COUNT(U.USU_ID) 
			FROM USUARIO U, ROL R
			WHERE R.ROL_ID = U.USU_FK_ROL AND R.ROL_ID = 1
				AND u.usu_activo LIKE 'Activo'
		
	IF @temp = 1
		BEGIN
			SELECT @idUsuario = count(U.USU_ID)
				FROM USUARIO U, ROL R
				WHERE R.ROL_ID = U.USU_FK_ROL AND R.ROL_ID = 1
					AND u.usu_activo LIKE 'Activo' AND U.USU_ID = @id
			IF @idUsuario = 1
				BEGIN
					THROW 55567, 'Debe existir al menos un usuario administrador activo', 1
				END
			ELSE
				BEGIN
					DELETE FROM Login 
						WHERE log_idusuario = @id	
					DELETE FROM USUARIO  
						WHERE USUARIO.USU_ID = @id	
				END
		END
		ELSE
				BEGIN
					DELETE FROM Login 
						WHERE log_idusuario = @id	
					DELETE FROM USUARIO  
						WHERE USUARIO.USU_ID = @id	
				END
END
GO

-- ----------------------------
-- Procedure structure for M12_ListarRoles
-- ----------------------------
DROP PROCEDURE [M12_ListarRoles]
GO


CREATE procedure [M12_ListarRoles]
AS
BEGIN
  SELECT
        R.ROL_NOMBRE rol,
	   R.ROL_ID rolID
  FROM
    ROL R
  WHERE
    (R.ROL_ID < 2) or (R.ROL_ID > 3) 

END

GO

-- ----------------------------
-- Procedure structure for M12_ListarUsuarios
-- ----------------------------
DROP PROCEDURE [M12_ListarUsuarios]
GO

CREATE procedure [M12_ListarUsuarios] 
AS
BEGIN
  SELECT
    U.USU_NOMBRE nombre,
    U.USU_APELLIDO apellido,
    U.USU_CORREO correo,
    U.USU_FECHACREACION fecha,
    U.USU_ACTIVO activo,
    R.rol_nombre rol,
		U.USU_FK_ROL rolID,
		U.USU_ID usuID
  FROM
    USUARIO U ,
    ROL R
  WHERE
    R.ROL_ID = U.USU_FK_ROL AND U.USU_FK_ROL IS NOT NULL
		AND (R.ROL_ID < 2 OR R.ROL_ID > 3)

END

GO

-- ----------------------------
-- Procedure structure for M12_ModificarUsuario
-- ----------------------------
DROP PROCEDURE [M12_ModificarUsuario]
GO

CREATE procedure [M12_ModificarUsuario] (
	@nombre varchar(50),
  @apellido varchar(50),
  @correo varchar(255),
  @contraseña varchar(32),
  @rol int,
	@activo varchar(20),
	@id int
)
AS
BEGIN
	if (@contraseña is null or @contraseña = '')
	BEGIN	
		UPDATE [dbo].[Usuario]
			SET
				[usu_nombre] = @nombre,
				[usu_apellido] = @apellido,	
				[usu_correo] = @correo,
				[usu_fk_rol] = @rol,	
				[usu_activo] = @activo
			WHERE
				[usu_id] = @id
		END
	ELSE BEGIN
		UPDATE [dbo].[Usuario]
		SET
			[usu_nombre] = @nombre,
			[usu_apellido] = @apellido,	
			[usu_correo] = @correo,
			[usu_contraseña] = @contraseña,
			[usu_fk_rol] = @rol,	
			[usu_activo] = @activo
		WHERE
			[usu_id] = @id
	END	
  
END

GO

-- ----------------------------
-- Procedure structure for M20_ActualizarEstadoReservaHabitacion
-- ----------------------------
DROP PROCEDURE [M20_ActualizarEstadoReservaHabitacion]
GO
-- =============================================
-- Author:		Roysbert Salinas
-- Create date: 28/11/2016
-- Description:	
-- RES_RF_FO_07_05 | El sistema deberá permitir ocupar alguna reserva realizada.
-- RES_RF_FO_07_06 | El sistema deberá permitir liberar alguna reserva realizada.
-- =============================================
CREATE PROCEDURE [M20_ActualizarEstadoReservaHabitacion]
	@id_reserva int,
		@estado int
AS
BEGIN
	DECLARE 
		@estatus int = -1, 
		@mensaje varchar(max) = 'Error desconocido...', 
		@referencia int = 0
	BEGIN TRY
		IF (@id_reserva > 0)
		BEGIN
			UPDATE [dbo].[Reserva_Habitacion]		
			SET [rha_estado] = @estado
			WHERE 		
				[rha_id] = @id_reserva
		END
		ELSE
		BEGIN
			THROW 60000, 'No es posible actualizar por que la reserva no existe.', 1
		END
		SELECT 
			@estatus = 0, 
			@mensaje = 'Se guardaron los cambios correctamente...', 
			@referencia = @id_reserva
	END TRY
	BEGIN CATCH
		SELECT @estatus = ERROR_STATE(), @mensaje = ERROR_MESSAGE()
	END CATCH
	SELECT 
		@estatus as "Estatus",
		@mensaje as "Mensaje",
		@referencia as "Referencia"
END

GO

-- ----------------------------
-- Procedure structure for M20_BuscarHotelesPorCiudad
-- ----------------------------
DROP PROCEDURE [M20_BuscarHotelesPorCiudad]
GO
-- =============================================
-- Author:		Roysbert Salinas
-- Create date: 28/11/2016
-- Description:
-- RES_RF_FO_07_02 | El sistema deberá permitir ver detalle de una reserva (Numero de Habitacion).
-- =============================================
CREATE PROCEDURE [M20_BuscarHotelesPorCiudad]	
	@id_ciudad int,
	@cantidad_dias int,
	@fecha_llegada datetime
AS
BEGIN
	SELECT 
			[DATA].[hot_id],
			[DATA].[hot_nombre],
			[DATA].[hot_email],
			[DATA].[hot_fk_ciudad],
			[DATA].[hot_cantidad_habitaciones_disponible]
	FROM (
		SELECT
			[HOL].[hot_id],
			[HOL].[hot_nombre],
			[HOL].[hot_email],
			[HOL].[hot_fk_ciudad],
			(
				SELECT [HOL].[hot_cantidad_habitaciones] - COUNT(*)
				FROM [dbo].[M20_ConflictosReservaHabitacion]([HOL].[hot_id], @cantidad_dias, @fecha_llegada)
			) AS hot_cantidad_habitaciones_disponible
		FROM [dbo].[Hotel] [HOL]
		WHERE [HOL].[hot_fk_ciudad] = @id_ciudad
	) [DATA]
	WHERE [DATA].[hot_cantidad_habitaciones_disponible] > 0
	ORDER BY [DATA].[hot_nombre]
END

GO

-- ----------------------------
-- Procedure structure for M20_DetalleReservaHabitacion
-- ----------------------------
DROP PROCEDURE [M20_DetalleReservaHabitacion]
GO
-- =============================================
-- Author:		Roysbert Salinas
-- Create date: 28/11/2016
-- Description:
-- RES_RF_FO_07_02 | El sistema deberá permitir ver detalle de una reserva (Numero de Habitacion).
-- =============================================
CREATE PROCEDURE [M20_DetalleReservaHabitacion]	
	@id_reserva int	
AS
BEGIN
	BEGIN TRY
		UPDATE [dbo].[Reserva_Habitacion]
		-- Reserva Expiro.
		SET [rha_estado] = 2                        
		WHERE 
		  -- Del mismo usuario
		  [rha_id] = @id_reserva
		  AND
		  -- Reserva Ocupada y Fecha de reserva Culmino.	  
		  (  ([rha_estado] = 0 AND DATEADD(day, [rha_cantidad_dias], [rha_fecha_llegada]) < GETDATE())
			-- Reserva Activa y Fecha de reserva Expiro.
		  OR ([rha_estado] = 1 AND [rha_fecha_llegada] < GETDATE()) 
		  )
	END TRY
	BEGIN CATCH
		
	END CATCH

	SELECT
		[HOL].[hot_id],
		[HOL].[hot_nombre],
		[USU].[usu_id],
		[USU].[usu_apellido] + ', ' + [USU].[usu_nombre] AS fullname,
		[RHA].[rha_id],
		[RHA].[rha_habitacion],
		[RHA].[rha_fecha_llegada],
		[RHA].[rha_cantidad_dias],
		DATEADD(dd, [rha_cantidad_dias], [rha_fecha_llegada]) as rha_fecha_partida,
		[RHA].[rha_estado]
	FROM [dbo].[Reserva_Habitacion] [RHA]
	JOIN [dbo].[Hotel] [HOL] ON [RHA].[rha_fk_hot_id] = [HOL].[hot_id]
	JOIN [dbo].[Usuario] [USU] ON [RHA].[rha_fk_usu_id] = [USU].[usu_id]
	WHERE [RHA].[rha_id] = @id_reserva
		
END

GO

-- ----------------------------
-- Procedure structure for M20_GenerarReservaHabitacion
-- ----------------------------
DROP PROCEDURE [M20_GenerarReservaHabitacion]
GO
-- =============================================
-- Author:		Roysbert Salinas
-- Create date: 28/11/2016
-- Description:	
-- RES_RF_FO_07_03 | El sistema deberá permitir realizar una reserva de habitación.
-- RES_RF_FO_07_07 | El sistema deberá permitir indicar si hay reservas disponibles alguna reserva realizada.
-- =============================================
CREATE PROCEDURE [M20_GenerarReservaHabitacion]
	@hot_id int,
	@usu_id int,
	@cantidad_dias int,
	@fecha_llegada datetime
AS
BEGIN	
	DECLARE 
		@estatus int = -1, 
		@mensaje varchar(max) = 'Error desconocido...',
		@referencia int = 0
	DECLARE @habitacion int = 0
	BEGIN TRY		
		SELECT TOP 1 @habitacion = [HAB].[habitacion]
			FROM [dbo].[M20_HabitacionesByHotel](@hot_id) [HAB] 
			LEFT JOIN [dbo].[M20_ConflictosReservaHabitacion](@hot_id, @cantidad_dias, @fecha_llegada) [RHA] ON [RHA].[rha_habitacion] = [HAB].[habitacion]				
			WHERE [RHA].[rha_habitacion] IS NULL

			IF @habitacion > 0
				EXEC [dbo].[M20_GuardarReservaHabitacion] 0, @habitacion, @cantidad_dias, @fecha_llegada, @hot_id, @usu_id, 1
			ELSE
				THROW 60000, 'No hay habitaciones disponibles', 1
	END TRY
	BEGIN CATCH		
		SELECT 
			ERROR_STATE() as "Estatus",
			ERROR_MESSAGE() as "Mensaje",
			@referencia as "Referencia"
	END CATCH
END

GO

-- ----------------------------
-- Procedure structure for M20_GuardarReservaHabitacion
-- ----------------------------
DROP PROCEDURE [M20_GuardarReservaHabitacion]
GO
-- =============================================
-- Author:		Roysbert Salinas
-- Create date: 28/11/2016
-- Description:	
-- RES_RF_FO_07_03 | El sistema deberá permitir realizar una reserva de habitación.
-- RES_RF_FO_07_04 | El sistema deberá permitir modificar alguna reserva realizada.
-- RES_RF_FO_07_07 | El sistema deberá permitir indicar si hay reservas disponibles alguna reserva realizada.
-- =============================================
CREATE PROCEDURE [M20_GuardarReservaHabitacion]
	@id_reserva int,
	@habitacion int,
	@cantidad_dias int, 
	@fecha_llegada datetime,
	@hot_id int,
	@usu_id int,
	@estado int = 1
AS
BEGIN	
	DECLARE 
		@estatus int = -1, 
		@mensaje varchar(max) = 'Error desconocido...', 
		@referencia int = 0
	BEGIN TRY
		IF EXISTS(
				SELECT 1
				FROM [dbo].[M20_ConflictosReservaHabitacion](@hot_id, @cantidad_dias, @fecha_llegada) [RHA]
				WHERE [RHA].[rha_habitacion] =  @habitacion
			)
		BEGIN
			THROW 60000, 'Ya existe una reservacion activa o en uso para esta habitacion en este hotel.', 1
		END
		
		IF (@id_reserva > 0)
		BEGIN
			UPDATE [dbo].[Reserva_Habitacion]		
			SET [rha_habitacion] = @habitacion, 
				[rha_cantidad_dias] = @cantidad_dias, 
				[rha_fecha_llegada] = @fecha_llegada,
				[rha_fk_hot_id] = @hot_id,
				[rha_fk_usu_id] = @usu_id,
				[rha_estado] = @estado
			WHERE 		
				[rha_id] = @id_reserva
		END
		ELSE
		BEGIN
			SELECT @id_reserva = NEXT VALUE FOR dbo.Sec_ReservaHabitacion
			INSERT INTO [dbo].[Reserva_Habitacion] 
				([rha_id], [rha_habitacion], [rha_cantidad_dias], [rha_fecha_llegada], [rha_fecha_reservacion], [rha_fk_hot_id], [rha_fk_usu_id], [rha_estado])
				VALUES
				(@id_reserva, @habitacion, @cantidad_dias, @fecha_llegada, getdate(), @hot_id, @usu_id, 1)
		END
		SELECT 
			@estatus = 0, 
			@mensaje = 'Se guardaron los cambios correctamente...',
			@referencia = @id_reserva
	END TRY
	BEGIN CATCH
		SELECT @estatus = ERROR_STATE(), @mensaje = ERROR_MESSAGE()
	END CATCH

	SELECT 
		@estatus as "Estatus",
		@mensaje as "Mensaje",
		@referencia as "Referencia"
		
END

GO

-- ----------------------------
-- Procedure structure for M20_HotelHistorialReservaHabitacion
-- ----------------------------
DROP PROCEDURE [M20_HotelHistorialReservaHabitacion]
GO
-- =============================================
-- Author:		Roysbert Salinas
-- Create date: 28/11/2016
-- Description:	
-- RES_RF_FO_07_01 | El sistema deberá permitir ver su historial de reservas.
-- =============================================
CREATE PROCEDURE [M20_HotelHistorialReservaHabitacion]	
	@id_hotel int	
AS
BEGIN
	BEGIN TRY
		UPDATE [dbo].[Reserva_Habitacion]
		-- Reserva Expiro.
		SET [rha_estado] = 2                        
		WHERE 
		  -- Del mismo usuario
		  [rha_fk_hot_id] = @id_hotel
		  AND	  
		  -- Reserva Ocupada y Fecha de reserva Culmino.	  
		  (  ([rha_estado] = 0 AND DATEADD(day, [rha_cantidad_dias], [rha_fecha_llegada]) < GETDATE())
			-- Reserva Activa y Fecha de reserva Expiro.
		  OR ([rha_estado] = 1 AND [rha_fecha_llegada] < GETDATE()) 
		  )
	END TRY
	BEGIN CATCH
		
	END CATCH

	SELECT
		[HOL].[hot_id],
		[HOL].[hot_nombre],
		[USU].[usu_id],
		[USU].[usu_apellido] + ', ' + [USU].[usu_nombre] AS fullname,
		[RHA].[rha_id],
		[RHA].[rha_habitacion],
		[RHA].[rha_fecha_llegada],
		[RHA].[rha_cantidad_dias],
		DATEADD(dd, [rha_cantidad_dias], [rha_fecha_llegada]) as rha_fecha_partida,
		[RHA].[rha_estado]
	FROM [dbo].[Reserva_Habitacion] [RHA]
	JOIN [dbo].[Hotel] [HOL] ON [RHA].[rha_fk_hot_id] = [HOL].[hot_id]
	JOIN [dbo].[Usuario] [USU] ON [RHA].[rha_fk_usu_id] = [USU].[usu_id]
	WHERE [RHA].[rha_fk_hot_id] = @id_hotel
	ORDER BY [rha_fecha_llegada] DESC
		
END

GO

-- ----------------------------
-- Procedure structure for M20_ObtenerCiudades
-- ----------------------------
DROP PROCEDURE [M20_ObtenerCiudades]
GO
-- =============================================
-- Author:		Roysbert Salinas
-- Create date: 28/11/2016
-- Description:	
-- RES_RF_FO_07_01 | El sistema deberá permitir ver su historial de reservas.
-- =============================================
CREATE PROCEDURE [M20_ObtenerCiudades]		
AS
BEGIN
	SELECT DISTINCT
		[LUG].[lug_id],
		[LUG].[lug_nombre]
	FROM [dbo].[Lugar] [LUG]
	JOIN [dbo].[Hotel] [HOT] ON [LUG].[lug_id] = [HOT].[hot_fk_ciudad]
	WHERE [LUG].[lug_tipo_lugar] = 'ciudad'
	ORDER BY [LUG].[lug_nombre]		
END

GO

-- ----------------------------
-- Procedure structure for M20_UsuarioHistorialReservaHabitacion
-- ----------------------------
DROP PROCEDURE [M20_UsuarioHistorialReservaHabitacion]
GO
-- =============================================
-- Author:		Roysbert Salinas
-- Create date: 28/11/2016
-- Description:	
-- RES_RF_FO_07_01 | El sistema deberá permitir ver su historial de reservas.
-- =============================================
CREATE PROCEDURE [M20_UsuarioHistorialReservaHabitacion]	
	@id_usuario int	
AS
BEGIN
	BEGIN TRY
		UPDATE [dbo].[Reserva_Habitacion]
		-- Reserva Expiro.
		SET [rha_estado] = 2                        
		WHERE 
		  -- Del mismo usuario
		  [rha_fk_usu_id] = @id_usuario
		  AND	  
		  -- Reserva Ocupada y Fecha de reserva Culmino.	  
		  (  ([rha_estado] = 0 AND DATEADD(day, [rha_cantidad_dias], [rha_fecha_llegada]) < GETDATE())
			-- Reserva Activa y Fecha de reserva Expiro.
		  OR ([rha_estado] = 1 AND [rha_fecha_llegada] < GETDATE()) 
		  )
	END TRY
	BEGIN CATCH
		
	END CATCH

	SELECT
		[HOL].[hot_id],
		[HOL].[hot_nombre],
		[USU].[usu_id],
		[USU].[usu_apellido] + ', ' + [USU].[usu_nombre] AS fullname,
		[RHA].[rha_id],
		[RHA].[rha_habitacion],
		[RHA].[rha_fecha_llegada],
		[RHA].[rha_cantidad_dias],
		DATEADD(dd, [rha_cantidad_dias], [rha_fecha_llegada]) as rha_fecha_partida,
		[RHA].[rha_estado]
	FROM [dbo].[Reserva_Habitacion] [RHA]
	JOIN [dbo].[Hotel] [HOL] ON [RHA].[rha_fk_hot_id] = [HOL].[hot_id]
	JOIN [dbo].[Usuario] [USU] ON [RHA].[rha_fk_usu_id] = [USU].[usu_id]
	WHERE [RHA].[rha_fk_usu_id] = @id_usuario
	ORDER BY [rha_fecha_llegada] DESC
		
END

GO

-- ----------------------------
-- Procedure structure for M24_AgregarCabinas
-- ----------------------------
DROP PROCEDURE [M24_AgregarCabinas]
GO
CREATE PROCEDURE [M24_AgregarCabinas]
(
@nombrecabina varchar(20),
@precio float,
@fk_id_crucero int
)
AS
BEGIN
  INSERT INTO dbo.Cabina (cab_nombre, cab_precio, cab_estatus, cab_fk_crucero)
	VALUES (@nombrecabina, @precio, 'activo', @fk_id_crucero);
END

GO

-- ----------------------------
-- Procedure structure for M24_AgregarCamarote
-- ----------------------------
DROP PROCEDURE [M24_AgregarCamarote]
GO
CREATE PROCEDURE [M24_AgregarCamarote]
(
@cantidad_camas int,
@tipo_cama varchar(20),
@fk_id_cabina int
)
AS
BEGIN
  INSERT INTO dbo.Camarote (cam_cantidad_cama, cam_tipo_cama,cam_estatus, cam_fk_cabina)
	VALUES (@cantidad_camas, @tipo_cama,'activo', @fk_id_cabina);
END
GO

-- ----------------------------
-- Procedure structure for M24_AgregarCrucero
-- ----------------------------
DROP PROCEDURE [M24_AgregarCrucero]
GO
CREATE PROCEDURE [M24_AgregarCrucero]
(
@nombrecrucero varchar(20),
@compania varchar(20),
@capacidad int,
@imagen varchar(200)
)
AS
BEGIN
  INSERT INTO dbo.Crucero (cru_nombre, cru_compania, cru_capacidad, cru_estatus, cru_image)
	VALUES (@nombrecrucero, @compania, @capacidad, 'activo', @imagen);
END
GO

-- ----------------------------
-- Procedure structure for M24_AgregarItinerario
-- ----------------------------
DROP PROCEDURE [M24_AgregarItinerario]
GO
CREATE PROCEDURE [M24_AgregarItinerario]
(

@fecha_inicio date,
@fecha_fin date,
@fk_crucero int,
@fk_ruta int
)
AS
BEGIN
  INSERT INTO dbo.Itinerario_Crucero (icru_fecha_inicio, icru_fecha_fin, icru_estatus, icru_fk_crucero, icru_fk_ruta)
	VALUES (@fecha_inicio, @fecha_fin, 'activo', @fk_crucero, @fk_ruta);
END
GO

-- ----------------------------
-- Procedure structure for M24_CambiarEstatusCabina
-- ----------------------------
DROP PROCEDURE [M24_CambiarEstatusCabina]
GO
CREATE PROCEDURE [M24_CambiarEstatusCabina]
(
@idCabina int
)
AS
BEGIN 
declare @estatus varchar(20)
set @estatus = (select cab.cab_estatus from cabina cab where cab.cab_id = @idCabina)
 if ( @estatus = 'activo' )
		BEGIN
			update cabina
			SET cab_estatus='inactivo'
			where cab_id = @idCabina;

			update Camarote
			set cam_estatus='inactivo'
			where cam_fk_cabina = @idCabina;
		END
	else if ( @estatus = 'inactivo' )
		BEGIN
			update cabina
			SET cab_estatus='activo'
			where cab_id = @idCabina;

			update Camarote
			set cam_estatus='activo'
			where cam_fk_cabina = @idCabina;
		end 
END
GO

-- ----------------------------
-- Procedure structure for M24_CambiarEstatusCamarote
-- ----------------------------
DROP PROCEDURE [M24_CambiarEstatusCamarote]
GO
CREATE PROCEDURE [M24_CambiarEstatusCamarote]
(
@idCamarote int
)
AS
BEGIN
	declare @estatus varchar(20)
	set @estatus = (select cam.cam_estatus from camarote cam where cam.cam_id = @idCamarote)
	if ( @estatus = 'activo' )
		BEGIN
			update Camarote
			set cam_estatus='inactivo'
			where cam_id = @idCamarote;
		END
  else if ( @estatus = 'inactivo' )
		BEGIN
			update Camarote
			set cam_estatus='activo'
			where cam_id = @idCamarote;
		end 
END


GO

-- ----------------------------
-- Procedure structure for M24_CambiarEstatusCrucero
-- ----------------------------
DROP PROCEDURE [M24_CambiarEstatusCrucero]
GO
CREATE PROCEDURE [M24_CambiarEstatusCrucero]
(
@idCrucero int
)
AS
BEGIN 
declare @estatus varchar(20)
set @estatus = (select cru.cru_estatus from crucero cru where cru.cru_id = @idCrucero)
 if ( @estatus = 'activo' )
		BEGIN
			update crucero
			SET cru_estatus='inactivo'
			where cru_id = @idCrucero;

			update cabina
			set cab_estatus='inactivo'
			where cab_fk_crucero = @idCrucero;

			update Camarote
			set cam_estatus = 'inactivo'
			where cam_fk_cabina in(select cab.cab_id from cabina cab where cab.cab_fk_crucero = @idCrucero);
		END
	else if ( @estatus = 'inactivo' )
		BEGIN
			update crucero
			SET cru_estatus='activo'
			where cru_id = @idCrucero;

			update cabina
			set cab_estatus='activo'
			where cab_fk_crucero = @idCrucero;

update Camarote
			set cam_estatus = 'activo'
			where cam_fk_cabina in(select cab.cab_id from cabina cab where cab.cab_fk_crucero = @idCrucero);
		end 
END
GO

-- ----------------------------
-- Procedure structure for M24_CambiarEstatusItinerario
-- ----------------------------
DROP PROCEDURE [M24_CambiarEstatusItinerario]
GO
CREATE PROCEDURE [M24_CambiarEstatusItinerario]
(
@idItinerario INT
)
AS
BEGIN
  declare @estatus varchar(20)
set @estatus = (select i.ic_estatus 
								from Itinerario_Cruceroo i 
								where i.ic_id = @idItinerario)
if ( @estatus = 'activo' )
		BEGIN

			update Itinerario_Cruceroo
			SET ic_estatus='inactivo'
			  where ic_id = @idItinerario;

		END
else 
 if ( @estatus = 'inactivo' )
		BEGIN

			update Itinerario_Cruceroo
			SET ic_estatus='activo'
			 where ic_id = @idItinerario ;

		end 
END
GO

-- ----------------------------
-- Procedure structure for M24_ConsultarCruceroID
-- ----------------------------
DROP PROCEDURE [M24_ConsultarCruceroID]
GO
CREATE PROCEDURE [M24_ConsultarCruceroID]
(
@id int
)
AS
BEGIN
select cru_nombre nombre, 
cru_compania compania, 
cru_capacidad capacidad
from crucero where cru_id = @id;
END
GO

-- ----------------------------
-- Procedure structure for M24_ConsultarCruceros
-- ----------------------------
DROP PROCEDURE [M24_ConsultarCruceros]
GO
CREATE PROCEDURE [M24_ConsultarCruceros]
(
@idCrucero int
)
AS
BEGIN
select c.cru_nombre nombreCrucero, 
c.cru_compania compania, 
c.cru_capacidad capacidad, 
c.cru_image imagen, 
cab.cab_nombre nombreCabina, 
cab.cab_precio precio, 
cam.cam_cantidad_cama cantidadCamas, 
cam.cam_tipo_cama tipoCamas
from crucero c, Cabina cab, Camarote cam 
where
c.cru_id = @idCrucero and c.cru_id = cab.cab_fk_crucero 
and cab.cab_id = cam.cam_fk_cabina
END
GO

-- ----------------------------
-- Procedure structure for M24_ListarCabinas
-- ----------------------------
DROP PROCEDURE [M24_ListarCabinas]
GO
CREATE PROCEDURE [M24_ListarCabinas]
(
@idCrucero int
)
AS
BEGIN
  SELECT c.cab_id id, 
	c.cab_nombre nombre,
	c.cab_precio precio,
	c.cab_estatus estatus 
	FROM CABINA C 
	WHERE CAB_FK_CRUCERO = @idCrucero;
END

GO

-- ----------------------------
-- Procedure structure for M24_ListarCamarote
-- ----------------------------
DROP PROCEDURE [M24_ListarCamarote]
GO
CREATE PROCEDURE [M24_ListarCamarote]
(
@idCabina int
)
AS
BEGIN
  SELECT
	c.cam_id id, 
	c.cam_cantidad_cama cantidadCama,
	c.cam_tipo_cama tipoCama,
	c.cam_estatus estatus 
	FROM CAMAROTE C 
	WHERE CAM_FK_CABINA = @idCabina; 
END
GO

-- ----------------------------
-- Procedure structure for M24_ListarCruceros
-- ----------------------------
DROP PROCEDURE [M24_ListarCruceros]
GO
CREATE PROCEDURE [M24_ListarCruceros]
AS
BEGIN
  select c.cru_id id,
c.cru_nombre nombre, 
c.cru_compania compania,
c.cru_capacidad capacidad,
c.cru_estatus estatus,
c.cru_image imagen 
from crucero c
END
GO

-- ----------------------------
-- Procedure structure for M24_ListarItinerario
-- ----------------------------
DROP PROCEDURE [M24_ListarItinerario]
GO
CREATE PROCEDURE [M24_ListarItinerario]
AS
BEGIN
select

i.icru_fecha_inicio fechaInicio,
i.icru_fecha_fin fechaFin,
c.cru_nombre nombreCrucero,
i.icru_estatus estatus,
(lo.lug_nombre + ' - ' + ld.lug_nombre) ruta
from ruta r, Lugar lo, Lugar ld, Itinerario_Crucero i, Crucero c
where 
r.rut_FK_lugar_origen = lo.lug_id and r.rut_FK_lugar_destino= ld.lug_id and i.icru_fk_ruta = r.rut_id
and c.cru_id = i.icru_fk_crucero
END
GO

-- ----------------------------
-- Procedure structure for M24_ListarRutas
-- ----------------------------
DROP PROCEDURE [M24_ListarRutas]
GO
CREATE PROCEDURE [M24_ListarRutas]
AS
BEGIN
select
r.rut_id id,
r.rut_distancia distancia, 
r.rut_status_ruta estatus,
r.rut_tipo_ruta tipoRuta,
(lo.lug_nombre + ' - ' + ld.lug_nombre) ruta
from ruta r, Lugar lo, Lugar ld
where 
r.rut_FK_lugar_origen = lo.lug_id and r.rut_FK_lugar_destino= ld.lug_id 
and r.rut_tipo_ruta = 'Maritima' and r.rut_status_ruta = 'activa'
END
GO

-- ----------------------------
-- Procedure structure for M24_ModificarCrucero
-- ----------------------------
DROP PROCEDURE [M24_ModificarCrucero]
GO
CREATE PROCEDURE [M24_ModificarCrucero]
(
@idCrucero int,
@nombreCrucero varchar(20),
@compania varchar(20),
@capacidad int
)
AS
BEGIN
  Update Crucero
	set cru_nombre = @nombreCrucero, cru_compania = @compania, 
	cru_capacidad = @capacidad
	where cru_id = @idCrucero;
END
GO

-- ----------------------------
-- Function structure for M20_ConflictosReservaHabitacion
-- ----------------------------
DROP FUNCTION [M20_ConflictosReservaHabitacion]
GO
-- =============================================
-- Author:		Roysbert Salinas
-- Create date: 28/11/2016
-- Description:
-- RES_RF_FO_07_02 | El sistema deberá permitir ver detalle de una reserva (Numero de Habitacion).
-- =============================================
CREATE FUNCTION [M20_ConflictosReservaHabitacion](
	@hot_id int,
	@cantidad_dias int,
	@fecha_llegada datetime
)
RETURNS TABLE
AS
RETURN (
	SELECT [rha_fk_hot_id], rha_habitacion
		FROM [dbo].[Reserva_Habitacion] 
		WHERE [rha_fk_hot_id] = @hot_id
			AND (
				([rha_estado] = 0 OR [rha_estado] = 1)
				AND (
						 (@fecha_llegada >= [rha_fecha_llegada] AND DATEADD(day, [rha_cantidad_dias], [rha_fecha_llegada]) >= @fecha_llegada)
					OR (DATEADD(day, @cantidad_dias, @fecha_llegada)  >= [rha_fecha_llegada] AND DATEADD(day, [rha_cantidad_dias], [rha_fecha_llegada]) >= DATEADD(day, @cantidad_dias, @fecha_llegada))
					OR (@fecha_llegada < [rha_fecha_llegada] AND DATEADD(day, @cantidad_dias, @fecha_llegada) > DATEADD(day, [rha_cantidad_dias], [rha_fecha_llegada]))
				)
			)
)
GO

-- ----------------------------
-- Function structure for M20_HabitacionesByHotel
-- ----------------------------
DROP FUNCTION [M20_HabitacionesByHotel]
GO
CREATE FUNCTION [M20_HabitacionesByHotel]
(	
	@hot_id int = NULL
)
RETURNS @TABLA_HABITACIONES TABLE ( hot_id INT NOT NULL, habitacion INT NOT NULL) 
AS
BEGIN
	DECLARE @numero_habitaciones INT, @habitacion INT = 1;

	SELECT @numero_habitaciones = [HOT].[hot_cantidad_habitaciones]
	FROM [dbo].[Hotel] [HOT]
	WHERE [HOT].[hot_id] = @hot_id
	
	WHILE (@habitacion <= @numero_habitaciones)
	BEGIN
		INSERT INTO @TABLA_HABITACIONES VALUES(@hot_id, @habitacion)
		SELECT @habitacion = @habitacion + 1
	END
	RETURN
END

GO

-- ----------------------------
-- Indexes structure for table Automovil
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Automovil
-- ----------------------------
ALTER TABLE [Automovil] ADD PRIMARY KEY ([aut_matricula])
GO

-- ----------------------------
-- Checks structure for table Automovil
-- ----------------------------
ALTER TABLE [Automovil] ADD CHECK (([aut_tipovehiculo]='Camioneta' OR [aut_tipovehiculo]='Todoterreno' OR [aut_tipovehiculo]='Minivan' OR [aut_tipovehiculo]='Deportivo' OR [aut_tipovehiculo]='Familiar' OR [aut_tipovehiculo]='Sedan'))
GO
ALTER TABLE [Automovil] ADD CHECK (([aut_transmision]='Sincronica' OR [aut_transmision]='Secuencial' OR [aut_transmision]='Automatica'))
GO

-- ----------------------------
-- Indexes structure for table Avion
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Avion
-- ----------------------------
ALTER TABLE [Avion] ADD PRIMARY KEY ([avi_id])
GO

-- ----------------------------
-- Uniques structure for table Avion
-- ----------------------------
ALTER TABLE [Avion] ADD UNIQUE ([avi_matricula] ASC)
GO

-- ----------------------------
-- Indexes structure for table Boleto
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Boleto
-- ----------------------------
ALTER TABLE [Boleto] ADD PRIMARY KEY ([bol_id])
GO

-- ----------------------------
-- Indexes structure for table Boleto_Vuelo
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Boleto_Vuelo
-- ----------------------------
ALTER TABLE [Boleto_Vuelo] ADD PRIMARY KEY ([bol_vue_id])
GO

-- ----------------------------
-- Indexes structure for table Cabina
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Cabina
-- ----------------------------
ALTER TABLE [Cabina] ADD PRIMARY KEY ([cab_id])
GO

-- ----------------------------
-- Indexes structure for table Camarote
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Camarote
-- ----------------------------
ALTER TABLE [Camarote] ADD PRIMARY KEY ([cam_id])
GO

-- ----------------------------
-- Indexes structure for table Comida
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Comida
-- ----------------------------
ALTER TABLE [Comida] ADD PRIMARY KEY ([com_id])
GO

-- ----------------------------
-- Indexes structure for table Comida_Vuelo
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Comida_Vuelo
-- ----------------------------
ALTER TABLE [Comida_Vuelo] ADD PRIMARY KEY ([com_vue_id])
GO

-- ----------------------------
-- Indexes structure for table Crucero
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Crucero
-- ----------------------------
ALTER TABLE [Crucero] ADD PRIMARY KEY ([cru_id])
GO

-- ----------------------------
-- Indexes structure for table Diario_Puntuacion
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Diario_Puntuacion
-- ----------------------------
ALTER TABLE [Diario_Puntuacion] ADD PRIMARY KEY ([id_diar_punt])
GO

-- ----------------------------
-- Indexes structure for table Diario_Viaje
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Diario_Viaje
-- ----------------------------
ALTER TABLE [Diario_Viaje] ADD PRIMARY KEY ([id_diar])
GO

-- ----------------------------
-- Indexes structure for table Equipaje
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Equipaje
-- ----------------------------
ALTER TABLE [Equipaje] ADD PRIMARY KEY ([equ_id])
GO

-- ----------------------------
-- Indexes structure for table Foto
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Foto
-- ----------------------------
ALTER TABLE [Foto] ADD PRIMARY KEY ([id_foto])
GO

-- ----------------------------
-- Indexes structure for table Hotel
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Hotel
-- ----------------------------
ALTER TABLE [Hotel] ADD PRIMARY KEY ([hot_id])
GO

-- ----------------------------
-- Indexes structure for table Itinerario_Crucero
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Itinerario_Crucero
-- ----------------------------
ALTER TABLE [Itinerario_Crucero] ADD PRIMARY KEY ([icru_fecha_inicio], [icru_fk_crucero], [icru_fk_ruta])
GO

-- ----------------------------
-- Indexes structure for table Itinerario_Vac
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Itinerario_Vac
-- ----------------------------
ALTER TABLE [Itinerario_Vac] ADD PRIMARY KEY ([itiv_id])
GO

-- ----------------------------
-- Indexes structure for table Login
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Login
-- ----------------------------
ALTER TABLE [Login] ADD PRIMARY KEY ([log_id])
GO

-- ----------------------------
-- Uniques structure for table Login
-- ----------------------------
ALTER TABLE [Login] ADD UNIQUE ([log_idusuario] ASC)
GO

-- ----------------------------
-- Indexes structure for table Lugar
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Lugar
-- ----------------------------
ALTER TABLE [Lugar] ADD PRIMARY KEY ([lug_id])
GO

-- ----------------------------
-- Checks structure for table Lugar
-- ----------------------------
ALTER TABLE [Lugar] ADD CHECK (([lug_tipo_lugar]='ciudad' OR [lug_tipo_lugar]='estado' OR [lug_tipo_lugar]='pais'))
GO

-- ----------------------------
-- Indexes structure for table Modulo_Detallado
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Modulo_Detallado
-- ----------------------------
ALTER TABLE [Modulo_Detallado] ADD PRIMARY KEY ([mod_det_id])
GO

-- ----------------------------
-- Indexes structure for table Modulo_General
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Modulo_General
-- ----------------------------
ALTER TABLE [Modulo_General] ADD PRIMARY KEY ([mod_gen_id])
GO

-- ----------------------------
-- Indexes structure for table Oferta
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Oferta
-- ----------------------------
ALTER TABLE [Oferta] ADD PRIMARY KEY ([ofe_id])
GO

-- ----------------------------
-- Indexes structure for table Paquete
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Paquete
-- ----------------------------
ALTER TABLE [Paquete] ADD PRIMARY KEY ([paq_id])
GO

-- ----------------------------
-- Indexes structure for table Pasajero
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Pasajero
-- ----------------------------
ALTER TABLE [Pasajero] ADD PRIMARY KEY ([pas_id])
GO

-- ----------------------------
-- Indexes structure for table Pase_Abordaje
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Pase_Abordaje
-- ----------------------------
ALTER TABLE [Pase_Abordaje] ADD PRIMARY KEY ([pas_id])
GO

-- ----------------------------
-- Indexes structure for table Perfil
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Perfil
-- ----------------------------
ALTER TABLE [Perfil] ADD PRIMARY KEY ([per_id])
GO

-- ----------------------------
-- Checks structure for table Perfil
-- ----------------------------
ALTER TABLE [Perfil] ADD CHECK (([per_genero]='Hombre' OR [per_genero]='Mujer'))
GO

-- ----------------------------
-- Indexes structure for table Pregunta_Respuesta
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Pregunta_Respuesta
-- ----------------------------
ALTER TABLE [Pregunta_Respuesta] ADD PRIMARY KEY ([pr_id])
GO

-- ----------------------------
-- Indexes structure for table Prueba
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Prueba
-- ----------------------------
ALTER TABLE [Prueba] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table Puntuacion
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Puntuacion
-- ----------------------------
ALTER TABLE [Puntuacion] ADD PRIMARY KEY ([id_punt])
GO

-- ----------------------------
-- Indexes structure for table Reclamo_Equipaje
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Reclamo_Equipaje
-- ----------------------------
ALTER TABLE [Reclamo_Equipaje] ADD PRIMARY KEY ([rec_id])
GO

-- ----------------------------
-- Indexes structure for table Reserva_Automovil
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Reserva_Automovil
-- ----------------------------
ALTER TABLE [Reserva_Automovil] ADD PRIMARY KEY ([raut_id])
GO

-- ----------------------------
-- Indexes structure for table Reserva_Boleto
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Reserva_Boleto
-- ----------------------------
ALTER TABLE [Reserva_Boleto] ADD PRIMARY KEY ([reb_id])
GO

-- ----------------------------
-- Indexes structure for table Reserva_Crucero
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Reserva_Crucero
-- ----------------------------
ALTER TABLE [Reserva_Crucero] ADD PRIMARY KEY ([RC_Id])
GO

-- ----------------------------
-- Indexes structure for table Reserva_Habitacion
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Reserva_Habitacion
-- ----------------------------
ALTER TABLE [Reserva_Habitacion] ADD PRIMARY KEY ([rha_id])
GO

-- ----------------------------
-- Indexes structure for table Reserva_Restaurante
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Reserva_Restaurante
-- ----------------------------
ALTER TABLE [Reserva_Restaurante] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table Reserva_Vuelo
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Reserva_Vuelo
-- ----------------------------
ALTER TABLE [Reserva_Vuelo] ADD PRIMARY KEY ([rev_id])
GO

-- ----------------------------
-- Indexes structure for table Restaurante
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Restaurante
-- ----------------------------
ALTER TABLE [Restaurante] ADD PRIMARY KEY ([rst_id])
GO

-- ----------------------------
-- Indexes structure for table Revision
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Revision
-- ----------------------------
ALTER TABLE [Revision] ADD PRIMARY KEY ([rev_id])
GO

-- ----------------------------
-- Indexes structure for table Revision_Valoracion
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Revision_Valoracion
-- ----------------------------
ALTER TABLE [Revision_Valoracion] ADD PRIMARY KEY ([rv_id])
GO

-- ----------------------------
-- Indexes structure for table Rol
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Rol
-- ----------------------------
ALTER TABLE [Rol] ADD PRIMARY KEY ([rol_id])
GO

-- ----------------------------
-- Indexes structure for table Rol_Modulo_Detallado
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Rol_Modulo_Detallado
-- ----------------------------
ALTER TABLE [Rol_Modulo_Detallado] ADD PRIMARY KEY ([fk_rol_id], [fk_mod_det_id])
GO

-- ----------------------------
-- Indexes structure for table Ruta
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Ruta
-- ----------------------------
ALTER TABLE [Ruta] ADD PRIMARY KEY ([rut_id])
GO

-- ----------------------------
-- Checks structure for table Ruta
-- ----------------------------
ALTER TABLE [Ruta] ADD CHECK (([rut_status_ruta]='Inactiva' OR [rut_status_ruta]='Activa'))
GO
ALTER TABLE [Ruta] ADD CHECK (([rut_tipo_ruta]='Maritima' OR [rut_tipo_ruta]='Aerea'))
GO

-- ----------------------------
-- Indexes structure for table TA
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table TA
-- ----------------------------
ALTER TABLE [TA] ADD PRIMARY KEY ([Uno], [Dos], [Tres])
GO

-- ----------------------------
-- Indexes structure for table Telefono
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Telefono
-- ----------------------------
ALTER TABLE [Telefono] ADD PRIMARY KEY ([tel_id])
GO

-- ----------------------------
-- Indexes structure for table Usuario
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Usuario
-- ----------------------------
ALTER TABLE [Usuario] ADD PRIMARY KEY ([usu_id])
GO

-- ----------------------------
-- Uniques structure for table Usuario
-- ----------------------------
ALTER TABLE [Usuario] ADD UNIQUE ([usu_correo] ASC)
GO

-- ----------------------------
-- Checks structure for table Usuario
-- ----------------------------
ALTER TABLE [Usuario] ADD CHECK (([usu_activo]='Activo' OR [usu_activo]='Inactivo'))
GO

-- ----------------------------
-- Indexes structure for table Vuelo
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Vuelo
-- ----------------------------
ALTER TABLE [Vuelo] ADD PRIMARY KEY ([vue_id])
GO

-- ----------------------------
-- Uniques structure for table Vuelo
-- ----------------------------
ALTER TABLE [Vuelo] ADD UNIQUE ([vue_codigo] ASC)
GO

-- ----------------------------
-- Checks structure for table Vuelo
-- ----------------------------
ALTER TABLE [Vuelo] ADD CHECK (([vue_status]='inactivo' OR [vue_status]='activo'))
GO

-- ----------------------------
-- Foreign Key structure for table [Automovil]
-- ----------------------------
ALTER TABLE [Automovil] ADD FOREIGN KEY ([aut_fk_ciudad]) REFERENCES [Lugar] ([lug_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Boleto]
-- ----------------------------
ALTER TABLE [Boleto] ADD FOREIGN KEY ([bol_fk_lugar_destino]) REFERENCES [Lugar] ([lug_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Boleto] ADD FOREIGN KEY ([bol_fk_lugar_origen]) REFERENCES [Lugar] ([lug_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Boleto] ADD FOREIGN KEY ([bol_fk_pasajero]) REFERENCES [Pasajero] ([pas_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Boleto_Vuelo]
-- ----------------------------
ALTER TABLE [Boleto_Vuelo] ADD FOREIGN KEY ([bol_fk_boleto]) REFERENCES [Boleto] ([bol_id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO
ALTER TABLE [Boleto_Vuelo] ADD FOREIGN KEY ([bol_fk_vuelo]) REFERENCES [Vuelo] ([vue_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Cabina]
-- ----------------------------
ALTER TABLE [Cabina] ADD FOREIGN KEY ([cab_fk_crucero]) REFERENCES [Crucero] ([cru_id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Camarote]
-- ----------------------------
ALTER TABLE [Camarote] ADD FOREIGN KEY ([cam_fk_cabina]) REFERENCES [Cabina] ([cab_id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Comida_Vuelo]
-- ----------------------------
ALTER TABLE [Comida_Vuelo] ADD FOREIGN KEY ([com_vue_fk_comida]) REFERENCES [Comida] ([com_id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO
ALTER TABLE [Comida_Vuelo] ADD FOREIGN KEY ([com_vue_fk_vuelo]) REFERENCES [Vuelo] ([vue_id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Diario_Puntuacion]
-- ----------------------------
ALTER TABLE [Diario_Puntuacion] ADD FOREIGN KEY ([fk_dia_id]) REFERENCES [Diario_Viaje] ([id_diar]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Diario_Puntuacion] ADD FOREIGN KEY ([fk_pun_id]) REFERENCES [Puntuacion] ([id_punt]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Diario_Puntuacion] ADD FOREIGN KEY ([fk_usu_id]) REFERENCES [Usuario] ([usu_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Diario_Viaje]
-- ----------------------------
ALTER TABLE [Diario_Viaje] ADD FOREIGN KEY ([fk_destino]) REFERENCES [Lugar] ([lug_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Diario_Viaje] ADD FOREIGN KEY ([fk_usuario_id]) REFERENCES [Usuario] ([usu_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Equipaje]
-- ----------------------------
ALTER TABLE [Equipaje] ADD FOREIGN KEY ([equ_fk_pase_abordaje]) REFERENCES [Pase_Abordaje] ([pas_id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Foto]
-- ----------------------------
ALTER TABLE [Foto] ADD FOREIGN KEY ([fk_diario]) REFERENCES [Diario_Viaje] ([id_diar]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Foto] ADD FOREIGN KEY ([fk_usuario]) REFERENCES [Usuario] ([usu_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Hotel]
-- ----------------------------
ALTER TABLE [Hotel] ADD FOREIGN KEY ([hot_fk_ciudad]) REFERENCES [Lugar] ([lug_id]) ON DELETE SET NULL ON UPDATE CASCADE
GO

-- ----------------------------
-- Foreign Key structure for table [Itinerario_Crucero]
-- ----------------------------
ALTER TABLE [Itinerario_Crucero] ADD FOREIGN KEY ([icru_fk_ruta]) REFERENCES [Ruta] ([rut_id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO
ALTER TABLE [Itinerario_Crucero] ADD FOREIGN KEY ([icru_fk_crucero]) REFERENCES [Crucero] ([cru_id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Itinerario_Vac]
-- ----------------------------
ALTER TABLE [Itinerario_Vac] ADD FOREIGN KEY ([itiv_fk_boleto]) REFERENCES [Boleto] ([bol_id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO
ALTER TABLE [Itinerario_Vac] ADD FOREIGN KEY ([itiv_fk_crucero]) REFERENCES [Crucero] ([cru_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Login]
-- ----------------------------
ALTER TABLE [Login] ADD FOREIGN KEY ([log_idusuario]) REFERENCES [Usuario] ([usu_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Lugar]
-- ----------------------------
ALTER TABLE [Lugar] ADD FOREIGN KEY ([lug_FK_lugar_id]) REFERENCES [Lugar] ([lug_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Modulo_Detallado]
-- ----------------------------
ALTER TABLE [Modulo_Detallado] ADD FOREIGN KEY ([fk_mod_gen_id]) REFERENCES [Modulo_General] ([mod_gen_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Paquete]
-- ----------------------------
ALTER TABLE [Paquete] ADD FOREIGN KEY ([paq_fk_automovil]) REFERENCES [Automovil] ([aut_matricula]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Paquete] ADD FOREIGN KEY ([paq_fk_crucero]) REFERENCES [Crucero] ([cru_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Paquete] ADD FOREIGN KEY ([paq_fk_hotel]) REFERENCES [Hotel] ([hot_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Paquete] ADD FOREIGN KEY ([paq_fk_oferta]) REFERENCES [Oferta] ([ofe_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Paquete] ADD FOREIGN KEY ([paq_fk_restaurante]) REFERENCES [Restaurante] ([rst_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Paquete] ADD FOREIGN KEY ([paq_fk_vuelo]) REFERENCES [Vuelo] ([vue_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Pase_Abordaje]
-- ----------------------------
ALTER TABLE [Pase_Abordaje] ADD FOREIGN KEY ([pas_fk_vuelo]) REFERENCES [Vuelo] ([vue_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Pase_Abordaje] ADD FOREIGN KEY ([pas_fk_boleto]) REFERENCES [Boleto] ([bol_id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO
ALTER TABLE [Pase_Abordaje] ADD FOREIGN KEY ([pas_fk_lugar_destino]) REFERENCES [Lugar] ([lug_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Pase_Abordaje] ADD FOREIGN KEY ([pas_fk_lugar_origen]) REFERENCES [Lugar] ([lug_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Perfil]
-- ----------------------------
ALTER TABLE [Perfil] ADD FOREIGN KEY ([per_fk_lugar]) REFERENCES [Lugar] ([lug_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Perfil] ADD FOREIGN KEY ([per_fk_usuario]) REFERENCES [Usuario] ([usu_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Perfil] ADD FOREIGN KEY ([per_fk_telefono]) REFERENCES [Telefono] ([tel_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Pregunta_Respuesta]
-- ----------------------------
ALTER TABLE [Pregunta_Respuesta] ADD FOREIGN KEY ([fk_perfil]) REFERENCES [Perfil] ([per_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Reclamo_Equipaje]
-- ----------------------------
ALTER TABLE [Reclamo_Equipaje] ADD FOREIGN KEY ([rec_fk_equipaje]) REFERENCES [Equipaje] ([equ_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Reclamo_Equipaje] ADD FOREIGN KEY ([rec_fk_pasajero]) REFERENCES [Pasajero] ([pas_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Reserva_Automovil]
-- ----------------------------
ALTER TABLE [Reserva_Automovil] ADD FOREIGN KEY ([raut_fk_automovil]) REFERENCES [Automovil] ([aut_matricula]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Reserva_Automovil] ADD FOREIGN KEY ([raut_fk_ciudad_devolucion]) REFERENCES [Lugar] ([lug_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Reserva_Automovil] ADD FOREIGN KEY ([raut_fk_ciudad_entrega]) REFERENCES [Lugar] ([lug_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Reserva_Automovil] ADD FOREIGN KEY ([raut_fk_usuario]) REFERENCES [Usuario] ([usu_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Reserva_Boleto]
-- ----------------------------
ALTER TABLE [Reserva_Boleto] ADD FOREIGN KEY ([fk_destino]) REFERENCES [Lugar] ([lug_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Reserva_Boleto] ADD FOREIGN KEY ([fk_origen]) REFERENCES [Lugar] ([lug_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Reserva_Boleto] ADD FOREIGN KEY ([fk_pas_id]) REFERENCES [Pasajero] ([pas_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Reserva_Crucero]
-- ----------------------------
ALTER TABLE [Reserva_Crucero] ADD FOREIGN KEY ([FK_Usuario]) REFERENCES [Usuario] ([usu_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Reserva_Crucero] ADD FOREIGN KEY ([FK_Fecha], [FK_Crucero], [FK_Ruta]) REFERENCES [Itinerario_Crucero] ([icru_fecha_inicio], [icru_fk_crucero], [icru_fk_ruta]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Reserva_Habitacion]
-- ----------------------------
ALTER TABLE [Reserva_Habitacion] ADD FOREIGN KEY ([rha_fk_hot_id]) REFERENCES [Hotel] ([hot_id]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [Reserva_Habitacion] ADD FOREIGN KEY ([rha_fk_usu_id]) REFERENCES [Usuario] ([usu_id]) ON DELETE CASCADE ON UPDATE CASCADE
GO

-- ----------------------------
-- Foreign Key structure for table [Reserva_Restaurante]
-- ----------------------------
ALTER TABLE [Reserva_Restaurante] ADD FOREIGN KEY ([FK_USUARIO]) REFERENCES [Usuario] ([usu_id]) ON DELETE SET NULL ON UPDATE NO ACTION
GO
ALTER TABLE [Reserva_Restaurante] ADD FOREIGN KEY ([FK_RESTAURANTE]) REFERENCES [Restaurante] ([rst_id]) ON DELETE SET NULL ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Reserva_Vuelo]
-- ----------------------------
ALTER TABLE [Reserva_Vuelo] ADD FOREIGN KEY ([fk_reb_id]) REFERENCES [Reserva_Boleto] ([reb_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Reserva_Vuelo] ADD FOREIGN KEY ([fk_vue_id]) REFERENCES [Vuelo] ([vue_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Restaurante]
-- ----------------------------
ALTER TABLE [Restaurante] ADD FOREIGN KEY ([fk_lugar]) REFERENCES [Lugar] ([lug_id]) ON DELETE SET NULL ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Revision]
-- ----------------------------
ALTER TABLE [Revision] ADD FOREIGN KEY ([rev_FK_res_hot_id]) REFERENCES [Reserva_Habitacion] ([rha_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Revision] ADD FOREIGN KEY ([rev_FK_res_res_id]) REFERENCES [Reserva_Restaurante] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Revision] ADD FOREIGN KEY ([rev_FK_usu_id]) REFERENCES [Usuario] ([usu_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Revision_Valoracion]
-- ----------------------------
ALTER TABLE [Revision_Valoracion] ADD FOREIGN KEY ([rv_FK_rev]) REFERENCES [Revision] ([rev_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Rol_Modulo_Detallado]
-- ----------------------------
ALTER TABLE [Rol_Modulo_Detallado] ADD FOREIGN KEY ([fk_mod_det_id]) REFERENCES [Modulo_Detallado] ([mod_det_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Rol_Modulo_Detallado] ADD FOREIGN KEY ([fk_rol_id]) REFERENCES [Rol] ([rol_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Ruta]
-- ----------------------------
ALTER TABLE [Ruta] ADD FOREIGN KEY ([rut_FK_lugar_destino]) REFERENCES [Lugar] ([lug_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Ruta] ADD FOREIGN KEY ([rut_FK_lugar_origen]) REFERENCES [Lugar] ([lug_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [TA_copy]
-- ----------------------------
ALTER TABLE [TA_copy] ADD FOREIGN KEY ([Uno], [Dos], [Tres]) REFERENCES [TA] ([Uno], [Dos], [Tres]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Usuario]
-- ----------------------------
ALTER TABLE [Usuario] ADD FOREIGN KEY ([usu_fk_rol]) REFERENCES [Rol] ([rol_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [Vuelo]
-- ----------------------------
ALTER TABLE [Vuelo] ADD FOREIGN KEY ([vue_fk_avion]) REFERENCES [Avion] ([avi_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Vuelo] ADD FOREIGN KEY ([vue_fk_ruta]) REFERENCES [Ruta] ([rut_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
