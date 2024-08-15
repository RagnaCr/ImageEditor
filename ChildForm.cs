using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SP_coursework
{
    public partial class ChildForm : Form
    {
        private Bitmap image;
        public string FilePath { get; set; }
        public bool HasUnsavedChanges { get; private set; }

        public ChildForm()
        {
            InitializeComponent();
        }

        public void ShuffleColors(string mode, Dictionary<string, string> componentSwap)
        {
            if (image == null) return;

            Bitmap newImage = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color originalColor = image.GetPixel(x, y);
                    Color newColor = originalColor;

                    if (mode == "Sequential")
                    {
                        int max = Math.Max(originalColor.R, Math.Max(originalColor.G, originalColor.B));
                        switch (max)
                        {
                            case int r when r == originalColor.R:
                                newColor = Color.FromArgb(
                                originalColor.A,
                                originalColor.G,
                                originalColor.R,
                                originalColor.B);
                                break;
                            case int g when g == originalColor.G:
                                newColor = Color.FromArgb(
                                originalColor.A,
                                originalColor.R,
                                originalColor.B,
                                originalColor.G);
                                break;
                            case int b when b == originalColor.B:
                                newColor = Color.FromArgb(
                                originalColor.A,
                                originalColor.B,
                                originalColor.G,
                                originalColor.R);
                                break;
                            default:
                                newColor = Color.FromArgb(
                                originalColor.A,
                                originalColor.R,
                                originalColor.G,
                                originalColor.B);
                                break;
                        }
                    }
                    else if (mode == "Custom")
                    {
                        // Оголошуємо змінні для зберігання значень компонентів
                        int r = originalColor.R, g = originalColor.G, b = originalColor.B;

                        // Отримуємо що міняти і на що міняти зі словника
                        string whatToChange = "", whichToChange = "";
                        foreach (var item in componentSwap)
                        {
                            whatToChange = item.Key;
                            whichToChange = item.Value;
                        }

                        // Змінні для зберігання нових значень компонентів
                        int newRed = r, newGreen = g, newBlue = b;

                        switch (whatToChange)
                        {
                            case "Red":
                                switch (whichToChange)
                                {
                                    case "Green":
                                        newRed = g;
                                        break;
                                    case "Blue":
                                        newRed = b;
                                        break;
                                    default:
                                        newRed = r;
                                        break;
                                }
                                break;
                            case "Green":
                                switch (whichToChange)
                                {
                                    case "Red":
                                        newGreen = r;
                                        break;
                                    case "Blue":
                                        newGreen = b;
                                        break;
                                    default:
                                        newGreen = g;
                                        break;
                                }
                                break;
                            case "Blue":
                                switch (whichToChange)
                                {
                                    case "Red":
                                        newBlue = r;
                                        break;
                                    case "Green":
                                        newBlue = g;
                                        break;
                                    default:
                                        newBlue = b;
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                        newColor = Color.FromArgb(
                            originalColor.A,
                            newRed,
                            newGreen,
                            newBlue
                        );
                    }
                    newImage.SetPixel(x, y, newColor);
                }
            }

            // Замінюємо поточне зображення на нове зі зміненими кольорами
            image.Dispose();
            image = newImage;
            this.BackgroundImage = (Image)image.Clone();
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void Imnoise(string type, params float[] parameters)
        {
            float mean = 0.0f; // математичне очікування: на скільки в середньому буде зсуватися значення пікселя.
            float variance = 0.01f; // дисперсія: визначає ступінь розкиду значень шуму, чим більша дисперсія, тим сильніший розкид значень.

            if (type == "Speckle")
            {
                if (parameters.Length > 0)
                {
                    variance = parameters[1];
                }
            }
            else if (type == "Gaussian")
            {
                if (parameters.Length > 0)
                {
                    mean = parameters[0];
                    variance = parameters.Length > 1 ? parameters[1] : 0.01f;
                }
            }

            Random random = new Random();
            Bitmap newImage = new Bitmap(image);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color originalColor = image.GetPixel(x, y);
                    float gray = (originalColor.R + originalColor.G + originalColor.B) / 3.0f; // робимо зображення полутоном(сірим)

                    if (type == "Gaussian")
                    {
                        float noise = (float)(mean + Math.Sqrt(variance) * random.NextDouble()); // формула гауссова білого шуму
                        gray = MathExtensions.Clamp(gray + noise * 255, 0, 255); // обмежуємо вихідне значення в діапазоні від 0 до 255
                    }
                    else if (type == "Speckle")
                    {
                        float noise = (float)(random.NextDouble() * Math.Sqrt(variance) * 2 - Math.Sqrt(variance)); // формула мультиплікативного шуму
                        gray = MathExtensions.Clamp(gray + noise * gray, 0, 255);
                    }

                    Color newColor = Color.FromArgb((int)gray, (int)gray, (int)gray);
                    newImage.SetPixel(x, y, newColor);
                }
            }

            image.Dispose();
            image = newImage;
            this.BackgroundImage = (Image)image.Clone();
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }


        public void LoadImage(string path)
        {
            if (image != null)
            {
                image.Dispose();
            }

            using (var tempImage = new Bitmap(path))
            {
                image = new Bitmap(tempImage);
            }

            FilePath = path;
            this.BackgroundImage = (Image)image.Clone();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            HasUnsavedChanges = false;
        }
        public void SaveImage()
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                using (var tempImage = new Bitmap(image))
                {
                    tempImage.Save(FilePath);
                }
                HasUnsavedChanges = false;
            }
            else
            {
                string path = SaveImageAs();
                if (!string.IsNullOrEmpty(path))
                {
                    FilePath = path;
                    HasUnsavedChanges = false;
                }
            }
        }
        public string SaveImageAs()
        {
            if (image == null)
            {
                MessageBox.Show("Немає зображення для збереження.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Image Files|*.bmp;*.jpg;*.png;*.gif;*.tiff"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                using (var tempImage = new Bitmap(image))
                {
                    tempImage.Save(path);
                }
                FilePath = path;
                HasUnsavedChanges = false;
                return path;
            }

            return string.Empty;
        }
        private void ChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HasUnsavedChanges)
            {
                var result = MessageBox.Show("Зберегти зміни?", "Завершення", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveImage();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        public string GetImageInfo()
        {
            if (image != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(FilePath); ;
                string fullPath = Path.GetFullPath(fileName);
                string format = Path.GetExtension(FilePath).Substring(1);
                int width = image.Width;
                int height = image.Height;
                float horizontalResolution = image.HorizontalResolution;
                float verticalResolution = image.VerticalResolution;
                float physicalWidth = width / horizontalResolution * 2.54f;
                float physicalHeight = height / verticalResolution * 2.54f;
                string pixelFormat = image.PixelFormat.ToString();
                bool hasAlpha = Image.IsAlphaPixelFormat(image.PixelFormat);
                int bitsPerPixel = Image.GetPixelFormatSize(image.PixelFormat);

                StringBuilder infoBuilder = new StringBuilder();
                infoBuilder.AppendLine($"Ім'я файлу: {fileName}\n");
                infoBuilder.AppendLine($"Повний шлях до файлу: {fullPath}\n");
                infoBuilder.AppendLine($"Формат файлу: {format}\n");
                infoBuilder.AppendLine($"Розміри в пікселях: {width}x{height}\n");
                infoBuilder.AppendLine($"Вертикальна роздільна здатність: {verticalResolution} точок/см\n");
                infoBuilder.AppendLine($"Горизонтальна роздільна здатність: {horizontalResolution} точок/см\n");
                infoBuilder.AppendLine($"Фізичні розміри: {physicalWidth}x{physicalHeight} см\n");
                infoBuilder.AppendLine($"Формат пікселів: {pixelFormat}\n");
                infoBuilder.AppendLine($"Використання біта або байта прозорості: {(hasAlpha ? "Біт" : "Байт")}\n");
                infoBuilder.AppendLine($"Кількість біт на піксель: {bitsPerPixel}");

                return infoBuilder.ToString();
            }
            else
            {
                return "Зображення не завантажено.";
            }
        }
    }
    public static class MathExtensions
    {
        public static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }

}

