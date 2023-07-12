using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services;

public class UsuarioService
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;
    private SignInManager<Usuario> _signInManager;
    private TokenService _tokenService;

    public UsuarioService(UserManager<Usuario> userManager, IMapper mapper, SignInManager<Usuario> signInManager, TokenService tokenService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task CadastraAsync(CreateUsuarioDto dto)
    {
        Usuario user = _mapper.Map<Usuario>(dto);

        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

        if(!result.Succeeded) throw new ApplicationException("Falha ao cadastrar o usuário!");
    }

    public async Task<string> LoginAsync(LoginUsuarioDto dto)
    {
        var res = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if (!res.Succeeded)
        {
            throw new ApplicationException("Usuário não autenticado!");
        }

        var usuario = _signInManager
                            .UserManager
                            .Users
                            .FirstOrDefault(i => i.NormalizedUserName == dto.Username.ToUpper());

        var token = _tokenService.GenerateToken(usuario);

        return token;
    }
}