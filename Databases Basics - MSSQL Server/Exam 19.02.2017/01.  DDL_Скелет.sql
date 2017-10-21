/*============================================================================
	File:		Data.sql

	Summary:	Scripts's purpose is to insert sample data into the specified
				below database.

				The script is part of DB Basics Exam - "Bakery";

	Date:		January 19th 2017

	SQL Server Version: 2008 / 2012 / 2014 / 2016
------------------------------------------------------------------------------
	Written by Georgi Stoimenov, Technical Trainer @SoftUni

	This script is intended only as a supplement to demos, lectures, exams
	given by SoftUni Team.  
  
	THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF 
	ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED 
	TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
	PARTICULAR PURPOSE.
============================================================================*/

USE Bakery

-- Table: Countries
SET IDENTITY_INSERT Countries ON

INSERT INTO Countries (Id, Name) VALUES
(1,'Turkey'),
(2,'Andorra'),
(3,'Japan'),
(4,'Venezuela'),
(5,'Serbia'),
(6,'Zimbabwe'),
(7,'Cambodia'),
(8,'Cape Verde'),
(9,'Thailand'),
(10,'Costa Rika'),
(11,'Bangladesh'),
(12,'Ecuador'),
(13,'Italy'),
(14,'Armenia'),
(15,'Ukraine'),
(16,'Brazil'),
(17,'South Korea'),
(18,'Albania'),
(19,'Poland'),
(20,'Sweden'),
(21,'Egypt'),
(22,'China'),
(23,'France'),
(24,'Iran'),
(25,'Guatemala'),
(26,'Philippines'),
(27,'Indonesia'),
(28,'Canada'),
(29,'Czech Republic'),
(30,'Croatia'),
(31,'Greece'),
(32,'Bulgaria')

SET IDENTITY_INSERT Countries OFF


-- Table: Customers
SET IDENTITY_INSERT Customers ON

INSERT INTO Customers (Id, FirstName, LastName, Gender, Age,PhoneNumber, CountryId) VALUES
(1,'Betty','Wallace','F',14,'0995421800',17),
(2,'Rachel','Bishop','F',10,'0779574407',3),
(3,'Joan','Peters','F',37,'0983157959',17),
(4,'Jean','Pierce','F',67,'0994780345',8),
(5,'Irene','Peters','F',69,'0995086966',25),
(6,'Carol','Miller','F',20,'0891119508',9),
(7,'Jason','Hamilton','M',36,'0980206055',8),
(8,'Brenda','Wallace','F',38,'0997026449',18),
(9,'Theresa','Riley','F',59,'0794768295',5),
(10,'Harry','Jones','M',16,'0971528030',15),
(11,'Jerry','Andrews','M',72,'0992688483',11),
(12,'Jennifer','Cunningham','F',62,'0871809337',6),
(13,'Antonio','Lynch','M',49,'0781375797',21),
(14,'Lisa','Green','F',37,'0972568702',19),
(15,'Randy','Ramirez','M',54,'0792944075',15),
(16,'Marie','Hudson','F',7,'0789987495',32),
(17,'Rachel','Hill','F',48,'0882068924',6),
(18,'Edward','Mills','M',55,'0988359338',22),
(19,'Paul','Bishop','M',12,'0783287386',12),
(20,'Robin','Mitchell','F',57,'0899531356',14),
(21,'Nicholas','Duncan','M',37,'0784596962',4),
(22,'Larry','Torres','M',9,'0879543860',2),
(23,'Richard','Carroll','M',27,'0896940133',14),
(24,'Gregory','Hernandez','M',043,'0993511373',11),
(25,'Harold','Clark','M',21,'0870010267',18),
(26,'Sharon','Franklin','F',47,'0890169598',10),
(27,'Justin','Garza','M',48,'0981024945',17),
(28,'Susan','Snyder','F',56,'0992319570',7),
(29,'Marie','Porter','F',23,'0781941781',7),
(30,'Amanda','Martinez','F',30,'0886609909',18),
(31,'Irene','Alexander','F',74,'0992097930',23),
(32,'Paul','Wells','M',6,'0989476093',26),
(33,'Jeremy','Banks','M',7,'0777661009',16),
(34,'Craig','Marshall','M',51,'0999678675',24),
(35,'Timothy','White','M',44,'0793395706',32),
(36,'Wanda','Cooper','F',29,'0995926642',3),
(37,'Emily','Nelson','F',29,'0984010220',8),
(38,'Paula','Gonzalez','F',62,'0898993491',26),
(39,'Robin','Daniels','F',24,'0776754347',21),
(40,'Ashley','Bryant','F',58,'0995449226',4)

