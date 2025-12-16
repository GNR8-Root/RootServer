using Blazorise;
using Blazorise.Tailwind;
using Blazorise.Icons.FontAwesome;
using RootServer.Shared._Editor;
using RootServer.Shared.Airtable;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// App services
builder.Services.AddScoped<Pointer_Service>();
builder.Services.AddScoped<LogCatcher_Service>();
builder.Services.AddScoped<EditorView_Service>();
builder.Services.AddScoped<EditorVisibility_Service>();

// Blazorise + Tailwind
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddTailwindProviders()
    .AddFontAwesomeIcons();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

AirtableConfig.Initialize(builder.Configuration);

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
