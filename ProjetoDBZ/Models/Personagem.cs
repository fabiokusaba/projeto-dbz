using System.ComponentModel.DataAnnotations;

namespace ProjetoDBZ.Models;

public class Personagem
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    [MaxLength(50, ErrorMessage = "O campo nome precisa ter no máximo 50 caracteres")]
    public string Nome { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "O campo tipo é obrigatório")]
    [MaxLength(50, ErrorMessage = "O campo tipo precisa ter no máximo 50 caracteres")]
    public string Tipo { get; set; } = string.Empty;
}