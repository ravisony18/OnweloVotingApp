using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnWelo.Models.Interfaces.Voter;
using OnWelo.Models.Models;

namespace Onwelo.Controllers
{
    public class VoterController : Controller
    {
        private readonly IHostEnvironment _env;
        private readonly IVoterRepositoryAsync _voterRepositoryAsync;
        public VoterController(IVoterRepositoryAsync voterRepositoryAsync, IHostEnvironment env)
        {
            _voterRepositoryAsync = voterRepositoryAsync;
            _env = env;
        }
        // GET: VoterController
        public async Task<IActionResult> Index()
        {
            var voters = await _voterRepositoryAsync.GetAllVoters(_env.ContentRootPath);
            return View(voters);
        }

        // GET: VoterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VoterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VoterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Voter voter)
        {
            try
            {
                int ret = await _voterRepositoryAsync.CreateVoters(voter, _env.ContentRootPath);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VoterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VoterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VoterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VoterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
