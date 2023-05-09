namespace TestEloadasProject
{
    public class Tests
    {
        Eloadas eloadas;
        [SetUp]
        public void Setup()
        {
            eloadas = new Eloadas(10, 10);
        }

        [Test]
        public void Eloadas_bevitelMinElso()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Eloadas e = new Eloadas(0, 1);
            });
        }

        [Test]
        public void Eloadas_bevitelMinMasodik()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Eloadas e = new Eloadas(1, 0);
            });
        }

        [Test]
        public void Eloadas_bevitelMinMindketto()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Eloadas e = new Eloadas(0, 0);
            });
        }

        [Test]
        public void Eloadas_bevitelMinJo()
        {
            Assert.DoesNotThrow(() =>
            {
                Eloadas e = new Eloadas(1, 1);
            });
        }

        [Test]
        public void Eloadas_bevitelJo()
        {
            Assert.DoesNotThrow(() =>
            {
                Eloadas e = new Eloadas(10, 15);
            });
        }

        [Test]
        public void Eloadas_letrehozMatrix()
        {
            Assert.IsNotEmpty(eloadas.Foglalasok);
        }

        [Test]
        public void Eloadas_letrehozMatrixMegfeleloMennyiseg()
        {
            Assert.That(eloadas.Foglalasok.Length, Is.EqualTo(100));
        }

        [Test]
        public void Eloadas_letrehozMatrixMegfeleloMennyisegEsUresek()
        {
            int db = 0;
            foreach (var e in eloadas.Foglalasok)
            {
                if (!e)
                {
                    db++;
                }
            }
            Assert.That(db, Is.EqualTo(100));
        }

        [Test]
        public void lefoglal_helyet()
        {
            Assert.That(true, Is.EqualTo(eloadas.lefoglal()));
        }

        [Test]
        public void lefoglal_elsoHelyet()
        {
            eloadas.lefoglal();
            Assert.That(true, Is.EqualTo(eloadas.Foglalasok[0, 0]));
        }

        [Test]
        public void lefoglal_masodikHelyet()
        {
            eloadas.lefoglal();
            eloadas.lefoglal();
            Assert.That(true, Is.EqualTo(eloadas.Foglalasok[0, 1]));
        }

        [Test]
        public void lefoglal_mindenHelyLefoglalvaMarad()
        {
            eloadas.lefoglal();
            eloadas.lefoglal();
            Assert.That(true, Is.EqualTo(eloadas.Foglalasok[0, 1]));
            Assert.That(true, Is.EqualTo(eloadas.Foglalasok[0, 0]));
        }
    }
}