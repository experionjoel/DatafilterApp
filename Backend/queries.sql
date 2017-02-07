
-- FIRST AFTER OPENING PROJECT RUN
-- enable-migrations
-- add-migration
-- update-database

-- QUERIES FOR FIELD OPERATOR TABLE
insert into FieldOperators values ('EmployeeName', 5);
insert into FieldOperators values ('EmployeeName', 6);
insert into FieldOperators values ('EmployeeName', 9);

insert into FieldOperators values ('EmployeeNo', 2);
insert into FieldOperators values ('EmployeeNo', 1);
insert into FieldOperators values ('EmployeeNo', 5);
insert into FieldOperators values ('EmployeeNo', 6);
insert into FieldOperators values ('EmployeeNo', 3);
insert into FieldOperators values ('EmployeeNo', 4);

insert into FieldOperators values ('DateOfJoining', 10);
insert into FieldOperators values ('DateOfJoining', 5);
insert into FieldOperators values ('DateOfJoining', 4);
insert into FieldOperators values ('DateOfJoining', 3);
insert into FieldOperators values ('DateOfJoining', 2);
insert into FieldOperators values ('DateOfJoining', 1);

insert into FieldOperators values ('Designation', 7);
insert into FieldOperators values ('Designation', 8);

insert into FieldOperators values ('Band', 7);
insert into FieldOperators values ('Band', 8);

-- insert into Employees values('John','Tester', 'A0', GETDATE(), 102) -- Today's date

-- INSERT INTO USER TABLE
insert into Employees values('John','Tester', 'A0', convert(datetime,'10/12/2016', 101),2)

-- INSERT INTO USER TABLE
insert into Users values("John", "jojo")
insert into Users values("John", "jojo")
