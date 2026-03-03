CREATE TABLE UserInfo (
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL,
    Password VARCHAR(20) NOT NULL,

    CONSTRAINT CHK_UserName_Length CHECK (LEN(UserName) BETWEEN 1 AND 50),
    CONSTRAINT CHK_Role CHECK (Role IN ('Admin', 'Participant')),
    CONSTRAINT CHK_Password_Length 
        CHECK (LEN(Password) BETWEEN 6 AND 20)
);
INSERT INTO UserInfo VALUES('lavanya@gmail.com', 'Lavanya', 'Admin', 'admin123'),
INSERT INTO UserInfo VALUES('anji@gmail.com', 'Anji', 'Participant', 'anji123'),
INSERT INTO UserInfo VALUES('indu@gmail.com', 'indu Kumar', 'Participant', 'ravi456');
Select*from UserInfo;

CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY,
    EventName VARCHAR(50) NOT NULL,
    EventCategory VARCHAR(50) NOT NULL,
    EventDate DATETIME NOT NULL,
    Description VARCHAR(255) NULL,
    Status VARCHAR(20) NOT NULL,
    CONSTRAINT CHK_EventName_Length 
        CHECK (LEN(EventName) BETWEEN 1 AND 50),

    CONSTRAINT CHK_EventCategory_Length 
        CHECK (LEN(EventCategory) BETWEEN 1 AND 50),

    CONSTRAINT CHK_EventStatus 
        CHECK (Status IN ('Active', 'In-Active'))
);

INSERT INTO EventDetails VALUES('Future Coders Meetup', 'Technology', '2026-03-25 10:00:00', 'Interactive meetup for students who love coding', 'Active')
INSERT INTO EventDetails VALUES('FitLife Awareness Day', 'Health', '2026-04-18 09:00:00', 'Sessions on fitness, nutrition and mental wellness', 'Active'),


CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY ,
    SpeakerName VARCHAR(50) NOT NULL,

    CONSTRAINT CHK_SpeakerName_Length 
        CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
);


CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,

    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL,
    SpeakerId INT NOT NULL,
    Description VARCHAR(255) NULL,

    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,

    SessionUrl VARCHAR(255) NULL,
    CONSTRAINT CHK_SessionTitle_Length 
        CHECK (LEN(SessionTitle) BETWEEN 1 AND 50),

    
    CONSTRAINT CHK_Session_Time 
        CHECK (SessionEnd > SessionStart),
    CONSTRAINT FK_Session_Event
        FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),

    CONSTRAINT FK_Session_Speaker
        FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
);


CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,

    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT NOT NULL,

    CHECK (IsAttended IN (0,1)),

    FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);
select *from ParticipantEventDetails;