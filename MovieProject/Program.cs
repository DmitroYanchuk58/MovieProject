using MovieDatabase.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "registration",
        pattern: "{controller=AuthenticateController}/{action=CreateUser}/{id?}");

    endpoints.MapControllerRoute(
        name: "deleteAccount",
        pattern: "{controller=AuthenticateController}/{action=DeleteUser}/{id?}");

    endpoints.MapControllerRoute(
       name: "changeAccountData",
       pattern: "{controller=AuthenticateController}/{action=UpdateUser}/{id?}");

    endpoints.MapControllerRoute(
       name: "getAccountData",
       pattern: "{controller=AuthenticateController}/{action=GetUser}/{id?}");

    endpoints.MapControllerRoute(
       name: "login",
       pattern: "{controller=AuthenticateController}/{action=Login}/{id?}");

    endpoints.MapControllerRoute(
       name: "createRate",
       pattern: "{controller=MovieController}/{action=CreateRate}/{id?}");

    endpoints.MapControllerRoute(
       name: "getRate",
       pattern: "{controller=MovieController}/{action=GetRate}/{id?}");

    endpoints.MapControllerRoute(
       name: "deleteRate",
       pattern: "{controller=MovieController}/{action=DeleteRate}/{id?}");

    endpoints.MapControllerRoute(
       name: "updateRate",
       pattern: "{controller=MovieController}/{action=UpdateRate}/{id?}");

    endpoints.MapControllerRoute(
       name: "createEmployee",
       pattern: "{controller=MovieController}/{action=CreateEmployee}/{id?}");

    endpoints.MapControllerRoute(
       name: "getEmployee",
       pattern: "{controller=MovieController}/{action=GetEmployee}/{id?}");

    endpoints.MapControllerRoute(
       name: "deleteEmployee",
       pattern: "{controller=MovieController}/{action=DeleteEmployee}/{id?}");

    endpoints.MapControllerRoute(
       name: "updateEmployee",
       pattern: "{controller=MovieController}/{action=UpdateEmployee}/{id?}");

    endpoints.MapControllerRoute(
       name: "createGenre",
       pattern: "{controller=MovieController}/{action=CreateGenre}/{id?}");

    endpoints.MapControllerRoute(
       name: "getGenre",
       pattern: "{controller=MovieController}/{action=GetGenre}/{id?}");

    endpoints.MapControllerRoute(
       name: "deleteGenre",
       pattern: "{controller=MovieController}/{action=DeleteGenre}/{id?}");

    endpoints.MapControllerRoute(
       name: "updateGenre",
       pattern: "{controller=MovieController}/{action=UpdateGenre}/{id?}");

    endpoints.MapControllerRoute(
       name: "createComment",
       pattern: "{controller=MovieController}/{action=CreateComment}/{id?}");

    endpoints.MapControllerRoute(
       name: "getComment",
       pattern: "{controller=MovieController}/{action=GetComment}/{id?}");

    endpoints.MapControllerRoute(
       name: "deleteComment",
       pattern: "{controller=MovieController}/{action=DeleteComment}/{id?}");

    endpoints.MapControllerRoute(
       name: "updateComment",
       pattern: "{controller=MovieController}/{action=UpdateComment}/{id?}");

    endpoints.MapControllerRoute(
       name: "createMovieGenre",
       pattern: "{controller=MovieController}/{action=CreateMovieGenre}/{id?}");

    endpoints.MapControllerRoute(
       name: "getMovieGenre",
       pattern: "{controller=MovieController}/{action=GetMovieGenre}/{id?}");

    endpoints.MapControllerRoute(
       name: "deleteMovieGenre",
       pattern: "{controller=MovieController}/{action=DeleteMovieGenre}/{id?}");

    endpoints.MapControllerRoute(
       name: "updateMovieGenre",
       pattern: "{controller=MovieController}/{action=UpdateMovieGenre}/{id?}");

    endpoints.MapControllerRoute(
       name: "createMovieEmployee",
       pattern: "{controller=MovieController}/{action=CreateMovieEmployee}/{id?}");

    endpoints.MapControllerRoute(
       name: "getMovieEmployee",
       pattern: "{controller=MovieController}/{action=GetMovieEmployee}/{id?}");

    endpoints.MapControllerRoute(
       name: "deleteMovieEmployee",
       pattern: "{controller=MovieController}/{action=DeleteMovieEmployee}/{id?}");

    endpoints.MapControllerRoute(
       name: "updateMovieEmployee",
       pattern: "{controller=MovieController}/{action=UpdateMovieEmployee}/{id?}");

    endpoints.MapControllerRoute(
       name: "createMovie",
       pattern: "{controller=MovieController}/{action=CreateMovie}/{id?}");

    endpoints.MapControllerRoute(
       name: "getMovie",
       pattern: "{controller=MovieController}/{action=GetMovie}/{id?}");

    endpoints.MapControllerRoute(
       name: "deleteMovie",
       pattern: "{controller=MovieController}/{action=DeleteMovie}/{id?}");

    endpoints.MapControllerRoute(
       name: "updateMovie",
       pattern: "{controller=MovieController}/{action=UpdateMovie}/{id?}");

    endpoints.MapControllerRoute(
       name: "getMostRateMovie",
       pattern: "{controller=MovieController}/{action=GetMostRateMovie}/{id?}");

    endpoints.MapControllerRoute(
       name: "getMostRateMovie",
       pattern: "{controller=MovieController}/{action=GetMovieByGenre}/{id?}");

    endpoints.MapControllerRoute(
        name: "getMovieByActor",
        pattern: "{controller=MovieController}/{action=GetMovieByActor}/{id?}");
});

app.Run();
