CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS knights(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
        name VARCHAR(255) NOT NULL,
        weapon VARCHAR(255) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS castles(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
        name VARCHAR(255) NOT NULL
    ) default charset utf8;

/* Create */

INSERT INTO knights (name, weapon) VALUES ("Sir Owen", "Mace");

INSERT INTO castles (name) VALUES ("Raven's Bluff ");

INSERT INTO
    accounts (name, email, picture)
VALUES (
        "Ty",
        "ty123@aol.com",
        "https//:thiscatdoesnotexist.com"
    );

/* Get ALL */

SELECT * FROM knights;

SELECT * FROM castles;

/* GET BY ID */

SELECT * FROM knights WHERE id= 2;

SELECT * FROM castles WHERE id= 2;

/* Search by Name */

SELECT * FROM knights WHERE name LIKE "%Tyler%";

/* Search by weapon catogery */

SELECT * FROM knights WHERE weapon LIKE "%Dragon%";

/* Search Castles */

SELECT * FROM castles WHERE name LIKE "%Raven%";

/* Edit */

UPDATE knights SET name = "King Tyler" WHERE id=2 ;

UPDATE castles SET name = "Tyler Castle" WHERE id=2 ;

/* Delete */

DELETE FROM knights WHERE id=3 LIMIT 1;

DELETE FROM castles WHERE id=1 LIMIT 1;

/* SECTION DANGER ZONE!!! */

/* With no WHERE statement all values will be deleted */

DELETE FROM knights;

/* Remove entire table and all data*/

DROP TABLE accounts;

DROP TABLE knights;