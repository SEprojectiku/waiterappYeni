create schema users
go

CREATE TABLE  users.userinfo(
    userID int IDENTITY(1,1) not null PRIMARY KEY,
    firstName nvarchar(30) not null,
    lastName nvarchar(40) not null,
	userName nvarchar(59) not null UNIQUE,
	email nvarchar(100) not null UNIQUE,
	phoneNumber nvarchar(15) not null,
	userPassword nvarchar(32) not null,
	birthDay date,
	gender char(1) not null,
    city smallint not null FOREIGN KEY REFERENCES states(id),
	lang smallint null FOREIGN KEY REFERENCES languages(id),
	currency tinyint not null FOREIGN KEY REFERENCES currency(id),
	registerDate date not null,
	membershipStatus bit not null default 1
);

select * from users.userinfo
select * from currency

CREATE TABLE users.userCreditCardinfo(
	cardID int IDENTITY(1,1) not null PRIMARY KEY,
	cardHolder nvarchar(60) not null,
	cardNumber nvarchar(25) not null UNIQUE,
	expMonth tinyint not null,
	expyear tinyint not null,
	modifiedDate datetime not null,
	cardstatus bit not null default 1,
	userID int FOREIGN KEY REFERENCES users.userinfo(userID)

);

create schema business
go

CREATE TABLE  business.memberinfo(
    memberID int IDENTITY(1,1) not null PRIMARY KEY,
    firstName nvarchar(30) not null,
    lastName nvarchar(40) not null,
	userName nvarchar(59) not null UNIQUE,
	email nvarchar(100) not null UNIQUE,
	phone1 nvarchar(15) not null,
	phone2 nvarchar(15) null,
	userPassword nvarchar(32) not null,
	birthDay date,
	gender char(1) not null,
    city smallint not null FOREIGN KEY REFERENCES states(id),
	lang smallint null FOREIGN KEY REFERENCES languages(id),
	registerDate date not null,
	membershipStatus bit not null default 1
);
select * from business.Businessinfo

ALTER TABLE business.Businessinfo
ADD memberID int not null FOREIGN KEY REFERENCES business.memberinfo(memberID)

CREATE TABLE  business.Businessinfo(
    bID int IDENTITY(1,1) not null PRIMARY KEY,
	bName nvarchar(100) not null,
	bdesc nvarchar(300) not null,
	city smallint not null FOREIGN KEY REFERENCES states(id),
	establishedYear smallint null,
	registerDate date not null,
	phone1 nvarchar(15) not null,
	phone2 nvarchar(15) null,
	email nvarchar(100) not null UNIQUE,
	lat decimal(10,6) NOT NULL,
    lng decimal(10,6) NOT NULL,
	avaragePrice smallint null,
	tableNumber smallint not null,
	workOpen tinyint not null,
	workClose tinyint not null,
	activeStatus bit not null default 1,
	memberID int not null FOREIGN KEY REFERENCES business.memberinfo(memberID)

);

CREATE TABLE  business.photos(
	bID int FOREIGN KEY REFERENCES business.businessinfo(bID),
	photoPath nvarchar(250) not null,
	photoDesc nvarchar(100),
	addedDate date null
);

CREATE TABLE  business.wificonnections(
	bID int FOREIGN KEY REFERENCES business.businessinfo(bID),
	connecitonName nvarchar(50),
	connectionPassword nvarchar(100)
);

CREATE TABLE business.businessBankAccount(
	accID int IDENTITY(1,1) not null PRIMARY KEY,
	nameofAccount nvarchar(80) not null,
	iban nvarchar(22) not null UNIQUE,
	bID int FOREIGN KEY REFERENCES business.businessinfo(bID)

);


CREATE TABLE business.memberCardinfo(
	cardID int IDENTITY(1,1) not null PRIMARY KEY,
	cardHolder nvarchar(60) not null,
	cardNumber nvarchar(25) not null UNIQUE,
	expMonth tinyint not null,
	expyear tinyint not null,
	modifiedDate datetime not null,
	cardstatus bit not null default 1,
	memberID int FOREIGN KEY REFERENCES business.memberinfo(memberID)

);



