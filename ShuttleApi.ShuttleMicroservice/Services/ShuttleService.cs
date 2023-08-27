using Microsoft.EntityFrameworkCore;
using ShuttleApi.ShuttleMicroservice.Common.Exceptions.Shuttle;
using ShuttleApi.ShuttleMicroservice.Data;
using ShuttleApi.ShuttleMicroservice.Models;
using ShuttleApi.ShuttleMicroservice.Services.Contracts;

using NLog;
using AutoMapper;
using ShuttleApi.ShuttleMicroservice.Data.DTOs;

namespace ShuttleApi.ShuttleMicroservice.Services
{
    public class ShuttleService : IShuttleService
    {
        private readonly ShuttleDbContext _context;
        private readonly Logger _logger;
        private readonly IMapper _mapper;
        public ShuttleService(ShuttleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task CreateShuttle(ShuttleDTO shuttleDto, CancellationToken cancellationToken)
        {
            var checkForTitle = await GetShuttleByTitle(shuttleDto.Title, cancellationToken);
            if (checkForTitle == null)
            {
                _logger.Error($"failed to create shuttle enitity, because entity with ({shuttleDto.Title}) as title alredy exists in db");
                throw new ShuttleAlreadyExistException();
            }
            try
            {
                var newShuttle = _mapper.Map<Shuttle>(shuttleDto);
                await _context.AddAsync(newShuttle, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.Info($"Creating shuttle with Id - {newShuttle.Id} and title - {newShuttle.Title}");
            }
            catch (Exception)
            {
                _logger.Error($"failed to create shuttle enitity, for some unknown reason");
                throw new CreateErrorException();
            }
        }

        public async Task DeleteShuttle(string id, CancellationToken cancellationToken)
        {
            var checkShuttle = await GetShuttleById(id, cancellationToken);
            if (checkShuttle == null)
            {
                _logger.Error($"failed to delete shuttle enitity, because it doesnt exists in db");
                throw new ShuttleNotFoundException();
            }
            try
            {
                _context.Remove(checkShuttle);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.Info($"Success deleting shuttle entity with Id - {id} ");
            }
            catch (Exception)
            {
                _logger.Error("failed to delete shuttle enitity, for some unknown reason");
                throw new DeleteErrorException();
            }
        }

        public async Task<IEnumerable<ShuttleDTO>> GetAllShuttles(CancellationToken cancellationToken)
        {
            _logger.Info("a list of all spaceships was called up");
            return await _context.Set<Shuttle>().Select(s => _mapper.Map<ShuttleDTO>(s)).ToListAsync(cancellationToken);
        }

        public async Task<ShuttleDTO> GetShuttleById(string id, CancellationToken cancellationToken)
        {
            var checkShuttle = await _context.Set<Shuttle>().FirstOrDefaultAsync(shuttle => shuttle.Id == id, cancellationToken);
            if (checkShuttle == null)
            {
                _logger.Error($"failed to get shuttle enitity by id, because it doesnt exists in db");
                throw new ShuttleNotFoundException();
            }
            _logger.Info($"a specific spaceship {checkShuttle.Id} was called up");
            return _mapper.Map<ShuttleDTO>(checkShuttle);
        }

        public async Task<ShuttleDTO> GetShuttleByTitle(string title, CancellationToken cancellationToken)
        {
            var checkShuttle = await _context.Set<Shuttle>().FirstOrDefaultAsync(shuttle => shuttle.Title == title, cancellationToken);
            if (checkShuttle == null)
            {
                _logger.Error($"failed to get shuttle enitity by title, because it doesnt exists in db");
                throw new ShuttleNotFoundException();
            }
            _logger.Info($"a specific spaceship {checkShuttle.Id} was called up");
            return _mapper.Map<ShuttleDTO>(checkShuttle);
        }
    }
}
