using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using System.Threading;
using System.ServiceProcess;
using System.Runtime.InteropServices;

// в планировке задания нет смысла т.к. нет возможности программно выключить антивирусник, которы автоматом убивает "лицензионные файлы
namespace RadminAutomaticActivation
{
    public partial class Form1 : Form
    {
        public List<ClPing.StructArrAddress> ArrAddresses { get; } = new List<ClPing.StructArrAddress>();
        private struct StructExtractFiles
        {
            public string targetFileName;
            public string fullPathToFile;
            public bool check;
            public StructExtractFiles(string targetFileName, string fullPath, bool wrote) {
                this.targetFileName = targetFileName;
                this.fullPathToFile = fullPath;
                this.check = wrote;
            }
        }
        private List<StructExtractFiles> ListExtractFiles { get; } = new List<StructExtractFiles>();
        private string pathToSourceProcess = null;
        private List<IAsyncResult> listAsynhPingDeleg { get; } = new List<IAsyncResult>();

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            BtActivate.BackColor = Color.Gray;
            if (!(new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator)) {
                RichTBConsole.AppendText(InsertCurrentTime() + "Не админ, не смогу перезаписать файлы. Отбой\n");
                return;
            }
            if (!Directory.Exists(TbExtractPath.Text)) {
                RichTBConsole.AppendText(InsertCurrentTime() + "Папки назначения не существует. Отбой\n");
                return;
            }

            string tempPath = "C:\\tempRadminArchiveExtract";
            if (IsArchive(TbArchivePath.Text)) {
                if (Directory.Exists(tempPath)) {
                    Directory.Delete(tempPath, true);
                    Thread.Sleep(50);
                    Directory.CreateDirectory(tempPath);
                } else
                    Directory.CreateDirectory(tempPath);
                tempPath = "C:\\tempRadminArchiveExtract";
                if (!UnZipArchive(tempPath)) { }
            } else {
                if (Directory.Exists(TbArchivePath.Text))
                    tempPath = TbArchivePath.Text;
                else {
                    RichTBConsole.AppendText(InsertCurrentTime() + "Папка источника не сущ. Отбой\n");
                    return;
                }
            }

            ListExtractFiles.Clear();
            for (int i = 0; i < RbRepList.Lines.Count(); i++) {
                if (RbRepList.Lines[ i ] != "") {
                    ListExtractFiles.Add(new StructExtractFiles(RbRepList.Lines[ i ], null, false)); // set target name
                }
            }

            RecursiveFindFile(tempPath);
            bool sectionChech = true; //isAllFilesFind
            for (int i = 0; i < ListExtractFiles.Count; i++) {
                if (ListExtractFiles[ i ].check == false) {
                    sectionChech = false;
                    RichTBConsole.AppendText(ListExtractFiles[ i ].targetFileName + "   не найден. Проверьте антивирус. Или его нет в архиве/папке\n");
                }
            }
            if (!sectionChech) {
                if (tempPath == "C:\\tempRadminArchiveExtract")
                    Directory.Delete(tempPath, true);
                return;
            }
            //inverse before new use
            for (int i = 0; i < ListExtractFiles.Count; i++) {
                ListExtractFiles[ i ] = new StructExtractFiles(ListExtractFiles[ i ].targetFileName, ListExtractFiles[ i ].fullPathToFile, false);
            }

            if (!IsKillRserverSuccess()) { }
            //return; если не убит, то должна быть ошибка перезаписи
            for (int i = 0; i < ListExtractFiles.Count; i++)
                RewriteFile(ListExtractFiles[ i ].fullPathToFile, i);
            if (tempPath == "C:\\tempRadminArchiveExtract")
                Directory.Delete(tempPath, true);

            sectionChech = true; //allIsWrote
            for (int i = 0; i < ListExtractFiles.Count; i++)
                if (!ListExtractFiles[ i ].check)
                    sectionChech = false;
            if (sectionChech)
                BtActivate.BackColor = Color.Green;
            else
                BtActivate.BackColor = Color.Red;

