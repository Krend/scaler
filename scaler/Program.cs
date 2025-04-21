using System.Globalization;
using Scale;
using SkiaSharp;
using MyBitmap;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

//ScaleTest st = new ScaleTest(new SourceTest(), new ResultTest());
//ScaleBase st = new ScaleBase(new SourceTest(), new ResultTest(), new ScaleFuncCopy());
ScaleBase st = new ScaleBase(new SourceTest(), new ResultTest(), new ScaleFuncSkiaResize(11.94f));

st.Scale();

unsafe
{
    int s1 = sizeof(BITMAPINFOHEADER);
    s1 = sizeof(BITMAPFILEHEADER);
    s1 = sizeof(BITMAPV5HEADER);
}



/*
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
*/