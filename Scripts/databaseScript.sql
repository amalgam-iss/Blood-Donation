CREATE DATABASE AmalgamIss;

-- IMPORTANT: to have a DB selected you have 2 options. 
		      -- 1 -> double click on the DB you want (aka AmalgamIss) from the left side (Schemas) 
			  -- 2 -> before any query write USE <database_name>;

USE AmalgamIss;               
CREATE TABLE Users (
    Id BIGINT PRIMARY KEY IDENTITY(1,1) ,
    Email VARCHAR(255) DEFAULT NULL,
    Username VARCHAR(255) DEFAULT NULL,
    Password VARCHAR(32) DEFAULT NULL, -- IMPORTANT: passwords will be saved as md5 because safety. Google it for more information
    Type INT DEFAULT 0 -- IMPORTANT: 1 - DONORS
								  -- 2 - DOCTORS
                                  -- 3 - NURSE or STUFF or dunno
);

CREATE TABLE Addresses(
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	Country VARCHAR(255) DEFAULT NULL,
    City VARCHAR(255) DEFAULT NULL,
    Street VARCHAR(255) DEFAULT NULL,
    StreetNumber INT DEFAULT NULL
);

CREATE TABLE Donors (
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	UserId BIGINT NULL, -- IMPORTANT: in case we will have donors that are not registered yet
    Name VARCHAR(255) DEFAULT NULL,
    PhoneNumber BIGINT DEFAULT NULL,
    AddressId BIGINT NULL,
    BirthDate BIGINT DEFAULT NULL, -- IMPORTANT: we will use timestamp when we want to work with dates
    BloodType VARCHAR(2) DEFAULT NULL,
    Rh VARCHAR(1) DEFAULT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);

CREATE TABLE Diseases (
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(255) DEFAULT NULL,
    Type INT DEFAULT 0 -- smth like contagious or chronic or dunno
);

CREATE TABLE DonorDisease (
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
    DonorId BIGINT NULL,
    DiseaseId BIGINT NULL,
    FOREIGN KEY (DonorId) REFERENCES Donors(Id),
    FOREIGN KEY (DiseaseId) REFERENCES Diseases(Id)
);

CREATE TABLE Pacients (
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(255) DEFAULT NULL,
    BloodType VARCHAR(2) DEFAULT NULL,
    Rh VARCHAR(1) DEFAULT NULL,
    AddressId BIGINT NULL,
    FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);

CREATE TABLE DoctorPacients (
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	DoctorId BIGINT NULL,
    PacientId BIGINT NULL,
    FOREIGN KEY (DoctorId) REFERENCES Users(Id),
    FOREIGN KEY (PacientId) REFERENCES Pacients(Id)
);

CREATE TABLE BloodRequests (
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
    DoctorPacientId BIGINT NULL,
    BloodType VARCHAR(2) DEFAULT NULL,
    Rh VARCHAR(1) DEFAULT NULL,
    Quantity INT DEFAULT 0,
    Urgency INT DEFAULT 0,
    AddressId BIGINT NULL,
    Flags BIGINT DEFAULT 0, -- smth like 1 - reviewed by donation center like they received the request and are searching for compatibility
									  -- 2 - received by pacient
                                      -- 3 - expired 
                                      -- smth else
    FOREIGN KEY (DoctorPacientId) REFERENCES DoctorPacients(Id),
    FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);

CREATE TABLE Donations (
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
    DonorId BIGINT NULL,
    AddressId BIGINT NULL, -- maybe the donor will donate from another city than his address from identity card
    BloodType VARCHAR(2) DEFAULT NULL,
    Rh VARCHAR(1) DEFAULT NULL,
    Quantity INT DEFAULT 0,
    Date BIGINT DEFAULT NULL,
    Status INT DEFAULT 0,  -- like processing, in tests, etc
    Flags INT DEFAULT 0, -- like OK, not ok -> contact donor, etc
    FOREIGN KEY (DonorId) REFERENCES Donors(Id),
    FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);

CREATE TABLE ProcessingDonations (
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
    RequestId BIGINT NULL,
    DonationId BIGINT NULL,
    PersonelId BIGINT NULL,
    Flags BIGINT DEFAULT 0,
    FOREIGN KEY (RequestId) REFERENCES BloodRequests(Id),
    FOREIGN KEY (DonationId) REFERENCES Donations(Id),
    FOREIGN KEY (PersonelId) REFERENCES Users(Id)
);
    