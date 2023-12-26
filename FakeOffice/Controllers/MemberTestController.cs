using FakeOffice.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FakeOffice.Controllers;

//may add white list for internal testing security
[ApiController]
[Route("api")]
public class MemberTestController : ControllerBase
{
    private IMemberRepo _memberRepo;

    public MemberTestController(IMemberRepo memberRepo)
    {
        _memberRepo = memberRepo;
    }

    [HttpGet]
    public IActionResult GetMember(int memberId)
    {
        var member = _memberRepo.Get(memberId);
        return Ok(member);
    }
}