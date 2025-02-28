using SkiaSharp;
using CommonUtility;

namespace ResultObj;

public abstract class ResultBase
{
    public ResultBase()
    {
        Console.WriteLine(this.GetType().Name + " Create");
    }
    public abstract int Save(SKBitmap bmp);
}


public class ResultTest : ResultBase
{
    public ResultTest() : base()
    {

    }

    public override int Save(SKBitmap bmp)
    {
        return  CU.SaveToFile("ResultTest.png", bmp, SKEncodedImageFormat.Png);
    }

}
