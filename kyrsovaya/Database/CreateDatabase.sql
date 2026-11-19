/*
  База данных: учёт редких видов растений и животных национального парка.
  Запускается в SQL Server Management Studio (подключение к (localdb)\MSSQLLocalDB)
  или автоматически самим приложением при первом старте.

  Тестовые учётные записи:
    admin   / Admin2024!Park   (администратор)
    ivanov  / Park2024!Demo    (научный сотрудник)
    visitor1/ Park2024!Demo    (посетитель)
*/

IF DB_ID(N'NationalParkDB') IS NULL
    CREATE DATABASE NationalParkDB;
GO

USE NationalParkDB;
GO

-- Удаляем старые таблицы (порядок важен из-за внешних ключей)
DROP TABLE IF EXISTS ExcursionBookings;
DROP TABLE IF EXISTS Excursions;
DROP TABLE IF EXISTS Observations;
DROP TABLE IF EXISTS Species;
DROP TABLE IF EXISTS Zones;
DROP TABLE IF EXISTS ConservationStatuses;
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS Roles;
GO

-- ===================== Таблицы =====================

CREATE TABLE Roles (
    Id   INT          NOT NULL PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Users (
    Id           INT IDENTITY(1,1) PRIMARY KEY,
    Login        NVARCHAR(30)  NOT NULL UNIQUE,
    PasswordHash CHAR(64)      NOT NULL,          -- SHA-256 в виде hex-строки
    LastName     NVARCHAR(50)  NOT NULL,
    FirstName    NVARCHAR(50)  NOT NULL,
    Email        NVARCHAR(100) NOT NULL UNIQUE,
    Phone        CHAR(10)      NOT NULL UNIQUE,   -- только 10 цифр без +7
    RoleId       INT           NOT NULL REFERENCES Roles(Id),
    CreatedAt    DATETIME2     NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE ConservationStatuses (
    Id   INT          NOT NULL PRIMARY KEY,
    Code NVARCHAR(5)  NOT NULL UNIQUE,            -- код по шкале МСОП
    Name NVARCHAR(60) NOT NULL
);

CREATE TABLE Zones (
    Id          INT IDENTITY(1,1) PRIMARY KEY,
    Name        NVARCHAR(100) NOT NULL UNIQUE,
    AreaHa      DECIMAL(10,1) NOT NULL CHECK (AreaHa > 0),
    Description NVARCHAR(300) NULL
);

CREATE TABLE Species (
    Id          INT IDENTITY(1,1) PRIMARY KEY,
    Name        NVARCHAR(100) NOT NULL UNIQUE,
    LatinName   NVARCHAR(100) NOT NULL,
    Kind        NVARCHAR(20)  NOT NULL CHECK (Kind IN (N'Животное', N'Растение', N'Гриб')),
    StatusId    INT           NOT NULL REFERENCES ConservationStatuses(Id),
    Population  INT           NOT NULL CHECK (Population >= 0),
    Description NVARCHAR(500) NULL
);

CREATE TABLE Observations (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    SpeciesId       INT           NOT NULL REFERENCES Species(Id),
    ZoneId          INT           NOT NULL REFERENCES Zones(Id),
    UserId          INT           NOT NULL REFERENCES Users(Id),
    ObservationDate DATE          NOT NULL,
    Quantity        INT           NOT NULL CHECK (Quantity > 0),
    Notes           NVARCHAR(300) NULL
);
GO

-- ===================== Данные =====================

INSERT INTO Roles (Id, Name) VALUES
(1, N'Администратор'),
(2, N'Научный сотрудник'),
(3, N'Посетитель');

INSERT INTO ConservationStatuses (Id, Code, Name) VALUES
(1, N'EX', N'Исчезнувший'),
(2, N'CR', N'На грани исчезновения'),
(3, N'EN', N'Вымирающий'),
(4, N'VU', N'Уязвимый'),
(5, N'NT', N'Близкий к угрозе'),
(6, N'LC', N'Вызывает наименьшие опасения'),
(7, N'DD', N'Недостаточно данных');

-- Пароли: admin -> Admin2024!Park, остальные -> Park2024!Demo
INSERT INTO Users (Login, PasswordHash, LastName, FirstName, Email, Phone, RoleId) VALUES
(N'admin',    CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Admin2024!Park'), 2), N'Шишлов',    N'Антон',     N'admin@grinpich.ru',     '9001112233', 1),
(N'ivanov',   CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Park2024!Demo'), 2),  N'Иванов',    N'Сергей',    N'ivanov@grinpich.ru',    '9001112234', 2),
(N'petrova',  CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Park2024!Demo'), 2),  N'Петрова',   N'Анна',      N'petrova@grinpich.ru',   '9001112235', 2),
(N'sidorov',  CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Park2024!Demo'), 2),  N'Сидоров',   N'Михаил',    N'sidorov@grinpich.ru',   '9001112236', 2),
(N'kuznetsova', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Park2024!Demo'), 2), N'Кузнецова', N'Елена',    N'kuznetsova@grinpich.ru','9001112237', 2),
(N'visitor1', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Park2024!Demo'), 2),  N'Смирнов',   N'Дмитрий',   N'smirnov@mail.ru',       '9002223341', 3),
(N'visitor2', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Park2024!Demo'), 2),  N'Попова',    N'Мария',     N'popova@mail.ru',        '9002223342', 3),
(N'visitor3', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Park2024!Demo'), 2),  N'Соколов',   N'Андрей',    N'sokolov@mail.ru',       '9002223343', 3),
(N'visitor4', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Park2024!Demo'), 2),  N'Лебедева',  N'Ольга',     N'lebedeva@mail.ru',      '9002223344', 3),
(N'visitor5', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Park2024!Demo'), 2),  N'Козлов',    N'Игорь',     N'kozlov@mail.ru',        '9002223345', 3),
(N'visitor6', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Park2024!Demo'), 2),  N'Новикова',  N'Татьяна',   N'novikova@mail.ru',      '9002223346', 3),
(N'visitor7', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Park2024!Demo'), 2),  N'Морозов',   N'Павел',     N'morozov@mail.ru',       '9002223347', 3),
(N'visitor8', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Park2024!Demo'), 2),  N'Волкова',   N'Наталья',   N'volkova@mail.ru',       '9002223348', 3),
(N'visitor9', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Park2024!Demo'), 2),  N'Зайцев',    N'Алексей',   N'zaytsev@mail.ru',       '9002223349', 3),
(N'visitor10',CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Park2024!Demo'), 2),  N'Орлова',    N'Светлана',  N'orlova@mail.ru',        '9002223350', 3);

INSERT INTO Zones (Name, AreaHa, Description) VALUES
(N'Северный кордон',        1250.0, N'Охраняемая граница парка, горные склоны'),
(N'Берег реки Тихой',        480.5, N'Пойменный лес вдоль реки'),
(N'Сосновый бор',           2100.0, N'Сосновый лес с лишайниковым покровом'),
(N'Журавлиное болото',       860.0, N'Верховое болото, места гнездования птиц'),
(N'Орлиный хребет',         1740.0, N'Скалы и горные луга'),
(N'Озеро Лазурное',          320.0, N'Пресноводное озеро с заболоченными берегами'),
(N'Кедровая падь',          1530.0, N'Кедрово-широколиственный лес'),
(N'Дубрава',                 690.0, N'Участок старовозрастного дубового леса'),
(N'Луговая степь',           970.0, N'Разнотравные степные участки'),
(N'Скалистый мыс',           210.0, N'Прибрежные скалы, колонии птиц'),
(N'Заповедная роща',         150.0, N'Ядро заповедного режима, посещение запрещено'),
(N'Устье реки',              540.0, N'Нерестилища осетровых рыб'),
(N'Таёжный массив',         3900.0, N'Тёмнохвойная тайга'),
(N'Пойменные луга',          760.0, N'Влажные луга, весенние разливы'),
(N'Каменистая россыпь',      390.0, N'Курумники и каменные осыпи');

INSERT INTO Species (Name, LatinName, Kind, StatusId, Population, Description) VALUES
(N'Амурский тигр',                  N'Panthera tigris altaica',      N'Животное', 3, 12,   N'Крупнейшая кошка планеты, охотится на копытных'),
(N'Дальневосточный леопард',        N'Panthera pardus orientalis',   N'Животное', 2, 8,    N'Одна из самых редких кошек мира'),
(N'Снежный барс',                   N'Panthera uncia',               N'Животное', 4, 5,    N'Обитает в высокогорье, ведёт скрытный образ жизни'),
(N'Белоплечий орлан',               N'Haliaeetus pelagicus',         N'Животное', 4, 14,   N'Крупная хищная птица побережий и рек'),
(N'Дальневосточный аист',           N'Ciconia boyciana',             N'Животное', 3, 9,    N'Гнездится на высоких деревьях у водоёмов'),
(N'Даурский журавль',               N'Antigone vipio',               N'Животное', 4, 21,   N'Перелётная птица, гнездится на болотах'),
(N'Чёрный аист',                    N'Ciconia nigra',                N'Животное', 5, 33,   N'Скрытная лесная птица'),
(N'Амурский горал',                 N'Naemorhedus caudatus',         N'Животное', 5, 60,   N'Горная антилопа, живёт на скалах'),
(N'Сибирский осётр',                N'Acipenser baerii',             N'Животное', 2, 40,   N'Проходная рыба, нерестится в верховьях рек'),
(N'Калуга',                         N'Huso dauricus',                N'Животное', 2, 25,   N'Крупнейшая пресноводная рыба'),
(N'Реликтовая чайка',               N'Ichthyaetus relictus',         N'Животное', 4, 30,   N'Редкая чайка, гнездится на островах озёр'),
(N'Беркут',                         N'Aquila chrysaetos',            N'Животное', 6, 18,   N'Хищная птица открытых пространств'),
(N'Женьшень настоящий',             N'Panax ginseng',                N'Растение', 3, 340,  N'Лекарственное растение, растёт в кедровниках'),
(N'Венерин башмачок настоящий',     N'Cypripedium calceolus',        N'Растение', 5, 520,  N'Редкая орхидея лесных полян'),
(N'Кедр корейский',                 N'Pinus koraiensis',             N'Растение', 4, 1200, N'Дерево с ценными съедобными орехами'),
(N'Рододендрон Шлиппенбаха',        N'Rhododendron schlippenbachii', N'Растение', 5, 800,  N'Кустарник, цветущий ранней весной'),
(N'Лотос орехоносный',              N'Nelumbo nucifera',             N'Растение', 4, 150,  N'Водное растение мелководных озёр'),
(N'Тис остроконечный',              N'Taxus cuspidata',              N'Растение', 3, 95,   N'Медленно растущее хвойное дерево'),
(N'Грифола зонтичная',              N'Grifola umbellata',            N'Гриб',     7, 70,   N'Трутовик, растёт у корней дубов'),
(N'Ежовик коралловидный',           N'Hericium coralloides',         N'Гриб',     5, 110,  N'Редкий гриб старых лиственных лесов');

INSERT INTO Observations (SpeciesId, ZoneId, UserId, ObservationDate, Quantity, Notes) VALUES
(1,  13, 2, '2025-09-14', 1, N'Следы у ручья, свежие'),
(1,  1,  3, '2025-10-02', 2, N'Самка с детёнышем, фотоловушка'),
(2,  5,  2, '2025-11-21', 1, N'Зафиксирован фотоловушкой ночью'),
(3,  5,  4, '2026-01-12', 1, N'Следы на снегу вдоль хребта'),
(4,  12, 3, '2026-02-03', 3, N'Три птицы на льду у устья'),
(5,  4,  5, '2026-04-18', 2, N'Пара строит гнездо'),
(6,  4,  5, '2026-05-07', 6, N'Стая на весеннем пролёте'),
(7,  2,  2, '2026-05-20', 1, N'Кормится на мелководье'),
(8,  15, 4, '2026-06-01', 7, N'Стадо на каменной россыпи'),
(9,  12, 3, '2026-06-15', 4, N'Нерест, учёт по сетям'),
(10, 12, 3, '2026-06-16', 2, N'Крупные особи, помечены'),
(11, 6,  5, '2026-06-25', 12, N'Колония на острове озера'),
(12, 10, 2, '2026-07-04', 1, N'Парит над скалами'),
(13, 7,  4, '2026-07-19', 15, N'Группа растений под пологом леса'),
(14, 9,  5, '2026-07-22', 28, N'Цветущая популяция на поляне'),
(15, 7,  2, '2026-08-05', 40, N'Плодоношение, учёт на пробной площадке'),
(16, 1,  4, '2026-08-11', 22, N'Кусты вдоль тропы'),
(17, 6,  5, '2026-08-23', 18, N'Заросли у берега озера'),
(18, 11, 3, '2026-09-09', 6, N'Молодые деревья в заповедной роще'),
(20, 8,  2, '2026-09-30', 3, N'Плодовые тела на старом дубе');
GO

-- === EXCURSIONS_START ===
CREATE TABLE Excursions (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    Title           NVARCHAR(120) NOT NULL,
    ZoneId          INT           NOT NULL REFERENCES Zones(Id),
    GuideId         INT           NOT NULL REFERENCES Users(Id),
    ExcursionDate   DATETIME2     NOT NULL,
    MaxParticipants INT           NOT NULL CHECK (MaxParticipants > 0),
    IsOpen          BIT           NOT NULL DEFAULT 1,
    Description     NVARCHAR(400) NULL
);

CREATE TABLE ExcursionBookings (
    Id          INT IDENTITY(1,1) PRIMARY KEY,
    ExcursionId INT       NOT NULL REFERENCES Excursions(Id),
    UserId      INT       NOT NULL REFERENCES Users(Id),
    BookedAt    DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT UQ_ExcursionBookings_User UNIQUE (ExcursionId, UserId)
);
GO

INSERT INTO Excursions (Title, ZoneId, GuideId, ExcursionDate, MaxParticipants, IsOpen, Description) VALUES
(N'Тропа амурского тигра',            1,  2, '2026-11-28 10:00', 10, 1, N'Знакомство со следами жизнедеятельности крупных хищников на северной границе парка'),
(N'Утро на реке Тихой',               2,  3, '2026-11-30 09:00', 12, 1, N'Прогулка по пойменному лесу, наблюдение за водоплавающими птицами'),
(N'Зимний сосновый бор',              3,  4, '2026-12-05 11:00', 15, 1, N'Экологическая тропа среди вековых сосен и лишайников'),
(N'Птицы Журавлиного болота',         4,  5, '2026-12-08 08:30', 8,  1, N'Наблюдение с деревянного настила со смотровой вышки'),
(N'Панорама Орлиного хребта',         5,  2, '2026-12-12 10:00', 10, 1, N'Подъём на смотровую площадку, рассказ о белоплечем орлане и горале'),
(N'Озеро Лазурное зимой',             6,  3, '2026-12-15 11:30', 14, 1, N'Экскурсия к берегам незамерзающих ключей озера'),
(N'Тайны кедровой пади',              7,  4, '2026-12-19 10:00', 12, 1, N'Рассказ о кедре корейском, женьшене и обитателях кедровника'),
(N'Вековая дубрава',                  8,  5, '2026-12-22 12:00', 15, 1, N'Осмотр старовозрастных дубов и редких древесных грибов'),
(N'Зимняя степь и её обитатели',      9,  2, '2026-12-26 11:00', 12, 1, N'Маршрут по разнотравно-степной зоне парка'),
(N'Скалистый мыс и колонии птиц',     10, 3, '2027-01-09 10:30', 10, 1, N'Обзор прибрежных скал, инструктаж по бережному наблюдению'),
(N'Нерестилища устья реки',           12, 4, '2027-01-16 10:00', 10, 1, N'Лекция об охране сибирского осетра и калуги на участке устья'),
(N'Сердце тёмнохвойной тайги',        13, 2, '2027-01-23 09:30', 8,  0, N'Группа временно закрыта научным сотрудником для корректировки маршрута'),
(N'Пойменные луга на рассвете',       14, 5, '2027-01-30 08:00', 12, 1, N'Фотопрогулка по маршруту весенних разливов'),
(N'Каменные россыпи и горалы',        15, 4, '2026-11-10 10:00', 10, 0, N'Экскурсия уже проведена'),
(N'Осенний учёт в Кедровой пади',     7,  3, '2026-10-24 10:00', 12, 0, N'Экскурсия завершена, отчёт сдан в архив');

INSERT INTO ExcursionBookings (ExcursionId, UserId) VALUES
(1,  6),
(1,  7),
(1,  8),
(2,  6),
(2,  9),
(3,  7),
(3,  10),
(3,  11),
(4,  8),
(5,  6),
(5,  12),
(6,  13),
(7,  7),
(7,  14),
(8,  15),
(9,  9),
(10, 10),
(14, 6),
(14, 7),
(15, 8);
GO
