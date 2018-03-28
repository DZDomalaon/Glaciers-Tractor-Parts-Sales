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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (1,NULL,NULL,2),(2,NULL,5000,5),(3,NULL,666,6),(4,NULL,555,7);
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `damaged_items`
--

LOCK TABLES `damaged_items` WRITE;
/*!40000 ALTER TABLE `damaged_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `damaged_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `delivery`
--

DROP TABLE IF EXISTS `delivery`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `delivery` (
  `DELIVERY_ID` int(11) NOT NULL AUTO_INCREMENT,
  `PRODUCT_NAME` varchar(45) DEFAULT NULL,
  `TOTAL_QUANTITY` int(6) DEFAULT NULL,
  `DELIVERY_DATE` varchar(45) DEFAULT NULL,
  `DELIVERY_PURCHASE_ID` int(11) NOT NULL,
  `EXPECTED_QUANTITY` int(6) DEFAULT NULL,
  PRIMARY KEY (`DELIVERY_ID`),
  KEY `fk_Delivery_purchase1_idx` (`DELIVERY_PURCHASE_ID`),
  CONSTRAINT `fk_Delivery_purchase1` FOREIGN KEY (`DELIVERY_PURCHASE_ID`) REFERENCES `purchase` (`PURCHASE_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `delivery`
--

LOCK TABLES `delivery` WRITE;
/*!40000 ALTER TABLE `delivery` DISABLE KEYS */;
INSERT INTO `delivery` VALUES (2,'ligid',2,'12-12-12',2,2),(3,'bearing',2,'13-13-13',2,4),(4,'wrench',2,'20 March 2018',3,4),(6,'wrench',2,'20 March 2018',3,NULL),(7,'wrench',4,'20 March 2018',4,NULL),(8,'Bolt',5,'20 March 2018',5,NULL),(9,'Bolt',5,'20 March 2018',5,NULL),(10,'Bolt',3,'20 March 2018',6,NULL),(11,'Paint',4,'20 March 2018',7,NULL),(12,'bearing',4,'20 March 2018',2,NULL),(13,'Bearing',9,'21 March 2018',8,NULL),(14,'Bearing',8,'21 March 2018',8,NULL),(15,'Bearing',8,'21 March 2018',8,NULL),(16,'Bearing',8,'21 March 2018',8,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,'2018-03-19','Admin','Active','admin','admin',1);
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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
INSERT INTO `inventory` VALUES (1,9,2),(2,9,3),(3,9,7),(4,2,8),(5,9,9);
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
  `TERM` int(11) DEFAULT NULL,
  PRIMARY KEY (`PAYMENT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment` VALUES (1,1000,'2018-03-19','Cash',NULL),(2,200,'2018-03-20','Cash',NULL),(3,200,'2018-03-20','Cash',NULL),(4,150,'2018-03-20','Cash',NULL),(5,500,'2018-03-21','Cash',NULL),(6,NULL,'2018-03-21','Credit',NULL),(7,NULL,'2018-03-21','Credit',NULL),(8,NULL,'2018-03-21','Credit',NULL),(9,NULL,'2018-03-21','Credit',NULL),(10,NULL,'2018-03-21','Credit',NULL),(11,NULL,'2018-03-21','Credit',NULL),(12,NULL,'2018-03-21','Credit',NULL),(13,NULL,'2018-03-21','Credit',NULL),(14,NULL,'2018-03-21','Credit',NULL),(15,NULL,'2018-03-21','Credit',NULL),(16,NULL,'2018-03-21','Credit',NULL),(17,NULL,'2018-03-21','Credit',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `person`
--

LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` VALUES (1,'Darell','Domalaon',' 915-484-3947','dzdomalaon@addu.edu.ph','SA PUSO NG PATO',1,'EMPLOYEE'),(2,'Kristina','Pitoy','09154843947','mkopitoy@addu.edu.ph','SA PUSO NI RJ',0,'CUSTOMER'),(3,'Jusane','Bellezas','09154843947','jtsbellezas@addu.edu.ph','SA PUSO NG JOLLIBEE',0,'SUPPLIER'),(4,'chynna','sevilleno','123456','csevilleno@addu.edu.ph','ASDFGH',1,'EMPLOYEE'),(5,'Robert Joseph','Mahinay',' 922-155-4489','rjam@addu.edu','SPNT',1,'Customer'),(6,'Byron','Solarte',' 948-225-6112','byronsolarte@gmail.com','Sasa Dvo City',1,'Customer'),(7,'Alexandra','Ybañez',' 965-665-6521','akaybañez@gmail.com','Jacinto Dvo City',0,'Customer');
/*!40000 ALTER TABLE `person` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `glaciers`.`insertToProfile`
AFTER INSERT ON `glaciers`.`person`
FOR EACH ROW
BEGIN
	IF new.PERSON_TYPE = 'EMPLOYEE' then
		INSERT INTO EMPLOYEE(DATE_HIRED, STATUS, USERNAME, PASSWORD, EMP_PERSON_ID) 
        VALUES (CONCAT(YEAR(NOW()),'-',MONTH(NOW()),'-',DAY(NOW())), 'ACTIVE',NEW.EMAIL, NEW.EMAIL, NEW.PERSON_ID);
	ELSEIF new.PERSON_TYPE = 'CUSTOMER' then
		INSERT INTO CUSTOMER(CUSTOMER_PERSON_ID) VALUES (NEW.PERSON_ID);
	ELSEIF new.PERSON_TYPE = 'SUPPLIER' then
		INSERT INTO SUPPLIER(SUPPLIER_PERSON_ID) VALUES (NEW.PERSON_ID);
	END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

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
  `PRICE` decimal(8,2) DEFAULT NULL,
  `SERIAL` varchar(45) DEFAULT NULL,
  `PRODUCT_PC_ID` int(11) NOT NULL,
  PRIMARY KEY (`PRODUCT_ID`),
  KEY `fk_product_product_catalogue1_idx` (`PRODUCT_PC_ID`),
  CONSTRAINT `fk_product_product_catalogue1` FOREIGN KEY (`PRODUCT_PC_ID`) REFERENCES `product_catalogue` (`PC_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (2,'Wheel','Suzuki Part',450.00,'000001',2),(3,'Tractor Wheel','Toyota',350.00,'000002',3),(4,'Bearing','Wheel Bearing',250.00,'000003',2),(5,'Wrench','XXL',500.00,'000004',3),(6,'Steering Wheel','Toyota',5500.00,'445665',8),(7,'Steering Wheel','Toyota',6600.00,'1122244',9),(8,'Bolt','Large',50.00,'000005',10),(9,'Paint','Car paint',660.00,'000000',11);
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
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_catalogue`
--

LOCK TABLES `product_catalogue` WRITE;
/*!40000 ALTER TABLE `product_catalogue` DISABLE KEYS */;
INSERT INTO `product_catalogue` VALUES (2,'Tractor Part','Model','black'),(3,'Tractor Part','Model','b500'),(4,'Tractor Part','Model','xy22'),(5,'Tractor Part','Model','red'),(6,'Tractor Part','Model','H700'),(7,'Tractor Part','Model','H700'),(8,'Tractor Part','Model','H700'),(9,'Tractor Part','Model','H700'),(10,'Tractor Part','Model','b600'),(11,'Tractor Part','Model','Red');
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
INSERT INTO `product_has_supplier` VALUES (2,1),(3,1),(4,1),(5,1),(8,1),(9,1);
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase`
--

LOCK TABLES `purchase` WRITE;
/*!40000 ALTER TABLE `purchase` DISABLE KEYS */;
INSERT INTO `purchase` VALUES (1,'10-12-12','to be delivered',1,1),(2,'2018-03-20','To be delivered',1,1),(3,'2018-03-20','To be delivered',1,1),(4,'2018-03-20','To be delivered',1,1),(5,'2018-03-20','To be delivered',1,1),(6,'2018-03-20','To be delivered',1,1),(7,'2018-03-20','To be delivered',1,1),(8,'2018-03-21','To be delivered',1,1);
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
INSERT INTO `purchase_details` VALUES ('ligid',100,2200,200,6,2,'Tractor Part','color','Type',2),('bearing',500,2200,2000,6,4,'Tractor Part','model','Type',2),('wrench',120,480,480,4,4,'Equipment','color','Type',3),('wrench',120,600,600,5,5,'Equipment','color','Type',4),('Bolt',50,2500,2500,50,50,'Tractor Part','Model','Type',5),('Bolt',50,150,150,3,3,'Tractor Part','Model','Type',6),('Paint',660,2640,2640,4,4,'Tractor Part','Model','Type',7),('Bearing',250,2500,2500,10,10,'Tractor Part','Model','Type',8);
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
  `ORDER_DISCOUNT` double DEFAULT NULL,
  `PAYMENT_CHANGE` double DEFAULT NULL,
  `ORDER_DATE` varchar(45) DEFAULT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_order`
--

LOCK TABLES `sales_order` WRITE;
/*!40000 ALTER TABLE `sales_order` DISABLE KEYS */;
INSERT INTO `sales_order` VALUES (1,NULL,NULL,'2018-03-19','Paid',NULL,1,1,1),(2,0,0,'2018-03-20','Paid',NULL,4,1,3),(3,0,0,'2018-03-20','Paid',NULL,4,1,4),(4,0,450,'2018-03-21','Paid',NULL,4,1,5),(5,NULL,NULL,'2018-03-21','Unpaid',0,1,1,6),(6,NULL,NULL,'2018-03-21','Unpaid',0,1,1,7),(7,NULL,NULL,'2018-03-21','Unpaid',0,1,1,9),(8,NULL,NULL,'2018-03-21','Unpaid',0,1,1,11),(9,NULL,NULL,'2018-03-21','Unpaid',0,1,1,13),(10,NULL,NULL,'2018-03-21','Unpaid',0,1,1,14),(11,NULL,NULL,'2018-03-21','Unpaid',0,1,1,16);
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
  `ORDER_SUBTOTAL` double DEFAULT NULL,
  `ORDER_TOTAL` double DEFAULT NULL,
  `ORDER_TQUANTITY` int(11) DEFAULT NULL,
  `ORDER_SUBQUANTITY` int(11) DEFAULT NULL,
  `SO_ID` int(11) NOT NULL,
  `ORDER_SERIAL_NO` varchar(45) DEFAULT NULL,
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
INSERT INTO `sales_order_details` VALUES (4,500,500,1000,2,1,1,'4005401158547'),(4,500,500,1000,2,1,1,'4012940909109'),(8,50,50,200,4,1,2,'220001'),(8,50,50,150,3,1,3,'220001'),(8,50,50,50,3,3,4,'000005'),(8,50,50,0,2,2,7,''),(8,50,50,0,1,1,8,''),(8,50,50,0,3,3,10,''),(8,50,50,0,3,3,11,'');
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier`
--

LOCK TABLES `supplier` WRITE;
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
INSERT INTO `supplier` VALUES (1,NULL,3);
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

-- Dump completed on 2018-03-21 10:47:23
