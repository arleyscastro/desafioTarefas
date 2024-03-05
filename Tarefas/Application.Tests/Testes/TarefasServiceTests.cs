using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using tarefas.Core.Application.Service.Implementation;
using tarefas.Core.Domain.DTO;
using tarefas.Core.Domain.Entitys;
using tarefas.Core.Domain.Interfaces;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace Application.Tests.Testes
{
    [TestFixture]
    public class TarefasServiceTests
    {
        private Mock<ITarefaRepository> _tarefaRepositoryMock;
        private Mock<IHistoricoTarefaRepository> _historicoTarefaRepositoryMock;
        private Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private Mock<IComentarioRepository> _comentarioRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private TarefasService _tarefasService;

        [TestInitialize]
        public void Setup()
        {
            _tarefaRepositoryMock = new Mock<ITarefaRepository>();
            _historicoTarefaRepositoryMock = new Mock<IHistoricoTarefaRepository>();
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            _comentarioRepositoryMock = new Mock<IComentarioRepository>();
            _mapperMock = new Mock<IMapper>();

            _tarefasService = new TarefasService(_tarefaRepositoryMock.Object,
                                                 _historicoTarefaRepositoryMock.Object,
                                                 _usuarioRepositoryMock.Object,
                                                 _tarefaRepositoryMock.Object, 
                                                 _comentarioRepositoryMock.Object,
                                                 _mapperMock.Object);
        }

        [Test]
        public async Task AdicionarTarefa_LimiteDeTarefasExcedido_DeveRetornarErro()
        {
            // Arrange
            var projetoId = 1; // Projeto com 20 tarefas
            var tarefaDTO = new TarefaDTO(); // Tarefa a ser adicionada

            _tarefaRepositoryMock.Setup(r => r.CountByProjetoAsync(projetoId)).ReturnsAsync(20);

            // Act
            var result = await _tarefasService.AddAsync(tarefaDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult)); // Verifica se o resultado é um OkObjectResult
            var okObjectResult = (OkObjectResult)result;
            dynamic value = okObjectResult.Value; // Obtém o valor retornado pelo OkObjectResult

            Assert.AreEqual(true, value.Success); // Verifica se a propriedade Success é verdadeira
            Assert.AreEqual("Tarefa adicionada com sucesso", value.Message); // Verifica a mensagem de retorno
        }

        [Test]
        public async Task AdicionarTarefa_PrioridadeVazia_DeveRetornarErro()
        {
            // Arrange
            var tarefaDTO = new TarefaDTO { Prioridade = "" }; // Prioridade vazia

            // Act
            var result = await _tarefasService.AddAsync(tarefaDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult)); // Verifica se o resultado é um OkObjectResult
            var okObjectResult = (OkObjectResult)result;
            dynamic value = okObjectResult.Value; // Obtém o valor retornado pelo OkObjectResult

            Assert.AreEqual(true, value.Success); // Verifica se a propriedade Success é verdadeira
            Assert.AreEqual("Prioridade da tarefa é obrigatória", value.Message); // Verifica a mensagem de retorno
        }


        [TestMethod]
        public async Task CalcularMediaTarefasConcluidasPorUsuarioUltimos30Dias_DeveRetornarMedia()
        {
            // Arrange
            var usuarioId = 1;
            var mediaEsperada = 10; // Média esperada
            var tarefasConcluidasPorUsuario = new List<(Usuario, double)>
            {
                (new Usuario { UsuarioID = 1, Nome = "Usuário 1" }, 15),
                (new Usuario { UsuarioID = 2, Nome = "Usuário 2" }, 5),
                (new Usuario { UsuarioID = 3, Nome = "Usuário 3" }, 10)
            };
            _usuarioRepositoryMock.Setup(r => r.GetByIdAsync(usuarioId)).ReturnsAsync(new Usuario { Id = usuarioId });

            _tarefaRepositoryMock.Setup(r => r.ObterMediaTarefasConcluidasUltimos30DiasPorUsuario())
                .ReturnsAsync(tarefasConcluidasPorUsuario);

            // Act
            var result = await _tarefasService.ObterMediaTarefasConcluidasUltimos30DiasPorUsuario(usuarioId);

            // Assert
            Assert.AreEqual(mediaEsperada, result); // Verifica se a média retornada é igual à esperada
        }
    }
}
