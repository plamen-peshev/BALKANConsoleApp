using BALKAN;
using System;
using System.Collections.Generic;
using System.Text;

namespace BALKANConsoleApp
{
    public static class Image
    {
        public static void Upload()
        {
            var imageService = new ImageService();

            var resultUpload  = imageService.Upload(new List<string> { "alf.jpg" });

            if (!resultUpload.IsSuccess)
            {
                Console.WriteLine(resultUpload.Error);
            }
            else
            {
                foreach (var image in resultUpload.Images)
                {
                    Console.WriteLine(image.OriginalFileName);
                    Console.WriteLine(image.NewFileName);
                    Console.WriteLine(image.Url);
                }
            }         
        }  
    }
}
