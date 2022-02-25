#nullable disable
using Application.Services.Interface;
using Infrastructure.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Training_Lv2.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class MembersController : Controller
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        // GET: MembersController
        public ActionResult Index()
        {
            return View(_memberService.GetAllMembers().ToList());
        }

        // GET: MembersController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var member = await _memberService.GetMemberById(id);
            if (member == null) return NotFound();

            return View(member);
        }

        // GET: MembersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Member member)
        {
            try {
                await _memberService.CreateMember(member);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(member);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var member = await _memberService.GetMemberById(id);
            if (member == null) return NotFound();
            return View(member);
        }

        // POST: Members1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Member member)
        {
            if (id != member.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _memberService.UpdateMember(member);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(member);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Member member = await _memberService.GetMemberById(id);
            if (member == null) return NotFound();

            return View(member);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _memberService.DeleteMemberById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
