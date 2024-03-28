using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RPN.API.Tools;
using RPN.BO.Services;
using RPN.Utils.Exceptions;

namespace RPN.API.Controllers
{
    [Route("rpn/[controller]")]
    [ApiController]
    public class OperandController : ControllerBase
    {
        private readonly IMemoryCache _cache;

        public OperandController(IMemoryCache cache)
        {
            _cache = cache;
        }

        // GET: api/<OperandController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(OperandService.GetOperands());
        }

        // POST api/<OperandController>
        [HttpPost]
        public IActionResult Post(char operand, int stackId)
        {
            try
            {
                IDictionary<int, Stack<decimal>> allStacks = CacheManager.AllCachedStacks(_cache);
                if (!allStacks.TryGetValue(stackId, out Stack<decimal> stack)) { throw new NoCacheFoundException(); }
                OperandService.Compute(operand, stack);
                CacheManager.UpdateCachedStacks(_cache, allStacks);
                return Ok(stack);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }
    }
}
