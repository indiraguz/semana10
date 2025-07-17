CREATE PROCEDURE EditarModelos 
	@Id AS uniqueidentifier,
	@IdMarca AS uniqueidentifier,
@Nombre AS varchar(max)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRANSACTION
UPDATE [dbo]. [Modelos]
SET [Nombre] = @Nombre
WHERE Id=@Id
Select @Id
COMMIT TRANSACTION
END