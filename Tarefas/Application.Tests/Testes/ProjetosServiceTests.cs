using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using tarefas.Core.Application.Service.Implementation;
using tarefas.Core.Domain.DTO;
using tarefas.Core.Domain.Entitys;
using tarefas.Core.Domain.Interfaces;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Application.Tests.Testes
{
    [TestClass]
    public class ProjetosServiceTests
    {
        private Mock<IProjetoRepository> _projetoRepositoryMock;
        private Mock<ITarefaRepository> _tarefaRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private ProjetosService _projetosService;

        [TestInitialize]
        public void Setup()
        {
            _projetoRepositoryMock = new Mock<IProjetoRepository>();
            _tarefaRepositoryMock = new Mock<ITarefaRepository>();
            _mapperMock = new Mock<IMapper>();

            _projetosService = new ProjetosService(_projetoRepositoryMock.Object, _tarefaRepositoryMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public async Task AdicionarProjeto_DeveRetornarSucesso()
        {
            // Arrange
            var projetoDTO = new ProjetoDTO();

            // Act
            var result = await _projetosService.AddAsync(projetoDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult)); // Verifica se o resultado é um OkObjectResult
            var okObjectResult = (OkObjectResult)result;
            var value = (dynamic)okObjectResult.Value;

            Assert.IsTrue(value.Success); // Verifica se a propriedade Success é verdadeira
            Assert.AreEqual("Projeto adicionado com sucesso", value.Message); // Verifica a mensagem de retorno
        }

        [TestMethod]
        public async Task ListarTodos_DeveRetornarSucesso()
        {
            // Arrange
            var projetos = new List<Projeto>();
            _projetoRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(projetos);

            // Act
            var result = await _projetosService.ListarTodos();

            // Assert
            var okObjectResult = result.Result as OkObjectResult; 
            Assert.IsNotNull(okObjectResult); 

            var value = okObjectResult.Value as dynamic; 
            Assert.IsTrue(value.Success); // Verifica se a propriedade Success é verdadeira
            Assert.AreEqual("Listagem Ok", value.Message); // Verifica a mensagem de retorno

            var projetosRetornados = value.Result as List<ProjetoDTO>; // Obtém os projetos retornados
            Assert.IsNotNull(projetosRetornados); // Verifica se os projetos retornados não são nulos
            Assert.AreEqual(0, projetosRetornados.Count); // Verifica se não há projetos retornados
        }

        [TestMethod]
        public async Task RemoverProjeto_SemTarefasPendentes_DeveRetornarSucesso()
        {
            // Arrange
            var projetoId = 1;
            var tarefas = new List<Tarefa>();
            _tarefaRepositoryMock.Setup(r => r.GetByStatusAsync("concluída")).ReturnsAsync(tarefas);

            // Act
            var result = await _projetosService.RemoveAsync(projetoId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult)); // Verifica se o resultado é um OkObjectResult
            var okObjectResult = (OkObjectResult)result;
            var value = (dynamic)okObjectResult.Value;

            Assert.IsTrue(value.Success); // Verifica se a propriedade Success é verdadeira
            Assert.AreEqual("Projeto removido com sucesso", value.Message); // Verifica a mensagem de retorno
        }

        [TestMethod]
        public async Task RemoverProjeto_ComTarefasPendentes_DeveRetornarErro()
        {
            // Arrange
            var projetoId = 1;
            var tarefas = new List<Tarefa> { new Tarefa() };
            _tarefaRepositoryMock.Setup(r => r.GetByStatusAsync("concluída")).ReturnsAsync(tarefas);

            // Act
            var result = await _projetosService.RemoveAsync(projetoId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult)); // Verifica se o resultado é um BadRequestObjectResult
            var badRequestObjectResult = (BadRequestObjectResult)result;
            var value = (string)badRequestObjectResult.Value;

            Assert.AreEqual("Existe(m) tarefa(s) pendente(s), remova a(s) tarefa(s0 pendente(s) ou conclua todas elas", value); // Verifica a mensagem de retorno
        }
    }
}
