using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Dtos;

public class CreateUsuarioDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DataNascimento { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
}
