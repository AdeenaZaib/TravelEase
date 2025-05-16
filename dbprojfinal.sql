--i230574
--i230674

CREATE DATABASE TravelEase;

CREATE TABLE Users (
	UserID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	FirstName VARCHAR(15),
	LastName VARCHAR(15),
	Email VARCHAR(50) UNIQUE,
	UserPassword VARCHAR(15),
	Contact VARCHAR(20) UNIQUE,
	City VARCHAR(50),
	Country VARCHAR(50),
	RegistrationDate DATE
);

BULK INSERT dbo.Users
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - Users.csv'
WITH (
    FIRSTROW = 2,            
    FIELDTERMINATOR = ',',    
    ROWTERMINATOR = '\n',    
    TABLOCK
);

DELETE FROM Users WHERE UserID = 102
DELETE FROM Traveller WHERE TravellerID = 102

SELECT * FROM Users

CREATE TABLE SystemAdmin (
	AdminID INT PRIMARY KEY NOT NULL,
	FOREIGN KEY (AdminID) REFERENCES Users(UserID)
);

BULK INSERT dbo.SystemAdmin
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - SystemAdmin.csv'
WITH (
    FIRSTROW = 2,             
    FIELDTERMINATOR = ',', 
    ROWTERMINATOR = '\n',    
    TABLOCK
);

CREATE TABLE Traveller (
	TravellerID INT PRIMARY KEY NOT NULL,
	Age INT,
	Budget DECIMAL,
	TravellerStatus VARCHAR(15)  DEFAULT 'Pending',
	CHECK (TravellerStatus IN ('Approved', 'Rejected', 'Pending')),
	FOREIGN KEY (TravellerID) REFERENCES Users(UserID)
);

BULK INSERT dbo.Traveller
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - Traveller.csv'
WITH (
    FIRSTROW = 2,             
    FIELDTERMINATOR = ',', 
    ROWTERMINATOR = '\n',    
    TABLOCK
);

CREATE TABLE TourOperator (
	TourOperatorID INT PRIMARY KEY NOT NULL,
	Comission DECIMAL,
	OperatorStatus VARCHAR(15) DEFAULT 'Pending',
	FOREIGN KEY (TourOperatorID) REFERENCES Users(UserID)
);

BULK INSERT dbo.TourOperator
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - TourOperator.csv'
WITH (
    FIRSTROW = 2,            
    FIELDTERMINATOR = ',',   
    ROWTERMINATOR = '\n',    
    TABLOCK
);

CREATE TABLE ServiceProvider (
	ServiceProviderID INT PRIMARY KEY NOT NULL,
	Comission DECIMAL,
	SPStatus VARCHAR(15) DEFAULT 'Pending',
	FOREIGN KEY (ServiceProviderID) REFERENCES Users(UserID)
);

BULK INSERT dbo.ServiceProvider
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - ServiceProvider.csv'
WITH (
    FIRSTROW = 2,           
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);

CREATE TABLE Destination (
	DestinationID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	DestinationName VARCHAR(100),
	Country VARCHAR(100),
	AddedDate DATE,
	AdminID INT,
	FOREIGN KEY (AdminID) REFERENCES SystemAdmin(AdminID)
);

BULK INSERT dbo.Destination
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - Destination.csv'
WITH (
    FIRSTROW = 2,         
    FIELDTERMINATOR = ',',   
    ROWTERMINATOR = '\n',  
    TABLOCK
);

SELECT * FROM Destination

CREATE TABLE Trip (
	TripID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	TripTitle VARCHAR(100),
	DestinationID INT,
	TourOperatorID INT,
	TripType VARCHAR(50),
	Capacity INT,
	CapacityType VARCHAR(50),
	PriceRange DECIMAL,
	Accessibility VARCHAR(50),
	StartDate DATE,
	EndDate DATE,
	CHECK (CapacityType IN ('Solo', 'Group', 'Corporation')),
	FOREIGN KEY (DestinationID) REFERENCES Destination(DestinationID),
	FOREIGN KEY (TourOperatorID) REFERENCES TourOperator(TourOperatorID)
);

