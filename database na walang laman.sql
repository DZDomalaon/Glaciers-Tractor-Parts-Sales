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
AUTO_INCREMENT = 7
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
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`employee`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`employee` (
  `EMP_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `SHIFT` VARCHAR(45) NULL DEFAULT NULL,
  `SALARY` VARCHAR(45) NULL DEFAULT NULL,
  `DATE_HIRED` DATE NULL DEFAULT NULL,
  `STATUS` VARCHAR(20) NULL DEFAULT NULL,
  `POSITION` VARCHAR(20) NULL DEFAULT NULL,
  `USERNAME` VARCHAR(45) NULL DEFAULT NULL,
  `PASSWORD` VARCHAR(45) NULL DEFAULT NULL,
  `EMP_PERSON_ID` INT(11) NOT NULL,
  `TIME_IN` VARCHAR(45) NULL DEFAULT NULL,
  `TIME_OUT` VARCHAR(45) NULL DEFAULT NULL,
  `LOG_DATE` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`EMP_ID`),
  INDEX `fk_employee_person1_idx` (`EMP_PERSON_ID` ASC),
  CONSTRAINT `fk_employee_person1`
    FOREIGN KEY (`EMP_PERSON_ID`)
    REFERENCES `glaciers`.`person` (`PERSON_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 3
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
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`purchase`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`purchase` (
  `PURCHASE_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `PURCHASE_SUPPLIER_ID` INT(11) NOT NULL,
  `PURCHASE_EMP_ID` INT(11) NOT NULL,
  `PURCHASE_DATE` DATE NULL DEFAULT NULL,
  `PRODUCT_NAME` VARCHAR(45) NULL DEFAULT NULL,
  `QUANTITY` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`PURCHASE_ID`),
  INDEX `fk_purchase_supplier1_idx` (`PURCHASE_SUPPLIER_ID` ASC),
  INDEX `fk_purchase_employee1_idx` (`PURCHASE_EMP_ID` ASC),
  CONSTRAINT `fk_purchase_employee1`
    FOREIGN KEY (`PURCHASE_EMP_ID`)
    REFERENCES `glaciers`.`employee` (`EMP_ID`)
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
-- Table `glaciers`.`delivery`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`delivery` (
  `DELIVER_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `DELIVER_STATUS` VARCHAR(45) NULL DEFAULT NULL,
  `DELIVER_PURCHASE_ID` INT(11) NOT NULL,
  PRIMARY KEY (`DELIVER_ID`),
  INDEX `fk_delivery report_purchase1_idx` (`DELIVER_PURCHASE_ID` ASC),
  CONSTRAINT `fk_delivery report_purchase1`
    FOREIGN KEY (`DELIVER_PURCHASE_ID`)
    REFERENCES `glaciers`.`purchase` (`PURCHASE_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`product_catalogue`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`product_catalogue` (
  `PC_ID` INT(11) NOT NULL,
  `PC_CATEGORY` VARCHAR(45) NULL DEFAULT NULL,
  `PC_VARIANT` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`PC_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`inventory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`inventory` (
  `PRODUCT_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `PRODUCT_NAME` VARCHAR(45) NULL DEFAULT NULL,
  `DESCRIPTION` VARCHAR(45) NULL DEFAULT NULL,
  `QUANTITY`` INT(11) NULL DEFAULT NULL,
  `PRICE` DECIMAL(5,2) NULL DEFAULT NULL,
  `WARRANTY` VARCHAR(45) NULL DEFAULT NULL,
  `DISCOUNT` INT(11) NULL DEFAULT NULL,
  `SERIAL` VARCHAR(45) NULL DEFAULT NULL,
  `INVENTORY_PC_ID` INT(11) NOT NULL,
  PRIMARY KEY (`PRODUCT_ID`),
  INDEX `fk_inventory_product_catalogue1_idx` (`INVENTORY_PC_ID` ASC),
  CONSTRAINT `fk_inventory_product_catalogue1`
    FOREIGN KEY (`INVENTORY_PC_ID`)
    REFERENCES `glaciers`.`product_catalogue` (`PC_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 16
DEFAULT CHARACTER SET = utf8;



-- -----------------------------------------------------
-- Table `glaciers`.`payment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`payment` (
  `PAYMENT_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `AMOUNT` VARCHAR(45) NULL DEFAULT NULL,
  `PAYMENT_DATE` VARCHAR(45) NULL DEFAULT NULL,
  `TYPE` VARCHAR(45) NULL DEFAULT NULL,
  `INTEREST` VARCHAR(4) NULL DEFAULT NULL,
  `TERM` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`PAYMENT_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`order_line`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`order_line` (
  `ORDERLINE_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `OL_TOTAL_PRICE` INT(11) NULL DEFAULT NULL,
  `OL_SUBTOTAL` INT(11) NULL DEFAULT NULL,
  `OL_TOTAL_QUANTITY` INT(11) NULL DEFAULT NULL,
  `OL_PRODUCT_ID` INT(11) NOT NULL,
  PRIMARY KEY (`ORDERLINE_ID`),
  INDEX `fk_order_line_product1_idx` (`OL_PRODUCT_ID` ASC),
  CONSTRAINT `fk_order_line_product1`
    FOREIGN KEY (`OL_PRODUCT_ID`)
    REFERENCES `glaciers`.`inventory` (`PRODUCT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`order`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`sales_order` (
  `ORDER_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `ORDER_DATE` VARCHAR(20) NULL DEFAULT NULL,
  `ORDER_STATUS` VARCHAR(45) NULL DEFAULT NULL,
  `ORDER_CUSTOMER_ID` INT(11) NOT NULL,
  `ORDER_EMP_ID` INT(11) NOT NULL,
  `ORDER_PAYMENT_ID` INT(11) NOT NULL,
  `OL_ORDER_ID` INT(11) NOT NULL,
  PRIMARY KEY (`ORDER_ID`),
  INDEX `fk_order_customer1_idx` (`ORDER_CUSTOMER_ID` ASC),
  INDEX `fk_order_employee1_idx` (`ORDER_EMP_ID` ASC),
  INDEX `fk_order_payment1_idx` (`ORDER_PAYMENT_ID` ASC),
  INDEX `fk_order_order_line1_idx` (`OL_ORDER_ID` ASC),
  CONSTRAINT `fk_order_customer1`
    FOREIGN KEY (`ORDER_CUSTOMER_ID`)
    REFERENCES `glaciers`.`customer` (`CUSTOMER_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_employee1`
    FOREIGN KEY (`ORDER_EMP_ID`)
    REFERENCES `glaciers`.`employee` (`EMP_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_payment1`
    FOREIGN KEY (`ORDER_PAYMENT_ID`)
    REFERENCES `glaciers`.`payment` (`PAYMENT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_order_line1`
    FOREIGN KEY (`OL_ORDER_ID`)
    REFERENCES `glaciers`.`order_line` (`ORDERLINE_ID`)
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
    REFERENCES `glaciers`.`inventory` (`PRODUCT_ID`)
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
-- Table `glaciers`.`stock_in`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`stock_in` (
  `SI_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `SI_PRDUCT` VARCHAR(45) NULL DEFAULT NULL,
  `SI_QUANTITY` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`SI_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`stock_in_has_inventory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`stock_in_has_inventory` (
  `stock_in_SI_ID` INT(11) NOT NULL,
  `Inventory_PRODUCT_ID` INT(11) NOT NULL,
  PRIMARY KEY (`stock_in_SI_ID`, `Inventory_PRODUCT_ID`),
  INDEX `fk_stock_in_has_Inventory_Inventory1_idx` (`Inventory_PRODUCT_ID` ASC),
  INDEX `fk_stock_in_has_Inventory_stock_in1_idx` (`stock_in_SI_ID` ASC),
  CONSTRAINT `fk_stock_in_has_Inventory_Inventory1`
    FOREIGN KEY (`Inventory_PRODUCT_ID`)
    REFERENCES `glaciers`.`inventory` (`PRODUCT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_stock_in_has_Inventory_stock_in1`
    FOREIGN KEY (`stock_in_SI_ID`)
    REFERENCES `glaciers`.`stock_in` (`SI_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

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
		INSERT INTO EMPLOYEE(DATE_HIRED, STATUS, USERNAME, PASSWORD, EMP_PERSON_ID) 
        VALUES (CONCAT(YEAR(NOW()),'-',MONTH(NOW()),'-',DAY(NOW())), 'ACTIVE',NEW.EMAIL, NEW.EMAIL, NEW.PERSON_ID);
	ELSEIF new.PERSON_TYPE = 'CUSTOMER' then
		INSERT INTO CUSTOMER(CUSTOMER_PERSON_ID) VALUES (NEW.PERSON_ID);
	ELSEIF new.PERSON_TYPE = 'SUPPLIER' then
		INSERT INTO SUPPLIER(SUPPLIER_PERSON_ID, CONTACT_PERSON) VALUES (NEW.PERSON_ID, CONCAT(NEW.FIRSTNAME, ' ', NEW.LASTNAME));
	END IF;
END$$


DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