CREATE TABLE business.tableinfo(
	tID int IDENTITY(1,1) not null PRIMARY KEY,
	tName nvarchar(40),
	chairNumber tinyint not null,
	tableType smallint not null FOREIGN KEY REFERENCES tableTypes(typeID),
	cigaratteAllowed bit not null default 0,
	bID int FOREIGN KEY REFERENCES business.businessinfo(bID),
	isAvailable bit not null default 1
);

CREATE TABLE business.reservation(
	resID int IDENTITY(1,1) not null PRIMARY KEY,
	userID int FOREIGN KEY REFERENCES users.userinfo(userID),
	tableID int FOREIGN KEY REFERENCES business.tableinfo(tID),
	reservationDate date not null,
	reservationTime tinyint not null,
	reservatedTime datetime not null

);

CREATE TABLE  business.reservationRules(
	bID int not null FOREIGN KEY REFERENCES business.businessinfo(bID),
	isCardNeededforReservation bit not null,
	latestCancelTime tinyint null,
	lateCancelFine smallmoney null default 0

);

CREATE TABLE business.menu(
	menuID int IDENTITY(1,1) not null PRIMARY KEY,
	menuName nvarchar(150),
	isMenuOnline bit not null default 1,
	bID int not null FOREIGN KEY REFERENCES business.businessinfo(bID),
	lastUpdatedDate date not null
	
);

CREATE TABLE business.menudetails(
	foodbeveragesID int IDENTITY(1,1) not null PRIMARY KEY,
	menuID int not null FOREIGN KEY REFERENCES business.menu(menuID),
	foodbeveragesName nvarchar(150) not null,
	catID int FOREIGN KEY REFERENCES menucategories(catID),
	ingredients nvarchar(300) null,
	prepairingTime nvarchar(20) null,
	price money not null,
	visibility bit not null default 1,
	lastUpdated date

);

CREATE TABLE business.businessType(
	bID int not null FOREIGN KEY REFERENCES business.businessinfo(bID),
	typeID smallint not null FOREIGN KEY REFERENCES businessTypes(typeID)
);

create schema orders

CREATE TABLE orders.orders(
	orderID int IDENTITY(1,1) not null PRIMARY KEY,
	bID int not null FOREIGN KEY REFERENCES business.businessinfo(bID),
	userID int FOREIGN KEY REFERENCES users.userinfo(userID),
	tableID int not null FOREIGN KEY REFERENCES business.tableinfo(tID),
	orderDate datetime not null,
	orderStatus nvarchar(20) not null default 'Active',
	orderBeReadyDirective bit not null default 0
);

CREATE TABLE orders.orderDetails(
	orderID int not null FOREIGN KEY REFERENCES orders.orders(orderID),
	foodbeveragesID int not null FOREIGN KEY REFERENCES business.menudetails(foodbeveragesID),
	piece tinyint not null,
	orderDesc nvarchar(100) null
	
);

----------------------------
----------------------------
CREATE TABLE business.payment(
	paymentID int IDENTITY(1,1) not null PRIMARY KEY,
	bID int not null FOREIGN KEY REFERENCES business.businessinfo(bID),
	cardID int FOREIGN KEY REFERENCES users.userinfo(userID),
	orderID int FOREIGN KEY REFERENCES orders.orders(orderID),
	total int not null,
	isConfirmed bit not null default 0
);

CREATE TABLE business.paymentMethods(
	bID int not null FOREIGN KEY REFERENCES business.businessinfo(bID),
	methodID int not null FOREIGN KEY REFERENCES allPaymentMethods(methodID),
	accountNameorAdress nvarchar
);

CREATE TABLE allPaymentMethods(
	methodID int IDENTITY(1,1) not null PRIMARY KEY,
	methodName nvarchar(30) not null,
	methodDesc nvarchar(100) null

);


