using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PC.Common
{
    public sealed class FileOper
    {
        private FileOper() { }
        public static readonly FileOper objFileOper = new FileOper();

        /// <summary>
        /// 保存文件并返回文件路径
        /// </summary>
        /// <param name="file1"></param>
        /// <returns></returns>
        public string uploadFile(System.Web.HttpPostedFile file1)
        {
            if (file1 == null)
                throw new Exception("缺少上传文件！");
            //判断文件类型是否正确或者用后缀
            string ext = System.IO.Path.GetExtension(file1.FileName).ToLower();
            string suffix = ".xls,.xlsx,";
            if (suffix.ToLower().IndexOf(ext) == -1)
            {
                throw new Exception("文件格式错误！");
            }
            //获取文件存放的服务器目录
            string path = PC.Common.Config.objConfig.getStringAppSetings("tempFile");
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            //检验文件是否存在,存在则另起名保存
            string filename=System.IO.Path.GetFileName(file1.FileName);
            if (existSameFile(path, filename))
                filename = System.DateTime.Now.ToString("yyMMddHHmmss")+"_" + filename;
            file1.SaveAs(path + filename);
            return path + filename;
        }

        public bool existSameFile(string path, string filename)
        {
            System.IO.FileInfo fileinfo = new System.IO.FileInfo(path + filename);
            if (fileinfo.Exists)
                return true;
            else
                return false;
        }
    }
}
