using DrinkShop.GUI.Forms;

namespace DrinkShop.GUI;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FrmLogin());
    }
}
