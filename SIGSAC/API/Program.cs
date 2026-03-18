//Resumencito de este código: 

//1. Program.cs arranca
//2. Configura DI
//3. Levanta servidor
//4. Usuario hace request
//5. Middleware
//6. Controller
//7. Flujo
//8. DA
//9. BD
//10. Respuesta

//Es el punto de entrada de la aplicación donde se configuran los servicios 
//mediante inyección de dependencias, se define el pipeline de ejecución 
//HTTP con middlewares y se inicia el servidor que atiende las solicitudes.

// Program.cs = inicio
// DI = AddScoped
// Middleware = pipeline
// Swagger = documentación
// MapControllers = activa API
// Run() = inicia


using Abstracciones.Interfaces.DA; // Interfaces de acceso a datos (DA)
using Abstracciones.Interfaces.Flujo; // Interfaces de la capa de lógica (Flujo)
using DA; // Implementaciones de DA
using DA.Repositorios; // Repositorio de conexión (Dapper)
using Flujo; // Implementaciones de la capa Flujo

// Crea el builder de la aplicación (punto de entrada del sistema)
var builder = WebApplication.CreateBuilder(args);

// ----------------------
// CONFIGURACIÓN DE SERVICIOS
// ----------------------

// Agrega soporte para controllers (API)
builder.Services.AddControllers();

// Permite explorar endpoints (necesario para Swagger)
builder.Services.AddEndpointsApiExplorer();

// Configura Swagger (documentación interactiva del API)
builder.Services.AddSwaggerGen();


// ----------------------
// INYECCIÓN DE DEPENDENCIAS (DI)
// ----------------------

// Registra la relación interfaz → implementación
//Se usa inyección de dependencias para desacoplar interfaces de sus implementaciones!!!!!!!!!!!!!!!

// Cuando alguien pida IPersonaFlujo → se le da PersonaFlujo
builder.Services.AddScoped<IPersonaFlujo, PersonaFlujo>();       // AddScoped: Crea una instancia por request

// Cuando alguien pida IPersonaDA → se le da PersonaDA
builder.Services.AddScoped<IPersonaDA, PersonaDA>();

// Otras entidades del sistema (Bautismo)
builder.Services.AddScoped<IBautismoFlujo, BautismoFlujo>();
builder.Services.AddScoped<IBautismoDA, BautismoDA>();

// Repositorio de conexión a BD
builder.Services.AddScoped<IRepositorioDapper, RepositorioDapper>();


// ----------------------
// CONSTRUCCIÓN DE LA APP
// ----------------------

// Construye la aplicación con todo lo configurado
var app = builder.Build();


// ----------------------
// PIPELINE (flujo de ejecución HTTP) MIDDLEWARES
// ----------------------

// Si está en modo desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Activa Swagger
    app.UseSwaggerUI(); // Interfaz gráfica de Swagger
}

// Redirige HTTP → HTTPS
app.UseHttpsRedirection();

// Middleware de autorización
app.UseAuthorization();

// Mapea los controllers (activa endpoints)
app.MapControllers();

// Inicia la aplicación (queda escuchando requests)
app.Run();

