﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
	public class VehiculoBase
	{
		[Required]
	
		public string? Placa { get; set; }		
		public string? Color { get; set; }		
		public int Anio { get; set; }

		[EmailAddress(ErrorMessage = "El formato del correo no es valido")]
		public string? CorreoPropietario { get; set; }

		public Decimal Precio { get; set; }
		
		
		public string? TelefonoPropietario { get; set; }
		}

	public class VehiculoRequest : VehiculoBase
	{
		public Guid IdModelo { get; set; }
	}
	public class  VehiculoResponse:VehiculoBase
	{
		public Guid Id { get; set; }
		public string? Modelo { get; set; }
		public string? Marca { get; set; }
	}
}