SET IDENTITY_INSERT Customers OFF


-- Table: Distributors
SET IDENTITY_INSERT Distributors ON

INSERT INTO Distributors (Id,Name,Summary,AddressText, CountryId) VALUES
(1,'Loride','Zero defect delivering','1 Rieder Avenue',5),
(2,'Frova','Configurable clear-thinking delivery','47450 Forster Place',17),
(3,'Oxygen','Triple-buffered stable delivery','386 Monica Lane',23),
(4,'Aceoline oride','Transport support','5254 Drewry Drive',28),
(5,'Hydroce Anhydrous','User-friendly transport portal','332 Havey Circle',24),
(6,'Capex','Robust 24 hour transport','555 Caliangt Parkway',8),
(7,'Honey 4 Kids','Customer-focused zero defect','249 Dexter Plaza',15),
(8,'Levetiracetam','Enhanced attitude-oriented business','15 Arkansas Center',6),
(9,'Rabbitbush','Seamless interactive transport parallelism','1 Northfield Court',5),
(10,'SUSTIVA','Right-sized content-based transport methodology','96636 Fieldstone Circle',25),
(11,'metformin hydrochloride','Customizable neutral traveling','04298 Continental Avenue',24),
(12,'Groundsel','Sharable transport platform','782 Anderson Alley',20),
(13,'Tobramycin','Distributed interactive delivery solution','7 Nelson Way',7),
(14,'Topcare Ibuprofen','Mandatory transport base','10 Annamark Crossing',19),
(15,'cold','Upgradable modular business','19110 Shoshone Lane',31),
(16,'Arinase','Optional hybrid transport','1211 Mockingbird Lane',18),
(17,'GENOTROPIN','Profound client-driven instruction set','742 Brickson Park Circle',31),
(18,'Equate antacid','Customer loyalty','786 Saint Paul Street',14),
(19,'Bacitracin','Focus group','7342 Everett Terrace',12),
(20,'Allopurinol','Multi-lateral cohesive delivery','20 Sachtjen Drive',2),
(21,'Pollens - Trees','Upgradable user-facing deals','2670 7th Crossing',32),
(22,'Lovastatin','Exclusive interactive transport','8 Katie Court',16),
(23,'Red Zone Collection','Synergistic actuating project','60 High Crossing Terrace',19),
(24,'Femring','Foods and Goods','60840 Scott Terrace',27),
(25,'Nitrous Oxide','You pay we deliver','1730 Alpine Crossing',7),
(26,'Oxyg','Innovative composite transport','49450 Ronald Regan Lane',12),
(27,'TOUCH BB PACT','Inverse transport system engine','182 Maple Way',14),
(28,'Alprazolam','Profit-focused mission-critical delivery','2 Texas Way',12),
(29,'COREGCR','Ameliorated intermediate traveling','5633 Steensland Junction',24),
(30,'Lyrica','Team-oriented incremental food','305 Russell Lane',16),
(31,'up and up','Phased interactive transport','36514 Waxwing Avenue',25),
(32,'Cefuroxime','Streamlined transitional transport','19 Mitchell Trail',5),
(33,'Escitalopram','Sharable 5th generation artificial transport','17 Scoville Drive',11),
(34,'Aspergillus terreus','Devolved secondary synergy','8 Schlimgen Trail',30),
(35,'SPF 17','Vision-oriented composite transport','295 Melody Plaza',2),
(36,'Chicken Feathers','Public-key secondary transport','6988 Westridge Avenue',9),
(37,'Fluvastatin','Virtual modular delivery','41976 Bashford Trail',13),
(38,'Rash','Total optimal delivering','54 Starling Way',25),
(39,'Jantoven','Cross-group 6th generation transport solution','00136 Butternut Plaza',26),
(40,'Depo-Provera','Profound asymmetric collaboration','975 Truax Trail',21),
(41,'Moisturizer','Customizable systemic delivery','4007 Ludington Center',25),
(42,'Medicated Chest ','Ameliorated static knowledge base','82 Toban Circle',13),
(43,'NYSTATIN','Quality-focused 4th generation hardware','65 Sycamore Lane',25),
(44,'Yes To Cucumbers','Advanced tangible transport management','63 Rigney Street',25),
(45,'Headache Relief','Optional logistical methodology','6 Corscot Place',29),
(46,'CAREONE','Profound scalable products','45171 Memorial Pass',1),
(47,'Laser Max SPF50','Synergized motivating products','Pierstorff Crossing',14),
(48,'Metoprolol Succinate','Adaptive logistical contingency','75 Farmco Lane',3),
(49,'SINGULAIR','superstructure','72 Nevada Plaza',10),
(50,'HICKORY MIX PIGNUT','Fundamental high-level strategy','7416 Karstens Point',18),
(51,'Sertraline','Persevering grid-enabled concept','74473 Kedzie Court',24),
(52,'Muscular Pain Relief','Optional value-added throughput','9388 Lillian Alley',3),
(53,'Concentrated Ibuprofen','Fully-configurable transitional capability','9627 Old Shore Lane',19),
(54,'Vaseline Intensive Care','Networked actuating attitude','88 Gina Hill',13),
(55,'Moore Medical','Intuitive logistic-enabled emulation','72547 Marcy Circle',12),
(56,'AcetaZOLAMIDE','Self-enabling multi-tasking transport management','00 Straubel Trail',30),
(57,'Natural herb','Implemented incremental transport','11305 Lillian Terrace',19),
(58,'Carvedilol','Multi-layered logistical capacity','6 Mcbride Trail',20),
(59,'Lisinopril','Enterprise-wide dedicated','9503 Autumn Leaf Way',14),
(60,'M3Modulator','Networked clear-thinking transport','68233 Division Place',8)

