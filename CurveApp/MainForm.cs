using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;

namespace CurveApp
{
    public partial class MainForm : Form
    {
        SerialPort serialPort = null;
        static int maxcount = 100;
        const int allowmaxcount = 1000;
        const int allowmincount = 100;
        static byte[] arrHeader = new byte[] { 0x5A, 0x69,}; //数据帧头
        const byte emptyByte = 0x00;
        public MainForm()
        {
            InitializeComponent();
            try
            {
                maxcount = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MaxDisplayCount"]);
            }
            catch
            { }
            if (maxcount < allowmincount)
            {
                maxcount = allowmincount;
            }
            else if (maxcount > allowmaxcount)
            {
                maxcount = allowmaxcount;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            comboPortName.Items.AddRange(ports);
            comboPortName.SelectedIndex = comboPortName.Items.Count > 0 ? 0 : -1;
            this.comboBaudrate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            comboBaudrate.SelectedIndex = comboBaudrate.Items.IndexOf("115200");


            InitChart();
            timerRefreshChart.Start();
            //UpdateChart(null);
        }
        Queue<DataInfo> queueData = new Queue<DataInfo>();
        List<byte> listByte =new List<byte>();
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                lock (listByte)
                {
                    //循环接收数据

                    byte prebyte = emptyByte;
                    while (serialPort.BytesToRead > 0)
                    {
                        Application.DoEvents();
                        byte b = emptyByte;
                        b = (byte)serialPort.ReadByte();
                        
                        //int c = serialPort.ReadChar();
                        //b = (byte)((serialPort.ReadChar() & 0xFF00) >> 8); 
                        if (b == arrHeader[1] && prebyte == arrHeader[0])
                        {
                            prebyte = emptyByte;
                            //移除两次
                            if(listByte.Count>0)
                            {
                                listByte.RemoveAt(listByte.Count - 1);
                            }

                            if (listByte.Count >= 51)
                            {
                                string message = BitConverter.ToString(listByte.ToArray<byte>(), 0);
                                //AddLog(message.Replace("-", ""));
                                AddLog(message);

                                //启动线程去处理
                                //Application.DoEvents();
                                DataInfo data = DataInfo.GetDataInfo(listByte.ToArray<Byte>());
                                lock (queueData)
                                {
                                    queueData.Enqueue(data);
                                }
                            }
                            listByte.Clear();
                            listByte.Add(arrHeader[0]);
                            listByte.Add(arrHeader[1]);
                        }
                        else
                        {
                            if (b == arrHeader[0])
                            {
                                prebyte = arrHeader[0];
                            }
                            else
                            {
                                prebyte = emptyByte;
                            }
                            listByte.Add(b);
                            if (listByte.Count >= 51)
                            {
                                string message = BitConverter.ToString(listByte.ToArray<byte>(), 0);
                                AddLog(message);

                                DataInfo data = DataInfo.GetDataInfo(listByte.ToArray<Byte>());
                                lock (queueData)
                                {
                                    queueData.Enqueue(data);
                                }
                                listByte.Clear();
                            }
                        }
                    }
                }
            });
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                timerRefreshChart.Stop();
                try
                {
                    serialPort.Close();
                }
                catch
                { }
                try
                {
                    Application.ExitThread();
                }
                catch
                { }
            }
        }

        private void AddLog(string text)
        {
            tbLogs.Invoke((EventHandler)(delegate
            {
                if (tbLogs.Text.Length > 20000)
                {
                    tbLogs.Clear();
                }
                tbLogs.Text = (DateTime.Now.ToString("HH:mm:ss") + ":" + text + "\r\n") + tbLogs.Text;

                //滚动到底部
                //tbLogs.Text = +=(DateTime.Now.ToString("HH:mm:ss") + ":" + text + "\r\n");
                //tbLogs.Select(tbLogs.Text.Length, 0);
                //tbLogs.ScrollToCaret();

            }));
        }


        #region 绘图相关
        private string timeFormat = "hh:mm:ss";
        private void InitChart()
        {
            InitChart1();
            InitChart2();
            InitChart3();
            InitChart4();
            InitChart5();
            InitChart6();
        }

        #region 绘图数据变量
        //chart1 
        PointPairList listCH1Lmpf = new PointPairList();
        PointPairList listCH1Qmpf = new PointPairList();
        List<string> listLabelsChart1 = new List<string>();

        //chart2 
        PointPairList listCH1Lval = new PointPairList();
        PointPairList listCH1Qval = new PointPairList();
        List<string> listLabelsChart2 = new List<string>();

        //chart3
        PointPairList listCH2Lval = new PointPairList();
        PointPairList listCH2Qval = new PointPairList();
        List<string> listLabelsChart3 = new List<string>();

        //chart4
        PointPairList listCH3Lval = new PointPairList();
        PointPairList listCH3Qval = new PointPairList();
        List<string> listLabelsChart4 = new List<string>();

        //chart5
        PointPairList listcarNco = new PointPairList();
        List<string> listLabelsChart5 = new List<string>();

        //chart6
        PointPairList listMoveMidPos = new PointPairList();
        List<string> listLabelsChart6 = new List<string>();

        #endregion

        #region 创建绘图
        public void InitChart1()
        {
            GraphPane myPane = chart1.GraphPane;

            //设置图标标题和x、y轴标题
            myPane.Title.Text = "曲线";
            myPane.XAxis.Title.Text = "时间";
            myPane.YAxis.Title.Text = "值";

            //更改标题的字体

            FontSpec myFont = new FontSpec("Arial", 16, Color.Red, false, false, false);
            myPane.Title.FontSpec = myFont;
            myPane.XAxis.Title.FontSpec = myFont;
            myPane.YAxis.Title.FontSpec = myFont;

            LineItem myCurve1 = myPane.AddCurve("CH1Lmpf", listCH1Lmpf, Color.Red, SymbolType.Star);
            LineItem myCurve2 = myPane.AddCurve("CH1Qmpf", listCH1Qmpf, Color.Green, SymbolType.Triangle);
        }
        public void InitChart2()
        {
            GraphPane myPane = chart2.GraphPane;

            //设置图标标题和x、y轴标题
            myPane.Title.Text = "曲线";
            myPane.XAxis.Title.Text = "时间";
            myPane.YAxis.Title.Text = "值";

            //更改标题的字体

            FontSpec myFont = new FontSpec("Arial", 16, Color.Red, false, false, false);
            myPane.Title.FontSpec = myFont;
            myPane.XAxis.Title.FontSpec = myFont;
            myPane.YAxis.Title.FontSpec = myFont;

            LineItem myCurve1 = myPane.AddCurve("CH1Lval", listCH1Lval, Color.Red, SymbolType.Star);
            LineItem myCurve2 = myPane.AddCurve("CH1Qval", listCH1Qval, Color.Green, SymbolType.Triangle);
        }
        public void InitChart3()
        {
            GraphPane myPane = chart3.GraphPane;

            //设置图标标题和x、y轴标题
            myPane.Title.Text = "曲线";
            myPane.XAxis.Title.Text = "时间";
            myPane.YAxis.Title.Text = "值";

            //更改标题的字体

            FontSpec myFont = new FontSpec("Arial", 16, Color.Red, false, false, false);
            myPane.Title.FontSpec = myFont;
            myPane.XAxis.Title.FontSpec = myFont;
            myPane.YAxis.Title.FontSpec = myFont;

            LineItem myCurve1 = myPane.AddCurve("CH2Lval", listCH2Lval, Color.Red, SymbolType.Star);
            LineItem myCurve2 = myPane.AddCurve("CH2Qval", listCH2Qval, Color.Green, SymbolType.Triangle);
        }
        public void InitChart4()
        {
            GraphPane myPane = chart4.GraphPane;

            //设置图标标题和x、y轴标题
            myPane.Title.Text = "曲线";
            myPane.XAxis.Title.Text = "时间";
            myPane.YAxis.Title.Text = "值";

            //更改标题的字体

            FontSpec myFont = new FontSpec("Arial", 16, Color.Red, false, false, false);
            myPane.Title.FontSpec = myFont;
            myPane.XAxis.Title.FontSpec = myFont;
            myPane.YAxis.Title.FontSpec = myFont;
            LineItem myCurve1 = myPane.AddCurve("CH3Lval", listCH3Lval, Color.Red, SymbolType.Star);
            LineItem myCurve2 = myPane.AddCurve("CH3Qval", listCH3Qval, Color.Green, SymbolType.Triangle);
        }
        public void InitChart5()
        {
            GraphPane myPane = chart5.GraphPane;

            //设置图标标题和x、y轴标题
            myPane.Title.Text = "曲线";
            myPane.XAxis.Title.Text = "时间";
            myPane.YAxis.Title.Text = "值";

            //更改标题的字体

            FontSpec myFont = new FontSpec("Arial", 16, Color.Red, false, false, false);
            myPane.Title.FontSpec = myFont;
            myPane.XAxis.Title.FontSpec = myFont;
            myPane.YAxis.Title.FontSpec = myFont;

            // 用list1生产一条曲线
            LineItem myCurve1 = myPane.AddCurve("carNco", listcarNco, Color.Red, SymbolType.Star);

        }
        public void InitChart6()
        {
            GraphPane myPane = chart6.GraphPane;

            //设置图标标题和x、y轴标题
            myPane.Title.Text = "曲线";
            myPane.XAxis.Title.Text = "时间";
            myPane.YAxis.Title.Text = "值";

            //更改标题的字体

            FontSpec myFont = new FontSpec("Arial", 16, Color.Red, false, false, false);
            myPane.Title.FontSpec = myFont;
            myPane.XAxis.Title.FontSpec = myFont;
            myPane.YAxis.Title.FontSpec = myFont;

            // 用list1生产一条曲线
            LineItem myCurve1 = myPane.AddCurve("MoveMidPos", listMoveMidPos, Color.Red, SymbolType.Star);
        }
        #endregion

        private void UpdateChart(List<DataInfo> data)
        {
            if (data == null || data.Count <= 0)
                return;
            this.Invoke((EventHandler)(delegate
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        UpdateChart1(data);
                    });
                }
                catch
                { }

                try
                {
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        UpdateChart2(data);
                    });
                }
                catch
                { }

                try
                {
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        UpdateChart3(data);
                    });
                }
                catch
                { }

                try
                {
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        UpdateChart4(data);
                    });
                }
                catch
                {
                }

                try
                {
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        UpdateChart5(data);
                    });
                }
                catch
                {
                }

                try
                {
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        UpdateChart6(data);
                    });
                }
                catch
                {
                }

                ThreadPool.QueueUserWorkItem(o =>
                {
                    UpdateChart1(data);

                });
            }));
        }

        #region 更新数据
        public void UpdateChart1(List<DataInfo> listdata)
        {
            chart1.Invoke((EventHandler)(delegate
            {
                GraphPane myPane = chart1.GraphPane;
                foreach (DataInfo data in listdata)
                {
                    if (data.CH1Lmpf == null || data.CH1Qmpf == null)
                    {
                        continue;
                    }
                    Application.DoEvents();
                    if (listCH1Lmpf.Count >= maxcount)
                    {
                        listCH1Lmpf.RemoveRange(0, 8);
                    }
                    if (listCH1Qmpf.Count >= maxcount)
                    {
                        listCH1Qmpf.RemoveRange(0, 8);
                    }
                    if (listLabelsChart1.Count >= maxcount)
                    {
                        listLabelsChart1.RemoveRange(0, 8);
                    }

                    for (int i = 0; i < 8; i++)
                    {
                        listCH1Lmpf.Add(listCH1Lmpf.Count, data.CH1Lmpf[i]);
                        listCH1Qmpf.Add(listCH1Qmpf.Count, data.CH1Qmpf[i]);
                    }

                    //以上生成的图标X轴为数字，下面将转换为日期的文本
                    for (int i = 0; i < 8; i++)
                    {
                        listLabelsChart1.Add(data.DataTime.AddMilliseconds(i).ToString(timeFormat));
                    }
                }

                //填充图表颜色
                myPane.Fill = new Fill(Color.White, Color.FromArgb(200, 200, 255), 45.0f);
                myPane.XAxis.Scale.TextLabels = listLabelsChart1.ToArray<string>(); //X轴文本取值
                myPane.XAxis.Type = AxisType.Text;   //X轴类型

                //画到zedGraphControl1控件中，此句必加
                chart1.AxisChange();//在数据变化时绘图
                                    //更新图表
                chart1.Invalidate();
                //重绘控件
                chart1.Refresh();
            }));
        }
        public void UpdateChart2(List<DataInfo> listdata)
        {
            chart2.Invoke((EventHandler)(delegate
            {
                GraphPane myPane = chart2.GraphPane;
                foreach (DataInfo data in listdata)
                {
                    if (data.CH1Lmpf == null || data.CH1Qmpf == null)
                    {
                        continue;
                    }
                    Application.DoEvents();
                    if (listCH1Lval.Count >= maxcount)
                    {
                        listCH1Lval.RemoveRange(0, 8);
                    }
                    if (listCH1Qval.Count >= maxcount)
                    {
                        listCH1Qval.RemoveRange(0, 8);
                    }
                    if (listLabelsChart2.Count >= maxcount)
                    {
                        listLabelsChart2.RemoveRange(0, 8);
                    }


                    listCH1Lval.Add(listCH1Lval.Count, data.CH1Lval); //添加一组数据
                    listCH1Qval.Add(listCH1Qval.Count, data.CH1Qval); //添加一组数据
                                                                      //以上生成的图标X轴为数字，下面将转换为日期的文本
                    listLabelsChart2.Add(data.DataTime.ToString(timeFormat));
                }

                //填充图表颜色
                myPane.Fill = new Fill(Color.White, Color.FromArgb(200, 200, 255), 45.0f);



                myPane.XAxis.Scale.TextLabels = listLabelsChart2.ToArray<string>(); //X轴文本取值
                myPane.XAxis.Type = AxisType.Text;   //X轴类型

                //画到zedGraphControl1控件中，此句必加
                chart2.AxisChange();//在数据变化时绘图
                                    //更新图表
                chart2.Invalidate();
                //重绘控件
                chart2.Refresh();
            }));
        }
        public void UpdateChart3(List<DataInfo> listdata)
        {
            chart3.Invoke((EventHandler)(delegate
            {
                GraphPane myPane = chart3.GraphPane;
                foreach (DataInfo data in listdata)
                {
                    if (data.CH1Lmpf == null || data.CH1Qmpf == null)
                    {
                        continue;
                    }
                    Application.DoEvents();
                    if (listCH2Lval.Count >= maxcount)
                    {
                        listCH2Lval.RemoveRange(0, 8);
                    }
                    if (listCH2Qval.Count >= maxcount)
                    {
                        listCH2Qval.RemoveRange(0, 8);
                    }
                    if (listLabelsChart3.Count >= maxcount)
                    {
                        listLabelsChart3.RemoveRange(0, 8);
                    }


                    listCH2Lval.Add(listCH2Lval.Count, data.CH2Lval); //添加一组数据
                    listCH2Qval.Add(listCH2Qval.Count, data.CH2Qval); //添加一组数据

                    //以上生成的图标X轴为数字，下面将转换为日期的文本
                    listLabelsChart3.Add(data.DataTime.ToString(timeFormat));
                }

                //填充图表颜色
                myPane.Fill = new Fill(Color.White, Color.FromArgb(200, 200, 255), 45.0f);


                myPane.XAxis.Scale.TextLabels = listLabelsChart3.ToArray<string>(); //X轴文本取值
                myPane.XAxis.Type = AxisType.Text;   //X轴类型

                //画到zedGraphControl1控件中，此句必加
                chart3.AxisChange();//在数据变化时绘图
                                    //更新图表
                chart3.Invalidate();
                //重绘控件
                chart3.Refresh();
            }));
        }
        public void UpdateChart4(List<DataInfo> listdata)
        {
            chart4.Invoke((EventHandler)(delegate
            {
                GraphPane myPane = chart4.GraphPane;
                foreach (DataInfo data in listdata)
                {
                    if (data.CH1Lmpf == null || data.CH1Qmpf == null)
                    {
                        continue;
                    }
                    Application.DoEvents();
                    if (listCH3Lval.Count >= maxcount)
                    {
                        listCH3Lval.RemoveRange(0, 8);
                    }
                    if (listCH3Qval.Count >= maxcount)
                    {
                        listCH3Qval.RemoveRange(0, 8);
                    }
                    if (listLabelsChart4.Count >= maxcount)
                    {
                        listLabelsChart4.RemoveRange(0, 8);
                    }


                    listCH3Lval.Add(listCH2Lval.Count, data.CH3Lval); //添加一组数据
                    listCH3Qval.Add(listCH2Qval.Count, data.CH3Qval); //添加一组数据
                                                                      //以上生成的图标X轴为数字，下面将转换为日期的文本
                    listLabelsChart4.Add(data.DataTime.ToString(timeFormat));
                }

                //填充图表颜色
                myPane.Fill = new Fill(Color.White, Color.FromArgb(200, 200, 255), 45.0f);


                myPane.XAxis.Scale.TextLabels = listLabelsChart4.ToArray<string>(); //X轴文本取值
                myPane.XAxis.Type = AxisType.Text;   //X轴类型

                //画到zedGraphControl1控件中，此句必加
                chart4.AxisChange();//在数据变化时绘图
                                    //更新图表
                chart4.Invalidate();
                //重绘控件
                chart4.Refresh();
            }));
        }
        public void UpdateChart5(List<DataInfo> listdata)
        {
            chart5.Invoke((EventHandler)(delegate
            {
                GraphPane myPane = chart5.GraphPane;
                foreach (DataInfo data in listdata)
                {
                    if (data.CH1Lmpf == null || data.CH1Qmpf == null)
                    {
                        continue;
                    }
                    Application.DoEvents();
                    if (listcarNco.Count >= maxcount)
                    {
                        listcarNco.RemoveRange(0, 8);
                    }
                    if (listLabelsChart5.Count >= maxcount)
                    {
                        listLabelsChart5.RemoveRange(0, 8);
                    }

                    listcarNco.Add(listcarNco.Count, data.carNco);

                    //以上生成的图标X轴为数字，下面将转换为日期的文本
                    listLabelsChart5.Add(data.DataTime.ToString(timeFormat));
                }
                //填充图表颜色
                myPane.Fill = new Fill(Color.White, Color.FromArgb(200, 200, 255), 45.0f);

                myPane.XAxis.Scale.TextLabels = listLabelsChart5.ToArray<string>(); //X轴文本取值
                myPane.XAxis.Type = AxisType.Text;   //X轴类型

                //画到zedGraphControl1控件中，此句必加
                chart5.AxisChange();//在数据变化时绘图
                                    //更新图表
                chart5.Invalidate();
                //重绘控件
                chart5.Refresh();
            }));
        }
        public void UpdateChart6(List<DataInfo> listdata)
        {
            chart6.Invoke((EventHandler)(delegate
            {
                GraphPane myPane = chart6.GraphPane;
                foreach (DataInfo data in listdata)
                {
                    if (data.CH1Lmpf == null || data.CH1Qmpf == null)
                    {
                        continue;
                    }
                    Application.DoEvents();
                    if (listMoveMidPos.Count >= maxcount)
                    {
                        listMoveMidPos.RemoveRange(0, 8);
                    }
                    if (listLabelsChart6.Count >= maxcount)
                    {
                        listLabelsChart6.RemoveRange(0, 8);
                    }

                    listMoveMidPos.Add(listMoveMidPos.Count, data.MoveMidPos);
                    //以上生成的图标X轴为数字，下面将转换为日期的文本
                    listLabelsChart6.Add(data.DataTime.ToString(timeFormat));
                }

                //填充图表颜色
                myPane.Fill = new Fill(Color.White, Color.FromArgb(200, 200, 255), 45.0f);


                myPane.XAxis.Scale.TextLabels = listLabelsChart6.ToArray<string>(); //X轴文本取值
                myPane.XAxis.Type = AxisType.Text;   //X轴类型

                //画到zedGraphControl1控件中，此句必加
                chart6.AxisChange();//在数据变化时绘图
                                    //更新图表
                chart6.Invalidate();
                //重绘控件
                chart6.Refresh();
            }));
        }
        #endregion

        #endregion

        private void btSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存日志到文件";
            sfd.Title = "请选择文件";
            sfd.Filter = "文本文件|.txt"; //设置要选择的文件的类型
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string file = sfd.FileName;//返回文件的完整路径 
                try
                {
                    File.WriteAllText(sfd.FileName, tbLogs.Text, Encoding.Default);
                    MessageHelper.ShowInfo("保存成功！");
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowInfo("保存失败,错误消息:" + ex.Message);
                }
            }
        }

        private void btSaveChartData_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                FolderBrowserDialog sfd = new FolderBrowserDialog();
                sfd.SelectedPath = "保存日志到文件";
                sfd.Description = "保存日志到文件";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        switch ((sender as Button).Name)
                        {
                            case "btSave1":
                                string CH1LmpfTxtData = GetChartData(listCH1Lmpf, listLabelsChart1);
                                File.WriteAllText(Path.Combine(sfd.SelectedPath, "CH1LmpfData" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt"), CH1LmpfTxtData, Encoding.Default);
                                string CH1QmpfTxtData = GetChartData(listCH1Qmpf, listLabelsChart1);
                                File.WriteAllText(Path.Combine(sfd.SelectedPath, "CH1QmpfData" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt"), CH1QmpfTxtData, Encoding.Default);
                                break;
                            case "btSave2":
                                string CH1LvalTxtData = GetChartData(listCH1Lval, listLabelsChart2);
                                File.WriteAllText(Path.Combine(sfd.SelectedPath, "CH1LvalData" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt"), CH1LvalTxtData, Encoding.Default);
                                string CH1QvalTxtData = GetChartData(listCH1Qval, listLabelsChart2);
                                File.WriteAllText(Path.Combine(sfd.SelectedPath, "CH1QvalData" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt"), CH1QvalTxtData, Encoding.Default);
                                break;
                            case "btSave3":
                                string CH2LvalTxtData = GetChartData(listCH2Lval, listLabelsChart3);
                                File.WriteAllText(Path.Combine(sfd.SelectedPath, "CH2LvalData" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt"), CH2LvalTxtData, Encoding.Default);
                                string CH2QvalTxtData = GetChartData(listCH2Qval, listLabelsChart3);
                                File.WriteAllText(Path.Combine(sfd.SelectedPath, "CH2QvalData" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt"), CH2QvalTxtData, Encoding.Default);
                                break;
                            case "btSave4":
                                string CH3LvalTxtData = GetChartData(listCH3Lval, listLabelsChart4);
                                File.WriteAllText(Path.Combine(sfd.SelectedPath, "CH3LvalData" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt"), CH3LvalTxtData, Encoding.Default);
                                string CH3QvalTxtData = GetChartData(listCH3Qval, listLabelsChart4);
                                File.WriteAllText(Path.Combine(sfd.SelectedPath, "CH3QvalData" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt"), CH3QvalTxtData, Encoding.Default);
                                break;
                            case "btSave5":
                                string carNcoTxtData = GetChartData(listcarNco, listLabelsChart5);
                                File.WriteAllText(Path.Combine(sfd.SelectedPath, "carNcoData" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt"), carNcoTxtData, Encoding.Default);
                                break;
                            case "btSave6":
                                string MoveMidPosTxtData = GetChartData(listMoveMidPos, listLabelsChart6);
                                File.WriteAllText(Path.Combine(sfd.SelectedPath, "MoveMidPosData" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt"), MoveMidPosTxtData, Encoding.Default);
                                break;
                        }
                        //File.WriteAllText(sfd.FileName, tbLogs.Text, Encoding.Default);
                        MessageHelper.ShowInfo("保存成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageHelper.ShowInfo("保存失败,错误消息:" + ex.Message);
                    }
                }
            }
        }


        private string GetChartData(PointPairList list, List<string> listData)
        {
            string temp = string.Empty;
            if (list == null || listData == null || list.Count <= 0 || listData.Count <= 0 || list.Count != listData.Count)
            {
                temp = "DataError";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < listData.Count; i++)
                {
                    string data = string.Empty;
                    try
                    {
                        data = list[i].Y.ToString();
                    }
                    catch
                    { }
                    sb.AppendLine(listData[i] + ":" + data);
                }
                temp = sb.ToString();
            }
            return temp;
        }

        private void timerRefreshChart_Tick(object sender, EventArgs e)
        {
            if (queueData.Count <= 0)
                return;
            ThreadPool.QueueUserWorkItem(o =>
            {
                lock (queueData)
                {
                    List<DataInfo> datalist = queueData.ToList<DataInfo>();
                    queueData.Clear();
                    UpdateChart(datalist);
                }
            });
        }

        private void buttonOpenClose_Click(object sender, EventArgs e)
        {
            if (buttonOpenClose.Text == "打开")
            {
                try
                {
                    serialPort = new SerialPort(comboPortName.Text);
                }
                catch
                {
                    serialPort = new SerialPort("COM5");
                }

                try
                {
                    serialPort.BaudRate = int.Parse(comboBaudrate.Text);
                }
                catch
                {
                    serialPort.BaudRate = 9600;
                }

                try
                {
                    //serialPort.DtrEnable = true;
                    serialPort.DataBits = 8;
                    serialPort.Parity = Parity.None;//无奇偶校验位
                    serialPort.StopBits = StopBits.One;//两个停止位
                    serialPort.Handshake = Handshake.RequestToSend;//控制协议
                    serialPort.ReceivedBytesThreshold = 60;//设置 DataReceived 事件发生前内部输入缓冲区中的字节数
                    serialPort.DataReceived += SerialPort_DataReceived;
                    serialPort.Open();
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("打开失败，错误消息:" + ex.Message);
                }
                buttonOpenClose.Text = "关闭";
            }
            else
            {
                try
                {
                    serialPort.Close();
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("关闭失败:" + ex.Message);
                }
                buttonOpenClose.Text = "打开";
            }
        }
    }
}
