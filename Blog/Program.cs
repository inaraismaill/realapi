using Blog.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Blog.Business;
using Microsoft.AspNetCore.Identity;
using Blog.Core.Entities;
using Blog.Core.Enum;
using System.Text;
using Blog.Business.Exceptions.AppUser;
using Blog.API;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var jwt = builder.Configuration.GetSection("Jwt").Get<Jwt>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddDbContext<BlogContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql")));
builder.Services.AddUserIdentity();
builder.Services.AddBusinessLayer();
builder.Services.AddAuth(jwt);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
    }); ;
}
app.UseHttpsRedirection();
app.Use(async (context, next) =>
{
    using(var scope= context.RequestServices.CreateScope())
    {
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if(!await roleManager.Roles.AnyAsync())
        {
            foreach(var role in Enum.GetNames(typeof(Roles)))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(role));
                if(!result.Succeeded)
                {
                    StringBuilder sb=new StringBuilder();
                    foreach(var error in result.Errors)
                    {
                        sb.Append(error.Description + " ");
                    }
                    throw new Exception(sb.ToString().TrimEnd()); 
                }
            }
            if (await userManager.FindByNameAsync(app.Configuration.GetSection("Admin")["Username"]) == null)
            {
                var user = new AppUser
                {
                    UserName = app.Configuration.GetSection("Admin")["Username"],
                    Email = app.Configuration.GetSection("Admin")["Username"]
                };
                var result =await userManager.CreateAsync(user, app.Configuration.GetSection("Admin")["Password"]);
                if (!result.Succeeded)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var error in result.Errors)
                    {
                        sb.Append(error.Description + " ");
                    }
                    throw new AppUserCreatedFailledException(sb.ToString().TrimEnd());
                }
                await userManager.AddToRoleAsync(user, nameof(Roles.Admin));
            }
        }
    }
    await next();
});

app.UseAuthorization();
app.MapControllers();

app.Run();
