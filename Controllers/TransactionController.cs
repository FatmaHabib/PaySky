using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaySky.IRepository;
using PaySky.Models;

namespace PaySky.Controllers
{
    [Route("/api")]

    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _transRepository;

        public TransactionController(ITransactionRepository transRepository)
        {

            _transRepository = transRepository;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [Authorize]
        [Route("Request")]
        [HttpPost]
        public async Task<IActionResult> Request([FromBody] TransactionRequestModel transactionDataModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            TransactionResponseModel Result = new TransactionResponseModel();

            try
            {

                await _transRepository.SaveTransaction(transactionDataModel);
                Result.RequestID = transactionDataModel.ID;
                Result.ApprovalCode = Guid.NewGuid().ToString();
                Result.DateTime = DateTime.Now.ToString();
            //_context.TransactionResponseModel.Add(Result);
            //var response = await _context.SaveChangesAsync();
                Result.ResponseCode = Response.StatusCode;
                Result.Message = "Success";
            return Ok(Result); 
            }
            catch(Exception e)
            {
                Result.ResponseCode = Response.StatusCode;
                Result.Message = "Bad Request";
                return BadRequest(Result); 
            }
        }
    }
}
