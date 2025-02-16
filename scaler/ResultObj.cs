using SkiaSharp;

namespace ResultObj;

abstract class ResultBase
{
    public ResultBase()
    {
        Console.WriteLine(this.GetType().Name + " Create");
    }

    public virtual void Dispose()
    {
        Console.WriteLine(this.GetType().Name + " Destroy");
    }

    public abstract void Save(SKBitmap bmp);
}


class ResultTest : ResultBase
{
    public ResultTest() : base()
    {

    }

    public override void Dispose()
    {

        base.Dispose();
    }

    public override void Save(SKBitmap bmp)
    {
        FileStream fs = new FileStream("ResultTest.bmp", FileMode.Create, FileAccess.ReadWrite);
        //StreamWriter sw = new StreamWriter(fs);
        //SKWStream sw = new()        
        bmp.Encode(fs, SKEncodedImageFormat.Bmp, 0);

    }

}
