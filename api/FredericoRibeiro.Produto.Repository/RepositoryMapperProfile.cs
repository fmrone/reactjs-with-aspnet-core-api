using AutoMapper;

namespace FredericoRibeiro.Produto.Repository
{
    public class RepositoryMapperProfile : Profile
    {
        public RepositoryMapperProfile()
        {
            //mapeia de model para entity
            CreateMap<Domain.Models.Produto, Data.Entities.Produto>()
                .ForMember(model => model.Id, opt => opt.MapFrom(entity => entity.Id))
                .ForMember(model => model.Descricao, opt => opt.MapFrom(entity => entity.Descricao))
                .ForMember(model => model.Quantidade, opt => opt.MapFrom(entity => entity.Quantidade))
                .ForMember(model => model.Valor, opt => opt.MapFrom(entity => entity.Valor));

            //mapeia de entity para model
            CreateMap<Data.Entities.Produto, Domain.Models.Produto>()
                .ForMember(entity => entity.Id, opt => opt.MapFrom(model => model.Id))
                .ForMember(entity => entity.Descricao, opt => opt.MapFrom(model => model.Descricao))
                .ForMember(entity => entity.Quantidade, opt => opt.MapFrom(model => model.Quantidade))
                .ForMember(entity => entity.Valor, opt => opt.MapFrom(model => model.Valor));
        }
    }
}

