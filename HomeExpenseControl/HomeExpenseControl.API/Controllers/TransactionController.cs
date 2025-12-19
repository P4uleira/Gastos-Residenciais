using HomeExpenseControl.Api.DTO.Requests;
using HomeExpenseControl.Api.DTO.Responses;
using HomeExpenseControl.Domain.Entities;
using HomeExpenseControl.Domain.Enums;
using HomeExpenseControl.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeExpenseControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;

        public TransactionController(ITransactionService transactionService, ICategoryService categoryService, IUserService userService)
        {
            _transactionService = transactionService;
            _categoryService = categoryService;
            _userService = userService;
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
            if (transaction == null)
                return NotFound();
            return Ok(new TransactionResponse(transaction.IdTransaction, transaction.TransactionDescription, transaction.TransactionAmount, transaction.TransactionType, transaction.CategoryId, transaction.UserId));
        }

        [HttpPost]
        public async Task<ActionResult> Create(TransactionRequest transactionRequest)
        {
            var user = await _userService.GetUserById(transactionRequest.UserId)
                ?? throw new ArgumentException("Usuário não encontrado");

            var category = await _categoryService.GetCategoryById(transactionRequest.CategoryId)
                ?? throw new ArgumentException("Categoria não encontrada");


            if (user.UserAge < 18 && transactionRequest.TransactionType == TransactionTypeEnum.Receita)
                throw new ArgumentException("Menor de idade não pode registrar receita.");

            if (category.CategoryPurpose != CategoryPurposeEnum.Ambas &&
                (TransactionTypeEnum)category.CategoryPurpose != transactionRequest.TransactionType)
                throw new ArgumentException("Categoria incompatível com o tipo da transação.");


            var transaction = new Transaction(transactionRequest.TransactionDescription, transactionRequest.TransactionAmount, transactionRequest.TransactionType, category, user);
            await _transactionService.CreateTransaction(transaction);
            return Ok();
        }
    }
}
