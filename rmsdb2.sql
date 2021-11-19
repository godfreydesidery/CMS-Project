-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 19, 2021 at 06:40 AM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.1.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `rmsdb2`
--

-- --------------------------------------------------------

--
-- Table structure for table `allocations`
--

CREATE TABLE `allocations` (
  `allocation_id` int(11) NOT NULL,
  `allocation_no` varchar(50) NOT NULL,
  `date_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `allocation_date` date NOT NULL,
  `invoice_no` varchar(50) NOT NULL,
  `receipt_no` varchar(50) NOT NULL,
  `amount` double NOT NULL DEFAULT '0',
  `user_id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `bar_codes`
--

CREATE TABLE `bar_codes` (
  `sn` int(11) NOT NULL,
  `item_scan_code` varchar(50) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `descr` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `bill`
--

CREATE TABLE `bill` (
  `sn` int(11) NOT NULL,
  `bill_no` varchar(100) NOT NULL,
  `amount` double NOT NULL,
  `bill_date` date NOT NULL,
  `bill_type` varchar(50) NOT NULL,
  `bill_status` varchar(50) DEFAULT NULL,
  `description` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `cart`
--

CREATE TABLE `cart` (
  `id` int(11) NOT NULL,
  `till_no` varchar(50) DEFAULT NULL,
  `bar_code` varchar(50) DEFAULT NULL,
  `item_code` varchar(50) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `sn` varchar(100) DEFAULT NULL,
  `void` varchar(50) NOT NULL DEFAULT 'NO',
  `short_description` varchar(100) DEFAULT NULL,
  `price` double NOT NULL DEFAULT '0',
  `vat` double NOT NULL DEFAULT '0',
  `discount` double NOT NULL DEFAULT '0',
  `qty` double NOT NULL DEFAULT '0',
  `amount` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `claim_details`
--

CREATE TABLE `claim_details` (
  `id` int(11) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `description` varchar(100) NOT NULL,
  `qty` double NOT NULL,
  `price` double NOT NULL,
  `reason` varchar(100) DEFAULT NULL,
  `remarks` varchar(100) DEFAULT NULL,
  `claim_type` varchar(50) NOT NULL,
  `claim_id` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `claim_replacement_details`
--

CREATE TABLE `claim_replacement_details` (
  `id` int(11) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `description` varchar(100) NOT NULL,
  `qty` double NOT NULL,
  `price` double NOT NULL,
  `claim_id` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `class`
--

CREATE TABLE `class` (
  `class_id` int(11) NOT NULL,
  `class_i` varchar(50) DEFAULT NULL,
  `class_name` varchar(100) NOT NULL,
  `department_id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `collections`
--

CREATE TABLE `collections` (
  `sn` int(11) NOT NULL,
  `till_no` varchar(50) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `cash` double NOT NULL DEFAULT '0',
  `voucher` double NOT NULL DEFAULT '0',
  `deposit` double NOT NULL DEFAULT '0',
  `loyalty` double NOT NULL DEFAULT '0',
  `cr_card` double NOT NULL DEFAULT '0',
  `cheque` double NOT NULL DEFAULT '0',
  `cap` double NOT NULL DEFAULT '0',
  `invoice` double NOT NULL DEFAULT '0',
  `cr_note` double NOT NULL DEFAULT '0',
  `mobile` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `company`
--

CREATE TABLE `company` (
  `sn` int(11) NOT NULL,
  `company_name` varchar(50) DEFAULT NULL,
  `contact_name` varchar(50) DEFAULT NULL,
  `tin` varchar(50) DEFAULT NULL,
  `vrn` varchar(50) DEFAULT NULL,
  `bank_acc_name` varchar(50) DEFAULT NULL,
  `bank_acc_address` varchar(50) DEFAULT NULL,
  `bank_post_code` varchar(50) DEFAULT NULL,
  `bank_name` varchar(50) DEFAULT NULL,
  `bank_acc_no` varchar(50) DEFAULT NULL,
  `address` varchar(50) DEFAULT NULL,
  `post_code` varchar(50) DEFAULT NULL,
  `physical_address` varchar(50) DEFAULT NULL,
  `telephone` varchar(50) DEFAULT NULL,
  `mobile` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `fax` varchar(50) DEFAULT NULL,
  `policy` varchar(100) DEFAULT NULL,
  `logo` mediumblob,
  `touch` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `company`
--

INSERT INTO `company` (`sn`, `company_name`, `contact_name`, `tin`, `vrn`, `bank_acc_name`, `bank_acc_address`, `bank_post_code`, `bank_name`, `bank_acc_no`, `address`, `post_code`, `physical_address`, `telephone`, `mobile`, `email`, `fax`, `policy`, `logo`, `touch`) VALUES
(94, 'Bumaco Holdings Ltd', 'Ali', 'Z0000', 'X0000', '', '', '', '', '', 'Dar es Salaam', '200', 'Kinondoni, Dar es Salaam', '0712765360', '0712765360', 'desideryg@gmail.com', '0712765360', NULL, 0x89504e470d0a1a0a0000000d49484452000000e1000000e10803000000096d22480000000467414d410000b18f0bfc6105000000c6504c5445ffffff90caf961616142424242a5f51976d22424245252525c595623201cfbfdff87c6f98fcbfca0bbd32d2d2d2a435b44abfe71baf799cef9c1e0fb77b5ee0971d03d39346babea3384d8749cbd3c3c3cd6d6d600e676e2e2e2dcdcdc7979795f5f5f221909a0a0a0377cb58181814891de3786d9ececec625e61353535c5c5c500ee78afafaf96bad8332d278f8f8f94a6b56e6e6e6457605d71632838485d8fbacacaca87accbb4b4b456886529d0725a796431c6705982656167621cdc7437bd6e4a4a4ae5f891670000047849444154785eeddd7153da481cc6711bae07e57adc9dd69ec60231d2928885222df5f4aed5f7ffa62e90270a980d1bb2cbeec6e7f357a733c4df7796840ce27240444444444444442f56db1c4ca0dbd16fa61c6102dd8edebe32e32d0b5561a1362c548685dab05019166ac3426558a80d0b9561a1362c548685dab05019166ac3426558a80d0b9561a1362c548685dae82ebc0ae1b3b1c2cf9820bcc24c6a79716a7c6aacf0748c193ccca4d6d46f2cbd3758f83e1dc19f6226b558a81f0bab62a17e2cac8a85fab1b0aafa177ab1bf94dc979a723a4e47507d5f3aec9e257a93017cf9dd942f986030e92d46ea0e316115bdab7eab990a322d7330411060a6663f3cc3a4bbb9ec275d9ecd92d6e925a62def2ce9c3816c9634eeb88ea1137d0b41738299cb680f9a78bc0b5a83d2179d76df95054c05d3b28903b70293c401269714baf4144db54a9d8b3df7023daf39c7f4321c3b095341899bd5b98b4b982ca2fc4bbf934bb85844d9bf1aeab6f010bb4551847f659ab2f736372e1446d7b37f66d7eb8d4188826d5c782d8c66b7a3d1e8f66e2d31e8a3609ba9fd85d1ec436a2311055bb41db89246ffa2f0f61affb3d494bb751bda5ff8b8841f46b3d5456c76d150aceb40e1dd282bfc6fadb08786622e148ad6b03685def53d1671e33cac4f61f4e3e72271f4736d09eb54e845de7d5278ff632db05685c9137576b7794f53b3c29cfbd2ba15e66021b0d0622c04165a8c85c0428bb11058683116020b2dc64260a1c55808f52fec35f0b93ff734e47e097cd6493f88eba058eeb30a2cb4180ba1eb70a1dc95c6e1c20e0b532cb4180b8185166321b0d0622c04165a4c4561dc312dc62479aa17c6bfda40dc58b9b0831f619a78c08a85d90abe3107138856b16a210effe6eb1fa67ccd1231d1a68a85d9129e5ffc69cac53966102c62c5c2ec2c4c0a7f31e3a95034220b532fb770e53cc44fdc37dde761762db5a110136daa5ae8a747b7a010fbc83c53b510cf53f385c2dbb6ca850d7f71b539bfc00fdcbf656147b4822a0a13be3ffef69729dfc6be382fa1a470b18b123635dabf6c1725116585c6f789126121d4bf70c8428b0be5fe0eb85d7841b6bb5072db88a038d1e2c207146c33d9b1f09d6238ec936d85beec9e0a97e2b7eb16448587af8f95fa7888033fda5618cb6ef33d7cc023f2090b4f5e2b55bed097de0d6b52b888d616faf29b610d0b4f446b0b63b9d78aa5b068116d2d8c4b6df6d52858455b0be5cfc2859e7b85929f697b7423be75db5361c9578b4ee92f84b8129e8a7b5b431cf749416147768ba81573d1b9282a7c75a8168eba4258e8fbf25bb5ade84ef39fa9c242ed44859da0c4ebc49af9439cb38e9615fa7163a70584cb6923c626d78f8c7e0b0b66c824c37937987557c37938e8affb6eacf03b26c80cc279e9bd6765f0fb9eb461a1322fb7f0ef0a9ebf6591c37461a577314e726e619e315e58e5bef4130b1758a80c0b77c1c225f385c718b7bc63370a3f9deceef95b16394c17567a1703872866bc503b162ac3426d58a80c0bb561a1322cd48685cabc8042dc2defdfbe0a898888888888888888888888d43b38f81fccfbc83f488b7cf30000000049454e44ae426082, NULL),
(95, 'COMPANY', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(96, 'COMPANY', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(97, 'COMPANY', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(98, 'COMPANY', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(99, 'COMPANY', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(100, 'COMPANY', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `converted`
--

CREATE TABLE `converted` (
  `id` int(11) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `description` varchar(200) NOT NULL,
  `qty` double NOT NULL,
  `price` double NOT NULL,
  `conversion_id` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `corporate_customers`
--

CREATE TABLE `corporate_customers` (
  `customer_id` int(11) NOT NULL,
  `customer_code` varchar(50) NOT NULL,
  `customer_name` varchar(100) NOT NULL,
  `address` varchar(100) DEFAULT NULL,
  `post_code` varchar(100) DEFAULT NULL,
  `physical_address` varchar(100) DEFAULT NULL,
  `contact_name` varchar(100) DEFAULT NULL,
  `bank_acc_name` varchar(100) DEFAULT NULL,
  `bank_acc_address` varchar(100) DEFAULT NULL,
  `bank_post_code` varchar(100) DEFAULT NULL,
  `bank_name` varchar(50) NOT NULL,
  `bank_acc_no` varchar(50) DEFAULT NULL,
  `telephone` varchar(50) DEFAULT NULL,
  `mob` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `fax` varchar(50) DEFAULT NULL,
  `tin` varchar(50) DEFAULT NULL,
  `vrn` varchar(50) DEFAULT NULL,
  `invoice_limit` double NOT NULL DEFAULT '0',
  `credit_limit` double NOT NULL DEFAULT '0',
  `status` varchar(50) DEFAULT 'ACTIVE',
  `credit_balance` double NOT NULL DEFAULT '0',
  `credit_days` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `credit_notes`
--

CREATE TABLE `credit_notes` (
  `sn` int(11) NOT NULL,
  `cr_note_no` varchar(50) NOT NULL,
  `cr_note_bill_no` varchar(50) NOT NULL,
  `sr_note_creditor` varchar(50) NOT NULL,
  `cr_note_type` varchar(50) NOT NULL,
  `cr_note_status` varchar(50) NOT NULL,
  `cr_note_description` varchar(500) DEFAULT NULL,
  `cr_note_date` date NOT NULL,
  `credit_amount` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `credit_note_particulars`
--

CREATE TABLE `credit_note_particulars` (
  `sn` int(11) NOT NULL,
  `cr_note_no` varchar(50) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `qty` varchar(50) NOT NULL,
  `price` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `cr_note`
--

CREATE TABLE `cr_note` (
  `sn` int(11) NOT NULL,
  `cr_no` varchar(50) NOT NULL,
  `cr_amount` double NOT NULL,
  `cr_bill_no` varchar(50) NOT NULL,
  `cr_date` date NOT NULL,
  `cr_status` varchar(50) DEFAULT NULL,
  `cr_details` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `sn` int(11) NOT NULL,
  `customer_no` varchar(50) NOT NULL,
  `customer_name` varchar(100) NOT NULL,
  `address` varchar(500) DEFAULT NULL,
  `location` varchar(100) DEFAULT NULL,
  `telephone` varchar(50) DEFAULT NULL,
  `phone` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `fax` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `customer_claims`
--

CREATE TABLE `customer_claims` (
  `id` int(11) NOT NULL,
  `claim_no` varchar(50) NOT NULL,
  `claim_date` date NOT NULL,
  `settlement_date` date DEFAULT NULL,
  `status` varchar(50) NOT NULL,
  `customer_name` varchar(100) NOT NULL,
  `customer_phone` varchar(100) DEFAULT NULL,
  `customer_address` varchar(100) DEFAULT NULL,
  `issue_no` varchar(100) DEFAULT NULL,
  `invoice_no` varchar(100) DEFAULT NULL,
  `other` varchar(100) DEFAULT NULL,
  `returned_by` varchar(100) DEFAULT NULL,
  `received_by` varchar(100) DEFAULT NULL,
  `touch` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `customer_credit_notes`
--

CREATE TABLE `customer_credit_notes` (
  `sn` int(11) NOT NULL,
  `cr_no` varchar(50) NOT NULL,
  `cr_date` date NOT NULL,
  `cr_bill_no` varchar(50) DEFAULT NULL,
  `cr_amount` double NOT NULL,
  `status` varchar(50) NOT NULL,
  `cr_details` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `cust_orders`
--

CREATE TABLE `cust_orders` (
  `order_no` int(11) NOT NULL,
  `waiter_id` varchar(50) NOT NULL,
  `time_ordered` datetime NOT NULL,
  `status` varchar(50) NOT NULL,
  `time_completed` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `cust_order_details`
--

CREATE TABLE `cust_order_details` (
  `sn` int(11) NOT NULL,
  `order_no` varchar(50) NOT NULL,
  `barcode` varchar(50) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `description` varchar(100) NOT NULL,
  `qty` double NOT NULL,
  `price` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `damages`
--

CREATE TABLE `damages` (
  `id` int(11) NOT NULL,
  `date` date NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `qty` double NOT NULL DEFAULT '0',
  `price` double NOT NULL DEFAULT '0',
  `reference` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `day_log`
--

CREATE TABLE `day_log` (
  `day_no` int(11) NOT NULL,
  `date` date NOT NULL,
  `start_at` varchar(50) DEFAULT NULL,
  `end_at` varchar(50) DEFAULT NULL,
  `open_closed` varchar(50) DEFAULT 'NAN'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `debt_payment`
--

CREATE TABLE `debt_payment` (
  `id` int(11) NOT NULL,
  `date` date NOT NULL,
  `issue_no` varchar(50) NOT NULL,
  `initial_balance` double NOT NULL,
  `amount` double NOT NULL,
  `current_balance` double NOT NULL,
  `user_id` varchar(50) NOT NULL,
  `sales_person_id` varchar(50) DEFAULT NULL,
  `remarks` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `department`
--

CREATE TABLE `department` (
  `department_id` int(11) NOT NULL,
  `department_i` varchar(50) DEFAULT NULL,
  `department_name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `expenses`
--

CREATE TABLE `expenses` (
  `expense_id` int(11) NOT NULL,
  `expense_no` varchar(50) NOT NULL,
  `date_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `date` date NOT NULL,
  `amount` double NOT NULL DEFAULT '0',
  `description` varchar(100) DEFAULT NULL,
  `user_id` varchar(50) DEFAULT NULL,
  `category` varchar(50) NOT NULL DEFAULT 'NAN',
  `status` varchar(50) NOT NULL DEFAULT 'OPEN'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `finished_products`
--

CREATE TABLE `finished_products` (
  `id` int(11) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `description` varchar(100) NOT NULL,
  `qty` double NOT NULL DEFAULT '0',
  `production_id` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `fiscal_printer`
--

CREATE TABLE `fiscal_printer` (
  `till_no` varchar(50) NOT NULL,
  `operator_code` varchar(100) NOT NULL,
  `operator_password` varchar(100) NOT NULL,
  `port` varchar(50) DEFAULT NULL,
  `status` varchar(50) NOT NULL DEFAULT 'DISABLED'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `float_balance`
--

CREATE TABLE `float_balance` (
  `till_no` varchar(50) NOT NULL,
  `amount` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `goods_received_note`
--

CREATE TABLE `goods_received_note` (
  `grn_no` int(11) NOT NULL,
  `order_no` varchar(50) DEFAULT NULL,
  `invoice_no` varchar(50) DEFAULT NULL,
  `grn_date` date DEFAULT NULL,
  `amount` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `goods_received_note_particulars`
--

CREATE TABLE `goods_received_note_particulars` (
  `sn` int(11) NOT NULL,
  `grn_no` varchar(50) DEFAULT NULL,
  `item_code` varchar(50) NOT NULL,
  `qty` double NOT NULL,
  `unit_cost` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `sn` int(11) NOT NULL,
  `bar_code` varchar(50) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `description` varchar(100) NOT NULL,
  `short_description` varchar(100) NOT NULL,
  `pck` varchar(50) DEFAULT NULL,
  `cost_price` double NOT NULL,
  `selling_price` double NOT NULL,
  `discount` double DEFAULT NULL,
  `vat` double NOT NULL,
  `stock` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `inventorys`
--

CREATE TABLE `inventorys` (
  `sn` int(11) NOT NULL,
  `item_code` varchar(30) NOT NULL,
  `qty` double DEFAULT NULL,
  `min_inventory` double DEFAULT NULL,
  `max_inventory` double DEFAULT NULL,
  `def_reorder_qty` double DEFAULT NULL,
  `reorder_level` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `invoice_book`
--

CREATE TABLE `invoice_book` (
  `id` int(11) NOT NULL,
  `invoice_no` varchar(50) NOT NULL,
  `vendor_id` varchar(50) NOT NULL,
  `date` date NOT NULL,
  `total` double NOT NULL DEFAULT '0',
  `amount_paid` double NOT NULL DEFAULT '0',
  `amount_due` double NOT NULL DEFAULT '0',
  `status` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `items`
--

CREATE TABLE `items` (
  `sn` int(11) NOT NULL,
  `item_code` varchar(30) NOT NULL,
  `item_scan_code` varchar(30) DEFAULT NULL,
  `item_long_description` varchar(200) NOT NULL,
  `item_description` varchar(100) DEFAULT NULL,
  `pck` varchar(50) DEFAULT NULL,
  `department_id` varchar(10) DEFAULT NULL,
  `class_id` varchar(10) DEFAULT NULL,
  `sub_class_id` varchar(10) DEFAULT NULL,
  `supplier_id` varchar(30) DEFAULT NULL,
  `unit_cost_price` double DEFAULT NULL,
  `retail_price` double DEFAULT NULL,
  `discount` double NOT NULL DEFAULT '0',
  `vat` double NOT NULL DEFAULT '18',
  `margin` double DEFAULT NULL,
  `standard_uom` varchar(10) DEFAULT NULL,
  `active` tinyint(1) DEFAULT '1',
  `sellable` tinyint(1) NOT NULL DEFAULT '1',
  `image` blob COMMENT 'item image'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `items_to_convert`
--

CREATE TABLE `items_to_convert` (
  `id` int(11) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `description` varchar(200) NOT NULL,
  `qty` double NOT NULL,
  `price` double NOT NULL,
  `conversion_id` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `item_conversion`
--

CREATE TABLE `item_conversion` (
  `id` int(11) NOT NULL,
  `conversion_no` varchar(50) NOT NULL,
  `date` date NOT NULL,
  `reason` varchar(500) DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `user_id` varchar(50) DEFAULT NULL,
  `touch` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `item_list`
--

CREATE TABLE `item_list` (
  `sn` int(11) NOT NULL,
  `bar_code` varchar(50) DEFAULT NULL,
  `item_code` varchar(50) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `short_description` int(100) DEFAULT NULL,
  `vat` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `item_production`
--

CREATE TABLE `item_production` (
  `id` int(11) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `date` date NOT NULL,
  `time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `price` double NOT NULL,
  `qty` double NOT NULL,
  `balance` double NOT NULL,
  `reference` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `list_return_to_supplier`
--

CREATE TABLE `list_return_to_supplier` (
  `sn` int(11) NOT NULL,
  `lot_no` varchar(50) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `qty` double NOT NULL,
  `price` double NOT NULL,
  `reason` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `log`
--

CREATE TABLE `log` (
  `id` int(11) NOT NULL,
  `user_id` varchar(50) DEFAULT NULL,
  `date_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `activity` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `materials`
--

CREATE TABLE `materials` (
  `id` int(11) NOT NULL,
  `material_code` varchar(50) NOT NULL,
  `description` varchar(100) NOT NULL,
  `uom` varchar(50) NOT NULL,
  `qty` double NOT NULL DEFAULT '0',
  `price` double NOT NULL DEFAULT '0',
  `status` varchar(50) NOT NULL,
  `category_id` varchar(50) DEFAULT NULL,
  `touch` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `material_categories`
--

CREATE TABLE `material_categories` (
  `category_no` varchar(50) NOT NULL,
  `category_name` varchar(100) NOT NULL,
  `status` varchar(50) DEFAULT NULL,
  `id` int(11) NOT NULL,
  `touch` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `material_stock_cards`
--

CREATE TABLE `material_stock_cards` (
  `id` int(11) NOT NULL,
  `material_code` varchar(50) NOT NULL,
  `date` date NOT NULL,
  `time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `qty_in` double DEFAULT NULL,
  `qty_out` double DEFAULT NULL,
  `balance` double NOT NULL,
  `reference` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `material_usage`
--

CREATE TABLE `material_usage` (
  `id` int(11) NOT NULL,
  `material_code` varchar(50) NOT NULL,
  `date` date NOT NULL,
  `time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `price` double NOT NULL,
  `qty` double NOT NULL,
  `balance` double NOT NULL,
  `reference` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `order_id` int(11) NOT NULL,
  `order_no` varchar(50) NOT NULL,
  `order_date` date NOT NULL,
  `validity_period` int(11) NOT NULL,
  `valid_until` date DEFAULT NULL,
  `supplier_id` varchar(50) NOT NULL,
  `status` varchar(50) DEFAULT NULL,
  `user_id` varchar(50) NOT NULL,
  `touch` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `order_details`
--

CREATE TABLE `order_details` (
  `sn` int(11) NOT NULL,
  `order_no` varchar(50) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `quantity` double NOT NULL,
  `unit_cost_price` double NOT NULL,
  `stock_size` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `order_item`
--

CREATE TABLE `order_item` (
  `sn` int(11) NOT NULL,
  `order_no` varchar(50) NOT NULL,
  `item_code` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `packing_list`
--

CREATE TABLE `packing_list` (
  `id` int(11) NOT NULL,
  `issue_no` varchar(50) NOT NULL,
  `issue_date` date NOT NULL,
  `status` varchar(50) DEFAULT NULL,
  `sales_person_id` varchar(50) NOT NULL,
  `amount_issued` double DEFAULT NULL,
  `total_returns` double DEFAULT NULL,
  `total_damages` double DEFAULT NULL,
  `total_discounts` double DEFAULT NULL,
  `total_expenditures` double DEFAULT NULL,
  `total_bank_cash` double DEFAULT NULL,
  `debt` double DEFAULT NULL,
  `user_id` varchar(50) DEFAULT NULL,
  `float_amount` double DEFAULT NULL,
  `cost_of_goods` double NOT NULL DEFAULT '0',
  `customer_address` varchar(500) DEFAULT NULL,
  `touch` varchar(100) DEFAULT NULL,
  `customer_name` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `packing_list_details`
--

CREATE TABLE `packing_list_details` (
  `id` int(11) NOT NULL,
  `issue_no` varchar(50) NOT NULL,
  `barcode` varchar(50) DEFAULT NULL,
  `item_code` varchar(50) NOT NULL,
  `description` varchar(100) NOT NULL,
  `cprice` double DEFAULT NULL,
  `price` double NOT NULL,
  `returns` double DEFAULT NULL,
  `packed` double DEFAULT NULL,
  `qty_issued` double DEFAULT NULL,
  `qty_returned` double DEFAULT NULL,
  `qty_sold` double DEFAULT NULL,
  `qty_damaged` double DEFAULT NULL,
  `packing_list_id` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `payment`
--

CREATE TABLE `payment` (
  `sn` int(11) NOT NULL,
  `sale_id` varchar(50) NOT NULL,
  `cash` double NOT NULL DEFAULT '0',
  `voucher` double NOT NULL DEFAULT '0',
  `cheque` double NOT NULL DEFAULT '0',
  `deposit` double NOT NULL DEFAULT '0',
  `loyalty` double NOT NULL DEFAULT '0',
  `cr_card` double NOT NULL DEFAULT '0',
  `cap` double NOT NULL DEFAULT '0',
  `invoice` double NOT NULL DEFAULT '0',
  `cr_note` double NOT NULL DEFAULT '0',
  `mobile` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `petty_cash`
--

CREATE TABLE `petty_cash` (
  `sn` int(11) NOT NULL,
  `till_no` varchar(50) NOT NULL,
  `date_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `amount` double NOT NULL,
  `details` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `pos_printer`
--

CREATE TABLE `pos_printer` (
  `till_no` varchar(50) NOT NULL,
  `logical_name` varchar(100) DEFAULT NULL,
  `status` varchar(50) NOT NULL DEFAULT 'DISABLED'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `price_change`
--

CREATE TABLE `price_change` (
  `sn` int(11) NOT NULL,
  `item_code` varchar(50) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `date_time` timestamp NULL DEFAULT NULL,
  `original_price` double DEFAULT NULL,
  `new_price` double DEFAULT NULL,
  `change_descr` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `price_history`
--

CREATE TABLE `price_history` (
  `id` int(11) NOT NULL,
  `date` date DEFAULT NULL,
  `date_time` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `item_code` varchar(50) DEFAULT NULL,
  `old_price` double DEFAULT NULL,
  `new_price` double DEFAULT NULL,
  `user_id` varchar(50) DEFAULT NULL,
  `reason` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `productions`
--

CREATE TABLE `productions` (
  `id` int(11) NOT NULL,
  `production_no` varchar(50) NOT NULL,
  `product_name` varchar(100) NOT NULL,
  `batch_size` double DEFAULT NULL,
  `uom` varchar(50) NOT NULL,
  `status` varchar(50) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `touch` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `production_material`
--

CREATE TABLE `production_material` (
  `id` int(11) NOT NULL,
  `production_id` varchar(50) NOT NULL,
  `material_id` varchar(50) NOT NULL,
  `qty` double NOT NULL DEFAULT '0',
  `price` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `quotations`
--

CREATE TABLE `quotations` (
  `quotation_id` int(11) NOT NULL,
  `quotation_no` varchar(50) NOT NULL,
  `date_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `quotation_date` date NOT NULL,
  `status` varchar(50) DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `contact` varchar(50) DEFAULT NULL,
  `user_id` varchar(50) DEFAULT NULL,
  `amount` double NOT NULL DEFAULT '0',
  `customer_no` varchar(50) DEFAULT NULL,
  `touch` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `quotation_details`
--

CREATE TABLE `quotation_details` (
  `id` int(11) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `barcode` varchar(50) DEFAULT NULL,
  `description` varchar(50) NOT NULL,
  `qty` double NOT NULL DEFAULT '0',
  `price` double NOT NULL DEFAULT '0',
  `quotation_no` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `receipt`
--

CREATE TABLE `receipt` (
  `sn` int(11) NOT NULL,
  `bill_no` varchar(100) NOT NULL,
  `till_no` varchar(50) NOT NULL,
  `receipt_no` int(11) NOT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `refunds`
--

CREATE TABLE `refunds` (
  `sn` int(11) NOT NULL,
  `date` date NOT NULL,
  `amount` double NOT NULL,
  `cr_note_no` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `returned_goods`
--

CREATE TABLE `returned_goods` (
  `sn` int(11) NOT NULL,
  `bill_no` varchar(50) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `qty_returned` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `return_to_supplier`
--

CREATE TABLE `return_to_supplier` (
  `sn` int(11) NOT NULL,
  `lot_no` varchar(50) DEFAULT NULL,
  `supplier_code` varchar(50) NOT NULL,
  `return_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE `roles` (
  `id` int(11) NOT NULL,
  `role` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`id`, `role`) VALUES
(5, 'ADMIN'),
(4, 'CASHIER'),
(6, 'CHIEF CASHIER'),
(3, 'MANAGER'),
(2, 'PROCUREMENT');

-- --------------------------------------------------------

--
-- Table structure for table `role_priveledge`
--

CREATE TABLE `role_priveledge` (
  `id` int(11) NOT NULL,
  `role_id` varchar(50) NOT NULL,
  `priveledge` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `role_priveledge`
--

INSERT INTO `role_priveledge` (`id`, `role_id`, `priveledge`) VALUES
(29, '3', 'VIEW REPORTS'),
(30, '3', 'END DAY'),
(31, '3', 'ADMIN'),
(32, '5', 'ADMIN'),
(37, '3', 'DISCOUNT'),
(38, '3', 'PETTY CASH MANAGEMENT'),
(39, '3', 'CASH PICK UP'),
(40, '3', 'FLOAT MANAGEMENT'),
(41, '3', 'SPECIAL'),
(43, '4', 'SELLING'),
(44, '3', 'PRODUCT MANAGEMENT'),
(46, '5', 'VOID'),
(47, '3', 'VOID'),
(48, '4', 'VOID'),
(49, '6', 'VOID'),
(50, '2', 'VOID'),
(51, '3', 'SELLING'),
(53, '3', 'TILL MANAGEMENT'),
(54, '3', 'USER MANAGEMENT'),
(55, '3', 'ACCOUNTS'),
(56, '3', 'SUPPLIER MANAGEMENT'),
(57, '3', 'COMPANY MANAGEMENT'),
(58, '3', 'PRODUCT INQUIRY'),
(60, '3', 'PROCUREMENT'),
(61, '3', 'EDIT LPO'),
(62, '3', 'APPROVE LPO'),
(63, '3', 'SALE INVOICE'),
(66, '3', 'EDIT INVENTORY'),
(67, '3', 'CUSTOM DATING'),
(69, '3', 'ACCESS MANAGEMENT'),
(70, '5', 'PRODUCT MANAGEMENT'),
(71, '5', 'PRODUCT INQUIRY'),
(72, '5', 'EDIT INVENTORY'),
(73, '5', 'COMPANY MANAGEMENT'),
(74, '5', 'SUPPLIER MANAGEMENT'),
(75, '5', 'PROCUREMENT'),
(76, '5', 'VIEW REPORTS'),
(77, '5', 'ACCOUNTS'),
(78, '5', 'END DAY'),
(79, '5', 'USER MANAGEMENT'),
(80, '5', 'TILL MANAGEMENT'),
(81, '5', 'ACCESS MANAGEMENT'),
(82, '5', 'FLOAT MANAGEMENT'),
(83, '3', 'MANAGE SALES PERSONS'),
(84, '3', 'MANAGE MATERIALS'),
(85, '3', 'CREATE & CANCEL PACKING LIST'),
(87, '3', 'APPROVE PACKING LIST'),
(88, '3', 'PRINT PACKING LIST'),
(90, '3', 'ARCHIVE DOCUMENTS'),
(91, '3', 'VIEW PRODUCTION & SALES REPORTS'),
(92, '3', 'COMPLETE CUSTOMER CLAIM'),
(93, '3', 'PRINT CUSTOMER CLAIM'),
(94, '3', 'APPROVE CUSTOMER CLAIM'),
(95, '3', 'CREATE & CANCEL CUSTOMER CLAIM'),
(96, '3', 'COMPLETE STOCK CONVERSION'),
(97, '3', 'PRINT STOCK CONVERSION'),
(98, '3', 'APPROVE STOCK CONVERSION'),
(99, '3', 'CREATE & CANCEL STOCK CONVERSION'),
(100, '3', 'COMPLETE PRODUCTION'),
(101, '3', 'PRINT PRODUCTION'),
(102, '3', 'APPROVE PRODUCTION'),
(103, '3', 'CREATE & CANCEL PRODUCTION'),
(104, '3', 'RECEIVE DEBT'),
(105, '3', 'COMPLETE PACKING LIST'),
(106, '4', 'PRODUCT MANAGEMENT'),
(107, '4', 'PRODUCT MANAGEMENT'),
(108, '4', 'PRODUCT MANAGEMENT');

-- --------------------------------------------------------

--
-- Table structure for table `sale`
--

CREATE TABLE `sale` (
  `sn` int(11) NOT NULL,
  `id` varchar(50) DEFAULT NULL,
  `till_no` varchar(10) NOT NULL,
  `user_id` varchar(50) DEFAULT NULL,
  `date` date NOT NULL,
  `date_time` datetime NOT NULL,
  `amount` double NOT NULL,
  `discount` double NOT NULL,
  `vat` double NOT NULL,
  `tax_return` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `sales_invoices`
--

CREATE TABLE `sales_invoices` (
  `invoice_id` int(11) NOT NULL,
  `invoice_no` varchar(50) NOT NULL,
  `date_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `invoice_date` date NOT NULL,
  `status` varchar(50) DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `contact` varchar(50) DEFAULT NULL,
  `user_id` varchar(50) DEFAULT NULL,
  `amount` double NOT NULL DEFAULT '0',
  `customer_no` varchar(50) NOT NULL,
  `touch` varchar(100) DEFAULT NULL,
  `paid` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `sales_invoice_details`
--

CREATE TABLE `sales_invoice_details` (
  `id` int(11) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `barcode` varchar(50) DEFAULT NULL,
  `description` varchar(50) NOT NULL,
  `qty` double NOT NULL DEFAULT '1',
  `price` double NOT NULL DEFAULT '0',
  `invoice_no` varchar(50) NOT NULL,
  `cprice` double NOT NULL DEFAULT '0',
  `vat` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `sales_persons`
--

CREATE TABLE `sales_persons` (
  `id` int(11) NOT NULL,
  `roll_no` varchar(50) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `second_name` varchar(50) DEFAULT NULL,
  `last_name` varchar(50) NOT NULL,
  `full_name` varchar(100) NOT NULL,
  `invoice_limit` double DEFAULT NULL,
  `address` varchar(100) NOT NULL,
  `telephone` varchar(50) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `status` varchar(50) NOT NULL,
  `touch` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `sales_receipts`
--

CREATE TABLE `sales_receipts` (
  `receipt_id` int(11) NOT NULL,
  `receipt_no` varchar(50) NOT NULL,
  `date_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `receipt_date` date NOT NULL,
  `customer_no` varchar(50) NOT NULL,
  `payment_mode` varchar(50) NOT NULL DEFAULT 'OTHER',
  `amount` double NOT NULL DEFAULT '0',
  `comments` varchar(200) DEFAULT NULL,
  `allocated` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `sale_details`
--

CREATE TABLE `sale_details` (
  `sn` int(11) NOT NULL,
  `sale_id` varchar(50) DEFAULT NULL,
  `item_code` varchar(50) NOT NULL,
  `selling_price` double NOT NULL,
  `discounted_price` double NOT NULL,
  `qty` int(11) NOT NULL,
  `amount` double NOT NULL,
  `vat` double NOT NULL,
  `tax_return` double DEFAULT NULL,
  `cost_price` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `settings`
--

CREATE TABLE `settings` (
  `name` varchar(100) NOT NULL,
  `value` varchar(50) NOT NULL DEFAULT 'NAN'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `settings`
--

INSERT INTO `settings` (`name`, `value`) VALUES
('ALLOW_NEGATIVE_SALES', 'NO');

-- --------------------------------------------------------

--
-- Table structure for table `stock_cards`
--

CREATE TABLE `stock_cards` (
  `id` int(11) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `date` date NOT NULL,
  `time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `qty_in` double DEFAULT NULL,
  `qty_out` double DEFAULT NULL,
  `balance` double NOT NULL,
  `reference` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `sub_class`
--

CREATE TABLE `sub_class` (
  `sub_class_id` int(11) NOT NULL,
  `sub_class_i` varchar(50) NOT NULL,
  `sub_class_name` varchar(100) NOT NULL,
  `class_id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `supplier_id` int(11) NOT NULL,
  `supplier_code` varchar(50) NOT NULL,
  `supplier_name` varchar(100) NOT NULL,
  `address` varchar(100) DEFAULT NULL,
  `post_code` varchar(100) DEFAULT NULL,
  `physical_address` varchar(100) DEFAULT NULL,
  `contact_name` varchar(100) DEFAULT NULL,
  `bank_acc_name` varchar(100) DEFAULT NULL,
  `bank_acc_address` varchar(100) DEFAULT NULL,
  `bank_post_code` varchar(100) DEFAULT NULL,
  `bank_name` varchar(50) NOT NULL,
  `bank_acc_no` varchar(50) DEFAULT NULL,
  `telephone` varchar(50) DEFAULT NULL,
  `mob` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `fax` varchar(50) DEFAULT NULL,
  `tin` varchar(50) DEFAULT NULL,
  `vrn` varchar(50) DEFAULT NULL,
  `touch` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `supplier_credit_notes`
--

CREATE TABLE `supplier_credit_notes` (
  `sn` int(11) NOT NULL,
  `cr_no` varchar(50) NOT NULL,
  `cr_date` date NOT NULL,
  `cr_order_no` varchar(50) NOT NULL,
  `cr_amount` double NOT NULL,
  `status` varchar(50) NOT NULL,
  `cr_details` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `supplier_item`
--

CREATE TABLE `supplier_item` (
  `supplier_item_id` int(11) NOT NULL,
  `supplier_id` varchar(20) NOT NULL,
  `item_code` varchar(20) NOT NULL,
  `service_description` varchar(300) DEFAULT NULL,
  `vat_no` varchar(20) DEFAULT NULL,
  `packing` varchar(50) DEFAULT NULL,
  `cost_price_vat_incl` double DEFAULT NULL,
  `cost_price_vat_excl` double DEFAULT NULL,
  `terms_of_payment` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `till`
--

CREATE TABLE `till` (
  `till_no` varchar(50) NOT NULL,
  `computer_name` varchar(100) DEFAULT NULL,
  `status` varchar(50) NOT NULL DEFAULT 'DISABLED'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `till_total`
--

CREATE TABLE `till_total` (
  `till_no` varchar(50) NOT NULL,
  `cash` double NOT NULL DEFAULT '0',
  `voucher` double NOT NULL DEFAULT '0',
  `cheque` double NOT NULL DEFAULT '0',
  `deposit` double NOT NULL DEFAULT '0',
  `loyalty` double NOT NULL DEFAULT '0',
  `cr_card` double NOT NULL DEFAULT '0',
  `cap` double NOT NULL DEFAULT '0',
  `invoice` double NOT NULL DEFAULT '0',
  `cr_note` double NOT NULL DEFAULT '0',
  `mobile` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `first_name` varchar(50) DEFAULT NULL,
  `second_name` varchar(50) DEFAULT NULL,
  `last_name` varchar(50) DEFAULT NULL,
  `pay_roll_no` varchar(50) DEFAULT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(1000) NOT NULL,
  `biometric` blob,
  `role_id` varchar(50) DEFAULT NULL,
  `role` varchar(50) DEFAULT NULL,
  `alias` varchar(50) NOT NULL,
  `status` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `first_name`, `second_name`, `last_name`, `pay_roll_no`, `username`, `password`, `biometric`, `role_id`, `role`, `alias`, `status`) VALUES
(3, 'GODFREY', 'DESIDERY', 'SHIRIMA', '123456', 'username', 'Jrp5157a0o170Is368D12p6sNw934RZU77wIPxK6N%TW627o386G!Q02886k13r14EFY188pEBaI343d', NULL, '3', 'ADMIN', 'ALEXANDRA', 'ACTIVE'),
(5, 'JACOB', 'JOSEPHAT', 'PETER', '01', 'JACOB', '1OjD057c9617$FoNgw&B26GoJ783ZN87r7l5m7H668qTKGM0N8l0Xn#17u55FP6CYB4vDV7mB$X1Q4T3', NULL, '3', 'MANAGER', 'JACOB PETER - JACOB', 'ACTIVE');

-- --------------------------------------------------------

--
-- Table structure for table `void`
--

CREATE TABLE `void` (
  `id` int(11) NOT NULL,
  `user_id` varchar(50) DEFAULT NULL,
  `till_no` varchar(50) DEFAULT NULL,
  `item_code` varchar(50) DEFAULT NULL,
  `qty` double DEFAULT NULL,
  `sale_id` varchar(50) DEFAULT NULL,
  `authorizing_user_id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `allocations`
--
ALTER TABLE `allocations`
  ADD PRIMARY KEY (`allocation_id`),
  ADD UNIQUE KEY `allocation_no` (`allocation_no`);

--
-- Indexes for table `bar_codes`
--
ALTER TABLE `bar_codes`
  ADD PRIMARY KEY (`sn`),
  ADD UNIQUE KEY `bar_code` (`item_scan_code`);

--
-- Indexes for table `bill`
--
ALTER TABLE `bill`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `claim_details`
--
ALTER TABLE `claim_details`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `claim_replacement_details`
--
ALTER TABLE `claim_replacement_details`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `class`
--
ALTER TABLE `class`
  ADD PRIMARY KEY (`class_id`),
  ADD UNIQUE KEY `class_name` (`class_name`);

--
-- Indexes for table `collections`
--
ALTER TABLE `collections`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `company`
--
ALTER TABLE `company`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `converted`
--
ALTER TABLE `converted`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `corporate_customers`
--
ALTER TABLE `corporate_customers`
  ADD PRIMARY KEY (`customer_id`);

--
-- Indexes for table `credit_notes`
--
ALTER TABLE `credit_notes`
  ADD PRIMARY KEY (`sn`),
  ADD UNIQUE KEY `cr_note_no` (`cr_note_no`);

--
-- Indexes for table `credit_note_particulars`
--
ALTER TABLE `credit_note_particulars`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `cr_note`
--
ALTER TABLE `cr_note`
  ADD PRIMARY KEY (`sn`),
  ADD UNIQUE KEY `cr_no` (`cr_no`);

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`sn`),
  ADD UNIQUE KEY `customer_no` (`customer_no`);

--
-- Indexes for table `customer_claims`
--
ALTER TABLE `customer_claims`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `claim_no` (`claim_no`);

--
-- Indexes for table `customer_credit_notes`
--
ALTER TABLE `customer_credit_notes`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `cust_orders`
--
ALTER TABLE `cust_orders`
  ADD PRIMARY KEY (`order_no`);

--
-- Indexes for table `cust_order_details`
--
ALTER TABLE `cust_order_details`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `damages`
--
ALTER TABLE `damages`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `day_log`
--
ALTER TABLE `day_log`
  ADD PRIMARY KEY (`day_no`);

--
-- Indexes for table `debt_payment`
--
ALTER TABLE `debt_payment`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `department`
--
ALTER TABLE `department`
  ADD PRIMARY KEY (`department_id`),
  ADD UNIQUE KEY `department_name` (`department_name`) USING BTREE,
  ADD UNIQUE KEY `department_id` (`department_i`);

--
-- Indexes for table `expenses`
--
ALTER TABLE `expenses`
  ADD PRIMARY KEY (`expense_id`),
  ADD UNIQUE KEY `expense_no` (`expense_no`);

--
-- Indexes for table `finished_products`
--
ALTER TABLE `finished_products`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `float_balance`
--
ALTER TABLE `float_balance`
  ADD UNIQUE KEY `till_no` (`till_no`);

--
-- Indexes for table `goods_received_note`
--
ALTER TABLE `goods_received_note`
  ADD PRIMARY KEY (`grn_no`);

--
-- Indexes for table `goods_received_note_particulars`
--
ALTER TABLE `goods_received_note_particulars`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `inventorys`
--
ALTER TABLE `inventorys`
  ADD PRIMARY KEY (`sn`),
  ADD UNIQUE KEY `item_code` (`item_code`);

--
-- Indexes for table `invoice_book`
--
ALTER TABLE `invoice_book`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `items`
--
ALTER TABLE `items`
  ADD PRIMARY KEY (`sn`),
  ADD UNIQUE KEY `item_code` (`item_code`);

--
-- Indexes for table `items_to_convert`
--
ALTER TABLE `items_to_convert`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `item_conversion`
--
ALTER TABLE `item_conversion`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `item_list`
--
ALTER TABLE `item_list`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `item_production`
--
ALTER TABLE `item_production`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `list_return_to_supplier`
--
ALTER TABLE `list_return_to_supplier`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `materials`
--
ALTER TABLE `materials`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `material_code` (`material_code`),
  ADD UNIQUE KEY `description` (`description`);

--
-- Indexes for table `material_categories`
--
ALTER TABLE `material_categories`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `category_no` (`category_no`),
  ADD UNIQUE KEY `category_name` (`category_name`);

--
-- Indexes for table `material_stock_cards`
--
ALTER TABLE `material_stock_cards`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `material_usage`
--
ALTER TABLE `material_usage`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`order_id`),
  ADD UNIQUE KEY `order_no` (`order_no`);

--
-- Indexes for table `order_details`
--
ALTER TABLE `order_details`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `order_item`
--
ALTER TABLE `order_item`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `packing_list`
--
ALTER TABLE `packing_list`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `issue_no` (`issue_no`);

--
-- Indexes for table `packing_list_details`
--
ALTER TABLE `packing_list_details`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `payment`
--
ALTER TABLE `payment`
  ADD PRIMARY KEY (`sn`),
  ADD UNIQUE KEY `sale_id` (`sale_id`);

--
-- Indexes for table `petty_cash`
--
ALTER TABLE `petty_cash`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `price_change`
--
ALTER TABLE `price_change`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `price_history`
--
ALTER TABLE `price_history`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `productions`
--
ALTER TABLE `productions`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `production_no` (`production_no`);

--
-- Indexes for table `production_material`
--
ALTER TABLE `production_material`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `quotations`
--
ALTER TABLE `quotations`
  ADD PRIMARY KEY (`quotation_id`),
  ADD UNIQUE KEY `quotation_no` (`quotation_no`);

--
-- Indexes for table `quotation_details`
--
ALTER TABLE `quotation_details`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `receipt`
--
ALTER TABLE `receipt`
  ADD PRIMARY KEY (`sn`),
  ADD UNIQUE KEY `bill_no` (`bill_no`);

--
-- Indexes for table `refunds`
--
ALTER TABLE `refunds`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `returned_goods`
--
ALTER TABLE `returned_goods`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `return_to_supplier`
--
ALTER TABLE `return_to_supplier`
  ADD PRIMARY KEY (`sn`),
  ADD UNIQUE KEY `lot_no` (`lot_no`);

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `role` (`role`);

--
-- Indexes for table `role_priveledge`
--
ALTER TABLE `role_priveledge`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sale`
--
ALTER TABLE `sale`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `sales_invoices`
--
ALTER TABLE `sales_invoices`
  ADD PRIMARY KEY (`invoice_id`),
  ADD UNIQUE KEY `invoice_no` (`invoice_no`);

--
-- Indexes for table `sales_invoice_details`
--
ALTER TABLE `sales_invoice_details`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sales_persons`
--
ALTER TABLE `sales_persons`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sales_receipts`
--
ALTER TABLE `sales_receipts`
  ADD PRIMARY KEY (`receipt_id`),
  ADD UNIQUE KEY `receipt_no` (`receipt_no`);

--
-- Indexes for table `sale_details`
--
ALTER TABLE `sale_details`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `settings`
--
ALTER TABLE `settings`
  ADD UNIQUE KEY `name` (`name`);

--
-- Indexes for table `stock_cards`
--
ALTER TABLE `stock_cards`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sub_class`
--
ALTER TABLE `sub_class`
  ADD PRIMARY KEY (`sub_class_id`),
  ADD UNIQUE KEY `sub_class_name` (`sub_class_name`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`supplier_id`),
  ADD UNIQUE KEY `supplier_code` (`supplier_code`),
  ADD UNIQUE KEY `supplier_name` (`supplier_name`);

--
-- Indexes for table `supplier_credit_notes`
--
ALTER TABLE `supplier_credit_notes`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `supplier_item`
--
ALTER TABLE `supplier_item`
  ADD PRIMARY KEY (`supplier_item_id`);

--
-- Indexes for table `till`
--
ALTER TABLE `till`
  ADD PRIMARY KEY (`till_no`);

--
-- Indexes for table `till_total`
--
ALTER TABLE `till_total`
  ADD UNIQUE KEY `till_no` (`till_no`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `pay_roll_no` (`pay_roll_no`);

--
-- Indexes for table `void`
--
ALTER TABLE `void`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `allocations`
--
ALTER TABLE `allocations`
  MODIFY `allocation_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `bar_codes`
--
ALTER TABLE `bar_codes`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `bill`
--
ALTER TABLE `bill`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `cart`
--
ALTER TABLE `cart`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `claim_details`
--
ALTER TABLE `claim_details`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `claim_replacement_details`
--
ALTER TABLE `claim_replacement_details`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `class`
--
ALTER TABLE `class`
  MODIFY `class_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `collections`
--
ALTER TABLE `collections`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `company`
--
ALTER TABLE `company`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=101;

--
-- AUTO_INCREMENT for table `converted`
--
ALTER TABLE `converted`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `corporate_customers`
--
ALTER TABLE `corporate_customers`
  MODIFY `customer_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `credit_notes`
--
ALTER TABLE `credit_notes`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `credit_note_particulars`
--
ALTER TABLE `credit_note_particulars`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `cr_note`
--
ALTER TABLE `cr_note`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `customer_claims`
--
ALTER TABLE `customer_claims`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `customer_credit_notes`
--
ALTER TABLE `customer_credit_notes`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `cust_orders`
--
ALTER TABLE `cust_orders`
  MODIFY `order_no` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `cust_order_details`
--
ALTER TABLE `cust_order_details`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `damages`
--
ALTER TABLE `damages`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `day_log`
--
ALTER TABLE `day_log`
  MODIFY `day_no` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `debt_payment`
--
ALTER TABLE `debt_payment`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `department`
--
ALTER TABLE `department`
  MODIFY `department_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `expenses`
--
ALTER TABLE `expenses`
  MODIFY `expense_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `finished_products`
--
ALTER TABLE `finished_products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `goods_received_note`
--
ALTER TABLE `goods_received_note`
  MODIFY `grn_no` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `goods_received_note_particulars`
--
ALTER TABLE `goods_received_note_particulars`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `inventory`
--
ALTER TABLE `inventory`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `inventorys`
--
ALTER TABLE `inventorys`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `invoice_book`
--
ALTER TABLE `invoice_book`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `items`
--
ALTER TABLE `items`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `items_to_convert`
--
ALTER TABLE `items_to_convert`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `item_conversion`
--
ALTER TABLE `item_conversion`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `item_list`
--
ALTER TABLE `item_list`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `item_production`
--
ALTER TABLE `item_production`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `list_return_to_supplier`
--
ALTER TABLE `list_return_to_supplier`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `log`
--
ALTER TABLE `log`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `materials`
--
ALTER TABLE `materials`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `material_categories`
--
ALTER TABLE `material_categories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `material_stock_cards`
--
ALTER TABLE `material_stock_cards`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `material_usage`
--
ALTER TABLE `material_usage`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `order_details`
--
ALTER TABLE `order_details`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `order_item`
--
ALTER TABLE `order_item`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `packing_list`
--
ALTER TABLE `packing_list`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `packing_list_details`
--
ALTER TABLE `packing_list_details`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `payment`
--
ALTER TABLE `payment`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `petty_cash`
--
ALTER TABLE `petty_cash`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `price_change`
--
ALTER TABLE `price_change`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `price_history`
--
ALTER TABLE `price_history`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `productions`
--
ALTER TABLE `productions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `production_material`
--
ALTER TABLE `production_material`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `quotations`
--
ALTER TABLE `quotations`
  MODIFY `quotation_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `quotation_details`
--
ALTER TABLE `quotation_details`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `receipt`
--
ALTER TABLE `receipt`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `refunds`
--
ALTER TABLE `refunds`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `returned_goods`
--
ALTER TABLE `returned_goods`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `return_to_supplier`
--
ALTER TABLE `return_to_supplier`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `roles`
--
ALTER TABLE `roles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `role_priveledge`
--
ALTER TABLE `role_priveledge`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=109;

--
-- AUTO_INCREMENT for table `sale`
--
ALTER TABLE `sale`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sales_invoices`
--
ALTER TABLE `sales_invoices`
  MODIFY `invoice_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sales_invoice_details`
--
ALTER TABLE `sales_invoice_details`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sales_persons`
--
ALTER TABLE `sales_persons`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sales_receipts`
--
ALTER TABLE `sales_receipts`
  MODIFY `receipt_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sale_details`
--
ALTER TABLE `sale_details`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `stock_cards`
--
ALTER TABLE `stock_cards`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sub_class`
--
ALTER TABLE `sub_class`
  MODIFY `sub_class_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supplier`
--
ALTER TABLE `supplier`
  MODIFY `supplier_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supplier_credit_notes`
--
ALTER TABLE `supplier_credit_notes`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supplier_item`
--
ALTER TABLE `supplier_item`
  MODIFY `supplier_item_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `void`
--
ALTER TABLE `void`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
