using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestSendData
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort serialPort = new SerialPort("COM6");
            serialPort.BaudRate = 115200;//波特率
            serialPort.Parity = Parity.None;//无奇偶校验位
            serialPort.StopBits = StopBits.Two;//两个停止位
            serialPort.Handshake = Handshake.RequestToSend;//控制协议
            serialPort.ReceivedBytesThreshold = 4;//设置 DataReceived 事件发生前内部输入缓冲区中的字节数
            serialPort.Open();
            byte[] barr = new byte[] { 0x5A ,0x69 ,0x02 ,0x03 ,0x04 ,0x05 ,0x06 ,0x07 ,0x08 ,0x09 ,0x0A ,0x0B ,0x0C ,0x0D ,0x0E ,0x0F ,0x10 ,0x11 ,0x12 ,0x13 ,0x14 ,0x15 ,0x16 ,0x17 ,0x18 ,0x19 ,0x1A ,0x1B ,0x1C ,0x1D ,0x1E ,0x1F ,0x20 ,0x21 ,0x22 ,0x23 ,0x01 ,0x2F ,0xFF ,0xD5 ,0x00 ,0x00 ,0x00 ,0x00 ,0x00 ,0x00 ,0x00 ,0x00 ,0x33 ,0x48 ,0x00 };
            for (int i = 0; i < int.MaxValue; i++)
            {
                serialPort.Write(barr, 0, 51);
                Thread.Sleep(15);
            }
            Console.WriteLine("Finished");
            Console.Read();
        }
    }
}
