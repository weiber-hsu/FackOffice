using FakeOffice.Repository;
using FakeOffice.Service;
using FakeOffice.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FakeOffice.Controllers;

//may add white list for internal testing security
[ApiController]
[Route("internal/api")]
public class TestingApiController : ControllerBase
{
    private readonly IMemberRepo _memberRepo;
    private readonly IBorrowFeeService _borrowFeeService;

    public TestingApiController(IMemberRepo memberRepo, IBorrowFeeService borrowFeeService)
    {
        _memberRepo = memberRepo;
        _borrowFeeService = borrowFeeService;
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
        await _borrowFeeService.CreateRandomTransactions(trxNumber);
        return Ok();
    }
    
    [HttpGet("Generate-Transactions/{memberId}")]
    public async Task<IActionResult> GenerateTransactions(int memberId)
    {
        var member = await _memberRepo.Get(memberId);

        for (int i = 0; i < 1000; i++)
        {
            await _borrowFeeService.CreateBorrowFees(member, 12);
        }
        return Ok();
    }
    
}