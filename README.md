# NetCore_MyPOS
## เขียนโดยใช้ vs code

#Code First
. สนใจ ไฟล์ DabaseContext กับ DBinitialize 

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

# partial view  
1. ต้องเป็น .cshtml 

``` @await Html.PartialAsync("_Userpartial") ```


# ลิงค์ที่เกี่ยวกับ CSS
1. [jsfiddle.net] (https://jsfiddle.net/)
2. [codepen] (https://codepen.io/)
3. [uplabs] (https://www.uplabs.com/)

# Forgery Attacks 
1. แก้โดย asp-action 

# การสร้างไฟล์ Log 
. ใช้ Packer ชื่อ <PackageReference Include="Serilog.Extensions.Logging.File" Version="2.0.0-dev-00024"/>
. แก้ไขไฟล์ Program.cs
. ตามนี้

```
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, builder) =>
                {
                    builder.AddFile("Logs/mypos-{Date}.txt");
                })
            .UseStartup<Startup>();
```

# ViewCoponents  
 1. สร้าง Folder ชื่อ ViewComponents
 2. สร้างไฟล์ .cs  ชื่อ UserViewComponent.cs  
 3. เรียกใช้งาน ใน View  โดยประกาศ ตามนี้  

```
 @await Component.InvokeAsync("User_database")
```

# อย่าลืมเรื่อง Using ไฟล์ที่  _ViewImports.cshtml
1. ให้ Using ตามชื่อ Folder เลย

# Attention for VS
1. Debugger for Chrome  สำหรับการ Debug ในหน้า cshtml สามารถ debug  JS ได้


# การ Deploy
1. dotnet publish -c Release -o ./deploy_app


# ความรู้ทั่วไป 
1. command + Shipt + O  สำหรับ หาชื่อ Function
2. services.AddTransient<ProductService>(); new ทุกครั้งที่ รีเฟชร หน้า
3. การใช้ wrap html  กด  alt+w
4. การจัด format code ไฟล์ \.cs กด shift+option+f สำหรับ mac
5. การลบ ช่องว่าง ให้ f1 เลือก tralling space delete
6. error massage ใช้ span เท่านั้น

    ``` <span asp-validation-for="@Model.ProductValidViewModel.Detail" class="alert_error"></span> ```

7. [วิธี Debug JavaScript & C# in Visual Studio Code] (https://www.youtube.com/watch?v=dKpIE0pq8VQ&feature=youtu.be&fbclid=IwAR3Qe7mWvFgYuRgAQmw8et4fY0XnAXw3wXF_PvA-kajVCzUqfUEOF2V3_ZY)


