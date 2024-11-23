--Creating a Database
Create Database CARS

--Creating Incidents Table 
Create Table Incidents(
IncidentID int identity Primary Key,
IncidentType Varchar(50),
IncidentDate Date,
Location Varchar(50),
Description Varchar(100),
Status Varchar(20),
VictimID int,
SuspectID int,
AgencyID int,
Foreign Key (VictimID) references Victims(VictimID),
Foreign Key (SuspectID) references Suspects(SuspectID),
Foreign Key (AgencyID) references LawEnforcementAgencies(AgencyID))

--Creating Victims Table
Create Table Victims(
VictimID int identity Primary Key,
FirstName Varchar(50),
LastName Varchar(50),
DateOfBirth Date,
Gender Varchar(50),
ContactInformation Varchar(100))

--Creating Suspects Table
Create Table Suspects(
SuspectID int identity Primary key,
FirstName Varchar(50),
LastName Varchar(50),
DateOfBirth Date,
Gender Varchar(50),
ContactInformation Varchar(100))

--Creating Law Enforcement Agencies Table
Create Table LawEnforcementAgencies(
AgencyID int identity Primary key,
AgencyName Varchar(100),
Jurisdiction Varchar(100),
ContactInformation Varchar(100),)

--Creating Officers Table
Create Table Officers(
OfficerID int identity Primary Key,
FirstName Varchar(50),
LastName Varchar(50),
BadgeNumber Varchar(50),
Rank Varchar(50),
ContactInformation Varchar(100),
AgencyID int,
Foreign Key (AgencyID) references LawEnforcementAgencies(AgencyID))

--Creating Evidence Table
Create Table Evidence (
EvidenceID int identity Primary Key,
Description Varchar(100),
LocationFound Varchar(100),
IncidentID int,
Foreign Key (IncidentID) references Incidents(IncidentID))

--Creating Reports Table
Create Table Reports(
ReportID int identity Primary Key,
IncidentID int,
ReportingOfficer int,
ReportDate Date,
ReportDetails Varchar(100),
Status varchar(20),
Foreign Key (IncidentID) references Incidents(IncidentID),
Foreign Key (ReportingOfficer) references Officers(OfficerID))
 
INSERT INTO Victims (FirstName, LastName, DateOfBirth, Gender, ContactInformation)
VALUES 
('John', 'Wick', '1985-05-15', 'Male', '4,Clock Tower Street'),
('Indhi', 'Rani', '1990-08-20', 'Female', '2/6,Wall Street'),
('Mark', 'Antony', '1978-12-30', 'Male', '27,Gandhi street')

INSERT INTO Suspects (FirstName, LastName, DateOfBirth, Gender, ContactInformation)
VALUES 
('Will', 'Smith', '1980-02-10', 'Male', '3, Rich Street'),
('Maha', 'Rani', '1992-03-25', 'Female', '6, Ganga Street'),
('Jack', 'Tomson', '1975-07-18', 'Male', '8/9, Apple Street')

INSERT INTO LawEnforcementAgencies (AgencyName, Jurisdiction, ContactInformation)
VALUES 
('Police Department', 'City', '9876543212'),
('State Police', 'State', '9876543211'),
('Central Police','Central','9876543210')

INSERT INTO Officers (FirstName, LastName, BadgeNumber, Rank, ContactInformation, AgencyID)
VALUES 
('Sara', 'James', 'A123', 'Sergeant', '0000044444', 1),
('Robert', 'Brown', 'B456', 'Detective', '4444400000', 2)

INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID, AgencyID)
VALUES 
('Robbery', '2023-01-10', 'Chennai', 'Armed robbery at a convenience store', 'Open', 1, 1, 1),
('Murder', '2023-02-20', 'Salem', 'Suspected murder, victim found in apartment', 'Under Investigation', 2, 2, 1),
('Theft', '2023-03-05', 'Coimbatore', 'Theft of electronics from a house', 'Closed', 3, 3, 2)

INSERT INTO Evidence (Description, LocationFound, IncidentID)
VALUES 
('Cash Register from robbery', 'KingShop', 1),
('Fingerprints from crime scene', 'Apartment Building, Springfield', 2),
('Stolen laptop', 'Victim house', 3)

INSERT INTO Reports (IncidentID, ReportingOfficer, ReportDate, ReportDetails, Status)
VALUES 
(1, 1, '2024-10-11', 'Armed robbery occurred at a convenience store.', 'Open'),
(2, 2, '2023-09-21', 'Victim found in apartment.', 'Finalized'),
(3, 1, '2023-09-06', 'Evidence collected from the crime scene.', 'closed')

