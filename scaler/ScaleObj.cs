using SkiaSharp;
using SourceObj;
using ResultObj;

namespace ScaleObj;

public abstract class ScaleBase
{
    protected SourceBase sb;
    protected ResultBase rb;

    protected bool DestroyOwnObjects;
    public ScaleBase(SourceBase? sb, ResultBase? rb, bool DestroyOwnObjects = true)
    {
        Console.WriteLine(this.GetType().Name + " Create");

        ArgumentNullException.ThrowIfNull(sb, "Unassigned Sourcebase");
        ArgumentNullException.ThrowIfNull(rb, "Unassigned ResultBase");

        this.sb = sb;
        this.rb = rb;
        this.DestroyOwnObjects = DestroyOwnObjects;

    }

    public virtual void Dispose()
    {
        if (DestroyOwnObjects)
        {
            sb.Dispose();
            rb.Dispose();
        }
        Console.WriteLine(this.GetType().Name + " Destroy");
    }

    public abstract SKBitmap ScaleFunc(SKBitmap bmp);

    public void Scale()
    {
        using SKBitmap bmp = sb.Pass();
        using SKBitmap bmp2 = ScaleFunc(bmp);
        rb.Save(bmp2);
    }

}

public class ScaleTest : ScaleBase
{
    public ScaleTest(SourceBase? sb, ResultBase? rb, bool DestroyOwnObjects = true) : base(sb, rb, DestroyOwnObjects)
    {

    }

    public override void Dispose()
    {

        base.Dispose();
    }

    public override SKBitmap ScaleFunc(SKBitmap bmp)
    {
        //return new SKBitmap(bmp, new Size(bmp.Width * 2 , bmp.Height * 2));
        return new SKBitmap(bmp.Width * 2, bmp.Height * 2);
    }

}