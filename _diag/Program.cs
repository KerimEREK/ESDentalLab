using System;
using System.Windows.Forms;
using ESDentalLab;

namespace Diag;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, e) =>
        {
            Console.Error.WriteLine("=== ThreadException ===");
            Console.Error.WriteLine(e.Exception.ToString());
        };
        AppDomain.CurrentDomain.UnhandledException += (_, e) =>
        {
            Console.Error.WriteLine("=== UnhandledException ===");
            Console.Error.WriteLine(e.ExceptionObject?.ToString());
        };

        try
        {
            ApplicationConfiguration.Initialize();
            Console.WriteLine("STEP: init data");
            VeriDeposu.VarsayilanKasalarıHazirla();
            VeriDeposu.VarsayilanKullaniciyiHazirla();
            DemoVeri.Yukle();
            bool ok = VeriDeposu.GirisYap("admin", "admin");
            Console.WriteLine($"STEP: login ok={ok}");

            Console.WriteLine("STEP: new frmAnaMenu()");
            using var ana = new frmAnaMenu();
            Console.WriteLine("STEP: frmAnaMenu ctor OK");

            Console.WriteLine("STEP: new frmIsEkle()");
            var isEkle = new frmIsEkle();
            Console.WriteLine("STEP: frmIsEkle ctor OK");

            Console.WriteLine("STEP: ArayuzTema.GomuluModaAl(isEkle)");
            ArayuzTema.GomuluModaAl(isEkle);
            Console.WriteLine("STEP: GomuluModaAl OK");

            // Try CreateControl/Show pattern like SayfaAc
            Console.WriteLine("STEP: force CreateControl on isEkle");
            _ = isEkle.Handle;
            Console.WriteLine($"STEP: Controls count={isEkle.Controls.Count}");
            ArayuzTema.GomuluModaAl(isEkle);
            Console.WriteLine("STEP: GomuluModaAl after handle OK");

            // Reflect SayfaAc-like embed into a host
            Console.WriteLine("STEP: embed into panel like SayfaAc");
            using var host = new Form { Width = 1200, Height = 800 };
            var pnl = new Panel { Dock = DockStyle.Fill };
            host.Controls.Add(pnl);
            isEkle.TopLevel = false;
            isEkle.FormBorderStyle = FormBorderStyle.None;
            isEkle.Dock = DockStyle.Fill;
            pnl.Controls.Add(isEkle);
            isEkle.Show();
            ArayuzTema.GomuluModaAl(isEkle);
            Console.WriteLine("STEP: embedded GomuluModaAl OK");

            // Also try Load event path: show main form briefly
            Console.WriteLine("STEP: show frmAnaMenu briefly (Load/Activated)");
            ana.Shown += (_, _) =>
            {
                try
                {
                    Console.WriteLine("STEP: ana Shown - invoke IsEkle via reflection SayfaAc");
                    var m = typeof(frmAnaMenu).GetMethod("SayfaAc", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    if (m is null)
                    {
                        Console.WriteLine("SayfaAc method not found");
                        ana.Close();
                        return;
                    }
                    m.Invoke(ana, new object[] { new frmIsEkle() });
                    Console.WriteLine("STEP: SayfaAc(frmIsEkle) OK");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("=== SayfaAc failed ===");
                    Console.Error.WriteLine(ex.ToString());
                    if (ex.InnerException is not null)
                    {
                        Console.Error.WriteLine("=== Inner ===");
                        Console.Error.WriteLine(ex.InnerException.ToString());
                    }
                }
                finally
                {
                    ana.Close();
                }
            };
            Application.Run(ana);
            Console.WriteLine("DONE without crash on shown path");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("=== CATCH ===");
            Console.Error.WriteLine(ex.ToString());
            Environment.ExitCode = 1;
        }
    }
}
