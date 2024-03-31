
 create database QuanLyHSHS
 go
 use QuanLyHSHS
 go
 create table nienkhoa(
	stt INT IDENTITY,
	nienkhoaID nvarchar(100) primary key,
	tennk nvarchar(100),
	ngaybatdau date,
	ngayketthuc date
 )
 go
 create table Lop(
	stt INT IDENTITY,
	lopID nvarchar(100) primary key,
	tenLop nvarchar(100),
	nienkhoa nvarchar(100),
	constraint FK_nienkhoa2 foreign key(nienkhoa) references nienkhoa(nienkhoaID) 
 )
 go
 create table GiaoVien(
	stt INT IDENTITY,
	giaovienID nvarchar(100) primary key,
	tengv nvarchar(100),
 )
 go
create table link_lop_gv(
	stt INT IDENTITY,
	linkID nvarchar(100) primary key,
	malop nvarchar(100),
	magv nvarchar(100),
	constraint FK_Lop foreign key(malop) references Lop(lopID) ,
	constraint FK_Gv foreign key(magv) references GiaoVien(giaovienID) 
)
 go
 create table UuTien(
	stt INT IDENTITY,
	uutienID nvarchar(100) primary key,
	mota nvarchar(100),
 )
 go
 
 create table HocSinh(
	stt INT IDENTITY,
	hocsinhID nvarchar(100) primary key,
	tenHS nvarchar(100),
	gioitinh nvarchar(50),
	ngaysinh date,
	dantoc nvarchar(100),
	tinhtrangsuckhoe nvarchar(100),
	doituongchinhsach nvarchar(100),
	ngayvaotruong date,
	diemtrungtuyen1 float,
	diemtrungtuyen2 float,
	diemtrungtuyen3 float,
	diachi nvarchar(100),
	sdt nvarchar(100),
	email nvarchar(100),
	hotencha  nvarchar(100),
	ngaysinhcha date,
	sdtcha nvarchar(100),
	nghenghiepcha nvarchar(100),
	diachilienhecha nvarchar(100),
	hotenme nvarchar(100),
	ngaysinhme date ,
	sdtme nvarchar(100),
	nghenghiepme nvarchar(100),
	diachilienheme nvarchar(100),
	uutien nvarchar(100),
	malop nvarchar(100),
	constraint FK_HocSinh_Lop foreign key(malop) references Lop(lopID),
	constraint FK_HocSinh_UuTien foreign key(uutien) references UuTien(uutienID) 
 )
 go
 create table MonHoc(
	stt INT IDENTITY,
	monHocID nvarchar(100) primary key,
	tenmon nvarchar(100),
 )
 go

 create table DiemHocTap(
	stt INT IDENTITY,
	madiem nvarchar(100) primary key,
	malop nvarchar(100),
	diemHK1 float,
	diemHK2 float,
	DTB float,
	mahs nvarchar(100) ,
	mamon nvarchar(100) ,
	constraint FK_lop1 foreign key(malop) references Lop(lopID) ,
	constraint FK_HocSinh foreign key(mahs) references HocSinh(hocsinhID)  on delete cascade on update cascade ,
	constraint FK_Mon foreign key(mamon) references MonHoc(monhocID) ,
	constraint unique_mon_lop_hs unique (malop,mahs,mamon)
 )

  go
create table DiemTotNghiep(
	stt INT IDENTITY,
	madiemtotnghiep nvarchar(100) primary key ,
	mahs nvarchar(100) ,
	malop nvarchar(100),
	diemmon1 float,
	diemmon2 float,
	diemmon3 float,
	tinhtrang nvarchar (100),
	constraint FK_hocsinh1 foreign key(mahs) references HocSinh(hocsinhID)  on delete cascade on update cascade ,
	constraint FK_lop2 foreign key(malop) references Lop(lopID),
	constraint unique_mahs_malop unique(mahs)
 )
 
 go
 create table Taikhoan(
	stt INT IDENTITY,
	taikhoan nvarchar(100) primary key,
	matkhau nvarchar(100),
	magiaovien nvarchar(100),
	constraint FK_giaovien foreign key(magiaovien) references giaovien(giaovienID),
	constraint unique_gv unique (magiaovien)
 )
 go
 create trigger autoDTB
 on DiemHocTap 
 for insert, update
 as
 begin
	 update DiemHocTap
	 set DTB=(inserted.diemHK1+inserted.diemHK2)/2
	 from DiemHocTap, inserted
	 where DiemHocTap.madiem=inserted.madiem
 end


 --tao trigger tu dong insert tinh trang tot nghiep
 go
