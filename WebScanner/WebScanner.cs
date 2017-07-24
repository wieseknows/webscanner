using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebScanner.Classes;

namespace WebScanner {
    public partial class WebScanner : Form {
        public WebScanner() {
            InitializeComponent();
            ScanFinished += RefreshStats;
        }

        public event Action<bool> ScanFinished;
        public List<Domain> ValidDomains = new List<Domain>();
        Queue<string> UrisToScan = new Queue<string>();
        int ScannedCounter, DetectedCounter = 0;
        int QueueCounter = 1;
        public bool Active = false;
        string CurrentUri = "";
        public static object Locker = new object();



        public List<Link> GetLinks(string _domain) {
            List<Link> result = new List<Link>();
            try {
                HtmlWeb hw = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc = hw.Load(_domain);
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]")) {
                    result.Add(new Link { Href = link.GetAttributeValue("href", string.Empty) });
                }
            }
            catch (Exception) {
            }
            return result;
        }

        public static IEnumerable<char[]> Combinations(int _numberOfChars) {
            string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
            char[] result = new char[_numberOfChars];
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0) {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value < alphabet.Length) {
                    result[index++] = alphabet[++value - 1];
                    stack.Push(value);

                    if (index == _numberOfChars) {
                        yield return result;
                        break;
                    }
                }
            }
        }

        private void RefreshStats(bool _finished) {
            Invoke(new Action(() => { scanned_label.Text = "Scanned: " + ScannedCounter.ToString(); }));
            Invoke(new Action(() => { detected_label.Text = "Detected: " + DetectedCounter.ToString(); }));
            Invoke(new Action(() => { current_label.Text = "Current: " + CurrentUri; }));
        }

        public void Scan() {
            CurrentUri = Thread.CurrentThread.Name;
            var result = GetHtmlFromUri(Thread.CurrentThread.Name);
            lock (Locker) {
                if (result is String) {
                    DetectedCounter++;
                    ValidDomains.Add(new Domain {
                        Uri = Thread.CurrentThread.Name,
                        Html = Convert.ToString(result),
                        Links = GetLinks(Thread.CurrentThread.Name)
                    });
                    //using (var db = new DomainContext()) {
                    //    var domain = new Domain { Uri = Thread.CurrentThread.Name, Html = Convert.ToString(result) };
                    //    domain.Links.Add(new Link { Href = "link1" });
                    //    domain.Links.Add(new Link { Href = "link2" });
                    //    db.Domains.Add(domain);
                    //}
                }
                ScannedCounter++;
                ScanFinished(true);
            }
        }

        public void GetUris(int _number) {
            UrisToScan.Clear();
            foreach (char[] chars in Combinations(_number)) {
                UrisToScan.Enqueue((@"http:\\" + (new string(chars)) + ".by"));
            }
        }

        public object GetHtmlFromUri(string _uri) {
            string htmlCode = "";
            try {
                using (WebClient client = new WebClient()) {
                    htmlCode = client.DownloadString(_uri);
                }
            }
            catch (Exception) {
                return false;
            }
            return Convert.ToString(htmlCode);
        }



        private void stop_button_Click(object sender, EventArgs e) {
            Active = false;
            start_button.Enabled = true;

            using (var db = new DomainContext()) {
                foreach (var domain in ValidDomains) {
                    db.Domains.Add(domain);
                }
                db.SaveChanges();
            }
        }

        private void start_button_Click(object sender, EventArgs e) {
            start_button.Enabled = false;
            Active = true;
            if (QueueCounter == 1) {
                GetUris(QueueCounter);
                Thread.Sleep(0);
            }
            Thread thread = new Thread(delegate () {
                while (Active) {
                    Thread backgroundThread = new Thread(Scan);
                    backgroundThread.Name = UrisToScan.Dequeue();
                    backgroundThread.Start();

                    if (UrisToScan.Count == 0) {
                        GetUris(++QueueCounter);
                    }
                }
            });
            thread.Start();
        }
    }
}