using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NetCore3._0Mvc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace NetCore3._0Mvc.helper
{
    public class FileHelper
    {
    

        [Obsolete]
        public async Task saveImagesDBAsync(IFormFile imageFile,int gameId, IHostingEnvironment env, GamesContext gameContext)
        {
            var uploads = Path.Combine(env.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            var fileNameWithOutExtension = Path.GetFileNameWithoutExtension(imageFile.FileName); // uzantısız adı alınır
            var extension = Path.GetExtension(imageFile.FileName); // uzantısı alınır
            fileNameWithOutExtension = Regex.Replace(fileNameWithOutExtension, "[^a-zA-Z0-9_]+", "_", RegexOptions.Compiled);

            if (imageFile.Length > 0)
            {
                var fileSavedName = fileNameWithOutExtension + extension;
                var filePath = Path.Combine(uploads, fileSavedName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                    var games = await gameContext.GamesTable.FindAsync(gameId);

                    games.ImagePath = fileSavedName;
                    gameContext.Update(games);
                    await gameContext.SaveChangesAsync();
                    

                }
            }



        }
    }
}
