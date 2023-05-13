using System.Security.Claims;
using Blazored.SessionStorage;
using Test.Shared;

namespace Test.Client.Extensiones
{
    public class AuthenticationExtension:AuthenticationStateProvider
    {

        private readonly ISessionStorageService _sessionStorage;
        private ClaimsPrincipal _noInfo = new ClaimsPrincipal(new ClaimsIdentity());

        public AuthenticationExtension(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public async Task UpdateAuthState(SesionDTO? sesionDto)
        {
            ClaimsPrincipal claimsPrincipal;
            if (sesionDto!=null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, sesionDto.Username),
                    new Claim(ClaimTypes.Role, sesionDto.Rol),
                },"JwtAuth"));
                await _sessionStorage.SaveStorage("sesionDto", sesionDto);

            }
            else
            {
                claimsPrincipal = _noInfo;
                await _sessionStorage.RemoveItemAsync("sesionDto");
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionDto = await _sessionStorage.ObtainStorage<SesionDTO>("sesionDto");
            if (sesionDto == null)
            {
                return await Task.FromResult(new AuthenticationState(_noInfo));


            }
            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, sesionDto.Username),
                new Claim(ClaimTypes.Role, sesionDto.Rol),
            }, "JwtAuth"));
            await _sessionStorage.SaveStorage("sesionDto", sesionDto);
            return await Task.FromResult(new AuthenticationState(claimPrincipal));
        }
    } 
}
