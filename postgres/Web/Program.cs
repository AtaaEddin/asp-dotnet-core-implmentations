using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Postgres.Data;
using Postgres.Business.Entites.PacketAggregate;
using System.Linq;

namespace Postgres.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<PacketContext>();
                var packetSet = context.Packets;
                var featureSet = context.Features;

                if(!packetSet.Any()){                
                    // // seed some data
                    packetSet.AddRange(new List<Packet> {
                        new Packet {
                            Name="enterprise website",
                            ImgUrl="not set",
                        },
                        new Packet {
                            Name="e-commercial website",
                            ImgUrl="not set",
                        }
                    });
                }

                if(!featureSet.Any() && packetSet.Any()){
                    featureSet.AddRange(new List<Feature> {
                        new Feature {Description="a domain name",PacketId=1},
                        new Feature {Description="free hosting",PacketId=1},
                        new Feature {Description="cross platform web application",PacketId=1},
                        new Feature {Description="a domain name",PacketId=2},
                        new Feature {Description="free hosting",PacketId=2},
                        new Feature {Description="controlling panel",PacketId=2},
                        new Feature {Description="credit card payment",PacketId=2},
                    });
                }

                context.SaveChanges();
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
