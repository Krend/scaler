using SkiaSharp;
using SourceObj;
using ResultObj;

namespace ScaleObj;

abstract class ScaleBase
{
    protected SourceBase sb;
    protected ResultBase rb;
    public ScaleBase(SourceBase sb, ResultBase rb)
    {
        Console.WriteLine(this.GetType().Name + " Create");
        this.sb = sb;
        this.rb = rb;

    }

    public virtual void Dispose()
    {
        sb.Dispose();
        rb.Dispose();
        Console.WriteLine(this.GetType().Name + " Destroy");
    }

    public abstract SKBitmap ScaleFunc(SKBitmap bmp);

    public void Scale()
    {
        SKBitmap bmp = sb.Pass();

        try
        {
            SKBitmap bmp2 = ScaleFunc(bmp);
            try
            {
                rb.Save(bmp2);
            }
            finally
            {
                bmp2.Dispose();
            }

        }
        finally
        {
            bmp.Dispose();
        }
    }

}

class ScaleTest : ScaleBase
{
    public ScaleTest(SourceBase sb, ResultBase rb) : base(sb, rb)
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