-- phpMyAdmin SQL Dump
-- version 4.9.5deb2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jan 22, 2024 at 10:43 AM
-- Server version: 8.0.35-0ubuntu0.20.04.1
-- PHP Version: 7.4.3-4ubuntu2.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `emails_api`
--
CREATE DATABASE IF NOT EXISTS `emails_api` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `emails_api`;

-- --------------------------------------------------------

--
-- Table structure for table `emails_sent`
--

CREATE TABLE `emails_sent` (
  `id` int NOT NULL,
  `subject` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `body` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `receivers` text NOT NULL,
  `Result` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FailedMessage` text NOT NULL,
  `email_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `emails_sent`
--
ALTER TABLE `emails_sent`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `emails_sent`
--
ALTER TABLE `emails_sent`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
