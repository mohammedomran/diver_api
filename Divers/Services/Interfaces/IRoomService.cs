using Divers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers.Services.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<Room> GetRooms();
        int GetNumberOfRoomsOfType(int roomId);
        decimal GetDefaultRateById(int id);
    }
}
