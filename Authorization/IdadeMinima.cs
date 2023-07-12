using Microsoft.AspNetCore.Authorization;

namespace UsuariosAPI.Authorization;

public class IdadeMinima : IAuthorizationRequirement
{
    public int Idade { get; set; }

    public IdadeMinima(int idade)
    {
        Idade = idade;
    }
}