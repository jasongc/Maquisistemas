CREATE DATABASE bdProductos
GO
USE bdProductos
GO
CREATE TABLE Producto(
	ProductId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name varchar(250) NOT NULL,
	Status SMALLINT NOT NULL,
	Stock decimal(18, 4) NOT NULL,
	Description nvarchar(MAX) NOT NULL,
	Price decimal(18, 4) NOT NULL,
	CreateDate DATETIME NULL,
	UpdateDate DATETIME NULL
)
GO
CREATE PROCEDURE CrearProducto
	@pProductId int,
	@pName varchar(250),
	@pStatus SMALLINT,
	@pStock decimal(18, 4),
	@pDescription nvarchar(MAX),
	@pPrice decimal(18, 4)
AS
BEGIN
	
	IF ISNULL(@pProductId,0) = 0
	BEGIN

		INSERT INTO Producto(
			Name,
			Status,
			Stock,
			Description,
			Price,
			CreateDate
		)
		VALUES(
			@pName,
			@pStatus,
			@pStock,
			@pDescription,
			@pPrice,
			GETDATE()
		)
		SET @pProductId = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		UPDATE Producto SET 
			Name = @pName,
			Status = @pStatus,
			Stock = @pStock,
			Description = @pDescription,
			Price = @pPrice,
			UpdateDate = GETDATE()
		WHERE ProductId = @pProductId
	END

	SELECT @pProductId
END
GO
CREATE PROCEDURE ObtenerProducto
	@pProductId INT
AS
BEGIN
	SELECT
		ProductId,
		Name,
		Status,
		Stock,
		Description,
		Price,
		CreateDate,
		UpdateDate
	FROM Producto
	WHERE @pProductId IS NULL OR ProductId = @pProductId
END