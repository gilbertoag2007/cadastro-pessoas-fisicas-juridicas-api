# API de Cadastro de Pessoas Físicas e Jurídicas

## Descrição

Esta API foi desenvolvida para gerenciar o cadastro de pessoas físicas e jurídicas, permitindo operações básicas de criação, consulta, edição e exclusão de registros. Através dela, é possível armazenar e manipular dados pessoais e empresariais, incluindo informações como CPF, CNPJ, endereços, contatos e documentos.

### Operações Disponíveis

- **Cadastro** de pessoas físicas e jurídicas
- **Consulta** detalhada por identificadores
- **Atualização** dos dados existentes
- **Exclusão** de registros
- Validações avançadas, como CPF e CNPJ válidos, restrição de duplicidade e consistência de dados

---

## Arquitetura

A API é construída seguindo o padrão **Clean Architecture simplificado**, o que garante:

- Separação clara de responsabilidades entre camadas
- Código desacoplado e fácil manutenção
- Testabilidade aprimorada
- Organização intuitiva com pastas para Application (casos de uso), Domain (entidades e regras), Infrastructure (acesso a dados, serialização), e API (controladores e configuração)

---

## Estilo da API

- Estilo RESTful
- Comunicação via JSON
- Utilização de verbos HTTP convencionais (GET, POST, PUT, DELETE)
- Tratamento padronizado de erros e respostas
- Documentação interativa via Swagger/OpenAPI

---

## Tecnologias Utilizadas

| Tecnologia                 | Versão     | Observações                                       |
|---------------------------|------------|--------------------------------------------------|
| .NET                       | 8.0        | Plataforma principal da API                       |
| Entity Framework Core      | 8.0        | ORM para acesso ao banco PostgreSQL               |
| PostgreSQL                 | 15.x       | Banco de dados relacional                          |
| AutoMapper                 | 12.0.1     | Mapeamento automático entre DTOs e entidades      |
| FluentValidation           | 11.8.2     | Validação de dados e regras de negócio             |
| Swashbuckle.AspNetCore     | 6.6.2      | Geração da documentação Swagger/OpenAPI            |
| Swashbuckle.AspNetCore.Filters | 6.6.2 | Suporte a exemplos e filtros na documentação Swagger |

---

## Banco de Dados

- Banco relacional **PostgreSQL** foi utilizado para persistência dos dados.
- Configurado via connection string no `appsettings.json`.
- Migrations automatizadas com Entity Framework Core para versionamento e atualização do esquema.
- Tipos específicos, como `DateOnly`, foram mapeados e tratados para garantir integridade e consistência.

---

## Como rodar a aplicação

1. Configure a string de conexão para seu banco PostgreSQL no arquivo `appsettings.json`.
2. Execute as migrations para criar o banco e as tabelas:
   ```bash
   dotnet ef database update
