using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnWelo.Models.Interfaces.Candidate;
using OnWelo.Models.Interfaces.Vote;
using OnWelo.Models.Interfaces.Voter;
using OnWelo.Models.Models;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Nodes;

namespace Onwelo.Controllers
{
    public class VoteController : Controller
    {
        private readonly ICandidateRepositoryAsync _candidateRepositoryAsync;
        private readonly IHostEnvironment _env;
        private readonly IVoterRepositoryAsync _voterRepositoryAsync;
        private readonly IVoteRepositoryAsync _voteRepositoryAsync;
        public VoteController(ICandidateRepositoryAsync candidateRepositoryAsync, IVoterRepositoryAsync voterRepositoryAsync,
            IHostEnvironment env, IVoteRepositoryAsync voteRepositoryAsync)
        {
            _candidateRepositoryAsync = candidateRepositoryAsync;
            _voterRepositoryAsync = voterRepositoryAsync;
            _env = env;
            _voteRepositoryAsync = voteRepositoryAsync;
        }

        // GET: VoteController
        public async Task<IActionResult> Index()
        {
            ViewBag.Voters = await _voterRepositoryAsync.GetAllVotersName(_env.ContentRootPath);
            ViewBag.Candidates =await _candidateRepositoryAsync.GetAllCandidatesName(_env.ContentRootPath);
            return View();
        }

        // GET: VoteController/Details/5
        public async Task<IActionResult> Details()
        {
            var votes = await _voteRepositoryAsync.GetAllVotes(_env.ContentRootPath);
            return View(votes);
        }

        // GET: VoteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VoteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                var VoterId = Convert.ToString(collection["ddlVotersName"]);
                var CandidateId = Convert.ToString(collection["ddlCandidatesName"]);
                var result= await _voteRepositoryAsync.Createvote(VoterId, CandidateId, _env.ContentRootPath);  

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VoteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VoteController/Edit/5
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

        // GET: VoteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VoteController/Delete/5
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
