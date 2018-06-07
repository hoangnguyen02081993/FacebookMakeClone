using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetKeyMakeCloneFacebookApp.Helpers
{
    public class Until
    {
        public static void ShowErrorBox(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowInfoBox(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ShowYesNoQuestion(string message)
        {
            return MessageBox.Show(message, "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult ShowYesNoQuestionWarning(string message)
        {
            return MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
        public static string GetRanDomHex(int length)
        {
            Thread.Sleep(10);
            return new Random().Next((int)Math.Pow(16, length - 1), (int)Math.Pow(16, length) - 2).ToString("X");
        }
        public static byte[] Create<T>(T value)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, value);
                return stream.ToArray();
            }
        }
    }
}
