-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 17, 2024 at 05:00 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbsepatu`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbpemesanan`
--

CREATE TABLE `tbpemesanan` (
  `idpelanggan` int(4) NOT NULL,
  `Id_Sepatu` int(4) NOT NULL,
  `Namapel` text NOT NULL,
  `Namasep` text NOT NULL,
  `alamatpel` text NOT NULL,
  `nohp` varchar(13) NOT NULL,
  `size` text NOT NULL,
  `harga` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbpo`
--

CREATE TABLE `tbpo` (
  `IdAntrian` int(4) NOT NULL,
  `Id_Sepatu` int(4) NOT NULL,
  `Namapel` text NOT NULL,
  `nohp` varchar(13) NOT NULL,
  `Merek` text NOT NULL,
  `Jenis` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbpo`
--

INSERT INTO `tbpo` (`IdAntrian`, `Id_Sepatu`, `Namapel`, `nohp`, `Merek`, `Jenis`) VALUES
(1, 1, 'ucup', '0188277715626', 'Adidas', 'Sneakers');

-- --------------------------------------------------------

--
-- Table structure for table `tbrak`
--

CREATE TABLE `tbrak` (
  `Id_Sepatu` int(4) NOT NULL,
  `Nama_sepatu` text NOT NULL,
  `Harga` text NOT NULL,
  `Rilis` date NOT NULL,
  `Jenis` text NOT NULL,
  `Merek` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbrak`
--

INSERT INTO `tbrak` (`Id_Sepatu`, `Nama_sepatu`, `Harga`, `Rilis`, `Jenis`, `Merek`) VALUES
(1, 'Adidas zero 60', '500000', '2005-07-17', 'Sneakers', 'Adidas'),
(2, 'Nike Dunk Panda', '1500000', '2014-03-14', 'Basket', 'Nike'),
(3, 'LV 087 Rex', '3500000', '2024-01-13', 'Sneakers', 'LV');

-- --------------------------------------------------------

--
-- Table structure for table `tbuser`
--

CREATE TABLE `tbuser` (
  `Nama` text NOT NULL,
  `Email` text NOT NULL,
  `NoHp` varchar(13) NOT NULL,
  `Username` text NOT NULL,
  `Password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbuser`
--

INSERT INTO `tbuser` (`Nama`, `Email`, `NoHp`, `Username`, `Password`) VALUES
('ucup', 'ucup@gmail.com', '0891872668121', 'ucup', 'ucup');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbpemesanan`
--
ALTER TABLE `tbpemesanan`
  ADD PRIMARY KEY (`idpelanggan`),
  ADD KEY `Id_Sepatu` (`Id_Sepatu`);

--
-- Indexes for table `tbpo`
--
ALTER TABLE `tbpo`
  ADD PRIMARY KEY (`IdAntrian`),
  ADD KEY `Id_Sepatu` (`Id_Sepatu`);

--
-- Indexes for table `tbrak`
--
ALTER TABLE `tbrak`
  ADD PRIMARY KEY (`Id_Sepatu`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbpemesanan`
--
ALTER TABLE `tbpemesanan`
  MODIFY `idpelanggan` int(4) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbpo`
--
ALTER TABLE `tbpo`
  MODIFY `IdAntrian` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `tbrak`
--
ALTER TABLE `tbrak`
  MODIFY `Id_Sepatu` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tbpemesanan`
--
ALTER TABLE `tbpemesanan`
  ADD CONSTRAINT `tbpemesanan_ibfk_1` FOREIGN KEY (`Id_Sepatu`) REFERENCES `tbrak` (`Id_Sepatu`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `tbpo`
--
ALTER TABLE `tbpo`
  ADD CONSTRAINT `tbpo_ibfk_1` FOREIGN KEY (`Id_Sepatu`) REFERENCES `tbrak` (`Id_Sepatu`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
