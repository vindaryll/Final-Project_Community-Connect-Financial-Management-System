-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 20, 2024 at 05:12 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `community_connect_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `amount_distribution_history`
--

CREATE TABLE `amount_distribution_history` (
  `balanceID` int(11) NOT NULL,
  `distributed_amount` decimal(10,2) DEFAULT NULL,
  `prev_balance` decimal(10,2) DEFAULT NULL,
  `after_balance` decimal(10,2) DEFAULT NULL,
  `fundID` int(11) DEFAULT NULL,
  `distributionID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `amount_distribution_history`
--

INSERT INTO `amount_distribution_history` (`balanceID`, `distributed_amount`, `prev_balance`, `after_balance`, `fundID`, `distributionID`) VALUES
(1, 1343406.35, 0.00, 1343406.35, 1, 1),
(2, 488511.40, 0.00, 488511.40, 2, 1),
(3, 244255.70, 0.00, 244255.70, 3, 1),
(4, 122127.85, 0.00, 122127.85, 4, 1),
(5, 122127.85, 0.00, 122127.85, 5, 1),
(6, 73276.71, 0.00, 73276.71, 6, 1),
(7, 24425.57, 0.00, 24425.57, 7, 1),
(8, 24425.57, 0.00, 24425.57, 8, 1),
(9, 1100000.00, 815.90, 1100815.90, 1, 2),
(10, 400000.00, 432781.24, 832781.24, 2, 2),
(11, 200000.00, 244255.70, 444255.70, 3, 2),
(12, 100000.00, 122127.85, 222127.85, 4, 2),
(13, 100000.00, 122127.85, 222127.85, 5, 2),
(14, 60000.00, 40281.58, 100281.58, 6, 2),
(15, 20000.00, 425.57, 20425.57, 7, 2),
(16, 20000.00, 4425.57, 24425.57, 8, 2);

-- --------------------------------------------------------

--
-- Table structure for table `cashin_history`
--

