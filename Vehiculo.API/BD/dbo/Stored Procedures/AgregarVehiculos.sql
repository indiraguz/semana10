CREATE PROCEDURE AgregarVehiculos
    @Id UNIQUEIDENTIFIER,
    @Placa NVARCHAR(20),
    @Color NVARCHAR(50),
    @Anio INT,
    @CorreoPropietario NVARCHAR(100),
    @Precio DECIMAL(18, 2),
    @TelefonoPropietario NVARCHAR(20),
    @IdModelo UNIQUEIDENTIFIER
AS
BEGIN
    INSERT INTO Vehiculo (Id, Placa, Color, Anio, CorreoPropietario, Precio, TelefonoPropietario, IdModelo)
    VALUES (@Id, @Placa, @Color, @Anio, @CorreoPropietario, @Precio, @TelefonoPropietario, @IdModelo)
END