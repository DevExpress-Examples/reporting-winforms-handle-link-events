Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting


Namespace UseLinkEvents
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        ' Define background and foreground colors. 

        Private _backColor As Color = Color.LightGreen

        Private _foreColor As Color = Color.Green

        ' Create the Marginal Header section. 
        Private Sub link1_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles link1.CreateMarginalHeaderArea
            ' Specify font and color settings for the brick graphics. 
            e.Graph.Font = e.Graph.DefaultFont
            e.Graph.BackColor = Color.Transparent

            ' Set the format string for a page info brick. 
            Dim format As String = "Page {0} of {1}"

            ' Set the rectangle for a page info brick. 
            Dim r As New RectangleF(0, 0, 0, CType(e.Graph.Font, Font).Height)

            ' Draw a page info brick, which displays page numbers. 
            Dim brick As PageInfoBrick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, format, Color.Black, r, BorderSide.None)

            ' Set brick alignment. 
            brick.Alignment = BrickAlignment.Far

            ' Enable the auto width option for a brick. 
            brick.AutoWidth = True

            ' Draw a page info brick, which displays current date and time. 
            brick = e.Graph.DrawPageInfo(PageInfo.DateTime, "", Color.Black, r, BorderSide.None)

            ' Set a brick's alignment. 
            brick.Alignment = BrickAlignment.Near

            ' Enable the auto width option for a brick. 
            brick.AutoWidth = True
        End Sub

        ' Create the Detail Header section.
        Private Sub link1_CreateDetailHeaderArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles link1.CreateDetailHeaderArea
            ' Specify font and alignment settings for the brick graphics. 
            e.Graph.Font = New Font("Comic Sans MS", 12)
            e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center, StringAlignment.Center)

            ' Set background and foreground colors to predefined values. 
            e.Graph.BackColor = _backColor
            e.Graph.ForeColor = _foreColor

            ' Draw 3 bricks containing "I love you". 
            e.Graph.DrawString("I", New Rectangle(0, 0, 150, 25))
            e.Graph.DrawString("love", New Rectangle(150, 0, 50, 25))
            e.Graph.DrawString("you", New Rectangle(200, 0, 50, 25))
        End Sub

        ' Create the Detail section. 
        Private Sub link1_CreateDetailArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles link1.CreateDetailArea
            ' Create a new rectangle. 
            Dim r As New Rectangle(0, 0, 150, 50)

            Dim top_Renamed As Integer = r.Top

            ' Change string format settings for the brick graphics. 
            e.Graph.StringFormat = e.Graph.StringFormat.ChangeAlignment(StringAlignment.Near)
            e.Graph.StringFormat = e.Graph.StringFormat.ChangeLineAlignment(StringAlignment.Center)

            ' Specify font and color settings for the brick graphics. 
            e.Graph.Font = New Font("Tahoma", 16, FontStyle.Bold Or FontStyle.Italic)
            e.Graph.BackColor = Color.DeepSkyBlue
            e.Graph.BorderColor = Color.MidnightBlue

            ' Draw a text brick with "Hello World!". 
            e.Graph.DrawString("Hello World!", Color.Red, r, BorderSide.All)

            ' Change font settings for the brick graphics. 
            e.Graph.Font = New Font("Arial", 14, FontStyle.Bold)

            ' Draw a text brick with "Good-bye!". 
            top_Renamed += 50
            e.Graph.DrawString("Good-bye!", Color.Blue, New Rectangle(0, top_Renamed, 150, 50), BorderSide.All)

            ' Change color settings for the brick graphics. 
            e.Graph.BackColor = Color.LightSkyBlue

            ' Draw a check box brick with the unchecked mark. 
            e.Graph.DrawCheckBox(New Rectangle(150, 0, 50, 50), False)

            ' Draw a check box brick with the checked mark. 
            e.Graph.DrawCheckBox(New Rectangle(150, top_Renamed, 50, 50), True)

            ' Draw borders around bricks. 
            e.Graph.DrawRect(New Rectangle(200, 0, 50, 50), BorderSide.All, Color.Lavender, e.Graph.BorderColor)
            e.Graph.DrawRect(New Rectangle(200, top_Renamed, 50, 50), BorderSide.All, Color.Lavender, e.Graph.BorderColor)

            ' Draw an image brick. 
            Dim img As Bitmap = CType(Bitmap.FromFile("..\..\fish.bmp"), Bitmap)
            img.MakeTransparent()
            e.Graph.DrawImage(img, New Rectangle(200 + (50 - img.Width) \ 2, top_Renamed + (50 - img.Height) \ 2, img.Width, img.Height), BorderSide.None, Color.Transparent)
        End Sub

        ' Create the Marginal Footer section. 
        Private Sub link1_CreateDetailFooterArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles link1.CreateDetailFooterArea
            ' Set the background color to Coral. 
            _backColor = Color.Coral

            ' Set the foreground color to White. 
            _foreColor = Color.White

            ' Add the detail header data to the detail footer section. 
            link1_CreateDetailHeaderArea(sender, e)
        End Sub
    End Class
End Namespace
