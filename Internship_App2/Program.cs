var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
	// Oturum zaman aþýmý süresi (varsayýlan olarak 20 dakika)
	options.IdleTimeout = TimeSpan.FromMinutes(20);

	// Çerez ayarlarý
	options.Cookie.HttpOnly = true; // Sadece sunucu tarafýndan eriþilebilir
	options.Cookie.IsEssential = true; // Kullanýcý için gerekli

	// Eðer uygulama HTTPS üzerinden çalýþýyorsa, çerez güvenliðini etkinleþtir
	options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
