using System.Reflection;
using Application.Auhtors.Commands;
using Application.Auhtors.Queries;
using Application.Authors.Commands;
using Application.BankAccounts.Commands;
using Application.BankAccounts.Queries;
using Application.Books.Commands;
using Application.Books.Queries;
using Application.Category.Commands;
using Application.Category.Queries;
using Application.Commands.Book;
using Application.Common.Interfaces.Repositories;
using Application.Customer.Commands;
using Application.Customer.Queries;
using Application.Mappers;
using Application.Order.Commands;
using Application.Order.Queries;
using Application.OrderItem.Commands;
using Application.OrderItem.Queries;
using Application.Publishers.Commands;
using Application.Publishers.Queries;
using Domain.Entities;
using FluentValidation.AspNetCore;
using Infrastructure.Middleware;
using Infrastructure.Persistence.DataBases;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Web.API.Validators.AuthorValidators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<BookRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.Decorate<IBookRepository, CachedBookRepository>();

builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.Decorate<IAuthorRepository, CachedAuthorRepository>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>(); // Add this line

builder.Services.AddProblemDetails();  // Add this line

// Adding of login 
builder.Services.AddLogging();  //  Add this line
builder.Services.AddStackExchangeRedisCache(redisOptions =>
{
    string connection = builder.Configuration
    .GetConnectionString("Redis");
    redisOptions.Configuration = connection;
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<EFContext>()
    .AddApiEndpoints();

builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddMemoryCache();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
//Authors
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreateAuthorCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdateAuthorCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DeleteAuthorCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetAuthorQuery).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetAuthorsQuery).Assembly));


//Accounts
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreateBankAccountCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdateBankAccountCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DeleteBankAccountCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetBankAccountQuery).Assembly));

//Books
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreateBookCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdateBookCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DeleteBookCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetBookQuery).Assembly));

//Categories
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdateCategoryCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DeleteCategoryCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetCategoryQuery).Assembly));

//Customers
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdateCustomerCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DeleteCategoryCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetCustomerQuery).Assembly));

//Customers
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreateOrderCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdateOrderCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DeleteOrderCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetOrderQuery).Assembly));

builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreateOrderItemCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdateOrderItemCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DeleteOrderItemCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetOrderItemQuery).Assembly));

builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreatePublisherCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdatePublisherCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DeletePublisherCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetPublisherQuery).Assembly));

//Validations
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateAuthorRequestValidator>());

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseRepository<BookEntity>), typeof(BaseRepository<BookEntity>));
builder.Services.AddScoped(typeof(IBaseRepository<AuthorEntity>), typeof(BaseRepository<AuthorEntity>));
builder.Services.AddScoped(typeof(IBaseRepository<BankAccountEntity>), typeof(BaseRepository<BankAccountEntity>));
builder.Services.AddScoped(typeof(IBaseRepository<CategoryEntity>), typeof(BaseRepository<CategoryEntity>));
builder.Services.AddScoped(typeof(IBaseRepository<CustomerEntity>), typeof(BaseRepository<CustomerEntity>));
builder.Services.AddScoped(typeof(IBaseRepository<OrderEnitity>), typeof(BaseRepository<OrderEnitity>));
builder.Services.AddScoped(typeof(IBaseRepository<OrderItemEntity>), typeof(BaseRepository<OrderItemEntity>));
builder.Services.AddScoped(typeof(IBaseRepository<PublisherEntity>), typeof(BaseRepository<PublisherEntity>));

builder.Services.AddScoped<IBankAccountRepository, BankAccountRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration).Assembly);
builder.Services.AddDbContext<EFContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapGroup("/Account").MapIdentityApi<IdentityUser>();

app.MapControllers();

app.Run();