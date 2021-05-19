CREATE DATABASE  IF NOT EXISTS `velomax` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `velomax`;
-- MySQL dump 10.13  Distrib 8.0.24, for Win64 (x86_64)
--
-- Host: localhost    Database: velomax
-- ------------------------------------------------------
-- Server version	8.0.23

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `adresse`
--

DROP TABLE IF EXISTS `adresse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `adresse` (
  `idAdresse` int NOT NULL AUTO_INCREMENT,
  `ligne1Adresse` varchar(255) NOT NULL,
  `ligne2Adresse` varchar(255) DEFAULT NULL,
  `villeAdresse` varchar(255) NOT NULL,
  `codePostalAdresse` varchar(255) NOT NULL,
  `provinceAdresse` varchar(255) DEFAULT NULL,
  `paysAdresse` varchar(255) NOT NULL,
  PRIMARY KEY (`idAdresse`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adresse`
--

LOCK TABLES `adresse` WRITE;
/*!40000 ALTER TABLE `adresse` DISABLE KEYS */;
INSERT INTO `adresse` VALUES (1,'31 boulevard Troussel','Bâtiment A, Maison M08','Conflans','78700','Yvellines','France'),(2,'7 rue de la Paix','','Paris','75002','Paris','France'),(3,'32 rue Bivouac Napoléon','','Cannes','06400','Alpes-Maritimes','France'),(4,'24 avenue Léonard de Vinci','','Courbevoie','92400','Hauts-de-Seine','France'),(5,'4 avenue des Champs-Elysées','Bâtiment C','Paris','75008','Paris','France'),(8,'42 rue de Rennes','','Paris','75006','Paris','France'),(9,'Adresse Test','Adresse Test','Adresse Test','Adresse Test','Adresse Test','Adresse Test'),(11,'2976 Aliquet Rd.',NULL,'Cholet','83702','PA','France'),(12,'2958 Pellentesque Rd.',NULL,'Nîmes','00798','Languedoc-Roussillon','France'),(13,'2637 Condimentum. Av.',NULL,'Lambersart','49664','NO','France'),(14,'5756 Metus. Avenue',NULL,'Laval','11974','Pays de la Loire','France'),(15,'8460 Quisque Rd.',NULL,'Poitiers','39700','PO','France'),(16,'9812 Vitae Avenue',NULL,'Vannes','42211','BR','France'),(17,'7255 Justo St.',NULL,'Albi','59833','MI','France'),(18,'7870 Nulla Rd.',NULL,'Illkirch-Graffenstaden','34301','Alsace','France'),(19,'8367 Malesuada St.','','Limoges','45004','LI','France'),(20,'3977 Pharetra Rd.',NULL,'Quimper','66781','Bretagne','France'),(21,'7161 Vitae Av.','Ap #819','Bastia','74176','Corse','France'),(22,'5072 Eget Ave',NULL,'Créteil','46955','IL','France'),(23,'P.O. Box 954, 7234 Ultrices. Av.','P.O. Box 954','Soissons','78683','Picardie','France'),(24,'9793 Nibh Avenue',NULL,'Périgueux','14802','Aquitaine','France'),(25,'3068 Augue St.',NULL,'Douai','42610','NO','France'),(26,'P.O. Box 293, 9815 Maecenas St.','P.O. Box 293','Anglet','13647','AQ','France'),(27,'3039 Eu Street','Ap #550','Épinal','54172','Lorraine','France'),(28,'3420 Orci. Avenue','P.O. Box 314','Caen','03518','BA','France'),(29,'9769 Odio Road','Ap #178','Saint-Louis','43608','Alsace','France'),(30,'2356 Augue Ave','P.O. Box 505','Charleville-Mézières','27111','CH','France'),(31,'2976 Aliquet Rd.',NULL,'Cholet','83702','PA','France');
/*!40000 ALTER TABLE `adresse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client` (
  `idClient` int NOT NULL AUTO_INCREMENT,
  `idAdresse` int NOT NULL,
  `idContact` int NOT NULL,
  `dateAdheranceClient` date NOT NULL,
  PRIMARY KEY (`idClient`),
  KEY `FK_Client_idAdresse_idAdresse` (`idAdresse`),
  KEY `FK_Client_idContact_idContact` (`idContact`),
  CONSTRAINT `FK_Client_idAdresse_idAdresse` FOREIGN KEY (`idAdresse`) REFERENCES `adresse` (`idAdresse`),
  CONSTRAINT `FK_Client_idContact_idContact` FOREIGN KEY (`idContact`) REFERENCES `contact` (`idContact`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (1,1,3,'2021-02-10'),(2,4,1,'2020-09-20'),(3,2,2,'2020-09-20'),(4,8,7,'2020-09-20'),(5,5,10,'2020-09-20'),(6,9,11,'2021-05-19'),(7,11,113,'2021-03-12'),(8,12,114,'2017-04-08'),(9,13,115,'2017-07-19'),(10,14,116,'2017-12-26'),(11,15,117,'2019-12-07'),(12,16,118,'2016-09-28'),(13,17,119,'2015-10-14'),(14,18,120,'2016-04-08'),(15,19,121,'2016-07-09'),(16,20,122,'2017-12-20'),(17,21,123,'2019-01-19'),(18,22,124,'2016-06-23'),(19,23,125,'2016-12-16'),(20,24,126,'2017-03-09'),(21,25,127,'2016-12-04'),(22,26,128,'2020-08-24'),(23,27,129,'2020-02-26'),(24,28,130,'2018-05-24'),(25,29,131,'2020-04-12'),(26,30,132,'2016-02-28');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientpart`
--

DROP TABLE IF EXISTS `clientpart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientpart` (
  `idClient` int NOT NULL,
  `idFidelio` int DEFAULT NULL,
  `dateDebutFidelio` date DEFAULT NULL,
  PRIMARY KEY (`idClient`),
  KEY `FK_ClientPart_idFidelio_idFidelio` (`idFidelio`),
  CONSTRAINT `FK_ClientPart_idClient_idClient` FOREIGN KEY (`idClient`) REFERENCES `client` (`idClient`),
  CONSTRAINT `FK_ClientPart_idFidelio_idFidelio` FOREIGN KEY (`idFidelio`) REFERENCES `fidelio` (`idFidelio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientpart`
--

LOCK TABLES `clientpart` WRITE;
/*!40000 ALTER TABLE `clientpart` DISABLE KEYS */;
INSERT INTO `clientpart` VALUES (3,1,'2021-05-18'),(5,3,'2021-05-16'),(6,4,'2021-05-19'),(17,2,'2020-09-05'),(18,2,'2020-10-17'),(19,1,'2021-03-31'),(20,NULL,NULL),(21,4,'2021-05-01'),(22,4,'2021-02-06'),(23,1,'2020-07-03'),(24,3,'2021-02-01'),(25,3,'2020-06-15'),(26,NULL,NULL);
/*!40000 ALTER TABLE `clientpart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientpro`
--

DROP TABLE IF EXISTS `clientpro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientpro` (
  `idClient` int NOT NULL,
  `nomEntreprise` varchar(255) NOT NULL,
  `remise` decimal(10,2) NOT NULL,
  PRIMARY KEY (`idClient`),
  CONSTRAINT `FK_ClientPro_idClient_idClient` FOREIGN KEY (`idClient`) REFERENCES `client` (`idClient`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientpro`
--

LOCK TABLES `clientpro` WRITE;
/*!40000 ALTER TABLE `clientpro` DISABLE KEYS */;
INSERT INTO `clientpro` VALUES (1,'Décathlon',16.00),(2,'GoSport',10.00),(4,'Intersport',0.00),(7,'Sed Ltd',8.00),(8,'Auctor Ltd',17.00),(9,'In At Pede Company',20.00),(10,'Lorem Donec Company',4.00),(11,'Luctus Inc.',8.00),(12,'Enim Nisl Associates',18.00),(13,'Nam Associates',18.00),(14,'Nam Porttitor Associates',3.00),(15,'Suscipit Est Ac Corp.',3.00),(16,'Integer PC',3.00);
/*!40000 ALTER TABLE `clientpro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `commande`
--

DROP TABLE IF EXISTS `commande`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `commande` (
  `idCommande` int NOT NULL AUTO_INCREMENT,
  `dateECommande` date NOT NULL,
  `dateSCommande` date DEFAULT NULL,
  `idAdresse` int NOT NULL,
  `idClient` int NOT NULL,
  `idStatut` int NOT NULL,
  PRIMARY KEY (`idCommande`),
  KEY `FK_Commande_idAdresse_idAdresse` (`idAdresse`),
  KEY `FK_Commande_idClient_idClient` (`idClient`),
  KEY `FK_Commande_idStatut_idStatut_idx` (`idStatut`),
  CONSTRAINT `FK_Commande_idAdresse_idAdresse` FOREIGN KEY (`idAdresse`) REFERENCES `adresse` (`idAdresse`),
  CONSTRAINT `FK_Commande_idClient_idClient` FOREIGN KEY (`idClient`) REFERENCES `client` (`idClient`),
  CONSTRAINT `FK_Commande_idStatutt_idStatut` FOREIGN KEY (`idStatut`) REFERENCES `statut` (`idStatut`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commande`
--

LOCK TABLES `commande` WRITE;
/*!40000 ALTER TABLE `commande` DISABLE KEYS */;
INSERT INTO `commande` VALUES (1,'2020-09-20','2020-10-20',8,1,3),(2,'2021-09-05','2021-03-01',2,3,2),(3,'2021-01-29','2021-03-01',4,4,2),(4,'2021-01-29','2021-01-29',1,2,3),(6,'2021-01-29','2021-01-31',1,1,1),(7,'2021-05-18','2021-05-24',2,3,1),(8,'2021-05-19','2021-05-24',9,6,3),(9,'2021-05-19','2021-05-21',9,6,2),(10,'2021-05-19','2021-05-21',8,4,3),(11,'2021-05-19','2021-05-21',4,2,3);
/*!40000 ALTER TABLE `commande` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `compocommandepiece`
--

DROP TABLE IF EXISTS `compocommandepiece`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `compocommandepiece` (
  `idCommande` int NOT NULL,
  `idPiece` int NOT NULL,
  `quantite` int NOT NULL,
  PRIMARY KEY (`idCommande`,`idPiece`),
  KEY `FK_CompoCommandePiece_idPiece_idPiece` (`idPiece`),
  CONSTRAINT `FK_CompoCommandePiece_idModele_idModele` FOREIGN KEY (`idCommande`) REFERENCES `commande` (`idCommande`),
  CONSTRAINT `FK_CompoCommandePiece_idPiece_idPiece` FOREIGN KEY (`idPiece`) REFERENCES `piecedetachee` (`idPiece`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compocommandepiece`
--

LOCK TABLES `compocommandepiece` WRITE;
/*!40000 ALTER TABLE `compocommandepiece` DISABLE KEYS */;
INSERT INTO `compocommandepiece` VALUES (1,10,3),(2,8,30),(3,4,3),(3,5,4),(6,1,1),(6,30,2),(6,69,2),(7,5,1),(8,1,2),(8,6,2),(9,1,0),(10,1,4),(10,2,0),(11,1,3),(11,4,0);
/*!40000 ALTER TABLE `compocommandepiece` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `compocommandevelo`
--

DROP TABLE IF EXISTS `compocommandevelo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `compocommandevelo` (
  `idCommande` int NOT NULL,
  `idModele` int NOT NULL,
  `quantite` int NOT NULL,
  PRIMARY KEY (`idCommande`,`idModele`),
  KEY `FK_CompoCommandeVelo_idModele_idModele` (`idModele`),
  CONSTRAINT `FK_CompoCommandeVelo_idCommande_idCommande` FOREIGN KEY (`idCommande`) REFERENCES `commande` (`idCommande`),
  CONSTRAINT `FK_CompoCommandeVelo_idModele_idModele` FOREIGN KEY (`idModele`) REFERENCES `modele` (`idModele`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compocommandevelo`
--

LOCK TABLES `compocommandevelo` WRITE;
/*!40000 ALTER TABLE `compocommandevelo` DISABLE KEYS */;
INSERT INTO `compocommandevelo` VALUES (1,101,3),(2,112,9),(3,103,22),(3,104,8),(6,101,2),(7,101,0),(7,114,1),(11,101,5);
/*!40000 ALTER TABLE `compocommandevelo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `composition`
--

DROP TABLE IF EXISTS `composition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `composition` (
  `idModele` int NOT NULL,
  `idPieceDetachee` int NOT NULL,
  PRIMARY KEY (`idModele`,`idPieceDetachee`),
  KEY `FK_Composition_idPieceDetachee_idPiece` (`idPieceDetachee`),
  CONSTRAINT `FK_Composition_idModele_idModele` FOREIGN KEY (`idModele`) REFERENCES `modele` (`idModele`),
  CONSTRAINT `FK_Composition_idPieceDetachee_idPiece` FOREIGN KEY (`idPieceDetachee`) REFERENCES `piecedetachee` (`idPiece`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `composition`
--

LOCK TABLES `composition` WRITE;
/*!40000 ALTER TABLE `composition` DISABLE KEYS */;
INSERT INTO `composition` VALUES (101,1),(109,1),(103,2),(104,2),(109,2),(101,3),(102,3),(103,3),(104,3),(109,3),(114,3),(115,3),(110,4),(111,4),(112,4),(113,4),(101,5),(102,5),(103,5),(104,5),(114,5),(115,5),(105,6),(106,6),(107,6),(108,6),(109,6),(111,6),(112,6),(113,6),(105,7),(106,7),(107,7),(103,8),(109,8),(109,9),(110,10),(101,12),(102,12),(103,12),(104,12),(102,13),(105,14),(107,14),(106,15),(108,16),(110,18),(111,19),(112,20),(113,21),(114,22),(115,23),(105,24),(106,24),(107,24),(108,24),(105,25),(107,25),(106,26),(108,26),(110,28),(111,29),(112,29),(113,30),(114,31),(115,31),(101,32),(102,32),(108,32),(115,32),(104,33),(111,34),(112,35),(113,35),(114,36),(101,38),(102,38),(103,39),(104,39),(105,39),(106,39),(107,39),(108,39),(111,40),(112,41),(113,41),(108,42),(114,42),(115,42),(101,43),(102,43),(103,44),(104,45),(112,45),(105,46),(106,46),(107,46),(108,46),(110,47),(111,48),(112,48),(113,48),(114,49),(115,49),(101,50),(102,50),(103,51),(114,51),(115,51),(104,52),(105,53),(106,53),(107,53),(108,53),(105,54),(110,54),(111,55),(113,55),(105,56),(106,56),(107,56),(108,56),(110,57),(111,58),(112,58),(113,58),(101,59),(102,59),(114,59),(115,59),(105,60),(106,60),(107,60),(108,60),(110,61),(111,62),(112,62),(113,62),(103,63),(104,63),(101,64),(102,64),(103,64),(107,65),(108,65),(110,67),(111,68),(112,68),(113,69);
/*!40000 ALTER TABLE `composition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contact`
--

DROP TABLE IF EXISTS `contact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contact` (
  `idContact` int NOT NULL AUTO_INCREMENT,
  `nomContact` varchar(255) NOT NULL,
  `prenomContact` varchar(255) NOT NULL,
  `emailContact` varchar(255) NOT NULL,
  `telContact` varchar(255) NOT NULL,
  PRIMARY KEY (`idContact`)
) ENGINE=InnoDB AUTO_INCREMENT=133 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contact`
--

LOCK TABLES `contact` WRITE;
/*!40000 ALTER TABLE `contact` DISABLE KEYS */;
INSERT INTO `contact` VALUES (1,'Dupont','Sylvie','sylvie@dupont.com','0102030405'),(2,'Dujardinette','Jeannette','jean@dujardin.com','0233445566'),(3,'Cotillard','Marionnette','marion@cotillard.com','0344556677'),(7,'Adjani','Isabelle','isabelle@adjani.com','0788990011'),(10,'Merad','Kad','kad@merad.com','0102030405'),(11,'Client Test','Client Test','Client Test','0662630286'),(113,'Colin','Corentin','molestie.sodales.Mauris@Nunc.net','0356698298'),(114,'Noel','Cédric','cubilia@nunc.net','0691208989'),(115,'Berger','Théo','sapien.imperdiet@eteuismodet.ca','0904087194'),(116,'Gomez','Rosalie','Vivamus.nibh@molestie.edu','0980886457'),(117,'Hubert','Maïwenn','risus@Vivamuseuismodurna.ca','0683031052'),(118,'Menard','Maxence','malesuada@sed.edu','0743116568'),(119,'Arnaud','Léane','posuere@diam.edu','0850170045'),(120,'Picard','Léa','pretium.et@Maurisblandit.ca','0621344258'),(121,'Garnier','Cédric','neque.Sed@ac.ca','0663158859'),(122,'Barbier','Maëlle','In.faucibus.Morbi@sedestNunc.net','0727861191'),(123,'Faure','Françoise','Maecenas.ornare@uteros.ca','0888867002'),(124,'Caron','Adrien','a@estac.org','0602535971'),(125,'Chevallier','Simon','tincidunt.neque.vitae@laoreetlectusquis.com','0539931353'),(126,'Jacob','Solene','ornare.lectus.ante@Suspendisse.net','0231750737'),(127,'Klein','Mathéo','Lorem.ipsum@torquentper.co.uk','0312856888'),(128,'Klein','Dylan','Donec@Donecvitaeerat.org','0939432804'),(129,'Blanc','Marion','et@Suspendissedui.ca','0186848862'),(130,'Boucher','Erwan','in.hendrerit@Nunc.edu','0412989535'),(131,'Renaud','Carla','enim@ornare.ca','0841914288'),(132,'Leroy','Constant','cursus@semperet.com','0520290582');
/*!40000 ALTER TABLE `contact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fidelio`
--

DROP TABLE IF EXISTS `fidelio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fidelio` (
  `idFidelio` int NOT NULL AUTO_INCREMENT,
  `nomFidelio` varchar(255) NOT NULL,
  `descriptionFidelio` varchar(255) DEFAULT NULL,
  `coutFidelio` decimal(10,2) NOT NULL,
  `rabaisFidelio` decimal(10,2) NOT NULL,
  `dureeJoursFidelio` int NOT NULL,
  PRIMARY KEY (`idFidelio`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fidelio`
--

LOCK TABLES `fidelio` WRITE;
/*!40000 ALTER TABLE `fidelio` DISABLE KEYS */;
INSERT INTO `fidelio` VALUES (1,'Fidelio Classique','Pour clients fidèles',15.00,5.00,365),(2,'Fidelio Or','N/A',25.00,8.00,720),(3,'Fidelio Platine','N/A',60.00,10.00,720),(4,'Fidelio Max','N/A',100.00,12.00,780);
/*!40000 ALTER TABLE `fidelio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fournisseur`
--

DROP TABLE IF EXISTS `fournisseur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fournisseur` (
  `siretFournisseur` int NOT NULL AUTO_INCREMENT,
  `nomFournisseur` varchar(255) NOT NULL,
  `idContact` int NOT NULL,
  `idAdresse` int NOT NULL,
  `idLibelle` int NOT NULL,
  PRIMARY KEY (`siretFournisseur`),
  KEY `FK_Fournisseur_idContact_idContact` (`idContact`),
  KEY `FK_Fournisseur_idAdresse_idAdresse` (`idAdresse`),
  KEY `FK_Fournisseur_idLibelle_idLibelle` (`idLibelle`),
  CONSTRAINT `FK_Fournisseur_idAdresse_idAdresse` FOREIGN KEY (`idAdresse`) REFERENCES `adresse` (`idAdresse`),
  CONSTRAINT `FK_Fournisseur_idContact_idContact` FOREIGN KEY (`idContact`) REFERENCES `contact` (`idContact`),
  CONSTRAINT `FK_Fournisseur_idLibelle_idLibelle` FOREIGN KEY (`idLibelle`) REFERENCES `libelle` (`idLibelle`)
) ENGINE=InnoDB AUTO_INCREMENT=47303 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fournisseur`
--

LOCK TABLES `fournisseur` WRITE;
/*!40000 ALTER TABLE `fournisseur` DISABLE KEYS */;
INSERT INTO `fournisseur` VALUES (36201,'VeloBike',2,1,1),(47302,'Pedalixx',10,3,1);
/*!40000 ALTER TABLE `fournisseur` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fournisseurpiece`
--

DROP TABLE IF EXISTS `fournisseurpiece`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fournisseurpiece` (
  `idPiece` int NOT NULL,
  `idFournisseur` int NOT NULL,
  `prixPiece` decimal(10,2) NOT NULL,
  `delaiPiece` int NOT NULL,
  `numCatalogue` varchar(255) NOT NULL,
  PRIMARY KEY (`idPiece`,`idFournisseur`),
  KEY `FK_FournisseurPiece_idFournisseur_siretFournisseur` (`idFournisseur`),
  CONSTRAINT `FK_FournisseurPiece_idFournisseur_siretFournisseur` FOREIGN KEY (`idFournisseur`) REFERENCES `fournisseur` (`siretFournisseur`),
  CONSTRAINT `FK_FournisseurPiece_idPiece_idPiece` FOREIGN KEY (`idPiece`) REFERENCES `piecedetachee` (`idPiece`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fournisseurpiece`
--

LOCK TABLES `fournisseurpiece` WRITE;
/*!40000 ALTER TABLE `fournisseurpiece` DISABLE KEYS */;
INSERT INTO `fournisseurpiece` VALUES (1,36201,14.00,2,'Ref Catalogue'),(1,47302,15.00,2,'ABC'),(5,36201,15.00,5,'A351bc'),(6,36201,15.00,5,'3');
/*!40000 ALTER TABLE `fournisseurpiece` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grandeur`
--

DROP TABLE IF EXISTS `grandeur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `grandeur` (
  `idGrandeur` int NOT NULL AUTO_INCREMENT,
  `nomGrandeur` varchar(255) NOT NULL,
  PRIMARY KEY (`idGrandeur`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grandeur`
--

LOCK TABLES `grandeur` WRITE;
/*!40000 ALTER TABLE `grandeur` DISABLE KEYS */;
INSERT INTO `grandeur` VALUES (1,'Enfant'),(2,'Adultes'),(3,'Jeunes'),(4,'Hommes'),(5,'Dames'),(6,'Filles'),(7,'Garcons');
/*!40000 ALTER TABLE `grandeur` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `libelle`
--

DROP TABLE IF EXISTS `libelle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `libelle` (
  `idLibelle` int NOT NULL AUTO_INCREMENT,
  `nomLibelle` varchar(255) NOT NULL,
  PRIMARY KEY (`idLibelle`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `libelle`
--

LOCK TABLES `libelle` WRITE;
/*!40000 ALTER TABLE `libelle` DISABLE KEYS */;
INSERT INTO `libelle` VALUES (1,'Très bon'),(2,'Bon'),(3,'Moyen'),(4,'Mauvais');
/*!40000 ALTER TABLE `libelle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ligneproduit`
--

DROP TABLE IF EXISTS `ligneproduit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ligneproduit` (
  `idLigneProduit` int NOT NULL AUTO_INCREMENT,
  `nomLigneProduit` varchar(255) NOT NULL,
  PRIMARY KEY (`idLigneProduit`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ligneproduit`
--

LOCK TABLES `ligneproduit` WRITE;
/*!40000 ALTER TABLE `ligneproduit` DISABLE KEYS */;
INSERT INTO `ligneproduit` VALUES (1,'VTT'),(2,'Vélo de course'),(3,'Classique'),(4,'BMX');
/*!40000 ALTER TABLE `ligneproduit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modele`
--

DROP TABLE IF EXISTS `modele`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `modele` (
  `idModele` int NOT NULL AUTO_INCREMENT,
  `nomModele` varchar(255) NOT NULL,
  `idGrandeur` int NOT NULL,
  `prixUnitaireModele` decimal(10,2) NOT NULL,
  `idLigneProduit` int NOT NULL,
  `dateEModele` date NOT NULL,
  `dateSModele` date DEFAULT NULL,
  `quantiteModele` int NOT NULL,
  PRIMARY KEY (`idModele`),
  KEY `FK_Modele_idGrandeur_idGrandeur` (`idGrandeur`),
  KEY `FK_Modele_idLigneProduit_idLigneProduit` (`idLigneProduit`),
  CONSTRAINT `FK_Modele_idGrandeur_idGrandeur` FOREIGN KEY (`idGrandeur`) REFERENCES `grandeur` (`idGrandeur`),
  CONSTRAINT `FK_Modele_idLigneProduit_idLigneProduit` FOREIGN KEY (`idLigneProduit`) REFERENCES `ligneproduit` (`idLigneProduit`)
) ENGINE=InnoDB AUTO_INCREMENT=117 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modele`
--

LOCK TABLES `modele` WRITE;
/*!40000 ALTER TABLE `modele` DISABLE KEYS */;
INSERT INTO `modele` VALUES (101,'Kilimandjaro',1,495.00,1,'2021-05-07','2022-05-07',8),(102,'NorthPole',1,329.00,1,'2021-05-07','2022-05-07',5),(103,'MontBlanc',2,399.00,1,'2022-05-07','2022-05-07',4),(104,'Hooligan',2,199.00,1,'2020-12-10','2021-12-10',3),(105,'Orleans',3,229.00,2,'2021-10-06','2022-10-06',1),(106,'Orleans',4,229.00,2,'2021-10-06','2022-10-06',4),(107,'BlueJay',3,349.00,2,'2021-04-25','2022-04-25',7),(108,'BlueJay',4,349.00,2,'2021-04-25','2022-04-25',7),(109,'TrailExplorer',5,129.99,3,'2020-06-08','2021-06-08',10),(110,'TrailExplorer',6,129.00,3,'2020-06-08','2021-06-08',18),(111,'NightHawk',2,189.00,3,'2021-09-30','2022-09-30',5),(112,'TierraVerde',3,199.00,3,'2019-03-26','2020-03-26',9),(113,'TierraVerde',4,199.00,3,'2019-03-26','2020-03-26',9),(114,'MudZingerI',2,279.00,4,'2019-01-03','2020-01-03',12),(115,'MudZingerII',1,359.00,4,'2019-02-03','2020-02-03',9);
/*!40000 ALTER TABLE `modele` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `piecedetachee`
--

DROP TABLE IF EXISTS `piecedetachee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `piecedetachee` (
  `idPiece` int NOT NULL AUTO_INCREMENT,
  `refPiece` varchar(255) NOT NULL,
  `nomPiece` varchar(255) NOT NULL,
  `descriptionPiece` varchar(255) DEFAULT NULL,
  `dateEPiece` date NOT NULL,
  `dateSPiece` date DEFAULT NULL,
  `quantitePiece` int NOT NULL,
  `prixVentePiece` decimal(10,2) NOT NULL,
  PRIMARY KEY (`idPiece`)
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `piecedetachee`
--

LOCK TABLES `piecedetachee` WRITE;
/*!40000 ALTER TABLE `piecedetachee` DISABLE KEYS */;
INSERT INTO `piecedetachee` VALUES (1,'C32','CadreC32','Cadre','2020-06-07','2020-09-20',1,10.00),(2,'C76','Cadre76','Cadre','2020-06-07','2020-09-20',2,15.00),(3,'G7','Guidon7','Guidon','2019-02-20','2020-09-20',5,20.00),(4,'G12','Guidon12','Guidon','2019-02-20','2019-03-17',10,25.00),(5,'F3','Freins3','Frein','2018-06-23','2018-07-23',20,30.00),(6,'F9','Frein9','Frein','2018-06-23','2018-07-23',3,35.00),(7,'DV57','Derailleur57','Dérailleur avant','2020-02-10','2020-03-10',20,40.00),(8,'DV17','Derailleur17','Dérailleur avant','2020-02-10','2020-03-10',12,45.00),(9,'R32','Roue32','Roue','2019-08-15','2019-09-15',10,50.00),(10,'R40','Roue40','Roue','2019-08-15','2019-09-15',20,55.00),(11,'P3','PanierNum3','Panier','2021-05-09','2021-05-13',1,60.00),(12,'S88','Selle88','Selle','2021-05-18','2021-05-18',1,15.00),(13,'C34','Cadre34','Cadre','2021-05-03','2021-05-30',8,15.00),(14,'C43','Cadre43','Cadre','2021-02-09','2021-07-23',4,20.00),(15,'C44F','Cadre44F','Cadre','2021-05-18','2021-05-18',4,38.00),(16,'C43F','Cadre43F','Cadre','2020-12-09','2021-12-19',1,38.00),(17,'C01','Cadre01','Cadre','2021-04-07','2021-05-18',7,20.00),(18,'C02','Cadre02','Cadre','2021-05-18','2021-08-14',1,20.00),(19,'C15','Cadre15','Cadre','2021-05-04','2021-05-20',0,13.00),(20,'C87','Cadre87','Cadre','2020-12-09','2021-10-17',0,28.00),(21,'C87F','Cadre87F','Cadre','2021-04-14','2021-08-15',0,40.00),(22,'C25','Cadre25','Cadre','2021-05-18','2021-05-18',0,22.00),(23,'C26','Cadre26','Cadre','2021-02-09','2021-10-09',0,28.00),(24,'G9','Guidon9','Guidon','2020-07-07','2021-11-03',0,39.00),(25,'S37','Selle37','Selle','2021-03-03','2021-05-18',0,8.00),(26,'S35','Selle35','Selle','2021-03-10','2021-05-18',0,40.00),(27,'S02','Selle02','Selle','2021-02-03','2021-07-15',2,20.00),(28,'S03','Selle03','Selle','2021-03-05','2021-08-14',2,30.00),(29,'S36','Selle36','Selle','2020-07-08','2021-12-11',6,36.00),(30,'S34','Selle34','Selle','2020-09-22','2021-09-16',0,44.00),(31,'S87','Selle87','Selle','2020-08-22','2020-09-29',4,37.00),(32,'DV133','Derailleur133','Derailleur avant','2020-05-14','2020-06-23',2,55.00),(33,'DV87','Derailleur87','Derailleur avant','2019-09-22','2020-02-01',6,20.00),(34,'DV15','Derailleur15','Derailleur avant','2020-09-23','2021-03-01',4,15.00),(35,'DV41','Derailleur41','Derailleur avant','2021-05-18','2021-06-23',4,30.00),(36,'DV132','Derailleur132','Derailleur avant','2019-02-09','2019-06-03',3,60.00),(37,'DV133','Derailleur133','Derailleur avant','2020-12-23','2021-01-22',2,39.00),(38,'DR56','Derailleur56','Derailleur arriere','2020-09-26','2021-09-26',3,56.00),(39,'DR87','DerailleurR87','Derailleur arriere','2019-03-23','2020-03-29',3,33.00),(40,'DR23','DerailleurR23','Derailleur arriere','2019-04-25','2021-05-18',12,35.00),(41,'DR76','DerailleurR76','Derailleur arriere','2020-05-18','2020-06-20',5,76.00),(42,'DR52','DerailleurR52','Derailleur arriere','2020-09-23','2020-10-24',1,52.00),(43,'R45','RoueV45','Roue avant','2021-05-18','2021-05-18',3,45.00),(44,'R48','RoueV48','Roue avant','2019-02-13','2019-03-22',1,15.00),(45,'R12','RoueV12','Roue avant','2020-12-12','2021-01-12',5,12.00),(46,'R19','RoueV19','Roue avant','2019-09-19','2020-09-19',2,19.00),(47,'R1','RoueV1','Roue avant','2019-10-10','2020-10-10',3,10.00),(48,'R11','RoueV11','Roue avant','2019-11-11','2020-11-11',6,11.00),(49,'R44','RoueV44','Roue avant','2014-04-04','2015-04-04',2,44.00),(50,'R46','RoueR46','Roue arriere','2016-06-16','2016-06-26',2,16.00),(51,'R47','RoueR47','Roue arriere','2017-07-17','2018-07-17',3,17.00),(52,'R32','RoueR32','Roue arriere','2002-02-22','2003-02-22',4,32.00),(53,'R18','RoueR18','Roue arriere','2021-05-18','2021-05-18',3,18.00),(54,'R2','RoueR2','Roue arriere','2013-10-20','2014-05-20',2,200.00),(55,'R12','RoueR12','Roue arriere','2012-12-12','2012-12-22',2,12.00),(56,'R02','Reflecteur2','Refelcteur','2020-10-20','2020-11-20',1,20.00),(57,'R09','Reflecteur9','Reflecteur','2009-09-19','2010-09-19',4,19.00),(58,'R10','Reflecteur10','Reflecteur','2010-10-10','2011-10-10',3,10.00),(59,'P12','Pedalier12','Pedalier','2012-12-12','2012-02-22',4,12.00),(60,'P34','Pedalier34','Pedalier','2004-04-24','2005-05-25',9,34.00),(61,'P1','Pedalier1','Pedalier','2010-10-10','2010-11-10',3,10.00),(62,'P15','Pedalier15','Pedalier','2005-05-15','2005-05-25',1,15.00),(63,'P12','Pedalier12','Pedalier','2021-05-18','2021-05-18',2,12.00),(64,'O2','Ordinateur2','Ordinateur','2020-12-20','2021-01-20',4,20.00),(65,'04','Ordinateur4','Ordinateur','2004-04-04','2004-04-24',8,40.00),(66,'S01','Panier1','Panier','2011-01-01','2011-03-06',1,70.00),(67,'S05','Panier5','Panier','2005-05-05','2005-06-25',6,50.00),(68,'S74','Panier74','Panier','2004-04-14','2004-05-14',4,24.00),(69,'S73','Panier73','Panier','2003-03-23','2003-06-26',1,23.00);
/*!40000 ALTER TABLE `piecedetachee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `statut`
--

DROP TABLE IF EXISTS `statut`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `statut` (
  `idStatut` int NOT NULL AUTO_INCREMENT,
  `nomStatut` varchar(255) NOT NULL,
  PRIMARY KEY (`idStatut`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `statut`
--

LOCK TABLES `statut` WRITE;
/*!40000 ALTER TABLE `statut` DISABLE KEYS */;
INSERT INTO `statut` VALUES (1,'En cours de préparation'),(2,'Terminée'),(3,'Annulée');
/*!40000 ALTER TABLE `statut` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'velomax'
--

--
-- Dumping routines for database 'velomax'
--
/*!50003 DROP PROCEDURE IF EXISTS `AddComposition` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddComposition`(
	IN idM INT, 
    IN idP INT)
BEGIN
	IF NOT EXISTS (
    select * from composition 
    where idModele = idM 
    and idPieceDetachee = idP)
    THEN insert into composition values(idM, idP);
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AddModelesToCommande` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddModelesToCommande`(
	in idC INT,
    in idM INT, 
    in qte INT)
BEGIN
	if exists (select * from compocommandevelo
    where idModele = idM and idCommande = idC)
    THEN update compocommandevelo set quantite = quantité + qte where idModele = idP and idCommande = idC;
    ELSE insert into compocommandevelo values (idC, idM, qte);
    END if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AddModeleToCommande` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddModeleToCommande`(
	in idC INT,
    in idM INT, 
    in qte INT)
BEGIN
	if exists (select * from compocommandevelo
    where idModele = idM and idCommande = idC)
    THEN update compocommandevelo set quantite = quantité + qte where idModele = idP and idCommande = idC;
    ELSE insert into compocommandevelo values (idC, idM, qte);
    END if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AddPiecesToCommande` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddPiecesToCommande`(
	in idC INT,
    in idP INT, 
    in qte INT)
BEGIN
	if exists (select * from compocommandepiece
    where idPiece = idP and idCommande = idC)
    THEN update compocommandepiece set quantite = quantite + qte where idPiece = idP and idCommande = idC;
    ELSE insert into compocommandepiece values (idC, idP, qte);
    END if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AddPieceToCommande` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddPieceToCommande`(
	in idC INT,
    in idP INT, 
    in qte INT)
BEGIN
	if exists (select * from compocommandepiece
    where idPiece = idP and idCommande = idC)
    THEN update compocommandepiece set quantite = quantite + qte where idPiece = idP and idCommande = idC;
    ELSE insert into compocommandepiece values (idC, idP, qte);
    END if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AfficherModelesPropre` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AfficherModelesPropre`()
BEGIN
	SELECT
		modele.NomModele as "Nom",
        grandeur.nomGrandeur as "Taille",
        ligneproduit.nomLigneProduit as "Ligne de produit",
        prixUnitaireModele as "Prix Unitaire",
        dateEModele as "Date d'introduction",
        dateSModele as "Data de sortie",
        quantiteModele as "Quantité en stock"
	FROM modele
    NATURAL JOIN grandeur
    NATURAL JOIN ligneproduit
    ORDER BY modele.nomModele;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CreateClientPart` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateClientPart`(
	IN id INT, 
    IN idC INT, 
    IN idA INT, 
    IN nom VARCHAR(255),
    IN prenom VARCHAR(255),
    IN tel VARCHAR(255),
    IN mail VARCHAR(255),
    IN l1 VARCHAR(255),
    IN l2 VARCHAR(255),
    IN cp VARCHAR(255),
    IN ville VARCHAR(255),
    IN province VARCHAR(255),
    IN pays VARCHAR(255),
    IN adherance DATE,
    IN idF INT,
    IN df DATE)
BEGIN
	IF NOT EXISTS(select * from adresse where idAdresse = idA)
    THEN insert into adresse values (idA, l1, l2, ville, cp, province, pays);
    END IF;
    
    IF NOT EXISTS(select * from contact where idContact = idC)
    THEN insert into contact values (idC, nom, prenom, mail, tel);
    END IF;
    
    insert into client values (id, idA, idC, adherance);
    
    IF (idF = -1) THEN insert into clientpart values(id, null, null);
    ELSE insert into clientpart values(id, idF, df);
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CreateClientPro` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateClientPro`(
	IN id INT, 
    IN idC INT, 
    IN idA INT, 
    IN nom VARCHAR(255),
    IN prenom VARCHAR(255),
    IN tel VARCHAR(255),
    IN mail VARCHAR(255),
    IN l1 VARCHAR(255),
    IN l2 VARCHAR(255),
    IN cp VARCHAR(255),
    IN ville VARCHAR(255),
    IN province VARCHAR(255),
    IN pays VARCHAR(255),
    IN adherance DATE,
    IN entreprise VARCHAR(255),
    IN rem DECIMAL(10,2))
BEGIN
	IF NOT EXISTS(select * from adresse where idAdresse = idA)
    THEN insert into adresse values (idA, l1, l2, ville, cp, province, pays);
    END IF;
    
    IF NOT EXISTS(select * from contact where idContact = idC)
    THEN insert into contact values (idC, nom, prenom, mail, tel);
    END IF;
    
    insert into client values (id, idA, idC, adherance);
    
    insert into clientpro values(id, entreprise, rem);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CreateCommande` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateCommande`(
	IN id INT,
    IN dE DATE,
    IN dS DATE,
    IN idC INT, 
    IN idS INT,
    IN idA INT, 
    IN l1 VARCHAR(255),
    IN l2 VARCHAR(255),
    IN cp VARCHAR(255),
    IN ville VARCHAR(255),
    IN province VARCHAR(255),
    IN pays VARCHAR(255))
BEGIN
	IF NOT EXISTS(select * from adresse where idAdresse = idA)
    THEN insert into adresse values (idA, l1, l2, ville, cp, province, pays);
    END IF;
    
    insert into commande
    values (id, dE, dS, idA, idC, idS);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CreateComposition` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateComposition`(
	IN idM INT, 
    IN idP INT)
BEGIN
	IF NOT EXISTS (
    select * from composition 
    where idModele = idM 
    and idPieceDetachee = idP)
    THEN insert into composition values(idM, idP);
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CreateFidelio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateFidelio`(
	IN id INT,
    IN nom VARCHAR(255),
    IN d VARCHAR(255),
    IN cout DECIMAL(10,2),
    IN rabais DECIMAL(10,2), 
    IN duree INT)
BEGIN
	INSERT INTO fidelio VALUES (id, nom, d, cout, rabais, duree);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CreateFournisseur` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateFournisseur`(
	IN siret INT, 
    IN idC INT, 
    IN idA INT, 
    IN idL INT, 
    IN nom VARCHAR(255),
    IN prenom VARCHAR(255),
    IN tel VARCHAR(255),
    IN mail VARCHAR(255),
    IN l1 VARCHAR(255),
    IN l2 VARCHAR(255),
    IN cp VARCHAR(255),
    IN ville VARCHAR(255),
    IN province VARCHAR(255),
    IN pays VARCHAR(255),
    IN nomF VARCHAR(255))
BEGIN
	IF NOT EXISTS(select * from adresse where idAdresse = idA)
    THEN insert into adresse values (idA, l1, l2, ville, cp, province, pays);
    END IF;
    
    IF NOT EXISTS(select * from contact where idContact = idC)
    THEN insert into contact values (idC, nom, prenom, mail, tel);
    END IF;
    
    insert into fournisseur values(siret, nomF, idC, idA, idL);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CreateFournisseurPiece` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`RemoteUser`@`%` PROCEDURE `CreateFournisseurPiece`(
	IN idF INT,
    IN idP INT,
    IN prix DECIMAL(10,2),
    IN delai INT,
    IN noC VARCHAR(255))
BEGIN
	INSERT INTO fournisseurpiece VALUES (idP,idF,prix,delai,noC);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CreateModele` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateModele`(
	IN id INT,
    IN nom VARCHAR(255),
    IN idG INT,
    IN prix decimal(10,2),
    IN de DATE,
    IN ds DATE,
    IN qte INT,
    IN idL INT)
BEGIN
	INSERT INTO modele VALUES (id, nom, idG, prix, idL, de, de, qte);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CreatePiece` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreatePiece`(
	IN id INT,
    IN ref VARCHAR(255),
    IN nom VARCHAR(255),
    IN d VARCHAR(255),
    IN de DATE,
    IN ds DATE,
    IN qte INT,
    IN prix DECIMAL(10,2))
BEGIN
	INSERT INTO piecedetachee VALUES (id, ref, nom, d, de, ds, qte, prix);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `EditClientPart` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `EditClientPart`(
	IN id INT, 
    IN idC INT, 
    IN idA INT, 
    IN idF INT, 
    IN nom VARCHAR(255),
    IN prenom VARCHAR(255),
    IN tel VARCHAR(255),
    IN mail VARCHAR(255),
    IN l1 VARCHAR(255),
    IN l2 VARCHAR(255),
    IN cp VARCHAR(255),
    IN ville VARCHAR(255),
    IN province VARCHAR(255),
    IN pays VARCHAR(255),
    IN adherance DATE,
    IN df DATE)
BEGIN
	set @idAToRemove = 0;
    set @idCToRemove = 0;
    select idAdresse INTO @idAToRemove from client where idClient = id;
    select idContact INTO @idCToRemove from client where idClient = id;
    
	update contact
    set nomContact = nom, prenomContact = prenom, emailContact = mail, telContact = tel 
    where idContact = idC;
    
    update adresse 
    set ligne1Adresse = l1, ligne2Adresse = l2, villeAdresse = ville, codePostalAdresse = cp, provinceAdresse = province, paysAdresse = pays
    where idAdresse = idA;
    
    update client
    set dateAdheranceClient = adherance
    where idClient = id;
    
    IF (idF = -1) THEN update clientpart set idFidelio = null, dateDebutFidelio = null where idClient = id;
    ELSE update clientpart set idFidelio = idF, dateDebutFidelio = df where idClient = id;
    END IF;
    
    call RemoveAdresse(@idAToRemove);
    call RemoveContact(@idCToRemove);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `EditClientPro` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `EditClientPro`(
	IN id INT, 
    IN idC INT, 
    IN idA INT, 
    IN nom VARCHAR(255),
    IN prenom VARCHAR(255),
    IN tel VARCHAR(255),
    IN mail VARCHAR(255),
    IN l1 VARCHAR(255),
    IN l2 VARCHAR(255),
    IN cp VARCHAR(255),
    IN ville VARCHAR(255),
    IN province VARCHAR(255),
    IN pays VARCHAR(255),
    IN adherance DATE,
    IN entreprise VARCHAR(255),
    IN rem DECIMAL(10,2))
BEGIN
	set @idAToRemove = 0;
    set @idCToRemove = 0;
    select idAdresse INTO @idAToRemove from client where idClient = id;
    select idContact INTO @idCToRemove from client where idClient = id;
    
	update contact
    set nomContact = nom, prenomContact = prenom, emailContact = mail, telContact = tel 
    where idContact = idC;
    
    update adresse 
    set ligne1Adresse = l1, ligne2Adresse = l2, villeAdresse = ville, codePostalAdresse = cp, provinceAdresse = province, paysAdresse = pays
    where idAdresse = idA;
    
    update client
    set dateAdheranceClient = adherance
    where idClient = id;
    
    update clientpro
    set nomEntreprise = entreprise, remise = rem
    where idClient = id;
    
    call RemoveAdresse(@idAToRemove);
    call RemoveContact(@idCToRemove);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `EditCommandeDueDate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `EditCommandeDueDate`(
	IN idC INT,
    IN newDs DATE)
BEGIN
	update commande
    set dateSCommande = newDs
    where idCommande = idC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `EditFidelio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `EditFidelio`(
	IN id INT,
    IN nom VARCHAR(255),
    IN d VARCHAR(255),
    IN cout DECIMAL(10,2),
    IN rabais DECIMAL(10,2), 
    IN duree INT)
BEGIN
	update fidelio
    set nomFidelio = nom,
    descriptionFidelio = d,
    coutFidelio = cout,
    rabaisFidelio = rabais,
    dureeJoursFidelio = duree
    where idFidelio = id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `EditFournisseur` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `EditFournisseur`(
	IN siret INT, 
    IN idC INT, 
    IN idA INT, 
    IN idL INT, 
    IN nom VARCHAR(255),
    IN prenom VARCHAR(255),
    IN tel VARCHAR(255),
    IN mail VARCHAR(255),
    IN l1 VARCHAR(255),
    IN l2 VARCHAR(255),
    IN cp VARCHAR(255),
    IN ville VARCHAR(255),
    IN province VARCHAR(255),
    IN pays VARCHAR(255),
    IN nomF VARCHAR(255))
BEGIN
	set @idAToRemove = 0;
    set @idCToRemove = 0;
    select idAdresse INTO @idAToRemove from fournisseur where siretFournisseur = siret;
    select idContact INTO @idCToRemove from fournisseur where siretFournisseur = siret;

	update contact
    set nomContact = nom, prenomContact = prenom, emailContact = mail, telContact = tel 
    where idContact = idC;
    
    update adresse 
    set ligne1Adresse = l1, ligne2Adresse = l2, villeAdresse = ville, codePostalAdresse = cp, provinceAdresse = province, paysAdresse = pays
    where idAdresse = idA;
    
    update fournisseur
    set nomFournisseur = nomF, idLibelle = idL
    where siretFournisseur = siret;
    
    call RemoveAdresse(@idAToRemove);
    call RemoveContact(@idCToRemove);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `EditModele` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `EditModele`(
	IN id INT,
    IN nom VARCHAR(255),
    IN idG INT,
    IN prix DECIMAL(10,2),
    IN idL INT, 
    IN de DATE,
    IN ds DATE)
BEGIN
	update modele
    set nomModele = nom,
    idGrandeur = idG,
    prixUnitaireModele = prix,
    idLigneProduit = idL,
    dateEModele = de,
    dateSModele = ds
    where idModele = id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `EditPiece` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `EditPiece`(
	IN id INT,
    IN ref VARCHAR(255),
    IN nom VARCHAR(255),
    IN d VARCHAR(255),
    IN de DATE, 
    IN ds DATE,
    IN prix DECIMAL(10,2))
BEGIN
	update piecedetachee
    set refPiece = ref,
    nomPiece = nom,
    descriptionPiece = d,
    dateEPiece = de,
    dateSPiece = ds,
    prixVentePiece = prix
    where idPiece = id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetAllFromTable` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllFromTable`(
	IN tableName VARCHAR(255))
BEGIN
	SET @s = CONCAT('select * from ', tableName);
    PREPARE stmt1 FROM @s;
    EXECUTE stmt1;
    DEALLOCATE PREPARE stmt1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `HighestId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `HighestId`(
	IN tableName VARCHAR(255),
    OUT n INT)
BEGIN
	DECLARE colName VARCHAR(255);
	IF tableName = "piecedetachee" THEN set colName = "idPiece";
    ELSE set colname = concat("id", tableName);
    END IF;
    
	SET @n = 0;
	SET @s = concat("Select max(", colname, ") into @n from ", tableName);
    PREPARE stmt1 FROM @s;
    EXECUTE stmt1;
    select @n into n;
    DEALLOCATE PREPARE stmt1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveAdresse` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveAdresse`(IN idA INT)
BEGIN
	IF (NOT EXISTS(select idAdresse from client where idAdresse = idA)
    AND NOT EXISTS(select idAdresse from fournisseur where idAdresse = idA)
    AND NOT EXISTS(select idAdresse from commande where idAdresse = idA))
    THEN delete from adresse where idAdresse = idA;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveClient` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveClient`(
	IN id INT)
BEGIN
	DECLARE idA INT;
    DECLARE idC INT;
    select idAdresse INTO @idA from client where idClient = id;
    select idContact INTO @idC from client where idClient = id;
    
    delete clientpart, client
	from clientpart natural join client
	where client.idClient = id;
    delete clientpro, client
	from clientpro natural join client
	where client.idClient = id;
    
    call RemoveAdresse(@idA);
	call RemoveContact(@idC);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveCommande` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveCommande`(
	IN id INT)
BEGIN
	set @idA = 0;
    select idAdresse INTO @idA from commande where idCommande = id;
	delete from commande where commande.idCommande = id;
    call RemoveAdresse(@idA);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveComposition` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveComposition`(
	IN idM INT, 
    IN idP INT)
BEGIN
	delete from composition 
    where idModele = idM 
    and idPieceDetachee = idP;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveContact` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveContact`(IN idC INT)
BEGIN
	IF (NOT EXISTS(select idContact from client where idContact = idC)
    AND NOT EXISTS(select idContact from fournisseur where idContact = idC))
    THEN delete from contact where idContact = idC;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveFidelio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveFidelio`(
	IN id INT)
BEGIN
	delete from fidelio where fidelio.idFidelio = id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveFournisseur` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveFournisseur`(
	IN srt INT)
BEGIN    
	set @idA = 0;
    set @idC = 0;
    select idAdresse INTO @idA from fournisseur where siretFournisseur = srt;
    select idContact INTO @idC from fournisseur where siretFournisseur = srt;
    
    delete from fournisseur where fournisseur.siretFournisseur = srt;
    
	call RemoveAdresse(@idA);
	call RemoveContact(@idC);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveFournisseurPiece` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`RemoteUser`@`%` PROCEDURE `RemoveFournisseurPiece`(
	IN idP INT,
	IN idF INT)
BEGIN
	DELETE FROM fournisseurpiece WHERE idPiece=idP AND idFournisseur=idF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveModele` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveModele`(
	IN id INT)
BEGIN
	delete from composition
    where composition.idModele = id;
    delete from modele
    where modele.idModele = id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveOneModeleFromCommande` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveOneModeleFromCommande`(
	IN idC INT, 
    IN idM INT)
BEGIN
	if exists (select * from compocommandevelo
    where idModele = idM and idCommande = idC)
    THEN update compocommandevelo set quantite = quantite - 1 where idModele = idM and idCommande = idC;
    END if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveOnePieceFromCommande` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveOnePieceFromCommande`(
	IN idC INT, 
    IN idP INT)
BEGIN
	if exists (select * from compocommandepiece
    where idPiece = idP and idCommande = idC)
    THEN update compocommandepiece set quantite = quantite - 1 where idPiece = idP and idCommande = idC;
    END if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveOrder` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveOrder`(
	IN id INT)
BEGIN
	DECLARE idA INT;
    select idAdresse INTO @idA from client where idClient = id;
	delete from commande where commande.idCommande = id;
    call RemoveAdresse(@idA);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemovePiece` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemovePiece`(
	IN id INT)
BEGIN
	delete from piecedetachee where piecedetachee.idPiece = id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `TestRemoveAdresse` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `TestRemoveAdresse`(IN idA INT)
BEGIN
	IF (NOT EXISTS(select idAdresse from client where idAdresse = idA)
    AND NOT EXISTS(select idAdresse from client where idAdresse = idA)
    AND NOT EXISTS(select idAdresse from client where idAdresse = idA))
    THEN delete from adresse where idAdresse = idA;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UpdateCommandeStatut` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateCommandeStatut`(
	IN id INT,
    IN stat INT)
BEGIN
	UPDATE commande set idStatut = stat where idCommande = id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UpdateStockModele` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateStockModele`(
	IN id INT,
    IN qte INT)
BEGIN
	update modele set quantiteModele = qte where idModele = id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UpdateStockPiece` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateStockPiece`(
	IN id INT,
    IN qte INT)
BEGIN
	update piecedetachee set quantitePiece = qte where idPiece = id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-05-20  0:37:04
