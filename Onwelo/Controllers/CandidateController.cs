using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnWelo.Models.Interfaces.Candidate;
using OnWelo.Models.Models;

namespace Onwelo.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidateRepositoryAsync _candidateRepositoryAsync;
        private readonly IHostEnvironment _env;
        public CandidateController(ICandidateRepositoryAsync candidateRepositoryAsync, IHostEnvironment env)
        {
            _candidateRepositoryAsync = candidateRepositoryAsync;
            _env = env;
        }
        // GET: CandidateController
        public async Task<IActionResult> Index()
        {
            var candidates = await _candidateRepositoryAsync.GetAllCandidates(_env.ContentRootPath);
            return View(candidates);
        }

        // GET: CandidateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CandidateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public async Task<IActionResult> Create(Candidate candidate)
        {
            try
            {
               int ret= await _candidateRepositoryAsync.CreateCandidate(candidate, _env.ContentRootPath);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CandidateController/Edit/5
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

        // GET: CandidateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CandidateController/Delete/5
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
