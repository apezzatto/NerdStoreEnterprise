using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NSE.Core.Communication;

namespace NSE.WebAPI.Core.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> ErrosList = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsOperationValid())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", ErrosList.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AddError(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AddError(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ResponseResult responseResult)
        {
            ResponseHasErrors(responseResult);

            return CustomResponse();
        }

        protected bool ResponseHasErrors(ResponseResult responseResult)
        {
            if (responseResult == null || !responseResult.Errors.Messages.Any()) return false;

            foreach (var mensagem in responseResult.Errors.Messages)
            {
                AddError(mensagem);
            }

            return true;
        }

        protected bool IsOperationValid()
        {
            return !ErrosList.Any();
        }

        protected void AddError(string erro)
        {
            ErrosList.Add(erro);
        }

        protected void ClearErrorsList()
        {
            ErrosList.Clear();
        }
    }
}