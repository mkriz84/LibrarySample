using Microsoft.Practices.Unity;
using System.Web.Http;
using Library.Controllers;

public static class UnityConfig
{
    public static void ConfigureUnity(HttpConfiguration config)
    {
        var container = new UnityContainer();
        
        container.RegisterType<IBooksList, BooksList>();
        container.RegisterType<IBooksSearch, BooksSearch>();
        container.RegisterType<IBooksMatchWord, BooksMatchWord>();
      
        config.DependencyResolver = new UnityResolver(container);
    }
}