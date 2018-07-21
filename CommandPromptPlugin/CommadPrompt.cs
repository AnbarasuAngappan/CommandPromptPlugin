using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.AddIn;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Drawing.Printing;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Windows.Documents;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using Spire;
using Spire.Pdf;

namespace CommandPromptPlugin
{
    [AddIn("CommadPrompt")]
    public class CommadPrompt
    {
        public void Commandpromt()
        {
            //string strCmdText;
            //strCmdText = "/C ipconfig";///C copy /b Image1.jpg + Archive.rar Image2.jpg
            //System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            //string IPAddress = "ipconfig";
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            //process.StartInfo.UseShellExecute = false;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "/C"+ IPAddress;
            //process.StartInfo = startInfo;
            //process.Start();          

            //string IPAddress = "ipconfig";
            //Process rdcProcess = new Process();
            //rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
            ////rdcProcess.StartInfo.Arguments = "/generic:TERMSRV/192.168.1.155 /user:" + Username + " /pass:" + Password;
            //rdcProcess.StartInfo.Arguments = "/generic:TERMSRV/" + IPAddress;
            //rdcProcess.Start();

            //rdcProcess.StartInfo.FileName = Environment.GetCommandLineArgs();//ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmd.exe");
            //rdcProcess.StartInfo.Arguments = "/C" + IPAddress;
            //rdcProcess.Start();

        }