create TRIGGER tudongxettotnghiep
ON DiemTotNghiep
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        UPDATE DiemTotNghiep
        SET tinhtrang = 
            CASE
                WHEN (diemmon1 > 1 AND diemmon2 > 1 AND diemmon3 > 1) AND ((diemmon1 + diemmon2 + diemmon3) / 3 > 4) THEN 'tot nghiep'
                WHEN (diemmon1 <= 1 OR diemmon2 <= 1 OR diemmon3 <= 1) OR ((diemmon1 + diemmon2 + diemmon3) / 3 <= 4) THEN ''
                ELSE tinhtrang
            END
        WHERE mahs IN (SELECT mahs FROM inserted);
    END
END;
go
 insert into GiaoVien
 values
 ('gv1','nguyen van a'),
 ('gv2','nguyen van b'),
 ('gv3','nguyen van c'),
 ('gv4','nguyen van d'),
 ('gv5','nguyen van e'),
 ('gv6','nguyen van r')
 GO
 insert into UuTien
 values
  ('ut0','khong uu tien'),
  ('ut1','diem cao'),
   ('ut3','dat giai hoc sinh gioi'),
  ('ut2','thuoc dien uu tien')

  GO
insert into nienkhoa
values
('1','nam hoc 2018-2019','2018-09-01','2019-06-30'),
('2','nam hoc 2019-2020','2019-09-01','2020-06-30'),
('3','nam hoc 2020-2021','2020-09-01','2021-06-30'),
('4','nam hoc 2022-2023','2022-09-01','2023-06-30')
go
insert into Lop
values
('lop1','10A','1'),
('lop2','10A','1'),
('lop3','10b','2'),
('lop4','10c','1'),
('lop5','10d','3'),
('lop6','10e','1'),
('lop7','11A','4'),
('lop8','12A','1'),
('lop10','10A','2'),
('lop11','10A','2'),
('lop12','10A','3'),
('lop13','10A','3'),
('lop14','10A','4'),
('lop15','10A','1')

GO
insert into HocSinh
values
('HS1','nguyen van a','nam','03/03/2003','kinh','binh thuong','khong','12/15/2022',6.8,7.7,9.5,'thanh ha - hai duong','734030704389'
,'dkshdksdh@gmail.com','nguyen van a1','08/15/1973','938409384034','nong dan','thanh ha - hai duong','nguyen thi a1','3/5/1978','37468343434','nong dan','thanh ha - hai duong','ut0','lop1'),
('HS2','nguyen van b','nam','05/10/2003','kinh','binh thuong','khong','11/18/2022',6.8,7.7,9.5,'thanh ha - hai duong','734030704389'
,'dkshdksdh@gmail.com','nguyen van b1','6/25/1965','938409384034','nong dan','thanh ha - hai duong','nguyen thi b1','3/5/1978','37468343434','nong dan','thanh ha - hai duong','ut1','lop2'),
('HS3','nguyen van c','nam','01/03/2003','kinh','binh thuong','khong','10/12/2022',6.8,7.7,9.5,'thanh ha - hai duong','734030704389'
,'dkshdksdh@gmail.com','nguyen van a1','6/19/1973','938409384034','nong dan','thanh ha - hai duong','nguyen thi a1','3/5/1978','37468343434','nong dan','thanh ha - hai duong','ut2','lop3'),
('HS4','nguyen van d','nam','10/03/2003','kinh','binh thuong','khong','12/23/2022',6.8,7.7,9.5,'thanh ha - hai duong','734030704389'
,'dkshdksdh@gmail.com','nguyen van a1','6/15/1980','938409384034','nong dan','thanh ha - hai duong','nguyen thi a1','3/5/1978','37468343434','nong dan','thanh ha - hai duong','ut0','lop2'),
('HS5','nguyen van e','nam','11/13/2003','kinh','binh thuong','khong','12/25/2022',6.8,7.7,9.5,'thanh ha - hai duong','734030704389'
,'dkshdfdksdh@gmail.com','nguyen van a1','09/20/1950','938409384034','nong dan','thanh ha - hai duong','nguyen thi a1','3/5/1978','37468343434','nong dan','thanh ha - hai duong','ut0','lop3'),
('HS6','nguyen van f','nam','01/23/2003','kinh','binh thuong','khong','10/13/2022',6.8,7.7,9.5,'thanh ha - hai duong','734030704389'
,'dkshdksdh@gmail.com','nguyen van a1','02/11/1923','938409384034','nong dan','thanh ha - hai duong','nguyen thi a1','3/5/1978','37468343434','nong dan','thanh ha - hai duong','ut3','lop1'),
('HS7','nguyen van g','nam','01/12/2003','kinh','binh thuong','khong','11/13/2022',6.8,7.7,9.5,'thanh ha - hai duong','734030704389'
,'dkshdksdh@gmail.com','nguyen van a1','01/14/1983','938409384034','nong dan','thanh ha - hai duong','nguyen thi a1','3/5/1978','37468343434','nong dan','thanh ha - hai duong','ut0','lop1'),
('HS8','nguyen van h','nam','02/03/2003','kinh','binh thuong','khong','10/13/2022',6.8,7.7,9.5,'thanh ha - hai duong','734030704389'
,'dkshdksdh@gmail.com','nguyen van a1','5/18/1975','938409384034','nong dan','thanh ha - hai duong','nguyen thi a1','3/5/1978','37468343434','nong dan','thanh ha - hai duong','ut0','lop1'),
('HS9','nguyen van i','nam','03/03/2003','kinh','binh thuong','khong','4/13/2022',6.8,7.7,9.5,'thanh ha - hai duong','734030704389'
,'dkshdksdh@gmail.com','nguyen van a1','6/15/1973','938409384034','nong dan','thanh ha - hai duong','nguyen thi a1','3/5/1978','37468343434','nong dan','thanh ha - hai duong','ut0','lop1')
delete HocSinh
go
insert into MonHoc
values
('mon1','toan'),
('mon2','van'),
('mon3','anh'),
('mon4','ly'),
('mon5','hoa'),
('mon6','sinh'),
('mon7','the duc'),
('mon8','quoc phong'),
('mon9','lich su'),
('mon10','dia ly')
go

