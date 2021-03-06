USE [DemoCRUD]
GO
/****** Object:  Table [dbo].[tbl_Employee]    Script Date: 3/21/2021 9:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Employee](
	[Sr_no] [int] IDENTITY(1,1) NOT NULL,
	[Em_name] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[STATE] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Department] [nvarchar](50) NULL,
	[flag] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Employee] PRIMARY KEY CLUSTERED 
(
	[Sr_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_Employee]    Script Date: 3/21/2021 9:21:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_Employee]
@Sr_no INT, @Em_name NVARCHAR(50),
@City NVARCHAR(50),@STATE NVARCHAR(50),
@Country NVARCHAR(50),@Department NVARCHAR(50),
@flag NVARCHAR(50)

AS BEGIN

IF(@flag='insert')
BEGIN
INSERT INTO dbo.tbl_Employee
(
    Em_name,
    City,
    STATE,
    Country,
    Department
   
)
VALUES
(   N'@Em_name', -- Em_name - nvarchar(50)
    N'@City', -- City - nvarchar(50)
    N'@STATE', -- STATE - nvarchar(50)
    N'@Country', -- Country - nvarchar(50)
    N'@Department' -- Department - nvarchar(50)
    
    )

END

ELSE IF (@flag='update')
BEGIN
UPDATE dbo.tbl_Employee SET
Em_name=@Em_name, City=@City,
STATE=@STATE,Country=@Country,
Department=@Department
WHERE Sr_no=@Sr_no
END
ELSE IF(@flag='delete')
BEGIN
DELETE FROM dbo.tbl_Employee
WHERE Sr_no=@Sr_no
END

ELSE IF (@flag='getid')
BEGIN
SELECT *FROM dbo.tbl_Employee
WHERE Sr_no=@Sr_no
END
ELSE IF(@flag='get')
BEGIN
SELECT *FROM dbo.tbl_Employee
END
END

GO
