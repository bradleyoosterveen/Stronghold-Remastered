using Data;
using Model;
using NUnit.Framework;

namespace DataTest
{
    public class DataRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            DotNetEnv.Env.TraversePath().Load();
        }

        [Test, Order(1)]
        public void InsertTestRole()
        {
            int expected = 1;
            int actual = DataRepository.InsertRole(new Role(0, "Test"));

            Assert.AreEqual(expected, actual);
        }

        [Test, Order(999)]
        public void DeleteAllTestRoles()
        {
            int expected = 1;
            int actual = DataRepository.DeleteRolesWithDescription("Test");

            Assert.AreEqual(expected, actual);
        }
    }
}