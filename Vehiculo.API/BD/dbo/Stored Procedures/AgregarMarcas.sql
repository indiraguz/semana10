CREATE PROCEDURE AgregarMarcas 
	@Id AS uniqueidentifier
,@Nombre AS varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	

    -- Insert statements for procedure here
    Begin TRANSACTION
	INSERT INTO [dbo].[Marcas]
           ([Id]
           ,[Nombre])
     VALUES
           (@Id
,@Nombre)
Select @Id
COMMIT TRANSACTION
END