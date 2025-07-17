using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Abstracciones.Modelos
{
	public class MarcaRequest
	{
		public string Nombre { get; set; }
	}

	public class MarcaResponse
	{
		public Guid Id { get; set; }
		public string Nombre { get; set; }
	}
}