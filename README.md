# NetCore_MyPOS
# เขียนโดยใช้ vs code

# command + Shipt + O  สำหรับ หาชื่อ Function

#Code First
#สนใจ ไฟล์ DabaseContext กับ DBinitialize 


#services.AddTransient<ProductService>(); new ทุกครั้งที่ รีเฟชร หน้า

*Docker
# docker pull microsoft/mssql-server-linux
# sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Meng1234!'  -p 1433:1433 --name sql1 -d 4095d6d460cd
# docker ps -a  สำหรับเช็ค Service  ทั้งหมด
# docker start sql1 สำหรับ Start Service ชื่อ Sql1
# docker start  ตามด้วยชื่อ Service  เช่น  docker start sql1


# partial view  ต้องเป็น .cshtml 

# @await Html.PartialAsync("_Userpartial")


* ลิงค์ที่เกี่ยวกับ CSS
https://jsfiddle.net/
https://codepen.io/
https://www.uplabs.com/

*Forgery Attacks 
# แก้โดย asp-action 

*การสร้างไฟล์ Log 
# ใช้ Packer ชื่อ <PackageReference Include="Serilog.Extensions.Logging.File" Version="2.0.0-dev-00024"/>
# แก้ไขไฟล์ Program.cs
# ตามนี้

            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, builder) =>
                {
                    builder.AddFile("Logs/mypos-{Date}.txt");
                })
            .UseStartup<Startup>();


*ViewCoponents  
# 1.สร้าง Folder ชื่อ ViewComponents
# 2. สร้างไฟล์ .cs  ชื่อ UserViewComponent.cs  
# 3. เรียกใช้งาน ใน View  โดยประกาศ ตามนี้  @await Component.InvokeAsync("User_database")


*อย่าลืมเรื่อง Using ไฟล์ที่  _ViewImports.cshtml
#ให้ Using ตามชื่อ Folder เลย