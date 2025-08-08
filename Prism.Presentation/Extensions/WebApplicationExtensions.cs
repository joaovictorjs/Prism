using Microsoft.EntityFrameworkCore;
using Prism.Infrastructure.Data;
using Prism.Presentation.Components;

namespace Prism.Presentation.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseApplicationMiddlewares(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseAntiforgery();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapStaticAssets();
        app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
        app.MapBlazorHub(options => options.CloseOnAuthenticationExpiration = true);

        return app;
    }

    public static void InitializeDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
    }
}
