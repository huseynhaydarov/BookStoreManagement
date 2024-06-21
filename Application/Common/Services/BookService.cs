using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Exceptions;
using AutoMapper;
using Contracts.Requests.AuthorRequests;
using Contracts.Requests.BookRequests;
using Contracts.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services;

public class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
{
    
    public async Task<BookResponse> CreateAsync(CreateBookRequestsModel request, CancellationToken token = default)
    {
        var book = mapper.Map<BookEntity>(request);
        var response = await bookRepository.CreateAsync(book, token);
        return mapper.Map<BookResponse>(response);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
    {
        var book = await bookRepository.GetAsync(id, token);

        if(book is null)
        {
            throw new NotFoundException(nameof(book), id);
        }
        return await bookRepository.DeleteAsync(book, token);
    }

    public async Task<List<BookResponse>> GetAllAsync(CancellationToken token = default)
    {
        var response = await bookRepository.GetAllAsync(token);
        return mapper.Map<List<BookResponse>>(response);
    }

    public async Task<BookResponse?> GetAsync(int id, CancellationToken token = default)
    {
        var response = await bookRepository.GetAsync(id, token);

        if(response is null)
        {
            throw new NotFoundException(nameof(BookEntity), id);
        }
        return mapper.Map<BookResponse?>(response); 
    }

    public async Task UpdateAsync(int id, UpdateBookRequestModel request, CancellationToken token = default)
    {
        var book = await bookRepository.GetAsync(id, token);

        if (book is null)
        {
            throw new Exception($"Not found entity with the following id: {id}");
        }
        mapper.Map(request, book);
        await bookRepository.UpdateAsync(book, token);
    }
}
