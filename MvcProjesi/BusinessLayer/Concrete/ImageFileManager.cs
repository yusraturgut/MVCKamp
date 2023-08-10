using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager:IImageService
    {
        IImageFileDal _ımageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _ımageFileDal = imageFileDal;
        }

        public List<ImageFile> GetList()
        {
           return _ımageFileDal.List();
        }
    }
}