SET IDENTITY_INSERT Distributors OFF


-- Table: Products
SET IDENTITY_INSERT Products ON

INSERT INTO Products(Id, Name, Description, Recipe, Price) VALUES
(1,'Octinoxate','Octocrylene','Oxybenzone libero non mattis pulvinar, nulla pede ullamcorper augue a suscipit nulla elit ac nulla. Sed vel enim sit amet',13),
(2,'Tobacco Cake','Sed ante. Vivamus tortor. Duis mattis egestas metus.','Aliquam augue quam sollicitudin vitae consectetuer eget rutrum at lorem.',14.39),
(3,'Musaka','Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.','Duis at velit eu est congue elementum.',15.05),
(4,'Fondu bread','Donec posuere metus vitae ipsum.','Curabitur at ipsum ac tellus semper interdum.',3.83),
(5,'Fried Eggs bread','Duis at velit eu est congue elementum. In hac habitasse platea dictumst. Morbi vestibulum velit id pretium iaculis diam.','Morbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet.',26.61),
(6,'Salad','Nulla ac enim.Duis aliquam convallis nunc.','Curabitur in libero ut mas', 3.31),
(7,'Panetone','Nulla justo. Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros.','Morbi non quam nec dui luctus rutrum. Nulla tellus.',8.67),
(8,'Lisinopril','Etiam faucibus cursus urna. Ut tellus. Nulla ut erat id mauris vulputate elementum.','Morbi porttitor lorem id ligula.',3.37),
(9,'Banitsa','Sed ante. Vivamus tortor. Duis mattis egestas metus.','Suspendisse accumsan tortor quis turpis. Sed ante. Vivamus tortor. Duis mattis egestas metus. Aenean fermentum.',21.77),
(10,'Caffeine passion','Proin eu mi. Nulla ac enim. In tempor turpis nec euismod scelerisque',' quam turpis adipiscing lorem vitae mattis nibh ligula nec sem.',7),
(11,'Root',' CRUDE PHOSPHORUS SULFUR','Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor.',0.91),
(12,'Sumapitan','In hac habitasse platea dictumst. Aliquam augue quam sollicitudin vitae consectetuer eget rutrum at lorem. Integer tincidunt ante vel ipsum.','Nam ultrices',3),
(13,'Nicotine Pleasure','Donec odio justo sollicitudin ut suscipit a feugiat et eros.','Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede venenatis non sodales sed tincidunt eu felis. Fusce posuere felis sed lacus. Morbi sem mauris',9),
(14,'Pear cake','Morbi sem mauris laoreet ut rhoncus aliquet pulvinar sed nisl. Nunc rhoncus dui vel sem.Donec odio justo','sollicitudin ut suscipit a feugiat et eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue diam id ornare imperdiet sa',1),
(15,'ALCOHOL Cake','Nulla facilisi.','Nullam molestie nibh in lectus. Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.',23.20),
(16,'Salt bread','Nullam varius. Nulla facilisi.','Praesent blandit. Nam nulla.',11.10),
(17,'Fire in kitchen','estibulum ac est lacinia nisi venenatis tristique. Fusce congue',' diam id ornare imperdiet', 12.1),
(18,'Pizza(small)','In sagittis dui vel nisl. Duis ac nibh.','Nulla tempus. Vivamus in felis eu sapien cursus vestibulum.',27.27),
(19,'Maleate','Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.','Lorem ipsum dolor sit amet',6),
(20,'Titanium breakfast','Proin risus.','Integer ac neque. Duis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus. In sagittis dui vel nisl.',26.18),
(21,'Oxygen bread','Morbi ut odio.','Lorem ipsum dolor sit amet consectetuer adipiscing elit.',27.39),
(22,'Bread','Mauris ullamcorper purus sit amet nulla.','Morbi ut odio.',1.84),
(23,'Rock','Curabitur in libero ut massa volutpat convallis. ','Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.',15.82),
(24,'Fish burger','Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend.','Nulla facilisi. Cras non velit nec nisi vulputate nonu',16.33),
(25,'Chicken salad','Nulla suscipit ligula in lacus. Curabitur at ipsum ac tellus semper interdum.','Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam. Suspendisse potenti. Nullam porttitor l',5.4),
(26,'guaifenesin',' dextromethorphan hydrobromide','Etiam vel augue. Vestibulum rutrum rutrum neque.',4.3),
(27,'iloperidone','Integer aliquet massa id lobortis convallis tortor risus dapibus augue ','Curabitur at ipsum ac tellus semper interdum.',21.86),
(28,'Amitriptyline','Lorem ipsum dolor sit amet  adipiscing elit. Proin risus.','Cras non velit nec nisi tincidunt lacus at velit.',4.77),
(29,'Atropinum Sulphuricum',' Berberis Vulgaris',' Bryonia', 1.21),
(30,'ALCOHOL','Suspendisse potenti.','Proin at turpis a pede posuere nonummy. Integer non velit.',24.37)

