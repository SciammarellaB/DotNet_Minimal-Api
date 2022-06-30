using Microsoft.EntityFrameworkCore;
using MinimalApi.Entity.Geral;

var builder = WebApplication.CreateBuilder(args);

//ADICIONAR SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//conexao banco
builder.Services.AddDbContext<MinimalApiContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Principal"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

//COLOCAR OS ENDPOINTS
app.MapGet("/Pessoa", async (MinimalApiContext dbContext) =>
{
    return await dbContext.Pessoas.AsNoTracking().ToListAsync();
});

app.MapGet("/Pessoa/{id}", async (long id, MinimalApiContext dbContext) =>
{
    return await dbContext.Pessoas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
});

app.MapPost("/Pessoa", async (Pessoa domain, MinimalApiContext dbContext) =>
{
    await dbContext.Pessoas.AddAsync(domain);
    await dbContext.SaveChangesAsync();

    return domain;
});

app.MapPut("/Pessoa/{id}", async (long id, Pessoa domain, MinimalApiContext dbContext) =>
{
    dbContext.Pessoas.Update(domain);
    await dbContext.SaveChangesAsync();
});

app.MapDelete("/Pessoa/{id}", async (long id, MinimalApiContext dbContext) =>
{
    var pessoa = await dbContext.Pessoas.FirstOrDefaultAsync(x => x.Id == id);

    if(pessoa != null)
    {
        dbContext.Pessoas.Remove(pessoa);
        await dbContext.SaveChangesAsync();
    }

    return;    
});

app.UseSwaggerUI();

//Atualizar Automático Migrations
using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    using (var context = serviceScope.ServiceProvider.GetService<MinimalApiContext>())
    {
        context.Database.Migrate();
    }
}

app.Run();

//Context
public class MinimalApiContext: DbContext
{
    public MinimalApiContext(DbContextOptions<MinimalApiContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

    //Classes
    public DbSet<Pessoa> Pessoas { get; set; }
}
