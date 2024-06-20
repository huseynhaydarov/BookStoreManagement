using Application.Books.Queries;
using Application.Commands.Book;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Common.Services;
using Application.Mappers;
using Contracts.Validators.BookValidators;
using Domain.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence.DataBases;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreateBookCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdateBookCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetBookQuery).Assembly));

//builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateBookRequestValidator>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseRepository<BookEntity>), typeof(BaseRepository<BookEntity>));
builder.Services.AddScoped(typeof(IBaseRepository<Author>), typeof(BaseRepository<Author>));
builder.Services.AddScoped(typeof(IBaseRepository<BankAccount>), typeof(BaseRepository<BankAccount>));
builder.Services.AddScoped(typeof(IBaseRepository<Category>), typeof(BaseRepository<Category>));
builder.Services.AddScoped(typeof(IBaseRepository<Customer>), typeof(BaseRepository<Customer>));
builder.Services.AddScoped(typeof(IBaseRepository<Order>), typeof(BaseRepository<Order>));
builder.Services.AddScoped(typeof(IBaseRepository<OrderItem>), typeof(BaseRepository<OrderItem>));
builder.Services.AddScoped(typeof(IBaseRepository<Publisher>), typeof(BaseRepository<Publisher>));



builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBankAccountRepository, BankAccountRepository>();
builder.Services.AddScoped<IBankAccountService, BankAccountService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IPublisherService, PublisherService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration).Assembly);
builder.Services.AddDbContext<EFContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
