using ResultObj;
using ScaleObj;
using SourceObj;
using SkiaSharp;

ScaleTest st = new ScaleTest(new SourceTest(), new ResultTest());

Console.WriteLine();

//st.Scale();

st.Dispose();

SKBitmap bmp = new SKBitmap(20, 20, false);
SKColor red = new SKColor(0xFF, 0x00, 0x00);

for (int x = 0; x < bmp.Width -1; x++)
{
    for (int y = 0; y < bmp.Height -1; y++)
    {
        bmp.SetPixel(x, y, red);
    }
}

foreach (SKEncodedImageFormat imf in (SKEncodedImageFormat[]) Enum.GetValues(typeof(SKEncodedImageFormat)) )
{
    string filename = "dump/ResultTest." + imf.ToString();
    FileStream fs;
    try
    {
        fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
    }
    catch (Exception e)
    {
        Console.WriteLine("File access error; Operation: Create; Exception: "+e.Message);
        continue;
    }

    bool b;

    using (fs)
    {
        using (SKManagedWStream wstream  = new SKManagedWStream(fs))
        {

            b= bmp.Encode(wstream, imf, 100);
        }
    }
    
    if (b)
    {
        Console.WriteLine("Success " + imf.ToString());
    }
    else
    {
        Console.WriteLine("Fail " + imf.ToString());
        try
        {
            File.Delete(filename);
        }
        catch(Exception e)
        {
            Console.WriteLine("File access error; Operation: Delete; Exception: "+e.Message);
            continue;
        }
    }
 }

bmp.Dispose();
