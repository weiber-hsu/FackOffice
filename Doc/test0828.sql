/*
SQLyog Community
MySQL - 10.7.3-MariaDB-log : Database - test1
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


/*Table structure for table `borrow_fee` */

DROP TABLE IF EXISTS `borrow_fee`;

CREATE TABLE `borrow_fee` (
  `member_fk` int(11) NOT NULL COMMENT '會員pk',
  `pk` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键PK',
  `type` int(11) NOT NULL DEFAULT 1 COMMENT '业务类型 1.新合约 2.续期',
  `borrow_fee` decimal(12,2) NOT NULL COMMENT '管理费',
  `create_time` datetime DEFAULT NULL COMMENT '发生时间',
  PRIMARY KEY (`pk`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COMMENT='合约管理费纪录';

/*Table structure for table `member` */

DROP TABLE IF EXISTS `member`;

CREATE TABLE `member` (
  `agent_fk` int(11) unsigned DEFAULT 0 COMMENT '推荐人 PK',
  `pk` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '用户pk',
  `username` varchar(16) NOT NULL COMMENT '登入帐号',
  `invitation_code` varchar(7) DEFAULT NOT NULL COMMENT '属于会员专有的邀请码(7码)',
  `recommend` varchar(7) DEFAULT NULL COMMENT '注册画面填入的被邀请码(推荐人的邀请码)',
  `create_time` datetime NOT NULL COMMENT '注册时间',
  PRIMARY KEY (`pk`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
