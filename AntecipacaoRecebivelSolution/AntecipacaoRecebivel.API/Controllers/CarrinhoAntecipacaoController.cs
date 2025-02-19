using AntecipacaoRecebivel.Infrastructure.Data.Interfaces;
using AntecipacaoRecebivel.Infrastructure.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AntecipacaoRecebivel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrinhoAntecipacaoController : Controller
    {
        private readonly ICarrinhoAntecipacaoRepository _carrinhoAntecipacaoRepository;

        public CarrinhoAntecipacaoController(ICarrinhoAntecipacaoRepository carrinhoAntecipacaoRepository)
        {
            _carrinhoAntecipacaoRepository = carrinhoAntecipacaoRepository;
        }

        [HttpGet]
        [Route("Calcular/{cnpj}")]
        public CalculoAntecipacaoViewModel Calcular(string cnpj)
        {
            return _carrinhoAntecipacaoRepository.Calcular(cnpj);
        }
    }
}
