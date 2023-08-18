namespace Monopoly.Storage.Tests
{
    public class ManagerTests
    {
        private Manager _manager = new Manager();
        //Box box1 = new Box(10, 19, 10, 3);
        Box box2 = new Box(2, 10, 10, 10, 2);

        [Test]
        public void CheckingSpaceOnAPalletTest_ReturnTrue()
        {
            Pallet pallet = new Pallet(1);
            Box box = new Box(1, 10, 15, 10, 2);
            var result = _manager.CheckingSpaceOnAPallet(pallet, box);
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckingSpaceOnAPalletTest_ReturnFalse()
        {
            Pallet pallet = new Pallet(1);
            Box box2 = new Box(2, 120, 150, 120, 2);
            var result = _manager.CheckingSpaceOnAPallet(pallet, box2);
            Assert.IsFalse(result);
        }
        Pallet pallet = new Pallet(1);
        Box box1 = new Box(1, 10, 19, 10, 3);
        Pallet pallet1 = new Pallet(1)
        {
            boxes = new List<Box>() { new Box(1, 10, 19, 10, 3) }
        };

        [Test]
        public void AddBoxOnPalletTest()
        {
            Pallet actualPallet = new Pallet(1);
            Box box1 = new Box(1, 10, 19, 10, 3);
            Pallet expectedPallet = new Pallet(1)
            {
                boxes = new List<Box>() { new Box(1, 10, 19, 10, 3) }
            };
            _manager.AddBoxOnPallet(box1, actualPallet);

            Assert.AreEqual(expectedPallet, actualPallet);
        }
    }
}