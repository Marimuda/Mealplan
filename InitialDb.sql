CREATE DATABASE  IF NOT EXISTS `mealplan` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `mealplan`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: mealplan
-- ------------------------------------------------------
-- Server version	5.7.21-log

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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account` (
  `AccountId` int(10) NOT NULL AUTO_INCREMENT,
  `DisplayedName` varchar(30) NOT NULL DEFAULT 'Anonymous' COMMENT 'Either Personal Name or Username',
  `Role` tinyint(1) NOT NULL,
  PRIMARY KEY (`AccountId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account`
--

LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `activity_level`
--

DROP TABLE IF EXISTS `activity_level`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `activity_level` (
  `BioId` int(10) NOT NULL,
  `ActivityLevel` tinyint(1) NOT NULL,
  `ActivityDescription` varchar(255) NOT NULL,
  PRIMARY KEY (`BioId`),
  KEY `FKactivity_l263631` (`BioId`),
  CONSTRAINT `FKactivity_l263631` FOREIGN KEY (`BioId`) REFERENCES `bio_data` (`BioId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activity_level`
--

LOCK TABLES `activity_level` WRITE;
/*!40000 ALTER TABLE `activity_level` DISABLE KEYS */;
INSERT INTO `activity_level` VALUES (2,4,'Very Active Person');
/*!40000 ALTER TABLE `activity_level` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bio_data`
--

