begin transaction

delete from Product
delete from Category

SET IDENTITY_INSERT Category ON
insert Category (Id, Name) values (1, 'Smartphone')
insert Category (Id, Name) values (2, 'Laptop')
insert Category (Id, Name) values (3, 'Tablet')
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

commit transaction
