CREATE PROCEDURE [hockey].[Type1andType2_SCD]
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @lastUpdate DATETIME2 = GETDATE();
    
    -- Type 1 SCD: Update player contact information (in place update)
    UPDATE t  
    SET                          
        t.EMAIL             = s.EMAIL,
        t.PHONE_NUMBER      = s.PHONE_NUMBER,
        t.ADDRESS           = s.ADDRESS,
        t.CITY              = s.CITY,
        t.STATE             = s.STATE,
        t.ZIP_CODE          = s.ZIP_CODE,
        t.LAST_UPDATE_DATE  = @lastUpdate
    FROM DW.FACT_HOCKEY_PLAYERS t  
    JOIN HOCKEY_APP_STATS.PLAYERS s ON t.PLAYER_GUID = s.PLAYER_GUID
    WHERE
        t.EMAIL             <> s.EMAIL
        OR t.PHONE_NUMBER   <> s.PHONE_NUMBER
        OR t.ADDRESS        <> s.ADDRESS
        OR t.CITY           <> s.CITY
        OR t.STATE          <> s.STATE
        OR t.ZIP_CODE       <> s.ZIP_CODE;
    
    -- Type 2 SCD: Insert new record when player name or team changes
    MERGE DW.FACT_HOCKEY_PLAYERS AS t
    USING HOCKEY_APP_STATS.PLAYERS AS s
    ON t.PLAYER_GUID = s.PLAYER_GUID AND t.EXPIRY_DATE = '9999-12-31'
    
    WHEN MATCHED AND (
        t.FULL_NAME <> s.FULL_NAME
        OR t.TEAM_ID <> s.TEAM_ID
    ) THEN
        UPDATE SET
            t.EXPIRY_DATE = DATEADD(DAY, -1, @lastUpdate),
            t.LAST_UPDATE_DATE = @lastUpdate
    
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            PLAYER_GUID, 
            FULL_NAME, 
            EMAIL, 
            PHONE_NUMBER, 
            ADDRESS, 
            CITY, 
            STATE, 
            ZIP_CODE, 
            TEAM_ID, 
            EFFECTIVE_DATE, 
            EXPIRY_DATE, 
            CREATE_DATE, 
            LAST_UPDATE_DATE
        )
        VALUES (
            s.PLAYER_GUID, 
            s.FULL_NAME, 
            s.EMAIL, 
            s.PHONE_NUMBER, 
            s.ADDRESS, 
            s.CITY, 
            s.STATE, 
            s.ZIP_CODE, 
            s.TEAM_ID, 
            @lastUpdate, 
            '9999-12-31', 
            @lastUpdate, 
            @lastUpdate
        );
    
    -- Ensure Expiry_Date and Effective_Date maintain a one-day gap
    WITH RankedPlayers AS (
        SELECT 
            PLAYER_GUID, 
            EFFECTIVE_DATE, 
            EXPIRY_DATE,
            ROW_NUMBER() OVER (PARTITION BY PLAYER_GUID ORDER BY EFFECTIVE_DATE DESC) AS rn
        FROM DW.FACT_HOCKEY_PLAYERS
    )
    UPDATE t
    SET t.EXPIRY_DATE = DATEADD(DAY, -1, (SELECT EFFECTIVE_DATE FROM RankedPlayers WHERE rn = 1 AND t.PLAYER_GUID = RankedPlayers.PLAYER_GUID))
    FROM DW.FACT_HOCKEY_PLAYERS t
    JOIN RankedPlayers rp ON t.PLAYER_GUID = rp.PLAYER_GUID
    WHERE rp.rn = 2;
END;