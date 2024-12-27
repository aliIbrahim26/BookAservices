using AutoMapper;
using BookAservices.Application.Featcuer.Differen;
using BookAservices.Application.Featcuer.OptionsDifferen;
using BookAservices.Application.Featcuer.Orders;
using BookAservices.Application.Featcuer.Service;
using BookAservices.Application.Featcuer.ServicesRequest;
using BookAservices.Domain;

namespace BookAservices.Application
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<Services,GetListService>().ReverseMap();
            CreateMap<Services,GetOneService>().ReverseMap();
            CreateMap<Services,CreateServiceQuery>().ReverseMap();
            CreateMap<Services, UpdateServiceQuerry>().ReverseMap();
            CreateMap<Services, DeleteServiceQuerry>().ReverseMap();

            CreateMap<ServiceRequest, GetListServiceRequest>().ReverseMap();
            CreateMap<ServiceRequest, GetOneServiceRequest>().ReverseMap();
            CreateMap<ServiceRequest, CreateServiceRequestQuerry>().ReverseMap();
            CreateMap<ServiceRequest, UpdateServiceRequestQuerry>().ReverseMap();
            CreateMap<ServiceRequest, DeleteServiceRequestQuerry>().ReverseMap();

            CreateMap<Order, GetListOrder>().ReverseMap();
            CreateMap<Order, GetOneOrder>().ReverseMap();
            CreateMap<Order,CreateOrderQuerry>().ReverseMap();
            CreateMap<Order, UpdateOrderQuerry>().ReverseMap();
            CreateMap<Order, DeleteOrderQuerry>().ReverseMap();
            CreateMap<OrderDetail, OrderDetails>().ReverseMap();

            CreateMap<Differences, GetListDifference>().ReverseMap();
            CreateMap<Differences, GetOneDifference>().ReverseMap();
            CreateMap<Differences, CreateDifferenceQuerry>().ReverseMap();
            CreateMap<Differences, UpdateDifferenceQuerry>().ReverseMap();
            CreateMap<Differences, DeleteDifferenceQuerry>().ReverseMap();
            CreateMap<DifferencesData, DifferenceData>().ReverseMap();
            CreateMap<DifferenceData, DifferenceDatas>().ReverseMap();

            CreateMap<OptionsDifference, GetListOptionsDifference>().ReverseMap();
            CreateMap<OptionsDifference, GetOneOptionsDifference>().ReverseMap();
            CreateMap<OptionsDifference, CreateOptionsDifferenceQuerry>().ReverseMap();
            CreateMap<OptionsDifference, UpdateOptionsDifferenceQuerry>().ReverseMap();
            CreateMap<OptionsDifference,  DeleteOptionsDifferenceQuerry>().ReverseMap();
            CreateMap<OptionsDifferencesData, OptionsDifferenceData>().ReverseMap();


        }
    }
}
