if not exists(select 1 from dbo.Food) 
begin

insert into dbo.Food ([Description], Title, Price)
values ('Pizzer with a drink and chips', 'Pizzer Meal', 15),
('Cheeseburger with a drink and chips', 'Cheeseburger Meal', 13),
('Fish Tacos with a drink and chips', 'Fish-Tacos Meal', 16)

end