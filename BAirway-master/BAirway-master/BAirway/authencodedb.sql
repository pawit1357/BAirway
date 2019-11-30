-- phpMyAdmin SQL Dump
-- version 2.10.3
-- http://www.phpmyadmin.net
-- 
-- Host: localhost
-- Generation Time: Sep 06, 2013 at 03:08 AM
-- Server version: 5.0.51
-- PHP Version: 5.2.6

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

-- 
-- Database: `authencodedb`
-- 

-- --------------------------------------------------------

-- 
-- Table structure for table `tb_authen_code`
-- 

CREATE TABLE `tb_authen_code` (
  `id` int(11) NOT NULL auto_increment,
  `ath_name` varchar(200) default NULL,
  `ath_pass` varchar(200) default NULL,
  `createdate` datetime default NULL,
  `ath_use` char(1) default '0',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=10 ;

-- 
-- Dumping data for table `tb_authen_code`
-- 

INSERT INTO `tb_authen_code` VALUES (1, 'user1', '1234', '2013-09-05 23:51:20', '1');
INSERT INTO `tb_authen_code` VALUES (2, 'user2', '1234', '2013-09-05 23:51:20', '1');
INSERT INTO `tb_authen_code` VALUES (3, 'user3', '1234', '2013-09-05 23:51:20', '1');
INSERT INTO `tb_authen_code` VALUES (4, 'user4', '1234', '2013-09-05 23:51:20', '1');
INSERT INTO `tb_authen_code` VALUES (5, 'user5', '1234', '2013-09-05 23:51:20', '1');
INSERT INTO `tb_authen_code` VALUES (6, 'user6', '1234', '2013-09-05 23:51:20', '1');
INSERT INTO `tb_authen_code` VALUES (7, 'user7', '1234', '2013-09-05 23:51:20', '0');
INSERT INTO `tb_authen_code` VALUES (8, 'user8', '1234', '2013-09-05 23:51:20', '0');
INSERT INTO `tb_authen_code` VALUES (9, 'user9', '1234', '2013-09-05 23:51:20', '0');

-- --------------------------------------------------------

-- 
-- Table structure for table `tb_staff`
-- 

CREATE TABLE `tb_staff` (
  `id` int(11) NOT NULL auto_increment,
  `staff_name` varchar(45) default NULL,
  `staff_pass` varchar(45) default NULL,
  `staff_site` int(11) default NULL,
  `createdate` datetime default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- 
-- Dumping data for table `tb_staff`
-- 


-- --------------------------------------------------------

-- 
-- Table structure for table `tb_transaction`
-- 

CREATE TABLE `tb_transaction` (
  `id` int(11) NOT NULL auto_increment,
  `group_id` varchar(45) default NULL,
  `passenger_name` varchar(200) default NULL,
  `from_city` varchar(45) default NULL,
  `to_city` varchar(45) default NULL,
  `airline_code` varchar(45) default NULL,
  `flight_no` varchar(45) default NULL,
  `date_of_flight` varchar(45) default NULL,
  `seat_no` int(11) default NULL,
  `remark` varchar(45) default NULL,
  `remakr2` varchar(45) default NULL,
  `ath_id` int(11) default NULL,
  `gen_by_staff_id` int(11) default NULL,
  `createdate` datetime default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=21 ;

-- 
-- Dumping data for table `tb_transaction`
-- 

INSERT INTO `tb_transaction` VALUES (19, '1', 'PAWIT S.', 'Trang', 'Bangkok', '12101', 'TG001', '2013-09-06 00:48:29.017', 19, '-', '-', 5, 0, '0001-01-01 00:00:00');
