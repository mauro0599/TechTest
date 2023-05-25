using BlazorCrud.Shared;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using BlazorCrud.Client.Services;

namespace BlazorCrud.Client.Extenciones
{
    public class AutenticacionExtension : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorageService;

        private ClaimsPrincipal _sinInformacion = new ClaimsPrincipal(new ClaimsIdentity());

        public AutenticacionExtension(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }

        public async Task ActualizarEstadoAutenticacion(SesionDTO? sesionUsuario)
        {
            ClaimsPrincipal claimsPrincipal;
            if (sesionUsuario != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name,sesionUsuario.Nombre),
                    new Claim(ClaimTypes.Email,sesionUsuario.Correo),
                    new Claim(ClaimTypes.Role,sesionUsuario.Rol),
                }, "JwtAuth"));

                await _sessionStorageService.GuardarStorage("SesionUsuario", sesionUsuario);
            }
            else
            {
                claimsPrincipal = _sinInformacion;
                await _sessionStorageService.RemoveItemAsync("SesionUsuario");
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionUsuario = await _sessionStorageService.ObtenerStorage<SesionDTO>("SesionUsuario");
            if(sesionUsuario == null)
            {
                return await Task.FromResult(new AuthenticationState(_sinInformacion));
            }
            else
            {
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name,sesionUsuario.Nombre),
                    new Claim(ClaimTypes.Email,sesionUsuario.Correo),
                    new Claim(ClaimTypes.Role,sesionUsuario.Rol),
                }, "JwtAuth"));
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));

            }
        }
    }
}
