using System;
using System.Linq;

namespace ShadowPropertyInEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var db = new ShadowDbContext())
                {
                    //Add record
                    db.Shadows.Add(new Shadow()
                    {
                        Content = "Test",
                        CreatedDate = DateTime.Now
                    });

                    db.SaveChanges();
                    
                    var res = db.Shadows.FirstOrDefault();
                    
                    Console.WriteLine("Hello World!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
