using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos.Servicios.Registro;
using Abstracciones.Modelos.Servicios.Revision;

namespace Abstracciones.Interfaces.Servicios
{
	public interface IRevisionServicio
	{
		Task<Revision> Obtener(string placa);
	}
}