CREATE TABLE `cashin_history` (
  `cashinID` int(11) NOT NULL,
  `orderID` int(11) DEFAULT NULL,
  `cashin_date` timestamp NOT NULL DEFAULT current_timestamp(),
  `cashin_amount` decimal(10,2) DEFAULT NULL,
  `source` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cashin_history`
--

INSERT INTO `cashin_history` (`cashinID`, `orderID`, `cashin_date`, `cashin_amount`, `source`) VALUES
(1, 1, '2024-01-10 00:13:00', 2442557.66, 'National Tax Allotment for Q1 2024'),
(2, 13, '2024-05-09 23:00:00', 2000000.00, 'National Tax Allotment Q2 2024');

-- --------------------------------------------------------

--
-- Table structure for table `distribution_history`
--

CREATE TABLE `distribution_history` (
  `distributionID` int(11) NOT NULL,
  `orderID` int(11) DEFAULT NULL,
  `distribution_date` timestamp NOT NULL DEFAULT current_timestamp(),
  `distributed_amount` decimal(10,2) DEFAULT NULL,
  `prev_balance` decimal(10,2) DEFAULT NULL,
  `after_balance` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `distribution_history`
--

INSERT INTO `distribution_history` (`distributionID`, `orderID`, `distribution_date`, `distributed_amount`, `prev_balance`, `after_balance`) VALUES
(1, 2, '2024-01-10 02:08:00', 2442557.00, 2442557.66, 0.66),
(2, 14, '2024-05-10 02:30:00', 2000000.00, 2000000.66, 0.66);

-- --------------------------------------------------------

--
-- Table structure for table `expenses_history`
--

CREATE TABLE `expenses_history` (
  `expenseID` int(11) NOT NULL,
  `orderID` int(11) DEFAULT NULL,
  `expense_amount` decimal(10,2) DEFAULT NULL,
  `prev_balance` decimal(10,2) DEFAULT NULL,
  `after_balance` decimal(10,2) DEFAULT NULL,
  `expense_date` timestamp NOT NULL DEFAULT current_timestamp(),
  `reason` text DEFAULT NULL,
  `fundID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `expenses_history`
--

INSERT INTO `expenses_history` (`expenseID`, `orderID`, `expense_amount`, `prev_balance`, `after_balance`, `expense_date`, `reason`, `fundID`) VALUES
(1, 3, 447900.13, 1343406.35, 895506.22, '2024-01-11 01:00:00', 'Salaries of Barangay Officials', 1),
(2, 4, 15000.00, 73276.71, 58276.71, '2024-01-15 05:00:00', 'Utility bills', 6),
(3, 5, 3000.00, 58276.71, 55276.71, '2024-01-16 01:00:00', 'Traveling Expenses - Local', 6),
(4, 6, 445800.11, 895506.22, 449706.11, '2024-02-11 01:00:00', 'Salaries of Barangay Officials', 1),
(5, 7, 14995.13, 55276.71, 40281.58, '2024-02-13 05:00:00', 'Utility bills', 6),
(6, 8, 55730.16, 488511.40, 432781.24, '2024-02-19 23:00:00', 'Investment in infrastructure development projects.', 2),
(7, 9, 18000.00, 24425.57, 6425.57, '2024-02-18 00:00:00', 'Organizing a community awareness campaign on child rights and protection.', 8),
(8, 10, 448890.21, 449706.11, 815.90, '2024-03-10 01:14:00', 'Salaries of Barangay Officials', 1),
(9, 12, 26000.00, 26425.57, 425.57, '2020-03-14 17:00:00', 'Distributing allowance to senior citizens within the Barangay', 7),
(10, 15, 500000.00, 1100815.90, 600815.90, '2024-05-11 00:00:00', 'Salaries of Barangay Officials', 1);

-- --------------------------------------------------------

--
-- Table structure for table `funds`
--

CREATE TABLE `funds` (
  `fundID` int(11) NOT NULL,
  `fundname` varchar(500) DEFAULT NULL,
  `abbreviation` varchar(15) DEFAULT NULL,
  `allocated_percentage` decimal(5,2) DEFAULT 0.00,
  `balance` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `funds`
--

INSERT INTO `funds` (`fundID`, `fundname`, `abbreviation`, `allocated_percentage`, `balance`) VALUES
(1, 'Personal Services Fund', 'PS', 55.00, 600815.91),
(2, 'Development Fund', 'DF', 20.00, 832781.24),
(3, 'Sangguniang Kabataan Fund', 'SK', 10.00, 444255.70),
(4, 'Brgy. Local Disaster Risk Reduction and Management Fund', 'LDRRM', 5.00, 222127.86),
(5, 'Gender And Development Fund', 'GAD', 5.00, 222127.86),
(6, 'Maintenance and Other Operating Expenses Fund', 'MOOE', 3.00, 100281.59),
(7, 'Senior and PWD Fund', 'SPWD', 1.00, 20425.58),
(8, 'Local Council for the Protection of Children Fund', 'LCPC', 1.00, 24425.58),
(9, 'Unallocated Fund', 'UN', 0.00, 0.66);

-- --------------------------------------------------------

--
-- Table structure for table `management`
--

CREATE TABLE `management` (
  `managementID` int(11) NOT NULL,
  `username` varchar(50) DEFAULT NULL,
  `email` varchar(250) DEFAULT NULL,
  `password` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `management`
--

INSERT INTO `management` (`managementID`, `username`, `email`, `password`) VALUES
(1, 'admin', 'brgymaraykit.official@gmail.com', 'password');

-- --------------------------------------------------------

--
-- Table structure for table `transactions_order`
--

CREATE TABLE `transactions_order` (
  `orderID` int(11) NOT NULL,
  `transaction_type` enum('transfer','expenses','cashin','distribution') DEFAULT NULL,
  `executed_timestamp` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transactions_order`
--

INSERT INTO `transactions_order` (`orderID`, `transaction_type`, `executed_timestamp`) VALUES
(1, 'cashin', '2024-05-12 03:25:34'),
(2, 'distribution', '2024-05-12 03:26:28'),
(3, 'expenses', '2024-05-12 03:36:03'),
(4, 'expenses', '2024-05-12 03:37:34'),
(5, 'expenses', '2024-05-12 03:51:00'),
(6, 'expenses', '2024-05-12 04:00:07'),
(7, 'expenses', '2024-05-12 04:01:15'),
(8, 'expenses', '2024-05-12 04:03:11'),
(9, 'expenses', '2024-05-12 04:08:36'),
(10, 'expenses', '2024-05-12 04:13:04'),
(11, 'transfer', '2024-05-12 05:02:23'),
(12, 'expenses', '2024-05-12 05:18:16'),
(13, 'cashin', '2024-05-12 07:56:05'),
(14, 'distribution', '2024-05-12 07:56:50'),
(15, 'expenses', '2024-05-12 07:57:48');

-- --------------------------------------------------------

--
-- Table structure for table `transfer_history`
--

CREATE TABLE `transfer_history` (
  `transferID` int(11) NOT NULL,
  `orderID` int(11) DEFAULT NULL,
  `from_fundID` int(11) DEFAULT NULL,
  `to_fundID` int(11) DEFAULT NULL,
  `transfer_amount` decimal(10,2) DEFAULT NULL,
  `from_prev_balance` decimal(10,2) DEFAULT NULL,
  `from_after_balance` decimal(10,2) DEFAULT NULL,
  `to_prev_balance` decimal(10,2) DEFAULT NULL,
  `to_after_balance` decimal(10,2) DEFAULT NULL,
  `transfer_date` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `reason` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transfer_history`
--

INSERT INTO `transfer_history` (`transferID`, `orderID`, `from_fundID`, `to_fundID`, `transfer_amount`, `from_prev_balance`, `from_after_balance`, `to_prev_balance`, `to_after_balance`, `transfer_date`, `reason`) VALUES
(1, 11, 8, 7, 2000.00, 6425.57, 4425.57, 24425.57, 26425.57, '2024-03-10 23:21:00', 'Supporting SPWD Fund');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `amount_distribution_history`
--
ALTER TABLE `amount_distribution_history`
  ADD PRIMARY KEY (`balanceID`),
  ADD KEY `fundID` (`fundID`),
  ADD KEY `distributionID` (`distributionID`);

--
-- Indexes for table `cashin_history`
--
ALTER TABLE `cashin_history`
  ADD PRIMARY KEY (`cashinID`),
  ADD KEY `orderID` (`orderID`);

--
-- Indexes for table `distribution_history`
--
ALTER TABLE `distribution_history`
  ADD PRIMARY KEY (`distributionID`),
  ADD KEY `orderID` (`orderID`);

--
-- Indexes for table `expenses_history`
--
ALTER TABLE `expenses_history`
  ADD PRIMARY KEY (`expenseID`),
  ADD KEY `orderID` (`orderID`),
  ADD KEY `fundID` (`fundID`);

--
-- Indexes for table `funds`
--
ALTER TABLE `funds`
  ADD PRIMARY KEY (`fundID`);

--
-- Indexes for table `management`
--
ALTER TABLE `management`
  ADD PRIMARY KEY (`managementID`);

--
-- Indexes for table `transactions_order`
--
ALTER TABLE `transactions_order`
  ADD PRIMARY KEY (`orderID`);

--
-- Indexes for table `transfer_history`
--
ALTER TABLE `transfer_history`
  ADD PRIMARY KEY (`transferID`),
  ADD KEY `from_fundID` (`from_fundID`),
  ADD KEY `to_fundID` (`to_fundID`),
  ADD KEY `orderID` (`orderID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `amount_distribution_history`
--
ALTER TABLE `amount_distribution_history`
  ADD CONSTRAINT `amount_distribution_history_ibfk_1` FOREIGN KEY (`fundID`) REFERENCES `funds` (`fundID`) ON DELETE CASCADE,
  ADD CONSTRAINT `amount_distribution_history_ibfk_2` FOREIGN KEY (`distributionID`) REFERENCES `distribution_history` (`distributionID`) ON DELETE CASCADE;

--
-- Constraints for table `cashin_history`
--
ALTER TABLE `cashin_history`
  ADD CONSTRAINT `cashin_history_ibfk_1` FOREIGN KEY (`orderID`) REFERENCES `transactions_order` (`orderID`) ON DELETE CASCADE;

--
-- Constraints for table `distribution_history`
--
ALTER TABLE `distribution_history`
  ADD CONSTRAINT `distribution_history_ibfk_1` FOREIGN KEY (`orderID`) REFERENCES `transactions_order` (`orderID`) ON DELETE CASCADE;

--
-- Constraints for table `expenses_history`
--
ALTER TABLE `expenses_history`
  ADD CONSTRAINT `expenses_history_ibfk_1` FOREIGN KEY (`orderID`) REFERENCES `transactions_order` (`orderID`) ON DELETE CASCADE,
  ADD CONSTRAINT `expenses_history_ibfk_2` FOREIGN KEY (`fundID`) REFERENCES `funds` (`fundID`);

--
-- Constraints for table `transfer_history`
--
ALTER TABLE `transfer_history`
  ADD CONSTRAINT `transfer_history_ibfk_1` FOREIGN KEY (`from_fundID`) REFERENCES `funds` (`fundID`),
  ADD CONSTRAINT `transfer_history_ibfk_2` FOREIGN KEY (`to_fundID`) REFERENCES `funds` (`fundID`),
  ADD CONSTRAINT `transfer_history_ibfk_3` FOREIGN KEY (`orderID`) REFERENCES `transactions_order` (`orderID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
