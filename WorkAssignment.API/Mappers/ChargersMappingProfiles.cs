using AutoMapper;
using OpenChargeApiClient;
using WorkAssignment.API.Entities;
using WorkAssignment.DB.Models;

namespace WorkAssignment.API.Mappers
{
    public class ChargersMappingProfiles : Profile
    {
        public ChargersMappingProfiles()
        {
            OpenChargerToChangerLocationMapping();
            OpenChargerToChargerDbMapping();
            ChargerToChargerResponse();
        }
        
        private void OpenChargerToChangerLocationMapping()
        {
            CreateMap<OpenChargerResponse, ChargerLocationResponse>()
                .ForMember(dest => dest.ChargerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.AddressInfo.Title))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.AddressInfo.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.AddressInfo.Longitude));
        }
        
        private void OpenChargerToChargerDbMapping()
        {
            CreateMap<OpenChargerResponse, Charger>()
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.AddressInfo.Id));
            CreateMap<OpenChargerAddressResponse, ChargerAddress>();
            CreateMap<OpenChargerConnectionsResponse, ChargerConnection>();
            CreateMap<OpenChargerMediaResponse, ChargerMedia>();
            CreateMap<OpenChargerUserResponse, User>();
        }
        
        private void ChargerToChargerResponse()
        {
            CreateMap<Charger, ChargerResponse>();
            CreateMap<ChargerAddress, AddressResponse>();
            CreateMap<ChargerConnection, ConnectionResponse>();
            CreateMap<ChargerMedia, MediaResponse>();
            CreateMap<User, UserResponse>();
        }
    }
}