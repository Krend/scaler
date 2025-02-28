using SkiaSharp;
using SourceObj;
using ResultObj;

namespace ScaleObj;

public abstract class ScaleBase
{
    protected SourceBase sb;
    protected ResultBase rb;

    protected bool DestroyOwnObjects;
    public ScaleBase(SourceBase sb, ResultBase rb, bool DestroyOwnObjects = true)
    {
        Console.WriteLine(this.GetType().Name + " Create");

        ArgumentNullException.ThrowIfNull(sb, "Unassigned Sourcebase");
        ArgumentNullException.ThrowIfNull(rb, "Unassigned ResultBase");

        this.sb = sb;
        this.rb = rb;
        this.DestroyOwnObjects = DestroyOwnObjects;

    }

    public abstract SKBitmap? ScaleFunc(SKBitmap bmp);

    public int Scale()
    {
        using SKBitmap? bmp = sb.Pass();
        if (null == bmp)
            return 0;

        using SKBitmap? bmp2 = ScaleFunc(bmp);
        if (null == bmp2)
            return 0;

        return rb.Save(bmp2);        
    }

}

public class ScaleTest : ScaleBase
{
    public ScaleTest(SourceBase sb, ResultBase rb, bool DestroyOwnObjects = true) : base(sb, rb, DestroyOwnObjects)
    {

    }

    public override SKBitmap? ScaleFunc(SKBitmap bmp)
    {
        SKBitmap resbmp = new SKBitmap();
        bmp.CopyTo(resbmp);
        return resbmp;

    }

}