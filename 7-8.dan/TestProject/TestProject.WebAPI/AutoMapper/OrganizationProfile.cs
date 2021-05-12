using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Animal.Model.Common;
using TestProject.WebAPI.Controllers;
using AnimalsEntity;

namespace Automapper.Model
{
    public class OrganizationProfile: Profile
    {
        public OrganizationProfile()
        {
            CreateMap<AnimalsRest, IAnimalModel>().ReverseMap();
        }
    }
}