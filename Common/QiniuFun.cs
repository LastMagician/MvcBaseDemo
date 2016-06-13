using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qiniu.Conf;
using System.Configuration;
using Qiniu.IO;
using Qiniu.RS;

namespace Common
{
    /// <summary>
    /// 七牛操作类
    /// </summary>
    public class QiniuFun
    {

        // 七牛初始化
        public void init()
        {
            Qiniu.Conf.Config.ACCESS_KEY = ConfigurationManager.AppSettings["ACCESS_KEY"];
            Qiniu.Conf.Config.SECRET_KEY = ConfigurationManager.AppSettings["SECRET_KEY"];
            string qnSpace = ConfigurationManager.AppSettings["qnSpace"];
            string itemname = ConfigurationManager.AppSettings["itemname"];
        }

        // 上传图片
        public string UploadFile(string bucket, string key, string path)
        {
            IOClient target = new IOClient();
            PutExtra extra = new PutExtra();
            // 设置上传的空间

            PutPolicy put = new PutPolicy(bucket, 3600);

            string upToken = put.Token();

            PutRet ret = target.PutFile(upToken, key, path, extra);

            return ret.Response.ToString();
        } 

        // 七牛空间名
        public string qnSpace
        {
            get {
                return ConfigurationManager.AppSettings["qnSpace"];
            }
             
        }
        
        // 项目名
        public string itemname
        {
            get
            {
                return ConfigurationManager.AppSettings["itemname"];
            }
        }

        public string outlink
        {
            get
            {
                return ConfigurationManager.AppSettings["outlink"];
            }
        }

        // 
        public string fullname(string name) 
        {
           return string.Format(itemname+ "{0}", name);         
       }
    }
}
