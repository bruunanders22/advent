using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Program.CreateHostBuilder(args).Build().Run();

// builder.UseUrls("http://*:" + Environment.GetEnvironmentVariable("PORT"));

// Add services to the container.
builder.Services.AddRazorPages();

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

app.MapGet("/Environment", () =>
{
    return new EnvironmentInfo2();
});

// app.MapGet("/add/{first:int}/{second:int}", () => first + second);

app.MapGet("/add", (AddParams addparams) => addparams.ToJson());
app.MapGet("/concat", (ConcatParams concatparams) => concatparams.ToJson());

// app.MapGet("/hello/{name:alpha}", (string name) => $"Hello {name}!");
// app.MapGet("/add/{params}", (AddParams params) => $"Sum: {params}");

// app.MapGet("/Square", () =>
// {
//     var first = app.Request.Query["first"];
//     return first;
// });

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