CREATE TABLE businessTypes(
	typeID smallint IDENTITY(1,1) not null PRIMARY KEY,
	typeName nvarchar(50),
	typeDesc nvarchar(50)

);

CREATE TABLE tableTypes(
	typeID smallint IDENTITY(1,1) not null PRIMARY KEY,
	tableType nvarchar(30) not null,
	typeDesc nvarchar(60) not null

);
CREATE TABLE depts(
	bID int not null FOREIGN KEY REFERENCES business.businessinfo(bID),
	totalAmount money not null,
	lastUpdateDate date not null
	
);

CREATE TABLE commissionPayHistory(
	bID int FOREIGN KEY REFERENCES business.businessinfo(bID),
	comAmount money not null,
	paymentDate datetime not null
);

CREATE TABLE menucategories(
	catID int IDENTITY(1,1) not null PRIMARY KEY,
	catName nvarchar(50) not null,
	catDesc nvarchar(100) null
	
);


CREATE TABLE tags(
	bID int FOREIGN KEY REFERENCES business.businessinfo(bID),
	tagName nvarchar(30)
);


CREATE TABLE currency (
  id tinyint,
  currency char(49),
  symbol char(3),
  PRIMARY KEY (id)
);


INSERT INTO currency VALUES(1, 'Euro', 'EUR');
INSERT INTO currency VALUES(2, 'US Dollar', 'USD');
INSERT INTO currency VALUES(3, 'Russian Ruble', 'RUB');
INSERT INTO currency VALUES(4, 'British Pound', 'GBR');
INSERT INTO currency VALUES(5, 'Turk Lirasi', 'TRY');
INSERT INTO currency VALUES(6, 'Bulgarian lev', 'BGN');
INSERT INTO currency VALUES(7, 'Serbian dinar', 'RSD');
INSERT INTO currency VALUES(8, 'Hungarian Forint', 'HUF');
select * from currency
drop table currency


CREATE TABLE languages (
  id smallint not null,
  name char(49),
  iso_639 char(2),
  PRIMARY KEY (id)
);

