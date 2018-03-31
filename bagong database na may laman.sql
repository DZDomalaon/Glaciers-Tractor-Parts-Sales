-- MySQL dump 10.13  Distrib 5.7.19, for Win64 (x86_64)
--
-- Host: localhost    Database: glaciers
-- ------------------------------------------------------
-- Server version	5.7.19-log

create database glaciers;
use glaciers;

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (1,700,NULL,2),(2,200,5000,8);
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `damaged_items`
--

DROP TABLE IF EXISTS `damaged_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `damaged_items` (
  `DI_ID` int(11) NOT NULL AUTO_INCREMENT,
  `DI_QUANTITY` int(11) DEFAULT NULL,
  `DI_DATE` varchar(45) DEFAULT NULL,
  `product_PRODUCT_ID` int(11) NOT NULL,
  `inventory_INVENTORY_ID` int(11) NOT NULL,
  PRIMARY KEY (`DI_ID`),
  KEY `fk_damaged_items_product1_idx` (`product_PRODUCT_ID`),
  KEY `fk_damaged_items_inventory1_idx` (`inventory_INVENTORY_ID`),
  CONSTRAINT `fk_damaged_items_inventory1` FOREIGN KEY (`inventory_INVENTORY_ID`) REFERENCES `inventory` (`INVENTORY_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_damaged_items_product1` FOREIGN KEY (`product_PRODUCT_ID`) REFERENCES `product` (`PRODUCT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `damaged_items`
--

