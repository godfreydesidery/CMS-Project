-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 01, 2021 at 01:17 PM
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
  `till_no` varchar(50) DEFAULT NULL,
  `bar_code` varchar(50) DEFAULT NULL,
  `item_code` varchar(50) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `price` varchar(50) DEFAULT NULL,
  `vat` varchar(50) DEFAULT NULL,
  `discount` varchar(50) DEFAULT NULL,
  `qty` varchar(50) DEFAULT NULL,
  `amount` varchar(50) DEFAULT NULL,
  `sn` varchar(100) DEFAULT NULL,
  `void` varchar(50) NOT NULL DEFAULT 'NO',
  `short_description` varchar(100) DEFAULT NULL
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
  `logo` mediumblob
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
  `received_by` varchar(100) DEFAULT NULL
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
  `stock` int(11) NOT NULL,
  `vat` double NOT NULL
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
  `active` tinyint(1) DEFAULT '1'
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
  `user_id` varchar(50) DEFAULT NULL
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
  `category_id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `material_categories`
--

CREATE TABLE `material_categories` (
  `category_no` varchar(50) NOT NULL,
  `category_name` varchar(100) NOT NULL,
  `status` varchar(50) DEFAULT NULL,
  `id` int(11) NOT NULL
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
  `user_id` varchar(50) NOT NULL
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
  `cost_of_goods` double NOT NULL DEFAULT '0'
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
  `date` date DEFAULT NULL
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
(66, '3', 'EDIT INVENTORY');

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
  `status` varchar(50) NOT NULL
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
  `tax_return` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `sale_invoices`
--

CREATE TABLE `sale_invoices` (
  `invoice_id` int(11) NOT NULL,
  `invoice_no` varchar(50) NOT NULL,
  `date_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `invoice_date` date NOT NULL,
  `status` varchar(50) DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  `contact` varchar(50) NOT NULL,
  `user_id` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `sale_invoice_details`
--

CREATE TABLE `sale_invoice_details` (
  `sn` int(11) NOT NULL,
  `invoice_no` varchar(50) NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `barcode` varchar(50) DEFAULT NULL,
  `description` varchar(50) NOT NULL,
  `quantity` int(11) NOT NULL,
  `quantity_returned` int(11) NOT NULL,
  `quantity_sold` int(11) NOT NULL,
  `quantity_due` int(11) NOT NULL,
  `cost_price` double NOT NULL,
  `selling_price` double NOT NULL,
  `discount` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
  `vrn` varchar(50) DEFAULT NULL
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
  ADD PRIMARY KEY (`id`);

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
-- Indexes for table `sales_persons`
--
ALTER TABLE `sales_persons`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sale_details`
--
ALTER TABLE `sale_details`
  ADD PRIMARY KEY (`sn`);

--
-- Indexes for table `sale_invoices`
--
ALTER TABLE `sale_invoices`
  ADD PRIMARY KEY (`invoice_id`);

--
-- Indexes for table `sale_invoice_details`
--
ALTER TABLE `sale_invoice_details`
  ADD PRIMARY KEY (`sn`);

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
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `converted`
--
ALTER TABLE `converted`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `role_priveledge`
--
ALTER TABLE `role_priveledge`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=67;

--
-- AUTO_INCREMENT for table `sale`
--
ALTER TABLE `sale`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sales_persons`
--
ALTER TABLE `sales_persons`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sale_details`
--
ALTER TABLE `sale_details`
  MODIFY `sn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sale_invoices`
--
ALTER TABLE `sale_invoices`
  MODIFY `invoice_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sale_invoice_details`
--
ALTER TABLE `sale_invoice_details`
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
