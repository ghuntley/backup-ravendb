# Backup RavenDB
This console application is designed to run locally on a RavenDB server and will backup all databases found to a local filesystem on the server.

# Usage
* Specify the backup destination via the` <add key="BackupDestination" value="C:\\Backups" />` in `BackupRavenDb.config`
* Results from the backup run are stored in the `logs/{date}.txt`
* Any backup failures will result in a exitcode of `$amountOfFailures` otherwise exitcode will be `0` which signifies that all backups were successful.

`> BackupRavenDB.exe`

    2014-12-28 15:56:26.185 +11:00 [Information] Retreiving list of databases on server: "http://localhost:8080"
    2014-12-28 15:56:26.544 +11:00 [Information] Found the following databases: ["Hello", "World"]
    2014-12-28 15:56:26.577 +11:00 [Information] Backing up database: "Hello" to "C:\\Backups\REMOVED\Hello\2014-12-28-04-56-26Z"
    2014-12-28 15:56:26.581 +11:00 [Information] Beginning operation "Hello": "Database Backup"
    2014-12-28 15:56:27.288 +11:00 [Debug] Sending json {
    2014-12-28 15:56:27.302 +11:00 [Debug]   "BackupLocation": "C:\\\\\\\\Backups\\\\REMOVED\\\\Hello\\\\2014-12-28-04-56-26Z"
    2014-12-28 15:56:27.315 +11:00 [Debug] } to http://localhost:8080
    2014-12-28 15:56:27.326 +11:00 [Debug] 
    2014-12-28 15:56:27.532 +11:00 [Debug] [28/12/2014 4:56:27 AM] Started backup process. Backing up data to directory = 'C:\\\\Backups\\REMOVED\\Hello\\2014-12-28-04-56-26Z'
    2014-12-28 15:56:27.544 +11:00 [Debug] [28/12/2014 4:56:27 AM] Backing up indexes..
    2014-12-28 15:56:27.554 +11:00 [Debug] [28/12/2014 4:56:27 AM] Hard linked C:\RavenDB\Data\Hello\IndexDefinitions\1.index
    2014-12-28 15:56:27.570 +11:00 [Debug] [28/12/2014 4:56:27 AM] Hard linked C:\RavenDB\Data\Hello\IndexDefinitions\indexes.txt
    2014-12-28 15:56:27.580 +11:00 [Debug] [28/12/2014 4:56:27 AM] Copying 1.index
    2014-12-28 15:56:27.590 +11:00 [Debug] [28/12/2014 4:56:27 AM] Overall progress 97% done
    2014-12-28 15:56:27.600 +11:00 [Debug] [28/12/2014 4:56:27 AM] Copied 1.index
    2014-12-28 15:56:27.609 +11:00 [Debug] [28/12/2014 4:56:27 AM] Copying indexes.txt
    2014-12-28 15:56:27.620 +11:00 [Debug] [28/12/2014 4:56:27 AM] Overall progress 100% done
    2014-12-28 15:56:27.632 +11:00 [Debug] [28/12/2014 4:56:27 AM] Copied indexes.txt
    2014-12-28 15:56:27.643 +11:00 [Debug] [28/12/2014 4:56:27 AM] Finished indexes backup. Executing data backup..
    2014-12-28 15:56:27.655 +11:00 [Debug] [28/12/2014 4:56:27 AM] Esent Backup Begin
    2014-12-28 15:56:28.568 +11:00 [Debug] [28/12/2014 4:56:27 AM] Esent Backup Complete
    2014-12-28 15:56:28.667 +11:00 [Information] Completed operation "Hello": "Database Backup" in 00:00:02.0852206 (2085 ms)
    2014-12-28 15:56:28.679 +11:00 [Information] Backing up database: "World" to "C:\\Backups\REMOVED\World\2014-12-28-04-56-28Z"
    2014-12-28 15:56:28.689 +11:00 [Information] Beginning operation "World": "Database Backup"
    2014-12-28 15:56:29.491 +11:00 [Debug] Sending json {
    2014-12-28 15:56:29.506 +11:00 [Debug]   "BackupLocation": "C:\\\\\\\\Backups\\\\REMOVED\\\\World\\\\2014-12-28-04-56-28Z"
    2014-12-28 15:56:29.522 +11:00 [Debug] } to http://localhost:8080
    2014-12-28 15:56:29.532 +11:00 [Debug] 
    2014-12-28 15:56:29.738 +11:00 [Debug] [28/12/2014 4:56:29 AM] Started backup process. Backing up data to directory = 'C:\\\\Backups\\REMOVED\\World\\2014-12-28-04-56-28Z'
    2014-12-28 15:56:29.752 +11:00 [Debug] [28/12/2014 4:56:29 AM] Backing up indexes..
    2014-12-28 15:56:29.765 +11:00 [Debug] [28/12/2014 4:56:29 AM] Hard linked C:\RavenDB\Data\World\IndexDefinitions\1.index
    2014-12-28 15:56:29.778 +11:00 [Debug] [28/12/2014 4:56:29 AM] Hard linked C:\RavenDB\Data\World\IndexDefinitions\indexes.txt
    2014-12-28 15:56:29.793 +11:00 [Debug] [28/12/2014 4:56:29 AM] Copying 1.index
    2014-12-28 15:56:29.804 +11:00 [Debug] [28/12/2014 4:56:29 AM] Overall progress 97% done
    2014-12-28 15:56:29.814 +11:00 [Debug] [28/12/2014 4:56:29 AM] Copied 1.index
    2014-12-28 15:56:29.824 +11:00 [Debug] [28/12/2014 4:56:29 AM] Copying indexes.txt
    2014-12-28 15:56:29.835 +11:00 [Debug] [28/12/2014 4:56:29 AM] Overall progress 100% done
    2014-12-28 15:56:29.845 +11:00 [Debug] [28/12/2014 4:56:29 AM] Copied indexes.txt
    2014-12-28 15:56:29.854 +11:00 [Debug] [28/12/2014 4:56:29 AM] Finished indexes backup. Executing data backup..
    2014-12-28 15:56:29.867 +11:00 [Debug] [28/12/2014 4:56:29 AM] Esent Backup Begin
    2014-12-28 15:56:30.775 +11:00 [Debug] [28/12/2014 4:56:29 AM] Esent Backup Complete
    2014-12-28 15:56:30.828 +11:00 [Information] Completed operation "World": "Database Backup" in 00:00:02.1312559 (2131 ms)
    2014-12-28 15:56:30.836 +11:00 [Information] Backing up database: "system" to "C:\\Backups\REMOVED\system\2014-12-28-04-56-30Z"
    2014-12-28 15:56:30.842 +11:00 [Information] Beginning operation "system": "Database Backup"
    2014-12-28 15:56:31.352 +11:00 [Debug] Sending json {
    2014-12-28 15:56:31.366 +11:00 [Debug]   "BackupLocation": "C:\\\\\\\\Backups\\\\REMOVED\\\\system\\\\2014-12-28-04-56-30Z"
    2014-12-28 15:56:31.384 +11:00 [Debug] } to http://localhost:8080
    2014-12-28 15:56:31.396 +11:00 [Debug] 
    2014-12-28 15:56:31.619 +11:00 [Debug] [28/12/2014 4:56:31 AM] Started backup process. Backing up data to directory = 'C:\\\\Backups\\REMOVED\\system\\2014-12-28-04-56-30Z'
    2014-12-28 15:56:31.633 +11:00 [Debug] [28/12/2014 4:56:31 AM] Backing up indexes..
    2014-12-28 15:56:31.644 +11:00 [Debug] [28/12/2014 4:56:31 AM] Hard linked C:\RavenDB\Data\System\IndexDefinitions\1.index
    2014-12-28 15:56:31.658 +11:00 [Debug] [28/12/2014 4:56:31 AM] Hard linked C:\RavenDB\Data\System\IndexDefinitions\indexes.txt
    2014-12-28 15:56:31.672 +11:00 [Debug] [28/12/2014 4:56:31 AM] Copying 1.index
    2014-12-28 15:56:31.683 +11:00 [Debug] [28/12/2014 4:56:31 AM] Overall progress 97% done
    2014-12-28 15:56:31.695 +11:00 [Debug] [28/12/2014 4:56:31 AM] Copied 1.index
    2014-12-28 15:56:31.706 +11:00 [Debug] [28/12/2014 4:56:31 AM] Copying indexes.txt
    2014-12-28 15:56:31.716 +11:00 [Debug] [28/12/2014 4:56:31 AM] Overall progress 100% done
    2014-12-28 15:56:31.728 +11:00 [Debug] [28/12/2014 4:56:31 AM] Copied indexes.txt
    2014-12-28 15:56:31.743 +11:00 [Debug] [28/12/2014 4:56:31 AM] Finished indexes backup. Executing data backup..
    2014-12-28 15:56:31.756 +11:00 [Debug] [28/12/2014 4:56:31 AM] Esent Backup Begin
    2014-12-28 15:56:32.667 +11:00 [Debug] [28/12/2014 4:56:31 AM] Esent Backup Complete
    2014-12-28 15:56:32.754 +11:00 [Information] Completed operation "system": "Database Backup" in 00:00:01.9075050 (1907 ms)
    2014-12-28 15:56:32.765 +11:00 [Information] Databases: ["Hello", "World", "system"] were successfully backed up.


    > tree
    Folder PATH listing for volume SYSTEM
    Volume serial number is 0000000A 8488:B2
    C:.
    └───REMOVED
        ├───Hello
        │   ├───2014-12-28-04-17-02Z
        │   │   ├───IndexDefinitions
        │   │   ├───Indexes
        │   │   │   └───1
        │   │   └───new
        │   ├───2014-12-28-04-18-49Z
        │   │   ├───IndexDefinitions
        │   │   ├───Indexes
        │   │   │   └───1
        │   │   └───new
        │   ├───2014-12-28-04-28-04Z
        │   │   ├───IndexDefinitions
        │   │   ├───Indexes
        │   │   │   └───1
        │   │   └───new
        │   ├───2014-12-28-04-47-45Z
        │   │   ├───IndexDefinitions
        │   │   ├───Indexes
        │   │   │   └───1
        │   │   └───new
        │   ├───2014-12-28-04-48-32Z
        │   │   ├───IndexDefinitions
        │   │   ├───Indexes
        │   │   │   └───1
        │   │   └───new
        │   ├───2014-12-28-04-49-06Z
        │   │   ├───IndexDefinitions
        │   │   ├───Indexes
        │   │   │   └───1
        │   │   └───new
        │   ├───2014-12-28-04-51-51Z
        │   │   ├───IndexDefinitions
        │   │   ├───Indexes
        │   │   │   └───1
        │   │   └───new
        │   ├───2014-12-28-04-53-53Z
        │   │   ├───IndexDefinitions
        │   │   ├───Indexes
        │   │   │   └───1
        │   │   └───new
        │   ├───2014-12-28-04-56-03Z
        │   │   ├───IndexDefinitions
        │   │   ├───Indexes
        │   │   │   └───1
        │   │   └───new
        │   └───2014-12-28-04-56-26Z
        │       ├───IndexDefinitions
        │       ├───Indexes
        │       │   └───1
        │       └───new
        ├───system
        │   ├───2014-12-28-04-47-50Z
        │   ├───2014-12-28-04-48-36Z
        │   ├───2014-12-28-04-49-10Z
        │   ├───2014-12-28-04-51-57Z
        │   ├───2014-12-28-04-53-57Z
        │   │   ├───IndexDefinitions
        │   │   ├───Indexes
        │   │   │   └───1
        │   │   └───new
        │   ├───2014-12-28-04-56-07Z
        │   │   ├───IndexDefinitions
        │   │   ├───Indexes
        │   │   │   └───1
        │   │   └───new
        │   └───2014-12-28-04-56-30Z
        │       ├───IndexDefinitions
        │       ├───Indexes
        │       │   └───1
        │       └───new
        └───World
            ├───2014-12-28-04-17-04Z
            │   ├───IndexDefinitions
            │   ├───Indexes
            │   │   └───1
            │   └───new
            ├───2014-12-28-04-18-51Z
            │   ├───IndexDefinitions
            │   ├───Indexes
            │   │   └───1
            │   └───new
            ├───2014-12-28-04-28-06Z
            │   ├───IndexDefinitions
            │   ├───Indexes
            │   │   └───1
            │   └───new
            ├───2014-12-28-04-47-47Z
            │   ├───IndexDefinitions
            │   ├───Indexes
            │   │   └───1
            │   └───new
            ├───2014-12-28-04-48-34Z
            │   ├───IndexDefinitions
            │   ├───Indexes
            │   │   └───1
            │   └───new
            ├───2014-12-28-04-49-09Z
            │   ├───IndexDefinitions
            │   ├───Indexes
            │   │   └───1
            │   └───new
            ├───2014-12-28-04-51-54Z
            │   ├───IndexDefinitions
            │   ├───Indexes
            │   │   └───1
            │   └───new
            ├───2014-12-28-04-53-55Z
            │   ├───IndexDefinitions
            │   ├───Indexes
            │   │   └───1
            │   └───new
            ├───2014-12-28-04-56-05Z
            │   ├───IndexDefinitions
            │   ├───Indexes
            │   │   └───1
            │   └───new
            └───2014-12-28-04-56-28Z
                ├───IndexDefinitions
                ├───Indexes
                │   └───1
                └───new