LOCK TABLES `damaged_items` WRITE;
/*!40000 ALTER TABLE `damaged_items` DISABLE KEYS */;
INSERT INTO `damaged_items` VALUES (1,4,'2018-03-21',3,2),(3,3,'2018-03-21',2,1),(4,5,'2018-03-21',3,2),(5,4,'2018-03-21',2,1),(6,4,'2018-03-21',3,2),(7,4,'2018-03-21',2,1),(8,4,'2018-03-21',3,2);
/*!40000 ALTER TABLE `damaged_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `delivery`
--

DROP TABLE IF EXISTS `delivery`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `delivery` (
  `DELIVERY_ID` int(11) NOT NULL,
  `PRODUCT_NAME` varchar(45) DEFAULT NULL,
  `TOTAL_QUANTITY` int(11) DEFAULT NULL,
  `DELIVERY_DATE` varchar(45) DEFAULT NULL,
  `RECEIVER` varchar(45) DEFAULT NULL,
  `CARRIER` varchar(45) DEFAULT NULL,
  `DELIVERY_PURCHASE_ID` int(11) NOT NULL,
  PRIMARY KEY (`DELIVERY_ID`),
  KEY `fk_Delivery_purchase1_idx` (`DELIVERY_PURCHASE_ID`),
  CONSTRAINT `fk_Delivery_purchase1` FOREIGN KEY (`DELIVERY_PURCHASE_ID`) REFERENCES `purchase` (`PURCHASE_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
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
  `DATE_HIRED` date DEFAULT NULL,
  `POSITION` varchar(20) DEFAULT NULL,
  `STATUS` varchar(20) DEFAULT NULL,
  `USERNAME` varchar(45) DEFAULT NULL,
  `PASSWORD` varchar(45) DEFAULT NULL,
  `EMP_PERSON_ID` int(11) NOT NULL,
  PRIMARY KEY (`EMP_ID`),
  KEY `fk_staff_person1_idx` (`EMP_PERSON_ID`),
  CONSTRAINT `fk_staff_person1` FOREIGN KEY (`EMP_PERSON_ID`) REFERENCES `person` (`PERSON_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,'2018-03-19','Admin','Active','admin','admin',1),(2,'2018-03-21','Employee','Active','ayabyuso@addu.edu.ph','ayabyuso@addu.edu.ph',6);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory`
--

DROP TABLE IF EXISTS `inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inventory` (
  `INVENTORY_ID` int(11) NOT NULL AUTO_INCREMENT,
  `QUANTITY` int(11) DEFAULT NULL,
  `INV_PRODUCT_ID` int(11) NOT NULL,
  PRIMARY KEY (`INVENTORY_ID`),
  KEY `fk_inventory_product1_idx` (`INV_PRODUCT_ID`),
  CONSTRAINT `fk_inventory_product1` FOREIGN KEY (`INV_PRODUCT_ID`) REFERENCES `product` (`PRODUCT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
INSERT INTO `inventory` VALUES (1,2,2),(2,3,3),(3,5,4),(4,5,5);
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment`
--

DROP TABLE IF EXISTS `payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payment` (
  `PAYMENT_ID` int(11) NOT NULL AUTO_INCREMENT,
  `AMOUNT` double DEFAULT NULL,
  `PAYMENT_DATE` date DEFAULT NULL,
  `TYPE` varchar(45) DEFAULT NULL,
  `TERM` date DEFAULT NULL,
  PRIMARY KEY (`PAYMENT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment` VALUES (2,400,'2018-03-31','Cash',NULL),(3,400,'2018-03-31','Credit','2018-04-30'),(4,200,'2018-03-31','Credit','2018-04-30'),(5,300,'2018-03-31','Credit','2018-04-30'),(6,1000,'2018-04-01','Cash',NULL),(7,0,'2018-04-01','Credit','2018-05-31'),(8,0,'2018-04-01','Credit','2018-05-31');
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `person`
--

LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` VALUES (1,'Darell','Domalaon',' 915-484-3947','dzdomalaon@addu.edu.ph','SA PUSO NG ECOLAND',1,'EMPLOYEE'),(2,'Kristina','Pitoy',' 915-484-3947','mkopitoy@addu.edu.ph','SA PUSO NI RJ',0,'CUSTOMER'),(3,'Jusane','Bellezas','09154843947','jtsbellezas@addu.edu.ph','SA PUSO NG JOLLIBEE',0,'SUPPLIER'),(4,'Susan','Salutan',' 915-484-3947','ssalutan@addu.edu.ph','Guererro, Buhangin',0,'Supplier'),(5,'Artemio','Bellezas',' 915-484-3947','artbellezas@addu.edu.ph','NHA, BUHANGIN',1,'Supplier'),(6,'Ira','Ybiernas',' 915-484-3947','ayabyuso@addu.edu.ph','Mintal',1,'Employee'),(7,'Regee','Bellezas',' 915-484-3947','rsbellezas@addu.edu.ph','Guererro, Buhangin',1,'Supplier'),(8,'Robert Joseph','Mahinay',' 915-484-3947','rjmahinay@addu.edu.ph','Puan, Davao City',1,'Customer');
/*!40000 ALTER TABLE `person` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product` (
  `PRODUCT_ID` int(11) NOT NULL AUTO_INCREMENT,
  `PRODUCT_NAME` varchar(45) NOT NULL,
  `DESCRIPTION` varchar(45) DEFAULT NULL,
  `PRICE` decimal(5,2) DEFAULT NULL,
  `DISCOUNT` varchar(45) DEFAULT NULL,
  `SERIAL` varchar(45) DEFAULT NULL,
  `PRODUCT_PC_ID` int(11) NOT NULL,
  PRIMARY KEY (`PRODUCT_ID`),
  KEY `fk_product_product_catalogue1_idx` (`PRODUCT_PC_ID`),
  CONSTRAINT `fk_product_product_catalogue1` FOREIGN KEY (`PRODUCT_PC_ID`) REFERENCES `product_catalogue` (`PC_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (2,'ligid','gamay',100.00,NULL,'4140989123571',2),(3,'ligid1','dako',200.00,NULL,'7412471929044',3),(4,'bearing','blue',500.00,'50','8084028400245',2),(5,'wrench','pula',120.00,'20','5346346342425',3);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_catalogue`
--

DROP TABLE IF EXISTS `product_catalogue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_catalogue` (
  `PC_ID` int(11) NOT NULL AUTO_INCREMENT,
  `PC_CATEGORY` varchar(45) DEFAULT NULL,
  `PC_VARIANT` varchar(45) DEFAULT NULL,
  `PC_TYPE` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`PC_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_catalogue`
--

LOCK TABLES `product_catalogue` WRITE;
/*!40000 ALTER TABLE `product_catalogue` DISABLE KEYS */;
INSERT INTO `product_catalogue` VALUES (2,'wheel','color','black'),(3,'wheel','color','black');
/*!40000 ALTER TABLE `product_catalogue` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_has_supplier`
--

DROP TABLE IF EXISTS `product_has_supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_has_supplier` (
  `PHS_PRODUCT_ID` int(11) NOT NULL,
  `PHS_SUPPLIER_ID` int(11) NOT NULL,
  KEY `fk_product_has_supplier_supplier1_idx` (`PHS_SUPPLIER_ID`),
  KEY `fk_product_has_supplier_product1_idx` (`PHS_PRODUCT_ID`),
  CONSTRAINT `fk_product_has_supplier_product1` FOREIGN KEY (`PHS_PRODUCT_ID`) REFERENCES `product` (`PRODUCT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_product_has_supplier_supplier1` FOREIGN KEY (`PHS_SUPPLIER_ID`) REFERENCES `supplier` (`SUPPLIER_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_has_supplier`
--

LOCK TABLES `product_has_supplier` WRITE;
/*!40000 ALTER TABLE `product_has_supplier` DISABLE KEYS */;
INSERT INTO `product_has_supplier` VALUES (2,1),(3,1),(4,2),(5,3);
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
  `PURCHASE_DATE` varchar(45) DEFAULT NULL,
  `STATUS` varchar(45) DEFAULT NULL,
  `PURCHASE_EMP_ID` int(11) NOT NULL,
  `PURCHASE_SUPPLIER_ID` int(11) NOT NULL,
  PRIMARY KEY (`PURCHASE_ID`),
  KEY `fk_purchase_supplier1_idx` (`PURCHASE_SUPPLIER_ID`),
  KEY `fk_purchase_staff1_idx` (`PURCHASE_EMP_ID`),
  CONSTRAINT `fk_purchase_staff1` FOREIGN KEY (`PURCHASE_EMP_ID`) REFERENCES `employee` (`EMP_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
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
-- Table structure for table `purchase_details`
--

DROP TABLE IF EXISTS `purchase_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purchase_details` (
  `PRODUCT_NAME` varchar(45) NOT NULL,
  `PRODUCT_UNIT_PRICE` double DEFAULT NULL,
  `PURCHASE_TOTAL` double DEFAULT NULL,
  `PURCHASE_SUBTOTAL` double DEFAULT NULL,
  `PURCHASE_TQUANTITY` int(11) DEFAULT NULL,
  `PURCHASE_SUBQUANTITY` int(11) DEFAULT NULL,
  `PROD_CATEGORY` varchar(45) DEFAULT NULL,
  `PROD_VARIANT` varchar(45) DEFAULT NULL,
  `PROD_TYPE` varchar(45) DEFAULT NULL,
  `PD_PURCHASE_ID` int(11) NOT NULL,
  KEY `fk_purchase_details_purchase1_idx` (`PD_PURCHASE_ID`),
  CONSTRAINT `fk_purchase_details_purchase1` FOREIGN KEY (`PD_PURCHASE_ID`) REFERENCES `purchase` (`PURCHASE_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_details`
--

LOCK TABLES `purchase_details` WRITE;
/*!40000 ALTER TABLE `purchase_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `purchase_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sales_order`
--

DROP TABLE IF EXISTS `sales_order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sales_order` (
  `ORDER_ID` int(11) NOT NULL AUTO_INCREMENT,
  `PAYMENT_CHANGE` double DEFAULT NULL,
  `ORDER_DATE` varchar(45) DEFAULT NULL,
  `ORDER_TQUANTITY` int(11) DEFAULT NULL,
  `ORDER_TOTAL` double DEFAULT NULL,
  `ORDER_STATUS` varchar(45) DEFAULT NULL,
  `ORDER_BALANCE` double DEFAULT NULL,
  `ORDER_CUSTOMER_ID` int(11) NOT NULL,
  `ORDER_EMP_ID` int(11) NOT NULL,
  `ORDER_PAYMENT_ID` int(11) NOT NULL,
  PRIMARY KEY (`ORDER_ID`),
  KEY `fk_order_customer1_idx` (`ORDER_CUSTOMER_ID`),
  KEY `fk_order_staff1_idx` (`ORDER_EMP_ID`),
  KEY `fk_order_payment1_idx` (`ORDER_PAYMENT_ID`),
  CONSTRAINT `fk_order_customer1` FOREIGN KEY (`ORDER_CUSTOMER_ID`) REFERENCES `customer` (`CUSTOMER_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_payment1` FOREIGN KEY (`ORDER_PAYMENT_ID`) REFERENCES `payment` (`PAYMENT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_staff1` FOREIGN KEY (`ORDER_EMP_ID`) REFERENCES `employee` (`EMP_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_order`
--

LOCK TABLES `sales_order` WRITE;
/*!40000 ALTER TABLE `sales_order` DISABLE KEYS */;
INSERT INTO `sales_order` VALUES (2,0,'2018-03-31',2,400,'Paid',NULL,1,1,2),(3,NULL,'2018-03-31',3,600,'Unpaid',200,2,1,3),(4,NULL,'2018-03-31',2,200,'Paid',0,2,1,4),(5,NULL,'2018-03-31',3,300,'Paid',0,1,1,5),(6,154,'2018-04-01',4,846,'Paid',NULL,2,1,6),(7,NULL,'2018-04-01',2,400,'Unpaid',400,1,1,7),(8,NULL,'2018-04-01',3,300,'Unpaid',300,1,1,8);
/*!40000 ALTER TABLE `sales_order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sales_order_details`
--

DROP TABLE IF EXISTS `sales_order_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sales_order_details` (
  `ORDER_PRODUCT_ID` int(11) NOT NULL,
  `ORDER_UNIT_PRICE` double NOT NULL,
  `PRODUCT_DISCOUNT` int(11) DEFAULT NULL,
  `ORDER_SUBTOTAL` double DEFAULT NULL,
  `ORDER_SUBQUANTITY` int(11) DEFAULT NULL,
  `ORDER_SERIAL_NO` varchar(45) DEFAULT NULL,
  `SO_ID` int(11) NOT NULL,
  KEY `fk_sales_order_details_product1_idx` (`ORDER_PRODUCT_ID`),
  KEY `fk_sales_order_details_sales_order1_idx` (`SO_ID`),
  CONSTRAINT `fk_sales_order_details_product1` FOREIGN KEY (`ORDER_PRODUCT_ID`) REFERENCES `product` (`PRODUCT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_sales_order_details_sales_order1` FOREIGN KEY (`SO_ID`) REFERENCES `sales_order` (`ORDER_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_order_details`
--

LOCK TABLES `sales_order_details` WRITE;
/*!40000 ALTER TABLE `sales_order_details` DISABLE KEYS */;
INSERT INTO `sales_order_details` VALUES (3,200,0,400,2,'7412471929044',2),(3,200,0,600,3,'7412471929044',3),(2,100,0,200,2,'4140989123571',4),(2,100,0,300,3,'4140989123571',5),(5,120,20,96,1,'5346346342425',6),(4,500,50,750,3,'8084028400245',6),(3,200,0,400,2,'7412471929044',7),(2,100,0,300,3,'4140989123571',8);
/*!40000 ALTER TABLE `sales_order_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock_in`
--

DROP TABLE IF EXISTS `stock_in`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stock_in` (
  `SI_ID` int(11) NOT NULL AUTO_INCREMENT,
  `SI_QUANTITY` int(11) DEFAULT NULL,
  `SI_DATE` varchar(45) DEFAULT NULL,
  `SI_PRODUCT_ID` int(11) NOT NULL,
  `SI_INVENTORY_ID` int(11) NOT NULL,
  PRIMARY KEY (`SI_ID`),
  KEY `fk_stock_in_Product1_idx` (`SI_PRODUCT_ID`),
  KEY `fk_stock_in_Inventory1_idx` (`SI_INVENTORY_ID`),
  CONSTRAINT `fk_stock_in_Inventory1` FOREIGN KEY (`SI_INVENTORY_ID`) REFERENCES `inventory` (`INVENTORY_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_stock_in_Product1` FOREIGN KEY (`SI_PRODUCT_ID`) REFERENCES `product` (`PRODUCT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
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
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `supplier` (
  `SUPPLIER_ID` int(11) NOT NULL AUTO_INCREMENT,
  `ORGANIZATION` varchar(45) DEFAULT NULL,
  `SUPPLIER_PERSON_ID` int(11) NOT NULL,
  PRIMARY KEY (`SUPPLIER_ID`),
  KEY `fk_supplier_person1_idx` (`SUPPLIER_PERSON_ID`),
  CONSTRAINT `fk_supplier_person1` FOREIGN KEY (`SUPPLIER_PERSON_ID`) REFERENCES `person` (`PERSON_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier`
--

LOCK TABLES `supplier` WRITE;
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
INSERT INTO `supplier` VALUES (1,'Hino',3),(2,'Toyota',4),(3,'Fuso',5),(4,'Nissan',7);
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;
UNLOCK TABLES;


DELIMITER $$
USE `glaciers`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `glaciers`.`insertToProfile`
AFTER INSERT ON `glaciers`.`person`
FOR EACH ROW
BEGIN
	IF new.PERSON_TYPE = 'EMPLOYEE' then
		INSERT INTO EMPLOYEE(DATE_HIRED, STATUS, USERNAME, PASSWORD, EMP_PERSON_ID) 
        VALUES (CONCAT(YEAR(NOW()),'-',MONTH(NOW()),'-',DAY(NOW())), 'ACTIVE',NEW.EMAIL, NEW.EMAIL, NEW.PERSON_ID);
	ELSEIF new.PERSON_TYPE = 'CUSTOMER' then
		INSERT INTO CUSTOMER(BALANCE, CUSTOMER_PERSON_ID) VALUES (0, NEW.PERSON_ID);
	ELSEIF new.PERSON_TYPE = 'SUPPLIER' then
		INSERT INTO SUPPLIER(SUPPLIER_PERSON_ID) VALUES (NEW.PERSON_ID);
	END IF;
END$$


DELIMITER ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-04-01  6:18:25
