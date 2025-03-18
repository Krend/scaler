using System.Runtime.InteropServices;
namespace MyBitmap;


/* header structure definitions based on microsoft's documentation
    

*/
[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct BITMAPFILEHEADER
{
    ushort bfType;
    uint bfSize;
    ushort bfReserved1;
    ushort bfReserved2;
    uint bfOffBits;
};

enum Compression : uint
{
    BI_RGB,
    BI_RLE8,
    BI_RLE4,
    BI_BITFIELDS,
    BI_JPEG,
    BI_PNG,
    BI_ALPHABITFIELDS,
    BI_CMYK,
    BI_CMYKRLE8,
    BI_CMYKRLE4
};

struct CIEXYZ
{
    uint ciexyzX;
    uint ciexyzY;
    uint ciexyzZ;
};

struct CIEXYZTRIPLE
{
    CIEXYZ ciexyzRed;
    CIEXYZ ciexyzGreen;
    CIEXYZ ciexyzBlue;
};

[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct BITMAPINFOHEADER
{
    uint biSize;
    int biWidrh;
    int biHeight;
    ushort biPlanes;
    ushort biBitCount;
    Compression biCompression;
    uint biSizeImage;
    int biXPelsPerMeter;
    int biYPelsPerMeter;
    uint biClrUsed;
    uint biClrImportant;
    bool b;
};

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BITMAPV4HEADER
{
    uint bV4Size;
    int bV4Width;
    int bV4Height;
    ushort bV4Planes;
    ushort bV4BitCount;
    uint bV4V4Compression;
    uint bV4SizeImage;
    int bV4XPelsPerMeter;
    int bV4YPelsPerMeter;
    uint bV4ClrUsed;
    uint bV4ClrImportant;
    uint bV4RedMask;
    uint bV4GreenMask;
    uint bV4BlueMask;
    uint bV4AlphaMask;
    uint bV4CSType;
    CIEXYZTRIPLE bV4Endpoints;
    uint bV4GammaRed;
    uint bV4GammaGreen;
    uint bV4GammaBlue;
};

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BITMAPV5HEADER
{
    uint bV5Size;
    int bV5Width;
    int bV5Height;
    ushort bV5Planes;
    ushort bV5BitCount;
    uint bV5Compression;
    uint bV5SizeImage;
    int bV5XPelsPerMeter;
    int bV5YPelsPerMeter;
    uint bV5ClrUsed;
    uint bV5ClrImportant;
    uint bV5RedMask;
    uint bV5GreenMask;
    uint bV5BlueMask;
    uint bV5AlphaMask;
    uint bV5CSType;
    CIEXYZTRIPLE bV5Endpoints;
    uint bV5GammaRed;
    uint bV5GammaGreen;
    uint bV5GammaBlue;
    uint bV5Intent;
    uint bV5ProfileData;
    uint bV5ProfileSize;
    uint bV5Reserved;
}


public class CustomBitmap
{
    public CustomBitmap()
    {

    }

    public bool ProcessHeader()
    {
        //1. try to read size of BITMAPFILEHEADER
        //2. validate that is in fact a bitmap
        //3. read theh size of the INFOHEADER
        //4. use the size to determine the version  (40, 108, 124)
        //5. fill the appropriate header        

        return false;
    }

};