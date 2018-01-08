-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema glaciers
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema glaciers
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `glaciers` DEFAULT CHARACTER SET utf8 ;
USE `glaciers` ;

-- -----------------------------------------------------
-- Table `glaciers`.`person`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`person` (
  `PERSON_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `FIRSTNAME` VARCHAR(45) NULL DEFAULT NULL,
  `LASTNAME` VARCHAR(45) NULL DEFAULT NULL,
  `CONTACT_NUM` VARCHAR(15) NULL DEFAULT NULL,
  `EMAIL` VARCHAR(64) NULL DEFAULT NULL,
  `ADDRESS` VARCHAR(64) NULL DEFAULT NULL,
  `GENDER` INT(11) NULL DEFAULT NULL,
  `PERSON_TYPE` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`PERSON_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`customer`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`customer` (
  `CUSTOMER_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `BALANCE` INT(11) NULL DEFAULT NULL,
  `CREDIT_LIMIT` INT(11) NULL DEFAULT NULL,
  `CUSTOMER_PERSON_ID` INT(11) NOT NULL,
  PRIMARY KEY (`CUSTOMER_ID`),
  INDEX `fk_customer_person_idx` (`CUSTOMER_PERSON_ID` ASC),
  CONSTRAINT `fk_customer_person`
    FOREIGN KEY (`CUSTOMER_PERSON_ID`)
    REFERENCES `glaciers`.`person` (`PERSON_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`Employee`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`Employee` (
  `EMP_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `SHIFT` TIME NULL DEFAULT NULL,
  `SALARY` INT(11) NULL DEFAULT NULL,
  `DATE_HIRED` DATE NULL DEFAULT NULL,
  `STATUS` VARCHAR(20) NULL DEFAULT NULL,
  `USERNAME` VARCHAR(45) NULL DEFAULT NULL,
  `PASSWORD` VARCHAR(45) NULL DEFAULT NULL,
  `TIME_IN` VARCHAR(45) NULL,
  `TIME_OUT` VARCHAR(45) NULL,
  `LOG_DATE` VARCHAR(45) NULL,
  `STAFF_PERSON_ID` INT(11) NOT NULL,
  PRIMARY KEY (`EMP_ID`),
  INDEX `fk_staff_person1_idx` (`STAFF_PERSON_ID` ASC),
  CONSTRAINT `fk_staff_person1`
    FOREIGN KEY (`STAFF_PERSON_ID`)
    REFERENCES `glaciers`.`person` (`PERSON_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`payment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`payment` (
  `PAYMENT_ID` INT NOT NULL AUTO_INCREMENT,
  `AMOUNT` DOUBLE NULL,
  `PAYMENT_DATE` DATE NULL,
  `TYPE` VARCHAR(45) NULL,
  `INTEREST` DOUBLE NULL,
  `TERM` INT NULL,
  PRIMARY KEY (`PAYMENT_ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `glaciers`.`product_catalogue`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`product_catalogue` (
  `PC_ID` INT NOT NULL AUTO_INCREMENT,
  `PC_CATEGORY` VARCHAR(45) NULL,
  `PC_VARIANT` VARCHAR(45) NULL,
  PRIMARY KEY (`PC_ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `glaciers`.`Product`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`Product` (
  `PRODUCT_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `PRODUCT_NAME` VARCHAR(45) NULL DEFAULT NULL,
  `DESCRIPTION` VARCHAR(45) NULL DEFAULT NULL,
  `PRICE` DECIMAL(5,2) NULL DEFAULT NULL,
  `WARRANTY` VARCHAR(45) NULL DEFAULT NULL,
  `SERIAL` VARCHAR(45) NULL,
  `PRODUCT_PC_ID` INT NOT NULL,
  PRIMARY KEY (`PRODUCT_ID`),
  INDEX `fk_product_product_catalogue1_idx` (`PRODUCT_PC_ID` ASC),
  CONSTRAINT `fk_product_product_catalogue1`
    FOREIGN KEY (`PRODUCT_PC_ID`)
    REFERENCES `glaciers`.`product_catalogue` (`PC_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`sales_order`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`sales_order` (
  `ORDER_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `ORDER_PRICE` DOUBLE NULL,
  `ORDER_SUBTOTAL` INT NULL,
  `ORDER_TQUANTITY` INT NULL,
  `ORDER_DISCOUNT` DOUBLE NULL,
  `ORDER_DATE` DATE NULL DEFAULT NULL,
  `ORDER_STATUS` VARCHAR(45) NULL DEFAULT NULL,
  `ORDER_CUSTOMER_ID` INT(11) NOT NULL,
  `ORDER_EMP_ID` INT(11) NOT NULL,
  `ORDER_PAYMENT_ID` INT NOT NULL,
  `ORDER_PRODUCT_ID` INT(11) NOT NULL,
  PRIMARY KEY (`ORDER_ID`),
  INDEX `fk_order_customer1_idx` (`ORDER_CUSTOMER_ID` ASC),
  INDEX `fk_order_staff1_idx` (`ORDER_EMP_ID` ASC),
  INDEX `fk_order_payment1_idx` (`ORDER_PAYMENT_ID` ASC),
  INDEX `fk_order_Product1_idx` (`ORDER_PRODUCT_ID` ASC),
  CONSTRAINT `fk_order_customer1`
    FOREIGN KEY (`ORDER_CUSTOMER_ID`)
    REFERENCES `glaciers`.`customer` (`CUSTOMER_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_staff1`
    FOREIGN KEY (`ORDER_EMP_ID`)
    REFERENCES `glaciers`.`Employee` (`EMP_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_payment1`
    FOREIGN KEY (`ORDER_PAYMENT_ID`)
    REFERENCES `glaciers`.`payment` (`PAYMENT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_Product1`
    FOREIGN KEY (`ORDER_PRODUCT_ID`)
    REFERENCES `glaciers`.`Product` (`PRODUCT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`supplier`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`supplier` (
  `SUPPLIER_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `CONTACT_PERSON` VARCHAR(45) NULL DEFAULT NULL,
  `ORGANIZATION` VARCHAR(45) NULL DEFAULT NULL,
  `SUPPLIER_PERSON_ID` INT(11) NOT NULL,
  PRIMARY KEY (`SUPPLIER_ID`),
  INDEX `fk_supplier_person1_idx` (`SUPPLIER_PERSON_ID` ASC),
  CONSTRAINT `fk_supplier_person1`
    FOREIGN KEY (`SUPPLIER_PERSON_ID`)
    REFERENCES `glaciers`.`person` (`PERSON_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`product_has_supplier`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`product_has_supplier` (
  `product_PRODUCT_ID` INT(11) NOT NULL,
  `supplier_SUPPLIER_ID` INT(11) NOT NULL,
  INDEX `fk_product_has_supplier_supplier1_idx` (`supplier_SUPPLIER_ID` ASC),
  INDEX `fk_product_has_supplier_product1_idx` (`product_PRODUCT_ID` ASC),
  CONSTRAINT `fk_product_has_supplier_product1`
    FOREIGN KEY (`product_PRODUCT_ID`)
    REFERENCES `glaciers`.`Product` (`PRODUCT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_product_has_supplier_supplier1`
    FOREIGN KEY (`supplier_SUPPLIER_ID`)
    REFERENCES `glaciers`.`supplier` (`SUPPLIER_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`purchase`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`purchase` (
  `PURCHASE_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `PURCHASE_DATE` VARCHAR(45) NULL DEFAULT NULL,
  `PRODUCT_NAME` VARCHAR(45) NULL,
  `QUANTITY` VARCHAR(45) NULL,
  `PRICE` DOUBLE NULL,
  `PURCHASE_EMP_ID` INT(11) NOT NULL,
  `PURCHASE_SUPPLIER_ID` INT(11) NOT NULL,
  PRIMARY KEY (`PURCHASE_ID`),
  INDEX `fk_purchase_supplier1_idx` (`PURCHASE_SUPPLIER_ID` ASC),
  INDEX `fk_purchase_staff1_idx` (`PURCHASE_EMP_ID` ASC),
  CONSTRAINT `fk_purchase_staff1`
    FOREIGN KEY (`PURCHASE_EMP_ID`)
    REFERENCES `glaciers`.`Employee` (`EMP_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_purchase_supplier1`
    FOREIGN KEY (`PURCHASE_SUPPLIER_ID`)
    REFERENCES `glaciers`.`supplier` (`SUPPLIER_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`Inventory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`Inventory` (
  `INVENTORY_ID` INT NOT NULL AUTO_INCREMENT,
  `QUANTITY` INT(11) NULL,
  `INV_PRODUCT_ID` INT(11) NOT NULL,
  PRIMARY KEY (`INVENTORY_ID`),
  INDEX `fk_Inventory_Product1_idx` (`INV_PRODUCT_ID` ASC),
  CONSTRAINT `fk_Inventory_Product1`
    FOREIGN KEY (`INV_PRODUCT_ID`)
    REFERENCES `glaciers`.`Product` (`PRODUCT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `glaciers`.`stock_in`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`stock_in` (
  `SI_ID` INT NOT NULL AUTO_INCREMENT,
  `SI_QUANTITY` INT NULL,
  `SI_PRODUCT_ID` INT(11) NOT NULL,
  `SI_INVENTORY_ID` INT NOT NULL,
  PRIMARY KEY (`SI_ID`),
  INDEX `fk_stock_in_Product1_idx` (`SI_PRODUCT_ID` ASC),
  INDEX `fk_stock_in_Inventory1_idx` (`SI_INVENTORY_ID` ASC),
  CONSTRAINT `fk_stock_in_Product1`
    FOREIGN KEY (`SI_PRODUCT_ID`)
    REFERENCES `glaciers`.`Product` (`PRODUCT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_stock_in_Inventory1`
    FOREIGN KEY (`SI_INVENTORY_ID`)
    REFERENCES `glaciers`.`Inventory` (`INVENTORY_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `glaciers`.`delivery`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`delivery` (
  `DELIVER_ID` INT NOT NULL AUTO_INCREMENT,
  `DELIVER_STATUS` VARCHAR(45) NULL,
  `DELIVER_PURCHASE_ID` INT(11) NOT NULL,
  PRIMARY KEY (`DELIVER_ID`),
  INDEX `fk_delivery report_purchase1_idx` (`DELIVER_PURCHASE_ID` ASC),
  CONSTRAINT `fk_delivery report_purchase1`
    FOREIGN KEY (`DELIVER_PURCHASE_ID`)
    REFERENCES `glaciers`.`purchase` (`PURCHASE_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `glaciers`;

DELIMITER $$
USE `glaciers`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `glaciers`.`insertToProfile`
AFTER INSERT ON `glaciers`.`person`
FOR EACH ROW
BEGIN
	IF new.PERSON_TYPE = 'EMPLOYEE' then
		INSERT INTO EMPLOYEE(DATE_HIRED, STATUS, USERNAME, PASSWORD, STAFF_PERSON_ID) 
        VALUES (CONCAT(YEAR(NOW()),'-',MONTH(NOW()),'-',DAY(NOW())), 'ACTIVE',NEW.EMAIL, NEW.EMAIL, NEW.PERSON_ID);
	ELSEIF new.PERSON_TYPE = 'CUSTOMER' then
		INSERT INTO CUSTOMER(CUSTOMER_PERSON_ID) VALUES (NEW.PERSON_ID);
	ELSEIF new.PERSON_TYPE = 'SUPPLIER' then
		INSERT INTO SUPPLIER(SUPPLIER_PERSON_ID) VALUES (NEW.PERSON_ID);
	END IF;
END$$


DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
