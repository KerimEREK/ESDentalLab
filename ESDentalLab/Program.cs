namespace ESDentalLab
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += (_, e) =>
                {
                    System.IO.File.WriteAllText(
                        System.IO.Path.Combine(AppContext.BaseDirectory, "diag_exception.txt"),
                        "ThreadException`n" + e.Exception.ToString());
                    Console.Error.WriteLine(e.Exception.ToString());
                    MessageBox.Show(e.Exception.ToString(), "DIAG ThreadException");
                };
                AppDomain.CurrentDomain.UnhandledException += (_, e) =>
                {
                    System.IO.File.WriteAllText(
                        System.IO.Path.Combine(AppContext.BaseDirectory, "diag_exception.txt"),
                        "Unhandled`n" + e.ExceptionObject);
                    Console.Error.WriteLine(e.ExceptionObject?.ToString());
                };

                VeriDeposu.VarsayilanKasalarıHazirla();
                VeriDeposu.VarsayilanKullaniciyiHazirla();
                DemoVeri.Yukle();

                var login = VeriDeposu.GirisYap("admin", "admin");
                System.IO.File.WriteAllText(
                    System.IO.Path.Combine(AppContext.BaseDirectory, "diag_steps.txt"),
                    "login=" + login.ToString() + Environment.NewLine);

                void Log(string s)
                {
                    System.IO.File.AppendAllText(
                        System.IO.Path.Combine(AppContext.BaseDirectory, "diag_steps.txt"),
                        s + Environment.NewLine);
                    Console.WriteLine(s);
                }

                Log("STEP: constructing frmAnaMenu");
                frmAnaMenu ana;
                try
                {
                    ana = new frmAnaMenu();
                    Log("STEP: frmAnaMenu ctor OK");
                }
                catch (Exception ex)
                {
                    Log("FAIL ctor: " + ex);
                    System.IO.File.WriteAllText(
                        System.IO.Path.Combine(AppContext.BaseDirectory, "diag_exception.txt"),
                        ex.ToString());
                    return;
                }

                ana.Shown += (_, _) =>
                {
                    try
                    {
                        Log("STEP: Shown - create frmIsEkle");
                        var isEkle = new frmIsEkle();
                        Log("STEP: frmIsEkle ctor OK");
                        Log("STEP: reflect SayfaAc");
                        var m = typeof(frmAnaMenu).GetMethod("SayfaAc",
                            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                        m!.Invoke(ana, new object[] { isEkle });
                        Log("STEP: SayfaAc OK");
                    }
                    catch (Exception ex)
                    {
                        var full = ex.ToString();
                        if (ex.InnerException != null) full += "`nINNER:`n" + ex.InnerException;
                        Log("FAIL Shown: " + full);
                        System.IO.File.WriteAllText(
                            System.IO.Path.Combine(AppContext.BaseDirectory, "diag_exception.txt"),
                            full);
                    }
                    finally
                    {
                        // close quickly after diagnosis
                        System.Windows.Forms.Timer t = new() { Interval = 500 };
                        t.Tick += (_, _) => { t.Stop(); ana.Close(); };
                        t.Start();
                    }
                };

                Log("STEP: Application.Run");
                Application.Run(ana);
                Log("STEP: Run finished");
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(
                    System.IO.Path.Combine(AppContext.BaseDirectory, "diag_exception.txt"),
                    ex.ToString());
                Console.Error.WriteLine(ex.ToString());
            }
        }
    }
}