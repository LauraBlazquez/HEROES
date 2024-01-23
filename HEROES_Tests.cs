using UtilsLibrary;
using Constants;
namespace HEROES_Tests
{
    [TestClass]
    public class HEROES_Tests
    {
        [TestMethod]
        public void InRangValidationFirstMenuOK()
        {
            Assert.IsTrue(Utils.InRangValidation(1, Values.Op0, Values.Op1));
        }

        [TestMethod]
        public void InRangValidationFirstMenuError()
        {
            Assert.IsFalse(Utils.InRangValidation(3, Values.Op0, Values.Op1));
        }

        [TestMethod]
        public void InRangValidationSecondMenuOK()
        {
            Assert.IsTrue(Utils.InRangValidation(1, Values.Op1, Values.Op4));
        }

        [TestMethod]
        public void InRangValidationSecondMenuError()
        {
            Assert.IsFalse(Utils.InRangValidation(5, Values.Op1, Values.Op4));
        }

        [TestMethod]
        public void InRangValidationHabilityOK()
        {
            Assert.IsTrue(Utils.InRangValidation(5));
        }

        [TestMethod]
        public void InRangValidationHabilityError()
        {
            Assert.IsFalse(Utils.InRangValidation(1));
        }

        [TestMethod]
        public void ValidNamesOk()
        {
            string[] names = { "Maria"," Laura"," Dani"," Marta" };
            Assert.IsFalse(Utils.ValidNames(names));
        }

        [TestMethod]
        public void ValidNamesError()
        {
            string[] names = { "Maria", " Laura", " Dani", " Marta"," Nuria"};
            Assert.IsTrue(Utils.ValidNames(names));
        }

        [TestMethod]
        public void TurnsOrderOK()
        {
            int[] turns = new int[4];
            Utils.TurnsOrder(turns);
            Assert.IsTrue(turns.Contains(0) && turns.Contains(1) && turns.Contains(2) && turns.Contains(3));
        }

        [TestMethod]
        public void RandomOK()
        {
            Assert.IsTrue(Utils.Random(4) >= 0 && Utils.Random(4) <= 3);
        }

        //[TestMethod]
        //public void OrderPrintByHealthOK()
        //{
        //    int[,] stats = { { Values.Archer, Values.ArcherHealthMax, Values.ArcherAttackMax, Values.ArcherShieldMax, Values.Cooldown },
        //                     { Values.Barbarian, Values.BarbarianHealthMax, Values.BarbarianAttackMax, Values.BarbarianShieldMax, Values.Cooldown },
        //                     { Values.Magician, Values.MagicianHealthMax, Values.MagicianAttackMax, Values.MagicianShieldMax, Values.Cooldown },
        //                     { Values.Druid, Values.DruidHealthMax, Values.DruidAttackMax, Values.DruidShieldMax, Values.Cooldown } };

        //    int[,] expected = { { Values.Barbarian, Values.BarbarianHealthMax, Values.BarbarianAttackMax, Values.BarbarianShieldMax, Values.Cooldown },
        //                        { Values.Druid, Values.DruidHealthMax, Values.DruidAttackMax, Values.DruidShieldMax, Values.Cooldown },
        //                        { Values.Archer, Values.ArcherHealthMax, Values.ArcherAttackMax, Values.ArcherShieldMax, Values.Cooldown },
        //                        { Values.Magician, Values.MagicianHealthMax, Values.MagicianAttackMax, Values.MagicianShieldMax, Values.Cooldown } };
        //    //Utils.OrderPrintByHealth(stats);
        //    for (int i = 0; i < stats.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < stats.GetLength(1); j++)
        //        {
        //            Assert.AreEqual(stats[i, j], expected[i, j]);
        //        }
        //    }
        //}

        [TestMethod]
        public void AttackOK()
        {
            int[,] stats = { { Values.Archer, Values.ArcherHealthMax, Values.ArcherAttackMax, Values.ArcherShieldMax, Values.Cooldown },
                             { Values.Barbarian, Values.BarbarianHealthMax, Values.BarbarianAttackMax, Values.BarbarianShieldMax, Values.Cooldown },
                             { Values.Magician, Values.MagicianHealthMax, Values.MagicianAttackMax, Values.MagicianShieldMax, Values.Cooldown },
                             { Values.Druid, Values.DruidHealthMax, Values.DruidAttackMax, Values.DruidShieldMax, Values.Cooldown } };
            int[] monsterStats = { Values.MonsterHealthMin, Values.MonsterAttackMin, Values.MonsterShieldMin, Values.KnockOut };
            Assert.AreEqual(Utils.Attack(stats, monsterStats, 0), 240);
        }

        [TestMethod]
        public void ShieldImprovementOK()
        {
            int[,] stats = { { Values.Archer, Values.ArcherHealthMax, Values.ArcherAttackMax, Values.ArcherShieldMax, Values.Cooldown },
                             { Values.Barbarian, Values.BarbarianHealthMax, Values.BarbarianAttackMax, Values.BarbarianShieldMax, Values.Cooldown },
                             { Values.Magician, Values.MagicianHealthMax, Values.MagicianAttackMax, Values.MagicianShieldMax, Values.Cooldown },
                             { Values.Druid, Values.DruidHealthMax, Values.DruidAttackMax, Values.DruidShieldMax, Values.Cooldown } };
            Assert.AreEqual(Utils.ShieldImprovement(stats, 0), 70);
        }

        [TestMethod]
        public void HealOK()
        {
            Assert.AreEqual(Utils.Heal(200, 2000), 700);
        }

        [TestMethod]
        public void HealMax()
        {
            Assert.AreEqual(Utils.Heal(1900, 2000), 2000);
        }

        [TestMethod]
        public void NoHeal()
        {
            Assert.AreEqual(Utils.Heal(0, 2000), 0);
        }

        [TestMethod]
        public void HabilitiesBalanceOK()
        {
            Assert.AreEqual(Utils.HabilitiesBalance(4, 5), 3);
        }

        [TestMethod]
        public void NoHabilitiesBalance()
        {
            Assert.AreEqual(Utils.HabilitiesBalance(5, 5), 5);
        }

        [TestMethod]
        public void HabilitiesBalanceCooldown()
        {
            Assert.AreEqual(Utils.HabilitiesBalance(0, 5), 5);
        }
    }
}