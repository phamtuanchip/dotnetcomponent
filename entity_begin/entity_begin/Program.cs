using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_begin
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var context = new ChinookContext())
            {
                var artists = from a in context.Artists
                              where a.Name.StartsWith("A")
                              orderby a.Name
                              select a;

                foreach (var artist in artists)
                {
                    Console.WriteLine(artist.Name);
                }
            }



            using (var context = new ChinookContext())
            {
                context.Artists.Add(
                    new Artist
                    {
                        Name = "Anberlin",
                        Albums =
                        {
                new Album { Title = "Cities" },
                new Album { Title = "New Surrender" }
                        }
                    });
                context.SaveChanges();
            }


            using (var context = new ChinookContext())
            {
                var police = context.Artists.Single(a => a.Name == "The Police");
                police.Name = "Police, The";

                var avril = context.Artists.Single(a => a.Name == "Avril Lavigne");
                context.Artists.Remove(avril);

                context.SaveChanges();
            }



        }
    }
}
