using SkiaSharp;

namespace CommonUtility;

static class CU
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
        bool valid;
        try
        {
            using FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            using SKManagedWStream wstream = new SKManagedWStream(fs);
            valid = bmp.Encode(wstream, imf, 100);
        }
        catch (Exception e)
        {
            Console.WriteLine("File access error; Operation: Create/Write; Exception: " + e.Message);
            return -1;
        }

        if (valid)
        {
            Console.WriteLine("Success " + imf.ToString());
        }
        else
        {
            Console.WriteLine("Fail " + imf.ToString());
            try
            {
                File.Delete(filename);
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("File access error; Operation: Delete; Exception: " + e.Message);
                return -2;
            }
        }

        return 1;
    }
}
