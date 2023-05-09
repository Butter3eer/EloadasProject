namespace EloadasProject
{
    public class Eloadas
    {
        private bool[,] foglalasok;

        public Eloadas(int sorokSzama, int helyekSzama)
        {
            if (sorokSzama <= 0 || helyekSzama <= 0)
            {
                throw new ArgumentException();
            }
            else
            {
                foglalasok = new bool[sorokSzama, helyekSzama];
            }
        }

        public bool lefoglal()
        {
            int sorok = foglalasok.GetLength(0);
            int oszlopok = foglalasok.GetLength(1);

            for (int sor = 0; sor < sorok; sor++)
            {
                for (int oszlop = 0; oszlop < oszlopok; oszlop++)
                {
                    if (!foglalasok[sor, oszlop])
                    {
                        foglalasok[sor, oszlop] = true;
                        return true;
                    }
                }
            }
            return false;
        }

        public int SzabadHelyek
        {
            get
            {
                int db = 0;
                foreach (var item in foglalasok)
                {
                    if (!item)
                    {
                        db++;
                    }
                }
                return db;
            }
        }

        public bool Teli
        {
            get
            {
                bool teli = false;
                int db = 0;
                foreach (var item in foglalasok)
                {
                    if (item)
                    {
                        db++;
                    }
                }
                if (db == foglalasok.Length)
                {
                    teli = true;
                }
                return teli;
            }
        }

        public bool[,] Foglalasok { get => foglalasok; set => foglalasok = value; }

        public bool Foglalt(int sorSzam, int helySzam)
        {
            bool foglalt = false;
            if (sorSzam < 1 || helySzam < 1)
            {
                throw new ArgumentException();
            }
            else
            {
                if (foglalasok[sorSzam - 1, helySzam - 1])
                {
                    foglalt = true;
                }
            }
            return foglalt;
        }
    }
}