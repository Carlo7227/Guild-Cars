
use GuildCars
go


delete from Vehicle
DBCC CHECKIDENT ('GuildCars.dbo.Vehicle',RESEED, 0)

delete from Models
DBCC CHECKIDENT ('GuildCars.dbo.Models',RESEED, 0)

delete from Specials
DBCC CHECKIDENT ('GuildCars.dbo.Specials',RESEED, 0)

delete from BodyType
DBCC CHECKIDENT ('GuildCars.dbo.BodyType',RESEED, 0)

delete from Make
DBCC CHECKIDENT ('GuildCars.dbo.Make',RESEED, 0)

delete from Color
DBCC CHECKIDENT ('GuildCars.dbo.Color',RESEED, 0)


insert into Color(ColorName)
VALUES
('Red'),
('Blue'),
('Green'),
('Black'),
('White')


insert into Make(MakeType)
VALUES
('Ford'),
('Mazda'),
('Honda'),
('Mitsubishi'),
('Jeep'),
('Nissian')



insert into BodyType([Type])
VALUES
('Hatchback'),
('Sedan'),
('SUV')


insert into Specials(SpecialTitle,SpecialDescription)
VALUES
('Spring Sale!', 'All 4 door sedans 25% off! 0% APR for 15 months, zero down. Come in and pick up a new vehicle today!'),
('Jeep Offer!', 'Trade your jeep in for a brand new one for this summer''s''off roading experience!'),
('Buy one get 20 free!', 'Just buy one super car and get 20 free used 1980 Ford Geos!'),
('Ask about our free coffee!', 'Buy a new car and get free coffee for 3 years'),
('Summer Sale', 'All cars with sunroofs $2000 dollars off!')





insert into Models(Model, MakeID)
VALUES
('Focus',1),
('R8',2),
('Accord',3),
('Evo',4),
('Wrangler',5),
('GTR',6)



insert into Vehicle(ExteriorColorID,InteriorColorID,BodyTypeID,IsFeatured,Id,IsAutomatic,SalesPrice,MSRP,Mileage,VIN,[Year],[Description],ImageFileName, ModelID)
VALUES
(2,2,1,1,666666661,1,20000,30000,3000,'4FZLFJSNFNDNJSH',2017,'Very Good car','FordFocus.jpeg', 1),
(2,3,1,0,66666661,0,15000,25000,30573,'57HNDJSNFHDNJSH',2010,'Very Bad car','FordFocus.jpeg', 1),
(2,1,1,0,66666664,0,17500,30000,5000,'10ZLF74jfn7NJSH',2015,'Very Okay car','FordFocus.jpeg', 1),
(2,1,1,0,66666664,1,30000,70000,500,'90ZLF74jfn7NJSH',2015,'Very GREAT GREAT  car','FordFocus.jpeg', 1),
(4,1,1,1,666664,1,32820,40000,500,'100ZLF74jfn7NDGH',2015,'Super Great AWD car ready to take the family to the grocery store','MitsubishiEVO.jpg', 4),
(4,1,1,0,666664,0,32820,40000,500,'100ZLF74jfn7NDGH',2015,'Super Great AWD car ready to take the family to the grocery store','MitsubishiEVO.jpg', 4),
(2,1,1,1,6666664,1,15000,30000,500,'77ZLF74jfVSDJLL',2008,'Cool car they stopped making','MazdaR8.jpg', 2),
(2,1,1,0,6666664,0,15000,30000,500,'11ZLF74jfVSDJLL',2008,'Cool car they stopped making','MazdaR8.jpg', 2),
(5,1,3,1,666664,0,30000,70000,500,'10ZLF4jGDBJS7S',2015,'You can take this car to Jurassic park and probably live longer as long as it starts','2015JeepWrangler.jpg', 5),
(5,1,3,0,666664,0,30000,70000,500,'66ZLF4jGDBJS7S',2015,'You can take this car to Jurassic park and probably live longer as long as it starts','2015JeepWrangler.jpg', 5),
(5,1,1,1,66666664,1,90000,120000,500,'K22ZLF74jfnJFSH',2015,'Super quick car. Once you have one of these you are pretty much done with life','2016NissanGTR.jpg', 6),
(2,3,1,0,66661,0,20000,35000,300,'57HNDJSNFHDNJSH',2010,'Just a normal car but its pretty good','HondaAccord.jpeg', 3),
(2,3,1,0,6666661,0,10000,35000,70000,'K266LF74jfFHDFSH',2010,'Just a normal car but its pretty good','HondaAccord.jpeg', 3),
(2,3,1,1,6666661,0,10000,35000,70000,'K2634534LF74jf99SH',2010,'Just a normal car but its pretty good','HondaAccord.jpeg', 3)
go


select * from Vehicle

--select [year], maketype, model, count(*) as [count], sum(salesprice)
--from Vehicle v
--join GuildCars.dbo.Models m
	--on v.modelid = m.ModelsID
	--join GuildCars.dbo.Make ma	
		--on ma.MakeID = m.MakeID
--group by year, maketype, model

insert into States(StateAbbreviation)
VALUES
('AL'),
('AK'),
('AZ'),
('AR'),
('CA'),
('CO'),
('CT'),
('DE'),
('FL'),
('GA'),
('HI'),
('ID'),
('IL'),
('IA'),
('KS'),
('KY'),
('LA'),
('ME'),
('MD'),
('MA'),
('MI'),
('MN'),
('MS'),
('MO'),
('MT'),
('NE'),
('NV'),
('NH'),
('NJ'),
('NM'),
('NY'),
('NC'),
('ND'),
('OH'),    
('OK'),      
('OR'),
('PA'),
('RI'),
('SC'),  
('SD'),
('TN'),
('TX'),
('UT'),
('VT'),
('VA'),
('WA'),
('WV'),
('WI'),
('WY')

delete from PurchaseType
insert into PurchaseType([Type])
VALUES
('Dealer Finance'),
('Bank Finance'),
('Cash')
