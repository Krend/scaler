using SkiaSharp;

namespace Scale;

static class CommonUtility
{

    /// <summary>
    /// Tries to save the image to a file in the specified format
    /// return values:
    /// 0: encode failed
    /// 1: success
    /// negative values: on exceptions
    /// </summary>
    public static int SaveToFile(string filename, SKBitmap bmp, SKEncodedImageFormat imf)
    {
        using SKData data = bmp.Encode(imf, 100);
        if (null == data)
        {
            Console.WriteLine("Failed to Encode " + filename + " format " + imf.ToString());
            return 0;
        }

        try
        {
            using FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            data.SaveTo(fs);
            Console.WriteLine("Success " + filename + " format " + imf.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine("File access error; Filename: " + filename + " format " + imf.ToString() + " Operation: Create/Write; Exception: " + e.Message);
            return -1;
        }

        return 1;
    }
}
