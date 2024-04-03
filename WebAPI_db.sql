create table employees
(
	id serial primary key,
	fristname varchar(50) not null,
	lastname varchar(50),
	age int,
	phone varchar(50) not null unique,
	address varchar(100),
	email varchar(100) unique check(email ~* '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$')
)

create table departments
(
	id serial primary key,
	name varchar(50) not null,
	employee_id int references employees(id)
)

create table companyes
(
	id serial primary key,
	name varchar(50) not null,
	department_id int references departments(id),
	address varchar(100)
)
select * from employees