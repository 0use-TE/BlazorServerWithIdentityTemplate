using Microsoft.AspNetCore.Components.Authorization;

public class UserContext
{
    private readonly AuthenticationStateProvider _authStateProvider;

    public UserContext(AuthenticationStateProvider authStateProvider)
    {
        _authStateProvider = authStateProvider;
    }

    // 获取当前用户是否已登录
    public async Task<bool> IsAuthenticatedAsync()
    {
        var state = await _authStateProvider.GetAuthenticationStateAsync();
        return state.User.Identity?.IsAuthenticated ?? false;
    }

    // 获取当前用户名/ID
    public async Task<string?> GetUserNameAsync()
    {
        var state = await _authStateProvider.GetAuthenticationStateAsync();
        return state.User.Identity?.Name;
    }
}