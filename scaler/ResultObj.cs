using SkiaSharp;
using CommonUtility;

namespace ResultObj;

public abstract class ResultBase
{
    public ResultBase()
    {
        Console.WriteLine(this.GetType().Name + " Create");
    }

    public virtual void Dispose()
    {
        Console.WriteLine(this.GetType().Name + " Destroy");
    }

    public abstract int Save(SKBitmap bmp);
}


public class ResultTest : ResultBase
{
    public ResultTest() : base()
    {

    }

    public override void Dispose()
    {

        base.Dispose();
    }

    public override int Save(SKBitmap bmp)
    {
        return  CU.SaveToFile("ResultTest.png", bmp, SKEncodedImageFormat.Png);
    }

}
