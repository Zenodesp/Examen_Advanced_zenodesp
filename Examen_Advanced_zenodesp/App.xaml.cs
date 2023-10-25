using Examen_Advanced_zenodesp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Examen_Advanced_zenodesp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static MainWindow mainWindow = null;
        internal static MyDbContext context = null;
        internal static Appointment appointment = null;
    }
}
