using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using lz_string_csharp;
using System.IO;

namespace lzstring_project
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: lzstring_project.exe <path/fin> <path/fout>");
                Console.ReadLine();
            }
            else {

                // absolute file path
                //string fin = @"D:\code\gist\NS1Hosp2GeoJSON\20160603\ns1hosp_20160603.json";
                //string fout = @"D:\code\gist\NS1Hosp2GeoJSON\20160603\ns1hosp_20160603_lzstring.json";

                string fin = @args[0];
                string fout = @args[1];

                if (File.Exists(fin))
                {
                    // utf-16
                    string content = null, getCompData = null;
                    LZString lzObj = new LZString();
                    using (StreamWriter sw = new StreamWriter(fout))
                    {
                        using (StreamReader sr = new StreamReader(fin))
                        {
                            while (sr.Peek() >= 0)
                            {
                                // must read all content
                                content = content + sr.ReadLine();
                            }
                            getCompData = lzObj.compressToUTF16(content);
                            sw.Write(getCompData);
                        }
                    }
                }
                else {
                    Console.WriteLine("Error: file not found.");
                }
                Console.WriteLine("Complete");
                Console.ReadLine();
            }
        }
    }
}
