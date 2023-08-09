using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using NLog.Fluent;
using WpfAppLog.Commands;

namespace WpfAppLog.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private FlowDocument _document;

        
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isLightTheme;
        public bool IsLightTheme
        {
            get => _isLightTheme;
            set
            {
                if (_isLightTheme == value) return;
                _isLightTheme = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLightTheme)));
            }
        }

        public ICommand TestCommand { get; set; }

        public FlowDocument Document
        {
            get { return _document; }
            set
            {
                if (_document == value) return;
                _document = value;
                OnPropertyChanged(nameof(Document));
            }
        }

        public MainViewModel()
        {
            TestCommand = new RelayCommand(param => Test());

            // 初始化 Document 属性
            Document = new FlowDocument();
        }

        private void Clear()
        {
            // 使用反射获取 RichTextBox 控件并调用 Clear 方法
            var rtb = Application.Current.Windows[0]?.FindName("richTextEditor") as RichTextBox;
            if (rtb == null) return;
            var clearMethod = rtb.GetType().GetMethod("Clear", BindingFlags.Instance | BindingFlags.Public);
            if (clearMethod != null)
            {
                clearMethod.Invoke(rtb, null);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private void Test()
        {
            IsLightTheme =!IsLightTheme;
            Debug.WriteLine("Test:" + IsLightTheme);
        }
    }

}
