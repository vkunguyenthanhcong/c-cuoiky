using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Khoa
    {
        string makhoa;
        string tenkhoa;

        public Khoa() { }
        public Khoa(string makhoa, string tenkhoa)
        {
            this.Makhoa = makhoa;
            this.Tenkhoa = tenkhoa;
        }

        public string Makhoa { get => makhoa; set => makhoa = value; }
        public string Tenkhoa { get => tenkhoa; set => tenkhoa = value; }
    }
}