insert into DiemHocTap(madiem,malop,diemHK1,diemHK2,mahs,mamon)
values
('diem1','lop1',4.5,3.2,'HS1','mon1'),
('diem2','lop5',4.5,3.2,'HS1','mon2'),
('diem3','lop3',4.5,9,'HS1','mon3'),
('diem4','lop4',6,3.2,'HS1','mon4'),
('diem5','lop5',4.5,3.2,'HS2','mon1'),
('diem6','lop6',4.5,3.2,'HS2','mon5'),
('diem7','lop6',4.5,7,'HS3','mon6'),
('diem8','lop7',4.5,3.2,'HS4','mon7'),
('diem9','lop1',3,3.2,'HS2','mon8'),
('diem10','lop8',5,3.2,'HS5','mon9'),
('diem11','lop4',4.5,3,'HS5','mon10'),
('diem12','lop4',4.5,2,'HS5','mon1'),
('diem13','lop5',5,3.2,'HS4','mon2'),
('diem14','lop4',4,3,'HS5','mon3'),
('diem15','lop1',4,2,'HS3','mon4'),
('diem16','lop3',4.5,3.2,'HS4','mon1'),
('diem17','lop4',4.5,3.2,'HS5','mon2'),
('diem18','lop1',4.5,3.2,'HS2','mon3'),
('diem19','lop5',4.5,3.2,'HS1','mon4')

go

insert into DiemTotNghiep(madiemtotnghiep,mahs,malop,diemmon1,diemmon2,diemmon3)
values
('diem1','HS1','lop1', 9, 8,6.7),
('diem2','HS2','lop5', 8,8,6.7),
('diem3','HS3','lop3', 1, 1,1),
('diem4','HS4','lop4', 9, 4,6.7),
('diem5','HS5','lop5',2,3,2),
('diem6','HS6','lop6', 9, 9,6.7)

go
create proc check_login
@user nvarchar(100),
@pass nvarchar(100)
as
begin
select *from Taikhoan where taikhoan=@user and matkhau=@pass
end
go
exec check_login @user='cuong1' , @pass='123'
go
select *from DiemTotNghiep
update DiemTotNghiep
set 
diemmon1=1
where mahs='hs7'

go
drop table DiemTotNghiep
delete from DiemTotNghiep


--them hs


insert into HocSinh(hocsinhID,tenHS,gioitinh,ngaysinh,dantoc,tinhtrangsuckhoe,doituongchinhsach,ngayvaotruong,diemtrungtuyen1,diemtrungtuyen2,diemtrungtuyen3,diachi)
values
('HS10','nguyen van a','nam','01/03/2003','kinh','binh thuong','khong','12/13/2022',6.8,7.7,9.5,'thanh ha - hai duong')

