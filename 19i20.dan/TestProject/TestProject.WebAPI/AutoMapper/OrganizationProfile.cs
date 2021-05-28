using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Animal.Model.Common;
using TestProject.WebAPI.Controllers;
using AnimalsEntity;
using Project.Common;
using Humans.Entity;
using Human.Model.Common;
namespace Automapper.Model
{
    public class OrganizationProfile: Profile
    {
        public OrganizationProfile()
        {
            CreateMap<AnimalsRest, IAnimalModel>().ReverseMap();
            CreateMap<IAnimalModel, AnimalEntity>().ReverseMap();
            CreateMap<AnimalFilterModelRest, IAnimalFilterModel>().ReverseMap();
            CreateMap<AnimalSortModelRest, IAnimalSortModel>().ReverseMap();
            CreateMap<HumanFilterModelRest, IHumanFilterModel>().ReverseMap();
            CreateMap<HumanSortModelRest, IHumanSortModel>().ReverseMap();
            CreateMap<PagingModelRest, IPagingModel>().ReverseMap();
            CreateMap<IHumanModel, HumanEntity>().ReverseMap();
            CreateMap<IHumanModel, PeopleRest>().ReverseMap();
        }
    }
}