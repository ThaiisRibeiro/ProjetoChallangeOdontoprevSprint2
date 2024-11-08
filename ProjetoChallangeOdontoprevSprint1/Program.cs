using Aplication.Aplication;
using Aplication.Interface;
using Domain.Entities;
using Domain.Interface;
using Infrastructure.Configuration;
using Infrastructure.Repository.Agendamento;
using Infrastructure.Repository.Clinica;
using Infrastructure.Repository.ContasPagar;
using Infrastructure.Repository.ContasReceber;
using Infrastructure.Repository.Dentista;
using Infrastructure.Repository.Fraude;
using Infrastructure.Repository.Generic;
using Infrastructure.Repository.Paciente;
using Infrastructure.Repository.TabelaPreco;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//1
var stringConexao = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=;Password=;";

builder.Services.AddDbContext<Context>
    (options => options.UseOracle(stringConexao));

//1


builder.Services.AddScoped<IPacienteRepository, RepositoryPaciente>();


builder.Services.AddScoped<IAgendamentoRepository, RepositoryAgendamento>();
builder.Services.AddScoped<IClinicaRepository, RepositoryClinica>();
builder.Services.AddScoped<IContasPagarRepository, RepositoryContasPagar>();
builder.Services.AddScoped<IContasReceberRepository, RepositoryContasReceber>();
builder.Services.AddScoped<IDentistaRepository, RepositoryDentista>();
builder.Services.AddScoped<IFraudeRepository, RepositoryFraude>();
builder.Services.AddScoped<ITabelaPrecoRepository, RepositoryTabelaPreco>();



builder.Services.AddScoped(typeof(InterfaceGeneric<>), typeof(RepositoryGeneric<>));
builder.Services.AddScoped <InterfacePacienteApp, AppPaciente> ();

builder.Services.AddScoped<InterfaceAgendamentoApp, AppAgendamento>();
builder.Services.AddScoped<InterfaceClinicaApp, AppClinica>();
builder.Services.AddScoped<InterfaceContasPagarApp, AppContasPagar>();
builder.Services.AddScoped<InterfaceContasReceberApp, AppContasReceber>();
builder.Services.AddScoped<InterfaceDentistaApp, AppDentista>();
builder.Services.AddScoped<InterfaceFraudeApp, AppFraude>();
builder.Services.AddScoped<InterfaceTabelaPrecoApp, AppTabelaPreco>();




/*services.AddSingleton (      typeof(InterfaceGenerica<>), typeof(RepositorioGenerico<>)       );
services.AddSingleton< InterfaceProduto, RepositorioProduto>();
services.AddSingleton<  InterfaceAppProduto, AppProduto>      ();*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
