# FilmeAPI

##Features

Essa API apresenta dois projetos em uma mesma solução, sendo eles:
  -API de autenticação --> UsuariosAPI;
  -API de filmes       --> FilmesAPI;
  -A API de filmes é linkada com a de autenticação;
  -A API de autenticação apresenta EmailService;
  

##Como iniciar

Para iniciar a aplicação, algumas dependências são necessárias, sendo elas:
  -AutoMapper       -->   8.1
  -FluentResults    -->   2.5
  -MailKit          -->   2.14
  -Pacotes Microsoft
    *Authentication.JwtBearer       -->   5.0.11
    *Authorization                  -->   5.0.11
    *Identity                       -->   2.20
    *IdentityEntityFramework        -->   5.0.5
    *Entity(core, proxies, tools)   -->   5.0.5
  -MimeKit          -->   2.14.0
  -MySQL.Entity     -->   5.0.3
  -Swashbuckle      -->   5.6.3
  -Tokens.JWT       -->   6.15.0
  -Também será necessário utilizar um banco de dados MySQL.
    
