CREATE PROCEDURE AgregarModelo
	@Id AS uniqueidentifier,
    @IdMarca AS uniqueidentifier  , 
    @Nombre AS varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    Begin TRANSACTION
	INSERT INTO [dbo].[Modelos]
           ([Id],
           [IdMarca],
           [Nombre])
     VALUES
           (@Id,
           @IdMarca,
           @Nombre)
Select @Id
COMMIT TRANSACTION
END