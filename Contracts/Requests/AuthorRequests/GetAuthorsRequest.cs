using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.AuthorRequests;

public class GetAuthorsRequest
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public GetAuthorsRequest()
    {
        this.PageNumber = 1;
        this.PageSize = 10;
    }
    public GetAuthorsRequest(int pageNumber, int pageSize)
    {
        this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
        this.PageSize = pageSize > 10 ? 10 : pageSize;
    }
}