-- Languages --
INSERT INTO languages VALUES(1, 'English', 'en');
INSERT INTO languages VALUES(2, 'Arabic', 'ar');
INSERT INTO languages VALUES(3, 'Azerbaijani', 'az');
INSERT INTO languages VALUES(4, 'Belarusian', 'be');
INSERT INTO languages VALUES(5, 'Bulgarian', 'bg');
INSERT INTO languages VALUES(6, 'Tibetan', 'bo');
INSERT INTO languages VALUES(7, 'Catalan', 'ca');
INSERT INTO languages VALUES(8, 'Czech', 'cs');
INSERT INTO languages VALUES(9, 'Welsh', 'cy');
INSERT INTO languages VALUES(10, 'Danish', 'da');
INSERT INTO languages VALUES(23, 'German', 'de');
INSERT INTO languages VALUES(24, 'Bhutani', 'dz');
INSERT INTO languages VALUES(25, 'Greek', 'el');
INSERT INTO languages VALUES(27, 'Spanish', 'es');
INSERT INTO languages VALUES(28, 'Estonian', 'et');
INSERT INTO languages VALUES(30, 'Persian', 'fa');
INSERT INTO languages VALUES(31, 'Finnish', 'fi');
INSERT INTO languages VALUES(33, 'Faeroese', 'fo');
INSERT INTO languages VALUES(34, 'French', 'fr');
INSERT INTO languages VALUES(35, 'Frisian', 'fy');
INSERT INTO languages VALUES(36, 'Irish', 'ga');
INSERT INTO languages VALUES(37, 'Scots/Gaelic', 'gd');
INSERT INTO languages VALUES(42, 'Hindi', 'hi');
INSERT INTO languages VALUES(43, 'Croatian', 'hr');
INSERT INTO languages VALUES(44, 'Hungarian', 'hu');
INSERT INTO languages VALUES(45, 'Armenian', 'hy');
INSERT INTO languages VALUES(49, 'Indonesian', 'in');
INSERT INTO languages VALUES(50, 'Icelandic', 'is');
INSERT INTO languages VALUES(51, 'Italian', 'it');
INSERT INTO languages VALUES(53, 'Japanese', 'ja');
INSERT INTO languages VALUES(56, 'Georgian', 'ka');
INSERT INTO languages VALUES(57, 'Kazakh', 'kk');
INSERT INTO languages VALUES(58, 'Greenlandic', 'kl');
INSERT INTO languages VALUES(59, 'Cambodian', 'km');
INSERT INTO languages VALUES(60, 'Kannada', 'kn');
INSERT INTO languages VALUES(61, 'Korean', 'ko');
INSERT INTO languages VALUES(62, 'Kashmiri', 'ks');
INSERT INTO languages VALUES(63, 'Kurdish', 'ku');
INSERT INTO languages VALUES(64, 'Kirghiz', 'ky');
INSERT INTO languages VALUES(65, 'Latin', 'la');
INSERT INTO languages VALUES(67, 'Laothian', 'lo');
INSERT INTO languages VALUES(68, 'Lithuanian', 'lt');
INSERT INTO languages VALUES(69, 'Latvian/Lettish', 'lv');
INSERT INTO languages VALUES(71, 'Maori', 'mi');
INSERT INTO languages VALUES(72, 'Macedonian', 'mk');
INSERT INTO languages VALUES(73, 'Malayalam', 'ml');
INSERT INTO languages VALUES(74, 'Mongolian', 'mn');
INSERT INTO languages VALUES(75, 'Moldavian', 'mo');
INSERT INTO languages VALUES(76, 'Marathi', 'mr');
INSERT INTO languages VALUES(77, 'Malay', 'ms');
INSERT INTO languages VALUES(78, 'Maltese', 'mt');
INSERT INTO languages VALUES(80, 'Nauru', 'na');
INSERT INTO languages VALUES(81, 'Nepali', 'ne');
INSERT INTO languages VALUES(82, 'Dutch', 'nl');
INSERT INTO languages VALUES(83, 'Norwegian', 'no');
INSERT INTO languages VALUES(87, 'Polish', 'pl');
INSERT INTO languages VALUES(89, 'Portuguese', 'pt');
INSERT INTO languages VALUES(93, 'Romanian', 'ro');
INSERT INTO languages VALUES(94, 'Russian', 'ru');
INSERT INTO languages VALUES(99, 'Serbo-Croatian', 'sh');
INSERT INTO languages VALUES(100, 'Singhalese', 'si');
INSERT INTO languages VALUES(101, 'Slovak', 'sk');
INSERT INTO languages VALUES(102, 'Slovenian', 'sl');
INSERT INTO languages VALUES(105, 'Somali', 'so');
INSERT INTO languages VALUES(106, 'Albanian', 'sq');
INSERT INTO languages VALUES(107, 'Serbian', 'sr');
INSERT INTO languages VALUES(110, 'Sundanese', 'su');
INSERT INTO languages VALUES(111, 'Swedish', 'sv');
INSERT INTO languages VALUES(115, 'Tajik', 'tg');
INSERT INTO languages VALUES(116, 'Thai', 'th');
INSERT INTO languages VALUES(117, 'Tigrinya', 'ti');
INSERT INTO languages VALUES(118, 'Turkmen', 'tk');
INSERT INTO languages VALUES(121, 'Tonga', 'to');
INSERT INTO languages VALUES(122, 'Turkish', 'tr');
INSERT INTO languages VALUES(124, 'Tatar', 'tt');
INSERT INTO languages VALUES(126, 'Ukrainian', 'uk');
INSERT INTO languages VALUES(128, 'Uzbek', 'uz');
INSERT INTO languages VALUES(129, 'Vietnamese', 'vi');
INSERT INTO languages VALUES(134, 'Chinese', 'zh');