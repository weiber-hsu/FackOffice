using FakeOffice.Repository;
using FakeOffice.Service;
using FakeOffice.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FakeOffice.Controllers;

//may add white list for internal testing security
[ApiController]
[Route("api")]
public class TestingApiController : ControllerBase
{
    private IMemberRepo _memberRepo;
    private ITransactionService _transactionService;

    public TestingApiController(IMemberRepo memberRepo, ITransactionService transactionService)
    {
        _memberRepo = memberRepo;
        _transactionService = transactionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMember(int memberId)
    {
        var member = await _memberRepo.Get(memberId);
        return Ok(member);
    }
    
    [HttpGet("Create-Fake")]
    public async Task<IActionResult> CreateFakeTrx(int trxNumber)
    {
        _transactionService.CreateTransactions(trxNumber);
        return Ok();
    }
    
}