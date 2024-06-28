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
        CreateMap<GetAuthorQuery, AuthorResponse>();
        CreateMap<GetAuthorsQuery, AuthorResponse>();
        CreateMap<DeleteAuthorCommand, AuthorEntity>();
        CreateMap<GetAllAuthorRequestModel, GetAuthorsQuery>();
        CreateMap<AuthorResponse, GetAllAuthorRequestModel>();

        CreateMap<CreateBankAccountRequestModel, CreateBankAccountCommand>();
        CreateMap<CreateBankAccountRequestModel, BankAccountEntity>();
        CreateMap<CreateBankAccountCommand, BankAccountEntity>();
        CreateMap<BankAccountEntity, BankAccountResponse>();
        CreateMap<UpdateBankAccountRequestModel, UpdateBankAccountCommand>();
        CreateMap<UpdateBankAccountCommand, BankAccountEntity>();
        CreateMap<GetBankAccountQuery, BankAccountEntity>();
        CreateMap<GetBankAccountQuery, BankAccountResponse>();
        CreateMap<GetBankAccountsQuery, AuthorResponse>();
        CreateMap<DeleteBankAccountCommand, BankAccountEntity>();
        CreateMap<GetAllBankAccountRequestModel, GetBankAccountsQuery>();
        CreateMap<BankAccountResponse, GetAllBankAccountRequestModel>();

        CreateMap<CreateBookRequestsModel, CreateBookCommand>();
        CreateMap<CreateBookRequestsModel, BookEntity>();
        CreateMap<CreateBookCommand, BookEntity>();
        CreateMap<BookEntity, BookResponse>();
        CreateMap<UpdateBookRequestModel, UpdateBookCommand>();
        CreateMap<UpdateBookCommand, BookEntity>();
        CreateMap<GetBookQuery, BookEntity>();
        CreateMap<GetBookQuery, BookResponse>();
        CreateMap<GetBooksQuery, BookResponse>();
        CreateMap<DeleteBookCommand, BookEntity>();
        CreateMap<GetAllBookRequestModel, GetBooksQuery>();
        CreateMap<BookResponse, GetAllBookRequestModel>();


        CreateMap<CreateCategoryRequestModel, CreateCategoryCommand>();
        CreateMap<CreateCategoryRequestModel, CategoryEntity>();
        CreateMap<CreateCategoryCommand, CategoryEntity>();
        CreateMap<CategoryEntity, CategoryResponse>();
        CreateMap<UpdateCategoryRequestModel, UpdateCategoryCommand>();
        CreateMap<UpdateCategoryCommand, CategoryEntity>();
        CreateMap<GetCategoryQuery, CategoryEntity>();
        CreateMap<GetCategoryQuery, CategoryResponse>();
        CreateMap<GetCategoriesQuery, CategoryResponse>();
        CreateMap<DeleteCategoryCommand, CategoryEntity>();
        CreateMap<GetAllCategoryRequestModel, GetCategoriesQuery>();
        CreateMap<CategoryResponse, GetAllCategoryRequestModel>();


        CreateMap<CreateCustomerRequestModel, CreateCustomerCommand>();
        CreateMap<CreateCustomerRequestModel, CustomerEntity>();
        CreateMap<CreateCustomerCommand, CustomerEntity>();
        CreateMap<CustomerEntity, CustomerResponse>();
        CreateMap<UpdateCustomerRequestModel, UpdateCustomerCommand>();
        CreateMap<UpdateCustomerCommand, CustomerEntity>();
        CreateMap<GetCustomerQuery, CustomerEntity>();
        CreateMap<GetCustomerQuery, CustomerResponse>();
        CreateMap<GetCustomersQuery, CustomerResponse>();
        CreateMap<DeleteCustomerCommand, CustomerEntity>();
        CreateMap<GetAllCustomerRequestModel, GetCustomersQuery>();
        CreateMap<CustomerResponse, GetAllCustomerRequestModel>();


        CreateMap<CreateOrderRequestModel, CreateOrderCommand>();
        CreateMap<CreateOrderRequestModel, OrderEnitity>();
        CreateMap<CreateOrderCommand, OrderEnitity>();
        CreateMap<OrderEnitity, OrderResponse>();
        CreateMap<UpdateOrderRequestModel, UpdateOrderCommand>();
        CreateMap<UpdateOrderCommand, OrderEnitity>();
        CreateMap<GetOrderQuery, OrderEnitity>();
        CreateMap<GetOrderQuery, OrderResponse>();
        CreateMap<GetOrdersQuery, OrderResponse>();
        CreateMap<DeleteOrderCommand, OrderEnitity>();
        CreateMap<GetAllOrderRequestModel, GetOrdersQuery>();
        CreateMap<OrderResponse, GetAllOrderRequestModel>();


        CreateMap<CreateOrderItemRequestModel, CreateOrderItemCommand>();
        CreateMap<CreateOrderItemRequestModel, OrderItemEntity>();
        CreateMap<CreateOrderItemCommand, OrderItemEntity>();
        CreateMap<OrderItemEntity, OrderItemResponse>();
        CreateMap<UpdateOrderItemRequestModel, UpdateOrderItemCommand>();
        CreateMap<UpdateOrderItemCommand, OrderItemEntity>();
        CreateMap<GetOrderItemQuery, OrderItemEntity>();
        CreateMap<GetOrderItemQuery, OrderItemResponse>();
        CreateMap<GetOrderItemsQuery, OrderItemResponse>();
        CreateMap<DeleteOrderItemCommand, OrderItemEntity>();
        CreateMap<GetAllOrderItemRequestModel, GetOrderItemsQuery>();
        CreateMap<OrderItemResponse, GetAllOrderItemRequestModel>();


        CreateMap<CreatePublisherRequestModel, CreatePublisherCommand>();
        CreateMap<CreatePublisherRequestModel, PublisherEntity>();
        CreateMap<CreatePublisherCommand, PublisherEntity>();
        CreateMap<PublisherEntity, PublisherResponse>();
        CreateMap<UpdatePublisherRequestModel, UpdatePublisherCommand>();
        CreateMap<UpdatePublisherCommand, PublisherEntity>();
        CreateMap<GetPublisherQuery, PublisherEntity>();
        CreateMap<GetPublisherQuery, PublisherResponse>();
        CreateMap<GetPublishersQuery, PublisherResponse>();
        CreateMap<DeletePublisherCommand, PublisherEntity>();
        CreateMap<GetAllPublisherRequestModel, GetPublishersQuery>();
        CreateMap<PublisherResponse, GetAllPublisherRequestModel>();
    }
}