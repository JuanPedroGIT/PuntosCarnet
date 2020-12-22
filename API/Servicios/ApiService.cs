using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using API.Errors;
using API.Interfaces;

namespace API.Servicios
{
    public class ApiService : IApiService
    {
        private readonly IVehiculosRepository _vehiculosRepo;
        private readonly IConductorRepository _conductorRepo;
        private readonly IInfraccionRepository _infraccionRepo;
        private readonly IRegistroInfraccionesRepository _registroInfraccionesRepo;
        private readonly IVehiculoConductorRepository _vehiculoConductorRepo;

        public ApiService(IVehiculosRepository vehiculosRepo, IConductorRepository conductorRepo,
        IInfraccionRepository infraccionRepo, IRegistroInfraccionesRepository registroInfraccionesRepo, IVehiculoConductorRepository vehiculoConductorRepo)
        {
            _vehiculoConductorRepo = vehiculoConductorRepo;
            _registroInfraccionesRepo = registroInfraccionesRepo;
            _infraccionRepo = infraccionRepo;
            _conductorRepo = conductorRepo;
            _vehiculosRepo = vehiculosRepo;
        }

        public async Task<ConductorVehiculosDTO> InsertarVehiculo(VehiculoDTO vehiculoDTO)
        {
            var conductor = await _conductorRepo.GetConductorByDniAsync(vehiculoDTO.Dni);

            if (conductor == null)
            {
                throw new ApiException("Conductor no existe");
            }

            var vehiculo = await _vehiculosRepo.GetVehiculoByMatriculaAsync(vehiculoDTO.Matricula);

            if (vehiculo != null)
            {
                throw new ApiException("Existe un vehículo con la misma matrícula");
            }
            else
            {
                var numeroCoches =_vehiculoConductorRepo.GetNoVehiculosPorIdConductor(conductor.Id);
                if(numeroCoches >= 10)
                {
                throw new ApiException("El conductor ya es habitual en 10 coches");

                }

                var newV = new Vehiculo(vehiculoDTO.Matricula, vehiculoDTO.Marca, vehiculoDTO.Modelo);
                var newC = new Conductor(conductor.Dni, conductor.Nombre, conductor.Apellidos, conductor.Puntos);

                _vehiculoConductorRepo.Insert(new VehiculosConductor(newC, newV));
                //_vehiculosRepo.Insert(v);

                var res = await _vehiculoConductorRepo.Complete();
                if (res <= 0)
                {
                    throw new ApiException("Error al Guardar los datos");
                }

                return new ConductorVehiculosDTO{
                    Apellidos = newC.Apellidos,
                    Puntos = newC.Puntos,
                    Nombre = newC.Nombre,
                    Dni = newC.Dni,
                    NumeroVehiculos = numeroCoches
                };
            }
        }


        public async Task<Conductor> InsertarConductor(ConductorDTO conductorDTO)
        {

            var conductor = await _conductorRepo.GetConductorByDniAsync(conductorDTO.Dni);
            if (conductor != null)
            {
                throw new ApiException("El conductor ya existe");
            }

            var newConductor = new Conductor(conductorDTO.Dni, conductorDTO.Nombre, conductorDTO.Apellidos, conductorDTO.Puntos);

            _conductorRepo.InsertConductor(newConductor);
            var res = await _conductorRepo.Complete();
            if (res <= 0)
            {
                throw new ApiException("Error al Guardar los datos");
            }


            return newConductor;
        }

        public async Task<TipoInfraccionDTO> InsertarInfraccion(TipoInfraccionDTO infraccion)
        {
            var inf = await _infraccionRepo.GetByNombreAsync(infraccion.Nombre);

            if (inf != null) {
                 throw new ApiException("La Infraccion ya existe");
            }

            _infraccionRepo.InsertarInfraccion(new TipoInfraccion(infraccion.Nombre, infraccion.Descripcion, infraccion.PuntosAdescontar));
            var res = await _infraccionRepo.Complete();

            if (res <= 0) 
            {
                throw new ApiException("Error al guardar la infraccion");
            }

            return infraccion;
        }

