namespace yazilim_proje2
{
    public abstract class Kisi
    {
        public string Isim { get; set; }
        public string Cinsiyet { get; set; }

        public abstract string BilgiVer();
    }
}
