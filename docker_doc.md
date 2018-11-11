# Docker
```
docker images  -- หาชื่อ images ในเครื่อง 
```

การ pull images 
```
docker pull microsoft/mssql-server-linux
```

การ run images ให้เป็น contrainer
```
```

การเช็ค process service ของ contrainer
```
docker ps -a  สำหรับเช็ค Service  ทั้งหมด
```

การ Start Contrainner 
```
docker start sql1 สำหรับ Start Service ชื่อ Sql1
docker start  ตามด้วยชื่อ Service  เช่น  docker start sql1
```

## การ Build docker

``` 
docker build -t ชื่อ images . คือเลือกไฟล์ทั้งหมด 
docker build -t mypos . 
```

หากต้องการ สร้าง images โดยใส่ Version
```
docker build -t:1.0 mypos . 
```

## การเข้าไปใช้ คำสั่งใน Contrainner ต้องใช้เป็นคำสั่ง Linux
```
docker exec -it [ชื่อ Contrainner ที่กำลัง Run] bash
docker exec -it mypos_v4 bash
```

### การ Run Docker  
```
docker run -d -p [portClient:portDocker] --name [ชื่อที่ใช้ Run] [รหัส images]
docker run -d -p 1112:80 --name mypos_v2  bf5aae61f2dc 
sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Meng1234!'  -p 1433:1433 --name sql1 -d 4095d6d460cd
```

## การ Remove Images
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

## การสร้างไฟล์ Images
```
1. ให้สร้างไฟล์ ชื่อ Dockerfile 

```
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
#EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["MyPOS.csproj", "./"]
RUN dotnet restore "./MyPOS.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MyPOS.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MyPOS.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MyPOS.dll"]
```

2. ใช้คำสั่ง docer save จะต้องมีไฟล์ ชื่อ Dockerfile อยู่ก่อน ถึงจะทำการ Save ไฟล์ได้
docker save -o ./mypos.tar mypos 
```

## การโหลด images ไฟล์ เข้า contrainner
```
docker load -i ./mypos.tar
```