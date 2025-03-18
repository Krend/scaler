Simple application to test different image upscaling/downscaling methods.

The project uses SkiaSharp since System.Drawing isn't suppoorted outside of windows since .net 6.

...
The default nuget package for SkiaSharp has limited support for image formats under linux (only png, jpeg and webp are available).

Since I would very much like to use basic bitmaps, I'll implement my own.
