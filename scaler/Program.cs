using ResultObj;
using ScaleObj;
using SourceObj;
using SkiaSharp;
using CommonUtility;

ScaleTest st = new ScaleTest(new SourceTest(), new ResultTest());

Console.WriteLine();

//st.Scale();

st.Dispose();

SKBitmap bmp = new SKBitmap(20, 20, false);
SKColor red = new SKColor(0xFF, 0x00, 0x00);

using (SKCanvas canvas = new SKCanvas(bmp))
{
    canvas.Clear(red);
}

foreach (SKEncodedImageFormat imf in (SKEncodedImageFormat[])Enum.GetValues(typeof(SKEncodedImageFormat)))
{
    string filename = "dump/ResultTest." + imf.ToString();
    CU.SaveToFile(filename, bmp, imf);
}

bmp.Dispose();