BULK INSERT dbo.Trip
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - Trip.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);

CREATE TABLE TripBooking (
	BookingID INT IDENTITY(1, 1) PRIMARY KEY,
	TripID INT,
	TravellerID INT,
	BookingStatus VARCHAR(50),
	NoOfPeople INT,
	BookingDate DATE,
	FOREIGN KEY (TripID) REFERENCES Trip(TripID),
	FOREIGN KEY (TravellerID) REFERENCES Traveller(TravellerID)
);

DROP TABLE TripBooking

BULK INSERT dbo.TripBooking
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - TripBooking.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);

CREATE TABLE Payments (
	PaymentID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	TripBookingID INT NOT NULL,
	PaymentMethod VARCHAR(30),
	Amount DECIMAL,
	PaymentStatus VARCHAR(30),
	PaymentTimestamp DATETIME,
	FOREIGN KEY (TripBookingID) REFERENCES TripBooking(BookingID)
);

BULK INSERT dbo.Payments
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - Payments.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);

CREATE TABLE Inquiries(
	InquiryID INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
	TravellerID INT,
	Inquiry VARCHAR(250),
	InquiryTime DATETIME
	FOREIGN KEY (TravellerID) REFERENCES Traveller(TravellerID),
);

SELECT * FROM Inquiries

BULK INSERT dbo.Inquiries
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - Inquiries.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);

CREATE TABLE Responses(
	ResponseID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	InquiryID INT,
	OperatorID INT,
	Response VARCHAR(250),
	ResponseTime DATE,
	FOREIGN KEY(InquiryID) REFERENCES Inquiries(InquiryID),
	FOREIGN KEY(OperatorID) REFERENCES TourOperator(TourOperatorID)
);

DROP TABLE Responses

BULK INSERT dbo.Responses
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - Responses.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);

SELECT * FROM Responses



CREATE TABLE ActivityPass (
	PassID INT PRIMARY KEY NOT NULL,
	ActivityType VARCHAR(100),
	ActivityDesc VARCHAR(250),
	Discount DECIMAL,
	ValidFor INT,
	BookingID INT,
	FOREIGN KEY (BookingID) REFERENCES TripBooking(BookingID)
);

BULK INSERT dbo.ActivityPass
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - AcitivityPass.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);

CREATE TABLE ETickets (
	TicketID INT PRIMARY KEY NOT NULL,
	Descrip VARCHAR(100),
	Discount DECIMAL,
	ValidFor INT,
	BookingID INT,
	FOREIGN KEY (BookingID) REFERENCES TripBooking(BookingID)
);

BULK INSERT dbo.ETickets
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - ETickets.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);

CREATE TABLE HotelVoucher (
	VoucherID INT PRIMARY KEY NOT NULL,
	Descrip VARCHAR(250),
	Discount DECIMAL,
	ValidFor INT,
	BookingID INT,
	FOREIGN KEY (BookingID) REFERENCES TripBooking(BookingID)
);

BULK INSERT dbo.HotelVoucher
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - HotelVoucher.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);


CREATE TABLE TripServices (
	ServiceID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	ServiceProviderID INT NOT NULL,
	FOREIGN KEY (ServiceProviderID) REFERENCES ServiceProvider(ServiceProviderID)
);

BULK INSERT dbo.TripServices
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - TripServices.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);
----------------------------
CREATE TABLE Hotel (
	HotelID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	ServiceID INT,
	HotelName VARCHAR(100),
	HotelAddress VARCHAR(200),
	Contact VARCHAR(20),
	JoiningDate DATE,
	TotalRooms INT,
	StayRate DECIMAL (10, 2),
	FOREIGN KEY (ServiceID) REFERENCES TripServices(ServiceID)
);

DROP TABLE Hotel

