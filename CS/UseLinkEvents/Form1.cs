using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraPrinting;


namespace UseLinkEvents {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        // Define background and foreground colors. 
        Color backColor = Color.LightGreen;
        Color foreColor = Color.Green;

        // Create the Marginal Header section. 
        private void link1_CreateMarginalHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e) {
            // Specify font and color settings for the brick graphics. 
            e.Graph.Font = e.Graph.DefaultFont;
            e.Graph.BackColor = Color.Transparent;

            // Set the format string for a page info brick. 
            string format = "Page {0} of {1}";

            // Set the rectangle for a page info brick. 
            RectangleF r = new RectangleF(0, 0, 0, e.Graph.Font.Height);

            // Draw a page info brick, which displays page numbers. 
            PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, format, Color.Black,
                r, BorderSide.None);

            // Set brick alignment. 
            brick.Alignment = BrickAlignment.Far;

            // Enable the auto width option for a brick. 
            brick.AutoWidth = true;

            // Draw a page info brick, which displays current date and time. 
            brick = e.Graph.DrawPageInfo(PageInfo.DateTime, "", Color.Black, r, BorderSide.None);

            // Set a brick's alignment. 
            brick.Alignment = BrickAlignment.Near;

            // Enable the auto width option for a brick. 
            brick.AutoWidth = true;
        }

        // Create the Detail Header section.
        private void link1_CreateDetailHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e) {
            // Specify font and alignment settings for the brick graphics. 
            e.Graph.Font = new Font("Comic Sans MS", 12);
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center, StringAlignment.Center);

            // Set background and foreground colors to predefined values. 
            e.Graph.BackColor = backColor;
            e.Graph.ForeColor = foreColor;

            // Draw 3 bricks containing "I love you". 
            e.Graph.DrawString("I", new Rectangle(0, 0, 150, 25));
            e.Graph.DrawString("love", new Rectangle(150, 0, 50, 25));
            e.Graph.DrawString("you", new Rectangle(200, 0, 50, 25));
        }

        // Create the Detail section. 
        private void link1_CreateDetailArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e) {
            // Create a new rectangle. 
            Rectangle r = new Rectangle(0, 0, 150, 50);
            int top = r.Top;

            // Change string format settings for the brick graphics. 
            e.Graph.StringFormat = e.Graph.StringFormat.ChangeAlignment(StringAlignment.Near);
            e.Graph.StringFormat = e.Graph.StringFormat.ChangeLineAlignment(StringAlignment.Center);

            // Specify font and color settings for the brick graphics. 
            e.Graph.Font = new Font("Tahoma", 16, FontStyle.Bold | FontStyle.Italic);
            e.Graph.BackColor = Color.DeepSkyBlue;
            e.Graph.BorderColor = Color.MidnightBlue;

            // Draw a text brick with "Hello World!". 
            e.Graph.DrawString("Hello World!", Color.Red, r, BorderSide.All);

            // Change font settings for the brick graphics. 
            e.Graph.Font = new Font("Arial", 14, FontStyle.Bold);

            // Draw a text brick with "Good-bye!". 
            top += 50;
            e.Graph.DrawString("Good-bye!", Color.Blue, new Rectangle(0, top, 150, 50),
                BorderSide.All);

            // Change color settings for the brick graphics. 
            e.Graph.BackColor = Color.LightSkyBlue;

            // Draw a check box brick with the unchecked mark. 
            e.Graph.DrawCheckBox(new Rectangle(150, 0, 50, 50), false);

            // Draw a check box brick with the checked mark. 
            e.Graph.DrawCheckBox(new Rectangle(150, top, 50, 50), true);

            // Draw borders around bricks. 
            e.Graph.DrawRect(new Rectangle(200, 0, 50, 50), BorderSide.All, Color.Lavender,
                e.Graph.BorderColor);
            e.Graph.DrawRect(new Rectangle(200, top, 50, 50), BorderSide.All, Color.Lavender,
                e.Graph.BorderColor);

            // Draw an image brick. 
            Bitmap img = (Bitmap)Bitmap.FromFile(@"..\..\fish.bmp");
            img.MakeTransparent();
            e.Graph.DrawImage(img, new Rectangle(200 + (50 - img.Width) / 2, top + (50 - img.Height) / 2,
                img.Width, img.Height), BorderSide.None, Color.Transparent);
        }

        // Create the Marginal Footer section. 
        private void link1_CreateDetailFooterArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e) {
            // Set the background color to Coral. 
            backColor = Color.Coral;

            // Set the foreground color to White. 
            foreColor = Color.White;

            // Add the detail header data to the detail footer section. 
            link1_CreateDetailHeaderArea(sender, e);
        }
    }
}
