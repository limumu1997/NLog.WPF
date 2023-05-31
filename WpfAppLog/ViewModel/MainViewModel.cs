using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using WpfAppLog.Commands;

namespace WpfAppLog.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private FlowDocument _document;

        public event PropertyChangedEventHandler PropertyChanged;

        //public ICommand ClearCommand { get; set; }

        public FlowDocument Document
        {
            get { return _document; }
            set
            {
                if (_document != value)
                {
                    _document = value;
                    OnPropertyChanged(nameof(Document));
                }
            }
        }

        public MainViewModel()
        {
            //ClearCommand = new RelayCommand(param => Clear());

            // 初始化 Document 属性
            Document = new FlowDocument();
        }

        private void Clear()
        {
            // 使用反射获取 RichTextBox 控件并调用 Clear 方法
            var rtb = Application.Current.Windows[0].FindName("richTextEditor") as RichTextBox;
            if (rtb != null)
            {
                MethodInfo clearMethod = rtb.GetType().GetMethod("Clear", BindingFlags.Instance | BindingFlags.Public);
                if (clearMethod != null)
                {
                    clearMethod.Invoke(rtb, null);
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public static readonly ICommand Clear1 = new RelayCommand(param => Clear2());

        private static void Clear2()
        {
            // 实现清空操作
        }
    }

}
