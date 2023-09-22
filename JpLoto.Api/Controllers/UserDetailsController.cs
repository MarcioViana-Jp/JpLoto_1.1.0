namespace JpLoto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserDetailsController : ControllerBase
{
    private UserDetailService _userDetailService;

    public UserDetailsController(UserDetailService jplUserDetailService) =>
        _userDetailService = jplUserDetailService;


    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<ActionResult<int>> Add(UserDetailAddRequest request)
    {
        var userDetail = new JplUserDetail(request.UserId, request.FirstName, request.LastName, request.PostalCode,
                        request.State, request.City, request.Address, request.Phone, request.UpdateDate, true);
        var id = (int)await _userDetailService.AddAsync(userDetail);
        return CreatedAtAction(nameof(GetById), new { id = id }, id);
    }


    [ProducesResponseType(typeof(UserDetailResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPut]
    public async Task<ActionResult> Update(UserDetailUpdateRequest request)
    {
        var userDetail = new JplUserDetail(request.UserId, request.FirstName, request.LastName, request.PostalCode,
                        request.State, request.City, request.Address, request.Phone, request.UpdateDate, true);
        await _userDetailService.UpdateAsync(userDetail);
        return Ok(UserDetailResponse.ConvertToResponse(userDetail));
    }


    [ProducesResponseType(typeof(IEnumerable<UserDetailResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDetailResponse>>> GetAll()
    {
        var userDetails = await _userDetailService.GetAllAsync();
        return Ok(userDetails.Select(JplUserDetail => UserDetailResponse.ConvertToResponse(JplUserDetail)));
    }


    [ProducesResponseType(typeof(UserDetailResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDetailResponse>> GetById(int id)
    {
        var userDetail = await _userDetailService.GetByIdAsync(id);
        if (userDetail is null)
            return NotFound();

        return Ok(UserDetailResponse.ConvertToResponse(userDetail));
    }


    [ProducesResponseType(typeof(UserDetailResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("{userId}")]
    public async Task<ActionResult<UserDetailResponse>> GetByUserId(string userId)
    {
        var userDetail = await _userDetailService.GetByUserIdAsync(userId);
        if (userDetail is null)
            return NotFound();

        return Ok(UserDetailResponse.ConvertToResponse(userDetail));

    }


    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveById(int id)
    {
        await _userDetailService.RemoveByIdAsync(id);
        return Ok(id);
    }


    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Remove(JplUserDetail userDetail)
    {
        await _userDetailService.RemoveAsync(userDetail);
        return Ok(userDetail);
    }
}
