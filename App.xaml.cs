using ex.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ex
{
    public partial class App : Application
    {
        public static User CurrentUser { get; set;}
    }

}
