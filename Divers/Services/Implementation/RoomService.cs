using Divers.Data;
using Divers.Models;
using Divers.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers.Services.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext _context;
        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Room> GetRooms()
        {
            var rooms = _context.rooms.ToList();
            return rooms;
        }

        public int GetNumberOfRoomsOfType(int roomId)
        {
            return _context.rooms.FirstOrDefault(r => r.Id == roomId).Quantity;
        }
    }
}
