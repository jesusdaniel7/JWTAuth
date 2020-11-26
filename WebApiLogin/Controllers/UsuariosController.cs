using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiLogin.Context;
using WebApiLogin.DTOS;
using WebApiLogin.Models;

namespace WebApiLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public UsuariosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpPost("AssignUserRole")]
        public async Task<ActionResult> AssignUserRole(EditRoleDTO editRoleDTO)
        {
            var user = await userManager.FindByIdAsync(editRoleDTO.userId);
            if (user == null) { return NotFound(); }

            await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDTO.RoleName));
            await userManager.AddToRoleAsync(user, editRoleDTO.RoleName);

            return Ok();
        }

        [HttpDelete("DeleteUserRole")]
        public async Task<ActionResult> DeleteUserRole(EditRoleDTO editRoleDTO)
        {
            var user = await userManager.FindByNameAsync(editRoleDTO.userId);
            if (user == null) { return NotFound(); }

            await userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDTO.RoleName));
            await userManager.RemoveFromRoleAsync(user, editRoleDTO.RoleName);

            return Ok();
        }
    }
}