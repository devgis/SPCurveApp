using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurveApp
{
    public struct DataInfo
    {
        public static DataInfo GetDataInfo(Byte[] bytearr)
        {
            DataInfo data=new DataInfo();
            data.DataTime = DateTime.Now;
            if (bytearr == null || bytearr.Length >= 51)
            {
                data = new DataInfo();
                //data.header = BitConverter.ToInt16(bytearr, 0);
                data.CH1Lmpf = new short[8];
                data.CH1Qmpf = new short[8];
                for (int i = 0; i < 8; i++)
                {
                    data.CH1Lmpf[i] = BitConverter.ToInt16(bytearr, 2 * i + 2);
                }
                for (int i = 0; i < 8; i++)
                {
                    data.CH1Qmpf[i] = BitConverter.ToInt16(bytearr, 2 * i + 18);
                }

                data.CH1Lval = BitConverter.ToInt16(bytearr, 36);
                data.CH1Qval = BitConverter.ToInt16(bytearr, 38);
                data.CH2Lval = BitConverter.ToInt16(bytearr, 40);
                data.CH2Qval = BitConverter.ToInt16(bytearr, 42);
                data.CH3Lval = BitConverter.ToInt16(bytearr, 44);
                data.CH3Qval = BitConverter.ToInt16(bytearr, 46);
                data.carNco = BitConverter.ToInt16(bytearr, 48);
                data.MoveMidPos = bytearr[50];
            }
            return data;
        }

        public short header
        {
            get;set;
        }
        public short[] CH1Lmpf
        {
            get;
            set;
        }
        public short[] CH1Qmpf
        {
            get;
            set;
        }
        public int CH1Lval
        {
            get; set;
        }
        public int CH1Qval
        {
            get; set;
        }
        public int CH2Lval
        {
            get; set;
        }
        public int CH2Qval
        {
            get; set;
        }
        public int CH3Lval
        {
            get; set;
        }
        public int CH3Qval
        {
            get; set;
        }
        public int carNco
        {
            get; set;
        }
        public byte MoveMidPos
        {
            get; set;
        }
        public DateTime DataTime
        {
            get;
            set;
        }
    }

}
