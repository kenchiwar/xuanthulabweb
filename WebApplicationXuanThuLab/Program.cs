using Microsoft.Extensions.Options;
using WebApplicationXuanThuLab.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
//options.RootDirectory = "/Pages";
    options.Conventions.AddPageRoute("/index", "/");
});
builder.Services.AddDbContext<SinhVienContext>();

WebApplication app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapRazorPages();
app.Run();
