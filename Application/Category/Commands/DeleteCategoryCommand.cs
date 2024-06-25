using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Category.Commands;

public record DeleteCategoryCommand : IRequest<bool>
{
    public int Id { get; set; }
}
public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetAsync(request.Id, cancellationToken);

        if (category is null)
        {
            throw new NotFoundException(nameof(category), request.Id);
        }

        await _categoryRepository.DeleteAsync(category, cancellationToken);
        return true;
    }
}
