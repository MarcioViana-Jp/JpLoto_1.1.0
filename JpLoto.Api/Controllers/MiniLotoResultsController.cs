﻿namespace JpLoto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MiniLotoResultsController : ControllerBase
{
    private IMiniLotoResultService _miniLotoService;

    public MiniLotoResultsController(IMiniLotoResultService miniLotoService) =>
        _miniLotoService = miniLotoService;


    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<ActionResult<int>> Add(MiniLotoResultDto request)
    {
        var miniLoto = new MiniLotoResult();
        miniLoto.Date = request.Date;
        miniLoto.DrawNumber = request.DrawNumber;
        miniLoto.Numbers = request.Numbers;
        miniLoto.Bonus = request.Bonus;
        miniLoto.Prize1Value = request.Prize1Value;
        miniLoto.Prize2Value = request.Prize2Value;
        miniLoto.Prize3Value = request.Prize3Value;
        miniLoto.Prize4Value = request.Prize4Value;

        var id = (int)await _miniLotoService.AddAsync(miniLoto);
        return CreatedAtAction(nameof(GetById), new { id = id }, id);
    }


    [ProducesResponseType(typeof(MiniLotoResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPut]
    public async Task<ActionResult> Update(MiniLotoResultDto request)
    {
        var lotoResult = await _miniLotoService.GetByIdAsync(request.Id);
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

            await _miniLotoService.UpdateAsync(lotoResult);
            return Ok(lotoResult);
        }
        return BadRequest();
    }


    [ProducesResponseType(typeof(IEnumerable<MiniLotoResultDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MiniLotoResultDto>>> GetAll()
    {
        var miniLotoResults = await _miniLotoService.GetAllAsync();
        return Ok(miniLotoResults.Select(MiniLotoResult => new MiniLotoResultDto(MiniLotoResult)));
    }


    [ProducesResponseType(typeof(MiniLotoResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("{id}")]
    public async Task<ActionResult<MiniLotoResultDto>> GetById(int id)
    {
        var lotoResult = await _miniLotoService.GetByIdAsync(id);
        if (lotoResult is null)
            return NotFound();

        return Ok(new MiniLotoResultDto(lotoResult));

    }


    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveById(int id)
    {
        await _miniLotoService.RemoveByIdAsync(id);
        return Ok(id);
    }

}
