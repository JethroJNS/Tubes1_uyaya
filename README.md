# Penjelasan Algoritma Greedy pada Bot

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
- **Serangan:** Daya tembak 3 (>200 unit), 2 (200-400 unit), 1 (<400 unit).  
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

