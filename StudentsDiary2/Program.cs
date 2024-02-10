using System;
using System.IO;
using System.Windows.Forms;

namespace StudentsDiary
{
    internal static class Program
    {
        public static string FilePathOfStudents = Path.Combine(Environment.CurrentDirectory, "students.txt");

        public static string FilePathOfGroups = Path.Combine(Environment.CurrentDirectory, "groups.txt");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
