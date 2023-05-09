namespace TestEloadasProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Eloadas eloadas = new Eloadas(10, 10);
        }

        [Test]
        public void Eloadas_bevitelMinElso()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Eloadas e = new Eloadas(-1, 1);
            });
        }

        [Test]
        public void Eloadas_bevitelMinMasodik()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Eloadas e = new Eloadas(1, -1);
            });
        }
    }
}