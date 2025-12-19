using HomeExpenseControl.Api.DTO.Requests;
using HomeExpenseControl.Api.DTO.Responses;
using HomeExpenseControl.Domain.Entities;
using HomeExpenseControl.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeExpenseControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionResponse>>> GetAll()
        {
            var transactionList = await _transactionService.GetAllTransactions();
            var transactionResponse = transactionList.Select(transaction => new TransactionResponse(transaction.IdTransaction, transaction.TransactionDescription, transaction.TransactionAmount, transaction.TransactionType, transaction.CategoryId, transaction.UserId));
            return Ok(transactionResponse);
        }

        [HttpGet("{idTransaction}")]
        public async Task<ActionResult<TransactionResponse>> GetById(Guid idTransaction)
        {
            var transaction = await _transactionService.GetTransactionById(idTransaction);

            return Ok(new TransactionResponse(transaction.IdTransaction, transaction.TransactionDescription, transaction.TransactionAmount, transaction.TransactionType, transaction.CategoryId, transaction.UserId));
        }

        [HttpPost]
        public async Task<ActionResult> Create(TransactionRequest transactionRequest)
        {
            try
            {
                var newTransaction = new Transaction(transactionRequest.TransactionDescription, transactionRequest.TransactionAmount, transactionRequest.TransactionType, transactionRequest.CategoryId, transactionRequest.UserId);

                await _transactionService.CreateTransaction(newTransaction);

                return Ok(new TransactionResponse(newTransaction.IdTransaction, newTransaction.TransactionDescription, newTransaction.TransactionAmount, newTransaction.TransactionType, newTransaction.CategoryId, newTransaction.UserId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
