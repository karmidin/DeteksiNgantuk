using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace DeteksiNgantuk
{
    public partial class CaptureForm : Form
    {
        private class Titik
        {
            public int Xatas { get; set; }
            public int Yatas { get; set; }
            public int Xbawah { get; set; }
            public int Ybawah { get; set; }
            public bool AtasBawah { get; set; }

            public int XKanan { get; set; }
            public int YKanan { get; set; }
            public int XKiri { get; set; }
            public int YKiri { get; set; }
            public bool KiriKanan { get; set; }
        }

        Image<Gray, byte> rightEyeResult;
        Image<Gray, byte> leftEyeResult;
        Bitmap leftSobelTreshold, rightSobelTreshold;
        Image<Bgr, Byte> img;
        String filePath;

        public CaptureForm()
        {
            InitializeComponent();
        }

        //Deteksi Atas Bawah
        bool DetekAtasBawah(Bitmap bmp, Titik titik)
        {
            titik.AtasBawah = true; //Jika tepi mata terdeteksi dengan sempurna

            int height = bmp.Height;
            int width = bmp.Width;

            bool titikAtas = false;
            bool titikBawah = false;
            int i, j;

            for (i = width / 3; i < width / 1.5; i++)
            {
                for (j = 2; j < height; j++)
                {
                    int pixelR = bmp.GetPixel(i, j).R;
                    int pixelG = bmp.GetPixel(i, j).G;
                    int pixelB = bmp.GetPixel(i, j).B;

                    if (pixelR == 0 || pixelG == 0 || pixelB == 0)
                    {
                        titik.Xatas = i;
                        titik.Yatas = j;
                        titikAtas = true;
                        break;
                    }
                }

                if (titikAtas == true)
                    break;
            }

            if (titikAtas == false)
            {
                titik.AtasBawah = false;
                return titik.AtasBawah;
            }


            for (i = width / 3; i < width / 1.5; i++)
            {
                for (j = height - 1; j > 0; j--)
                {
                    int pixelR = bmp.GetPixel(i, j).R;
                    int pixelG = bmp.GetPixel(i, j).G;
                    int pixelB = bmp.GetPixel(i, j).B;

                    if (pixelR == 0 || pixelG == 0 || pixelB == 0)
                    {
                        titik.Xbawah = i;
                        titik.Ybawah = j;
                        titikBawah = true;
                        break;
                    }
                }

                if (titikBawah == true)
                    break;
            }

            if (titik.Yatas > height / 2 || titik.Ybawah < height / 2)
            {
                titik.AtasBawah = false;
            }

            return titik.AtasBawah;
        }

        //Deteksi Titik Kiri dan Kanan Mata
        bool DetekKiriKanan(Bitmap bmp, Titik titik)
        {
            titik.KiriKanan = true; //Jika tepi mata terdeteksi dengan sempurna

            int height = bmp.Height;
            int width = bmp.Width;

            bool titikKiri = false;
            bool titikKanan = false;

            //titik kiri
            int i = 1;
            int j = 0;

            for (i = 1; i < width; i++)
            {
                for (j = height / 3; j < height / 1.5; j++)
                {
                    int pixelR = bmp.GetPixel(i, j).R;
                    int pixelG = bmp.GetPixel(i, j).G;
                    int pixelB = bmp.GetPixel(i, j).B;

                    if (pixelR == 0 || pixelG == 0 || pixelB == 0)
                    {
                        titik.XKiri = i;
                        titik.YKiri = j;
                        titikKiri = true;
                        break;
                    }
                }

                if (titikKiri == true)
                    break;
            }

            if (titikKiri == false)
            {
                titik.KiriKanan = false;
                return titik.KiriKanan;
            }


            //titik kanan
            for (i = width - 2; i > 1; i--)
            {
                for (j = height / 3; j < height / 1.5; j++)
                {
                    int pixelR = bmp.GetPixel(i, j).R;
                    int pixelG = bmp.GetPixel(i, j).G;
                    int pixelB = bmp.GetPixel(i, j).B;

                    if (pixelR == 0 || pixelG == 0 || pixelB == 0)
                    {
                        titik.XKanan = i;
                        titik.YKanan = j;
                        titikKanan = true;
                        break;
                    }
                }

                if (titikKanan == true)
                {
                    break;
                }
            }

            if (titik.XKiri > width * 0.25 || titik.XKanan < width * 0.75)
            {
                titik.KiriKanan = false;
            }

            return titik.KiriKanan;
        }

        Bitmap CropAtasBawah(Bitmap bmp, Titik titik)
        {
            int newHeight = titik.Ybawah - titik.Yatas;
            Bitmap newBmp = new Bitmap(bmp.Width, newHeight);

            for (int i = 1; i < bmp.Width - 1; i++)
            {
                for (int j = 0; j < newHeight; j++)
                {
                    newBmp.SetPixel(i, j, Color.White);
                    int jT = j + titik.Yatas;
                    Color clr = Color.FromArgb(bmp.GetPixel(i, jT).R, bmp.GetPixel(i, jT).G, bmp.GetPixel(i, jT).B);
                    newBmp.SetPixel(i, j, clr);
                }
            }
            return newBmp;
        }

        //Gambar mata
        Bitmap DrawEye(Bitmap bmp, Titik titik)
        {
            int newHeight = titik.Ybawah - titik.Yatas;
            int newWidth = titik.XKanan - titik.XKiri;
            Bitmap newBmp = new Bitmap(newWidth, newHeight);
            for (int x = 0; x < newBmp.Width; x++)
            {
                for (int y = 0; y < newBmp.Height; y++)
                {
                    newBmp.SetPixel(x, y, Color.Black);
                }
            }

            //Left
            int j = titik.YKiri;
            int tengah = newWidth / 2;
            int mod = 1;
            int segment = (newHeight / j) * 2;
            int loop = 1;

            while (loop <= tengah || j > 0)
            {
                newBmp.SetPixel(loop, j, Color.White);

                if (loop >= tengah)
                {
                    loop = tengah;
                    j -= 1;
                }
                else if (loop % mod == 0)
                    j -= 1;

                if (loop % segment == 0)
                    mod += 1;

                if (j < 0)
                    j = 0;

                loop += 1;
            }

            mod = 1;
            j = titik.YKiri;
            segment = (newHeight / j) * 2;
            loop = 1;
            while (loop < tengah || j < newHeight - titik.YKiri)
            {
                newBmp.SetPixel(loop, j, Color.White);
                if (loop % mod == 0)
                    j += 1;

                if (loop % segment == 0)
                    mod += 1;

                if (j >= newHeight - titik.YKiri)
                    j = newHeight - titik.YKiri;

                if (loop >= tengah)
                {
                    loop = tengah;
                    j += 1;
                }
                else
                {
                    loop += 1;
                }
            }

            //Right
            mod = 1;
            j = titik.YKanan;
            segment = (newHeight / j) * 2 == 0 ? 1 : (newHeight / j) * 2;
            tengah = newWidth / 2;
            loop = newWidth - 1;
            while (loop >= tengah || j > 0)
            {
                newBmp.SetPixel(loop, j, Color.White);

                if (loop <= tengah)
                {
                    loop = tengah;
                    j -= 1;
                }
                else if (loop % mod == 0)
                    j -= 1;

                if (loop % segment == 0)
                    mod += 1;

                if (j < 0)
                    j = 0;

                loop -= 1;
            }

            mod = 1;
            j = titik.YKanan;
            segment = (newHeight / j) * 2 == 0 ? 1 : (newHeight / j) * 2;
            loop = newWidth - 1;
            while (loop > tengah || j < newHeight - titik.YKiri)
            {
                newBmp.SetPixel(loop, j, Color.White);
                if (loop % mod == 0)
                    j += 1;

                if (loop % segment == 0)
                    mod += 1;

                if (j >= newHeight - titik.YKiri)
                    j = newHeight - titik.YKiri;

                if (loop <= tengah)
                {
                    loop = tengah;
                    j += 1;
                }
                else
                {
                    loop -= 1;
                }
            }

            Bitmap resultBmp = new Bitmap(newWidth, newHeight - titik.YKiri);

            for (int x = 1; x < resultBmp.Width - 1; x++)
            {
                for (int y = 1; y < resultBmp.Height - 1; y++)
                {
                    resultBmp.SetPixel(x, y, newBmp.GetPixel(x, y));
                }
            }

            return resultBmp;
        }

        private void CaptureForm_Load(object sender, EventArgs e)
        {

        }

        //private void BtnStop_Click(object sender, EventArgs e)
        //{
        //    if (_capture != null)
        //    {
        //        _capture.Dispose();
        //        Application.Idle -= new EventHandler(FrameGrabber);
        //        btnstart.Enabled = true;
        //        CaptureImgBox.Image = null;
        //    }
        //}

        //Fungsi deteksi tepi menggunakan metode sobel
        private Bitmap sobelfilter(Bitmap bmp)
        {
            int oJ = 9;
            Bitmap b = new Bitmap(bmp);
            Bitmap bb = new Bitmap(bmp.Width, bmp.Height - oJ);
            int width = b.Width;
            int height = b.Height;
            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            int[,] allPixR = new int[width, height];
            int[,] allPixG = new int[width, height];
            int[,] allPixB = new int[width, height];

            int limit = 128 * 32;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0 + oJ; j < height; j++)
                {
                    allPixR[i, j - oJ] = b.GetPixel(i, j).R;
                    allPixG[i, j - oJ] = b.GetPixel(i, j).G;
                    allPixB[i, j - oJ] = b.GetPixel(i, j).B;
                }
            }

            int new_rx = 0, new_ry = 0;
            int new_gx = 0, new_gy = 0;
            int new_bx = 0, new_by = 0;
            int rc, gc, bc;
            for (int i = 1; i < b.Width - 1; i++)
            {
                for (int j = 1 + oJ; j < b.Height - 1; j++)
                {

                    new_rx = 0;
                    new_ry = 0;
                    new_gx = 0;
                    new_gy = 0;
                    new_bx = 0;
                    new_by = 0;
                    rc = 0;
                    gc = 0;
                    bc = 0;

                    for (int wi = -1; wi < 2; wi++)
                    {
                        for (int hw = -1; hw < 2; hw++)
                        {
                            rc = allPixR[i + hw, j - oJ + wi];
                            new_rx += gx[wi + 1, hw + 1] * rc;
                            new_ry += gy[wi + 1, hw + 1] * rc;

                            gc = allPixG[i + hw, j - oJ + wi];
                            new_gx += gx[wi + 1, hw + 1] * gc;
                            new_gy += gy[wi + 1, hw + 1] * gc;

                            bc = allPixB[i + hw, j - oJ + wi];
                            new_bx += gx[wi + 1, hw + 1] * bc;
                            new_by += gy[wi + 1, hw + 1] * bc;

                            //print ke output   
                            //System.Diagnostics.Debug.WriteLine("rc = " + rc.ToString());
                        }
                    }
                    if (new_rx * new_rx + new_ry * new_ry > limit || new_gx * new_gx + new_gy * new_gy > limit || new_bx * new_bx + new_by * new_by > limit)
                        bb.SetPixel(i, j - oJ, Color.Black);
                    else
                        bb.SetPixel(i, j - oJ, Color.White);
                }
            }
            return bb;
        }

        //private void btncapture_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (_capture != null)
        //        {
        //            _capture.Dispose();
        //            Application.Idle -= new EventHandler(FrameGrabber);
        //            btnstart.Enabled = true;
        //            CaptureImgBox.Image = null;
        //        }
        //    }
        //    catch (Exception ex) { }
        //}

        private void TampilkanPesan()
        {
            Titik titikKanan = new Titik();
            DetekAtasBawah(rightSobelTreshold, titikKanan);
            Bitmap kananAtasBawah = CropAtasBawah(rightSobelTreshold, titikKanan);
            DetekKiriKanan(kananAtasBawah, titikKanan);
            Bitmap drawEyeKanan = DrawEye(kananAtasBawah, titikKanan);

            ptbHasilAkhirKanan.Image = drawEyeKanan;

            Titik titikKiri = new Titik();
            DetekAtasBawah(leftSobelTreshold, titikKiri);
            Bitmap kiriAtasBawah = CropAtasBawah(leftSobelTreshold, titikKiri);

            DetekKiriKanan(kiriAtasBawah, titikKiri);
            Bitmap drawEyeKiri = DrawEye(kiriAtasBawah, titikKiri);

            ptbHasilAkhirKiri.Image = drawEyeKiri;

            //Hitung Total Energy
            var listEnergyKanan = HitungEnergy(drawEyeKanan);
            var listEnergyKiri = HitungEnergy(drawEyeKiri);
            double totalEnergyKanan = listEnergyKanan.Sum(a => a.Total);
            double totalEnergyKiri = listEnergyKiri.Sum(a => a.Total);

            //Pengecekan untuk mata setengah tertutup
            //if(totalEnergyKanan >= RangeEnergySetengahTertutup.start && totalEnergyKanan <= RangeEnergySetengahTertutup.end || totalEnergyKiri >= RangeEnergySetengahTertutup.start && totalEnergyKiri <= RangeEnergySetengahTertutup.end)
            //{           
            //    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"EfekSuara.wav");
            //    player.Play();
            //            //Untuk Menampilkan pesan jika masuk dalam range
            //    MessageBox.Show("Kiri: " + totalEnergyKiri.ToString("#,##0") + "\n" + "Kanan: " + totalEnergyKanan.ToString("#,##0"), "Mata Setengah Tertutup");
            //}

            //Pengecekan untuk mata tertutup penuh
            if (totalEnergyKanan >= RangeEnergyTertutupPenuh.start && totalEnergyKanan <= RangeEnergyTertutupPenuh.end || totalEnergyKiri >= RangeEnergyTertutupPenuh.start && totalEnergyKiri <= RangeEnergyTertutupPenuh.end)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"EfekSuara.wav");
                player.Play();

                //Untuk Menampilkan pesan jika masuk dalam range
                MessageBox.Show("Kiri: " + totalEnergyKiri.ToString("#,##0") + "\n" + "Kanan: " + totalEnergyKanan.ToString("#,##0"), "Anda Mengantuk");
            }
            LblEnergyKanan.Text = "Energi Kiri: " + totalEnergyKanan.ToString("#,##0");
            LblEnergyKiri.Text = "Energi Kanan: " + totalEnergyKiri.ToString("#,##0");
        }


        //Fungsi perhitungan Energy
        private List<EnergySUM> HitungEnergy(Bitmap bmp)
        {
            var listEnergy = new List<EnergySUM>();
            try
            {
                for (int i = 1; i < bmp.Width - 1; i++)
                {
                    for (int j = 1; j < bmp.Height - 1; j++)
                    {
                        //Xgrad(i,j) = (i-1, j) - (i+1,j);
                        //Ygrad(i,j) = (i, j-1) - (i,j+1);          
                        //System.Diagnostics.Debug.WriteLine(i.ToString() + "," + j.ToString());
                        var energySum = new EnergySUM(i, j);
                        energySum.XGrad.R = bmp.GetPixel(i - 1, j).R - bmp.GetPixel(i + 1, j).R;
                        energySum.XGrad.G = bmp.GetPixel(i - 1, j).G - bmp.GetPixel(i + 1, j).G;
                        energySum.XGrad.B = bmp.GetPixel(i - 1, j).B - bmp.GetPixel(i + 1, j).B;

                        energySum.YGrad.R = bmp.GetPixel(i, j - 1).R - bmp.GetPixel(i, j + 1).R;
                        energySum.YGrad.G = bmp.GetPixel(i, j - 1).G - bmp.GetPixel(i, j + 1).G;
                        energySum.YGrad.B = bmp.GetPixel(i, j - 1).B - bmp.GetPixel(i, j + 1).B;
                        listEnergy.Add(energySum);
                    }
                }

            }
            catch (Exception ex) { }

            return listEnergy;
        }


        private class Energy
        {
            public int R { get; set; }
            public int G { get; set; }
            public int B { get; set; }

            public double Total
            {
                get
                {
                    return R + G + B;
                }
            }
        }

        private class EnergySUM
        {
            public EnergySUM(int i, int j)
            {
                this.I = i;
                this.J = j;
                XGrad = new Energy();
                YGrad = new Energy();
            }

            public int I { get; set; }
            public int J { get; set; }

            public Energy XGrad { get; set; }
            public Energy YGrad { get; set; }

            public double Total
            {
                get
                {
                    return (Math.Pow(XGrad.Total, 2) + Math.Pow(YGrad.Total, 2));
                }
            }
        }

        //Range nilai untuk mata setengah tertutup
        public static class RangeEnergySetengahTertutup
        {
            public static double start
            {
                get { return 30000000; }
            }
            public static double end
            {
                get { return 58000000; }
            }
        }

        void FrameGrab(String _filePath)
        {
            filePath = _filePath;
            CascadeClassifier faceCascade, eyeCascade;
            faceCascade = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_alt2.xml");
            eyeCascade = new CascadeClassifier(Application.StartupPath + "/haarcascade_RightEye.xml");
            //eyeCascade = new CascadeClassifier(Application.StartupPath + "/haarcascade_eye_tree_eyeglasses.xml");

            rightEyeResult = null;
            leftEyeResult = null;

            img = new Image<Bgr, Byte>(new Bitmap(@filePath));

            using (var imageFrame = img)//_capture.QueryFrame().ToImage<Bgr, Byte>())
            {
                if (imageFrame != null)
                {
                    var faceFrame = imageFrame.Convert<Gray, byte>();
                    var faces = faceCascade.DetectMultiScale(faceFrame, 1.1, 10, Size.Empty); //the actual face detection happens here
                    foreach (var face in faces)
                    {
                        Rectangle rightFace = face;
                        rightFace.Width = face.Width / 2;
                        rightFace.Height = face.Height / 2;

                        Rectangle leftFace = rightFace;
                        leftFace.X = leftFace.X + leftFace.Width;

                        Image<Gray, Byte> rightFaceImage = faceFrame.Copy(rightFace);
                        Image<Gray, Byte> leftFaceImage = faceFrame.Copy(leftFace);

                        imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them                                               
                        imageFrame.Draw(rightFace, new Bgr(Color.Green), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them                                               
                        imageFrame.Draw(leftFace, new Bgr(Color.Blue), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them                                               

                        var rightEyeFrame = rightFaceImage.Convert<Gray, byte>();
                        var rightEyes = eyeCascade.DetectMultiScale(rightEyeFrame);

                        foreach (var eye in rightEyes)
                        {
                            Image<Gray, Byte> eyeImage = rightEyeFrame.Copy(eye);
                            var deepEyeFrame = eyeImage.Convert<Gray, byte>();
                            Rectangle eyeRect = eye;
                            eyeRect.Offset(rightFace.X, rightFace.Y);
                            rightEyeResult = rightEyeFrame.Copy(eye).Convert<Gray, byte>().Resize(100, 60, Inter.Cubic);
                            imageFrame.Draw(eyeRect, new Bgr(Color.Green), 2);
                        }

                        var leftEyeFrame = leftFaceImage.Convert<Gray, byte>();
                        var leftEyes = eyeCascade.DetectMultiScale(leftEyeFrame);

                        foreach (var eye in leftEyes)
                        {
                            Image<Gray, Byte> eyeImage = leftEyeFrame.Copy(eye);
                            var deepEyeFrame = eyeImage.Convert<Gray, byte>();
                            Rectangle eyeRect = eye;
                            eyeRect.Offset(leftFace.X, leftFace.Y);
                            leftEyeResult = leftEyeFrame.Copy(eye).Convert<Gray, byte>().Resize(100, 60, Inter.Cubic); //.Resize(50, 50, Emgu.CV.CvEnum.Inter.Cubic); //100 ukuran pixel hasil capture
                            imageFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                        }
                    }

                    if (rightEyeResult != null && leftEyeResult != null)
                    {
                        RightEyeImgBox.Image = rightEyeResult;
                        Bitmap bmp = rightEyeResult.ToBitmap();
                        rightSobelTreshold = sobelfilter(bmp);
                        RightEyeSobelImgBox.Image = rightSobelTreshold;

                        LeftEyeImgBox.Image = leftEyeResult;
                        bmp = leftEyeResult.ToBitmap();
                        leftSobelTreshold = sobelfilter(bmp);
                        LeftEyeSobelImgBox.Image = leftSobelTreshold;

                        try
                        {
                            TampilkanPesan();
                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex.ToString());
                        }
                    }
                    else
                    {
                        LeftEyeImgBox.Image = null;
                        LeftEyeImgBox.Update();
                        RightEyeImgBox.Image = null;
                        RightEyeImgBox.Update();

                        LeftEyeSobelImgBox.Image = null;
                        LeftEyeSobelImgBox.Update();
                        RightEyeSobelImgBox.Image = null;
                        RightEyeSobelImgBox.Update();

                        ptbHasilAkhirKanan.Image = null;
                        ptbHasilAkhirKanan.Update();
                        ptbHasilAkhirKiri.Image = null;
                        ptbHasilAkhirKiri.Update();
                    }

                }
                CaptureImgBox.Image = imageFrame;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            
            ofdGambar.Filter = "JPEG Files|*.JPEG;*.JPG;|Bitmap Files|*.BMP;";
            ofdGambar.DefaultExt = "JPG";
            ofdGambar.FileName = "";

            if (ofdGambar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                FrameGrab(ofdGambar.FileName);
                txtFilePath.Text = ofdGambar.FileName;
                lblName.Text = ofdGambar.SafeFileName;
                lblFormat.Text = Path.GetExtension(ofdGambar.FileName).ToUpper();
                lblDimensions.Text = new Bitmap(@filePath).Width.ToString() + " x "+new Bitmap(@filePath).Height.ToString() + " (pixels) ";
                lblSize.Text = (new FileInfo(ofdGambar.FileName).Length / 1024).ToString() + " KB";
            }
        }
        //Range nilai untuk mata tertutup penuh
        public static class RangeEnergyTertutupPenuh
        {
            public static double start
            {
                get { return 5000000; }
            }
            public static double end
            {
                get { return 15000000; }
            }
        }
    }
}

