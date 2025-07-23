using AutoMapper;
using cadastro_pessoas_fisicas_juridicas_api.Application.DTOs;
using cadastro_pessoas_fisicas_juridicas_api.Domain.Entities;

namespace cadastro_pessoas_fisicas_juridicas_api.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Pessoa Física
            CreateMap<PessoaFisica, PessoaFisicaRequestDto>().ReverseMap();
            CreateMap<PessoaFisica, PessoaFisicaResponseDto>().ReverseMap();

            // Pessoa Jurídica
            CreateMap<PessoaJuridica, PessoaJuridicaRequestDto>().ReverseMap();
            CreateMap<PessoaJuridica, PessoaJuridicaResponseDto>().ReverseMap();

            // Endereço
            CreateMap<Endereco, EnderecoDto>().ReverseMap();

            // Telefones
            CreateMap<Telefone, TelefoneDto>().ReverseMap();

            // Presença Online
            CreateMap<PresencaOnLine, PresencaOnlineDto>().ReverseMap();
        }
    }
    }

