using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("usuario")]
public class UsuarioController : ControllerBase
{
    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("new")]
    public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto dto)
    {
        await _usuarioService.CadastraAsync(dto);

        return Ok("Usuário cadastrado com sucesso!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
    {
        var token = await _usuarioService.LoginAsync(dto);

        return Ok(token);
    }
}