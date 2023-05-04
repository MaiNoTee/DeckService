using DeckService.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDeckService, DeckService.Models.DeckService>();

builder.Services.AddCors(
	options =>
		options.AddPolicy(
			"CorsPolicy", policyBuilder => policyBuilder
				.AllowCredentials()
				.AllowAnyHeader()
				.WithOrigins("http://localhost:443")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
