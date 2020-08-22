Đây là 1 mẫu triển khai cho dự án web thương mại điện tử (e-commerce) cơ bản trong thực tế.

<b>AspnetVnBasicRealWorld</b> chỉ là một solution, nó chỉ là một ứng dụng Web Asp.Net Core & Entity Framework Core(EF.Core), mà ở đó đã sử dụng các thành phần trong aspnetcore như: <b>razor pages</b>, <b>middlewares</b>, <b>dependency injection</b>, <b>configuration</b>, <b>logging</b>, và một số sử dụng HTML5, CSS & JavaScript để xây dựng nên các trang web. Bạn có thể sử dụng một số boilerplate fast implementation, minimum development, bootstrap your idea, create Minimum Viable Product (MVP), idea validation, startup development trong quá trình học tập với việc sử dụng phiên bản mới nhất của Asp.Net Core và Entity Framework Core.

# Dự án AspnetVn để làm gì?
Lộ trình tốt nhất để phát triển kĩ năng <b>ASP.NET Core</b> của bản thân. Tìm kiếm cơ hội tới nhưng công việc <b>Full Stack .Net Core Developer</b> trong tương lai. Mẫu kiến trúc tốt trên Asp.Net Core với Entity Framework core, những thực hành tốt nhất để xây dựng kiến trúc cho một những dụng nhiều tầng layers với DDD principle. Triển khai một ứng dụng NLayer Hexagonal architecture (Core, Application, Infrastructure and Presentation Layers) và Domain Driven Design (Entities, Repositories, Domain/Application Services, DTO's...) nhằm mục đích tạo ra một kiến trúc sạch Clean Architecture, cùng với việc sử dụng các nguyên lý SOLID để sử dụng sau dự án mẫu này. Hơn nữa, sẽ triển khai với các best practices như kiến trúc loosely-coupled, dependency-inverted và sử dụng các pattern như là Dependency Injection, logging, validation, exception handling, localization và nhiều hơn nữa.

# AspnetVn Repositories

# Những thứ sẽ được nhắc tới trong Repository
Chúng ta sẽ triển khai tính năng run-aspnetcore-basic boilerplate template. Bạn có thể tự thay đổi cho phù hợp với những tính năng thực tế như một yêu cầu cho doanh nghiệp của bạn.

- Sử dụng Bootstrap4 theme
- Sử dụng tính năng Asp.net core built-in dependency injection
- Identity and identity configuration
- Sử dụng Authorization cho trang quản lý Products.
- Sử dụng Aspnet core razor tools - View Components, partial Views, Tag Helpers, Model Bindings and Validations, Razor Sections,...

# Cho tôi 1⭐ để có động lực!
Nếu bạn thích dự án hoặc nếu AspnetVN đã giúp bạn, vui lòng cho một dấu sao. Và cũng vui lòng fork kho lưu trữ này và gửi cho chúng tôi các pull-request. Nếu bạn tìm thấy bất kỳ vấn đề, vui lòng mở một issue. Cám ơn sự đóng góp của toàn bộ các bạn.

# Bắt đầu
Sử dụng các hướng dẫn sau để bắt đầu thực hành 

### Chuẩn bị môi trường, Editor, IDE
Bạn cần tối thiểu các công cụ sau:
- Visual Studio 2019
- .Net Core 3.0 or later
- EF Core 3.0 or later

### Cài đặt
Làm theo các bước sau để thiết lập môi trường phát triển của bạn:
1. Clone repo này về máy bạn
2. Trong thư mục Root tại dự án, bạn khôi phục các packages cần thiết bằng lệnh sau: `dotnet restore`.
3. Tiếp theo, Build dự án bằng lệnh: `dotnet build`.
4. Tiếp theo, tại thư mục AspnetVn.Web khởi chạy ứng dụng bằng cách chạy: `dotnet run`.
5. Mở trình duyệt và truy cập vào địa chỉ sau: [http://localhost:8000](http://localhost:5400).

Chú ý: Nếu làm theo các bước trên là bạn đang chạy ứng dụng bằng cửa sổ dòng lệnh hay còn gọi là CLI. Nếu bạn đang sử dụng Visual Studio 2019, bạn có thể chạy ứng dụng bằng phím F5 (nếu muốn chạy có debug) và Ctrl + F5 nếu muốn chạy mà không cần debug. 

### Sử dụng

Mặc định Entity Framework Core được cấu hình trên cơ sở dữ liệu <b>"InMemoryDatabase"</b>. Nếu bạn muốn cấu hình dự án trên một cơ sở dữ liệu thật như SQL server, bạn nên chạy Entity Framework Core migrations trước khi chạy ứng dụng và cập nhật phương thức ConfigureDatabases trong file Startup.cs như sau:

```cs
public void ConfigureDatabases(IServiceCollection services)
{
        //// use in-memory database
        //  services.AddDbContext<DatabaseContext>(c => c.UseInMemoryDatabase("DatabaseConnection"));

        // add real database dependecy
            services.AddDbContext<DatabaseContext>(c => c.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));  
}
```

