using CadastroCaminhoneirosAPI.Controllers;
using CadastroCaminhoneirosMVC.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CadastroCaminhoneirosTest
{
    public class EnderecoMotoristasControllerTest
    {
        private readonly Mock<DbSet<EnderecoMotorista>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly EnderecoMotorista _enderecoMotorista;

        public EnderecoMotoristasControllerTest()
        {
            _mockSet = new Mock<DbSet<EnderecoMotorista>>();
            _mockContext = new Mock<Context>();
            _enderecoMotorista = new EnderecoMotorista { Id = 1, Cep = 01001000, Logradouro = "Praça da Sé", Numero = 1, Bairro = "Sé", Cidade = "São Paulo", Estado = "São Paulo", MotoristaId = 1 };

            _mockContext.Setup(m => m.EnderecoMotorista).Returns(_mockSet.Object);

            _mockContext.Setup(m => m.EnderecoMotorista.FindAsync(1)).ReturnsAsync(_enderecoMotorista);

            _mockContext.Setup(m => m.SetModified(_enderecoMotorista));//SetModified

            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        }


        [Fact]
        public async Task Put_EnderecoMotorista()
        {
            var service = new EnderecoMotoristasController(_mockContext.Object);
            await service.PutEnderecoMotorista(1, _enderecoMotorista);

            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Post_EnderecoMotorista()
        {
            var service = new EnderecoMotoristasController(_mockContext.Object);
            await service.PostEnderecoMotorista(_enderecoMotorista);

            _mockSet.Verify(x => x.Add(_enderecoMotorista), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Delete_EnderecoMotorista()
        {
            var service = new EnderecoMotoristasController(_mockContext.Object);
            await service.DeleteEnderecoMotorista(1);

            _mockSet.Verify(m => m.FindAsync(1), Times.Once());
            _mockSet.Verify(x => x.Remove(_enderecoMotorista), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