        public async Task<ConductorDTO> RegistrarInfraccion(RegistroInfraccionDTO registroInfraccionDTO)
        {
            var conductor = await _conductorRepo.GetConductorByDniAsync(registroInfraccionDTO.Dni);
            var vehiculo = await _vehiculosRepo.GetVehiculoByMatriculaAsync(registroInfraccionDTO.Matricula);
            var tipoInfraccion = await _infraccionRepo.GetByNombreAsync(registroInfraccionDTO.NombreInfraccion);

            if (conductor == null) {throw new ApiException("El conductor no existe");}
            if ( tipoInfraccion == null) {throw new ApiException("La Infraccion no  existe");}
            if ( vehiculo == null ) {throw new ApiException("El vehiculo no existe");}

            conductor.Puntos -= tipoInfraccion.PuntosAdescontar;

            var registroI = new RegistroInfraccion(conductor, tipoInfraccion, vehiculo);

            _registroInfraccionesRepo.Insert(registroI);
            var res = await _registroInfraccionesRepo.Complete();

            if (res <= 0) {
                throw new ApiException("Error al guardar los datos");
            }

            return new ConductorDTO
            {
                Apellidos = conductor.Apellidos,
                Dni = conductor.Dni,
                Nombre = conductor.Nombre,
                Puntos = conductor.Puntos
            };


        }

        public async Task<HistorialInfraccionesDniDTO> GetHistorialInfraccionesDni(string dni)
        {
            var conductor = await _conductorRepo.GetConductorByDniAsync(dni);
            var infracciones = await _registroInfraccionesRepo.GetRegistroInfraccionByIdConductor(conductor.Id);

            var listaIn = new List<InfraccionDTO>();

            foreach (var item in infracciones)
            {
                listaIn.Add(new InfraccionDTO
                {
                    Descripcion = item.TipoInfraccion.Descripcion,
                    Fecha = item.Fecha,
                    Nombre = item.TipoInfraccion.Nombre,
                    PuntosAdescontar = item.TipoInfraccion.PuntosAdescontar
                });
            };


            return new HistorialInfraccionesDniDTO
            {
                Apellidos = conductor.Apellidos,
                Dni = conductor.Dni,
                Nombre = conductor.Nombre,
                Puntos = conductor.Puntos,

                registroInfracciones = listaIn
            };
        }

        public async Task<IReadOnlyList<InfraccionHabitualDTO>> InfraccionesHabituales()
        {
            var registro = await _registroInfraccionesRepo.GetRegistroInfraccion();
            return registro.GroupBy(x => x.TipoInfraccion)
                           .Select(r => new InfraccionHabitualDTO
                           {
                               Descripcion = r.First().TipoInfraccion.Descripcion,
                               Nombre = r.First().TipoInfraccion.Nombre,
                               PuntosAdescontar = r.First().TipoInfraccion.PuntosAdescontar,
                               NumeroInfracciones = r.Count()
                           })
                           .OrderByDescending(o => o.NumeroInfracciones)
                           .Take(5).ToList();
        }

        public async Task<IReadOnlyList<ConductorNuInfraccionesDTO>> TopNConductores(int n)
        {
            var registro = await _registroInfraccionesRepo.GetRegistroInfraccion();
            return registro.GroupBy(x => x.Conductor)
                           .Select(r => new ConductorNuInfraccionesDTO
                           {
                               Nombre = r.First().Conductor.Nombre,
                               Apellidos = r.First().Conductor.Apellidos,
                               Dni = r.First().Conductor.Dni,
                               Puntos = r.First().Conductor.Puntos,
                               NumeroInfracciones = r.Count()
                           })
                           .OrderByDescending(o => o.NumeroInfracciones)
                           .Take(n).ToList();
        }
    }
}