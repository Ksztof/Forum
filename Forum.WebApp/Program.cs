using Forum.Core.Interfaces.Answer;
using Forum.Core.Interfaces.AppUsers;
using Forum.Core.Interfaces.CommentToAnswer;
using Forum.Core.Interfaces.CommentToComment;
using Forum.Core.Interfaces.Question;
using Forum.Core.Services.Answer;
using Forum.Core.Services.AppUser;
using Forum.Core.Services.CommentToAnswer;
using Forum.Core.Services.CommentToComment;
using Forum.Core.Services.Question;
using Forum.Domain.Models;
using Forum.Domain.Models.Identities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//++++++++
builder.Services.AddTransient<IAppUserService, AppUserService>();
builder.Services.AddTransient<IUserProfileService, UserProfileService>();//to przerobioć//zapomniałem co?
builder.Services.AddTransient<IAnswerService, AnswerService>();
builder.Services.AddTransient<IQuestionService, QuestionService>();
builder.Services.AddTransient<ICommentToAnswerService, CommentToAnswerService>();
builder.Services.AddTransient<ICommentToCommentService, CommentToCommentService>();
//Identity dodanie kontekstu DB i konfiguracja połaczenia DB z modelami to identity
builder.Services.AddDbContext<ForumDb>();
builder.Services.AddIdentity<WebAppUser, WebAppRole>()
    .AddEntityFrameworkStores<ForumDb>()
    .AddDefaultTokenProviders();        //generate password reset token (email change etc.)
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = /*ściezka do logowania*/"/Account";
    options.ExpireTimeSpan = TimeSpan.FromHours(2);// długośc sesji
    options.AccessDeniedPath = "/Account";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/AppUser");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AppUser}/{action=Index}/{id?}");

app.Run();