go
update  HocSinh
set 
hotencha=@hotencha,ngaysinhcha=@ngaysinhcha,sdtcha=@sdtcha,nghenghiepcha=@nghenghiepcha,diachilienhecha=@diachilienhecha,hotenme=@hotenme,ngaysinhme=@ngaysinhme,sdtme=@sdtme,nghenghiepme=@nghenghiepme,diachilienheme=@diachilienheme
where 
hocsinhID=@mahs
go
update  HocSinh
set 
diachi=@diachi, sdt=@sdt
where 
hocsinhID=@mahs
go

--xoa hs
delete from HocSinh
where hocsinhID=@mahs
go

--sua hs
update HocSinh
set 
tenHS=@tenHS, gioitinh=@gioitinh,dantoc=@dantoc,tinhtrangsuckhoe=@tinhtrangsuckhoe,doituongchinhsach=@doituongchinhsach,ngayvaotruong=@ngayvaotruong,diemtrungtuyen1=@diemtrungtuyen1,diemtrungtuyen2=@diemtrungtuyen2,diemtrungtuyen3=@diemtrungtuyen3,diachi=@diachi,uutien=@uutien,malop=@malop
where hocsinhID=@mahs

--them diem
insert into DiemHocTap(diemhesomot,diemhesohai,diemhesoba,mahs,mamon) values (@diemhesomot,@diemhesohai,@diemhesoba,@mahs,@mamon)

select *from DiemHocTap

--sua diem
update DiemHocTap set diemhesomot= @diemhesomot,diemhesohai= @diemhesohai,diemhesoba =@diemhesoba,mamon= @mamon where mahs=@mahs
--xoa diem
delete from DiemHocTap where madiem=@madiem
--doi mat khau
update Taikhoan set matkhau=@matkhau where taikhoan=@taikhoan

--ti kiem ho so
select *from HocSinh where hocsinhID ='hs1'
--check quyen

select maquyen from Taikhoan ,phanquyen where taikhoan='cuong1' and Taikhoan.maquyen=phanquyen


--- insert diem tot nghiep
insert into DiemTotNghiep(diemhmon1, diemmon2, diemmon3,mahs) values (@diemhmon1,@diemmon2,@diemmon3,@mahs)

--update diem tn
update DiemTotNghiep set diemhmon1=@diemmon1, diemmon2=@diemmon2, diemmon3=@diemmon3 where mahs=@mahs

--xoa diem tn
delete from DiemTotNghiep where mahs=@mahs

select * from DiemHocTap
select * from Taikhoan 
--report diem theo lop
select *from DiemHocTap where malop='lop1'
--report diem theo nien khoa
select madiem, DiemHocTap.malop,diemHK1,diemHK2,DTB,mahs,mamon from DiemHocTap,Lop where nienkhoa='1' and DiemHocTap.malop=Lop.lopID
--report diem theo nien khoa-lop
select madiem, DiemHocTap.malop,diemHK1,diemHK2,DTB,mahs,mamon from DiemHocTap,Lop where nienkhoa='1' and DiemHocTap.malop='lop1' and DiemHocTap.malop=Lop.lopID

--report diem  TN theo lop
select *from DiemTotNghiep where malop='lop1'
--report diem TN theo nien khoa
select mahs, DiemTotNghiep.malop,diemmon1, diemmon2, diemmon3, tinhtrang from DiemTotNghiep,Lop where nienkhoa='1' and DiemTotNghiep.malop=Lop.lopID
--report diem TN theo nien khoa-lop
select mahs, DiemTotNghiep.malop,diemmon1, diemmon2, diemmon3, tinhtrang from DiemTotNghiep,Lop where nienkhoa='1' and DiemTotNghiep.malop='lop1' and DiemTotNghiep.malop=Lop.lopID

