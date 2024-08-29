-----Task 3
--- No 1
CREATE TABLE Fakultas (
	kodeFakultas int not null,
	namaFakultas varchar(30),
	namaDekan varchar(50)
)

--- No 2
CREATE TABLE Prodi (
	kodeProdi int not null,
	kodeFakultas int not null,
	namaProdi varchar(30),
	namaKetuaProdi varchar(50)
)

--- No 3
CREATE TABLE Mahasiswa (
	NPM varchar(8) not null primary key,
	kodeProdi int,
	namaMahasiswa varchar(50),
	tempatLahir varchar(30),
	tanggalLahir Datetime,
	alamat varchar(100)
)

--- No 4
ALTER TABLE Fakultas ADD CONSTRAINT PK_Fakultas PRIMARY KEY (kodeFakultas)

--- No 5
ALTER TABLE Prodi ADD CONSTRAINT PK_Prodi PRIMARY KEY (kodeProdi,kodeFakultas)

--- No 6
-- A
INSERT INTO Fakultas VALUES 
(1,'Teknik','Ahmad Riyadi'),
(2,'Pertanian','Paiman'),
(3,'Ekonomi','Sukhemi'),
(4,'Keguruan','Suharni')

-- B
INSERT INTO Prodi VALUES
(11,1,'Teknik Informatika','Bachtiar Dwi Effendi'),
(21,2,'Agroteknologi','Bahrum'),
(31,3,'Manajemen','Vita'),
(32,3,'Akuntansi','Siti Maisaroh'),
(41,4,'PPKN','Sigit'),
(42,4,'Sejarah','Gunawan'),
(43,4,'Pendidikan Matematika','Tri'),
(44,4,'Bimbingan Konseling','Siswanti'),
(45,4,'PGSD','Haniek')

-- C
INSERT INTO Mahasiswa VALUES
('08110167', 11, 'Andi', 'Jakarta', '1988-12-03', 'Gunung Kidul'),
('08110231', 11, 'Joko', 'Sleman', '1989-01-02', 'Sleman'),
('08210232', 21, 'Budi', 'Bantul', '1988-09-15', 'Bantul'),
('08210233', 21, 'Cici', 'Purwokerto', '1989-02-21', 'Bantul'),
('08310234', 31, 'Didi', 'Bandung', '1987-07-11', 'Kodya'),
('08320235', 32, 'Alfin', 'Makassar', '1986-09-22', 'Kodya'),
('08320236', 32, 'Dodi', 'Gunung Kidul', '1979-03-24', 'Kodya'),
('08320237', 32, 'Derri', 'Pangkal Pinang', '1984-09-02', 'Sleman'),
('08410121', 41, 'Dudung', 'Kebumen', '1985-02-25', 'Sleman'),
('08410122', 41, 'Afgan', 'Palembang', '1986-11-21', 'Kulon Progo'),
('08420123', 42, 'Didi', 'Kutoarjo', '1986-09-11', 'Kulon Progo'),
('08430124', 43, 'Firza', 'Purworejo', '1986-09-11', 'Bantul'),
('08440125', 44, 'Zahir', 'Temom', '1986-09-11', 'Kulon Progo');


--- No 7
ALTER TABLE Mahasiswa ADD tanggalDaftar date

--- No 8
SELECT namaMahasiswa,alamat FROM Mahasiswa WHERE YEAR(tanggalLahir) BETWEEN 1970 AND 1979

--- No 9
SELECT a.namaMahasiswa,b.namaProdi FROM Mahasiswa a LEFT JOIN Prodi b ON a.kodeProdi = b.kodeProdi

--- No 10
SELECT TOP 3 a.namaMahasiswa, a.alamat
FROM Mahasiswa a INNER JOIN Prodi b ON a.kodeProdi = b.kodeProdi
INNER JOIN Fakultas c ON b.kodeFakultas = b.kodeFakultas
WHERE c.namaFakultas = 'Teknik' 
ORDER BY a.tanggalLahir ASC

--- No 11
SELECT COUNT(1) as 'Jumlah Mahasiswa dari Sleman' FROM Mahasiswa WHERE alamat = 'Sleman'

--- No 12
UPDATE Mahasiswa SET tanggalDaftar = '2013-09-03'

--- No 13
SELECT * FROM Mahasiswa WHERE namaMahasiswa LIKE 'D%'

--- No 14
UPDATE Mahasiswa SET tanggalLahir = '1990-01-20' WHERE namaMahasiswa = 'Joko'

--- No 15
SELECT a.namaProdi, COUNT(b.namaMahasiswa) as JumlahMahasiswa 
FROM Prodi a LEFT JOIN Mahasiswa b
ON a.kodeProdi = b.kodeProdi
GROUP BY a.namaProdi