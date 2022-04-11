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
    public class CaminhaoMotoristasControllerTest
    {
        private readonly Mock<DbSet<CaminhaoMotorista>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly CaminhaoMotorista _caminhaoMotorista;

        public CaminhaoMotoristasControllerTest()
        {
            _mockSet = new Mock<DbSet<CaminhaoMotorista>>();
            _mockContext = new Mock<Context>();
            _caminhaoMotorista = new CaminhaoMotorista { Id = 1, Marca = "Teste Marca", Modelo = "Teste Modelo", Placa = "Teste", Eixos = 4, MotoristaId = 1 };

            _mockContext.Setup(m => m.CaminhaoMotorista).Returns(_mockSet.Object);

            _mockContext.Setup(m => m.CaminhaoMotorista.FindAsync(1)).ReturnsAsync(_caminhaoMotorista);

            _mockContext.Setup(m => m.SetModified(_caminhaoMotorista));//SetModified

            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        }

        [Fact]
        public async Task Put_CaminhaoMotorista()
        {
            var service = new CaminhaoMotoristasController(_mockContext.Object);
            await service.PutCaminhaoMotorista(1, _caminhaoMotorista);

            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Post_CaminhaoMotorista()
        {
            var service = new CaminhaoMotoristasController(_mockContext.Object);
            await service.PostCaminhaoMotorista(_caminhaoMotorista);

            _mockSet.Verify(x => x.Add(_caminhaoMotorista), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Delete_CaminhaoMotorista()
        {
            var service = new CaminhaoMotoristasController(_mockContext.Object);
            await service.DeleteCaminhaoMotorista(1);

            _mockSet.Verify(m => m.FindAsync(1), Times.Once());
            _mockSet.Verify(x => x.Remove(_caminhaoMotorista), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
