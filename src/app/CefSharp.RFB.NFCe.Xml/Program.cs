using CefSharp;
using CefSharp.WinForms;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CefSharp.RFB.NFCe.Xml
{
    static class Program
    {
        #region Enums

        public enum ExitCodes
        {
            Sucess = 0,
            Error = 1,
        }

        #endregion Enums

        #region Variáveis

        private static DirectoryInfo diretorio = null;

        #endregion Variáveis

        #region Propriedades

        public static string Ambiente { get; private set; }
        public static string pastaTemporaria { get; private set; }

        #endregion Propriedades

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            #region Testa se só existe um processo do sistema

            bool createdNew;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, "CefSharp.RFB.NFCe.Xml", out createdNew);
            if (!createdNew)
                return;

            #endregion Testa se só existe um processo do sistema

            //Parametros
            try
            {
                if (args == null && args.Length > 2)
                    throw new Exception("Quantidade incorreta de parâmetros informados");

                if (string.IsNullOrWhiteSpace(args[0]))
                    throw new ArgumentNullException("ambiente");

                if (string.IsNullOrWhiteSpace(args[1]))
                    throw new ArgumentNullException("caminho da pasta temporaria");

                //Propriedades
                Ambiente = args[0];
                pastaTemporaria = args[1];
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Erro ao ler as informações do documento fiscal: " + ex.Message);

                //Fechar aplicação
                Environment.Exit((int) Program.ExitCodes.Error);
            }

            //Check CefSharp directory
            diretorio = new DirectoryInfo(@"C:\Program Files (x86)\Infofisco\CefSharp");
            if (!diretorio.Exists)
                diretorio = new DirectoryInfo(@"C:\Program Files\Infofisco\CefSharp");

            if (!diretorio.Exists)
                throw new Exception("Não encontrada a pasta de instalação do CefSharp");

            // Handle the ApplicationExit event to know when the application is exiting.
            Application.ApplicationExit += OnApplicationExit;

            // Handle Assembly Resolve
            AppDomain.CurrentDomain.AssemblyResolve += Resolver;

            //Load form
            LoadApp();

            //Fechou aplicação sem consultar com sucesso
            Environment.Exit((int) ExitCodes.Error);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void LoadApp()
        {
            var settings = new CefSettings();

            settings.MultiThreadedMessageLoop = true;
            settings.ExternalMessagePump = false;

            //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
            settings.CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache");

            // Set BrowserSubProcessPath based on app bitness at runtime
            settings.BrowserSubprocessPath = Path.Combine(diretorio.FullName, Environment.Is64BitProcess ? "x64" : "x86", "CefSharp.BrowserSubprocess.exe");

            IBrowserProcessHandler browserProcessHandler = new BrowserProcessHandler();
            // Make sure you set performDependencyCheck false
            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: browserProcessHandler);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        // Will attempt to load missing assembly from either x86 or x64 subdir
        private static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("CefSharp"))
            {
                string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                string archSpecificPath = Path.Combine(diretorio.FullName, Environment.Is64BitProcess ? "x64" : "x86", assemblyName);

                return File.Exists(archSpecificPath) ? Assembly.LoadFile(archSpecificPath) : null;
            }

            return null;
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            try
            {
                // Ignore any errors that might occur while closing the browser
                Cef.Shutdown();
            }
            catch { }
        }
    }
}
