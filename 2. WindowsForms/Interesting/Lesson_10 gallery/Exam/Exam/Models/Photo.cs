using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    [Serializable]
    public class Photo: ICloneable
    {
        public string PhotoName { get; set; }
        public string PhotoDescription { get; set; }
        public string PhotoPath { get; set; }
        public DateTime DownloadDataTime { get; set; }
        public string PhotoCategory { get; set; }
        public string PhotoAuthor { get; set; }

        public object Clone()
        {
            return new Photo
            {
                PhotoName = this.PhotoName,
                PhotoDescription = this.PhotoDescription,
                PhotoPath = this.PhotoPath,
                DownloadDataTime = this.DownloadDataTime,
                PhotoCategory = this.PhotoCategory,
                PhotoAuthor = this.PhotoAuthor
            };
        }

        public void Copy(Photo from)
        {
            PhotoName = from.PhotoName;
            PhotoDescription = from.PhotoDescription;
            PhotoPath = from.PhotoPath;
            DownloadDataTime = from.DownloadDataTime;
            PhotoCategory = from.PhotoCategory;
            PhotoAuthor = from.PhotoAuthor;
        }

        public override string ToString()
        {
            return $"{PhotoName} (Category: {PhotoCategory}) {DownloadDataTime}";
        }
        public string ShowDetailedInfo()
        {
            return $"PhotoName - {PhotoName}\n" +
                $"DownloadDataTime - {DownloadDataTime}\n" +
                $"PhotoCategory - {PhotoCategory}\n" +
                $"PhotoAuthor - {PhotoAuthor}";           
        }
    }
}
