﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZMEJ.Domain.Models;

namespace ZMEJ.EventHandlers.Commands
{
    public class CreateUbicacionTecnicaCommand : IRequest<CreateResultData>
    {
        public string Centro { get; set; }
        
        public string Ubicacion { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public Guid uuid { get; set; }
    }
}
