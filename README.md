# SmartWasteManagement — aplicação web de coleta inteligente

Projeto acadêmico em **ASP.NET Core MVC / .NET 8** para estudar o domínio de gerenciamento de resíduos e coletas.

## Funcionalidades representadas no código

A estrutura inclui controllers e modelos de:

- Agendamento de coleta
- Caminhões
- Moradores
- Notificações
- Recipientes
- Rotas

## Tecnologias

- C# / ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- Oracle Entity Framework Core
- AutoMapper
- Dockerfile

## Organização

O projeto principal está na raiz:

- `Controllers/` — entrada das requisições
- `Models/` — entidades e modelos
- `Services/` — lógica de serviços
- `Data/` e `Migrations/` — infraestrutura de dados
- `Views/` — telas MVC
- `Fiap.Web.SmartWasteManagement.sln` — solução

## Execução local

Requer **SDK .NET 8** e configuração das dependências externas:

```bash
dotnet restore Fiap.Web.SmartWasteManagement.sln
dotnet build Fiap.Web.SmartWasteManagement.sln
```

Configure seu banco de dados localmente. Não compartilhe dados sensíveis em `appsettings` nem em arquivos de usuário.

> Projeto de estudo; build, dependências externas e fluxos da aplicação devem ser verificados no ambiente de desenvolvimento antes de uso.
