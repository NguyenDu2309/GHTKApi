
using ClientAuthentication;
using Ghtk.Authorization;

namespace GHTK.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IClientSourceAuthencitationHandler clientSourceAuthencitationHandler = new SqlServerClientSourceAuthencitationHandler(builder.Configuration.GetConnectionString("ClientAuthentication") ?? throw new Exception("ClientAuthentication database cannot be found"));
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddAuthentication("X-Client-Source").AddXClientSource(
                options =>
                {
                    options.ClientValidator = (clientSource, token, principal) => clientSourceAuthencitationHandler.Validate(clientSource);
                    options.IssuerSigningKey = builder.Configuration["IssuerSigningKey"] ?? "";
                }  
            );

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
