using ChatModule;
using Common;
using FacebookChat;
using GoogleChat;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<ChatClientProvider>();
builder.Services.AddTransient<MessageProcessor>();
builder.Services.AddTransient<MessageBus>();


builder.Services.AddHttpClient();

// configure clients
builder.Services.ConfigureFacebookClient();
builder.Services.ConfigureGoogleClient();
builder.Services.ConfigureWhatsAppClient();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseFacebookClient();


// app.MapPost("/google/webhook/receive/", async (GoogleMessage message,MessageProcessor messageProcessor) =>
// {
//     messageProcessor.Receive(ChatType.Google,message);
// });
// app.MapPost("/whatsapp/webhook/receive/", async (GoogleMessage message,MessageProcessor messageProcessor) =>
// {
//     messageProcessor.Receive(ChatType.WhatsApp,message);
// });




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();