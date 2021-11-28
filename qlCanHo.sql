create database bttbCanHo
use bttbCanHo
create table NhanVien
(
	MaNV int primary key,
	TenNV varchar(50),
	SoDT varchar(20),
	GioiTinh varchar(10)
)
create table CanHo
(
	MaCH int primary key,
	TenCH varchar(100)
)
create table ThietBi
(
	MaTB int primary key,
	TenTB varchar(100)
)
create table NV_BT
(
	MaNV int,
	MaTB int,
	MaCH int,
	LanThu int,
	NgayBT smalldatetime
	constraint KC primary key (MaNV, MaTB, MaCH, LanThu),
	constraint KN1 foreign key (MaNV) references NhanVien(MaNV),
	constraint KN2 foreign key (MaTB) references ThietBi(MaTB),
	constraint KN3 foreign key (MaCH) references CanHo(MaCH),
)
INSERT INTO NhanVien VALUES ('1','NGUYEN VAN A',null,1);
INSERT INTO NhanVien VALUES ('2','NGUYEN VAN B',null,1);
INSERT INTO NhanVien VALUES ('3','NGUYEN THI C',null,0);
select * from NhanVien

INSERT INTO ThietBi VALUES ('1','TIVI');
INSERT INTO ThietBi VALUES ('2','Dien Thoai');
select * from ThietBi

INSERT INTO CanHo VALUES ('3','CanHoA');
INSERT INTO CanHo VALUES ('4','CanHoB');
INSERT INTO CanHo VALUES ('5','CanHoC');
INSERT INTO CanHo VALUES ('6','CanHoD');
select * from CanHo

INSERT INTO NV_BT VALUES ('1','1','1',1,'11/19/2021');
INSERT INTO NV_BT VALUES ('2','2','2',2,'11/19/2021');
INSERT INTO NV_BT VALUES ('3','1','3',3,'11/19/2021');
INSERT INTO NV_BT VALUES ('1','2','4',1,'11/19/2021');
INSERT INTO NV_BT VALUES ('2','2','5',2,'11/19/2021');
INSERT INTO NV_BT VALUES ('2','1','1',1,'11/19/2021');
INSERT INTO NV_BT VALUES ('1','2','2',2,'11/19/2021');
INSERT INTO NV_BT VALUES ('2','1','3',3,'11/19/2021');
INSERT INTO NV_BT VALUES ('3','2','4',1,'11/19/2021');
INSERT INTO NV_BT VALUES ('3','2','5',2,'11/19/2021');
select * from NV_BT

select NV.TenNV, NV.SoDT, count(BT.LanThu) as LanThu
from NV_BT as BT, NhanVien as NV
where BT.MaNV = NV.MaNV
group by NV.TenNV, NV.SoDT
having count(BT.LanThu) >= 3