BULK INSERT dbo.Hotel
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - Hotel.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);
-----------------------------------
CREATE TABLE TourGuide (
	GuideID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	ServiceID INT,
	GuideName VARCHAR(100),
	Contact VARCHAR(15),
	JoiningDate DATE,
	GuideAvailability VARCHAR(15) DEFAULT 'Available',
	HourlyRate DECIMAL,
	Experience VARCHAR(250),
	FOREIGN KEY (ServiceID) REFERENCES TripServices(ServiceID)
);

BULK INSERT dbo.TourGuide
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - TourGuide.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);

CREATE TABLE Transport (
	RegID INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
	ServiceID INT,
	TransportType VARCHAR(50),
	Contact VARCHAR(15),
	TAvailability VARCHAR(15) DEFAULT 'Available',
	Rate DECIMAL,
	CHECK (TransportType IN ('Bus', 'Airplane', 'Train')),
	FOREIGN KEY (ServiceID) REFERENCES TripServices(ServiceID)
);

BULK INSERT dbo.Transport
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - Transport.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);

DROP TABLE Transport

CREATE TABLE TransportLog (
	RegID INT,
	LogDate DATE NOT NULL,
	ExpectedTimeOfDeparture DATETIME,
	TimeOfDeparture DATETIME,
	ExpectedTimeOfArrival DATETIME,
	TimeOfArrival DATETIME,
	FOREIGN KEY (RegID) REFERENCES Transport(RegID),
	PRIMARY KEY(RegID, LogDate)
);

DROP TABLE TransportLog

BULK INSERT dbo.TransportLog
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - TransportLog.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);
-----------------------------------------
CREATE TABLE Rooms (
	RoomNo INT,
	HotelID INT,
	OccupancyStatus VARCHAR(100) DEFAULT 'Vacant',
	ExtraCharges DECIMAL,
	PRIMARY KEY(RoomNo, HotelID),
	CHECK (OccupancyStatus IN ('Occupied', 'Reserved', 'Vacant')),
	FOREIGN KEY (HotelID) REFERENCES Hotel(HotelID)
);

DROP TABLE Rooms

BULK INSERT dbo.Rooms
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - Rooms.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);
-----------------------------------------------
CREATE TABLE Meals (
	MealName VARCHAR(50),
	Timings DATETIME,
	ServiceID INT,
	MealDesc VARCHAR(200),
	PRIMARY KEY (MealName, Timings),
	FOREIGN KEY (ServiceID) REFERENCES TripServices(ServiceID)
);

BULK INSERT dbo.Meals
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - Meals.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);

CREATE TABLE ServicesBooked (
	ServiceID INT NOT NULL,
	TourOperatorID INT NOT NULL,
	TravellerID INT NOT NULL,
	BookingStatus VARCHAR(50),
	BookingDate DATE,
	PRIMARY KEY (ServiceID, TourOperatorID, TravellerID),
	FOREIGN KEY (ServiceID) REFERENCES TripServices(ServiceID),
	FOREIGN KEY (TourOperatorID) REFERENCES TourOperator(TourOperatorID),
	FOREIGN KEY (TravellerID) REFERENCES Traveller(TravellerID),
);

SELECT * FROM ServicesBooked

BULK INSERT dbo.ServicesBooked
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - ServicesBooked.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    TABLOCK
);

CREATE TABLE Reviews (
	ReviewID INT IDENTITY(1,1) PRIMARY KEY,
	TravellerID INT,
	TripID INT,
	TourOperatorID INT,
	GuideID INT,
	HotelID INT,
	FOREIGN KEY (GuideID) REFERENCES TourGuide(GuideID),
	FOREIGN KEY (HotelID) REFERENCES Hotel(HotelID),
	FOREIGN KEY (TourOperatorID) REFERENCES TourOperator(TourOperatorID),
	FOREIGN KEY (TravellerID) REFERENCES Traveller(TravellerID),
	FOREIGN KEY (TripID) REFERENCES Trip(TripID),
	UNIQUE (TravellerID, TripID),
	UNIQUE (TravellerID, TripID, TourOperatorID ),
	UNIQUE (TravellerID, TripID, GuideID),
	UNIQUE (TravellerID, TripID, HotelID)
);

