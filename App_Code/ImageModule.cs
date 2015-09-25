using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for ImageModule
/// </summary>
public class ImageModule
{
	public ImageModule()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public byte[] convertImageToByteArray(System.Drawing.Image imageToConvert, System.Drawing.Imaging.ImageFormat formatOfImage)
    {
        byte[] myByteArray;
        try
        {
            using (MemoryStream myMemoryStream = new MemoryStream())
            {
                imageToConvert.Save(myMemoryStream, formatOfImage);
                myByteArray = myMemoryStream.ToArray();
            }
        }
        catch (Exception)
        {
            throw;
        }
        return myByteArray;
    }
}