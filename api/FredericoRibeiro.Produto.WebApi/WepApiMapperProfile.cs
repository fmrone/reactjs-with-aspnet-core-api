using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FredericoRibeiro.Produto.WebApi
{
    public class WepApiMapperProfile : Profile
    {
        public WepApiMapperProfile()
        {
            //mapeia de dto para model
            CreateMap<Dtos.ProdutoDto, Domain.Models.Produto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Descricao, opt => opt.MapFrom(model => model.Descricao))
                .ForMember(dto => dto.Quantidade, opt => opt.MapFrom(model => model.Quantidade))
                .ForMember(dto => dto.Valor, opt => opt.MapFrom(model => model.Valor));

            //mapeia de model para dto
            CreateMap<Domain.Models.Produto, Dtos.ProdutoDto>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(model => model.Descricao, opt => opt.MapFrom(dto => dto.Descricao))
                .ForMember(model => model.Quantidade, opt => opt.MapFrom(dto => dto.Quantidade))
                .ForMember(model => model.Valor, opt => opt.MapFrom(dto => dto.Valor));
        }
    }
}


