Rekening rekening1 = new Rekening("112234567");

bool ulang = true;
int jumlah;
string pilihan;

while (ulang)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Tampilkan Info Rekening");
    Console.WriteLine("2. Setor Uang");
    Console.WriteLine("3. Tarik Uang");
    Console.WriteLine("4. Keluar");
    Console.Write("Pilih menu (1-4): ");
    pilihan = Console.ReadLine();
    switch (pilihan)
    {
        case "1":
            rekening1.DisplayInfo();
            break;
        case "2":
            Console.Write("Masukkan jumlah yang ingin disetor: ");
            if (int.TryParse(Console.ReadLine(), out int setorJumlah))
                rekening1.setorUang(setorJumlah);
            else
                Console.WriteLine("Input tidak valid!");
            break;
        case "3":
            Console.Write("Masukkan jumlah yang ingin ditarik: ");
            if (int.TryParse(Console.ReadLine(), out int tarikJumlah))
                rekening1.tarikUang(tarikJumlah);
            else
                Console.WriteLine("Input tidak valid!");
            break;
        case "4":
            ulang = false;
            Console.WriteLine("Terima kasih telah menggunakan ATM!");
            break;
        default:
            Console.WriteLine("Pilihan tidak valid, silakan coba lagi.");
            break;
    }
}

class Rekening
{
    private string _noRekening;
    private int _saldo;

    public int Saldo
    {
        get { return _saldo; }
        set
        {
            if (value < 0) Console.WriteLine("Saldo tidak boleh negatif!");
            else _saldo = value;
        }
    }

    public string NoRekening
    {
        get { return _noRekening; }
    }

    public Rekening(string no_rekening)
    {
        _noRekening = no_rekening;
        _saldo = 100000;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Menampilkan Info...");
        Console.WriteLine($"No. Rekening: {NoRekening}");
        Console.WriteLine($"Saldo saat ini Rp {Saldo} ");
    }

    public void setorUang(int jumlah)
    {
        if (jumlah <= 0) Console.WriteLine("Jumlah setor harus lebih dari 0!");
        else
        {
            Saldo += jumlah;
            Console.WriteLine($"Anda menyetor {jumlah}. Saldo baru: Rp {Saldo}");
        }
    }

    public void tarikUang(int jumlah)
    {
        if (jumlah <= 0) Console.WriteLine("Jumlah tarik harus lebih dari 0!");
        else if (jumlah > Saldo) Console.WriteLine("Saldo tidak cukup untuk penarikan!");
        else
        {
            Saldo -= jumlah;
            Console.WriteLine($"Anda menarik {jumlah}. Saldo baru: Rp {Saldo}");
        }
    }
}