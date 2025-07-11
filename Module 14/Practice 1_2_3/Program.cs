var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

//app.UseEndpoints(endpoints =>
//{
//    app.MapControllerRoute(
//        name: "Default",
//        pattern: "/api/{controller}/{action}/{id?}"
//        //defaults: new
//        //{
//        //    controller = "Book",
//        //    action = "Index",
//        //}
//        );
////});
app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action}/{id?}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();