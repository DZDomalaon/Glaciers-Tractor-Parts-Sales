CREATE DATABASE  IF NOT EXISTS `glaciers` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `glaciers`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: glaciers
-- ------------------------------------------------------
-- Server version	5.7.17-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer` (
  `CUSTOMER_ID` int(11) NOT NULL AUTO_INCREMENT,
  `BALANCE` int(11) DEFAULT NULL,
  `CREDIT_LIMIT` int(11) DEFAULT NULL,
  `CUSTOMER_PERSON_ID` int(11) NOT NULL,
  PRIMARY KEY (`CUSTOMER_ID`),
  KEY `fk_customer_person_idx` (`CUSTOMER_PERSON_ID`),
  CONSTRAINT `fk_customer_person` FOREIGN KEY (`CUSTOMER_PERSON_ID`) REFERENCES `person` (`PERSON_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (1,NULL,NULL,2);
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `delivery`
--

DROP TABLE IF EXISTS `delivery`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `delivery` (
  `DELIVER_ID` int(11) NOT NULL AUTO_INCREMENT,
  `DELIVER_STATUS` varchar(45) DEFAULT NULL,
  `DELIVER_PURCHASE_ID` int(11) NOT NULL,
  PRIMARY KEY (`DELIVER_ID`),
  KEY `fk_delivery report_purchase1_idx` (`DELIVER_PURCHASE_ID`),
  CONSTRAINT `fk_delivery report_purchase1` FOREIGN KEY (`DELIVER_PURCHASE_ID`) REFERENCES `purchase` (`PURCHASE_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `delivery`
--

LOCK TABLES `delivery` WRITE;
/*!40000 ALTER TABLE `delivery` DISABLE KEYS */;
/*!40000 ALTER TABLE `delivery` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employee` (
  `EMP_ID` int(11) NOT NULL AUTO_INCREMENT,
  `SHIFT` varchar(45) DEFAULT NULL,
  `SALARY` varchar(45) DEFAULT NULL,
  `DATE_HIRED` date DEFAULT NULL,
  `STATUS` varchar(20) DEFAULT NULL,
  `POSITION` varchar(20) DEFAULT NULL,
  `USERNAME` varchar(45) DEFAULT NULL,
  `PASSWORD` varchar(45) DEFAULT NULL,
  `EMP_PERSON_ID` int(11) NOT NULL,
  `TIME_IN` varchar(45) DEFAULT NULL,
  `TIME_OUT` varchar(45) DEFAULT NULL,
  `LOG_DATE` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`EMP_ID`),
  KEY `fk_employee_person1_idx` (`EMP_PERSON_ID`),
  CONSTRAINT `fk_employee_person1` FOREIGN KEY (`EMP_PERSON_ID`) REFERENCES `person` (`PERSON_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,NULL,NULL,'2017-12-28','ACTIVE',NULL,'dzdomalaon@addu.edu.ph','dzdomalaon@addu.edu.ph',1,NULL,NULL,NULL),(2,NULL,NULL,'2017-12-28','ACTIVE',NULL,'admin','admin',5,'16:26:12',NULL,'2017-12-28');
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory`
--

DROP TABLE IF EXISTS `inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inventory` (
  `PRODUCT_ID` int(11) NOT NULL AUTO_INCREMENT,
  `PRODUCT_NAME` varchar(45) DEFAULT NULL,
  `DESCRIPTION` varchar(45) DEFAULT NULL,
  `PRICE` decimal(5,2) DEFAULT NULL,
  `WARRANTY` varchar(45) DEFAULT NULL,
  `DISCOUNT` int(11) DEFAULT NULL,
  `SERIAL` varchar(45) DEFAULT NULL,
  `INVENTORY_CATALOGUE` int(11) DEFAULT NULL,
  PRIMARY KEY (`PRODUCT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
INSERT INTO `inventory` VALUES (1,'Ligid','sa puno',300.00,NULL,NULL,NULL,NULL),(2,'Ligid','sa Glacier Tractor',100.00,NULL,NULL,NULL,1),(3,'Screw','gamay',50.00,NULL,NULL,NULL,NULL),(5,'Bearing','na dako',600.00,NULL,NULL,NULL,0),(6,'bearing','na gamay',300.00,NULL,NULL,NULL,NULL),(7,'Spinner','Blue',450.00,NULL,NULL,NULL,NULL),(8,'Spinner','Red',450.00,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order` (
  `ORDER_ID` int(11) NOT NULL AUTO_INCREMENT,
  `ORDER_DATE` varchar(20) DEFAULT NULL,
  `ORDER_CUSTOMER_ID` int(11) NOT NULL,
  `ORDER_EMP_ID` int(11) NOT NULL,
  `ORDER_STATUS` varchar(45) DEFAULT NULL,
  `ORDER_PAYMENT_ID` int(11) NOT NULL,
  PRIMARY KEY (`ORDER_ID`),
  KEY `fk_order_customer1_idx` (`ORDER_CUSTOMER_ID`),
  KEY `fk_order_employee1_idx` (`ORDER_EMP_ID`),
  KEY `fk_order_payment1_idx` (`ORDER_PAYMENT_ID`),
  CONSTRAINT `fk_order_customer1` FOREIGN KEY (`ORDER_CUSTOMER_ID`) REFERENCES `customer` (`CUSTOMER_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_employee1` FOREIGN KEY (`ORDER_EMP_ID`) REFERENCES `employee` (`EMP_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_payment1` FOREIGN KEY (`ORDER_PAYMENT_ID`) REFERENCES `payment` (`PAYMENT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_line`
--

DROP TABLE IF EXISTS `order_line`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_line` (
  `ORDERLINE_ID` int(11) NOT NULL AUTO_INCREMENT,
  `OL_TOTAL_PRICE` int(11) DEFAULT NULL,
  `OL_SUBTOTAL` int(11) DEFAULT NULL,
  `OL_TOTAL_QUANTITY` int(11) DEFAULT NULL,
  `OL_ORDER_ID` int(11) DEFAULT NULL,
  `OL_PRODUCT_ID` int(11) NOT NULL,
  PRIMARY KEY (`ORDERLINE_ID`),
  KEY `fk_order_line_order1_idx` (`OL_ORDER_ID`),
  KEY `fk_order_line_product1_idx` (`OL_PRODUCT_ID`),
  CONSTRAINT `fk_order_line_order1` FOREIGN KEY (`OL_ORDER_ID`) REFERENCES `order` (`ORDER_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_line_product1` FOREIGN KEY (`OL_PRODUCT_ID`) REFERENCES `inventory` (`PRODUCT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_line`
--

LOCK TABLES `order_line` WRITE;
/*!40000 ALTER TABLE `order_line` DISABLE KEYS */;
/*!40000 ALTER TABLE `order_line` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment`
--

DROP TABLE IF EXISTS `payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payment` (
  `PAYMENT_ID` int(11) NOT NULL AUTO_INCREMENT,
  `AMOUNT` varchar(45) DEFAULT NULL,
  `PAYMENT_DATE` varchar(45) DEFAULT NULL,
  `TYPE` varchar(45) DEFAULT NULL,
  `INTEREST` varchar(4) DEFAULT NULL,
  `TERM` int(11) DEFAULT NULL,
  PRIMARY KEY (`PAYMENT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `person`
--

DROP TABLE IF EXISTS `person`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `person` (
  `PERSON_ID` int(11) NOT NULL AUTO_INCREMENT,
  `FIRSTNAME` varchar(45) DEFAULT NULL,
  `LASTNAME` varchar(45) DEFAULT NULL,
  `CONTACT_NUM` varchar(15) DEFAULT NULL,
  `EMAIL` varchar(64) DEFAULT NULL,
  `ADDRESS` varchar(64) DEFAULT NULL,
  `GENDER` int(11) DEFAULT NULL,
  `PERSON_TYPE` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`PERSON_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `person`
--

LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` VALUES (1,'Darell','Domalaon','09154843947','dzdomalaon@addu.edu.ph','SA PUSO NI CHYNNA',1,'EMPLOYEE'),(2,'Kristina','Pitoy','09154843947','mkopitoy@addu.edu.ph','SA PUSO NI RJ',0,'CUSTOMER'),(3,'Jusane','Bellezas','09154843947','jtsbellezas@addu.edu.ph','SA PUSO NI JJ',0,'SUPPLIER'),(4,'rj','mahinay','09474389111','admin','SA PUSO NI TINA',1,'ADMIN'),(5,'Kristina Tadesa','Domalaon','09154843947','admin','SA PUSO MO',1,'EMPLOYEE');
/*!40000 ALTER TABLE `person` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_catalogue`
--

DROP TABLE IF EXISTS `product_catalogue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_catalogue` (
  `PC_ID` int(11) NOT NULL,
  `PC_CATEGORY` varchar(45) DEFAULT NULL,
  `PC_VARIANT` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`PC_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_catalogue`
--

LOCK TABLES `product_catalogue` WRITE;
/*!40000 ALTER TABLE `product_catalogue` DISABLE KEYS */;
INSERT INTO `product_catalogue` VALUES (0,'DAKO',NULL),(1,'DAKO','RUBBER');
/*!40000 ALTER TABLE `product_catalogue` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_has_supplier`
--

DROP TABLE IF EXISTS `product_has_supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_has_supplier` (
  `product_PRODUCT_ID` int(11) NOT NULL,
  `supplier_SUPPLIER_ID` int(11) NOT NULL,
  KEY `fk_product_has_supplier_supplier1_idx` (`supplier_SUPPLIER_ID`),
  KEY `fk_product_has_supplier_product1_idx` (`product_PRODUCT_ID`),
  CONSTRAINT `fk_product_has_supplier_product1` FOREIGN KEY (`product_PRODUCT_ID`) REFERENCES `inventory` (`PRODUCT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_product_has_supplier_supplier1` FOREIGN KEY (`supplier_SUPPLIER_ID`) REFERENCES `supplier` (`SUPPLIER_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_has_supplier`
--

LOCK TABLES `product_has_supplier` WRITE;
/*!40000 ALTER TABLE `product_has_supplier` DISABLE KEYS */;
/*!40000 ALTER TABLE `product_has_supplier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase`
--

DROP TABLE IF EXISTS `purchase`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purchase` (
  `PURCHASE_ID` int(11) NOT NULL AUTO_INCREMENT,
  `PURCHASE_SUPPLIER_ID` int(11) NOT NULL,
  `PURCHASE_EMP_ID` int(11) NOT NULL,
  `PURCHASE_DATE` date DEFAULT NULL,
  `PRODUCT_NAME` varchar(45) DEFAULT NULL,
  `QUANTITY` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`PURCHASE_ID`),
  KEY `fk_purchase_supplier1_idx` (`PURCHASE_SUPPLIER_ID`),
  KEY `fk_purchase_employee1_idx` (`PURCHASE_EMP_ID`),
  CONSTRAINT `fk_purchase_employee1` FOREIGN KEY (`PURCHASE_EMP_ID`) REFERENCES `employee` (`EMP_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_purchase_supplier1` FOREIGN KEY (`PURCHASE_SUPPLIER_ID`) REFERENCES `supplier` (`SUPPLIER_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase`
--

LOCK TABLES `purchase` WRITE;
/*!40000 ALTER TABLE `purchase` DISABLE KEYS */;
/*!40000 ALTER TABLE `purchase` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock_in`
--

DROP TABLE IF EXISTS `stock_in`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stock_in` (
  `SI_ID` int(11) NOT NULL AUTO_INCREMENT,
  `SI_PRDUCT` varchar(45) DEFAULT NULL,
  `SI_QUANTITY` int(11) DEFAULT NULL,
  PRIMARY KEY (`SI_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock_in`
--

LOCK TABLES `stock_in` WRITE;
/*!40000 ALTER TABLE `stock_in` DISABLE KEYS */;
/*!40000 ALTER TABLE `stock_in` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock_in_has_inventory`
--

DROP TABLE IF EXISTS `stock_in_has_inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stock_in_has_inventory` (
  `stock_in_SI_ID` int(11) NOT NULL,
  `Inventory_PRODUCT_ID` int(11) NOT NULL,
  PRIMARY KEY (`stock_in_SI_ID`,`Inventory_PRODUCT_ID`),
  KEY `fk_stock_in_has_Inventory_Inventory1_idx` (`Inventory_PRODUCT_ID`),
  KEY `fk_stock_in_has_Inventory_stock_in1_idx` (`stock_in_SI_ID`),
  CONSTRAINT `fk_stock_in_has_Inventory_Inventory1` FOREIGN KEY (`Inventory_PRODUCT_ID`) REFERENCES `inventory` (`PRODUCT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_stock_in_has_Inventory_stock_in1` FOREIGN KEY (`stock_in_SI_ID`) REFERENCES `stock_in` (`SI_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock_in_has_inventory`
--

LOCK TABLES `stock_in_has_inventory` WRITE;
/*!40000 ALTER TABLE `stock_in_has_inventory` DISABLE KEYS */;
/*!40000 ALTER TABLE `stock_in_has_inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `supplier` (
  `SUPPLIER_ID` int(11) NOT NULL AUTO_INCREMENT,
  `CONTACT_PERSON` varchar(45) DEFAULT NULL,
  `ORGANIZATION` varchar(45) DEFAULT NULL,
  `SUPPLIER_PERSON_ID` int(11) NOT NULL,
  PRIMARY KEY (`SUPPLIER_ID`),
  KEY `fk_supplier_person1_idx` (`SUPPLIER_PERSON_ID`),
  CONSTRAINT `fk_supplier_person1` FOREIGN KEY (`SUPPLIER_PERSON_ID`) REFERENCES `person` (`PERSON_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier`
--

LOCK TABLES `supplier` WRITE;
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
INSERT INTO `supplier` VALUES (1,'Jusane Bellezas',NULL,3);
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-12-29 15:29:58
