
using BlazorServerWithIdentityTemplate.DataPersistence.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BlazorServerWithIdentityTemplate.Services
{
    public class DefaultUser
    {
        public string Account { get; set; } = "";
        public string Password { get; set; } = "";
    }
    public class DefaultUserInitializer : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DefaultUserInitializer> _logger;

        public DefaultUserInitializer(IServiceProvider serviceProvider, ILogger<DefaultUserInitializer> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var defaultUser = scope.ServiceProvider.GetRequiredService<IOptions<DefaultUser>>().Value;

                var existingUser = await userManager.FindByNameAsync(defaultUser.Account);

                if (existingUser == null)
                {
                    var newUser = new ApplicationUser { UserName = defaultUser.Account };
                    var result = await userManager.CreateAsync(newUser, defaultUser.Password);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation($"默认用户 {defaultUser.Account} 创建成功！");
                    }
                    else
                    {
                        _logger.LogError($"默认用户 {defaultUser.Account} 创建失败！");
                        foreach (var error in result.Errors)
                        {
                            _logger.LogError($"错误: {error.Description}");
                        }
                    }
                }
                else
                {
                    _logger.LogInformation($"默认用户 {defaultUser.Account} 已存在！");
                }
            }
        }
    }
}