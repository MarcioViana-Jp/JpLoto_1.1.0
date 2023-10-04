namespace JpLoto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Loto7ResultsController : ControllerBase
{
    private ILoto7ResultService _loto7Service;

    public Loto7ResultsController(ILoto7ResultService loto7Service) =>
        _loto7Service = loto7Service;


    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<ActionResult<int>> Add(Loto7ResultDto request)
    {
        var loto7 = new Loto7Result();
        loto7.Date = request.Date;
        loto7.DrawNumber = request.DrawNumber;
        loto7.Numbers = request.Numbers;
        loto7.Bonus = request.Bonus;
        loto7.Prize1Value = request.Prize1Value;
        loto7.Prize2Value = request.Prize2Value;
        loto7.Prize3Value = request.Prize3Value;
        loto7.Prize4Value = request.Prize4Value;
        loto7.Prize5Value = request.Prize5Value;
        loto7.Prize6Value = request.Prize6Value;

        var id = (int)await _loto7Service.AddAsync(loto7);
        return CreatedAtAction(nameof(GetById), new { id = id }, id);
    }


    [ProducesResponseType(typeof(Loto7Result), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPut]
    public async Task<ActionResult> Update(Loto7ResultDto request)
    {
        var lotoResult = await _loto7Service.GetByIdAsync(request.Id);
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
            lotoResult.Prize6Value = request.Prize6Value;

            await _loto7Service.UpdateAsync(lotoResult);
            return Ok(lotoResult);
        }
        return BadRequest();
    }


    [ProducesResponseType(typeof(IEnumerable<Loto7ResultDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Loto7ResultDto>>> GetAll()
    {
        var loto7s = await _loto7Service.GetAllAsync();
        return Ok(loto7s.Select(Loto7Result => new Loto7ResultDto(Loto7Result)));
    }


    [ProducesResponseType(typeof(Loto7ResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("{id}")]
    public async Task<ActionResult<Loto7ResultDto>> GetById(int id)
    {
        var lotoResult = await _loto7Service.GetByIdAsync(id);
        if (lotoResult is null)
            return NotFound();

        return Ok(new Loto7ResultDto(lotoResult));

    }


    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveById(int id)
    {
        await _loto7Service.RemoveByIdAsync(id);
        return Ok(id);
    }

}
