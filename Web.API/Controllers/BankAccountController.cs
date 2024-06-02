using Application.Common.Interfaces.Services;
using Application.Common.Services;
using Contracts.Requests.BankAccount;
using Contracts.Requests.BankAccountRequests;
using Contracts.Requests.OrderRequests;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]

public class BankAccountController(IBankAccountService accountService) : ControllerBase
{
    [HttpPost(ApiEndpoints.BankAccount.Create)]
    public async Task<IActionResult> Create([FromBody] CreateBankAccountRequestModel request, CancellationToken token)
    {
        var response = await accountService.CreateAsync(request, token);
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    [HttpGet(ApiEndpoints.BankAccount.Get)]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await accountService.GetAsync(id, token);
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.BankAccount.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var response = await accountService.GetAllAsync(token);
        return Ok(response);
    }

    [HttpPut(ApiEndpoints.BankAccount.Update)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBankAccountRequestModel request,
    CancellationToken token)
    {
        var response = await accountService.UpdateAsync(request, token);
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.BankAccount.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var response = await accountService.DeleteAsync(id, token);
        return Ok(response);
    }
}

