using AutoMapper;
using Fiap.Web.SmartWasteManagement.Data.Contexts;
using Fiap.Web.SmartWasteManagement.Data.Repository;
using Fiap.Web.SmartWasteManagement.Models;
using Fiap.Web.SmartWasteManagement.Services;
using Fiap.Web.SmartWasteManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Banco de Dados
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString)
);
#endregion

#region Registro IServiceCollection

builder.Services.AddScoped<ICaminhaoService, CaminhaoService>();
builder.Services.AddScoped<ICaminhaoRepository, CaminhaoRepository>();
builder.Services.AddScoped<IMoradorService, MoradorService>();
builder.Services.AddScoped<IMoradorRepository, MoradorRepository>();
builder.Services.AddScoped<INotificacaoService, NotificacaoService>();
builder.Services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
builder.Services.AddScoped<IRecipienteService, RecipienteService>();
builder.Services.AddScoped<IRecipienteRepository, RecipienteRepository>();
builder.Services.AddScoped<IRotaService, RotaService>();
builder.Services.AddScoped<IRotaRepository, RotaRepository>();
builder.Services.AddScoped<IAgendamentoColetaService, AgendamentoColetaService>();
builder.Services.AddScoped<IAgendamentoColetaRepository, AgendamentoColetaRepository>();

#endregion

#region Automapper

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AllowNullCollections = true;
    cfg.AllowNullDestinationValues = true;
    //cfg.CreateMap<CaminhaoModel, CaminhaoViewModel>();
    //cfg.CreateMap<CaminhaoViewModel, CaminhaoModel>();
    //cfg.CreateMap<IEnumerable<CaminhaoModel>, IEnumerable<CaminhaoViewModel>>();
    //cfg.CreateMap<MoradorModel, MoradorViewModel>();
    //cfg.CreateMap<MoradorViewModel, MoradorModel>();
    //cfg.CreateMap<IEnumerable<MoradorModel>, IEnumerable<MoradorViewModel>>();
    //cfg.CreateMap<NotificacaoModel, NotificacaoViewModel>();
    //cfg.CreateMap<NotificacaoViewModel, NotificacaoModel>();
    //cfg.CreateMap<IEnumerable<NotificacaoModel>, IEnumerable<NotificacaoViewModel>>();
    //cfg.CreateMap<RecipienteModel, RecipienteViewModel>();
    //cfg.CreateMap<RecipienteViewModel, RecipienteModel>();
    //cfg.CreateMap<IEnumerable<RecipienteModel>, IEnumerable<RecipienteViewModel>>();
    //cfg.CreateMap<RotaModel, RotaViewModel>();
    //cfg.CreateMap<RotaViewModel, RotaModel>();
    //cfg.CreateMap<IEnumerable<RotaModel>, IEnumerable<RotaViewModel>>();
    //cfg.CreateMap<AgendamentoColetaModel, AgendamentoColetaViewModel>();
    //cfg.CreateMap<AgendamentoColetaViewModel, AgendamentoColetaModel>();
    //cfg.CreateMap<IEnumerable<AgendamentoColetaModel>, IEnumerable<AgendamentoColetaViewModel>>();
    cfg.CreateMap<CaminhaoModel, CaminhaoViewModel>().ReverseMap();
    cfg.CreateMap<MoradorModel, MoradorViewModel>().ReverseMap();
    cfg.CreateMap<NotificacaoModel, NotificacaoViewModel>().ReverseMap();
    cfg.CreateMap<RecipienteModel, RecipienteViewModel>().ReverseMap();
    cfg.CreateMap<RotaModel, RotaViewModel>().ReverseMap();
    cfg.CreateMap<AgendamentoColetaModel, AgendamentoColetaViewModel>().ReverseMap();
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));

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
