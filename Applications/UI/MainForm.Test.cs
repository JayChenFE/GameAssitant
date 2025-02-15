using GameAssistant.Configs;
using GameAssistant;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameAssitant.Infrastructure.Utils;
using GameAssitant.Applications.Tests;

namespace GameAssitant.Applications.UI
{
    public partial class MainForm
    {

        private async void test_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {

                // 获取输入框中的图片名称
                string imageName = txtImageName.Text.Trim();
                if (string.IsNullOrEmpty(imageName))
                {
                    MessageBox.Show("请输入图片名称！");
                    return;
                }

                // 拼接图片路径
                string imageFolderPath = Config.Instance.ImageFolderPath; // 从配置中获取资源路径
                string imagePath = Path.Combine(imageFolderPath, imageName + ".png");

                // 检查文件是否存在
                if (!File.Exists(imagePath))
                {
                    MessageBox.Show($"图片文件未找到：{imagePath}");
                    return;
                }

                // 尝试查找图片
                var location = ImageRecognition.FindImageOnScreen(imageName);
                if (location != Point.Empty)
                {
                    MessageBox.Show($"找到图片！位置：({location.X}, {location.Y})");
                }
                else
                {
                    MessageBox.Show("未找到图片！");
                }
            });
        }





        private void btnTestCoordinate_Click(object sender, EventArgs e)
        {
            // 获取输入框中的坐标字符串
            string coordinateText = txtTestCoordinate.Text.Trim();

            // 检查输入是否为空
            if (string.IsNullOrEmpty(coordinateText))
            {
                MessageBox.Show("请输入坐标！");
                return;
            }

            // 使用空格分隔坐标
            string[] coordinates = coordinateText.Split(' ');

            // 检查坐标格式是否正确
            if (coordinates.Length != 2)
            {
                MessageBox.Show("坐标格式不正确，请输入类似 '100 200' 的格式！");
                return;
            }

            // 尝试解析 x 和 y 坐标
            if (int.TryParse(coordinates[0].Trim(), out int x) && int.TryParse(coordinates[1].Trim(), out int y))
            {
                // 执行点击操作
                var point = new Point(x, y);

                var scaledPoint = Config.Instance.Scale.CalculateScaledPoint(point);

                Logger.Log($"点击坐标：({x}, {y})");
                for (int i = 0; i < 3; i++)
                {
                    SleepHelper.DelayExecution(1.5);
                    MouseAction.ClickPoint(new Point(x, y));
                }

                Logger.Log($"点击缩放后坐标：({scaledPoint.X}, {scaledPoint.Y})");
                for (int i = 0; i < 3; i++)
                {
                    SleepHelper.DelayExecution(1.5);
                    MouseAction.ClickPoint(scaledPoint);
                }

            }
            else
            {
                MessageBox.Show("坐标格式不正确，请输入有效的数字！");
            }
        }

        private async void btnTestOther_Click(object sender, EventArgs e)
        {
            if (cbxTestOther.SelectedItem is TestBase selectedTest)
            {
                await Task.Run(() => selectedTest.Execute());
            }
            else
            {
                MessageBox.Show("请选择一个测试选项！");
            }
        }

    }
}
