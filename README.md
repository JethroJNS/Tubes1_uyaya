# Penjelasan Algoritma Greedy pada Bot

## Daftar Isi
1. [Main Bot](#main-bot)
2. [Alternatif Bot 1](#alternatif-bot-1)
3. [Alternatif Bot 2](#alternatif-bot-2)
4. [Alternatif Bot 3](#alternatif-bot-3)
5. [Requirement Program dan Instalasi](#requirement-program-dan-instalasi)
6. [Author](#author)

## Main Bot
- **Pergerakan:** Bot menjaga jarak optimal (menjauh <150 unit, mendekat >400 unit, orbit di jarak tengah).  
  *Heuristik:* Menjaga keseimbangan serangan dan pertahanan.
- **Pemindaian:** Fokus pada lawan terdekat.  
  *Heuristik:* Serangan lebih akurat dan cepat eliminasi.
- **Serangan:** Daya tembak besar di jarak dekat, kecil di jarak jauh.  
  *Heuristik:* Maksimalkan damage di jarak efektif.
- **Tabrakan Lawan:** Tabrak dan tembak jika lawan energi rendah.  
  *Heuristik:* Memanfaatkan musuh lemah untuk poin.
- **Menghindari Dinding:** Belok 60° saat menabrak.  
  *Heuristik:* Cepat keluar dari posisi macet.

## Alternatif Bot 1
- **Pergerakan:** Berputar 360° sambil maju cepat.  
  *Heuristik:* Maksimalkan pengamatan dan hindari peluru.
- **Pemindaian:** Kunci target pertama.  
  *Heuristik:* Minimalkan peluang lawan kabur.
- **Serangan:** Daya tembak 3 (<200 unit), 2 (200-400 unit), 1 (>400 unit).  
  *Heuristik:* Sesuaikan daya untuk akurasi dan efisiensi.
- **Tabrakan Lawan:** Arahkan meriam ke lawan, tembak daya maksimum, lalu tabrak.  
  *Heuristik:* Manfaatkan lawan lemah.
- **Menghindari Dinding:** Mundur 100 unit, belok acak.  
  *Heuristik:* Hindari terjebak.

## Alternatif Bot 2
- **Pergerakan:** Pola slinki (45° kiri, 100 unit, 90° kanan).  
  *Heuristik:* Sulit ditembak, pemindaian menyeluruh.
- **Pemindaian:** Cari semua bot tanpa terkecuali.  
  *Heuristik:* Maksimalkan poin dari peluru.
- **Serangan:** Daya besar di jarak dekat, kecil di jarak jauh.  
  *Heuristik:* Efisiensi dan peluang kena lebih tinggi.
- **Menghindari Serangan:** Berbelok acak (90° ± 30°) dan maju acak (150 + random(50)).  
  *Heuristik:* Kurangi risiko kena tembakan.
- **Tabrakan Lawan:** Mundur 50 unit, putar 30°, tembak saat GunHeat = 0.  
  *Heuristik:* Cepat keluar sambil serang.
- **Menghindari Dinding:** Mundur 50 unit, putar 90°.  
  *Heuristik:* Cepat lepas dari dinding.

## Alternatif Bot 3
- **Pergerakan:** Zig-zag tetap (200° kiri, maju 200 unit, 200° kanan, maju 200 unit).  
  *Heuristik:* Sulit diprediksi dan tetap mobile.
- **Pemindaian:** Cari semua lawan.  
  *Heuristik:* Maksimalkan peluang serangan.
- **Serangan:** Daya 3 (<100 unit), 2 (100-200 unit), 1 (>200 unit).  
  *Heuristik:* Daya besar di jarak dekat, kecil di jarak jauh.
- **Tabrakan Lawan:** Belok 50° kiri-kanan, tembak daya maksimum.  
  *Heuristik:* Hindari serangan sambil serang balik.
- **Menghindari Dinding:** Putar 100° kiri-kanan.  
  *Heuristik:* Cepat keluar tanpa mundur.

## Requirement Program dan Instalasi
1. **Instalasi .NET 6.0 untuk bot C#:**
   - **Download .NET SDK 6.0:** [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
   - **Cek instalasi:**
     ```bash
     dotnet --version
     ```
2. **Download Starter Pack:** [Tubes Starter Pack](https://github.com/Ariel-HS/tubes1-if2211-starter-pack/releases/tag/v1.0)
3. **Unduh dan jalankan game engine:**
   ```bash
   java -jar robocode-tankroyale-gui-0.30.0.jar
   ```
4. **Setup Config:**
   - Klik **Config** → **Bot Root Directories**
   - Masukkan directory berisi folder bot.
5. **Jalankan Battle:**
   - Klik **Battle** → **Start Battle**
   - Pilih bot, lalu **Boot →** dan **Add →**
6. **Referensi API:**
   - Buka `Robocode.TankRoyale.BotApi`


## Author
**Buege Mahara Putra  13523037**  
**Abrar Abhirama Widyadhana  13523038**  
**Jethro Jens Norbert Simatupang  13523081**

