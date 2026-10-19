using Microsoft.EntityFrameworkCore;
using Notes.DAL.Data;
using Notes.DAL.Featrue.User.Command.createuser;

var builder = WebApplication.CreateBuilder(args);

// 1. إضافة خدمة الـ Controllers الخاصة بالـ API
builder.Services.AddControllers();

// 2. قراءة نص الاتصال والتأكد منه
var connectionString = builder.Configuration.GetConnectionString("contsr");
if (string.IsNullOrWhiteSpace(connectionString))
    throw new InvalidOperationException("Connection string 'contsr' not found.");

// 3. تسجيل الـ DbContext مرة واحدة فقط وبطريقة صحيحة مع الـ Logging
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    if (builder.Environment.IsDevelopment())
    {
        options.LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging();
    }
});

// 4. تسجيل الـ Repositories الخاصة بك
builder.Services.AddScoped<CreateUserHandler>();
builder.Services.AddScoped<CreateUserValidator>();

// 5. إضافة خدمات الأمان والتفويض (لتفادي أي مشاكل في الـ Authorization)
builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ترتيب الـ Middlewares مهم جداً (Authentication أولاً ثم Authorization)
app.UseAuthentication();
app.UseAuthorization();

// ربط الـ Controllers بالـ Endpoints
app.MapControllers();

app.Run();