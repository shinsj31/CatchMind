create database catchmind_db;
use catchmind_db;

create table host (
	room_id int not null auto_increment primary key,
    ip		varchar(15) not null,
    room_num int not null,
    curr_num int not null
);

create table game (
	qid int not null auto_increment primary key,
	question varchar(100) not null
);

alter table host auto_increment=1;
alter table game auto_increment=1;

insert into game(question) values('개');
insert into game(question) values('고양이');
insert into game(question) values('원숭이');
insert into game(question) values('연가시');
insert into game(question) values('부산행');
insert into game(question) values('지져스');
insert into game(question) values('오마이갓');
insert into game(question) values('안녕');
insert into game(question) values('인사');
insert into game(question) values('책상');
insert into game(question) values('얼굴');
insert into game(question) values('사물놀이');
insert into game(question) values('하하');	
insert into game(question) values('호호');
insert into game(question) values('에라이');
insert into game(question) values('돌침대');
insert into game(question) values('안마의자');
insert into game(question) values('정답');
insert into game(question) values('문제');
insert into game(question) values('김삿갓');
insert into game(question) values('아파트');
