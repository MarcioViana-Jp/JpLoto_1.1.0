namespace JpLoto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Loto6ResultsController : ControllerBase
{
    private ILoto6ResultService _loto6Service;

    public Loto6ResultsController(ILoto6ResultService loto6Service) =>
        _loto6Service = loto6Service;


    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<ActionResult<int>> Add(Loto6ResultDto request)
    {
        var loto6 = new Loto6Result();
        loto6.Date = request.Date;
        loto6.DrawNumber = request.DrawNumber;
        loto6.Numbers = request.Numbers;
        loto6.Bonus = request.Bonus;
        loto6.Prize1Value = request.Prize1Value;
        loto6.Prize2Value = request.Prize2Value;
        loto6.Prize3Value = request.Prize3Value;
        loto6.Prize4Value = request.Prize4Value;
        loto6.Prize5Value = request.Prize5Value;

        var id = (int)await _loto6Service.AddAsync(loto6);
        return CreatedAtAction(nameof(GetById), new { id = id }, id);
    }


    [ProducesResponseType(typeof(Loto6Result), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPut]
    public async Task<ActionResult> Update(Loto6ResultDto request)
    {
        var lotoResult = await _loto6Service.GetByIdAsync(request.Id);
        if (lotoResult != null)
        {
            lotoResult.Date = request.Date;
            lotoResult.DrawNumber = request.DrawNumber;
            lotoResult.Numbers = request.Numbers;
            lotoResult.Bonus = request.Bonus;
            lotoResult.Prize1Value = request.Prize1Value;
            lotoResult.Prize2Value = request.Prize2Value;
            lotoResult.Prize3Value = request.Prize3Value;
            lotoResult.Prize4Value = request.Prize4Value;
            lotoResult.Prize5Value = request.Prize5Value;

            await _loto6Service.UpdateAsync(lotoResult);
            return Ok(lotoResult);
        }
        return BadRequest();
    }


    [ProducesResponseType(typeof(IEnumerable<Loto6ResultDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Loto6ResultDto>>> GetAll()
    {
        var loto6s = await _loto6Service.GetAllAsync();
        return Ok(loto6s.Select(Loto6Result => new Loto6ResultDto(Loto6Result)));
    }


    [ProducesResponseType(typeof(Loto6ResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("{id}")]
    public async Task<ActionResult<Loto6ResultDto>> GetById(int id)
    {
        var lotoResult = await _loto6Service.GetByIdAsync(id);
        if (lotoResult is null)
            return NotFound();

        return Ok(new Loto6ResultDto(lotoResult));

    }


    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveById(int id)
    {
        await _loto6Service.RemoveByIdAsync(id);
        return Ok(id);
    }

}
