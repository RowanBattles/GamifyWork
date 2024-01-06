-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema gamifywork
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `gamifywork` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `gamifywork` ;

-- -----------------------------------------------------
-- Table `gamifywork`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gamifywork`.`user` (
  `User_ID` VARCHAR(36) NOT NULL,
  `Points` INT NOT NULL,
  PRIMARY KEY (`User_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `gamifywork`.`reward`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gamifywork`.`reward` (
  `Reward_ID` INT NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(60) NOT NULL,
  `Description` VARCHAR(255) NULL DEFAULT NULL,
  `Cost` INT NOT NULL,
  `User` VARCHAR(36) NOT NULL,
  PRIMARY KEY (`Reward_ID`),
  INDEX `UserKey_idx` (`User` ASC) VISIBLE,
  CONSTRAINT `RewardUserKey`
    FOREIGN KEY (`User`)
    REFERENCES `gamifywork`.`user` (`User_ID`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `gamifywork`.`task`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gamifywork`.`task` (
  `Task_ID` INT NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(60) NOT NULL,
  `Description` VARCHAR(255) NULL DEFAULT NULL,
  `Points` INT NOT NULL,
  `Completed` TINYINT NOT NULL,
  `Recurring` TINYINT NOT NULL,
  `RecurrenceType` VARCHAR(45) NULL DEFAULT NULL,
  `RecurrenceInterval` INT NULL DEFAULT NULL,
  `NextDueDate` DATETIME NULL DEFAULT NULL,
  `User` VARCHAR(36) NOT NULL,
  PRIMARY KEY (`Task_ID`),
  INDEX `UserKey_idx` (`User` ASC) VISIBLE,
  CONSTRAINT `TaskUserKey`
    FOREIGN KEY (`User`)
    REFERENCES `gamifywork`.`user` (`User_ID`))
ENGINE = InnoDB
AUTO_INCREMENT = 176
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
