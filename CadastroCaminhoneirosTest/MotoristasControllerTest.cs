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
    public class MotoristasControllerTest
    {
        private readonly Mock<DbSet<Motorista>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Motorista _motorista;

        public MotoristasControllerTest()
        {
            _mockSet = new Mock<DbSet<Motorista>>();
            _mockContext = new Mock<Context>();
            _motorista = new Motorista { Id = 1, PrimeiroNome = "Teste Motorista", UltimoNome = "Teste Motorista" };

            _mockContext.Setup(m => m.Motorista).Returns(_mockSet.Object);

            _mockContext.Setup(m => m.Motorista.FindAsync(1)).ReturnsAsync(_motorista);

            _mockContext.Setup(m => m.SetModified(_motorista));//SetModified

            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        }


        [Fact]
        public async Task Get_Motorista()
        {
            var service = new MotoristasController(_mockContext.Object);

            await service.GetMotorista(1);

            _mockSet.Verify(m => m.FindAsync(1), Times.Once());
        }

        [Fact]
        public async Task Put_Motorista()
        {
            var service = new MotoristasController(_mockContext.Object);
            await service.PutMotorista(1, _motorista);

            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Post_Motorista()
        {
            var service = new MotoristasController(_mockContext.Object);
            await service.PostMotorista(_motorista);

            _mockSet.Verify(x => x.Add(_motorista), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Delete_Motorista()
        {
            var service = new MotoristasController(_mockContext.Object);
            await service.DeleteMotorista(1);

            _mockSet.Verify(m => m.FindAsync(1), Times.Once());
            _mockSet.Verify(x => x.Remove(_motorista), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

    }
}
