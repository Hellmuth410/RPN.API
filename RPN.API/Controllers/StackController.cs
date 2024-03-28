using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RPN.API.Tools;
using RPN.BO.Services;

namespace RPN.API.Controllers
{
    [Route("rpn/[controller]")]
    [ApiController]
    public class StackController : ControllerBase
    {
        private readonly IMemoryCache _cache;

        public StackController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpGet]
        public IActionResult GetAllStacks()
        {
            return Ok(CacheManager.AllCachedStacks(_cache));
        }

        [HttpPost]
        public IActionResult CreateStack()
        {
            try
            {
                IDictionary<int, Stack<decimal>> allStacks = CacheManager.AllCachedStacks(_cache);
                StackService.AddStack(allStacks);
                CacheManager.UpdateCachedStacks(_cache, allStacks);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{stackId}")]
        public IActionResult DeleteStack(int stackId)
        {
            try
            {
                IDictionary<int, Stack<decimal>> allStacks = CacheManager.AllCachedStacks(_cache);
                StackService.RemoveStack(stackId, allStacks);
                CacheManager.UpdateCachedStacks(_cache, allStacks);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("stack/{stackId}")]
        public IActionResult GetStack(int stackId)
        {
            try
            {
                IDictionary<int, Stack<decimal>> allStacks = CacheManager.AllCachedStacks(_cache);
                Stack<decimal> stack = StackService.GetStack(stackId, allStacks);
                return Ok(stack);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("stack/{stackId}")]
        public IActionResult PushValue(int stackId, [FromBody] decimal value)
        {
            try
            {
                IDictionary<int, Stack<decimal>> allStacks = CacheManager.AllCachedStacks(_cache);
                Stack<decimal> stack = StackService.PushInStack(stackId, value, allStacks);
                CacheManager.UpdateCachedStacks(_cache, allStacks);
                return Ok(stack);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("stack/{stackId}")]
        public IActionResult PopValue(int stackId)
        {
            try
            {
                IDictionary<int, Stack<decimal>> allStacks = CacheManager.AllCachedStacks(_cache);
                Stack<decimal> stack = StackService.PopFromStack(stackId, allStacks);
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
