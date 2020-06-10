using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CollectionApp.api.Data;
using CollectionApp.api.Dtos;
using CollectionApp.api.Helpers;
using CollectionApp.api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionApp.api.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICollectorRepository repo;

        private readonly IMapper mapper;

        private readonly ICollectionGundamRepository gRepo;

        public UsersController(ICollectorRepository repo, IMapper mapper, 
        ICollectionGundamRepository gRepo)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.gRepo = gRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] UserParams userParams)
        {
            var currentUserId =
                int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var userFromRepo = await repo.GetUser(currentUserId);

            userParams.UserId = currentUserId;

            if (string.IsNullOrEmpty(userParams.Gender))
            {
                userParams.Gender = userFromRepo.Gender;
            }

            var users = await this.repo.GetUsers(userParams);

            var usersToReturn = this.mapper.Map<IEnumerable<UserForListDto>>(users);

            Response.AddPagination(users.CurrentPage, users.PageSize, users.TotalCount,
                users.TotalPages);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await this.repo.GetUser(id);

            var userToReturn = this.mapper.Map<UserForDetailDto>(user);

            return Ok(userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id,
            UserForUpdateDto userForUpdateDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await this.repo.GetUser(id);

            mapper.Map(userForUpdateDto, userFromRepo);

            if (await this.repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user{id} failed on save");
        }

        [HttpPost("{id}/like/{gundamId}")]
        public async Task<IActionResult> LikeGundam(int id, int gundamId)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var like = await repo.GetLike(id, gundamId);

            if (like != null)
                return BadRequest("You already liked this gundam");

            if (await gRepo.GetCollectionGundam(gundamId) == null)
                return NotFound();

            like = new Like
            {
                LikerId = id,
                LikeeId = gundamId
            };
            
            repo.Add<Like>(like);

            if (await repo.SaveAll())
                return Ok();

            return BadRequest();
        }
    }
}