DROP TABLE IF EXISTS `bio_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bio_data` (
  `BioId` int(10) NOT NULL AUTO_INCREMENT,
  `Weight` tinyint(4) NOT NULL,
  `Height` tinyint(4) NOT NULL,
  `Gender` char(1) NOT NULL,
  `Birthday` datetime NOT NULL,
  `PersonId` int(10) DEFAULT NULL,
  PRIMARY KEY (`BioId`),
  KEY `FKBio_data523729_idx` (`PersonId`),
  CONSTRAINT `FKbio_l263631` FOREIGN KEY (`PersonId`) REFERENCES `persons` (`PersonId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bio_data`
--

LOCK TABLES `bio_data` WRITE;
/*!40000 ALTER TABLE `bio_data` DISABLE KEYS */;
INSERT INTO `bio_data` VALUES (1,77,14,'F','1322-12-31 02:31:00',1),(2,123,123,'M','1131-12-23 12:31:00',2);
/*!40000 ALTER TABLE `bio_data` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `course_recipe_choices`
--

DROP TABLE IF EXISTS `course_recipe_choices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `course_recipe_choices` (
  `CourseId` smallint(5) NOT NULL,
  `MenuId` int(10) DEFAULT NULL,
  `RecipesId` int(10) NOT NULL,
  PRIMARY KEY (`CourseId`,`RecipesId`),
  KEY `FKCourse_Rec894165` (`RecipesId`),
  KEY `FKCourse_Rec371103` (`CourseId`,`MenuId`),
  CONSTRAINT `FKCourse_Rec371103` FOREIGN KEY (`CourseId`, `MenuId`) REFERENCES `menu_course` (`CourseId`, `MenuId`) ON UPDATE CASCADE,
  CONSTRAINT `FKCourse_Rec894165` FOREIGN KEY (`RecipesId`) REFERENCES `recipes` (`RecipeId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `course_recipe_choices`
--

LOCK TABLES `course_recipe_choices` WRITE;
/*!40000 ALTER TABLE `course_recipe_choices` DISABLE KEYS */;
/*!40000 ALTER TABLE `course_recipe_choices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `course_type`
--

DROP TABLE IF EXISTS `course_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `course_type` (
  `CourseIdr` smallint(5) NOT NULL,
  `MenuId` int(10) NOT NULL,
  `CourseType` varchar(50) NOT NULL,
  PRIMARY KEY (`CourseIdr`,`MenuId`),
  KEY `FKCourse_typ472992` (`CourseIdr`,`MenuId`),
  CONSTRAINT `FKCourse_typ472992` FOREIGN KEY (`CourseIdr`, `MenuId`) REFERENCES `menu_course` (`CourseId`, `MenuId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `course_type`
--

LOCK TABLES `course_type` WRITE;
/*!40000 ALTER TABLE `course_type` DISABLE KEYS */;
/*!40000 ALTER TABLE `course_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredients`
--

DROP TABLE IF EXISTS `ingredients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ingredients` (
  `IngredientId` smallint(5) NOT NULL AUTO_INCREMENT,
  `IngredientName` varchar(50) NOT NULL,
  PRIMARY KEY (`IngredientId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredients`
--

LOCK TABLES `ingredients` WRITE;
/*!40000 ALTER TABLE `ingredients` DISABLE KEYS */;
/*!40000 ALTER TABLE `ingredients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logins`
--

DROP TABLE IF EXISTS `logins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `logins` (
  `AccountId` int(10) NOT NULL AUTO_INCREMENT,
  `Username` varchar(30) NOT NULL,
  `PasswordSalt` varchar(36) NOT NULL COMMENT 'random-generated salt\nNVARCHAR(36)\nFor SHA2_512 encryption',
  `PasswordHash` char(64) NOT NULL COMMENT 'SHA-256 generates a 256-bit hash value. You can use CHAR(64) or BINARY(32)',
  `IsActivated` bit(1) DEFAULT NULL COMMENT 'The option to deactivate user / functionality',
  `PersonId` int(10) NOT NULL,
  PRIMARY KEY (`AccountId`),
  UNIQUE KEY `Username` (`Username`),
  UNIQUE KEY `PasswordHash` (`PasswordHash`),
  KEY `FKLogins640643` (`PersonId`),
  CONSTRAINT `FKLogins640643` FOREIGN KEY (`PersonId`) REFERENCES `persons` (`PersonId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logins`
--

LOCK TABLES `logins` WRITE;
/*!40000 ALTER TABLE `logins` DISABLE KEYS */;
/*!40000 ALTER TABLE `logins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `memberships`
--

DROP TABLE IF EXISTS `memberships`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `memberships` (
  `MembershipId` int(10) NOT NULL,
  `EmailAdress` varchar(50) NOT NULL,
  `CreationDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `LastLogin` datetime NOT NULL,
  `PasswordQuestion` varchar(255) DEFAULT NULL,
  `PasswordAnswer` varchar(255) DEFAULT NULL,
  `FailedAttempts` tinyint(1) NOT NULL DEFAULT '0',
  `LoginId` int(10) NOT NULL,
  `AccountId` int(10) NOT NULL,
  PRIMARY KEY (`MembershipId`),
  KEY `FKMembership716389` (`AccountId`),
  KEY `FKMembership459979` (`LoginId`),
  CONSTRAINT `FKMembership459979` FOREIGN KEY (`LoginId`) REFERENCES `logins` (`AccountId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FKMembership716389` FOREIGN KEY (`AccountId`) REFERENCES `account` (`AccountId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `memberships`
--

LOCK TABLES `memberships` WRITE;
/*!40000 ALTER TABLE `memberships` DISABLE KEYS */;
/*!40000 ALTER TABLE `memberships` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu_course`
--

DROP TABLE IF EXISTS `menu_course`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `menu_course` (
  `CourseId` smallint(5) NOT NULL,
  `MenuId` int(10) NOT NULL,
  `CourseName` varchar(50) NOT NULL,
  `CImageUrl` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`CourseId`,`MenuId`),
  KEY `FKMenu_Cours370256` (`MenuId`),
  CONSTRAINT `FKMenu_Cours370256` FOREIGN KEY (`MenuId`) REFERENCES `suggested_menus` (`MenuId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu_course`
--

LOCK TABLES `menu_course` WRITE;
/*!40000 ALTER TABLE `menu_course` DISABLE KEYS */;
/*!40000 ALTER TABLE `menu_course` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu_courses`
--

DROP TABLE IF EXISTS `menu_courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `menu_courses` (
  `menu_id` int(10) NOT NULL,
  `course_number` tinyint(4) NOT NULL,
  `course_name` varchar(50) NOT NULL,
  PRIMARY KEY (`menu_id`,`course_number`),
  UNIQUE KEY `menu_id` (`menu_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu_courses`
--

LOCK TABLES `menu_courses` WRITE;
/*!40000 ALTER TABLE `menu_courses` DISABLE KEYS */;
/*!40000 ALTER TABLE `menu_courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `persons`
--

DROP TABLE IF EXISTS `persons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `persons` (
  `PersonId` int(10) NOT NULL,
  `Firstname` varchar(30) NOT NULL,
  `Surname` varchar(30) NOT NULL,
  PRIMARY KEY (`PersonId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persons`
--

LOCK TABLES `persons` WRITE;
/*!40000 ALTER TABLE `persons` DISABLE KEYS */;
INSERT INTO `persons` VALUES (1,'Fred','Hansen'),(2,'Johan','Trump'),(3,'Hans','Egil');
/*!40000 ALTER TABLE `persons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe_ratning`
--

DROP TABLE IF EXISTS `recipe_ratning`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recipe_ratning` (
  `RecipeId` int(10) NOT NULL,
  `RecipeRating` smallint(5) DEFAULT NULL,
  PRIMARY KEY (`RecipeId`),
  KEY `FKRecipe_Rat281140` (`RecipeId`),
  CONSTRAINT `FKRecipe_Rat281140` FOREIGN KEY (`RecipeId`) REFERENCES `recipes` (`RecipeId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_ratning`
--

LOCK TABLES `recipe_ratning` WRITE;
/*!40000 ALTER TABLE `recipe_ratning` DISABLE KEYS */;
/*!40000 ALTER TABLE `recipe_ratning` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe_steps_ingredients`
--

DROP TABLE IF EXISTS `recipe_steps_ingredients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recipe_steps_ingredients` (
  `StepId` tinyint(2) NOT NULL AUTO_INCREMENT,
  `Amount` smallint(5) NOT NULL,
  `IngredientId` smallint(5) NOT NULL,
  `RecipeId` int(10) NOT NULL,
  PRIMARY KEY (`StepId`),
  KEY `FKRecipe_Ste135474` (`RecipeId`),
  KEY `FKRecipe_Ste374390` (`IngredientId`),
  CONSTRAINT `FKRecipe_Ste135474` FOREIGN KEY (`RecipeId`) REFERENCES `recipes` (`RecipeId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FKRecipe_Ste374390` FOREIGN KEY (`IngredientId`) REFERENCES `ingredients` (`IngredientId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_steps_ingredients`
--

LOCK TABLES `recipe_steps_ingredients` WRITE;
/*!40000 ALTER TABLE `recipe_steps_ingredients` DISABLE KEYS */;
/*!40000 ALTER TABLE `recipe_steps_ingredients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipes`
--

DROP TABLE IF EXISTS `recipes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recipes` (
  `RecipeId` int(10) NOT NULL AUTO_INCREMENT,
  `RecipeName` varchar(50) NOT NULL COMMENT 'Group decide if the recipe shall be unique or not',
  `RecipeDescription` blob NOT NULL COMMENT 'blob limit , around 21,844 characters. UTF-8',
  `ReCreationDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `AccountId` int(10) NOT NULL,
  PRIMARY KEY (`RecipeId`),
  KEY `FKRecipes688032` (`AccountId`),
  CONSTRAINT `FKRecipes688032` FOREIGN KEY (`AccountId`) REFERENCES `account` (`AccountId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipes`
--

LOCK TABLES `recipes` WRITE;
/*!40000 ALTER TABLE `recipes` DISABLE KEYS */;
/*!40000 ALTER TABLE `recipes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suggested_menus`
--

DROP TABLE IF EXISTS `suggested_menus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `suggested_menus` (
  `MenuId` int(10) NOT NULL AUTO_INCREMENT,
  `MenuName` varchar(50) NOT NULL,
  `MenuDescription` varchar(255) NOT NULL,
  PRIMARY KEY (`MenuId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suggested_menus`
--

LOCK TABLES `suggested_menus` WRITE;
/*!40000 ALTER TABLE `suggested_menus` DISABLE KEYS */;
/*!40000 ALTER TABLE `suggested_menus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'mealplan'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-04-05 19:18:16
