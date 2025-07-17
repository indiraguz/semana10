CREATE PROCEDURE EliminarMarcas
	@Id uniqueidentifier

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Begin Transaction
		Delete 
		FROM Marcas 
		Where (Marcas.Id=@Id)
		select @Id
	commit transaction
END