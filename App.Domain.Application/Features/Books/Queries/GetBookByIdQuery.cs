﻿using App.Domain.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.Application.Features.Books.Queries
{
    /// <summary>
    /// Query Parameters
    /// </summary>
    public class GetBookByIdQuery : IRequest<BookViewModel>
    {
        public int? Id { get; set; }
    }

    public class Validator : AbstractValidator<GetBookByIdQuery>
    {
        public Validator()
        {
            RuleFor(m => m.Id).NotNull();
        }
    }

    /// <summary>
    /// Handler the request
    /// </summary>
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookViewModel>
    {
        private readonly IAppDataContext _db;
        private readonly IMapper _mapper;

        public GetBookByIdHandler(IAppDataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<BookViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _db.Books.Where(i => i.BookId == request.Id)
                                  .ProjectTo<BookViewModel>(_mapper.ConfigurationProvider)
                                  .SingleOrDefaultAsync();
        }
    }    
}