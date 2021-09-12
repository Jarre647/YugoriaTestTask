using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YugoriaTestTask.Models;
using YugoriaTestTask.Services.Contracts;
using YugoriaTestTask.ViewModels;

namespace YugoriaTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsApi _animalsApi;
        
        public AnimalsController(IAnimalsApi animalsApi)
        {
            _animalsApi = animalsApi;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimalsViewModel>>> GetAnimalsAsync()
        {
            return await _animalsApi.GetAnimalsAsync();
        }

        [HttpGet("helpedTypes")]
        public async Task<ActionResult<HelpedTypesViewModel>> GetHelpedTypes()
        {
            return await _animalsApi.GetCachingHelpedTypesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalModel>> GetAnimalById(int id)
        {
            try
            {
                return await _animalsApi.GetAnimalsByIdAsync(id);
            }
            catch
            {
                return BadRequest("Животное с таким Id не найдено");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostAnimal(AnimalModel model)
        {
            try
            {
                 await _animalsApi.PostAnimalAsync(model);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutAnimal(AnimalModel model)
        {
            try
            {
                await _animalsApi.PutAnimalAsync(model);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AnimalModel>> DeleteExpenseIncome(int id)
        {
            try
            {
                await _animalsApi.DeleteAnimalAsync(id);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
