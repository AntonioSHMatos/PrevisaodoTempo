
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace PrevisaoDoTempo.Modelo
{
    public class Previsao
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Campo é Obrigatório")]
        public int Id { get; set; }

        [Display(Name = "Nome Da Cidade")]
        [Required(ErrorMessage = "O Nome da Cidade é Obrigatório.")]
        public string NomeDaCidade { get; set; }

        [Display(Name = "Temperatura Máxima")]
        public Decimal TemperaturaMaxima { get; set; }

        [Display (Name = "Temperatura Mínima")]
        public Decimal TemperaturaMinina { get; set; }

        [Display(Name = "Latitude")]
        public Decimal Latitude { get; set; }

        [Display(Name = "Longitude")]
        public Decimal Longitude { get; set; }

        [Display(Name = "Data de Previsão é Obrigatorio")]
        [Required(ErrorMessage = "Data da previsão obrigatório.")]
        public DateTime DataHoraPrevisao { get; set; }


        [Required(ErrorMessage = "Data Inclusão é Obrigatório")]
        public DateTime DataInclusao { get; set; }

    }
}
