using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Swashbuckle.AspNetCore.SwaggerGen;
using static System.Net.WebRequestMethods;

namespace singleton_apirest
{
    public class Singleton
    {
        private static Singleton instance = null;
        public string mensaje = "";

        protected Singleton()
        {
            mensaje = "Hi";
        }

        public static String time
        {
            get
            {
                return System.DateTime.UtcNow.ToString();
            }
        }

        public static List<Dictionary<string, object>> dirlist(String dirpath)
        {
            List<Dictionary<string, object>> files_list = new List<Dictionary<string, object>>();
            Dictionary<string, object> files_dir = new Dictionary<string, object>();
            try
            {
                DirectoryInfo d = new DirectoryInfo(@dirpath);

                FileInfo[] Files = d.GetFiles("*"); //Getting Text files

                int i = 0;
                foreach (FileInfo file in Files)
                {
                    i++;
                    files_dir.Add(i.ToString(), file.Name);
                }
                files_list.Add(files_dir);
            }
            catch (Exception e)
            {
                files_dir.Add("msg", e);
                files_list.Add(files_dir);
            }
            return files_list;
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();

                return instance;
            }
        }

    }
}
