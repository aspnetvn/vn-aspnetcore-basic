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

1. Đảm bảo chuỗi kết nối sql server cho db của bạn có trong file appsettings.json
2. Mở commandline để update database:
```
   dotnet restore
   dotnet ef database update -c DatabaseContext
```
Hoặc bạn có thể chạy từ command line Visual Studio Package Manager Console Open Package Manager Console, set default project to AspnetRun.Infrastructure và chạy command: `update-database`.

Command line trên sẽ tạo ra 1 csdl bao gồm 2 table:  Product và Category. Bạn có thể nhìn thấy code trong file `DatabaseContext.cs`.
Khi chạy ứng dụng lần đầu tiên, nó sẽ tạo ra cơ sở dữ liệu máy chủ sql AspnetVN với một vài dữ liệu mà bạn sẽ thấy các sản phẩm và danh mục.

Nếu muốn sửa đổi hoặc thêm nhiều entities khác tới dự án, bạn có thể add thêm bằng tính năng dotnet ef migation trong EF.Core: 
```
  add-migration YourCustomEntityChanges
  update-database
```

### Cấu trúc dự án
<b>vn-aspnetcore-basic</b> với một mục đích là triển khái  Default Web Application template of .Net với 1 solution là một project cho ý tưởng triên khai nhanh nhất tới xây dựng 1 ứng dụng web trên nền tảng ASP.NET Core & Entity Framework Core mới nhất.

Trong thư mục sẽ bao gồm các nhóm như sau:
```
+-- Data
|  +-- DatabaseContext
|   +-- DatabaseContextSeed
+-- Entities
|   +--  Product
|   +-- Category
+--  Migrations (Generated by scaffolding from ef.core)
+--  Pages (Default Razor Web Application Template trong Asp.Net Core)
+--  Repositories
|   +--  IProductRepository
|   +--  ProductRepository
+-- wwwroot
+-- Startup.cs
+-- Program.cs

```
#### 1, Data Folder
Bao gồm Entity Framework Core Context và các table. Khi tạo mới 1 Entity bạn sẽ thêm và cấu hình scheme của chúng trong DatabaseContext, Tầng Infrastructure sẽ depend-on  Microsoft.EntityFrameworkCore.SqlServer. Bạn cũng có thể thay đổi data access layer, với một lighter-weight ORM như Dapper.

### 2, Migrations
Thư mục chứa các file tự sinh ra từ tính năng EF add-migration classes.

### 3, Repository
EF Repository implementation. Class này chịu trách nghiệm tạo ra các truy vấn, liên kết, join, điều kiện, phân trang m,tìm kiếm,...

### 4, Entities Folder
Chứa các Entities để tạo ra các table với Entity Framework Core Code First. Một vài thuộc tính trong một entity có thể các tag validation
```cs
public class Product 
{
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Description { get; set; }

        public int UnitPrice { get; set; }        

        public int CategoryId { get; set; }
        public Category Category { get; set; }
}
```
### 5, Repository Folder
Triển khai các Core Interface trong dự án này với Entity Framework Core và các phần phụ thuộc khác.Hầu hết sự phụ thuộc của ứng dụng của bạn vào tài nguyên bên ngoài nên được triển khai trong các lớp được xác định trong dự án Infrastructure. Các Class này sẽ implement trong Core. Nếu bạn đang xây dựng 1 dự án lớn thì có thể bạn có thêm nhiều dự án Infrastructure project. 
Bạn sẽ có 1 file InterfaceRepository và 1 class implement các phương thức của interface này.

```cs
public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductListAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductByNameAsync(string name);
        Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId);
        Task<Product> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task<IEnumerable<Category>> GetCategories();
    }
    
public class ProductRepository : IProductRepository
    {
        protected readonly AspnetRunContext _dbContext;

        public ProductRepository(AspnetRunContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<Product>> GetProductListAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
....
```

### 6, Pages Folder

Sử dụng ASP.NET Core project template với based on Razor Pages templates. Các thành phần được sử dụng bao gồm:
- Asp.Net Core
- Entity Framework Core
- Razor Pages
- Scaffolding Razor
- Tag Helpers
- Bindings
- Model Validations
- Navigation - Page Routes
- User Interfaces
- Partial Views
- View Components
- Razor Sections
- Dynamic Layout
- Middlewares
- Logging
- Configuration
- Dependency Injection

### wwwroot Folder

Đây là thư mục các file static như hình ảnh, css, js, file thư viện javascript như jquery, boostrap, được sử dụng trong ứng dụng web.

### Startup.cs
Ứng dụng ASP.NET Core phải bao gồm 1 class Startup.cs Nó giống như file Global.asax trong ứng dụng .NET. Có thể hiểu là nó là file sẽ được thực thi đầu tiên khi ứng dụng được viết bằng ASP.NET Core khởi động.

### Program.cs
Đây là file có thể tạo một máy chủ lưu trữ cho ứng dụng web viết bằng ASP.NET Core.

## Công nghệ sử dụng
- .NET Core 3.1 hoặc mới nhất
- ASP.NET Core 3.1 hoặc mới nhất
- Entity Framework Core 3.0
- .NET Core Native DI
- Razor Pages
- AutoMapper

## Các đối tượng chính
- Asp.Net Core

- Entity Framework Core

- Razor Pages

- Repository Design Pattern

- Multiple Page Web Application (MPA)

- Monolitic Deployment Architecture

- SOLID and Clean Code

# Tham khảo từ repo
<b>[run-aspnetcore-basics](https://github.com/aspnetrun/run-aspnetcore-basics]</b>
