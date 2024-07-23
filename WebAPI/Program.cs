using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs.User;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSingleton<IUserService,UserManager>();
builder.Services.AddSingleton<IUserDal,EfUserDal>();
builder.Services.AddSingleton<IAccountService,AccountManager>();
builder.Services.AddSingleton<IAccountDal,EfAccountDal>();
builder.Services.AddSingleton<ICreditCardService, CreditCardManager>();
builder.Services.AddSingleton<ICreditCardDal, EfCreditCardDal>();
builder.Services.AddSingleton<IAccountCardService, AccountCardManager>();
builder.Services.AddSingleton<IAccountCardDal,EfAccountCardDal>();
builder.Services.AddSingleton<ITransaction, EfTransactionDal>();
builder.Services.AddSingleton<ITransactionService, TransactionManager>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(UserManager)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
