using MediatR;
using ZMEJ.EventHandlers.Commands;

using ZMEJ.Domain.Repositories;
using ZMEJ.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZMEJ.Domain.Models;

namespace ZMEJ.EventHandlers
{
    public class CreatePuestoDeTrabajoHandler : IRequestHandler<CreatePuestoDeTrabajoCommand, CreateResultData>
    {
        private IPuestoDeTrabajoRepository _puestoDeTrabajoRepository;
        private IIdentityService _identityServices;

        public CreatePuestoDeTrabajoHandler(IPuestoDeTrabajoRepository puestoDeTrabajoRepository ,IIdentityService identityServices)
        {
            _puestoDeTrabajoRepository = puestoDeTrabajoRepository;
            _identityServices = identityServices;
        }
        public async Task<CreateResultData> Handle(CreatePuestoDeTrabajoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userName = _identityServices.GetUserName();
                var vPuestoDeTrabajo = new PuestoDeTrabajo(request.PstoTbjo,request.Descripcion);
                  
                var r =  _puestoDeTrabajoRepository.Save(vPuestoDeTrabajo);             
                return new CreateResultData
                {
                    Id= r.uuid
                };
               // return r;
            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
            }
            //return false;
            //throw new NotImplementedException();
        }

    }
}
