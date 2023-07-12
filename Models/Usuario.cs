using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Models;

public class Usuario : IdentityUser
{
    [DataType(DataType.DateTime)]
    public DateTime DataNascimento { get; set; }

    public Usuario() : base() { }
}