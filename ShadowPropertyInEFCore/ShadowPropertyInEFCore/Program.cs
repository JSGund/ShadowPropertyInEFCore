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
                        Content = "Shadow Property",
                        CreatedDate = DateTime.Now
                    });

                    db.SaveChanges();
                    
                    var res = db.Shadows.FirstOrDefault();

                    if (res != null)
                    {
                        Console.WriteLine("Added record Id :- {0}", res.Id);
                        Console.WriteLine("Added record Content :- {0}", res.Content);
                        Console.WriteLine("Added record CreatedDate - {0}", res.CreatedDate);
                    }
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
