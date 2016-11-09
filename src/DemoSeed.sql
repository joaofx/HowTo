begin transaction

delete from Product
delete from Category

SET IDENTITY_INSERT Category ON
insert Category (Id, Name) values (1, 'Smartphone')
insert Category (Id, Name) values (2, 'Laptop')
insert Category (Id, Name) values (3, 'Tablet')
insert Category (Id, Name) values (4, 'Printer')
insert Category (Id, Name) values (5, 'Monitor')
insert Category (Id, Name) values (6, 'Projector')
SET IDENTITY_INSERT Category OFF

insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('iPhone', 1, 599, getdate(), getdate())
insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('Samsung Galaxy', 1, 549, getdate(), getdate())
insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('Motorola', 1, 499, getdate(), getdate())

insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('Macbook', 2, 1899, getdate(), getdate())
insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('Dell XPS', 2, 1699, getdate(), getdate())
insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('Surface', 2, 1799, getdate(), getdate())

insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('Amazon Fire', 3, 149, getdate(), getdate())
insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('iPad Mini', 3, 459, getdate(), getdate())
insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('Surface Tablet', 3, 399, getdate(), getdate())

insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('HP Envy 4520', 4, 78.78, getdate(), getdate())
insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('Epson Expression Home XP-330', 4, 44.98, getdate(), getdate())
insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('HP OfficeJet 4650"', 4, 67.99, getdate(), getdate())

insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('HP Pavilion 21.5', 5, 99.99, getdate(), getdate())
insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('Acer R240HY 23.8', 5, 119.99, getdate(), getdate())
insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('ASUS VG248QE 24"', 5, 219.99, getdate(), getdate())

insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('Epson EB-X03', 6, 400.99, getdate(), getdate())
insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('Epson EB-U04', 6, 789.99, getdate(), getdate())
insert Product (Name, CategoryId, Price, Audit_CreatedAt, Audit_UpdatedAt) values ('Acer X112H', 6, 319.99, getdate(), getdate())

commit transaction
