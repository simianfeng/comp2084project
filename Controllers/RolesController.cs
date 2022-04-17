using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectComp2084.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectComp2084.Controllers
{
    
    public class RolesController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public RolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) {
            this.userManager = userManager;
            this.roleManager = roleManager;
        
        }
        public IActionResult Index()
        {
            
            return View(roleManager.Roles);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create([Bind("RoleName")]Role role) {

            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(role.RoleName));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");

                }
                string errors = "";

                foreach (IdentityError error in result.Errors)
                {
                    errors += error.Description + "\n";
                }
                return Content("Error Occurred. \n" + errors);
            }
            else
            {
                return View(role);
            }
            return Content("Submitted Successfully");
        
        }
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            roleManager.DeleteAsync(role);
            return RedirectToAction(nameof(Index));
            //return Content(" deleting the role with a role id of " + id);
        }
        public async Task<IActionResult> ManageUsers(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return RedirectToAction("Index");
            }
            List<IdentityUser> members = new List<IdentityUser>();
            List<IdentityUser> nonmembers = new List<IdentityUser>();
            foreach (IdentityUser currentUser in userManager.Users.ToList())
            {

                if (await userManager.IsInRoleAsync(currentUser, role.Name))
                {

                    members.Add(currentUser);
                }
                else
                {
                    nonmembers.Add(currentUser);
                }
            }
            RoleManagement model = new RoleManagement
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }
        [Route("RolesController/AddMemberToRole/{userId}/{roleId}")]
        public async Task<IActionResult> AddMemberToRole(string userId, string roleId)
        {
            //userManager.AddToRoleAsync(userObjectAsWhole, RoleName);
            return Content("UserID = " + userId + " RoleID = " + roleId);
        }
    }
}
