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
            Assert.IsTrue(Utils.InRangValidation(option, Op1, Op0));
        }

        [TestMethod]
        public void InRangValidationFirstMenuError()
        {
            const int Op1 = 1, Op0 = 0;
            int option = 3;
            Assert.IsFalse(Utils.InRangValidation(option, Op1, Op0));
        }
    }
}