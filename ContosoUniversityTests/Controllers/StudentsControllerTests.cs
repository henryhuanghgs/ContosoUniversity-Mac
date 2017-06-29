using System;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using static ContosoUniversity.Data.DbInitializer;
using Xunit;
using ContosoUniversity.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ContosoUniversity.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversityTests.Controllers
{
    public class StudentsControllerTests
    {
		private SchoolContext _context;

        public StudentsControllerTests()
        {
            setup();
        }

        void setup() {
            var builder = new DbContextOptionsBuilder<SchoolContext>().UseInMemoryDatabase();
			_context = new SchoolContext(builder.Options);

            DbInitializer.Initialize(_context);
        }

        [Fact]
        public void TestQueryStudents() {
			var students = from s in _context.Students select s;

            var student = students.Where(s => s.LastName.Contains("Alexander")).Single();

            Assert.Equal(student.LastName, "Alexander");

		}

	    [Fact]
	    public async Task TestIndexAsync() {
	        var studentController = new StudentsController(_context);
	        var res = await studentController.Index("name_desc", null, null, null);

	        var viewResult = Assert.IsType<ViewResult>(res);

	        var model = Assert.IsAssignableFrom<IEnumerable<Student>>(viewResult.ViewData.Model);

			Assert.Equal(3, model.Count());

		    var student = model.First();
            //System.Console.WriteLine(student.LastName);
		    Assert.Equal(student.LastName, "Olivetto");
		}

		[Fact]
		public void TestIndex()
		{
			var studentController = new StudentsController(_context);
			var task = studentController.Index("name_desc", null, null, null);

            var res = task.Result;
			var viewResult = Assert.IsType<ViewResult>(res);

			var model = Assert.IsAssignableFrom<IEnumerable<Student>>(viewResult.ViewData.Model);

			Assert.Equal(3, model.Count());

			var student = model.First();
			//System.Console.WriteLine(student.LastName);
			Assert.Equal(student.LastName, "Olivetto");
		}
    }
}
