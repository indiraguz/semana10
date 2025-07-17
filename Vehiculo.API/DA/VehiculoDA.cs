
using System.Linq;
using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
	public class VehiculoDA : IVehiculoDA

	{
		private IRepositorioDapper _repoitorioDapper;
		private SqlConnection _sqlConnection;
		public VehiculoDA(IRepositorioDapper repoitorioDapper)
		{
			_repoitorioDapper = repoitorioDapper;
			_sqlConnection = _repoitorioDapper.ObtenerRepositorio();
		}
		#region Operaciones
		public async Task<Guid> Agregar(VehiculoRequest vehiculo)
		{
			string query = @"AgregarVehiculos";

			var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
			{
				Id = Guid.NewGuid(),
				IdModelo = vehiculo.IdModelo,
				Placa = vehiculo.Placa,
				Color = vehiculo.Color,
				Anio = vehiculo.Anio,
				CorreoPropietario = vehiculo.CorreoPropietario,
				Precio = vehiculo.Precio,
				TelefonoPropietario = vehiculo.TelefonoPropietario
			});
			return resultadoConsulta;
		}

		public async Task<Guid> Editar(Guid Id, VehiculoRequest vehiculo)
		{

			await verificarVehiculoExiste(Id);
			string query = @"EditarVehiculos";
			var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
			{
				Id = Id,
				IdModelo = vehiculo.IdModelo,
				Placa = vehiculo.Placa,
				Color = vehiculo.Color,
				Anio = vehiculo.Anio,
				CorreoPropietario = vehiculo.CorreoPropietario,
				Precio = vehiculo.Precio,
				TelefonoPropietario = vehiculo.TelefonoPropietario
			});
			return resultadoConsulta;
		}
		public async Task<Guid> Eliminar(Guid Id)
		{
			await verificarVehiculoExiste(Id);
			string query = @"EliminarVehiculos";
			var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
			{
				Id = Id

			});
			return resultadoConsulta;
		}

		public async Task<IEnumerable<VehiculoResponse>> Obtener()
		{
			string query = @"ObtenerVehiculos";
			var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoResponse>(query);
			return resultadoConsulta;
		}


		public async Task<VehiculoResponse> Obtener(Guid Id)
		{
			string query = @"ObtenerVehiculo";
			var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoResponse>(query, new { Id = Id });
			return resultadoConsulta.FirstOrDefault();
		}
		#endregion
		#region Helpers
		private async Task verificarVehiculoExiste(Guid Id)
		{
			VehiculoResponse? resultadoConsultaVehiculo = await Obtener(Id);
			if (resultadoConsultaVehiculo == null)
				throw new Exception("No se encontró codigo");
		}
		#endregion
	}
}