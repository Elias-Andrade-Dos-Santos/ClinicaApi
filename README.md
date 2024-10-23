<h1>📋 ClínicaAPI - Sistema de Gerenciamento de Pacientes e Atendimentos</h1>

<p>
Este projeto é um sistema <strong>ASP.NET Core</strong> para gerenciar pacientes e atendimentos em uma clínica. Ele permite a criação, edição, exclusão e desativação de pacientes e atendimentos, além de oferecer listagens com filtros.
</p>

<h2>📁 Estrutura do Projeto</h2>

<p>
A aplicação segue o padrão <strong>SOLID</strong> e <strong>MVC</strong> para organizar a estrutura e manter o código modular, reutilizável e de fácil manutenção.
</p>

<ul>
  <li><strong>Controller</strong>: Lida com a lógica de entrada/saída da aplicação, direcionando requisições HTTP para as ações corretas.</li>
  <li><strong>Services</strong>: Camada de negócio onde as regras são aplicadas. Cada serviço implementa interfaces e segue os princípios de <em>Dependency Injection</em>.</li>
  <li><strong>Repositories</strong>: Camada de persistência de dados, responsável pela comunicação com o banco de dados usando <strong>Entity Framework (EF Core)</strong>.</li>
  <li><strong>DTOs (Data Transfer Objects)</strong>: Camada de transferência de dados que separa entidades do domínio da lógica de exibição.</li>
  <li><strong>FluentValidation</strong>: Usado para validação de dados de entrada.</li>
  <li><strong>AutoMapper</strong>: Usado para mapear as entidades para os DTOs, facilitando a conversão entre camadas.</li>
</ul>

<h2>🎯 Funcionalidades</h2>

<ul>
  <li><strong>Gerenciamento de Pacientes:</strong> Listar, filtrar, cadastrar, editar, desativar e excluir pacientes.</li>
  <li><strong>Gerenciamento de Atendimentos:</strong> Listar, filtrar, cadastrar, editar e excluir atendimentos.</li>
</ul>

<h2>🛠️ Tecnologias Utilizadas</h2>

<ul>
  <li><strong>ASP.NET Core 8</strong></li>
  <li><strong>Entity Framework Core</strong></li>
  <li><strong>AutoMapper</strong></li>
  <li><strong>FluentValidation</strong></li>
  <li><strong>Swagger</strong> para documentação da API</li>
  <li><strong>MySQL</strong> ou <strong>SQL Server</strong> para o banco de dados</li>
  <li><strong>React com Vite.js, Context API, TypeScript, Sass</strong> para o front-end</li>
</ul>

<h2>📋 Requisitos</h2>

<ul>
  <li>.NET 8 SDK</li>
  <li>Visual Studio ou Visual Studio Code</li>
  <li>SQL Server ou MySQL para o banco de dados</li>
  <li>Node.js (para rodar o front-end com Vite.js)</li>
</ul>

<h2>🚀 Como Configurar o Projeto</h2>

<h3>1. Clonando o Repositório</h3>

<pre><code>
git clone https://github.com/Elias-Andrade-Dos-Santos/ClinicaApi.git
cd ClinicaAPI
</code></pre>

<h3>2. Configurando o Banco de Dados</h3>

<p>Crie um banco de dados no MySQL ou SQL Server. Depois, configure a string de conexão no arquivo <strong>appsettings.json</strong>.</p>

<p><strong>Exemplo com MySQL:</strong></p>

<pre><code>
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ClinicaDB;User=root;Password=senha;"
}
</code></pre>

<p><strong>Exemplo com SQL Server:</strong></p>

<pre><code>
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ClinicaDB;Trusted_Connection=True;"
}
</code></pre>

<h3>3. Executando as Migrações do Banco de Dados</h3>

<p>Execute o seguinte comando para garantir que todas as tabelas e relacionamentos sejam criados no banco de dados:</p>

<pre><code>
dotnet ef migrations add init
dotnet ef database update
</code></pre>

<h3>4. Rodando a Aplicação</h3>

<p>Depois de configurar o banco de dados, rode o projeto com o comando:</p>

<pre><code>
dotnet run
</code></pre>

<h3>5. Acessando a API com Swagger</h3>

<p>Abra o navegador e acesse a seguinte URL para visualizar a documentação da API no Swagger:</p>

<pre><code>
http://localhost:5143/swagger/index.html
</code></pre>

<h2>🧑‍💻 Design Patterns Utilizados</h2>

<h3>1. Repository Pattern</h3>

<p>O padrão <strong>Repository</strong> é utilizado para abstrair as interações com o banco de dados, centralizando o código de acesso a dados.</p>

<pre><code>
public interface IPatientRepository {
    Task<Patient> GetByIdAsync(int id);
    Task AddAsync(Patient patient);
    Task UpdateAsync(Patient patient);
    Task DeleteAsync(int id);
}
</code></pre>

<h3>2. Dependency Injection</h3>

<p>A injeção de dependência é usada para gerenciar dependências entre as classes. Repositórios, serviços e validadores são injetados via construtores, tornando o código mais flexível e testável.</p>

<pre><code>
public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public PatientService(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }
}
</code></pre>

<h3>3. DTO (Data Transfer Objects)</h3>

<p>Os <strong>DTOs</strong> transferem dados entre camadas da aplicação, garantindo que apenas as informações necessárias sejam expostas.</p>

<pre><code>
public class PatientDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public bool IsActive { get; set; }
}
</code></pre>

<h3>4. FluentValidation</h3>

<p>O <strong>FluentValidation</strong> é usado para validar as entradas do usuário antes do processamento.</p>

<pre><code>
public class PatientValidator : AbstractValidator<PatientDTO>
{
    public PatientValidator()
    {
        RuleFor(p => p.CPF)
            .NotEmpty().WithMessage("CPF é obrigatório.")
            .Length(11).WithMessage("O CPF deve ter 11 dígitos.");
    }
}
</code></pre>

<h3>5. AutoMapper</h3>

<p>O <strong>AutoMapper</strong> mapeia entidades para <strong>DTOs</strong> e vice-versa, facilitando a conversão entre camadas.</p>

<pre><code>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap&lt;Patient, PatientDTO&gt;().ReverseMap();
    }
}
</code></pre>

