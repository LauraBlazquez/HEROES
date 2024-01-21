using UtilsLibrary;
namespace HEROES_Tests
{
    [TestClass]
    public class HEROES_Tests
    {
        [TestMethod]
        public void InRangValidationFirstMenuOK()
        {
            const int Op1 = 1, Op0 = 0;
            int option = 1;
            Assert.IsTrue(Utils.InRangValidation(option, Op0, Op1));
        }

        [TestMethod]
        public void InRangValidationFirstMenuError()
        {
            const int Op1 = 1, Op0 = 0;
            int option = 3;
            Assert.IsFalse(Utils.InRangValidation(option, Op0, Op1));
        }

        [TestMethod]
        public void InRangValidationSecondMenuOK()
        {
            const int Op4 = 4, Op1 = 1;
            int option = 1;
            Assert.IsTrue(Utils.InRangValidation(option, Op1, Op4));
        }

        [TestMethod]
        public void InRangValidationSecondMenuError()
        {
            const int Op4 = 4, Op1 = 1;
            int option = 5;
            Assert.IsFalse(Utils.InRangValidation(option, Op1, Op4));
        }
    }
}