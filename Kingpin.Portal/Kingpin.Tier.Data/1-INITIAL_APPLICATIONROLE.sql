DELETE FROM ApplicationRole;

delete from sqlite_sequence where name='ApplicationRole';

INSERT INTO ApplicationRole (LASTMODIFIED,
NAME,
NORMALIZEDNAME,
IMAGEURI,
CONCURRENCYSTAMP) 
VALUES(date('now'),
"Super Admin",
"Super Admin",
"roles\Super_Administrator_600px.png",
"0x0000AAA0008E37A0");

INSERT INTO ApplicationRole (LASTMODIFIED,
NAME,
NORMALIZEDNAME,
IMAGEURI,
CONCURRENCYSTAMP) 
VALUES(date('now'),
"Administrator",
"Administrator",
"roles\Administrator_600px.png",
"0x0000AAA0008E37A0");

INSERT INTO ApplicationRole (LASTMODIFIED,
NAME,
NORMALIZEDNAME,
IMAGEURI,
CONCURRENCYSTAMP) 
VALUES(date('now'),
"Editor",
"Editor",
"roles\Editor_600px.png",
"0x0000AAA0008E37A0");

INSERT INTO ApplicationRole (LASTMODIFIED,
NAME,
NORMALIZEDNAME,
IMAGEURI,
CONCURRENCYSTAMP) 
VALUES(date('now'),
"Author",
"Author",
"roles\Author_600px.png",
"0x0000AAA0008E37A0");

INSERT INTO ApplicationRole (LASTMODIFIED,
NAME,
NORMALIZEDNAME,
IMAGEURI,
CONCURRENCYSTAMP) 
VALUES(date('now'),
"Contributor",
"Contributor",
"roles\Author_600px.png",
"0x0000AAA0008E37A0");

INSERT INTO ApplicationRole (LASTMODIFIED,
NAME,
NORMALIZEDNAME,
IMAGEURI,
CONCURRENCYSTAMP) 
VALUES(date('now'),
"Subscriber",
"Subscriber",
"roles\Subscriber_600px.png",
"0x0000AAA0008E37A0");

INSERT INTO ApplicationRole (LASTMODIFIED,
NAME,
NORMALIZEDNAME,
IMAGEURI,
CONCURRENCYSTAMP) 
VALUES(date('now'),
"Guest",
"Guest",
"roles\Guest_600px.png",
"0x0000AAA0008E37A0");


