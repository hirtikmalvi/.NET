CREATE DATABASE HospitalManagementSystem;

USE HospitalManagementSystem;

CREATE TABLE Department(
	DepartmentId INT PRIMARY KEY IDENTITY(1,1),
	DepartmentName VARCHAR(50)
);

CREATE TABLE Doctor(
	DoctorId INT PRIMARY KEY IDENTITY(1,1),
	DoctorName VARCHAR(50),
	DepartmentId INT FOREIGN KEY REFERENCES Department(DepartmentId)
);

CREATE TABLE Patient(
	PatientId INT PRIMARY KEY IDENTITY(1,1),
	PatientName VARCHAR(50)
);

CREATE TABLE DoctorPatient(
	PatientId INT FOREIGN KEY REFERENCES Patient(PatientId),
	DoctorId INT FOREIGN KEY REFERENCES Doctor(DoctorId),
	AssignedDate DATETIME,
	PRIMARY KEY (PatientId, DoctorId)
);

CREATE TABLE Drug(
	DrugId INT PRIMARY KEY IDENTITY(1,1),
	DrugName VARCHAR(50)
);

CREATE TABLE PatientDrug(
	PatientId INT FOREIGN KEY REFERENCES Patient(PatientId),
	DrugId INT FOREIGN KEY REFERENCES Drug(DrugId),
	TimeOfDay VARCHAR(10),
	PRIMARY KEY (PatientId, DrugId)
);

SELECT * FROM Department;
SELECT * FROM Doctor;
SELECT * FROM Patient;
SELECT * FROM DoctorPatient;
SELECT * FROM Drug;
SELECT * FROM PatientDrug;

DROP TABLE Department;
DROP TABLE Doctor;
DROP TABLE Patient;
DROP TABLE DoctorPatient;
DROP TABLE Drug;
DROP TABLE PatientDrug;