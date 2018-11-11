# Docker
1. docker images  -- หาชื่อ images ในเครื่อง 
2. docker pull microsoft/mssql-server-linux
3. sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Meng1234!'  -p 1433:1433 --name sql1 -d 4095d6d460cd
4. docker ps -a  สำหรับเช็ค Service  ทั้งหมด
5. docker start sql1 สำหรับ Start Service ชื่อ Sql1
6. docker start  ตามด้วยชื่อ Service  เช่น  docker start sql1
7. docker hub
9. windows 10  home,Edu  ให้ลง Toolsbox เพราะ ไม่มี HT ตัว ToolsBox  Run ภายใต้ VM ware
9. google หา .net core deploy docker

10. การ Build docker

``` 
docker build -t ชื่อ images . คือเลือกไฟล์ทั้งหมด 
docker build -t mypos . 

```
หากต้องการ สร้าง images โดยใส่ Version
```
docker build -t:1.0 mypos . 
```

11. การเข้าไปใช้ คำสั่งใน Contrainner
```
docker exec -it [ชื่อ Contrainner ที่กำลัง Run] bash
docker exec -it mypos_v4 bash
```

12. การ Run Docker  
```
docker run -d -p [portClient:portDocker] --name [ชื่อที่ใช้ Run] [รหัส images]
docker run -d -p 1112:80 --name mypos_v2  bf5aae61f2dc 
```
13. การ Remove Images
```
docker stop  หยุด
docker start สตาร์
docker rm ลบ contrainner

docker rm ชื่อ Contranner  or   เลข id
docker rm mypos_v2
docker rm 1224 23333 12121

ลบ images
docker rmi ชื่อ image หรือ id

```

14. การสร้างไฟล์ Images
```
docker save -o ./mypos.tar mypos 
```
15
```
docker load -i ./mypos.tar
```