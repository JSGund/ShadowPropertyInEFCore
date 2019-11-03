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
                    #region The old way to use and access

                    var olShadow = new Shadow();
                    olShadow.Content = "Old way to set";
                    olShadow.CreatedDate = DateTime.Now;

                    //Add record
                    db.Shadows.Add(olShadow);

                    db.SaveChanges();

                    //Get First Or Default record
                    var olFirstOrDefault = db.Shadows.FirstOrDefault();

                    if (olFirstOrDefault != null)
                    {
                        Console.WriteLine("Added record Id :- {0}", olFirstOrDefault.Id);
                        Console.WriteLine("Added record Content :- {0}", olFirstOrDefault.Content);
                        Console.WriteLine("Added record CreatedDate - {0}", olFirstOrDefault.CreatedDate);
                    }

                    #endregion The old way to use and access

                    Console.WriteLine();

                    #region The new way to use and access

                    var nwArticle = new Article();
                    nwArticle.Name = "Shadow Property";
                    nwArticle.Description = "New way to set";
                    db.Entry(nwArticle).Property("CreatedDate").CurrentValue = DateTime.Now;

                    //Add record
                    db.Articles.Add(nwArticle);

                    db.SaveChanges();

                    //Get First Or Default record
                    var nwFirstOrDefault = db.Articles.FirstOrDefault();

                    if (nwFirstOrDefault != null)
                    {
                        Console.WriteLine("Added record Id :- {0}", nwFirstOrDefault.Id);
                        Console.WriteLine("Added record Content :- {0}", nwFirstOrDefault.Name);
                        Console.WriteLine("Added record Description - {0}", nwFirstOrDefault.Description);
                        Console.WriteLine("Added record CreatedDate - {0}", db.Entry(nwFirstOrDefault).Property("CreatedDate").CurrentValue);
                    }

                    #endregion The new way to use and access
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
