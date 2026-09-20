using Application;
using BattryShopApi.Exceptions;
using BattryShopApi.Extensions;
using Infrastructure;
using Infrastructure.Services.AuthorizationService;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.ConfigureApplication();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerService();
builder.Services.AddIdentityService();
builder.Services.AddJwtAuthenticationServices(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("Permission", policy =>
	{
		if (builder.Environment.IsDevelopment() == false)
		{
			policy.RequireAuthenticatedUser();
		}
		policy.AddRequirements(new PermissionRequirement());
	});
});

builder.Services.AddCors(options =>
{
	options.AddPolicy("front", policy =>
	{
		policy
			.WithOrigins("http://localhost:3000")
			.AllowAnyHeader()
			.AllowAnyMethod()
			.AllowCredentials();
	});
});

var app = builder.Build();

await app.SyncAuthorizationAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseCors("front");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers()
	.RequireAuthorization("Permission");

app.Run();
