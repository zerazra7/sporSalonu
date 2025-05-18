using System;

namespace yazilim_proje2
{
    public class Uye : Kisi
    {
        public string Telefon { get; set; }

        private int yas;
        public int Yas
        {
            get { return yas; }
            set
            {
                if (value < 18 || value > 110)
                    throw new ArgumentException("Yaş 18 ile 110 arasında olmalıdır.");
                yas = value;
            }
        }

        public int Odeme { get; set; }
        public string Tip { get; set; }

        public override string BilgiVer()
        {
            return $"Ad: {Isim}, Yaş: {Yas}, Tip: {Tip}";
        }
    }
}
