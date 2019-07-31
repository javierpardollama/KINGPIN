DELETE FROM ApplicationRole;
delete from sqlite_sequence where name='ApplicationRole';
INSERT INTO ApplicationRole (LASTMODIFIED,NAME,NORMALIZEDNAME,IMAGEURI,CONCURRENCYSTAMP) VALUES(date('now'),"User","User","roles\User_600px.png");
INSERT INTO ApplicationRole (LASTMODIFIED,NAME,NORMALIZEDNAME,IMAGEURI,CONCURRENCYSTAMP) VALUES(date('now'),"Guest","Guest","roles\Guest_600px.png");
INSERT INTO ApplicationRole (LASTMODIFIED,NAME,NORMALIZEDNAME,IMAGEURI,CONCURRENCYSTAMP) VALUES(date('now'),"Administrator","Administrator","roles\Administrator_600px.png");