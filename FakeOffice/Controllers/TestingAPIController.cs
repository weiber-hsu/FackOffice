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
    private readonly IMemberRepo _memberRepo;
    private readonly ITransactionService _transactionService;

    public TestingApiController(IMemberRepo memberRepo, ITransactionService transactionService)
    {
        _memberRepo = memberRepo;
        _transactionService = transactionService;
    }

    [HttpGet("member/{memberId}")]
    public async Task<IActionResult> GetMember(int memberId)
    {
        var member = await _memberRepo.Get(memberId);
        return Ok(member);
    }
    
    [HttpGet("Create-Fake")]
    public async Task<IActionResult> CreateFakeTrx(int trxNumber)
    {
        await _transactionService.CreateRandomTransactions(trxNumber);
        return Ok();
    }
    
    [HttpGet("Generate-Transactions/{memberId}")]
    public async Task<IActionResult> GenerateTransactions(int memberId)
    {
        var member = await _memberRepo.Get(memberId);

        for (int i = 0; i < 1000; i++)
        {
            await _transactionService.CreateTransactionsWith(member, 12);
        }
        return Ok();
    }
    
}