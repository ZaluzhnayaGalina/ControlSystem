IF NOT EXISTS ( select * from sysobjects where name='t_user')
CREATE TABLE  t_user(id_user uniqueidentifier Primary KEY, name NVARCHAR(255), password NVARCHAR(255), role NVARCHAR(1))

--Создаем таблицу "курс" если она не существует
            IF NOT EXISTS ( select * from sysobjects where name='course') CREATE TABLE 
course (id_course uniqueidentifier PRIMARY KEY, name NVARCHAR(50));

--создаем таблицу "тема", если она не существует
            IF NOT EXISTS ( select * from sysobjects where name='topic') CREATE TABLE
topic (id_topic uniqueidentifier PRIMARY KEY, name NVARCHAR(50), time int, id_course uniqueidentifier FOREIGN KEY REFERENCES course(id_course), count int);

--создаем таблицу "вопрос", если она не существует
            IF NOT EXISTS ( select * from sysobjects where name='question')
CREATE TABLE question (id_que uniqueidentifier PRIMARY KEY, text NVARCHAR(255), type NVARCHAR(3), count int, id_topic uniqueidentifier FOREIGN KEY REFERENCES topic(id_topic));

 --создаем таблицу "ответ", если она не существует
            IF NOT EXISTS ( select * from sysobjects where name='answer') CREATE TABLE
answer (id_answ uniqueidentifier PRIMARY KEY, text NVARCHAR(255), id_que uniqueidentifier FOREIGN KEY REFERENCES question(id_que), point int);

            IF NOT EXISTS ( select * from sysobjects where name='coordinates') CREATE TABLE
coordinates (id_coord uniqueidentifier PRIMARY KEY, axisX NVARCHAR(255), axisY NVARCHAR(255),  type NVARCHAR(20), points int, id_que uniqueidentifier FOREIGN KEY REFERENCES question(id_que));

            IF NOT EXISTS ( select * from sysobjects where name='result')  
CREATE TABLE result (id_result uniqueidentifier PRIMARY KEY, id_course uniqueidentifier FOREIGN KEY REFERENCES course(id_course), 
id_topic uniqueidentifier FOREIGN KEY REFERENCES topic(id_topic), id_user uniqueidentifier  FOREIGN KEY REFERENCES t_user(id_user), points int, date DATE, time TIME);