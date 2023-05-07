# Api.MySql.ASPNET.Core

Este projeto ASP NET Core 6 se trata de uma api e teste feita com EF Core e MySql
Ela demonstra a criação e implantação da API no Azure como um Serviço de aplicativo utilizando
o plano gratuito de requisições com 60 min por dia de recursos.
O banco de dados é em MySql e está hospedado em um outro servidor gratuito smarterasp.net 

### Composição 👋
- Template do ASP NET Core Web Application
- Visual Studio 2022
- Pacotes
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.Design
  - Pomelo.EntityFrameworkCore.MySql
  - Microsoft.EntityFrameworkCore.Tools
  - Microsoft.VisualStudio.Azure.Containers.Tools.Targets
  - Microsoft.VisualStudio.Azure.Containers.Tools.Targets
  - Microsoft.VisualStudio.Web.CodeGeneration.Design
  - Swashbuckle.AspNetCore
- MySql 8
- Trabalhando com Migration
- Documentação com Swagger

Obs.: 30 min de prática.
<hr>
1. Criar projeto API Web do ASP.NET Core
2. Instalar pacotes 
   - Microsoft.EntityFrameworkCore
   - Microsoft.EntityFrameworkCore.Design
   - Pomelo.EntityFrameworkCore.MySql
   - Microsoft.EntityFrameworkCore.Tools
   - Microsoft.VisualStudio.Azure.Containers.Tools.Targets
   - Microsoft.VisualStudio.Azure.Containers.Tools.Targets
   - Microsoft.VisualStudio.Web.CodeGeneration.Design
3. Criar classe Estado na pasta models
```c#
    public class Estado
    {
        [Key]
        [StringLength(2,MinimumLength =2, ErrorMessage ="O campo sigla deve conter 2 caracteres")]
        public string Sigla { get; set; }

        [Required(ErrorMessage ="O campo nome é obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O campo nome deve conter entre 3 e 200 caracteres.")]
        public string Nome { get; set; }
    }
```
4. Criar classe de contexto na pastas Data
```c#
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Estado> Estados { get; set; }
    }
 ```
5. Configurar connection string no appsettings.json
```json
"ConnectionStrings": {
    "Conexao": "Server=MYSQL8002.site4now.net;Database=db_a87b2f_test1;Uid=a87b2f_test1;Pwd=SENHA"
  }
```   
6. Criar controller viar Novo Item com Scaffolding
7. Tipo Controlador de API com ações usando EntityFramework
   - Selecione Classe do Modelo
   - Selecione Classe DbContext
   - selecione Nome do controlador
   
8. No Program.cs adicione  (Configurando o DbContext)
```c#
   // Add services to the container.
var connectionStringMySql = builder.Configuration.GetConnectionString("Conexao");
builder.Services.AddDbContext<ApiDbContext>(options => 
{
    options.UseMySql(
        connectionStringMySql,
        ServerVersion.Parse("8.0.29"));
    });
```
9. Compile a solução

10. Acessar o Console do Gerenciador de pacotes
11. Executar os comandos para criar a migração:
12. add-migration inicial
13. update-database


14. Acessar o portal azure https://portal.azure.com/#create/hub
15. Selecionar criar Aplicativo Web
    - Criar grupo de recursos
	- Nome
	- Publicar: código
	- Pilha de runtime: .NEt 6
	- Sistema Operacional: Linux
	- Região Brazil South
	- Plano de preços: Gratuito F1 (Infraestrutura compartilhada)
16. Cria o recursos

17. Após a criação acesse Centro de Implantação, e configure o repositório GitHub
    Ele irá criar o arquivo de deploy CI/CD no branch mais
	
18. Todos os commits na branch main iram disparar o deploy 

<hr>