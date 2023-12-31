USE [Generacion23]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 24/12/2023 11:14:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[idEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](200) NULL,
	[numeroEmpleado] [char](5) NULL,
	[sueldo] [decimal](18, 2) NULL,
	[fechaNacimiento] [date] NULL,
	[tiempoCompleto] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [numeroEmpleado], [sueldo], [fechaNacimiento], [tiempoCompleto]) VALUES (2, N'Carlos Ruiz', N'EMP09', CAST(15264.00 AS Decimal(18, 2)), CAST(N'2001-10-15' AS Date), 1)
INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [numeroEmpleado], [sueldo], [fechaNacimiento], [tiempoCompleto]) VALUES (3, N'Francisco Martinez', N'EMP03', CAST(9112.21 AS Decimal(18, 2)), CAST(N'1991-05-12' AS Date), 1)
INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [numeroEmpleado], [sueldo], [fechaNacimiento], [tiempoCompleto]) VALUES (4, N'Jose Manuel', N'EMP08', CAST(20156.00 AS Decimal(18, 2)), CAST(N'1996-12-31' AS Date), 1)
INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [numeroEmpleado], [sueldo], [fechaNacimiento], [tiempoCompleto]) VALUES (5, N'Jose Carlos Zabala', N'EMP05', CAST(56413.00 AS Decimal(18, 2)), CAST(N'1998-04-23' AS Date), 0)
INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [numeroEmpleado], [sueldo], [fechaNacimiento], [tiempoCompleto]) VALUES (6, N'Lizeth Martinez', N'EMP06', CAST(12313.00 AS Decimal(18, 2)), CAST(N'1997-07-23' AS Date), 1)
INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [numeroEmpleado], [sueldo], [fechaNacimiento], [tiempoCompleto]) VALUES (7, N'Ana', N'EMP07', CAST(15365.00 AS Decimal(18, 2)), CAST(N'1993-05-12' AS Date), 0)
INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [numeroEmpleado], [sueldo], [fechaNacimiento], [tiempoCompleto]) VALUES (9, N'Carlos', N'EMP01', CAST(10251.00 AS Decimal(18, 2)), CAST(N'1996-05-12' AS Date), 1)
INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [numeroEmpleado], [sueldo], [fechaNacimiento], [tiempoCompleto]) VALUES (10, N'Horacio', N'EMP04', CAST(15625.00 AS Decimal(18, 2)), CAST(N'1996-12-12' AS Date), 0)
INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [numeroEmpleado], [sueldo], [fechaNacimiento], [tiempoCompleto]) VALUES (11, N'Rosa', N'EMP02', CAST(15678.00 AS Decimal(18, 2)), CAST(N'1997-08-15' AS Date), 0)
SET IDENTITY_INSERT [dbo].[Empleados] OFF
GO
