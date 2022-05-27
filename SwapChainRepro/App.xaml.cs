using Microsoft.UI.Xaml;

namespace SwapChainRepro;

public sealed partial class App : Application
{
    public App()
    {
        this.InitializeComponent();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        m_window = new MainWindow();
        //m_window.Closed += (s, e) => ((MainWindow)s).StopRenderLoop();
        m_window.Activate();
    }

    private Window m_window;
}