            StartService();
        }
        private void StartService() {
            Process processRadmin = null;
            string path = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Radmin Server 3\\Запустить Radmin Server";
            try {
                processRadmin = Process.Start(pathToSourceProcess);
            } catch {
                RichTBConsole.AppendText(InsertCurrentTime() + "Не удалось запустить сервер из взятого пути. Запуск по стандартному пути...\n");
                try {
                    processRadmin = Process.Start(path);
                    //processRadmin = Process.Start("C:\\Windows\\SysWOW64\\rserver30\\rserver3.exe");
                } catch {
                    RichTBConsole.AppendText(InsertCurrentTime() + "Файл не найден:  ");
                    RichTBConsole.AppendText("C:\\Windows\\SysWOW64\\rserver30\\rserver3.exe\n");
                    return;
                }
                RichTBConsole.AppendText(InsertCurrentTime() + "Программа успешно запущена из:  ");
                RichTBConsole.AppendText(path + "\n");
            }

            ServiceController sc = new ServiceController();
            try {
                sc.ServiceName = "RServer3";
                if (sc.Status == ServiceControllerStatus.Stopped) {
                    try {
                        sc.Start();
                        sc.WaitForStatus(ServiceControllerStatus.Running);
                        RichTBConsole.AppendText(InsertCurrentTime() + "Сервис запущен. Статус:  " + sc.Status.ToString() + "\n");
                    } catch (InvalidOperationException) {
                        RichTBConsole.AppendText(InsertCurrentTime() + "Сервис НЕ запущен. Статус:  " + sc.Status.ToString() + "\n");
                    }
                }
            } catch {
                RichTBConsole.AppendText(InsertCurrentTime() + "Используется неверное имя службы. Посмотрите его: ПКМ → св-ва → " +
                    "имя службы и сообщите разработчику. А пока запустите вручную\n");
            }
        }

        private bool UnZipArchive(string tempPath) {
            ZipArchive zip;
            try {
                zip = ZipFile.Open(TbArchivePath.Text, 0);
            } catch (Exception e) {
                RichTBConsole.AppendText(InsertCurrentTime() + "UnzipMethod: " + e.Message + "\n");
                return false;
            }

            try {
                zip.ExtractToDirectory(tempPath);
            } catch (Exception e) {
                RichTBConsole.AppendText(InsertCurrentTime() + "ExractMethod: " + e.Message + "\n");
                return false;
            }
            //richTBConsole.AppendText(InsertCurrentTime() + "Unzip: Распаковка архива произошла успешно\n");
            return true;
        }

        public static NotifyIcon notifyIcon = new NotifyIcon();

        private void Form1_Load(object sender, EventArgs e) {
            RichTBConsole.AppendText(InsertCurrentTime() + "Остановите защитник\n");
            ArrAddresses.Add(new ClPing.StructArrAddress("nas64", "panelPingnas64", true)); //nas65 by dns
            ArrAddresses.Add(new ClPing.StructArrAddress("192.168.195.17", "panelPing17", true)); //nas64 by ip 
            ArrAddresses.Add(new ClPing.StructArrAddress("10.64.21.18", "panelPing65", true)); //server65

            ClPing clPing = new ClPing(ArrAddresses, this);
            for (int i = 0; i < ArrAddresses.Count; i++)
                listAsynhPingDeleg .Add(new ClPing._PingAndIndicate(ClPing.PingAndIndicate).BeginInvoke(i, null, null));
        }

        private void RecursiveFindFile(string PathToTempFolder) {
            StructExtractFiles tempStruct;
            foreach (string subdir in Directory.GetDirectories(PathToTempFolder)) {
                try {
                    RecursiveFindFile(subdir);
                } catch {
                    RichTBConsole.AppendText(InsertCurrentTime() + "Папка не доступна" + subdir + "\n");
                }
            }
            foreach (string file in Directory.GetFiles(PathToTempFolder)) {
                for (int i = 0; i < ListExtractFiles.Count; i++) {
                    string[] temp = file.Split("\\"[ 0 ]);                            //вохможна неправильная тоработка метда по данной маске
                    string fileName = temp[ temp.Length - 1 ];
                    if (ListExtractFiles[ i ].targetFileName != fileName)
                        continue;
                    if (!ListExtractFiles[ i ].check) {
                        tempStruct.targetFileName = ListExtractFiles[ i ].targetFileName;
                        tempStruct.check = true;
                        tempStruct.fullPathToFile = file;
                        if (RbFromFolder.Checked) {
                            if (file.IndexOf("\\" + TbInFolder.Text + "\\") != -1)
                                //RewriteFile(file, i);
                                ListExtractFiles[ i ] = tempStruct;
                        } else
                            //RewriteFile(file, i);
                            ListExtractFiles[ i ] = tempStruct;
                    }
                }
            }
        }

