using SkiaSharp;

namespace SourceObj;

public abstract class SourceBase
{

    public SourceBase()
    {
        Console.WriteLine(this.GetType().Name + " Create");
    }

    public abstract SKBitmap? Pass();

}

public class SourceTest : SourceBase
{
    public SourceTest() : base()
    {

    }

    public override SKBitmap? Pass()
    {
        SKBitmap bmp = new SKBitmap(20, 20, false);

        using (SKCanvas canvas = new SKCanvas(bmp))
        {
            SKColor red = new SKColor(0xFF, 0x00, 0x00);
            canvas.Clear(red);
        }
        
        return bmp;
    }
}