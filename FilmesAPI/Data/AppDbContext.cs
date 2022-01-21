using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    //Criando contexto para interação com banco de dados
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        //Fazendo a linkagem entre duas entidades
        //Nesse caso um endereço possui um cinema, porém o "HasForeingKey" faz com que o Cinema obrigatoriamente contenha um endereco, pelo ID
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relação de cinema -- endereço é de 1:1, ou seja, 1 endereço so pode possuir um cinema, e vice-versa
            modelBuilder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);

            //Relação gerente -- cinema é de 1:n pois 1 gerente pode possuir vários cinemas, mas um cinema só pode possuir um gerente
            //DeleteBehavior.Restrict impede que a deleção de um gerente delete os cinemas junto
            modelBuilder.Entity<Cinema>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relacionando Sessao com cinema -- um cinema pode ter várias sessoes, mas uma sessão pode ter apenas um cinema
            modelBuilder.Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessao => sessao.CinemaId);

            //Relacionando Sessao com filme -- um filme pode ter várias sessoes, mas uma sessão pode ter apenas um filme
            modelBuilder.Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId);
        }

        //Instancia nosso DataBase com base em nosso Model "Filme"
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set;}
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
    }
}
