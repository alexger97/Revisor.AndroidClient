using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Revisor.Service
{
    public class CompressionService
    {

        public static byte[] CreateCompress(string filename)
        {
            if (File.Exists(filename))
            {
                using (FileStream originalFileStream = File.OpenRead(filename))
                {
                    using (MemoryStream s = new MemoryStream())
                    {
                        GZipStream compressionStream = new GZipStream(s, CompressionMode.Compress);
                        originalFileStream.CopyTo(compressionStream);
                        return s.ToArray();
                    }
                }

            }
            return null;


        }

    }
}
