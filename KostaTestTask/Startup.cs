using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using KostaTestTask.Options;
using KostaTestTask.Extensions;

public class Startup
{
    public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
        Configuration = configuration;
        WebHostEnvironment = webHostEnvironment;
    }
    protected IWebHostEnvironment WebHostEnvironment { get; }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddLogging();
        services.AddMvc();
        services.Configure<DBOptions>(Configuration.GetSection(nameof(DBOptions)));
        services.AddDBServices();
    }
    
    public void Configure(IApplicationBuilder app)
    {
        app.UseDeveloperExceptionPage();
        app.UseStatusCodePages();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseEndpoints(config => config.MapControllers());

    }
}

