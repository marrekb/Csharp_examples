using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatProjectLib.Commands.Simple;
using StatProjectLib.Factories;
using StatProjectAPI.Models.SimpleCommand;

namespace StatProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleCommandController : ControllerBase
    {
        private readonly IMyFactory<ISimpleCommand> _simpleCommandFactory;

        public SimpleCommandController(IMyFactory<ISimpleCommand> simpleCommandFactory)
        {
            _simpleCommandFactory = simpleCommandFactory;
        }

        [HttpPost]
        public ActionResult<double> SimpleCalculation(PostModel? model)
        {
            if (model == null)
                return BadRequest("Model does not exist!");
            if (model.Function == null || model.Data == null)
                return BadRequest("Atleast one parameter does not exist!");
            if (model.Data.Length == 0)
                return BadRequest("Data array is empty!");

            var command = _simpleCommandFactory.Create(model.Function);
            if (command == null)
                return NotFound("Function does not exist!");
            return Ok(command.Compute(model.Data));
        }
    }
}
