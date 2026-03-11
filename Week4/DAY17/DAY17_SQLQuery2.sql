CREATE PROCEDURE sp_FundTransfer
(
    @FromAccount INT,
    @ToAccount INT,
    @Amount DECIMAL(18,2)
)
AS
BEGIN

BEGIN TRANSACTION;

BEGIN TRY

    DECLARE @ExistingBalance DECIMAL(18,2);

    -- Check balance
    SELECT @ExistingBalance = Balance
    FROM Accounts
    WHERE AccountID = @FromAccount;

    -- Step 1: Check sufficient balance
    IF @ExistingBalance < @Amount
    BEGIN
        RAISERROR('Insufficient Balance',16,1);
    END

    -- Step 2: Deduct from sender
    UPDATE Accounts
    SET Balance = Balance - @Amount
    WHERE AccountID = @FromAccount;

    -- Step 3: Add to receiver
    UPDATE Accounts
    SET Balance = Balance + @Amount
    WHERE AccountID = @ToAccount;

    -- Step 4: Log success
    INSERT INTO dbo.FundTransferLog (FromAccount, ToAccount, Amount, TransferDate, Status)
    VALUES (@FromAccount, @ToAccount, @Amount, GETDATE(), 'Success');

    -- Step 5: Commit
    COMMIT;

    PRINT 'Fund transfer completed successfully';

END TRY

BEGIN CATCH

    -- Rollback if error
    ROLLBACK;

    -- Log failure
    INSERT INTO dbo.FundTransferLog (FromAccount, ToAccount, Amount, TransferDate, Status)
    VALUES (@FromAccount, @ToAccount, @Amount, GETDATE(), 'Failed: ' + ERROR_MESSAGE());

    PRINT 'Fund transfer failed: ' + ERROR_MESSAGE();

END CATCH

END;

SELECT name
FROM sys.procedures
WHERE name = 'sp_FundTransfer';

sp_helptext sp_FundTransfer;

EXEC sp_helptext 'sp_FundTransfer';
EXEC sp_FundTransfer 102,103,500;
USE BankAppDb;
EXEC sp_FundTransfer 102,103,500;