using AutoMapper;
using Domain.Entities;
using Domain.Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserModel>();
        CreateMap<UserModel, User>();
    }
}