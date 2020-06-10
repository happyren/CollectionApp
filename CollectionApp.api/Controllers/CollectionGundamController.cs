using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CollectionApp.api.Data;
using CollectionApp.api.Dtos;
using CollectionApp.api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionApp.api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionGundamController : ControllerBase
    {
        private readonly ICollectionGundamRepository repo;
        private readonly IMapper mapper;

        public CollectionGundamController(ICollectionGundamRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCollectionGundams([FromQuery] UserParams userParams)
        {
            if (userParams != null)
            {
                var currentUserId =
                    int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                userParams.UserId = currentUserId;

                var gundams = await this.repo.GetGundams(userParams);

                var gundamsToReturn = this.mapper
                .Map<IEnumerable<CollectionGundamForListDto>>(gundams);

                return Ok(gundamsToReturn);
            }

            var collectionGundams = await this.repo.GetCollectionGundams();

            var collectionGundamsToReturn = this.mapper.Map<IEnumerable<CollectionGundamForListDto>>(collectionGundams);

            return Ok(collectionGundamsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCollectionGundam(int id)
        {
            var collectionGundam = await this.repo.GetCollectionGundam(id);

            var collectionGundamToReturn = this.mapper.Map<CollectionGundamForDetailDto>(collectionGundam);

            return Ok(collectionGundamToReturn);
        }
    }
}