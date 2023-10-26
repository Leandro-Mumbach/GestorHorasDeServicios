using GestorHorasDeServicios.Controllers;
using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestsGestorHorasDeServicios
{
    [TestClass]
    public class ProyectosTests
    {
     //GetAllProyectos
        [TestMethod]
        public async Task TestGetAllProyectos()
        {
            //ARRANGE
            var proyectosTest = new List<Proyectos>
            {
                new Proyectos
                {
                    CodProyecto = 1,
                    Nombre = "Proyecto 1",
                    Dirección = "calle 123",
                    Estado = 2
                },
                new Proyectos
                {
                    CodProyecto = 2,
                    Nombre = "Proyecto 2",
                    Dirección = "avenida 123",
                    Estado = 1
                }
            };

            var mockRepository = new Mock<IProyectosRepository>();
            mockRepository.Setup(repo => repo.GetAllProyectos(1, 3)).ReturnsAsync(proyectosTest);
            var controller = new ProyectosControllers(mockRepository.Object);


            //ACT
            var result = await controller.Get() as OkObjectResult;
            var proyectosTestResult = result.Value as IEnumerable<Proyectos>;


            //ASSERT
            Assert.IsNotNull(result);
            Assert.IsNotNull(proyectosTestResult);
            Assert.AreEqual(2, proyectosTestResult.Count());
        }

     //GetProyectosById
        [TestMethod]
        public async Task TestGetByIdProyectos()
        {
            //ARRANGE
            var proyectosTest = new Proyectos
            {
                CodProyecto = 1,
                Nombre = "Proyecto 1",
                Dirección = "calle 123",
                Estado = 2
            };
          

            var mockRepository = new Mock<IProyectosRepository>();
            mockRepository.Setup(repo => repo.GetProyectosById(1)).ReturnsAsync(proyectosTest);
            var controller = new ProyectosControllers(mockRepository.Object);


            //ACT
            var result = await controller.Get(1) as OkObjectResult;
            var proyectosTestResult = result.Value as Proyectos;


            //ASSERT
            Assert.IsNotNull(result);
            Assert.IsNotNull(proyectosTestResult);
            Assert.AreEqual(1, proyectosTestResult.CodProyecto);
            Assert.AreEqual("Proyecto 1", proyectosTestResult.Nombre);
        }

     //UpdateProyecto
        [TestMethod]
        public async Task UpdateProyecto()
        {
            //ARRANGE
            var proyectosTest = new Proyectos{CodProyecto = 1, Nombre = "Proyecto 1", Dirección = "calle 123", Estado = 2};
            var updatedProyectosTest = new Proyectos{CodProyecto = 1, Nombre = "ProyectoAct 1", Dirección = "CALLE 123", Estado = 2};

            var mockRepository = new Mock<IProyectosRepository>();
            mockRepository.Setup(repo => repo.GetProyectosById(1)).ReturnsAsync(updatedProyectosTest);
            var controller = new ProyectosControllers(mockRepository.Object);


            //ACT
            var result = await controller.Put(1, updatedProyectosTest) as NoContentResult;


            //ASSERT
            Assert.IsNotNull(result);
            mockRepository.Verify(repo => repo.UpdateProyecto(updatedProyectosTest), Times.Once);
        }

     //UpdateProyecto ReturnsNotFound
        [TestMethod]
        public async Task ReturnsNotFound()
        {
            //ARRANGE
            var mockRepository = new Mock<IProyectosRepository>();
            mockRepository.Setup(repo => repo.GetProyectosById(1)).ReturnsAsync((Proyectos)null);
            var controller = new ProyectosControllers(mockRepository.Object);


            //ACT
            var result = await controller.Put(1, new Proyectos { CodProyecto = 1, Nombre = "Proyecto 1", Dirección = "calle 123", Estado = 2 });


            //ASSERT
            Assert.IsNotNull(result);
        }

     //DeleteProyecto
        [TestMethod]
        public async Task DeleteProyecto()
        {
            //ARRANGE
            var proyectosTest = new Proyectos {CodProyecto = 1, Nombre = "Proyecto 1", Dirección = "calle 123", Estado = 2 };

            var mockRepository = new Mock<IProyectosRepository>();
            mockRepository.Setup(repo => repo.GetProyectosById(1)).ReturnsAsync(proyectosTest);
            var controller = new ProyectosControllers(mockRepository.Object);


            //ACT
            var result = await controller.Delete(1) as NoContentResult;


            //ASSERT
            Assert.IsNotNull(result);
            mockRepository.Verify(repo => repo.DeleteProyectoById(1), Times.Once);
        }

     //DeleteProyecto ReturnsNotFound
        [TestMethod]
        public async Task DeleteReturnsNotFound()
        {
            //ARRANGE
            var mockRepository = new Mock<IProyectosRepository>();
            mockRepository.Setup(repo => repo.GetProyectosById(1)).ReturnsAsync((Proyectos)null);
            var controller = new ProyectosControllers(mockRepository.Object);


            //ACT
            var result = await controller.Delete(1) as NotFoundResult;


            //ASSERT
            Assert.IsNotNull(result);
        }
    }
}