using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.FileUpload
{
    public class FileUpload
    {
        public static IDataResult<string> AddFile(IFormFile files)
        {

           
            if (files.Length > 0)
            {
                var createPath = FolderAndFilePath(files);

                if (!CreateFolder(createPath.folderPath))
                {
                    Directory.CreateDirectory(createPath.folderPath);
                }
                using (FileStream stream = File.Create(createPath.filePath))
                {
                    files.CopyTo(stream);
                    stream.Flush();
                    return new SuccessDataResult<string>(createPath.lowerFolderPath + createPath.fileName);
                }

            }
            else
            {
                return new ErrorDataResult<string>(null);
            }
               


        }












        private static bool CreateFolder(string folderPath)
        {
           
             return   Directory.Exists(folderPath);
          
        }

        private static (string fileName, string folderPath,string lowerFolderPath, string filePath) FolderAndFilePath(IFormFile files)
        {
            string extension = Path.GetExtension(files.FileName);
            string fileName = Guid.NewGuid().ToString(format: "D") + extension;
            string folderPath = Path.Combine(Environment.CurrentDirectory, @"wwwroot\");
            string lowerFolderPath =  @"Images\";
            string filePath = Path.Combine(folderPath, lowerFolderPath, fileName) ;
           
            return (fileName, folderPath, lowerFolderPath, filePath);
        }

        public static IResult Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return new SuccessResult();
            }

            return new ErrorResult();
        }

        //public static IResult Update(string ımagePath)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
