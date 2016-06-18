INSERT INTO Users(Name,Surname,Email,Password)
	VALUES('Admin','Admin','admin@admin.pl','haslo')

INSERT INTO Roles(Name, Description) VALUES ('Admin','Mo¿e wszystko')

INSERT INTO News(AddDate,ModificationDate,Title,Description,Content,Archive,UsersId)
	VALUES(convert(datetime,'18-06-12 10:34:09 PM',5),convert(datetime,'18-06-12 10:34:09 PM',5),'Bardzo wa¿na wiadomoœæ','Tutaj krótki opis...','A tutaj bardzo d³ugi wpis wiadmoœci',0,1)

INSERT INTO News(AddDate,ModificationDate,Title,Description,Content,Archive,UsersId)
	VALUES(convert(datetime,'18-06-12 10:34:09 PM',5),convert(datetime,'18-06-12 10:34:09 PM',5),'Bardzo wa¿na wiadomoœæ','Tutaj krótki opis...','A tutaj bardzo d³ugi wpis wiadmoœci',0,1)

INSERT INTO News(AddDate,ModificationDate,Title,Description,Content,Archive,UsersId)
	VALUES(convert(datetime,'18-06-12 10:34:09 PM',5),convert(datetime,'18-06-12 10:34:09 PM',5),'Bardzo wa¿na wiadomoœæ','Tutaj krótki opis...','A tutaj bardzo d³ugi wpis wiadmoœci',0,1)
