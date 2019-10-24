using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class autoCreate
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tbkkdbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tbkkdbContext>>()))
            {
                // Look for any movies.

                var date1 = DateTime.Today;



                IList<OT> OT = context.OT.Where(s => s.TimeStart == date1).ToList();

                if (OT == null)
                {
                    context.OT.AddRange(
                new OT
                {
                    TimeStart = DateTime.Parse("08:00"),
                    TimeEnd = DateTime.Parse("15:00"),
                    TypeOT = "Nomal",
                    TypStatus = "Open"
                }
                );

                    /* ---------------------------------*/





                    context.SaveChanges();
                      // DB has been seeded
                }
                return;


                /*---------------------------------*/





            }
        }

    }
}
