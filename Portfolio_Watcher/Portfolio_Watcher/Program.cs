using Core.Data.Repository;
using Core.Domain.Interfaces;
using Core.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//ToDo: add depedency injection for repo DB connectionstring
builder.Services.AddRazorPages();

builder.Services.AddScoped<IPortfolioRepository, PortfolioRepo>();
builder.Services.AddScoped<PortfolioService>();

builder.Services.AddScoped<ITradeRepository, TradeRepo>();
builder.Services.AddScoped<TradeService>();

builder.Services.AddScoped<ISymbolRepository, SymbolRepo>();
builder.Services.AddScoped<SymbolService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
