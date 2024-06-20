using Application.Books.Queries;
using Application.Commands.Book;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<CreateAuthorRequestModel, Author>();
        CreateMap<Author, AuthorResponse>();
        CreateMap<UpdateAuthorRequestModel, Author>();

        CreateMap<CreateBankAccountRequestModel, BankAccount>();
        CreateMap<BankAccount, BankAccountResponse>();
        CreateMap<UpdateBankAccountRequestModel, BankAccount>();

        CreateMap<CreateBookRequestsModel, BookEntity>();
        CreateMap<CreateBookCommand, BookEntity>();
        CreateMap<BookEntity, BookResponse>();
        CreateMap<UpdateBookRequestModel, UpdateBookCommand>();
        CreateMap<UpdateBookCommand, BookEntity>();
        CreateMap<GetBookQuery, BookEntity>();


        CreateMap<CreateCategoryRequestModel, Category>();
        CreateMap<Category, CategoryResponse>();
        CreateMap<UpdateCategoryRequestModel, Category>();

        CreateMap<CreateCustomerRequestModel, Customer>();
        CreateMap<Customer, CustomerResponse>();
        CreateMap<UpdateCustomerRequestModel, Customer>();

        CreateMap<CreateOrderRequestModel, Order>();
        CreateMap<Order, OrderResponse>();
        CreateMap<UpdateOrderRequestModel, Order>();

        CreateMap<CreateOrderItemRequestModel, OrderItem>();
        CreateMap<OrderItem, OrderItemResponse>();
        CreateMap<UpdateOrderItemRequestModel, OrderItem>();

        CreateMap<CreatePublisherRequestModel, Publisher>();
        CreateMap<Publisher, PublisherResponse>();
        CreateMap<UpdatePublisherRequestModel, Publisher>();
    }
}
