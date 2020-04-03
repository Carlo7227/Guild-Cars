USE GuildCars
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleSelectAll')
		DROP PROCEDURE VehicleSelectAll
	GO

CREATE PROCEDURE VehicleSelectAll AS
BEGIN
	SELECT VehicleID, UserID, MakeID, SalesID, BodyTypeID, InteriorColorID, ExteriorColorID,
	IsAutomatic,SalesPrice,MSRP,Mileage,VIN,[Year],[Description],ImageFileName,IsNew,
	FROM Vehicle
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleInsert')
		DROP PROCEDURE VehicleInsert
	GO

CREATE PROCEDURE VehicleInsert(
	@VehicleID int output,
	@MakeID int output,
	@ModelID int output,
	@BodyTypeID int output,
	@InteriorColorID int output,
	@ExteriorColorID int output,
	@IsAutomatic bit,
	@SalesPrice decimal (8,2),
	@MSRP decimal(8,2),
	@Mileage decimal (8,2), 
	@VIN nvarchar(17),
	@[Year] int,
	@[Description] nvarchar(500),
	@IsNew bit,
	@ImageFileName nvarchar(50)
)AS
BEGIN
	INSERT INTO Vehicle(MakeID, BodyTypeID, InteriorColorID, ExteriorColorID,
	IsAutomatic,SalesPrice,MSRP,Mileage,VIN,[Year],[Description],ImageFileName,IsNew)
	VALUES(@MakeID, @BodyTypeID, @InteriorColorID, @ExteriorColorID, @IsAutomatic,
	@SalesPrice,@MSRP,@Mileage,@VIN,@[Year],@[Description],@ImageFileName,@IsNew);

SET @DvdId = SCOPE_IDENTITY();
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdEdit')
		DROP PROCEDURE DvdEdit
	GO

CREATE PROCEDURE DvdEdit(
	@VehicleID int,
	@VMakeID int,
	@ModelID int,
	@BodyTypeID int,
	@InteriorColorID int,
	@ExteriorColorID int,
	@IsAutomatic bit,
	@SalesPrice decimal (9,2),
	@MSRP decimal(9,2),
	@Mileage decimal (9,2), 
	@VIN nvarchar(17),
	@[Year] int,
	@[Description] nvarchar(500),
	@IsNew bit,
	@ImageFileName nvarchar(50)
)AS
BEGIN
	UPDATE Dvd SET
	Title = @Title,
	ReleaseYear = @ReleaseYear,
	Director= @Director,
	Rating= @Rating,
	Notes= @Notes
	WHERE DvdId = @DvdId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdDelete')
		DROP PROCEDURE DvdDelete
	GO

CREATE PROCEDURE DvdDelete(
	@DvdId int
)AS
BEGIN
	BEGIN TRANSACTION
	DELETE FROM Dvd WHERE DvdId = @DvdId;
	COMMIT TRANSACTION
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdSelect')
		DROP PROCEDURE DvdSelect
	GO

CREATE PROCEDURE DvdSelect(
	@DvdId int
)AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd
	WHERE DvdId = @DvdId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TitleSelectAll')
		DROP PROCEDURE TitleSelectAll
	GO

CREATE PROCEDURE TitleSelectAll(
	@Title nvarchar(20)
)AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd
	WHERE Title = @Title
END
GO