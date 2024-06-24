using Application.Auhtors.Commands;
using Application.Auhtors.Queries;
using Application.BankAccounts.Commands;
using Application.BankAccounts.Queries;
using Application.Books.Queries;
using Application.Category.Commands;
using Application.Category.Queries;
using Application.Commands.Book;
using Application.Customer.Commands;
using Application.Customer.Queries;
using Application.Order.Commands;
using Application.Order.Queries;
using Application.OrderItem.Commands;
using Application.OrderItem.Queries;
using Application.Publishers.Commands;
using Application.Publishers.Queries;
using AutoMapper;
using Contracts.Requests.AuthorRequests;
using Contracts.Requests.BankAccount;
using Contracts.Requests.BankAccountRequests;
using Contracts.Requests.BookRequests;
using Contracts.Requests.CategoryRequests;
using Contracts.Requests.CustomerRequests;
using Contracts.Requests.OrderItemRequestsModel;
using Contracts.Requests.OrderRequests;
using Contracts.Requests.PublisherRequests;
using Contracts.Responses;
using Domain.Entities;


namespace Application.Mappers;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<CreateAuthorRequestModel, CreateAuthorCommand>();
        CreateMap<CreateAuthorRequestModel, AuthorEntity>();
        CreateMap<CreateAuthorCommand, AuthorEntity>();
        CreateMap<AuthorEntity, AuthorResponse>();
        CreateMap<UpdateAuthorRequestModel, UpdateAuthorCommand>();
        CreateMap<UpdateAuthorCommand, AuthorEntity>();
        CreateMap<GetAuthorQuery, AuthorEntity>();


        CreateMap<CreateBankAccountRequestModel, CreateBankAccountCommand>();
        CreateMap<CreateBankAccountRequestModel, BankAccountEntity>();
        CreateMap<CreateBankAccountCommand, BankAccountEntity>();
        CreateMap<BankAccountEntity, BankAccountResponse>();
        CreateMap<UpdateBankAccountRequestModel, UpdateBankAccountCommand>();
        CreateMap<UpdateBankAccountCommand, BankAccountEntity>();
        CreateMap<GetBankAccountQuery, BankAccountEntity>();

        CreateMap<CreateBookRequestsModel, CreateBookCommand>();
        CreateMap<CreateBookRequestsModel, BookEntity>();
        CreateMap<CreateBookCommand, BookEntity>();
        CreateMap<BookEntity, BookResponse>();
        CreateMap<UpdateBookRequestModel, UpdateBookCommand>();
        CreateMap<UpdateBookCommand, BookEntity>();
        CreateMap<GetBookQuery, BookEntity>();

        CreateMap<CreateCategoryRequestModel, CreateCategoryCommand>();
        CreateMap<CreateCategoryRequestModel, CategoryEntity>();
        CreateMap<CreateCategoryCommand, CategoryEntity>();
        CreateMap<CategoryEntity, CategoryResponse>();
        CreateMap<UpdateCategoryRequestModel, UpdateCategoryCommand>();
        CreateMap<UpdateCategoryCommand, CategoryEntity>();
        CreateMap<GetCategoryQuery, CategoryEntity>();

        CreateMap<CreateCustomerRequestModel, CreateCustomerCommand>();
        CreateMap<CreateCustomerRequestModel, CustomerEntity>();
        CreateMap<CreateCustomerCommand, CustomerEntity>();
        CreateMap<CustomerEntity, CustomerResponse>();
        CreateMap<UpdateCustomerRequestModel, UpdateCustomerCommand>();
        CreateMap<UpdateCustomerCommand, CustomerEntity>();
        CreateMap<GetCustomerQuery, CustomerEntity>();

        CreateMap<CreateOrderRequestModel, CreateOrderCommand>();
        CreateMap<CreateOrderRequestModel, OrderEnitity>();
        CreateMap<CreateOrderCommand, OrderEnitity>();
        CreateMap<OrderEnitity, OrderResponse>();
        CreateMap<UpdateOrderItemRequestModel, UpdateOrderCommand>();
        CreateMap<UpdateOrderCommand, OrderEnitity>();
        CreateMap<GetOrderQuery, OrderEnitity>();

        CreateMap<CreateOrderItemRequestModel, CreateOrderItemCommand>();
        CreateMap<CreateOrderItemRequestModel, OrderItemEntity>();
        CreateMap<CreateOrderItemCommand, OrderItemEntity>();
        CreateMap<OrderItemEntity, OrderItemResponse>();
        CreateMap<UpdateOrderItemRequestModel, UpdateOrderItemCommand>();
        CreateMap<UpdateOrderItemCommand, OrderItemEntity>();
        CreateMap<GetOrderItemQuery, OrderItemEntity>();


        CreateMap<CreatePublisherRequestModel, CreatePublisherCommand>();
        CreateMap<CreatePublisherRequestModel, PublisherEntity>();
        CreateMap<CreatePublisherCommand, PublisherEntity>();
        CreateMap<PublisherEntity, PublisherEntity>();
        CreateMap<UpdateOrderRequestModel, PublisherEntity>();
        CreateMap<UpdatePublisherCommand, PublisherEntity>();
        CreateMap<GetPublisherQuery, PublisherEntity>();
    }
}
