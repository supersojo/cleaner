using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/**
 * 清理目录及文件
 * 
 * 
 * 
 **/
namespace Cleaner
{
    class Dirs
    {
        private ArrayList dirs = new ArrayList();
        void Add(string d)
        {
            int index = -1;
            try
            {
                index = dirs.BinarySearch(d);
            } catch ()
            {

            }
            
            dirs.Add(d);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirinfo =new DirectoryInfo(@"C:\WINDOWS\Temp");
            if (dirinfo.Exists)
                Console.WriteLine("good dir");
            FileInfo[] files = dirinfo.GetFiles();
            Console.WriteLine(files.Count());
            for (int i = 0; i < files.Count(); i++)
            {
                Console.WriteLine("deleting:"+files[i].Name);
                try
                {
                    files[i].Delete();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Data);
                }
                
            }
            DirectoryInfo[] subdirs = dirinfo.GetDirectories();
            foreach(DirectoryInfo d in subdirs)
            {
                if(d.GetFiles().Count()!=0)
                    Console.WriteLine("dir has file");
                try
                {
                    d.Delete();
                    Console.WriteLine("delete dir ok");
                }
                catch(Exception e)
                { 
                    Console.WriteLine(e.Message);
                }
                
                Console.WriteLine("deleting:"+d.Name);
            }
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
