DELETE FROM ApplicationRole;

delete from sqlite_sequence where name='ApplicationRole';

INSERT INTO ApplicationRole (
DELETED,
LASTMODIFIED,
NAME,
NORMALIZEDNAME,
IMAGEURI,
CONCURRENCYSTAMP) 
VALUES(
false,
date('now'),
"Super Admin",
"Super Admin",
"roles\Super_Administrator_500px.png",
"0x0000AAA0008E37A0");

INSERT INTO ApplicationRole (
DELETED,
LASTMODIFIED,
NAME,
NORMALIZEDNAME,
IMAGEURI,
CONCURRENCYSTAMP) 
VALUES(
false,
date('now'),
"Administrator",
"Administrator",
"roles\Administrator_500px.png",
"0x0000AAA0008E37A0");

INSERT INTO ApplicationRole (
DELETED,
LASTMODIFIED,
NAME,
NORMALIZEDNAME,
IMAGEURI,
CONCURRENCYSTAMP) 
VALUES(
false,
date('now'),
"Editor",
"Editor",
"roles\Editor_500px.png",
"0x0000AAA0008E37A0");

INSERT INTO ApplicationRole (
DELETED,
LASTMODIFIED,
NAME,
NORMALIZEDNAME,
IMAGEURI,
CONCURRENCYSTAMP) 
VALUES(
false,
date('now'),
"Author",
"Author",
"roles\Author_500px.png",
"0x0000AAA0008E37A0");

INSERT INTO ApplicationRole (
DELETED,
LASTMODIFIED,
NAME,
NORMALIZEDNAME,
IMAGEURI,
CONCURRENCYSTAMP) 
VALUES(
false,
date('now'),
"Contributor",
"Contributor",
"roles\Contributor_500px.png",
"0x0000AAA0008E37A0");

INSERT INTO ApplicationRole (
DELETED,
LASTMODIFIED,
NAME,
NORMALIZEDNAME,
IMAGEURI,
CONCURRENCYSTAMP) 
VALUES(
false,
date('now'),
"Subscriber",
"Subscriber",
"roles\Subscriber_500px.png",
"0x0000AAA0008E37A0");

INSERT INTO ApplicationRole (
DELETED,
LASTMODIFIED,
NAME,
NORMALIZEDNAME,
IMAGEURI,
CONCURRENCYSTAMP) 
VALUES(
false,
date('now'),
"Guest",
"Guest",
"roles\Guest_500px.png",
"0x0000AAA0008E37A0");


