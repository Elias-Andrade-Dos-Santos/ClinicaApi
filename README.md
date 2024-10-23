📋 ClínicaAPI - Sistema de Gerenciamento de Pacientes e Atendimentos
Este projeto é um sistema ASP.NET Core para gerenciar pacientes e atendimentos em uma clínica. Ele permite a criação, edição, exclusão e desativação de pacientes e atendimentos, além de oferecer listagens com filtros.

📁 Estrutura do Projeto
A aplicação segue o padrão SOLID e MVC para organizar a estrutura e manter o código modular, reutilizável e de fácil manutenção.

Controller: Lida com a lógica de entrada/saída da aplicação, direcionando requisições HTTP para as ações corretas.
Services: Camada de negócio onde as regras são aplicadas. Cada serviço implementa interfaces e segue os princípios de Dependency Injection.
Repositories: Camada de persistência de dados, responsável pela comunicação com o banco de dados. Usamos Entity Framework (EF Core) para lidar com o mapeamento objeto-relacional.
DTOs (Data Transfer Objects): Camada de transferência de dados que define o que será enviado ou recebido via API, ajudando a separar as entidades do domínio da lógica de exibição.
FluentValidation: Utilizado para validação de dados, garantindo que todas as entradas sejam verificadas antes de serem processadas.
AutoMapper: Usado para mapear as entidades para os DTOs, facilitando a conversão entre camadas.
🎯 Funcionalidades
Gerenciamento de Pacientes:
Listar, filtrar, cadastrar, editar, desativar e excluir.
Gerenciamento de Atendimentos:
Listar, filtrar, cadastrar, editar e excluir.
🛠️ Tecnologias Utilizadas
ASP.NET Core 6
Entity Framework Core
AutoMapper
FluentValidation
Swagger (para documentação da API)
MySQL ou SQL Server (para o banco de dados)
React com Vite.js, Context API, TypeScript, Sass (para o front-end)
📋 Requisitos
Antes de rodar o projeto, certifique-se de que você tem os seguintes itens instalados:

.NET 6 SDK
Visual Studio (ou Visual Studio Code)
SQL Server ou MySQL para o banco de dados
Node.js (para rodar o front-end com Vite.js)
