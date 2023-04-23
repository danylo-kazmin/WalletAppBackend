using AutoMapper;
using WalletAppBackend.Service.Models;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities;

namespace WalletAppBackend.Service.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<UserEntity, User>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dst => dst.Transactions, opt => opt.MapFrom(src => src.Transactions))
                .ForMember(dst => dst.DailyPoints, opt => opt.MapFrom(src => src.DailyPoints))
                .ForMember(dst => dst.CardBalance, opt => opt.MapFrom(src => src.CardBalance));

            CreateMap<TransactionEntity, Transaction>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dst => dst.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dst => dst.IconLink, opt => opt.MapFrom(src => src.IconLink))
                .ForMember(dst => dst.Sender, opt => opt.MapFrom(src => src.Sender))
                .ForMember(dst => dst.Owner, opt => opt.MapFrom(src => src.Owner));

            CreateMap<DailyPointsEntity, DailyPoints>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Points, opt => opt.MapFrom(src => (long)Math.Round((decimal)src.Points) >= 1000 
                ? (long)Math.Round((decimal)src.Points) / 1000 + "K" 
                : ((long)Math.Round((decimal)src.Points)).ToString()))
                .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dst => dst.User, opt => opt.MapFrom(src => src.User));

            CreateMap<CardBalanceEntity, CardBalance>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.MaxLimit, opt => opt.MapFrom(src => src.MaxLimit))
                .ForMember(dst => dst.Balance, opt => opt.MapFrom(src => src.Balance))
                .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dst => dst.User, opt => opt.MapFrom(src => src.User));
        }
    }
}