        private void RewriteFile(string PathToArchiveFile, int index) {
            try {
                string oldFile = TbExtractPath.Text + "\\" + ListExtractFiles[ index ].targetFileName;
                File.SetAttributes(oldFile, FileAttributes.Normal);
                File.Copy(PathToArchiveFile, oldFile, true);
            } catch (UnauthorizedAccessException e) {
                RichTBConsole.AppendText(InsertCurrentTime() + e.Message + "\n");
                MoveFileToDir(PathToArchiveFile, TbExtractPath.Text + "\\", index);
                return;
            } catch (Exception e) {
                RichTBConsole.AppendText(InsertCurrentTime() + "RewriteMethod::" + ListExtractFiles[ index ].targetFileName + "::" + e.Message + "\n");
                return;
            }
            //richTBConsole.AppendText(InsertCurrentTime() + "Успешно перезаписан: " + ListExtractFiles[ index ].targetFileName + "\n");
            //richTBConsole.AppendText("на файл: " + PathToArchiveFile + "\n");
            ListExtractFiles[ index ] = new StructExtractFiles(ListExtractFiles[ index ].targetFileName, ListExtractFiles[ index ].fullPathToFile, true);
        }

        private void MoveFileToDir(string pathToFile, string pathToDestFolder, int index) {
            try {
                RichTBConsole.AppendText(InsertCurrentTime() + "Попытка скопировать в директорию..." + "\n");
                File.Move(pathToFile, pathToDestFolder);
            } catch (Exception e) {
                RichTBConsole.AppendText(InsertCurrentTime() + "MoveMethod: " + e.Message + "\n");
                return;
            }
            RichTBConsole.AppendText(InsertCurrentTime() + "Успешно помещен в директрию: " + ListExtractFiles[ index ].targetFileName + "\n");
        }

        private bool IsKillRserverSuccess() {
            int pid;
            Process[] allProc = Process.GetProcesses();
            for (int i = 0; i < allProc.Length; i++) {
                if (allProc[ i ].ProcessName.IndexOf("rserver") != -1) {
                    pid = allProc[ i ].Id;
                    if ((new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator)) {//adm priv
                        pathToSourceProcess = allProc[ i ].MainModule.FileName;
                        allProc[ i ].Kill();
                        RichTBConsole.AppendText(InsertCurrentTime() + "Путь к .exe определен \n");
                        RichTBConsole.AppendText(pathToSourceProcess + "\n");
                        //check
                        Thread.Sleep(1000);
                        allProc = Process.GetProcesses();
                        bool isLife = true;
                        for (int j = 0; j < allProc.Length; j++) {
                            if ((allProc[ j ].Id == pid) && (allProc[ j ].ProcessName.IndexOf("rserver") != -1)) {
                                isLife = !isLife;
                                break;
                            }
                        }
                        if (isLife) {
                            //richTBConsole.AppendText(InsertCurrentTime() + "Процесс успешно завершен\n");
                            return true;
                        } else {
                            RichTBConsole.AppendText(InsertCurrentTime() + "Попытка завершения процесса не удалась\n");
                            return false;
                        }
                    } else {
                        RichTBConsole.AppendText(InsertCurrentTime() + "Нужны права адм чтобы завершить процесс. Отбой\n");
                        return false;
                    }
                }
            }
            RichTBConsole.AppendText(InsertCurrentTime() + "Процесс RServer не найден. Путь к нему не определен\n");
            return false;
        }

        private string InsertCurrentTime() {
            return DateTime.Now.ToString("hh:mm:ss") + "   ";
        }

        private void bArchivePathClear_Click(object sender, EventArgs e) {
            TbArchivePath.Clear();
        }

        private void bExtractPathClear_Click(object sender, EventArgs e) {
            TbExtractPath.Clear();
        }

        private bool IsArchive(string str) {
            string[] arrStr = str.Split("\\"[ 0 ]);
            if ((arrStr[ arrStr.Length - 1 ].EndsWith(".rar")) || (arrStr[ arrStr.Length - 1 ].EndsWith(".zip")))
                return true;
            return false;
        }

