using ComputeSharp;
using ComputeSharp.WinUI;
using Microsoft.UI.Xaml;

namespace SwapChainRepro;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();
    }

    private void AnimatedComputeShaderPanel_Loaded(object sender, RoutedEventArgs e)
    {
        ShaderPanel.ShaderRunner = new ShaderRunner<HelloWorld>(static time => new((float)time.TotalSeconds));
    }

    public void StopRenderLoop()
    {
        ShaderPanel.ShaderRunner = null;
    }
}

[AutoConstructor]
[EmbeddedBytecode(DispatchAxis.XY)]
internal readonly partial struct HelloWorld : IPixelShader<float4>
{
    public readonly float time;

    /// <inheritdoc/>
    public float4 Execute()
    {
        float2 uv = ThreadIds.Normalized.XY;

        float3 col = 0.5f + 0.5f * Hlsl.Cos(time + new float3(uv, uv.X) + new float3(0, 2, 4));

        return new(col, 1f);
    }
}
