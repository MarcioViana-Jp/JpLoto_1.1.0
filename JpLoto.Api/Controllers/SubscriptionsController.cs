namespace JpLoto.Api.Controllers.v1;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class SubscriptionsController : ControllerBase
{
    private ISubscriptionService _licenseService;

    public SubscriptionsController(ISubscriptionService planService) =>
        _licenseService = planService;


    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<ActionResult<int>> Add(SubscriptionAddRequest request)
    {
        var plan = SubscriptionAddRequest.ConvertToEntity(request);
        var id = (int)await _licenseService.AddAsync(plan);
        return CreatedAtAction(nameof(GetById), new { id = id }, id);
    }


    [ProducesResponseType(typeof(SubscriptionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPut]
    public async Task<ActionResult> Update(SubscriptionUpdateRequest request)
    {
        var subscription = SubscriptionUpdateRequest.ConvertToEntity(request);
        await _licenseService.UpdateAsync(subscription);
        return Ok(SubscriptionResponse.ConvertToResponse(subscription));
    }


    [ProducesResponseType(typeof(IEnumerable<SubscriptionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubscriptionResponse>>> GetAll()
    {
        var subscriptions = await _licenseService.GetAllAsync();
        return Ok(subscriptions.Select(License => SubscriptionResponse.ConvertToResponse(License)));
    }


    [ProducesResponseType(typeof(SubscriptionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("{id}")]
    public async Task<ActionResult<SubscriptionResponse>> GetById(int id)
    {
        var License = await _licenseService.GetByIdAsync(id);
        if (License is null)
            return NotFound();

        return Ok(SubscriptionResponse.ConvertToResponse(License));
    }


    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveById(int id)
    {
        await _licenseService.RemoveByIdAsync(id);
        return Ok(id);
    }
}