        private void btSetArchPath_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog1 = new OpenFileDialog {
                InitialDirectory = TbArchivePath.Text,
                Title = "Bыберите архив",

                CheckFileExists = true,
                CheckPathExists = true,

                //DefaultExt = "zip",
                //Filter = "(*.zip)|*.rar",
                FilterIndex = 2,
                //RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            try {
                if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                    TbArchivePath.Text = openFileDialog1.FileName;
                }
            } catch {
                RichTBConsole.AppendText(InsertCurrentTime() + "Ошибка открытия папки: неверный путь\n");
            }
        }

        private void btSetExtractPath_Click(object sender, EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Укажите конечный путь извлечния";
            //dialog.RootFolder = Environment.SpecialFolder.Windows;
            DialogResult result = dialog.ShowDialog();
            if (result != DialogResult.Cancel)
                TbExtractPath.Text = dialog.SelectedPath;
            dialog.Dispose();
        }

        private void rbFirstFindFiles_CheckedChanged(object sender, EventArgs e) {
            if (RbFirstFindFiles.Checked)
                TbInFolder.Enabled = false;
            else
                TbInFolder.Enabled = true;
        }

        private void btSetArchFolder_Click(object sender, EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Укажите путь к установщику";
            //dialog.RootFolder = Environment.SpecialFolder.Windows;
            DialogResult result = dialog.ShowDialog();
            if (result != DialogResult.Cancel)
                TbArchivePath.Text = dialog.SelectedPath;
            dialog.Dispose();

        }

        
        private void btLogon_Click(object sender, EventArgs e) {
            bool valid = false; //true is pass wrote correctly
            void SetValidValue(bool value)
            {
                valid = value;
            }

            void SetFullAccessAndExit() {
                for (int i = 0; i < 5; i++) {
                    SendKeys.Send("{Tab}");
                }
                SendKeys.Send(" ");
                Thread.Sleep(1000);
                SendKeys.Send("{Enter}");
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Enter}");
                SendKeys.Send("{Esc}");
            }

            CallBackMy.callbackEventHandler = new CallBackMy.callbackEvent(SetValidValue);
            if (!(new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator)) {
                RichTBConsole.AppendText(InsertCurrentTime() + "Не админ, не смогу вносить изменения. Отбой\n");
                return;
            }
            
            Form Form2 = new Form2();
            Form2.Owner = this;
            Form2.ShowDialog();
            if (!valid) {
                return;
            }
            Color oldColor = BtLogon.BackColor;
            BtLogon.BackColor = Color.Yellow;
            RichTBConsole.AppendText(InsertCurrentTime() + "Начинаю, не меняйте фокус\n");

            /*
            richTBConsole.AppendText(InsertCurrentTime() + "НЕ забирай фокус с радмина!\n");
            if (processRadmin == null) { // attempt find radmin process
                Process[] allProc = Process.GetProcesses();
                for (int i = 0; i < allProc.Length; i++) {
                    if (allProc[ i ].ProcessName.IndexOf("rserver") != -1) {
                        processRadmin = allProc[ i ];
                        break;
                    }
                }
                if (processRadmin == null) //if nothing was found → atemp start service
                    StartService();
            }*/

            IntPtr hwnd = IntPtr.Zero;
            if (hwnd == IntPtr.Zero)
                ExecuteCommandAsAdmin("C:\\Windows\\SysWOW64\\rserver30\\rserver3.exe /setup & exit");
            hwnd = FindWindow(null, "Настройки Radmin Server");
            new _SupportWindowActive(SupportWindowActive).BeginInvoke(hwnd, null, null);

            Thread.Sleep(4000);
            SendKeys.Send("{Down}");
            SendKeys.Send("{Down}");
            SendKeys.Send("{Enter}");
            if (RbActiveAdm.Checked || RbActiveRadm.Checked) {
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Enter}");
                //del record
                for (int i = 0; i < 3; i++)
                    SendKeys.Send("{Tab}");
                SendKeys.Send("{Enter}");
                //open add new user Window
                for (int i = 0; i < 5; i++)
                    SendKeys.Send("{Tab}");
                SendKeys.Send("{Enter}");

                if (RbActiveAdm.Checked) {
                    SendKeys.Send("admin");
                    SendKeys.Send("{Tab}");
                    SendKeys.Send("kfgecbr");
                    SendKeys.Send("{Tab}");
                    SendKeys.Send("kfgecbr");
                    SendKeys.Send("{Tab}");
                    SendKeys.Send("{Enter}");
                } else {
                    SendKeys.Send("radmin");
                    SendKeys.Send("{Tab}");
                    SendKeys.Send("Geujdrf!");
                    SendKeys.Send("{Tab}");
                    SendKeys.Send("Geujdrf!");
                    SendKeys.Send("{Tab}");
                    SendKeys.Send("{Enter}");
                }
                SetFullAccessAndExit();
            } else {
                SendKeys.Send("{Right}");
                SendKeys.Send("{Tab}");
                SendKeys.Send("Enter");
                SendKeys.Send("Enter");
            }
            RichTBConsole.AppendText(InsertCurrentTime() + "Завершил\n");
            BtLogon.BackColor = oldColor;
        }

        public delegate void _SupportWindowActive(IntPtr hwnd);
        public void SupportWindowActive(IntPtr hwnd) {
            while (true) {
                try {
                    SetForegroundWindow(hwnd);
                } catch {
                    return;
                }
                Thread.Sleep(1);
            }
        }


        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private string ExecuteCommandAsAdmin(string command) {

            ProcessStartInfo procStartInfo = new ProcessStartInfo() {
                //RedirectStandardError = true,
                //RedirectStandardOutput = true,
                WindowStyle = ProcessWindowStyle.Minimized,
                UseShellExecute = true,
                CreateNoWindow = true,
                //FileName = "runas.exe",
                //Arguments = "/user:Администратор \"cmd /K " + command + "\""
                FileName = "cmd",
                Arguments = "/K " + command + "\""

            };

            using (Process proc = new Process()) {
                proc.StartInfo = procStartInfo;
                proc.Start();
                return null;
                /*
                string output = proc.StandardOutput.ReadToEnd();

                if (string.IsNullOrEmpty(output))
                    output = proc.StandardError.ReadToEnd();

                return output;
                */
            }
        }

        public class ClPing {
            public ClPing(List<ClPing.StructArrAddress> arrArd, System.Windows.Forms.Form form) {
                pArrAddresses = arrArd;
                MainForm = form;
            }
            public struct StructArrAddress {
                public string IpAddress;
                public string NameOfPanel;
                public bool RunDelegate;
                public StructArrAddress(string ip, string name, bool isRun) {
                    this.IpAddress = ip;
                    this.NameOfPanel = name;
                    this.RunDelegate = isRun;
                }
            }
            public static List<StructArrAddress> pArrAddresses;
            public static System.Windows.Forms.Form MainForm;
            public delegate void _PingAndIndicate(int index);
            public static void PingAndIndicate(int index) {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string data = "packetsOfPingsByRadmin3Activator";
                byte[] buffer = System.Text.Encoding.ASCII.GetBytes(data);
                int timeout = 150;

                while (pArrAddresses[ index ].RunDelegate) {
                    PingReply reply = pingSender.Send(pArrAddresses[ index ].IpAddress, timeout, buffer, options);
                    long timeRep = reply.RoundtripTime;
                    if (reply.Status == IPStatus.Success) {
                        if (timeRep >= 0 && timeRep <= 50)
                            MainForm.Controls[ "groupBox1" ].Controls[ pArrAddresses[ index ].NameOfPanel ].BackColor = Color.Green;
                        if (timeRep > 50 && timeRep <= 100)
                            MainForm.Controls[ "groupBox1" ].Controls[ pArrAddresses[ index ].NameOfPanel ].BackColor = Color.Yellow;
                        if (timeRep > 100)
                            MainForm.Controls[ "groupBox1" ].Controls[ pArrAddresses[ index ].NameOfPanel ].BackColor = Color.Red;
                    } else
                        MainForm.Controls[ "groupBox1" ].Controls[ pArrAddresses[ index ].NameOfPanel ].BackColor = Color.Red;
                    Thread.Sleep(200);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            for (int i = 0; i < ArrAddresses.Count; i++) {
                ArrAddresses[ i ] = (new ClPing.StructArrAddress(null, null, false));
            }
            for (int i = 0; i < listAsynhPingDeleg.Count; i++) {
                listAsynhPingDeleg[ i ].AsyncWaitHandle.WaitOne(250);
            }
        }



    }
}

        
    