drop table Reviews
drop table HotelReviews
drop table GuideReviews
drop table TourOperatorReviews
drop table TripReviews

BULK INSERT dbo.Reviews
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - Reviews.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',
	KEEPNULLS,
    TABLOCK
);

CREATE TABLE TripReviews (
	TravellerID INT,
	TripID INT,
	TripRating INT,
	TripReview VARCHAR(100),
	PRIMARY KEY (TravellerID, TripID),
	FOREIGN KEY (TravellerID, TripID) REFERENCES Reviews(TravellerID, TripID)
);

BULK INSERT dbo.TripReviews
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - TripReviews.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',
	KEEPNULLS,
    TABLOCK
);

CREATE TABLE TourOperatorReviews (
	TravellerID INT,
	TripID INT,
	TourOperatorID INT,
	TourOperatorRating INT,
	TourOperatorReview VARCHAR(100),
	PRIMARY KEY (TravellerID, TripID, TourOperatorID),
	FOREIGN KEY (TravellerID, TripID, TourOperatorID) REFERENCES Reviews(TravellerID, TripID, TourOperatorID)
);
BULK INSERT dbo.TourOperatorReviews
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - TourOperatorReviews.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',
	KEEPNULLS,
    TABLOCK
);

CREATE TABLE GuideReviews (
	TravellerID INT,
	TripID INT,
	GuideID INT,
	GuideRating INT,
	GuideReview VARCHAR(100),
	PRIMARY KEY (TravellerID, TripID, GuideID),
	FOREIGN KEY (TravellerID, TripID, GuideID) REFERENCES Reviews(TravellerID, TripID, GuideID)
);

BULK INSERT dbo.GuideReviews
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - GuideReviews.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',
	KEEPNULLS,
    TABLOCK
);

SELECT * FROM GuideReviews

CREATE TABLE HotelReviews (
	TravellerID INT,
	TripID INT,
	HotelID INT,
	HotelRating INT,
	HotelReview VARCHAR(100),
	PRIMARY KEY (TravellerID, TripID, HotelID),
	FOREIGN KEY (TravellerID, TripID, HotelID) REFERENCES Reviews(TravellerID, TripID, HotelID)
);


BULK INSERT dbo.HotelReviews
FROM 'C:\Users\Adeena\Documents\SQL Server Management Studio\TEData\TravelEase_Populated_Full.xlsx - HotelReviews.csv'
WITH (
    FIRSTROW = 2,          
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',
	KEEPNULLS,
    TABLOCK
);

