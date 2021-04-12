using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace asciiart {
    class BitmapAscii {

        private int _kernalHeight = 0;
        private int _kernalWidth = 0;
        private int _imageHeight = 0;
        private int _imagewidth = 0;
        private string _asciiArt = "";

        public int KernalHeight {
            set {_kernalHeight = value;}
        }

        public int KernalWidth {
            set {_kernalWidth = value;}
        }
        public string Asciitze(Bitmap image) {
            List<Color> colors = new List<Color>();
            double nominalValue = 0;
            string asciiChars = "";
            Color colcurrent;
            _imageHeight = image.Height;
            _imagewidth = image.Width;

            
            for (int totalY = 0; totalY <  image.Height - 1; totalY+= _kernalHeight) {
                for (int totalX = 0; totalX < image.Width; totalX += _kernalWidth) {
                    for (int y = 0; y < _kernalHeight; y++) {
                        for (int x = 0; x < _kernalWidth; x++) {
                            
                            if (totalX + 1> image.Width) totalX = totalX - _kernalWidth;
                            if (totalY + 1 > image.Height) {
                                totalY = totalY - _kernalHeight;
                            }
                            colcurrent = image.GetPixel(x + totalX, y + totalY);
                            colors.Add(colcurrent);
                        }
                    }
                    nominalValue = AverageColor(colors);
                    asciiChars += GrayToString(nominalValue);
                    asciiChars += "  ";
                    colors.Clear();
                    
                }
                asciiChars+= "\n";
                
            }
            
            
            _asciiArt = asciiChars;
            return _asciiArt;
        }

        public double AveragePixel(int r, int g, int b) {
            double average = (r + g + b)/3;
            return average/255;
        }

        public double AveragePixel(Color color) {
            
            return AveragePixel(color.R, color.G,color.B);
        }

        public double AverageColor(List<Color> colors) {
            double average = 0;
            for (int index = 0; index < colors.Count; index++) {
                 average += AveragePixel(colors[index]);
            }
            average = average/colors.Count;
            return average;
        }

        public string GrayToString(double value) {
            if (value >= 0 && value <= .17) return "*";
            else if (value > .17 && value <= .33) return "+";
            else if (value > .33 && value <= .50) return "-";
            else if (value > .50 && value <= .66) return ",";
            else if (value > .66 && value <= .83) return ".";
            else if (value > .83 && value <= 1) return " ";
            else throw new Exception("value was not in the range of 0 - 1");
        }

        public override string ToString() {
            return _asciiArt;
        }

        
    }
}
