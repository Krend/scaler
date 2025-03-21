using SkiaSharp;

namespace Scale;

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

public class ScaleFuncSkiaResize : IScaleFunc
{
    protected float scaleRatio;
    public ScaleFuncSkiaResize(float scaleRatio)
    {
        this.scaleRatio = scaleRatio;
    }

    protected SKSizeI CalcNewSize(SKSizeI size)
    {
        return new SKSizeI(
            (int)Math.Floor((size.Width * scaleRatio)),
            (int)Math.Floor((size.Height * scaleRatio))
        );
    }
    public SKBitmap? Scale(SKBitmap bmp)
    {
        SKSizeI newsize = CalcNewSize(bmp.Info.Size);
        SKSamplingOptions so = new SKSamplingOptions(SKFilterMode.Linear);
        return bmp.Resize(newsize, so);
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