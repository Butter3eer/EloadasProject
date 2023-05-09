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

        [Test]
        public void SzabadHelyek_jolSzamolUres()
        {
            Assert.That(eloadas.SzabadHelyek, Is.EqualTo(100));
        }

        [Test]
        public void SzabadHelyek_jolSzamolEgy()
        {
            eloadas.lefoglal();
            Assert.That(eloadas.SzabadHelyek, Is.EqualTo(99));
        }

        [Test]
        public void SzabadHelyek_jolSzamolTobb()
        {
            eloadas.lefoglal();
            eloadas.lefoglal();
            eloadas.lefoglal();
            eloadas.lefoglal();
            eloadas.lefoglal();
            Assert.That(eloadas.SzabadHelyek, Is.EqualTo(95));
        }

        [Test]
        public void SzabadHelyek_jolSzamolTobbMajdnemTele()
        {
            Eloadas e = new Eloadas(1, 6);
            e.lefoglal();
            e.lefoglal();
            e.lefoglal();
            e.lefoglal();
            e.lefoglal();
            Assert.That(e.SzabadHelyek, Is.EqualTo(1));
        }

        [Test]
        public void Teli_jolSzamolUres()
        {
            Assert.That(eloadas.Teli, Is.EqualTo(false));
        }

        [Test]
        public void Teli_jolSzamolNemTeljesenUres()
        {
            eloadas.lefoglal();
            Assert.That(eloadas.Teli, Is.EqualTo(false));
        }

        [Test]
        public void Teli_jolSzamolNemTeljesenUresTobb()
        {
            eloadas.lefoglal();
            eloadas.lefoglal();
            eloadas.lefoglal();
            eloadas.lefoglal();
            eloadas.lefoglal();
            Assert.That(eloadas.Teli, Is.EqualTo(false));
        }

        [Test]
        public void Teli_jolSzamolTeli()
        {
            Eloadas e = new Eloadas(1, 5);
            e.lefoglal();
            e.lefoglal();
            e.lefoglal();
            e.lefoglal();
            e.lefoglal();
            Assert.That(e.Teli, Is.EqualTo(true));
        }

        [Test]
        public void Foglalt_haFalse()
        {
            Assert.That(eloadas.Foglalt(1, 1), Is.EqualTo(false));
        }

        [Test]
        public void Foglalt_haTrue()
        {
            eloadas.lefoglal();
            Assert.That(eloadas.Foglalt(1, 1), Is.EqualTo(true));
        }

        [Test]
        public void Foglalt_haFalseNemCsakAzElso()
        {
            Assert.That(eloadas.Foglalt(5, 6), Is.EqualTo(false));
        }

        [Test]
        public void Foglalt_haFalseDeVanTrue()
        {
            eloadas.lefoglal();
            eloadas.lefoglal();
            eloadas.lefoglal();
            eloadas.lefoglal();
            eloadas.lefoglal();
            Assert.That(eloadas.Foglalt(5, 6), Is.EqualTo(false));
        }

        [Test]
        public void Foglalt_haTrueNemCsakAzElso()
        {
            eloadas.lefoglal();
            eloadas.lefoglal();
            eloadas.lefoglal();
            eloadas.lefoglal();
            eloadas.lefoglal();
            Assert.That(eloadas.Foglalt(1, 4), Is.EqualTo(true));
        }
    }
}