CREATE TABLE ActivityLog (
	LogID INT PRIMARY KEY NOT NULL,
	UserID INT NOT NULL,
	ActivityType VARCHAR(30)
	FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Reminders (
	RemID INT IDENTITY(1, 1) PRIMARY KEY,
	TravellerID INT,
	OperatorID INT,
	Rem VARCHAR(250),
	FOREIGN KEY (TravellerID) REFERENCES Traveller(TravellerID),
	FOREIGN KEY (OperatorID) REFERENCES TourOperator(TourOperatorID)
);

INSERT INTO Reminders (TravellerID, OperatorID, Rem) 
VALUES (17, 55, 'Your Hotel Booking is confirmed!')

INSERT INTO Reminders (TravellerID, OperatorID, Rem) 
VALUES (17, 48, 'Your Transport Booking is confirmed!')

INSERT INTO TripBooking (TripID, TravellerID, BookingStatus, NoOfPeople, BookingDate)
VALUES (17, 17, 'InProcess', 1, GETDATE())

SELECT * FROM Reminders

SELECT * FROM TripBooking WHERE TravellerID = 17

CREATE TABLE AuditTrail (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,  -- Auto incremented ID
    Action VARCHAR(10),                      -- Action type (INSERT, UPDATE, DELETE)
    TableName VARCHAR(100),                  -- The table name
    RecordID INT,                            -- ID of the affected record
    ColumnName VARCHAR(100),                 -- The column that was changed
    OldValue VARCHAR(MAX),                   -- The old value (for UPDATE/DELETE)
    NewValue VARCHAR(MAX),                   -- The new value (for INSERT/UPDATE)
    ChangedBy VARCHAR(100),                  -- User who made the change
    ChangeDate DATETIME DEFAULT GETDATE(),   -- Timestamp
    Reason VARCHAR(255)                      -- Optional reason for the change
);

-- HOTEL TRIGGERS
CREATE TRIGGER trg_InsertHotel
ON Hotel
FOR INSERT
AS
BEGIN
    DECLARE @HotelID INT, @ServiceID INT, @HotelName VARCHAR(100), 
            @HotelAddress VARCHAR(200), @Contact VARCHAR(20), 
            @JoiningDate DATE, @TotalRooms INT, @StayRate DECIMAL(10, 2);

    -- Get inserted values
    SELECT @HotelID = HotelID, @ServiceID = ServiceID, 
           @HotelName = HotelName, @HotelAddress = HotelAddress, 
           @Contact = Contact, @JoiningDate = JoiningDate, 
           @TotalRooms = TotalRooms, @StayRate = StayRate
    FROM INSERTED;

    -- Insert into AuditTrail for the insert action
    INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
    VALUES ('INSERT', 'Hotel', @HotelID, 'All Fields', NULL, 
            CONCAT('HotelID: ', @HotelID, ', ServiceID: ', @ServiceID, 
                   ', HotelName: ', @HotelName, ', HotelAddress: ', @HotelAddress, 
                   ', Contact: ', @Contact, ', JoiningDate: ', @JoiningDate, 
                   ', TotalRooms: ', @TotalRooms, ', StayRate: ', @StayRate), 
            1, GETDATE());
END;



CREATE TRIGGER trg_UpdateHotel
ON Hotel
FOR UPDATE
AS
BEGIN
    DECLARE @HotelID INT, @ColumnName VARCHAR(100), 
            @OldValue VARCHAR(MAX), @NewValue VARCHAR(MAX);

    -- Log each changed column
    IF UPDATE(HotelName)
    BEGIN
        SELECT @HotelID = i.HotelID, 
               @OldValue = d.HotelName, 
               @NewValue = i.HotelName
        FROM INSERTED i
        JOIN DELETED d ON i.HotelID = d.HotelID;

        INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
        VALUES ('UPDATE', 'Hotel', @HotelID, 'HotelName', @OldValue, @NewValue, SYSTEM_USER, GETDATE());
    END

    IF UPDATE(HotelAddress)
    BEGIN
        SELECT @HotelID = i.HotelID, 
               @OldValue = d.HotelAddress, 
               @NewValue = i.HotelAddress
        FROM INSERTED i
        JOIN DELETED d ON i.HotelID = d.HotelID;

        INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
        VALUES ('UPDATE', 'Hotel', @HotelID, 'HotelAddress', @OldValue, @NewValue, SYSTEM_USER, GETDATE());
    END

    IF UPDATE(Contact)
    BEGIN
        SELECT @HotelID = i.HotelID, 
               @OldValue = d.Contact, 
               @NewValue = i.Contact
        FROM INSERTED i
        JOIN DELETED d ON i.HotelID = d.HotelID;

        INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
        VALUES ('UPDATE', 'Hotel', @HotelID, 'Contact', @OldValue, @NewValue, SYSTEM_USER, GETDATE());
    END

    IF UPDATE(JoiningDate)
    BEGIN
        SELECT @HotelID = i.HotelID, 
               @OldValue = d.JoiningDate, 
               @NewValue = i.JoiningDate
        FROM INSERTED i
        JOIN DELETED d ON i.HotelID = d.HotelID;

        INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
        VALUES ('UPDATE', 'Hotel', @HotelID, 'JoiningDate', @OldValue, @NewValue, SYSTEM_USER, GETDATE());
    END

    IF UPDATE(TotalRooms)
    BEGIN
        SELECT @HotelID = i.HotelID, 
               @OldValue = d.TotalRooms, 
               @NewValue = i.TotalRooms
        FROM INSERTED i
        JOIN DELETED d ON i.HotelID = d.HotelID;

        INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
        VALUES ('UPDATE', 'Hotel', @HotelID, 'TotalRooms', @OldValue, @NewValue, SYSTEM_USER, GETDATE());
    END

    IF UPDATE(StayRate)
    BEGIN
        SELECT @HotelID = i.HotelID, 
               @OldValue = d.StayRate, 
               @NewValue = i.StayRate
        FROM INSERTED i
        JOIN DELETED d ON i.HotelID = d.HotelID;

        INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
        VALUES ('UPDATE', 'Hotel', @HotelID, 'StayRate', @OldValue, @NewValue, SYSTEM_USER, GETDATE());
    END
END;

-- TRIP TABLE TRGIGERS
CREATE TRIGGER trg_InsertTrips
ON Trip
AFTER INSERT
AS
BEGIN
    DECLARE @TripID INT, @NewValue VARCHAR(MAX);
    
    -- Logging Insert operation
    SELECT @TripID = TripID, @NewValue = TripTitle
    FROM INSERTED;
    
    INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
    VALUES ('INSERT', 'Trips', @TripID, 'TripTitle', NULL, @NewValue, SYSTEM_USER, GETDATE());
END;

CREATE TRIGGER trg_UpdateTrips
ON Trip
AFTER UPDATE
AS
BEGIN
    DECLARE @TripID INT, @OldValue VARCHAR(MAX), @NewValue VARCHAR(MAX);
    
    -- Logging Update operation
    SELECT @TripID = i.TripID, @OldValue = d.TripTitle, @NewValue = i.TripTitle
    FROM INSERTED i
    JOIN DELETED d ON i.TripID = d.TripID;
    
    INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
    VALUES ('UPDATE', 'Trips', @TripID, 'TripTitle', @OldValue, @NewValue, SYSTEM_USER, GETDATE());
END;

CREATE TRIGGER trg_DeleteTrips
ON Trip
AFTER DELETE
AS
BEGIN
    DECLARE @TripID INT, @OldValue VARCHAR(MAX);
    
    -- Logging Delete operation
    SELECT @TripID = TripID, @OldValue = TripTitle
    FROM DELETED;
    
    INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
    VALUES ('DELETE', 'Trips', @TripID, 'TripName', @OldValue, NULL, SYSTEM_USER, GETDATE());
END;

-- TRIP BOOKING TABLE TRIGGERS
CREATE TRIGGER trg_InsertTripBookings
ON TripBooking
AFTER INSERT
AS
BEGIN
    DECLARE @BookingID INT, @NewValue VARCHAR(MAX);
    
    -- Logging Insert operation
    SELECT @BookingID = BookingID, @NewValue = BookingDate
    FROM INSERTED;
    
    INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
    VALUES ('INSERT', 'TripBookings', @BookingID, 'BookingDate', NULL, @NewValue, SYSTEM_USER, GETDATE());
END;

CREATE TRIGGER trg_UpdateTripBookings
ON TripBooking
AFTER UPDATE
AS
BEGIN
    DECLARE @BookingID INT, @OldValue VARCHAR(MAX), @NewValue VARCHAR(MAX);
    
    -- Logging Update operation
    SELECT @BookingID = i.BookingID, @OldValue = d.BookingDate, @NewValue = i.BookingDate
    FROM INSERTED i
    JOIN DELETED d ON i.BookingID = d.BookingID;
    
    INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
    VALUES ('UPDATE', 'TripBookings', @BookingID, 'BookingDate', @OldValue, @NewValue, SYSTEM_USER, GETDATE());
END;

CREATE TRIGGER trg_DeleteTripBookings
ON TripBooking
AFTER DELETE
AS
BEGIN
    DECLARE @BookingID INT, @OldValue VARCHAR(MAX);
    
    -- Logging Delete operation
    SELECT @BookingID = BookingID, @OldValue = BookingDate
    FROM DELETED;
    
    INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
    VALUES ('DELETE', 'TripBookings', @BookingID, 'BookingDate', @OldValue, NULL, SYSTEM_USER, GETDATE());
END;

-- TRIGGERS FOR GUIDES TABLE
CREATE TRIGGER trg_InsertGuides
ON TourGuide
AFTER INSERT
AS
BEGIN
    DECLARE @GuideID INT, @NewValue VARCHAR(MAX);
    
    -- Logging Insert operation
    SELECT @GuideID = GuideID, @NewValue = GuideName
    FROM INSERTED;
    
    INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
    VALUES ('INSERT', 'Guides', @GuideID, 'GuideName', NULL, @NewValue, SYSTEM_USER, GETDATE());
END;

CREATE TRIGGER trg_UpdateGuides
ON TourGuide
AFTER UPDATE
AS
BEGIN
    DECLARE @GuideID INT, @OldValue VARCHAR(MAX), @NewValue VARCHAR(MAX);
    
    -- Logging Update operation
    SELECT @GuideID = i.GuideID, @OldValue = d.GuideName, @NewValue = i.GuideName
    FROM INSERTED i
    JOIN DELETED d ON i.GuideID = d.GuideID;
    
    INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
    VALUES ('UPDATE', 'Guides', @GuideID, 'GuideName', @OldValue, @NewValue, SYSTEM_USER, GETDATE());
END;

CREATE TRIGGER trg_DeleteGuides
ON TourGuide
AFTER DELETE
AS
BEGIN
    DECLARE @GuideID INT, @OldValue VARCHAR(MAX);
    
    -- Logging Delete operation
    SELECT @GuideID = GuideID, @OldValue = GuideName
    FROM DELETED;
    
    INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
    VALUES ('DELETE', 'Guides', @GuideID, 'GuideName', @OldValue, NULL, SYSTEM_USER, GETDATE());
END;

-- TRANSPORT TRIGGERS
CREATE TRIGGER trg_InsertTransport
ON Transport
AFTER INSERT
AS
BEGIN
    DECLARE @TransportID INT, @NewValue VARCHAR(MAX);
    
    -- Logging Insert operation
    SELECT @TransportID = RegID, @NewValue = TransportType
    FROM INSERTED;
    
    INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
    VALUES ('INSERT', 'Transport', @TransportID, 'TransportType', NULL, @NewValue, SYSTEM_USER, GETDATE());
END;

CREATE TRIGGER trg_UpdateTransport
ON Transport
AFTER UPDATE
AS
BEGIN
    DECLARE @TransportID INT, @OldValue VARCHAR(MAX), @NewValue VARCHAR(MAX);
    
    -- Logging Update operation
    SELECT @TransportID = i.RegID, @OldValue = d.TransportType, @NewValue = i.TransportType
    FROM INSERTED i
    JOIN DELETED d ON i.RegID = d.RegID;
    
    INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
    VALUES ('UPDATE', 'Transport', @TransportID, 'TransportType', @OldValue, @NewValue, SYSTEM_USER, GETDATE());
END;

CREATE TRIGGER trg_DeleteTransport
ON Transport
AFTER DELETE
AS
BEGIN
    DECLARE @TransportID INT, @OldValue VARCHAR(MAX);
    
    -- Logging Delete operation
    SELECT @TransportID = RegID, @OldValue = TransportType
    FROM DELETED;
    
    INSERT INTO AuditTrail (Action, TableName, RecordID, ColumnName, OldValue, NewValue, ChangedBy, ChangeDate)
    VALUES ('DELETE', 'Transport', @TransportID, 'TransportType', @OldValue, NULL, SYSTEM_USER, GETDATE());
END;