        public static string ExecuteCommandPrompt(string Command)
        {
            #region            
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.UseShellExecute = false;
            //startInfo.RedirectStandardOutput = true;
            //startInfo.FileName = "CMD.exe";
            //startInfo.Arguments = "dir";
            //process.StartInfo = startInfo;
            //process.Start();
            //string output = process.StandardOutput.ReadToEnd();
            ////MessageBox.Show(output);
            //process.WaitForExit();


            //ProcessStartInfo ProcessInfo;
            //Process Process;
            //ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + Command);
            //ProcessInfo.CreateNoWindow = true;
            //ProcessInfo.UseShellExecute = true;
            //ProcessInfo.WorkingDirectory = "C:/Windows/system32";
            //Process = Process.Start(ProcessInfo);
            #endregion
            try
            {
                ProcessStartInfo ProcessInfo;
                Process Process;
                if (Command != null && Command.Length > 0)
                {
                    ProcessInfo = new ProcessStartInfo("cmd.exe");
                    ProcessInfo.RedirectStandardInput = true;
                    ProcessInfo.RedirectStandardOutput = true;
                    ProcessInfo.UseShellExecute = false;
                    Process = Process.Start(ProcessInfo);
                    Process.StandardInput.WriteLine(Command);
                    Process.StandardInput.WriteLine("exit");
                    string standardOutput = Process.StandardOutput.ReadToEnd();
                    return standardOutput;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        public static void DisconnectCommandPrompt()
        {
            try
            {
                Process[] RDPprocess = Process.GetProcessesByName("cmd");
                if (RDPprocess != null && RDPprocess.Length > 0)
                {
                    int RDPId = RDPprocess[0].Id;
                    Process process = Process.GetProcessById(RDPId);
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void SystemEnviroinment(string EnviroinmentIndex, out string MachineName, out string UserName, out string UserDomain,
                                                  out string SystemDirectory, out bool Is64BitOperatingSystem)
        {          

            MachineName = UserName = UserDomain = SystemDirectory  = null;
            Is64BitOperatingSystem = false;

            int[] numbers = EnviroinmentIndex.Split(',').Select(n => int.Parse(n)).ToArray();

            foreach (var item in numbers)
            {
                switch (item)
                {
                    case 0:
                       MachineName =  Environment.MachineName;
                        break;
                    case 1:
                        UserName = Environment.UserName;
                        break;
                    case 2:
                        UserDomain = Environment.UserDomainName;
                        break;
                    case 3:
                        SystemDirectory = Environment.SystemDirectory;
                        break;
                    case 4:
                        Is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
                        break;                    
                    default:
                        MachineName = null;
                        UserName = null;
                        UserDomain = null;
                        SystemDirectory = null;
                        Is64BitOperatingSystem = false;
                        break;
                }
            }        
                 
        }

        public void PirntDialog(string PrinterName,string DocumentName,UInt16 MinPage, UInt16 MaxPage)
        {
            //PrintDialog printDialog = new PrintDialog();
            //PrintDocument printDocument = new PrintDocument();
            //printDocument.DocumentName = DocumentName;

            //printDialog.PrintDocument();


            //printDocument.DefaultPageSettings.PrinterSettings.PrinterName = PrinterName;
            //printDocument.DefaultPageSettings.PrinterSettings.MinimumPage = MinPage;
            //printDocument.DefaultPageSettings.PrinterSettings.MaximumPage = MaxPage;


            //if (printDialog.ShowDialog() == true)
            //    printDocument.Print();

            //if (printDialog.ShowDialog() == DialogResult.OK)

            //    printDoc.Print();

            //PrintDocument printDoc = new PrintDocument();
            //printDoc.DocumentName = "Print Document";
            //printDialog.Document = printDoc;
            //printDialog.AllowSelection = true;
            //printDialog.AllowSomePages = true;

            ////Call ShowDialog




            //PrintDialog pDialog = new PrintDialog();
            //pDialog.PageRangeSelection = PageRangeSelection.AllPages;
            //pDialog.UserPageRangeEnabled = true;

            //pDialog.MinPage = MinPage;
            //pDialog.MaxPage = MaxPage;       



            //// Display the dialog. This returns true if the user presses the Print button.
            //Nullable<Boolean> print = pDialog.ShowDialog();
            //if (print == true)
            //{

            //    var webClient = new System.Net.WebClient();
            //    var data = webClient.DownloadData(DocumentName);
            //    var package = System.IO.Packaging.Package.Open(new System.IO.MemoryStream(data));
            //    var xpsDocument = new System.Windows.Xps.Packaging.XpsDocument(package,
            //                                                              System.IO.Packaging.CompressionOption.SuperFast,
            //                                                              DocumentName);
            //    var sequence = xpsDocument.GetFixedDocumentSequence();


            //    //XpsDocument xpsDocument = new XpsDocument(DocumentName, FileAccess.ReadWrite);//Windows
            //    //FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
            //    //pDialog.PrintDocument(fixedDocSeq.DocumentPaginator, "");//PrintDocument(fixedDocSeq.DocumentPaginator, "Test print job");//PresentaionCore
            //}


        }

        public void PrintPDF(string PDFFilePath)
        {
            PdfDocument doc = new PdfDocument();           
            doc.LoadFromFile(PDFFilePath);
#pragma warning disable CS0618 // Type or member is obsolete
            doc.PrintDocument.Print();
#pragma warning restore CS0618 // Type or member is obsolete
            #region
            //PrintDialog dialogPrint = new PrintDialog();


            //printDialog.Document = printDoc;
            //printDialog.AllowSelection = true;
            //printDialog.AllowSomePages = true;

            //dialogPrint.AllowPrintToFile = true;

            //dialogPrint.AllowSomePages = true;

            //dialogPrint.PrinterSettings.MinimumPage = 1;

            //dialogPrint.PrinterSettings.MaximumPage = doc.Pages.Count;

            //dialogPrint.PrinterSettings.FromPage = 1;

            //dialogPrint.PrinterSettings.ToPage = doc.Pages.Count;




            //if (dialogPrint.ShowDialog() == DialogResult.OK)

            //{

            //    doc.PrintFromPage = dialogPrint.PrinterSettings.FromPage;

            //    doc.PrintToPage = dialogPrint.PrinterSettings.ToPage;

            //    doc.PrinterName = dialogPrint.PrinterSettings.PrinterName;




            //    PrintDocument printDoc = doc.PrintDocument;

            //    printDoc.Print();

            //}
            #endregion
        }

        //public static void Boolmanipulation(bool ADD,bool MUL,bool DIV, out int Add, out int Mul, out int Div)
        //{         

        //    int a = 5;
        //    int b = 5;

        //    Add = Mul = Div = 0;

        //    if (ADD == true)
        //    {
        //        Add = a + b;
        //        Mul = 0;
        //        Div = 0;
        //    }
        //    if (MUL == true)
        //    {
        //        Add = 0;
        //        Mul = a * b;
        //        Div = 0;
        //    }
        //    if (DIV == true)
        //    {
        //        Add = 0;
        //        Mul = 0;
        //        Div = a * b;
        //    }


        //    //if (ADD == true || MUL == true || DIV == true)
        //    //{

        //    //    if (ADD == true)
        //    //    {
        //    //        Add = a + b;

        //    //    }
        //    //    if (MUL == true)

        //    //    {
        //    //        Mul = a * b;
        //    //    }
        //    //    if (DIV == true)
        //    //    {
        //    //        Div = a / b;
        //    //    }
        //    //    else
        //    //    {
        //    //        Add = 0;
        //    //        Mul = 0;
        //    //        Div = 0;
        //    //    }
        //    //}           
        //    //    Add = 0;
        //    //    Mul = 0;
        //    //    Div = 0;

        //}
    }
    
}
