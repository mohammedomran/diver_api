using AutoMapper;
using Divers.Dtos.Reservation;
using Divers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers.Profiles
{
    public class ReservationsProfile : Profile
    {
            public ReservationsProfile()
            {
                CreateMap<AddPermenantReservationDto, Reservation>();
                CreateMap<UpdateReservationDto, Reservation>();
            }
    }

}
