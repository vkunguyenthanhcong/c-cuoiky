using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Lop
    {
        string tenlop;
        int siso;
        string makhoa;

        public Lop(string tenlop, int siso, string makhoa)
        {
            this.Tenlop = tenlop;
            this.Siso = siso;
            this.Makhoa = makhoa;
        }

        public string Tenlop { get => tenlop; set => tenlop = value; }
        public int Siso { get => siso; set => siso = value; }
        public string Makhoa { get => makhoa; set => makhoa = value; }
    }
}
