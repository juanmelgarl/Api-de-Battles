using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication16.Core.Command;
using WebApplication16.Core.Query;


namespace WebApplication16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Battlescontroller : ControllerBase
    {
        private readonly IMediator Mediator;
        public Battlescontroller(IMediator mediator)
        {
               Mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var battles = new ObtenerTodoQuery();
            var battle = await Mediator.Send(battles);
            return Ok(battle);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Obtenerporid(int id)
        {
            var battle = new ObtenerPorIdQuery(id);
            var send = await Mediator.Send(battle);
            return Ok(send);
        }
        [HttpPatch("Updatename")]
        public async Task<IActionResult> Updatename([FromBody] UpdateNameCommand dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }
            var battle = await Mediator.Send(dto);
            return Ok(battle);
        }
        [HttpPatch("UpdateTYPE")]
        public async Task<IActionResult> UpdateType([FromBody] ÚpdateTypeBattleCommand dto)
        {
            if (dto is null)
                return BadRequest();
            var battle = await Mediator.Send(dto);
            return Ok(battle);
        }
        [HttpPost]
        public async Task<IActionResult> CrearBatalla([FromBody] CreateBattleCommmand dto)
        {
            if (dto is null)
                return BadRequest();
            var battle = await Mediator.Send(dto);
            if (battle is null)
            {
                return NotFound();
            }
            return Ok(battle);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizarbatalla(int id, [FromBody] UpdateBattleCommand dto)
        {
            if (dto is null)
                return BadRequest();
            if (id != dto.battle.Id)
            {
                return BadRequest();
            }
            var battle = await Mediator.Send(dto);
            if (!battle)
            {
                return NotFound();
            }
            return Ok(battle);
        }
      
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarBatalla( int id,Deletebattlecommand dto)
        {
            var result = await Mediator.Send(new Deletebattlecommand(id));
            if (!result)

            {
                return NotFound();

            }
            return NoContent();
        }
    }
}