--report ttcn theo lop
select hocsinhID,tenHS,gioitinh,ngaysinh,dantoc,tinhtrangsuckhoe,doituongchinhsach,ngayvaotruong,diemtrungtuyen1,diemtrungtuyen2,diemtrungtuyen3 from HocSinh where malop='lop1'
--report ttcn theo khoa
select hocsinhID,tenHS,gioitinh,ngaysinh,dantoc,tinhtrangsuckhoe,doituongchinhsach,ngayvaotruong,diemtrungtuyen1,diemtrungtuyen2,diemtrungtuyen3 from HocSinh,Lop where HocSinh.malop=Lop.lopID and nienkhoa='1'
--report ttcn theo lop-khoa
select hocsinhID,tenHS,gioitinh,ngaysinh,dantoc,tinhtrangsuckhoe,doituongchinhsach,ngayvaotruong,diemtrungtuyen1,diemtrungtuyen2,diemtrungtuyen3 from HocSinh,Lop where HocSinh.malop=Lop.lopID and nienkhoa='1' and Lop.lopID='lop1'
--report ttgd theo lop
select hocsinhID,tenHS, hotencha,ngaysinhcha,sdtcha,nghenghiepcha,diachilienhecha,hotenme,ngaysinhme,sdtme,nghenghiepme,diachilienheme from HocSinh where malop='lop1'
--report ttgd theo khoa
select hocsinhID,tenHS, hotencha,ngaysinhcha,sdtcha,nghenghiepcha,diachilienhecha,hotenme,ngaysinhme,sdtme,nghenghiepme,diachilienheme  from HocSinh,Lop where HocSinh.malop=Lop.lopID and nienkhoa='1'
--report ttgd theo lop-khoa
select hocsinhID,tenHS, hotencha,ngaysinhcha,sdtcha,nghenghiepcha,diachilienhecha,hotenme,ngaysinhme,sdtme,nghenghiepme,diachilienheme  from HocSinh,Lop where HocSinh.malop=Lop.lopID and nienkhoa='1' and Lop.lopID='lop1'
--report ttlh theo lop
select hocsinhID,tenHS,sdt,email,diachi from HocSinh where malop='lop1'
--report ttlh theo khoa
select  hocsinhID,tenHS,sdt,email,diachi  from HocSinh,Lop where HocSinh.malop=Lop.lopID and nienkhoa='1'
--report ttlh theo lop-khoa
select hocsinhID,tenHS,sdt,email,diachi  from HocSinh,Lop where HocSinh.malop=Lop.lopID and nienkhoa='1' and Lop.lopID='lop1'
--tim kiem hs theo ma
select *from HocSinh where hocsinhID='hs1' 
--tim kiem hs theo ten
select *from HocSinh where tenHS like '%b%'
--tim kiem hs theo ma-ten
select *from HocSinh where hocsinhID='hs1'  and   tenHS like '%b%'

--tim kiem diem hs theo ma
select  mahs,tenHS, madiem,DiemHocTap.malop,diemHK1, diemHK2,DTB,mamon from DiemHocTap,HocSinh where mahs='hs1' and DiemHocTap.mahs=HocSinh.hocsinhID
--tim kiem diem hs theo ten
select mahs,tenHS, madiem,DiemHocTap.malop,diemHK1, diemHK2,DTB,mamon from DiemHocTap ,HocSinh where tenHS like '%b%' and DiemHocTap.mahs=HocSinh.hocsinhID
--tim kiem diem hs theo ten-ma
select mahs,tenHS, madiem,DiemHocTap.malop,diemHK1, diemHK2,DTB,mamon from DiemHocTap ,HocSinh where tenHS like '%b%' and DiemHocTap.mahs=HocSinh.hocsinhID and  mahs='hs2' 

--tim kiem diem TN theo ma
select DiemTotNghiep.mahs, tenHS,DiemTotNghiep.malop,diemmon1,diemmon2, diemmon3,tinhtrang  from DiemTotNghiep,HocSinh where mahs='hs1' and DiemTotNghiep.mahs=HocSinh.hocsinhID
--tim kiem diem TN theo ten
select DiemTotNghiep.mahs, tenHS,DiemTotNghiep.malop,diemmon1,diemmon2, diemmon3,tinhtrang  from DiemTotNghiep,HocSinh where tenHS like '%b%' and DiemTotNghiep.mahs=HocSinh.hocsinhID
--tim kiem diem TN theo ma-ten
select DiemTotNghiep.mahs, tenHS,DiemTotNghiep.malop,diemmon1,diemmon2, diemmon3,tinhtrang  from DiemTotNghiep,HocSinh where mahs='hs2' and tenHS like '%b%'and DiemTotNghiep.mahs=HocSinh.hocsinhID

delete Taikhoan
select *from taikhoan 
select *from diemhoctap order by stt desc
select * from   HocSinh order by stt desc
delete Taikhoan
select * from diemtotnghiep order by  stt

select hocsinhID,tenHS,gioitinh,ngaysinh,dantoc,tinhtrangsuckhoe,ngayvaotruong, diachi, doituongchinhsach,uutien, malop from HocSinh 
 
 delete HocSinh