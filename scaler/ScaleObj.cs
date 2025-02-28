using SkiaSharp;
using SourceObj;
using ResultObj;

namespace ScaleObj;

public interface IScaleFunc
{
    public SKBitmap? Scale(SKBitmap bmp);
}

public class ScaleFuncCopy : IScaleFunc
{
    public SKBitmap? Scale(SKBitmap bmp)
    {
        SKBitmap resbmp = new SKBitmap();
        bmp.CopyTo(resbmp);
        return resbmp;
    }
}

public class ScaleBase
{
    private readonly SourceBase _sb;
    private readonly ResultBase _rb;
    private readonly IScaleFunc _sf;
    public ScaleBase(SourceBase sb, ResultBase rb, IScaleFunc sf)
    {
        Console.WriteLine(this.GetType().Name + " Create");

        ArgumentNullException.ThrowIfNull(sb, "Unassigned Sourcebase");
        ArgumentNullException.ThrowIfNull(rb, "Unassigned ResultBase");
        ArgumentNullException.ThrowIfNull(sf, "Unassigned ResultBase");

        this._sb = sb;
        this._rb = rb;
        this._sf = sf;
    }

    public int Scale()
    {
        using SKBitmap? bmp = _sb.Pass();
        if (null == bmp)
            return 0;

        using SKBitmap? bmp2 = _sf.Scale(bmp);
        if (null == bmp2)
            return 0;

        return _rb.Save(bmp2);
    }

}