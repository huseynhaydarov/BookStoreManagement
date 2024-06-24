using Application.Auhtors.Commands;
using Application.Auhtors.Queries;
using Application.BankAccounts.Commands;
using Application.BankAccounts.Queries;
using Application.Books.Queries;
using Application.Category.Commands;
using Application.Category.Queries;
using Application.Commands.Book;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Common.Services;
using Application.Customer.Commands;
using Application.Customer.Queries;
using Application.Mappers;
using Application.Order.Commands;
using Application.Order.Queries;
using Application.OrderItem.Commands;
using Application.OrderItem.Queries;
using Application.Publishers.Commands;
using Application.Publishers.Queries;
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

//Authors
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreateAuthorCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdateAuthorCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetAuthorQuery).Assembly));

//Accounts
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreateBankAccountCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdateBankAccountCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetBankAccountQuery).Assembly));

//Books
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreateBookCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdateBookCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetBookQuery).Assembly));

//Categories
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdateCategoryCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetCategoryQuery).Assembly));

//Customers
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdateCustomerCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetCustomerQuery).Assembly));

//Customers
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreateOrderCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdateOrderCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetOrderQuery).Assembly));

builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreateOrderItemCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdateOrderItemCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetOrderItemQuery).Assembly));

builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CreatePublisherCommand).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UpdatePublisherCommandHandler).Assembly));
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetPublisherQuery).Assembly));
//builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateBookRequestValidator>());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseRepository<BookEntity>), typeof(BaseRepository<BookEntity>));
builder.Services.AddScoped(typeof(IBaseRepository<AuthorEntity>), typeof(BaseRepository<AuthorEntity>));
builder.Services.AddScoped(typeof(IBaseRepository<BankAccountEntity>), typeof(BaseRepository<BankAccountEntity>));
builder.Services.AddScoped(typeof(IBaseRepository<CategoryEntity>), typeof(BaseRepository<CategoryEntity>));
builder.Services.AddScoped(typeof(IBaseRepository<CustomerEntity>), typeof(BaseRepository<CustomerEntity>));
builder.Services.AddScoped(typeof(IBaseRepository<OrderEnitity>), typeof(BaseRepository<OrderEnitity>));
builder.Services.AddScoped(typeof(IBaseRepository<OrderItemEntity>), typeof(BaseRepository<OrderItemEntity>));
builder.Services.AddScoped(typeof(IBaseRepository<PublisherEntity>), typeof(BaseRepository<PublisherEntity>));



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