SET IDENTITY_INSERT Products OFF


-- Table: Feedbacks
SET IDENTITY_INSERT Feedbacks ON

INSERT INTO Feedbacks(Id,Description, Rate, ProductId, CustomerId) VALUES
(1,'I did not like the product',2.04,30,23),
(2,'Meh..',4.16,27,20),
(3,'Really delicious.',5.78,11,19),
(4,'Well cooked and well served. Would like to recommend new furniture.',7.49,18,16),
(5,'First food was not ok. Second I do not like sombreros. Third the music was bad.',3.6,6,14),
(6,'One of the best things I have ever eaten. Really enjoyed it.',9.57,14,9),
(7,'The best thing for breakfast!!!',9.65,1,27),
(8,'Intermediate food.',5.26,13,15),
(9,'Hmm. It''s that good that it''s suspicious',9.92,20,10),
(10,'Ingredients are the keys',8.0,5,25),
(11,'Worst food EVER!!!!1!.',1.67,12,15),
(12,'',7,12,22),
(13,'Nothing special',5.82,27,22),
(14,'Meh - spiders are tastier',5.4,7,28),
(15,'You should kill yourselves.',0.86,5,26),
(16,'Total garbage food.',1.11,22,22),
(17,'Babushka makes it better',7.29,17,21),
(18,'Way too salty',3.36,21,17),
(19,'I am glad that I have eaten here',8.06,11,7),
(20,'Best ingredients - worst cooking',7.23,22,30),
(21,'SPAM MESSAGEEEEEEE',6.66,17,26),
(22,'Totally worth it',8.96,25,4),
(23,'We had an amazing time.',7.77,21,14),
(24,'You should stop making these...',2.73,23,21),
(25,'Well- it is overpriced',5.54,9,18),
(26,'I do not know',5.56,5,28),
(27,'Hello - it''s me',9.56,18,18),
(28,'Let''s find some flavours',8.94,30,15),
(29,'Every food we enjoyed had a variety of options and was flavorful but also because the prices were so reasonable',9.35,6,19),
(30,'My greetings - it could be more enjoyable if ingredients were fresh',6.17,22,11),
(31,'',1.3,11,1),
(32,NULL,9.1,3,14),
(33,'More ingredients pleasseeeeee',7.6,14,3)

