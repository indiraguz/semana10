using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
	public class MarcasDA : IMarcaDA
	{
		private IRepositorioDapper _repoitorioDapper;
		private SqlConnection _sqlConnection;
		public MarcasDA(IRepositorioDapper repoitorioDapper)
		{
			_repoitorioDapper = repoitorioDapper;
			_sqlConnection = _repoitorioDapper.ObtenerRepositorio();
		}

		public async Task<Guid> Agregar(MarcaRequest marcas)
		{
			string query = @"AgregarMarcas";

			var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
			{
				Id = Guid.NewGuid(),
				Nombre = marcas.Nombre,
			});
			return resultadoConsulta;
		}
		public async Task<Guid> Editar(Guid Id, MarcaRequest marcas)
		{
			await verificarMarcaExiste(Id);
			string query = @"EditarMarcas";
			var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
			{
				Id = Id,
				Nombre = marcas.Nombre,

			});
			return resultadoConsulta;
		}


		public async Task<Guid> Eliminar(Guid Id)
		{
			await verificarMarcaExiste(Id);
			string query = @"EliminarMarcas";
			var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
			{
				Id = Id

			});
			return resultadoConsulta;
		}

		public async Task<IEnumerable<MarcaResponse>> Obtener()
		{
			string query = @"ObtenerMarcas";
			var resultadoConsulta = await _sqlConnection.QueryAsync<MarcaResponse>(query);
			return resultadoConsulta;
		}

		public async Task<MarcaResponse> Obtener(Guid Id)
		{
			string query = @"ObtenerMarca";
			var resultadoConsulta = await _sqlConnection.QueryAsync<MarcaResponse>(query, new { Id = Id });
			return resultadoConsulta.FirstOrDefault();
		}
		private async Task verificarMarcaExiste(Guid Id)
		{
			MarcaResponse? resultadoConsultaMarca = await Obtener(Id);
			if (resultadoConsultaMarca == null)
				throw new Exception("No se encontró codigo");
		}
	}
}
