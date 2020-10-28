using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Runtime.InteropServices;
using AutoIt;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

class Model : INotifyPropertyChanged
    {
        
        private string vkId = "https://vk.com/shpikone";
        private string status = "";

    static Regex regex = new Regex("<div class=.pp_status.>(.*?)<");

    public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public string VkId
        {
            get { return vkId; }
            set
            {
                vkId = value;
                OnPropertyChanged("VkId");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void OpenAndParseVk()
        {
            HttpWebRequest request = WebRequest.CreateHttp(VkId);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader streamReader = new StreamReader(response.GetResponseStream());
        string html = streamReader.ReadToEnd();
        Match match = regex.Match(html);
        Status = match.Groups[1].Value;
            var bbb = AutoItX.Run("C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe "+ VkId, "");
        }
    }
