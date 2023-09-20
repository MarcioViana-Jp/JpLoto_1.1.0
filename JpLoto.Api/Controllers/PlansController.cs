using JpLoto.Domain.Interfaces.Services;

namespace JpLoto.Api.Controllers.v1;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class PlansController : ControllerBase
{
    private IPlanService _planService;

    public PlansController(IPlanService planService) =>
        _planService = planService;

    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<ActionResult<int>> Add(PlanAddRequest request)
    {
        var plan = PlanAddRequest.ConvertToEntity(request);
        var id = (int)await _planService.AddAsync(plan);
        return CreatedAtAction(nameof(GetById), new { id = id }, id);
    }

    
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPut]
    public async Task<ActionResult> Update(PlanUpdateRequest request)
    {
        var plan = PlanUpdateRequest.ConvertToEntity(request);
        await _planService.UpdateAsync(plan);
        return Ok(plan);
    }


    [ProducesResponseType(typeof(IEnumerable<PlanResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlanResponse>>> GetAll()
    {
        var plans = await _planService.GetAllAsync();
        var plansResponse = plans.Select(Plan => PlanResponse.ConvertToResponse(Plan));
        return Ok(plansResponse);
    }


    [ProducesResponseType(typeof(IEnumerable<PlanResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("{id}")]
    public async Task<ActionResult<PlanResponse>> GetById(int id)
    {
        var Plan = await _planService.GetByIdAsync(id);
        if (Plan is null)
            return NotFound();

        var planResponse = PlanResponse.ConvertToResponse(Plan);
        return Ok(planResponse);
    }


    [ProducesResponseType(typeof(IEnumerable<PlanResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveById(int id)
    {
        await _planService.RemoveByIdAsync(id);
        return Ok();
    }
}
