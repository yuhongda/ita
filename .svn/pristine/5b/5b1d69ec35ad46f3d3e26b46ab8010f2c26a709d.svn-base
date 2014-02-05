using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITA.Model
{
    public class Thumbnail
    {
        public Thumbnail(string id, byte[] data)
        {
            this.ID = id;
            this.Data = data;
        }

        public Thumbnail(string id, string filename, byte[] data)
        {
            this.ID = id;
            this.FileName = filename;
            this.Data = data;
        }
        private string id;
        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string FileName { get; set; }

        private byte[] thumbnail_data;
        public byte[] Data
        {
            get
            {
                return this.thumbnail_data;
            }
            set
            {
                this.thumbnail_data = value;
            }
        }
    }
}
