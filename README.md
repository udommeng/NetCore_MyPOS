# NetCore_MyPOS
## เขียนโดยใช้ vs code

#Code First
. สนใจ ไฟล์ DabaseContext กับ DBinitialize 

# Docker
1. docker pull microsoft/mssql-server-linux
2. sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Meng1234!'  -p 1433:1433 --name sql1 -d 4095d6d460cd
3. docker ps -a  สำหรับเช็ค Service  ทั้งหมด
4. docker start sql1 สำหรับ Start Service ชื่อ Sql1
5. docker start  ตามด้วยชื่อ Service  เช่น  docker start sql1


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



# ความรู้ทั่วไป 
1. command + Shipt + O  สำหรับ หาชื่อ Function
2. services.AddTransient<ProductService>(); new ทุกครั้งที่ รีเฟชร หน้า
3. การใช้ wrap html  กด  alt+w
4. การจัด format code ไฟล์ \.cs กด shift+option+f สำหรับ mac
5. การลบ ช่องว่าง ให้ f1 เลือก tralling space delete
6. error massage ใช้ span เท่านั้น
    ``` <span asp-validation-for="@Model.ProductValidViewModel.Detail" class="alert_error"></span> ```
7. 