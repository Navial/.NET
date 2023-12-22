var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/bank/tva/{valueToConvert}/{country}", (int price, string country) =>
{
    if (country == "BE")
    {
        return price * 1.21;
    }
    if (country == "FR")
    {
        return price * 1.20;
    }
    return 0;

});


app.Run();
