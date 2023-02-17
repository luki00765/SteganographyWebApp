using SteganographyWebApp.CipherMethods.Implementations;
using SteganographyWebApp.CipherMethods.Interfaces;
using SteganographyWebApp.Steganography.Implementation;
using SteganographyWebApp.SteganographyMethods.Interfaces;
using SteganographyWebApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddScoped<ErrorHandlerMiddleware>();
builder.Services.AddTransient<ISteganographyMethod, LsbSteganographyMethod>();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin", builder => {
		builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
	});
});

builder.Services.AddTransient<ICipherMethod>(provider =>
{
	string strategy = provider.GetService<IHttpContextAccessor>().HttpContext.Request.Query.Keys.FirstOrDefault();
	return !string.IsNullOrEmpty(strategy) && strategy.ToLower() == "vigenere" ? new VigenereCipherMethod() : new CesarCipherMethod();
});

var app = builder.Build();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Steganography API"); });
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
app.UseCors("AllowSpecificOrigin");

app.Run();
