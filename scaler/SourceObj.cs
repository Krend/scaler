using SkiaSharp;

namespace SourceObj;

public abstract class SourceBase
{

    public SourceBase()
    {
        Console.WriteLine(this.GetType().Name + " Create");
    }

    public virtual void Dispose()
    {
        Console.WriteLine(this.GetType().Name + " Destroy");
    }

    public abstract SKBitmap Pass();

}

public class SourceTest : SourceBase
{
    public SourceTest() : base()
    {

    }

    public override void Dispose()
    {

        base.Dispose();
    }

    public override SKBitmap Pass()
    {
        SKBitmap bmp = new SKBitmap(20, 20, false);


        return bmp;
    }
}