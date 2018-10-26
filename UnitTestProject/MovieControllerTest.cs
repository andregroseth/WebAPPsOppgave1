using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebAppsProsjekt1.BLL;
using WebAppsProsjekt1.Controllers;
using WebAppsProsjekt1.DAL;
using WebAppsProsjekt1.Model;

namespace UnitTestProject
{
    [TestClass]
    public class MovieControllerTest
    {
        [TestMethod]
        public void MovieListAdminView()
        {
            // Arrange
            var controller = new MovieController(new MovieBLL(new DBMovieStub()));
            var expectedResult = new List<Movie>();
            var movie = new Movie()
            {
                Id = 1,
                Title = "The Matrix",
                Category = "Sci-Fi",
                Cost = 59,
                ImagePath = "/Content/images/movie/matrixImage.jpg",
                MovieSrc = "https://www.youtube.com/embed/m8e-FF8MsqU"
            };
            expectedResult.Add(movie);
            expectedResult.Add(movie);
            expectedResult.Add(movie);

            // Act
            var actionResult = (ViewResult)controller.MovieListAdminView();
            var result = (List<Movie>)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Id, result[i].Id);
                Assert.AreEqual(expectedResult[i].Title, result[i].Title);
                Assert.AreEqual(expectedResult[i].Category, result[i].Category);
                Assert.AreEqual(expectedResult[i].Cost, result[i].Cost);
                Assert.AreEqual(expectedResult[i].ImagePath, result[i].ImagePath);
                Assert.AreEqual(expectedResult[i].MovieSrc, result[i].MovieSrc);
            }
        }

        [TestMethod]
        public void MovieAdd_Post_Valid()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new MovieController(new MovieBLL(new DBMovieStub()));
            SessionMock.InitializeController(controller);
            controller.Session["AddSuccess"] = "true";
            var movie = new Movie()
            {
                Id = 1,
                Title = "The Matrix",
                Category = "Sci-Fi",
                Cost = 59,
                ImagePath = "/Content/images/movie/matrixImage.jpg",
                MovieSrc = "https://www.youtube.com/embed/m8e-FF8MsqU"
            };
            // Act
            var result = (RedirectToRouteResult)controller.MovieAdd(movie);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "MovieListAdminView");
        }

        [TestMethod]
        public void MovieAdd_Post_Model_Error()
        {

        }
    }
}
