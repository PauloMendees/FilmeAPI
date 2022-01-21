using FilmesAPI.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FilmesAPI.Data.Dtos.GerenteDTO
{
    public class ReadGerenteDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public virtual List<Cinema> Cinemas { get; set; }
    }
}
