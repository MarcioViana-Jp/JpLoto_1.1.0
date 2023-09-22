namespace JpLoto.Api.Controllers.v1;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class TrialsController : ControllerBase
{
    private ITrialService _trialService;

    public TrialsController(ITrialService trialService) =>
        _trialService = trialService;


    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<ActionResult<int>> Add(TrialDto request)
    {
        var trial = new Trial(request.UserId, request.TrialBegin, request.TrialFinish);
        var id = (int)await _trialService.AddAsync(trial);
        return CreatedAtAction(nameof(GetById), new { id = id }, id);
    }


    [ProducesResponseType(typeof(Trial), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPut]
    public async Task<ActionResult> Update(TrialDto request)
    {
        var trial = new Trial(request.UserId, request.TrialBegin, request.TrialFinish);
        await _trialService.UpdateAsync(trial);
        return Ok(trial);
    }


    [ProducesResponseType(typeof(IEnumerable<TrialDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrialDto>>> GetAll()
    {
        var trials = await _trialService.GetAllAsync();
        return Ok(trials.Select(Trial => TrialDto.ConvertToDto(Trial)));
    }


    [ProducesResponseType(typeof(TrialDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("{id}")]
    public async Task<ActionResult<TrialDto>> GetById(int id)
    {
        var trial = await _trialService.GetByIdAsync(id);
        if (trial is null)
            return NotFound();

        return Ok(TrialDto.ConvertToDto(trial));

    }


    [ProducesResponseType(typeof(TrialDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("{userId}")]
    public async Task<ActionResult<TrialDto>> GetByUserId(string userId)
    {
        var trial = await _trialService.GetByUserIdAsync(userId);
        if (trial is null)
            return NotFound();

        return Ok(TrialDto.ConvertToDto(trial));

    }


    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveById(int id)
    {
        await _trialService.RemoveByIdAsync(id);
        return Ok(id);
    }
}