SET IDENTITY_INSERT Feedbacks OFF


-- Table: Ingredients
SET IDENTITY_INSERT Ingredients ON

INSERT INTO Ingredients (Id, Name, Description, OriginCountryId, DistributorId) VALUES
(1,'Allspice','It is a dark-brown pea-size berry. Comes from the evergreen pimento tree.',5,4),
(2,'Basil','Member of the mint family. It has green leaves.',12,3),
(3,'Bay Leaf','Leaves from the evergreen bay laurel tree. Also called laurel leaf.',2,14),
(4,'Bouket','Small bundle of herbs wrapped in a cheesecloth bag or tied together and added in soups to add flavor (parsley thyme and bay leaves is the classic combination).',10,6),
(5,'Cayenne','A mixture of seasoning made from different tropical chiles, including red cayenne peppers. It is very hot and spicy so use in moderation if you dont like spicy foods. Also called red pepper.',3,23),
(6,'Celery','Comes from wild Indian celery called lovage.',11,23),
(7,'Chili','A mixture of different seasonings (ground dried chiles coriander cumin garlic oregano and other herbs and spices).',15,30),
(8,'Chives','Belongs to the onion and leek family. Source of vitamin A.',10,27),
(9,'Cilantro','Bright-green stems and leaves from the coriander plant.',7,26),
(10,'Cinnamon','Bark from the Ceylon or Cassia tree Comes in buff color or dark reddish color.',8,28),
(11,'Clove','Reddish-brown budds from the tropical evergreen clove tree.',19,6),
(12,'Coriander','Related to the parsley family. Seeds from the coriander plant.',19,18),
(13,'Cumin','Dried fruit from a plant in the parsley family.',3,6),
(14,'Dill Seed','Dried seed from the dill plant',7,3),
(15,'Dill Weed','Green leaves from the dill plant',1,9),
(16,'Fennel','Oval greenish-brown seeds from the fennel plant',10,9),
(17,'Ginger','The root from the ginger plant',3,5),
(18,'Marjoram','Member of the mint and oregano family. Oval pale green leaves.',18,9),
(19,'Mint','One of the most popular spice used.',20,15),
(20,'Mustard','Comes in white yellow and brown seeds.',19,22),
(21,'Nutmeg','Oval seeds from the nutmeg tree. Dark grey color. Mace is the spice obtained from the membrane of the seeds.',7,22),
(22,'Oregano','Member of the mint family related to marjoram and thyme',15,8),
(23,'Paprika','Powdered dried red peppers',2,4),
(24,'Parsley','Curly leaf and Italian (flat-leaf) parsley are two of the more popular spices that exist.',11,27),
(25,'Peppercorn','Berries from the pepper plant. Black white and green peppercorns are three kinds processed from the this plant.',12,16),
(26,'Poppy','Very small gray white seeds from the poppy plant',2,4),
(27,'Rosemary','Silver-green leaves; member of the mint family',4,2),
(28,'Saffron','Dried yellow-orange stigmas from the crocus plant.',20,25),
(29,'Sage','Narrow oval gray-green leaves.',8,10),
(30,'Sesame','Tiny flat seeds brown red or black',2,5),
(31,'Tarragon','Narrow pointed dark-green leaves',12,7),
(32,'Thyme','Member of the mint family. It is a bush with gray-green leaves.',14,23),
(33,'Turmeric','Yellow-orange root of a plant related to ginger; used to flavor and color food.',18,22),
(40,'Cinnamon','Bark from the Ceylon or Cassia tree Comes in buff color or dark reddish color.',8,28),
(41,'Djodjen','Spearmint (djodjen or mentha spicata) is one of the typical Bulgarian spices that are omnipresent in Bulgarian cuisine. ',32,6),
(42,'Savory','Savory (chubritsa, merudia) is one of the most traditional Bulgarian spices. It is used as the base for many of the traditional Bulgarian spice mixes.',32,8),
(43,'Table Salt Savory Mix','Table Salt Savory Mix – Balkanska Rusenitsa is one of the several varieties of the Bulgarian Sharena Salt spice mix that is worth using as an everyday table spice.',32,6),
(44,'Savory - Traditional','Savory (chubritsa) is widely used for seasoning in Bulgarian cuisine. It is often blended together with salt and other herbs and spices to make another Bulgarian table favorite – sharena sol.',32,3),
(45,'Smardala','Smardala is a typical Bulgarian spice mix. Goes great on any dish you put salt on.',32,9),
(46,'Sharena Salt','The Bulgarian Sharena Salt (colorful salt, sharena sol mix) is a signature Bulgarian spice.',32,9),
(47,'Savory - Ronena','Savory is one of the most widely used and the oldest spices in Bulgarian cuisine.',32,5),
(48,'Cardamon','Member of the mint and oregano family. Oval pale green leaves.',32,9),
(49,'Fenugreek','One of the most popular spice used.',32,15),
(50,'Turmeric','Comes in white yellow and brown seeds.',32,22),
(51,'Garifalo','Garifalo (cloves) are an important ingredient in stifado and is also used in breads and sweets. ',31,22),
(52,'Kumino','Kumino (cumin) is used in soutzoukakia, the spicey meatballs served in tomato sauce.',31,8),
(53,'Sousami','Sousami (sesame seeds) are used on breads and in halva and with honey to make a sweet called pasteli. ',31,4),
(54,'Cardamom ','Cardamom has a strong piquant taste with lemon and pine notes. It is considered one of the most expensive spices and it is famous for its stimulating properties.',31,27),
(55,'Anise','The Greek name of anise “glykanissos” betrays its sweet character [glýka means sweetness]. Its best known use is in the famous ouzo, the Greeks’ favourite drink for the summertime.',31,16),
(56,'Mahlab','Mahlab comes from the kernel of the sour cherry. On account of its intense aroma it is mostly used in pastry-making, leaving a unique aftertaste of cherry and bitter almond.',31,4)

SET IDENTITY_INSERT Ingredients OFF


-- Table: ProductsIngredients
INSERT INTO ProductsIngredients (ProductId, IngredientId) VALUES
(12,32),
(8,11),
(24,21),
(29,26),
(3,24),
(11,11),
(12,9),
(18,22),
(29,19),
(13,10),
(8,22),
(10,25),
(15,14),
(14,29),
(6,27),
(30,33),
(7,20),
(20,18),
(25,12),
(14,15),
(2,24),
(2,20),
(14,17),
(16,26),
(2,17),
(3,20),
(23,11),
(27,4),
(1,21),
(14,16),
(7,18),
(3,12),
(14,3),
(8,9),
(27,9),
(28,5),
(25,13),
(30,12),
(8,31),
(9,15),
(26,2),
(3,27),
(7,25),
(10,33),
(19,13),
(23,4),
(14,28),
(11,18),
(22,4)