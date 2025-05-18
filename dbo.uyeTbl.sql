CREATE TABLE [dbo].[uyeTbl] (
    [UYEid]       INT          IDENTITY (1, 1) NOT NULL,
    [UYEisim]     VARCHAR (70) NOT NULL,
    [UYEtel]      INT NOT NULL,
    [UYEcinsiyet] VARCHAR (10) NOT NULL,
    [UYEyas]      INT          NOT NULL,
    [UYEodeme]    INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([UYEid] ASC)
);

