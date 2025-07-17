using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
	public class ModeloDA : IModeloDA
	{
		private IRepositorioDapper _repoitorioDapper;
		private SqlConnection _sqlConnection;
		public ModeloDA(IRepositorioDapper repoitorioDapper)
		{
			_repoitorioDapper = repoitorioDapper;
			_sqlConnection = _repoitorioDapper.ObtenerRepositorio();
		}

		public async Task<Guid> Agregar(ModeloRequest modelo)
		{
			string query = @"AgregarModelo";

			var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
			{
				Id = Guid.NewGuid(),
				Nombre = modelo.Nombre,
				IdMarca = modelo.IdMarca
			});
			return resultadoConsulta;
		}
		public async Task<Guid> Editar(Guid Id, ModeloRequest modelo)
		{
			await verificarModeloExiste(Id);
			string query = @"EditarModelos";
			var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
			{
				Id = Id,
				Nombre = modelo.Nombre,
				IdMarca = modelo.IdMarca

			});
			return resultadoConsulta;
		}


		public async Task<Guid> Eliminar(Guid Id)
		{
			await verificarModeloExiste(Id);
			string query = @"EliminarModelos";
			var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
			{
				Id = Id

			});
			return resultadoConsulta;
		}

		public async Task<IEnumerable<ModeloResponse>> Obtener()
		{
			string query = @"ObtenerModelos";
			var resultadoConsulta = await _sqlConnection.QueryAsync<ModeloResponse>(query);
			return resultadoConsulta;
		}

		public async Task<ModeloResponse> Obtener(Guid Id)
		{
			string query = @"ObtenerModelo";
			var resultadoConsulta = await _sqlConnection.QueryAsync<ModeloResponse>(query, new { Id = Id });
			return resultadoConsulta.FirstOrDefault();
		}


		private async Task verificarModeloExiste(Guid Id)
		{
			ModeloResponse? resultadoConsultaModelo = await Obtener(Id);
			if (resultadoConsultaModelo == null)
				throw new Exception("No se encontró codigo");
		}
	}
}

