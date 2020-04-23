using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4SChan
{
    public class ImagesClass
    {
        private bool isSelected;
        private string URLOfImage;
        private string nameOfImage;
        private string fileTypeOfImage;
        private double downloadSize;

        public ImagesClass()
        {

        }

        public bool getIsSelected()
        {
            return isSelected;
        }

        public void setIsSelected(bool isSelected)
        {
            this.isSelected = isSelected;
        }

        public string getURLOfImage()
        {
            return URLOfImage;
        }

        public void setURLOfImage(string URLOfImage)
        {
            this.URLOfImage = URLOfImage;
        }

        public string getNameOfImage()
        {
            return nameOfImage;
        }

        public void setNameOfImage(string nameOfImage)
        {
            this.nameOfImage = nameOfImage; 
        }

        public string getFileTypeOfImage()
        {
            return fileTypeOfImage;
        }

        public void setFileTypeOfImage(string fileTypeOfImage)
        {
            this.fileTypeOfImage = fileTypeOfImage;
        }

        public double getDownloadSize()
        {
            return downloadSize;
        }

        public void setDownloadSize(double downloadSize)
        {
            this.downloadSize = downloadSize;
        }
    }
}
