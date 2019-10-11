using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using SmartPlantsMvc.Data;

namespace SmartPlantsMvc.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext (
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (!context.PlantTypes.Any())
                {

                    context.PlantTypes.AddRange(
                        new PlantType
                        {
                            Name = "Lechuga Escarola",
                            Description = "Lechuga que se utiliza para ensaladas de invierno"
                        },
                        new PlantType
                        {
                            Name = "Lechuga Radicchio",
                            Description = "Lechuga con alto poder antioxidante se utiliza para llevar una dieta sana y equilibrada."
                        },
                        new PlantType
                        {
                            Name = "Tomate Cherry",
                            Description = "Tomate cherry o tomate cereza, ha sido un elemento básico de las ensaladas de verano y otros platos."
                        },
                        new PlantType
                        {
                            Name = "Tomate Kumato",
                            Description = "Tomate carnoso y de una pulpa muy exquisita."
                        }
                        );

                    context.SaveChanges();
                }

                
                
            }
        }
    }
}
